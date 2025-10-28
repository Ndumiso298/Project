
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Utility;
using Project.ViewModels;
using System.Security.Claims;


namespace Project.Controllers
{
    public class AllocatedFridgesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AllocatedFridgesController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Dashbord()
        {
            var totalRequests = _db.tblRequestHeaders.Count();
            var approvedRequests = _db.tblRequestHeaders.Count(r => r.Status == Utility.SD.Approved);
            var pendingRequests = _db.tblRequestHeaders.Count(r => r.Status == Utility.SD.Pending);
            var completedVisits = _db.tblFridgeVisits.Count(v => v.CheckupStatus == "Passed");

            var today = DateTime.Today;
            var visitsToday = _db.tblFridgeVisits.Count(v => v.VisitDate.Date == today);

            
            var visitsByDate = _db.tblFridgeVisits
                .AsEnumerable()  
                .GroupBy(v => v.VisitDate.Date)
                .Select(g => new KeyValuePair<string, int>(g.Key.ToString("yyyy-MM-dd"), g.Count()))
                .OrderBy(x => x.Key)
                .Take(30)
                .ToList();

            var fridgeTypeDistribution = _db.tblFridges
                .AsEnumerable()
                .GroupBy(rf => rf.Brand)
                .Select(g => new KeyValuePair<string, int>(g.Key, g.Count()))
                .ToList();

            var checkupStatusCounts = _db.tblFridgeVisits
                .AsEnumerable()
                .GroupBy(v => v.CheckupStatus)
                .Select(g => new KeyValuePair<string, int>(g.Key, g.Count()))
                .ToList();

            var topCustomers = _db.tblRequestHeaders
                .Include(r => r.Customer.ApplicationUser)
                .AsEnumerable()
                .GroupBy(r => r.Customer.ApplicationUser.FirstName)
                .Select(g => new KeyValuePair<string, int>(g.Key, g.Count()))
                .OrderByDescending(x => x.Value)
                .Take(10)
                .ToList();

            var vm = new DashboardViewModel
            {
                TotalRequests = totalRequests,
                ApprovedRequests = approvedRequests,
                PendingRequests = pendingRequests,
                CompletedVisits = completedVisits,
                VisitsToday = visitsToday,
                VisitsByDate = visitsByDate,
                FridgeTypeDistribution = fridgeTypeDistribution,
                CheckupStatusCounts = checkupStatusCounts,
                TopCustomers = topCustomers
            };

            return View(vm);
        

    }
    public IActionResult Calendar()
    {
            var visits = _db.tblFridgeVisits
                .Include(u=> u.RequestHeader)
                .ThenInclude(u => u.Customer.ApplicationUser)
                .Include(u => u.RequestHeader)
                .ThenInclude(u => u.RequestFridges)
                .ThenInclude(u => u.Fridge)
                .Include(u => u.RequestHeader)
                .ThenInclude(u => u.RequestFridges)
                .ThenInclude(u => u.CustomerFridges)
                .ThenInclude(u => u.FridgeInStock)
                .ToList();
            return View(visits);
        }


        public IActionResult Index()
        {
            var allocatedRequests = _db.tblRequestHeaders
            .Include(u => u.Customer.ApplicationUser)
            .Include(u => u.RequestFridges)
            .ThenInclude(u => u.Fridge)
            .Include(u => u.RequestFridges)
            .ThenInclude(u => u.CustomerFridges)
            .ThenInclude(cf => cf.FridgeInStock)
            .Where(u => u.Status == SD.Approved)
            .ToList();


            var requestIds = allocatedRequests
                .Select(u => u.RequestHeaderId)
                .ToList();

            var visits = _db.tblFridgeVisits
                .Where(u => requestIds.Contains(u.RequestHeaderId))
                .ToList();

            foreach (var request in allocatedRequests)
            {
                request.FridgeVisits = visits
                    .Where(u => u.RequestHeaderId == request.RequestHeaderId)
                    .ToList();
            }

            return View(allocatedRequests);
        }

        public IActionResult CustomerBookings()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); 

            var requests = _db.tblRequestHeaders
                .Include(u => u.Customer.ApplicationUser)
                .Include(u => u.RequestFridges)
                .ThenInclude(u => u.Fridge)
                .Include(u => u.FridgeVisits) 
                .Where(u => u.Customer.ApplicationUserId == userId && u.Status == SD.Approved)
                .ToList();

            return View(requests);
        }

        public IActionResult DetailsFoRProcessing(int id)
        {
            var request = _db.tblRequestHeaders
                .Include(u => u.Customer.ApplicationUser)
                .Include(u => u.RequestFridges)
                .ThenInclude(u => u.Fridge)
                .Include(u => u.RequestFridges)
                .ThenInclude(u => u.CustomerFridges)
                .ThenInclude(u => u.FridgeInStock)
                .FirstOrDefault(u => u.RequestHeaderId == id && u.Status == SD.Approved);

            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }


        public IActionResult SafetyGuideLines()
        {
            return View();
        }

        public IActionResult Completed()
        {
            var visits = _db.tblFridgeVisits
                .Include(u => u.RequestHeader)
                .ThenInclude(u => u.Customer.ApplicationUser)
                .Include(u => u.RequestHeader)
                .ThenInclude(u => u.RequestFridges)
                .ThenInclude(u => u.Fridge)
                .Include(u => u.RequestHeader)
                .ThenInclude(u => u.RequestFridges)
                .ThenInclude(u => u.CustomerFridges)
                .ThenInclude(u => u.FridgeInStock)
                .ToList();

            return View(visits);   
        }


        public IActionResult BookVisit(int requestId, int? visitId)
{
          var request = _db.tblRequestHeaders
            .Include(u => u.RequestFridges)
            .ThenInclude(u => u.Fridge)
            .Include(u => u.RequestFridges)
            .ThenInclude(u => u.CustomerFridges)
            .ThenInclude(u => u.FridgeInStock) 
            .FirstOrDefault(u => u.RequestHeaderId == requestId && u.Status == SD.Approved);

    if (request == null)
    {
        return NotFound();
    }

    ViewBag.CheckupStatusList = new List<SelectListItem>
    {
        new SelectListItem { Text = "Passed", Value = "Passed" },
        new SelectListItem { Text = "Failed", Value = "Failed" },
        new SelectListItem { Text = "In Progress", Value = "In Progress" },
        new SelectListItem { Text = "Not Started", Value = "Not Started" }
    };

    FridgeVisit visit;

    if (visitId.HasValue)
    {
        visit = _db.tblFridgeVisits
            .Include(u => u.RequestHeader)
            .ThenInclude(u => u.RequestFridges)
            .ThenInclude(u => u.Fridge)
            .Include(u => u.RequestHeader)
            .ThenInclude(u => u.RequestFridges)
            .ThenInclude(u => u.CustomerFridges)
            .ThenInclude(u => u.FridgeInStock) 
            .FirstOrDefault(u => u.VisitId == visitId.Value);

        if (visit == null)
        {
            return NotFound();
        }
    }
    else
    {
        visit = new FridgeVisit
        {
            RequestHeaderId = requestId,
            RequestHeader = request,
            VisitDate = DateTime.Now.AddDays(1)
        };
    }

    foreach (var rf in visit.RequestHeader.RequestFridges)
    {
        var firstStock = rf.CustomerFridges?.FirstOrDefault()?.FridgeInStock;
        if (firstStock != null)
        {
            rf.Fridge.FridgeNo = firstStock.FridgeNo;
        }
    }

    return View(visit);
}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BookVisit(FridgeVisit visit)
        {
            if (ModelState.IsValid)
            {
                if (visit.VisitId == 0)
                {
                    _db.tblFridgeVisits.Add(visit);
                }
                else
                {
                    _db.tblFridgeVisits.Update(visit);
                }
                _db.SaveChanges();
                TempData[SD.Success] = "Booking successfully";

                return RedirectToAction("Index", new { id = visit.RequestHeaderId });
            }
            ViewBag.CheckupStatusList = new List<SelectListItem>
            {
               new SelectListItem { Text = "Passed", Value = "Passed" },
               new SelectListItem { Text = "Failed", Value = "Failed" },
               new SelectListItem { Text = "In Progress", Value = "In Progress" },
            };

            
            return View(visit);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ApproveVisit(int visitId)
        {
            var visit = _db.tblFridgeVisits.Find(visitId);
            if (visit == null)
            {
                return NotFound();
            }

            visit.CustomerApproval = SD.Approved;
            _db.SaveChanges();
            TempData[SD.Success] = "Visit successfully Approved";

            return RedirectToAction("CustomerBookings");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeclineVisit(int visitId)
        {
            var visit = _db.tblFridgeVisits.Find(visitId);
            if (visit == null)
            {
                return NotFound();
            }

            visit.CustomerApproval = SD.Declined;
            _db.SaveChanges();
            TempData[SD.Error] = "Visit successfully Decline";

            return RedirectToAction("CustomerBookings");
        }

    }
}


