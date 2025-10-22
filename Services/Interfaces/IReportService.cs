using Project.Models; 


namespace Project.Services.Interfaces
{
    public interface IReportService
    {
        Task<ReportResult> GenerateReportAsync(ReportFilters filters);
    }
}