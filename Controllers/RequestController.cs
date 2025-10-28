using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.ViewModel;
using Project.Utility;
using System.Security.Claims;

namespace Project.Controllers
{
    public class RequestController : Controller
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public RequestVM RequestVM { get; set; }
        public RequestController(ApplicationDbContext db)
        {
            _db = db;
        }

       
        public IActionResult Index(string status)
        {

            IEnumerable<RequestHeader> objRequestHeaders;


            if (User.IsInRole(SD.AdminRole) || User.IsInRole(SD.CustomerSupport))
            {
                objRequestHeaders = _db.tblRequestHeaders.Include(a=>a.Customer.ApplicationUser).ToList();
            }
            else
            {

                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

                objRequestHeaders = _db.tblRequestHeaders
                    .Include(u => u.Customer.ApplicationUser)
                    .Where(r => r.Customer.ApplicationUserId == userId)
                    .ToList();

            }

            return View(objRequestHeaders);
        }


        public IActionResult Details(int id)
        {
            // Fetch full request data with all related entities
            var requestHeader =  _db.tblRequestHeaders
                .Include(r => r.Customer)
                .ThenInclude(c => c.ApplicationUser)
                .Include(r => r.RequestFridges)
                .ThenInclude(d => d.Fridge)
                .Include(r => r.RequestFridges)
                .ThenInclude(d => d.CustomerFridges)
                .ThenInclude(cf => cf.FridgeInStock) // ✅ Includes FridgeNo
                .FirstOrDefault(r => r.RequestHeaderId == id);

            if (requestHeader == null)
            {
                return NotFound();
            }

            RequestVM = new RequestVM
            {
                RequstHeader = requestHeader,
                RequstDetail = requestHeader.RequestFridges.ToList()
            };

            return View(RequestVM);
        }


        [HttpPost]
        public IActionResult UpdateRequestDetail(RequestVM RequestVM)
        {
            if (RequestVM == null || RequestVM.RequstHeader == null)
            {
                return BadRequest("Invalid request data.");
            }

            var RequestHeaderFromDb = _db.tblRequestHeaders
                .FirstOrDefault(u => u.RequestHeaderId == 
                RequestVM.RequstHeader.RequestHeaderId);

            if (RequestHeaderFromDb == null)
            {
                return NotFound("Request not found.");
            }

            RequestHeaderFromDb.FirstName = RequestVM.RequstHeader.FirstName;
            RequestHeaderFromDb.LastName = RequestVM.RequstHeader.LastName;
            RequestHeaderFromDb.CellNumber = RequestVM.RequstHeader.CellNumber;
            RequestHeaderFromDb.StreetAddress = RequestVM.RequstHeader.StreetAddress;
            RequestHeaderFromDb.City = RequestVM.RequstHeader.City;
            RequestHeaderFromDb.State = RequestVM.RequstHeader.State;
            RequestHeaderFromDb.PostalCode = RequestVM.RequstHeader.PostalCode;

           

            _db.tblRequestHeaders.Update(RequestHeaderFromDb);
            _db.SaveChanges();

            TempData[SD.Success] = "Order Details Updated Successfully.";

            return RedirectToAction(nameof(Details), 
                new { id = RequestHeaderFromDb.RequestHeaderId });
        }

        [HttpPost]
        public async Task<IActionResult> Approve(RequestVM RequestVM)
        {
            if (RequestVM == null || RequestVM.RequstHeader == null)
            {
                return BadRequest("Invalid request data.");
            }

            var requestHeaderFromDb = await _db.tblRequestHeaders
                .Include(r => r.RequestFridges)
                    .ThenInclude(d => d.Fridge)
                .Include(r => r.RequestFridges)
                    .ThenInclude(d => d.CustomerFridges)
                        .ThenInclude(cf => cf.FridgeInStock)
                .FirstOrDefaultAsync(r => r.RequestHeaderId == RequestVM.RequstHeader.RequestHeaderId);

            if (requestHeaderFromDb == null)
            {
                return NotFound("Request not found.");
            }

            requestHeaderFromDb.Status = SD.Approved;
            requestHeaderFromDb.RequestDate = DateTime.Now;

            _db.tblRequestHeaders.Update(requestHeaderFromDb);
            await _db.SaveChangesAsync();

            await ReserveApprovedFridges(requestHeaderFromDb);

            TempData[SD.Success] = "Request approved successfully.";

            return RedirectToAction(nameof(Details), new { id = requestHeaderFromDb.RequestHeaderId });
        }

        private async Task ReserveApprovedFridges(RequestHeader requestHeader)
        {
            var fridgesInStock = await _db.tblFridgeInStocks.Where(x => x.IsAvailable).ToListAsync();

            foreach (var detail in requestHeader.RequestFridges)
            {
                if (detail == null) continue;

                var availableFridges = fridgesInStock
                    .Where(x => x.FridgeId == detail.FridgeId)
                    .Take(detail.Count)
                    .ToList();

                foreach (var f in availableFridges)
                {
                    var customerFridge = new CustomerFridge
                    {
                        CustomerID = requestHeader.CustomerID,
                        FridgeId = detail.FridgeId,
                        FridgeInStockId = f.FridgeInStockId,
                        RequestDetailId = detail.RequestDetailId, 
                        ReservedDate = DateTime.Now
                    };
                    _db.tblCustomerFridge.Add(customerFridge);

                    f.IsAvailable = false;
                    _db.tblFridgeInStocks.Update(f);
                }
            }

            await _db.SaveChangesAsync();
        }

        public IActionResult Reject(RequestVM RequestVM)
        {
            if (RequestVM == null || RequestVM.RequstHeader == null)
            {
                return BadRequest("Invalid request data.");
            }

            var requestHeaderFromDb = _db.tblRequestHeaders
                .FirstOrDefault(u => u.RequestHeaderId ==
                RequestVM.RequstHeader.RequestHeaderId);

            if (requestHeaderFromDb == null)
            {
                return NotFound("Request not found.");
            }

            requestHeaderFromDb.Status = SD.Rejected;
            requestHeaderFromDb.RequestDate = DateTime.Now;

            _db.tblRequestHeaders.Update(requestHeaderFromDb);
            _db.SaveChanges();

            TempData[SD.Success] = "Request rejected successfully.";

            return RedirectToAction(nameof(Details), 
                new { id = requestHeaderFromDb.RequestHeaderId });
        }

        public IActionResult Feedback(RequestVM RequestVM)
        {
            if (RequestVM == null || RequestVM.RequstHeader == null)
            {
                return BadRequest("Invalid request data.");
            }

            var requestHeaderFromDb = _db.tblRequestHeaders
                .FirstOrDefault(u => u.RequestHeaderId ==
                RequestVM.RequstHeader.RequestHeaderId);

            if (requestHeaderFromDb == null)
            {
                return NotFound("Request not found.");
            }

            requestHeaderFromDb.Status = SD.NeedsFeedback;
            requestHeaderFromDb.RequestDate = DateTime.Now;

            _db.tblRequestHeaders.Update(requestHeaderFromDb);
            _db.SaveChanges();

            TempData[SD.Success] = "Request marked as needing feedback.";

            return RedirectToAction(nameof(Details), 
                new { id = requestHeaderFromDb.RequestHeaderId });
        }





        [HttpPost]
        public IActionResult ShipOrder()
        {

            var RequestHeader = _db.tblRequestHeaders.
                FirstOrDefault(u => u.RequestHeaderId ==
                RequestVM.RequstHeader.RequestHeaderId);
            //RequestHeader.TrackingNumber = OrderVM.OrderHeader.TrackingNumber;
            RequestHeader.Carrier = RequestVM.RequstHeader.Carrier;
            RequestHeader.ShippingDate = DateTime.Now;
          

            _db.tblRequestHeaders.Update(RequestHeader);
            _db.SaveChanges();
            TempData[SD.Success] = "Order Shipped Successfully.";
            return RedirectToAction(nameof(Details), 
                new { requesId = RequestVM.RequstHeader.RequestHeaderId });
        }






    }
}
