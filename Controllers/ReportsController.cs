using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Models;

using Project.Services.Interfaces;

namespace Project.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ITechnicianService _technicianService;
        private readonly IReportService _reportService;

        public ReportsController(ITechnicianService technicianService, IReportService reportService)
        {
            _technicianService = technicianService;
            _reportService = reportService;
        }

        public IActionResult Index()
        {
            // Populate filter dropdowns
            ViewBag.ReportTypes = new List<SelectListItem>
            {
                new SelectListItem { Value = "faults_summary", Text = "Faults Summary" },
                new SelectListItem { Value = "technician_performance", Text = "Technician Performance" },
                new SelectListItem { Value = "maintenance_schedule", Text = "Maintenance Schedule" },
                new SelectListItem { Value = "customer_reports", Text = "Customer Reports Analysis" },
                new SelectListItem { Value = "response_times", Text = "Response Time Analysis" }
            };

            ViewBag.Statuses = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "All Statuses" },
                new SelectListItem { Value = "Not Started", Text = "Not Started" },
                new SelectListItem { Value = "In Progress", Text = "In Progress" },
                new SelectListItem { Value = "Completed", Text = "Completed" }
            };

            // Get technicians from your service
            var technicians = _technicianService.GetAllTechnicians();
            ViewBag.Technicians = technicians
                .Where(t => !string.IsNullOrEmpty(t.TechnicianAssigned))
                .Select(t => new SelectListItem { Value = t.TechnicianAssigned, Text = t.TechnicianAssigned })
                .ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GenerateReport([FromBody] ReportFilters filters)
        {
            try
            {
                var report = await _reportService.GenerateReportAsync(filters);
                return Json(new { success = true, report = report });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}