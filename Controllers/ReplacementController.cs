//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Project.Data;
//using Project.Models;
//using Project.Models.ViewModel;
//using Project.Utility;
//using System.Security.Claims;

//namespace Project.Controllers
//{
//    public class ReplacementController : Controller
//    {

//        private readonly ApplicationDbContext _db;

//        public ReplacementController(ApplicationDbContext db)
//        {
//            _db = db;
//        }

//        public IActionResult Index()
//        {
//             var fridgeReplacements = _db.tblFridgeReplacements
//                    .Include(fr => fr.FridgeVisit)
//                        .ThenInclude(fv => fv.RequestHeader)
//                        .ThenInclude(rh => rh.Customer)
//                        .ThenInclude(c => c.ApplicationUser)
//                    .Include(fr => fr.FridgeVisit)
//                        .ThenInclude(fv => fv.RequestHeader)
//                        .ThenInclude(rh => rh.RequestFridges)
//                        .ThenInclude(rf => rf.Fridge)
//                    .Include(fr => fr.NewFridgeInStock)
//                        .ThenInclude(nf => nf.Fridge)
//                    .Include(fr => fr.Customer)
//                        .ThenInclude(c => c.ApplicationUser)
//                    .Select(fr => new FridgeReplacementViewModel
//                    {
//                        FridgeReplacementId = fr.FridgeReplacementId,
//                        VisitId = fr.VisitId,
//                        CustomerID = fr.CustomerID,
//                        CustomerName = fr.Customer.ApplicationUser != null ?
//                            $"{fr.Customer.ApplicationUser.FirstName} {fr.Customer.ApplicationUser.LastName}" : "N/A",
//                        CustomerEmail = fr.Customer.ApplicationUser?.Email ?? "N/A",
//                        CustomerPhone = fr.Customer.ApplicationUser?.CellNumber ?? "N/A",
//                        OldFridgeNo = fr.OldFridgeNo,
//                        OldFridgeModel = fr.FridgeVisit.RequestHeader.RequestFridges
//                            .FirstOrDefault().Fridge?.Model ?? "Unknown Model",
//                        ReasonForReplacement = fr.ReasonForReplacement,
//                        AdditionalNotes = fr.AdditionalNotes,
//                        ReplacementDate = fr.ReplacementDate,
//                        RequestDate = fr.RequestDate,
//                        ReplacementStatus = fr.ReplacementStatus,
//                        NewFridgeNo = fr.NewFridgeInStock != null ? fr.NewFridgeInStock.FridgeNo : "Not Assigned",
//                        NewFridgeModel = fr.NewFridgeInStock != null ? fr.NewFridgeInStock.Fridge?.Model : "Not Assigned",
//                        VisitDate = fr.FridgeVisit?.VisitDate ?? DateTime.MinValue,
//                        TechnicianNotes = fr.FridgeVisit?.Notes ?? "No notes available"
//                    })
//                    .OrderByDescending(fr => fr.RequestDate)
//                    .ToList();

//                ViewBag.PendingCount = fridgeReplacements.Count(fr => fr.ReplacementStatus == SD.Pending);
//                ViewBag.ApprovedCount = fridgeReplacements.Count(fr => fr.ReplacementStatus == SD.Approved);
//                ViewBag.CompletedCount = fridgeReplacements.Count(fr => fr.ReplacementStatus == SD.Success);

//                return View(fridgeReplacements);
          
//        }

//        public IActionResult RequestReplacement(int visitId)
//        {
//            var visit = _db.tblFridgeVisits
//                .Include(v => v.RequestHeader)
//                .ThenInclude(rh => rh.Customer.ApplicationUser)
//                .Include(v => v.RequestHeader)
//                .ThenInclude(rh => rh.RequestFridges)
//                .ThenInclude(rf => rf.Fridge)
//                .Include(v => v.RequestHeader)
//                .ThenInclude(rh => rh.RequestFridges)
//                .ThenInclude(rf => rf.CustomerFridges)
//                .ThenInclude(cf => cf.FridgeInStock)
//                .FirstOrDefault(v => v.VisitId == visitId);

//            if (visit == null)
//            {
//                TempData[SD.Error] = "Visit not found";
//                return RedirectToAction("Index");
//            }

//            var customerFridge = visit.RequestHeader.RequestFridges
//                .FirstOrDefault()?.CustomerFridges
//                .FirstOrDefault();

//            if (customerFridge == null)
//            {
//                TempData[SD.Error] = "Customer fridge not found";
//                return RedirectToAction("Index");
//            }

//            var viewModel = new FridgeReplacementViewModel
//            {
//                VisitId = visitId,
//                CustomerID = visit.RequestHeader.CustomerID,
//                CustomerName = visit.RequestHeader.Customer.ApplicationUser?.FirstName + " " +
//                              visit.RequestHeader.Customer.ApplicationUser?.LastName,
//                OldFridgeNo = customerFridge.FridgeInStock?.FridgeNo ?? "Unknown",
//                FridgeModel = visit.RequestHeader.RequestFridges.FirstOrDefault()?.Fridge?.Model ?? "Unknown Model",
//                ReplacementDate = DateTime.Now
//            };

//            ViewBag.ReplacementReasons = new List<SelectListItem>
//            {
//                new SelectListItem { Text = "Fridge Beyond Repair", Value = "Fridge Beyond Repair" },
//                new SelectListItem { Text = "Frequent Breakdowns", Value = "Frequent Breakdowns" },
//                new SelectListItem { Text = "Old Age", Value = "Old Age" },
//                new SelectListItem { Text = "Customer Request", Value = "Customer Request" },
//                new SelectListItem { Text = "Other", Value = "Other" }
//            };

//            return View(viewModel);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]

//        public IActionResult RequestReplacement(FridgeReplacementViewModel viewModel)
//        {
//            if (ModelState.IsValid)
//            {

//                var visit = _db.tblFridgeVisits
//                    .Include(v => v.RequestHeader)
//                    .FirstOrDefault(v => v.VisitId == viewModel.VisitId &&
//                                       v.RequestHeader.CustomerID == viewModel.CustomerID);

//                if (visit == null)
//                {
//                    TempData[SD.Error] = "Visit not found or doesn't belong to this customer";
//                    return RedirectToAction("Index");
//                }

//                var customer = _db.tblCustomer.Find(viewModel.CustomerID);
//                if (customer == null)
//                {
//                    TempData[SD.Error] = "Customer not found";
//                    return RedirectToAction("Index");
//                }

//                var existingReplacement = _db.tblFridgeReplacements
//                    .FirstOrDefault(fr => fr.VisitId == viewModel.VisitId &&
//                                         fr.ReplacementStatus != SD.Rejected);

//                if (existingReplacement != null)
//                {
//                    TempData[SD.Error] = "A replacement request already exists for this visit";
//                    return RedirectToAction("ReplacementRequests");
//                }

//                var replacement = new FridgeReplacement
//                {
//                    VisitId = viewModel.VisitId,
//                    CustomerID = viewModel.CustomerID,
//                    OldFridgeNo = viewModel.OldFridgeNo,
//                    ReasonForReplacement = viewModel.ReasonForReplacement,
//                    AdditionalNotes = viewModel.AdditionalNotes,
//                    ReplacementDate = viewModel.ReplacementDate,
//                    RequestDate = DateTime.Now,
//                    ReplacementStatus = SD.Pending
//                };

//                _db.tblFridgeReplacements.Add(replacement);
//                _db.SaveChanges();

//                TempData[SD.Success] = "Fridge replacement request submitted successfully!";
//                return RedirectToAction("ReplacementRequests");

//            }

//            ViewBag.ReplacementReasons = new List<SelectListItem>
//            {
//               new SelectListItem { Text = "Fridge Beyond Repair", Value = "Fridge Beyond Repair" },
//               new SelectListItem { Text = "Frequent Breakdowns", Value = "Frequent Breakdowns" },
//               new SelectListItem { Text = "Old Age", Value = "Old Age" },
//               new SelectListItem { Text = "Customer Request", Value = "Customer Request" },
//               new SelectListItem { Text = "Other", Value = "Other" }
//             };

//            var customerData = _db.tblCustomer
//                .Include(c => c.ApplicationUser)
//                .FirstOrDefault(c => c.CustomerID == viewModel.CustomerID);

//            if (customerData != null)
//            {
//                viewModel.CustomerName = customerData.ApplicationUser?.FirstName + " " +
//                                       customerData.ApplicationUser?.LastName;
//            }

//            return View(viewModel);
//        }



//        public IActionResult ReplacementRequests()
//        {
//            var customerId = GetCurrentCustomerId();

//            var replacements = _db.tblFridgeReplacements
//                .Include(fr => fr.FridgeVisit)
//                .ThenInclude(fv => fv.RequestHeader)
//                .ThenInclude(rh => rh.RequestFridges)
//                .ThenInclude(rf => rf.Fridge)
//                .Include(fr => fr.NewFridgeInStock)
//                .ThenInclude(nf => nf.Fridge)
//                .Where(fr => fr.CustomerID == customerId)
//                .OrderByDescending(fr => fr.OldFridgeNo)
//                .ToList();

//            return View(replacements);
//        }

//        public IActionResult ReplacementDetails(int id)
//        {
//            var customerId = GetCurrentCustomerId();

//            var replacement = _db.tblFridgeReplacements
//                .Include(fr => fr.FridgeVisit)
//                .ThenInclude(fv => fv.RequestHeader)
//                .ThenInclude(rh => rh.RequestFridges)
//                .ThenInclude(rf => rf.Fridge)
//                .Include(fr => fr.NewFridgeInStock)
//                .ThenInclude(nf => nf.Fridge)
//                .FirstOrDefault(fr => fr.FridgeReplacementId == id && fr.CustomerID == customerId);

//            if (replacement == null)
//            {
//                TempData[SD.Error] = "Replacement request not found";
//                return RedirectToAction("ReplacementRequests");
//            }

//            return View(replacement);
//        }

//        private int GetCurrentCustomerId()
//        {
//            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
//            var customer = _db.tblCustomer.FirstOrDefault(c => c.ApplicationUserId == userId);
//            return customer?.CustomerID ?? 0;
//        }

//    }
//}
