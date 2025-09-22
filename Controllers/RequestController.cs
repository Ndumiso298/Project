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
                objRequestHeaders = _db.tblRequestHeaders.Include(a=>a.ApplicationUser).ToList();
            }
            else
            {

                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

                objRequestHeaders = _db.tblRequestHeaders
                    .Include(u => u.ApplicationUser)
                    .Where(r => r.ApplicationUserId == userId)
                    .ToList();

            }

            return View(objRequestHeaders);
        }

        public IActionResult Details(int id)
        {
            RequestVM = new()
            {
                RequstHeader = _db.tblRequestHeaders
                               .Include(a => a.ApplicationUser)
                               .FirstOrDefault(o => o.RequestHeaderId == id),

                RequstDetail = _db.tblRequestDetais
                               .Include(d => d.Fridge)
                               .Where(d => d.RequestHeaderId == id)
                               .ToList()
            };

            return View(RequestVM);
        }

        [HttpPost]
        [HttpPost]
        public IActionResult UpdateRequestDetail(RequestVM RequestVM)
        {
            if (RequestVM == null || RequestVM.RequstHeader == null)
            {
                return BadRequest("Invalid request data.");
            }

            var RequestHeaderFromDb = _db.tblRequestHeaders
                .FirstOrDefault(u => u.RequestHeaderId == RequestVM.RequstHeader.RequestHeaderId);

            if (RequestHeaderFromDb == null)
            {
                return NotFound("Request not found.");
            }

            // Update properties safely
            RequestHeaderFromDb.FirstName = RequestVM.RequstHeader.FirstName;
            RequestHeaderFromDb.LastName = RequestVM.RequstHeader.LastName;
            RequestHeaderFromDb.CellNumber = RequestVM.RequstHeader.CellNumber;
            RequestHeaderFromDb.StreetAddress = RequestVM.RequstHeader.StreetAddress;
            RequestHeaderFromDb.City = RequestVM.RequstHeader.City;
            RequestHeaderFromDb.State = RequestVM.RequstHeader.State;
            RequestHeaderFromDb.PostalCode = RequestVM.RequstHeader.PostalCode;
            RequestHeaderFromDb.Status = "Allocated";

            if (!string.IsNullOrEmpty(RequestVM.RequstHeader.Carrier))
            {
                RequestHeaderFromDb.Carrier = RequestVM.RequstHeader.Carrier;
            }

            if (RequestVM.RequestFridgeNo?.Fridge != null &&
                !string.IsNullOrEmpty(RequestVM.RequestFridgeNo.Fridge.FridgeNo))
            {
                RequestHeaderFromDb.Carrier = RequestVM.RequestFridgeNo.Fridge.FridgeNo;
            }

            _db.tblRequestHeaders.Update(RequestHeaderFromDb);
            _db.SaveChanges();

            TempData["Success"] = "Order Details Updated Successfully.";

            return RedirectToAction(nameof(Details), new { id = RequestHeaderFromDb.RequestHeaderId });
        }

        
        
      

        [HttpPost]
        public IActionResult ShipOrder()
        {

            var RequestHeader = _db.tblRequestHeaders.FirstOrDefault(u => u.RequestHeaderId == RequestVM.RequstHeader.RequestHeaderId);
            //RequestHeader.TrackingNumber = OrderVM.OrderHeader.TrackingNumber;
            RequestHeader.Carrier = RequestVM.RequstHeader.Carrier;
            RequestHeader.ShippingDate = DateTime.Now;
            //if (RequestHeader.Status == SD.PaymentStatusDelayedPayment)
            //{
            //    RequestHeader.PaymentDueDate = DateTime.Now.AddDays(30);
            //}

            _db.tblRequestHeaders.Update(RequestHeader);
            _db.SaveChanges();
            TempData["Success"] = "Order Shipped Successfully.";
            return RedirectToAction(nameof(Details), new { requesId = RequestVM.RequstHeader.RequestHeaderId });
        }






    }
}
