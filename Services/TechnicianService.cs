using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Services.Interfaces;

namespace Project.Services
{
    public class TechnicianService : ITechnicianService
    {
        private readonly ApplicationDbContext _context;

        public TechnicianService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<FaultTechnician> GetAllTechnicians()
        {
            // Since you're using FaultTechnician as your main model,
            // we'll return distinct technician names from assigned faults
            var technicianNames = _context.tblFaultTechnicians
                .Where(ft => !string.IsNullOrEmpty(ft.TechnicianAssigned))
                .Select(ft => ft.TechnicianAssigned)
                .Distinct()
                .ToList();

            // Create FaultTechnician objects with just the name populated
            return technicianNames.Select(name => new FaultTechnician
            {
                TechnicianAssigned = name
            }).ToList();
        }

        public FaultTechnician GetTechnicianById(int id)
        {
            // Since FaultTechnician uses FaultId as primary key, 
            // this method might not make sense in your current structure
            // You might want to reconsider your model design
            return _context.tblFaultTechnicians
                .FirstOrDefault(ft => ft.FaultId == id && !string.IsNullOrEmpty(ft.TechnicianAssigned));
        }

        public async Task<List<FaultTechnician>> GetActiveTechniciansAsync()
        {
            var technicianNames = await _context.tblFaultTechnicians
                .Where(ft => !string.IsNullOrEmpty(ft.TechnicianAssigned))
                .Select(ft => ft.TechnicianAssigned)
                .Distinct()
                .ToListAsync();

            return technicianNames.Select(name => new FaultTechnician
            {
                TechnicianAssigned = name
            }).ToList();
        }
    }
}