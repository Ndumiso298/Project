using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.ViewModels;
using Project.Utilities;
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
                objRequestHeaders = _db.RequestHeaders.Include(a=>a.Customer).ToList();
            }
            else
            {

                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

                objRequestHeaders = _db.RequestHeaders
                    .Include(u => u.Customer)
                    .Where(r => r.Customer.UserAccount.Id == userId)
                    .ToList();

            }

            return View(objRequestHeaders);
        }

        public IActionResult Details(int id)
        {
            RequestVM = new()
            {
                RequstHeader = _db.RequestHeaders
                               .Include(a => a.Customer)
                               .FirstOrDefault(o => o.Id == id),

                RequestDetails = _db.RequestDetails
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

            var RequestHeaderFromDb = _db.RequestHeaders
                .FirstOrDefault(u => u.Id == RequestVM.RequstHeader.Id);

            if (RequestHeaderFromDb == null)
            {
                return NotFound("Request not found.");
            }

            // Update properties safely
            RequestHeaderFromDb.FirstName = RequestVM.RequstHeader.FirstName;
            RequestHeaderFromDb.LastName = RequestVM.RequstHeader.LastName;
            RequestHeaderFromDb.CellNumber = RequestVM.RequstHeader.CellNumber;
            RequestHeaderFromDb.AddressLine1 = RequestVM.RequstHeader.AddressLine1;
            RequestHeaderFromDb.AddressLine2 = RequestVM.RequstHeader.AddressLine2;
            RequestHeaderFromDb.City = RequestVM.RequstHeader.City;
            RequestHeaderFromDb.Province = RequestVM.RequstHeader.Province;
            RequestHeaderFromDb.PostalCode = RequestVM.RequstHeader.PostalCode;
            RequestHeaderFromDb.Status = "Allocated";

            if (!string.IsNullOrEmpty(RequestVM.RequstHeader.Carrier))
            {
                RequestHeaderFromDb.Carrier = RequestVM.RequstHeader.Carrier;
            }

            if (RequestVM.RequestFridgeNo?.Fridge != null &&
                !string.IsNullOrEmpty(RequestVM.RequestFridgeNo.Fridge.SerialNumber))
            {
                RequestHeaderFromDb.Carrier = RequestVM.RequestFridgeNo.Fridge.SerialNumber;
            }

            _db.RequestHeaders.Update(RequestHeaderFromDb);
            _db.SaveChanges();

            TempData["Success"] = "Order Details Updated Successfully.";

            return RedirectToAction(nameof(Details), new { id = RequestHeaderFromDb.Id });
        }

        [HttpPost]
        
        public IActionResult StartProcessing()
        {
            var requestHeader = _db.RequestHeaders
            .FirstOrDefault(r => r.Id == RequestVM.RequstHeader.Id);

           

            TempData["Success"] = "Request Details Updated Successfully.";
            return RedirectToAction(nameof(Details), new { orderId = RequestVM.RequstHeader.Id });

        }

        [HttpPost]
        public IActionResult ShipOrder()
        {

            var RequestHeader = _db.RequestHeaders.FirstOrDefault(u => u.Id == RequestVM.RequstHeader.Id);
            //RequestHeader.TrackingNumber = OrderVM.OrderHeader.TrackingNumber;
            RequestHeader.Carrier = RequestVM.RequstHeader.Carrier;
            RequestHeader.ShippingDate = DateTime.Now;
            if (RequestHeader.Status == SD.PaymentStatusDelayedPayment)
            {
                RequestHeader.PaymentDueDate = DateTime.Now.AddDays(30);
            }

            _db.RequestHeaders.Update(RequestHeader);
            _db.SaveChanges();
            TempData["Success"] = "Order Shipped Successfully.";
            return RedirectToAction(nameof(Details), new { requesId = RequestVM.RequstHeader.Id });
        }
    }
}
