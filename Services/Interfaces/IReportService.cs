using System.Threading.Tasks;
using Project.Models.ViewModel;

namespace Project.Services.Interfaces
{
    public interface IReportService
    {
        Task<ReportResult> GenerateReportAsync(ReportFilters filters);
        Task<ReportResult> GenerateFaultsSummaryReport(ReportFilters filters);
        Task<ReportResult> GenerateTechnicianPerformanceReport(ReportFilters filters);
        Task<ReportResult> GenerateMaintenanceScheduleReport(ReportFilters filters);
        Task<ReportResult> GenerateCustomerReportsAnalysis(ReportFilters filters);
        Task<ReportResult> GenerateResponseTimeAnalysis(ReportFilters filters);
    }
}