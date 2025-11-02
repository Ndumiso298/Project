using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models.ViewModel;
using Project.Utility;
using System.Security.Claims;

namespace Project.Controllers
{
    public class CustomerSupportController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CustomerSupportController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Dashboard");
        }

        public IActionResult Dashboard()
        {
            var totalRequests = _db.tblRequestHeaders.Count();
            var pendingRequests = _db.tblRequestHeaders.Count(r => r.Status == SD.Pending);
            var approvedRequests = _db.tblRequestHeaders.Count(r => r.Status == SD.Approved);
            var rejectedRequests = _db.tblRequestHeaders.Count(r => r.Status == SD.Rejected);
            var totalCustomers = _db.tblCustomer.Count();
            var relaunchedRequests = _db.tblRequestHeaders.Count(r => r.IsRelaunched);

            var today = DateTime.Today;
            var requestsToday = _db.tblRequestHeaders.Count(r => r.RequestDate.Date == today);

            // Requests by date (last 30 days)
            var requestsByDate = _db.tblRequestHeaders
                .Where(r => r.RequestDate >= DateTime.Today.AddDays(-30))
                .AsEnumerable()
                .GroupBy(r => r.RequestDate.Date)
                .Select(g => new KeyValuePair<string, int>(g.Key.ToString("MMM dd"), g.Count()))
                .OrderBy(x => x.Key)
                .ToList();

            // Request status distribution - INCLUDING RELAUNCHED
            var requestStatusDistribution = _db.tblRequestHeaders
                .AsEnumerable()
                .GroupBy(r => r.Status)
                .Select(g => new KeyValuePair<string, int>(g.Key ?? "Unknown", g.Count()))
                .Where(x => !string.IsNullOrEmpty(x.Key))
                .ToList();

            // Add Relaunched count to the status distribution
            requestStatusDistribution.Add(new KeyValuePair<string, int>("Relaunched", relaunchedRequests));

            // Top requested fridges
            var topRequestedFridges = _db.tblRequestDetais
                .Include(rd => rd.Fridge)
                .AsEnumerable()
                .GroupBy(rd => rd.Fridge?.Brand ?? "Unknown")
                .Select(g => new KeyValuePair<string, int>(g.Key, g.Sum(rd => rd.Count)))
                .OrderByDescending(x => x.Value)
                .Take(5)
                .ToList();

            // Recent activity (last 7 days)
            var recentActivity = _db.tblRequestHeaders
                .Where(r => r.RequestDate >= DateTime.Today.AddDays(-7))
                .Include(r => r.Customer.ApplicationUser)
                .AsEnumerable()
                .GroupBy(r => r.RequestDate.Date)
                .Select(g => new KeyValuePair<string, int>(g.Key.ToString("MMM dd"), g.Count()))
                .OrderBy(x => x.Key)
                .ToList();

            var vm = new CustomerSupportDashboardViewModel
            {
                TotalRequests = totalRequests,
                PendingRequests = pendingRequests,
                ApprovedRequests = approvedRequests,
                RejectedRequests = rejectedRequests,
                TotalCustomers = totalCustomers,
                RelaunchedRequests = relaunchedRequests,
                RequestsToday = requestsToday,
                RequestsByDate = requestsByDate,
                RequestStatusDistribution = requestStatusDistribution,
                TopRequestedFridges = topRequestedFridges,
                RecentActivity = recentActivity
            };

            return View(vm);
        }
    }
}