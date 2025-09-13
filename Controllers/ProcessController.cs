

using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;

namespace FridgeSystem.Controllers
{
    public class ProcessController : Controller
    {

        public class ProcessFaultController : Controller
        {
            private readonly ApplicationDbContext _db;

            public ProcessFaultController(ApplicationDbContext db)
            {
                _db = db;
            }
            public IActionResult Create(int faultId)
            {
                var process = new ProcessFault { FaultId = faultId };
                return View(process);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Create(ProcessFault processFault)
            {
                if (ModelState.IsValid)
                {
                    _db.tblProcessFaults.Add(processFault);
                    _db.SaveChangesAsync();
                    return RedirectToAction("Index", "ProcessFault");
                }
                return View(processFault);
            }
            
            

        }
    }
      
    }

