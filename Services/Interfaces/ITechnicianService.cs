using Project.Models;

namespace Project.Services.Interfaces
{
    public interface ITechnicianService
    {
        List<FaultTechnician> GetAllTechnicians();
        FaultTechnician GetTechnicianById(int id);
        Task<List<FaultTechnician>> GetActiveTechniciansAsync();
    }
}