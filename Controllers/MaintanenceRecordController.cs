/using Microsoft.AspNetCore.Mvc;
//using Project.Data;
//using Project.Models;

//namespace Project.Controllers
//{
//    public class MaintenanceRecordController : Controller
//    {
//        private readonly ApplicationDbContext _db;

//        public MaintenanceRecordController(ApplicationDbContext db)
//        {
//            _db = db;
//        }

//        // GET: MaintenanceRecord
//        public IActionResult Index()
//        {
//            List<MaintenanceRecord> records = _db.tblMaintenanceRecords.ToList();
//            return View(records);
//        }

//        // GET: MaintenanceRecord/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: MaintenanceRecord/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Create(MaintenanceRecord record)
//        {
//            if (ModelState.IsValid)
//            {
//                _db.tblMaintenanceRecords.Add(record);
//                _db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(record);
//        }

//        // GET: MaintenanceRecord/Details/5
//        public IActionResult Details(int id)
//        {
//            var record = _db.tblMaintenanceRecords.FirstOrDefault(r => r.MaintenanceRecordId == id);
//            if (record == null)
//            {
//                return NotFound();
//            }
//            return View(record);
//        }

//        // GET: MaintenanceRecord/Edit/5
//        public IActionResult Edit(int id)
//        {
//            var record = _db.tblMaintenanceRecords.FirstOrDefault(r => r.MaintenanceRecordId == id);
//            if (record == null)
//            {
//                return NotFound();
//            }
//            return View(record);
//        }

//        // POST: MaintenanceRecord/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Edit(MaintenanceRecord record)
//        {
//            if (ModelState.IsValid)
//            {
//                _db.tblMaintenanceRecords.Update(record);
//                _db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(record);
//        }

//        // GET: MaintenanceRecord/Delete/5
//        public IActionResult Delete(int id)
//        {
//            var record = _db.tblMaintenanceRecords.FirstOrDefault(r => r.MaintenanceRecordId == id);
//            if (record == null)
//            {
//                return NotFound();
//            }
//            return View(record);
//        }

//        // POST: MaintenanceRecord/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public IActionResult DeleteConfirmed(int id)
//        {
//            var record = _db.tblMaintenanceRecords.FirstOrDefault(r => r.MaintenanceRecordId == id);
//            if (record == null)
//            {
//                return NotFound();
//            }

//            _db.tblMaintenanceRecords.Remove(record);
//            _db.SaveChanges();
//            return RedirectToAction("Index");
//        }
//    }
//}