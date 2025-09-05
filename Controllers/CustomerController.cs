using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CustomerController(ApplicationDbContext db)
        {
            _db = db;
        }
      
        public IActionResult Index()
        {
            IEnumerable<Fridge> fridgesList=_db.tblFridge.ToList();
            return View(fridgesList);
        }
        public IActionResult Details(int id)
        {
           Fridge objFridge = _db.tblFridge.FirstOrDefault(u=>u.FridgeId==id);
           return View(objFridge);
        }
    }
}
