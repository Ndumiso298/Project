//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Project.Data;
//using Project.Models;
//using Project.Models.ViewModel;

//namespace Project.Controllers
//{
//    public class RequestController : Controller
//    {
//        private readonly ApplicationDbContext _db;
//        [BindProperty]
//        public RequestVM RequestVM { get; set; }
//        public RequestController(ApplicationDbContext db)
//        {
//            _db = db;
//        }

       
//        public IActionResult Index()
//        {
//            return View();
//        }

//        public IActionResult Details(int id)
//        {
//            RequestVM = new()
//            {
//                RequstHeader = _db.tblRequestHeader
//                               .Include(a => a.ApplicationUser)
//                               .FirstOrDefault(o => o.RequestHeaderId == id),

//                RequstDetail = _db.tblRequestDetail
//                               .Include(d => d.Fridge)
//                               .Where(d => d.RequestHeaderId == id)
//                               .ToList()
//            };

//            return View(RequestVM);
//        }

//        [HttpPost]
//        public IActionResult UpdateRequestDetail()
//        {
//            var RequestHeaderFromDb = _db.tblRequestHeader.FirstOrDefault(u => u.RequestHeaderId == RequestVM.RequstHeader.RequestHeaderId);
//            RequestHeaderFromDb.FirstName = RequestVM.RequstHeader.FirstName;
//            RequestHeaderFromDb.LastName = RequestVM.RequstHeader.LastName;
//            RequestHeaderFromDb.CellNumber = RequestVM.RequstHeader.CellNumber;
//            RequestHeaderFromDb.StreetAddress = RequestVM.RequstHeader.StreetAddress;
//            RequestHeaderFromDb.City = RequestVM.RequstHeader.City;
//            RequestHeaderFromDb.State = RequestVM.RequstHeader.State;
//            RequestHeaderFromDb.PostalCode = RequestVM.RequstHeader.PostalCode;
//            if (!string.IsNullOrEmpty(RequestVM.RequstHeader.Carrier))
//            {
//                RequestHeaderFromDb.Carrier = RequestVM.RequstHeader.Carrier;
//            }
//            if (!string.IsNullOrEmpty(RequestVM.RequestFridgeNo.Fridge.FridgeNo))
//            {
//                RequestHeaderFromDb.Carrier = RequestVM.RequestFridgeNo.Fridge.FridgeNo;
//            }
//            _db.tblRequestHeader.Update(RequestHeaderFromDb);
//            _db.SaveChanges();

//            TempData["Success"] = "Order Details Updated Successfully.";


//            return RedirectToAction(nameof(Details), new { id = RequestHeaderFromDb.RequestHeaderId });
//        }






//    }
//}
