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
            RequestVM = new()
            {
                RequstHeader = _db.tblRequestHeaders
                               .Include(a => a.Customer.ApplicationUser)
                               .FirstOrDefault(o => o.RequestHeaderId == id),

                RequstDetail = _db.tblRequestDetails
                               .Include(d => d.Fridge)
                               .Where(d => d.RequestHeaderId == id)
                               .ToList()
            };

           
            ViewBag.CarrierList = new List<string>
    {
        "DHL",
        "Local Delivery",
        "Customer Pickup",
        "Amazon Logistics"
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
        public IActionResult Approve(RequestVM RequestVM)
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

            requestHeaderFromDb.Status = SD.Approved;
            requestHeaderFromDb.RequestDate = DateTime.Now;

            _db.tblRequestHeaders.Update(requestHeaderFromDb);
            _db.SaveChanges();

            ReserveApprovedFridges(RequestVM);

            TempData[SD.Success] = "Request approved successfully.";

            return RedirectToAction(nameof(Details), 
                new { id = requestHeaderFromDb.RequestHeaderId });
        }
        //TODO auto reserve a fridge on approval
        private async  Task ReserveApprovedFridges(RequestVM RequestVM)
        {
            var fridgesInStock = await _db.tblFridgeInStocks.Where(x=>x.IsAvailable).ToListAsync();

            var selectedModels = RequestVM.RequstDetail.Select(x => x.FridgeId).ToList();

            var fridges = fridgesInStock.Where(x => selectedModels.Contains(x.FridgeId)).ToList();
           
            _ = fridges.Take(selectedModels.Count); //TODO double check that the user is allocated the quantity of fridges they actually requested.

            foreach (var f in fridges)
            {
                //TODO insert into CustomerFridges

                //TODO Update reserved fridge status as Unavailable
                f.IsAvailable = false;
                _db.tblFridgeInStocks.Update(f);
            }
            //TODO Save changes
            _db.SaveChanges();

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
            //if (RequestHeader.Status == SD.PaymentStatusDelayedPayment)
            //{
            //    RequestHeader.PaymentDueDate = DateTime.Now.AddDays(30);
            //}

            _db.tblRequestHeaders.Update(RequestHeader);
            _db.SaveChanges();
            TempData[SD.Success] = "Order Shipped Successfully.";
            return RedirectToAction(nameof(Details), 
                new { requesId = RequestVM.RequstHeader.RequestHeaderId });
        }






    }
}
