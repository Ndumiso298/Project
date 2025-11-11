using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.ViewModel;
using Project.Utility;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using ClosedXML.Excel;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Project.Controllers
{
    [Authorize]
    public class ReplacementController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ReplacementController(ApplicationDbContext db)
        {
            _db = db;
        }

        // ===================================================================
        // TECHNICIAN: REQUEST REPLACEMENT
        // ===================================================================
        [Authorize(Roles = SD.FaultTechnician)]
        public IActionResult RequestReplacement(int visitId)
        {
            var visit = _db.tblFridgeVisits
                .Include(v => v.RequestHeader)
                .ThenInclude(rh => rh.Customer!.ApplicationUser)
                .Include(v => v.RequestHeader)
                .ThenInclude(rh => rh.RequestFridges!)
                .ThenInclude(rf => rf.CustomerFridges!)
                .ThenInclude(cf => cf.FridgeInStock)
                .FirstOrDefault(v => v.VisitId == visitId);

            if (visit == null)
            {
                TempData[SD.Error] = "Visit not found";
                return RedirectToAction("Index", "FaultTechnician");
            }

            var customerFridge = visit.RequestHeader?.RequestFridges?
                .FirstOrDefault()?.CustomerFridges?.FirstOrDefault();

            if (customerFridge == null)
            {
                TempData[SD.Error] = "Customer fridge not found";
                return RedirectToAction("Index", "FaultTechnician");
            }

            var viewModel = new FridgeReplacementViewModel
            {
                VisitId = visitId,
                CustomerID = visit.RequestHeader?.CustomerID ?? 0,
                CustomerName = $"{visit.RequestHeader?.Customer?.ApplicationUser?.FirstName} {visit.RequestHeader?.Customer?.ApplicationUser?.LastName}",
                OldFridgeNo = customerFridge.FridgeInStock?.FridgeNo ?? "Unknown",
                FridgeModel = visit.RequestHeader?.RequestFridges?.FirstOrDefault()?.Fridge?.Model ?? "Unknown Model",
                ReplacementDate = DateTime.Now
            };

            ViewBag.ReplacementReasons = GetReplacementReasons();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.FaultTechnician)]
        public IActionResult RequestReplacement(FridgeReplacementViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ReplacementReasons = GetReplacementReasons();
                return View(viewModel);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var visit = _db.tblFridgeVisits
                .Include(v => v.RequestHeader)
                .FirstOrDefault(v => v.VisitId == viewModel.VisitId);

            if (visit == null)
            {
                TempData[SD.Error] = "Visit not found";
                return RedirectToAction("Index", "FaultTechnician");
            }

            // Check for existing pending replacement
            var existingReplacement = _db.tblFridgeReplacements
                .FirstOrDefault(fr => fr.VisitId == viewModel.VisitId &&
                    (fr.ReplacementStatus == SD.Pending || fr.ReplacementStatus == SD.Approved));

            if (existingReplacement != null)
            {
                TempData[SD.Error] = "A replacement request already exists for this visit";
                return RedirectToAction("ReplacementHistory");
            }

            try
            {
                var replacement = new FridgeReplacement
                {
                    VisitId = viewModel.VisitId,
                    CustomerID = viewModel.CustomerID,
                    OldFridgeNo = viewModel.OldFridgeNo,
                    ReasonForReplacement = viewModel.ReasonForReplacement,
                    AdditionalNotes = viewModel.AdditionalNotes,
                    ReplacementDate = viewModel.ReplacementDate,
                    RequestDate = DateTime.Now,
                    ReplacementStatus = SD.Pending,
                    ApplicationUserId = userId
                };

                _db.tblFridgeReplacements.Add(replacement);
                _db.SaveChanges();
                TempData[SD.Success] = "Fridge replacement request submitted successfully!";
                return RedirectToAction("ReplacementHistory");
            }
            catch (Exception ex)
            {
                TempData[SD.Error] = $"Error submitting replacement request: {ex.Message}";
                ViewBag.ReplacementReasons = GetReplacementReasons();
                return View(viewModel);
            }
        }

        // ===================================================================
        // CUSTOMER: VIEW REPLACEMENT REQUESTS
        // ===================================================================
        [Authorize(Roles = SD.CustomerRole)]
        public IActionResult MyReplacements()
        {
            var customerId = GetCurrentCustomerId();
            if (customerId == 0)
            {
                TempData[SD.Error] = "Please log in to view replacement requests";
                return RedirectToAction("Login", "Account");
            }

            var replacements = _db.tblFridgeReplacements
                .Include(fr => fr.FridgeVisit)
                .ThenInclude(fv => fv.RequestHeader)
                .ThenInclude(rh => rh.RequestFridges!)
                .ThenInclude(rf => rf.Fridge)
                .Include(fr => fr.NewFridgeInStock)
                .ThenInclude(nf => nf.Fridge)
                .Where(fr => fr.CustomerID == customerId)
                .OrderByDescending(fr => fr.RequestDate)
                .ToList();

            return View(replacements);
        }

        [Authorize(Roles = SD.CustomerRole)]
        public IActionResult ReplacementDetails(int id)
        {
            var customerId = GetCurrentCustomerId();
            var replacement = _db.tblFridgeReplacements
                .Include(fr => fr.FridgeVisit)
                .ThenInclude(fv => fv.RequestHeader)
                .ThenInclude(rh => rh.RequestFridges!)
                .ThenInclude(rf => rf.Fridge)
                .Include(fr => fr.NewFridgeInStock)
                .ThenInclude(nf => nf.Fridge)
                .Include(fr => fr.ApplicationUser)
                .FirstOrDefault(fr => fr.FridgeReplacementId == id && fr.CustomerID == customerId);

            if (replacement == null)
            {
                TempData[SD.Error] = "Replacement request not found";
                return RedirectToAction("MyReplacements");
            }

            return View(replacement);
        }

        // ===================================================================
        // TECHNICIAN: VIEW REPLACEMENT HISTORY
        // ===================================================================
        [Authorize(Roles = SD.FaultTechnician)]
        public IActionResult ReplacementHistory()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var replacements = _db.tblFridgeReplacements
                .Include(fr => fr.Customer)
                .ThenInclude(c => c.ApplicationUser)
                .Include(fr => fr.FridgeVisit)
                .ThenInclude(fv => fv.RequestHeader)
                .Include(fr => fr.NewFridgeInStock)
                .ThenInclude(nf => nf.Fridge)
                .Where(fr => fr.ApplicationUserId == userId)
                .OrderByDescending(fr => fr.RequestDate)
                .ToList();

            return View(replacements);
        }

        // ===================================================================
        // CUSTOMER SUPPORT: MANAGE REPLACEMENTS
        // ===================================================================
        [Authorize(Roles = $"{SD.CustomerSupport},{SD.AdminRole}")]
        public IActionResult ManageReplacements()
        {
            var replacements = _db.tblFridgeReplacements
                .Include(fr => fr.Customer)
                .ThenInclude(c => c.ApplicationUser)
                .Include(fr => fr.ApplicationUser)
                .Include(fr => fr.FridgeVisit)
                .ThenInclude(fv => fv.RequestHeader)
                .Include(fr => fr.NewFridgeInStock)
                .ThenInclude(nf => nf.Fridge)
                .OrderByDescending(fr => fr.RequestDate)
                .ToList();

            return View(replacements);
        }

        // GET replacement details for modal (AJAX)
        [Authorize(Roles = $"{SD.CustomerSupport},{SD.AdminRole}")]
        public IActionResult GetReplacementDetails(int id)
        {
            var replacement = _db.tblFridgeReplacements
                .Include(fr => fr.Customer)
                .ThenInclude(c => c.ApplicationUser)
                .Include(fr => fr.ApplicationUser)
                .Include(fr => fr.FridgeVisit)
                .ThenInclude(fv => fv.RequestHeader)
                .Include(fr => fr.NewFridgeInStock)
                .ThenInclude(nf => nf.Fridge)
                .FirstOrDefault(fr => fr.FridgeReplacementId == id);

            if (replacement == null)
            {
                return NotFound();
            }

            return PartialView("_ReplacementDetailsPartial", replacement);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = $"{SD.CustomerSupport},{SD.AdminRole}")]
        public async Task<IActionResult> ApproveReplacement(int id)
        {
            var replacement = _db.tblFridgeReplacements
                .Include(fr => fr.Customer)
                .Include(fr => fr.ApplicationUser) // Include the technician who requested the replacement
                .Include(fr => fr.FridgeVisit)
                .ThenInclude(fv => fv.RequestHeader)
                .FirstOrDefault(fr => fr.FridgeReplacementId == id);

            if (replacement == null)
            {
                TempData[SD.Error] = "Replacement request not found";
                return RedirectToAction("ManageReplacements");
            }

            if (replacement.ReplacementStatus != SD.Pending)
            {
                TempData[SD.Error] = "This replacement request has already been processed";
                return RedirectToAction("ManageReplacements");
            }

            try
            {
                // Find an available fridge
                var availableFridge = _db.tblFridgeInStocks
                    .Include(fis => fis.Fridge)
                    .FirstOrDefault(fis => fis.IsAvailable && fis.Status == "Available");

                if (availableFridge == null)
                {
                    TempData[SD.Error] = "No available fridges in stock";
                    return RedirectToAction("ManageReplacements");
                }

                // Get the technician who processed the replacement (the one who requested it)
                var technicianName = replacement.ApplicationUser != null ?
                    $"{replacement.ApplicationUser.FirstName} {replacement.ApplicationUser.LastName}" :
                    "Technician";

                // Get current user's full name (customer support/admin who approved)
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var currentUser = await _db.AppUser.FirstOrDefaultAsync(u => u.Id == userId);
                var approvedByName = currentUser != null ?
                    $"{currentUser.FirstName} {currentUser.LastName}" :
                    User.Identity?.Name ?? "System";

                // Update replacement status - set ActionBy to the technician who processed it
                replacement.ReplacementStatus = SD.Approved;
                replacement.NewFridgeInStockId = availableFridge.FridgeInStockId;
                replacement.ActionDate = DateTime.Now;
                replacement.ActionBy = technicianName; // Set to technician who processed
                replacement.ApprovedBy = approvedByName; // Track who approved

                // Mark the available fridge as allocated
                availableFridge.IsAvailable = false;
                availableFridge.Status = "Allocated";

                await _db.SaveChangesAsync();
                TempData[SD.Success] = $"Replacement approved successfully! New fridge allocated: {availableFridge.FridgeNo}";
            }
            catch (Exception ex)
            {
                TempData[SD.Error] = $"Error approving replacement: {ex.Message}";
            }

            return RedirectToAction("ManageReplacements");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = $"{SD.CustomerSupport},{SD.AdminRole}")]
        public async Task<IActionResult> RejectReplacement(int id)
        {
            var replacement = _db.tblFridgeReplacements
                .Include(fr => fr.ApplicationUser) // Include the technician who requested the replacement
                .FirstOrDefault(fr => fr.FridgeReplacementId == id);

            if (replacement == null)
            {
                TempData[SD.Error] = "Replacement request not found";
                return RedirectToAction("ManageReplacements");
            }

            if (replacement.ReplacementStatus != SD.Pending)
            {
                TempData[SD.Error] = "This replacement request has already been processed";
                return RedirectToAction("ManageReplacements");
            }

            // Get the technician who processed the replacement (the one who requested it)
            var technicianName = replacement.ApplicationUser != null ?
                $"{replacement.ApplicationUser.FirstName} {replacement.ApplicationUser.LastName}" :
                "Technician";

            // Get current user's full name (customer support/admin who rejected)
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentUser = await _db.AppUser.FirstOrDefaultAsync(u => u.Id == userId);
            var rejectedByName = currentUser != null ?
                $"{currentUser.FirstName} {currentUser.LastName}" :
                User.Identity?.Name ?? "System";

            replacement.ReplacementStatus = SD.Rejected;
            replacement.ActionDate = DateTime.Now;
            replacement.ActionBy = technicianName; // Set to technician who processed
            replacement.ApprovedBy = rejectedByName; // Track who rejected

            await _db.SaveChangesAsync();
            TempData[SD.Success] = "Replacement request rejected successfully";
            return RedirectToAction("ManageReplacements");
        }

        // Bulk actions
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = $"{SD.CustomerSupport},{SD.AdminRole}")]
        public async Task<IActionResult> BulkApproveReplacements(string requestIds)
        {
            if (string.IsNullOrEmpty(requestIds))
            {
                TempData[SD.Error] = "No requests selected";
                return RedirectToAction("ManageReplacements");
            }

            var ids = requestIds.Split(',').Select(int.Parse).ToList();
            var replacements = _db.tblFridgeReplacements
                .Include(fr => fr.ApplicationUser) // Include technicians
                .Where(fr => ids.Contains(fr.FridgeReplacementId) && fr.ReplacementStatus == SD.Pending)
                .ToList();

            if (!replacements.Any())
            {
                TempData[SD.Error] = "No pending replacement requests found";
                return RedirectToAction("ManageReplacements");
            }

            var availableFridges = _db.tblFridgeInStocks
                .Where(fis => fis.IsAvailable && fis.Status == "Available")
                .ToList();

            if (availableFridges.Count < replacements.Count)
            {
                TempData[SD.Error] = $"Not enough available fridges. Required: {replacements.Count}, Available: {availableFridges.Count}";
                return RedirectToAction("ManageReplacements");
            }

            // Get current user's full name (customer support/admin who approved)
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentUser = await _db.AppUser.FirstOrDefaultAsync(u => u.Id == userId);
            var approvedByName = currentUser != null ?
                $"{currentUser.FirstName} {currentUser.LastName}" :
                User.Identity?.Name ?? "System";

            await using var transaction = await _db.Database.BeginTransactionAsync();
            try
            {
                for (int i = 0; i < replacements.Count; i++)
                {
                    var replacement = replacements[i];
                    var availableFridge = availableFridges[i];

                    // Get the technician who processed this replacement
                    var technicianName = replacement.ApplicationUser != null ?
                        $"{replacement.ApplicationUser.FirstName} {replacement.ApplicationUser.LastName}" :
                        "Technician";

                    replacement.ReplacementStatus = SD.Approved;
                    replacement.NewFridgeInStockId = availableFridge.FridgeInStockId;
                    replacement.ActionDate = DateTime.Now;
                    replacement.ActionBy = technicianName; // Set to technician who processed
                    replacement.ApprovedBy = approvedByName; // Track who approved

                    availableFridge.IsAvailable = false;
                    availableFridge.Status = "Allocated";
                }

                await _db.SaveChangesAsync();
                await transaction.CommitAsync();
                TempData[SD.Success] = $"Successfully approved {replacements.Count} replacement requests";
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                TempData[SD.Error] = $"Error bulk approving replacements: {ex.Message}";
            }

            return RedirectToAction("ManageReplacements");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = $"{SD.CustomerSupport},{SD.AdminRole}")]
        public async Task<IActionResult> BulkRejectReplacements(string requestIds)
        {
            if (string.IsNullOrEmpty(requestIds))
            {
                TempData[SD.Error] = "No requests selected";
                return RedirectToAction("ManageReplacements");
            }

            var ids = requestIds.Split(',').Select(int.Parse).ToList();
            var replacements = _db.tblFridgeReplacements
                .Include(fr => fr.ApplicationUser) // Include technicians
                .Where(fr => ids.Contains(fr.FridgeReplacementId) && fr.ReplacementStatus == SD.Pending)
                .ToList();

            if (!replacements.Any())
            {
                TempData[SD.Error] = "No pending replacement requests found";
                return RedirectToAction("ManageReplacements");
            }

            // Get current user's full name (customer support/admin who rejected)
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentUser = await _db.AppUser.FirstOrDefaultAsync(u => u.Id == userId);
            var rejectedByName = currentUser != null ?
                $"{currentUser.FirstName} {currentUser.LastName}" :
                User.Identity?.Name ?? "System";

            foreach (var replacement in replacements)
            {
                // Get the technician who processed this replacement
                var technicianName = replacement.ApplicationUser != null ?
                    $"{replacement.ApplicationUser.FirstName} {replacement.ApplicationUser.LastName}" :
                    "Technician";

                replacement.ReplacementStatus = SD.Rejected;
                replacement.ActionDate = DateTime.Now;
                replacement.ActionBy = technicianName; // Set to technician who processed
                replacement.ApprovedBy = rejectedByName; // Track who rejected
            }

            await _db.SaveChangesAsync();
            TempData[SD.Success] = $"Successfully rejected {replacements.Count} replacement requests";
            return RedirectToAction("ManageReplacements");
        }

        // ===================================================================
        // EXPORT FUNCTIONALITY
        // ===================================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = $"{SD.CustomerSupport},{SD.AdminRole}")]
        public IActionResult ExportReplacements(string exportType, string requestIds)
        {
            try
            {
                // Provide default values
                exportType ??= "excel";
                requestIds ??= "all";

                IQueryable<FridgeReplacement> query = _db.tblFridgeReplacements
                    .Include(fr => fr.Customer)
                    .ThenInclude(c => c.ApplicationUser)
                    .Include(fr => fr.ApplicationUser)
                    .Include(fr => fr.FridgeVisit)
                    .ThenInclude(fv => fv.RequestHeader)
                    .Include(fr => fr.NewFridgeInStock)
                    .ThenInclude(nf => nf.Fridge);

                if (requestIds != "all")
                {
                    var ids = requestIds.Split(',').Select(int.Parse).ToList();
                    query = query.Where(fr => ids.Contains(fr.FridgeReplacementId));
                }

                var replacements = query.OrderByDescending(fr => fr.RequestDate).ToList();

                if (!replacements.Any())
                {
                    TempData[SD.Error] = "No replacement requests found to export";
                    return RedirectToAction("ManageReplacements");
                }

                return exportType.ToLower() switch
                {
                    "excel" => ExportToExcel(replacements),
                    "csv" => ExportToCsv(replacements),
                    "pdf" => ExportToPdf(replacements),
                    _ => ExportToExcel(replacements)
                };
            }
            catch (Exception ex)
            {
                TempData[SD.Error] = $"Error exporting replacements: {ex.Message}";
                return RedirectToAction("ManageReplacements");
            }
        }

        private IActionResult ExportToExcel(List<FridgeReplacement> replacements)
        {
            try
            {
                using var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Replacement Requests");

                // Title
                worksheet.Cell(1, 1).Value = "Fridge Replacement Requests - Export Report";
                worksheet.Cell(1, 1).Style.Font.Bold = true;
                worksheet.Cell(1, 1).Style.Font.FontSize = 16;
                worksheet.Range(1, 1, 1, 12).Merge();

                // Export Date
                worksheet.Cell(2, 1).Value = $"Exported on: {DateTime.Now:yyyy-MM-dd HH:mm}";
                worksheet.Cell(2, 1).Style.Font.Italic = true;
                worksheet.Range(2, 1, 2, 12).Merge();

                // Summary
                worksheet.Cell(3, 1).Value = $"Total Requests: {replacements.Count}";
                worksheet.Range(3, 1, 3, 12).Merge();

                // Headers
                var headers = new string[]
                {
                    "Request ID", "Customer Name", "Customer Number", "Old Fridge No",
                    "Reason for Replacement", "Request Date", "Replacement Date", "Status",
                    "Requested By", "New Fridge No", "Processed By", "Processed Date"
                };

                for (int i = 0; i < headers.Length; i++)
                {
                    worksheet.Cell(5, i + 1).Value = headers[i];
                    worksheet.Cell(5, i + 1).Style.Font.Bold = true;
                    worksheet.Cell(5, i + 1).Style.Fill.BackgroundColor = XLColor.LightBlue;
                    worksheet.Cell(5, i + 1).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                }

                // Data
                int row = 6;
                foreach (var replacement in replacements)
                {
                    // Get technician names
                    var requestedBy = replacement.ApplicationUser != null ?
                        $"{replacement.ApplicationUser.FirstName} {replacement.ApplicationUser.LastName}" :
                        "N/A";

                    worksheet.Cell(row, 1).Value = $"REQ-{replacement.FridgeReplacementId:D4}";
                    worksheet.Cell(row, 2).Value = $"{replacement.Customer?.ApplicationUser?.FirstName} {replacement.Customer?.ApplicationUser?.LastName}";
                    worksheet.Cell(row, 3).Value = replacement.Customer?.CustomerNumber ?? "N/A";
                    worksheet.Cell(row, 4).Value = replacement.OldFridgeNo;
                    worksheet.Cell(row, 5).Value = replacement.ReasonForReplacement;
                    worksheet.Cell(row, 6).Value = replacement.RequestDate;
                    worksheet.Cell(row, 6).Style.NumberFormat.Format = "yyyy-mm-dd hh:mm AM/PM";
                    worksheet.Cell(row, 7).Value = replacement.ReplacementDate;
                    worksheet.Cell(row, 7).Style.NumberFormat.Format = "yyyy-mm-dd";

                    // Status with conditional formatting
                    var statusCell = worksheet.Cell(row, 8);
                    statusCell.Value = GetStatusText(replacement.ReplacementStatus);

                    // Apply color based on status
                    switch (replacement.ReplacementStatus)
                    {
                        case SD.Pending:
                            statusCell.Style.Fill.BackgroundColor = XLColor.Yellow;
                            break;
                        case SD.Approved:
                            statusCell.Style.Fill.BackgroundColor = XLColor.Green;
                            statusCell.Style.Font.FontColor = XLColor.White;
                            break;
                        case SD.Rejected:
                            statusCell.Style.Fill.BackgroundColor = XLColor.Red;
                            statusCell.Style.Font.FontColor = XLColor.White;
                            break;
                    }

                    worksheet.Cell(row, 9).Value = requestedBy;
                    worksheet.Cell(row, 10).Value = replacement.NewFridgeInStock?.FridgeNo ?? "Pending";
                    worksheet.Cell(row, 11).Value = replacement.ActionBy ?? "Pending";
                    worksheet.Cell(row, 12).Value = replacement.ActionDate?.ToString("yyyy-MM-dd HH:mm") ?? "Pending";

                    // Add borders
                    for (int col = 1; col <= headers.Length; col++)
                    {
                        worksheet.Cell(row, col).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    }
                    row++;
                }

                // Auto-fit columns
                worksheet.Columns().AdjustToContents();

                using var stream = new MemoryStream();
                workbook.SaveAs(stream);
                var content = stream.ToArray();

                return File(content,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    $"Replacement_Requests_Export_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");
            }
            catch (Exception ex)
            {
                TempData[SD.Error] = $"Error generating Excel file: {ex.Message}";
                return RedirectToAction("ManageReplacements");
            }
        }

        private IActionResult ExportToCsv(List<FridgeReplacement> replacements)
        {
            try
            {
                var csv = new StringBuilder();

                // Headers
                csv.AppendLine("Request ID,Customer Name,Customer Number,Old Fridge No,Reason for Replacement,Request Date,Replacement Date,Status,Requested By,New Fridge No,Processed By,Processed Date");

                // Data
                foreach (var replacement in replacements)
                {
                    var requestedBy = replacement.ApplicationUser != null ?
                        $"{replacement.ApplicationUser.FirstName} {replacement.ApplicationUser.LastName}" :
                        "N/A";

                    var fields = new string[]
                    {
                        $"REQ-{replacement.FridgeReplacementId:D4}",
                        EscapeCsvField($"{replacement.Customer?.ApplicationUser?.FirstName} {replacement.Customer?.ApplicationUser?.LastName}"),
                        EscapeCsvField(replacement.Customer?.CustomerNumber ?? "N/A"),
                        EscapeCsvField(replacement.OldFridgeNo),
                        EscapeCsvField(replacement.ReasonForReplacement),
                        replacement.RequestDate.ToString("yyyy-MM-dd HH:mm"),
                        replacement.ReplacementDate.ToString("yyyy-MM-dd"),
                        EscapeCsvField(GetStatusText(replacement.ReplacementStatus)),
                        EscapeCsvField(requestedBy),
                        EscapeCsvField(replacement.NewFridgeInStock?.FridgeNo ?? "Pending"),
                        EscapeCsvField(replacement.ActionBy ?? "Pending"),
                        replacement.ActionDate?.ToString("yyyy-MM-dd HH:mm") ?? "Pending"
                    };

                    csv.AppendLine(string.Join(",", fields));
                }

                var content = Encoding.UTF8.GetBytes(csv.ToString());
                return File(content,
                    "text/csv",
                    $"Replacement_Requests_Export_{DateTime.Now:yyyyMMdd_HHmmss}.csv");
            }
            catch (Exception ex)
            {
                TempData[SD.Error] = $"Error generating CSV file: {ex.Message}";
                return RedirectToAction("ManageReplacements");
            }
        }

        private IActionResult ExportToPdf(List<FridgeReplacement> replacements)
        {
            try
            {
                using var memoryStream = new MemoryStream();
                var document = new Document(PageSize.A4.Rotate(), 20, 20, 30, 30);
                var writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                // Add title
                var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.Blue);
                var title = new Paragraph("Fridge Replacement Requests - Export Report", titleFont)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 15f
                };
                document.Add(title);

                // Add export date
                var dateFont = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.Gray);
                var exportDate = new Paragraph($"Exported on: {DateTime.Now:yyyy-MM-dd HH:mm}", dateFont)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 10f
                };
                document.Add(exportDate);

                // Create table
                var table = new PdfPTable(8)
                {
                    WidthPercentage = 100,
                    SpacingBefore = 10f,
                    SpacingAfter = 10f
                };

                // Set column widths
                float[] columnWidths = { 1f, 1.5f, 1f, 1.5f, 2f, 1f, 1f, 1f };
                table.SetWidths(columnWidths);

                // Table headers
                var headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9, BaseColor.White);
                var headerBackground = new BaseColor(70, 130, 180);
                string[] headers = {
                    "Request ID", "Customer Name", "Old Fridge", "Reason",
                    "Request Date", "Status", "New Fridge", "Processed By"
                };

                foreach (var header in headers)
                {
                    var cell = new PdfPCell(new Phrase(header, headerFont))
                    {
                        BackgroundColor = headerBackground,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        Padding = 5
                    };
                    table.AddCell(cell);
                }

                // Table data
                var dataFont = FontFactory.GetFont(FontFactory.HELVETICA, 8);
                foreach (var replacement in replacements)
                {
                    table.AddCell(new PdfPCell(new Phrase($"REQ-{replacement.FridgeReplacementId:D4}", dataFont)) { Padding = 4 });
                    table.AddCell(new PdfPCell(new Phrase($"{replacement.Customer?.ApplicationUser?.FirstName} {replacement.Customer?.ApplicationUser?.LastName}", dataFont)) { Padding = 4 });
                    table.AddCell(new PdfPCell(new Phrase(replacement.OldFridgeNo, dataFont)) { Padding = 4 });
                    var reason = replacement.ReasonForReplacement?.Length > 50 ?
                        replacement.ReasonForReplacement.Substring(0, 47) + "..." :
                        replacement.ReasonForReplacement ?? "";
                    table.AddCell(new PdfPCell(new Phrase(reason, dataFont)) { Padding = 4 });
                    table.AddCell(new PdfPCell(new Phrase(replacement.RequestDate.ToString("MMM dd, yyyy"), dataFont)) { Padding = 4 });

                    // Status cell with background color
                    var statusCell = new PdfPCell(new Phrase(GetStatusText(replacement.ReplacementStatus), dataFont))
                    {
                        Padding = 4,
                        HorizontalAlignment = Element.ALIGN_CENTER
                    };

                    // Apply background color based on status
                    switch (replacement.ReplacementStatus)
                    {
                        case SD.Pending:
                            statusCell.BackgroundColor = BaseColor.Yellow;
                            break;
                        case SD.Approved:
                            statusCell.BackgroundColor = BaseColor.Green;
                            break;
                        case SD.Rejected:
                            statusCell.BackgroundColor = BaseColor.Red;
                            break;
                    }
                    table.AddCell(statusCell);

                    table.AddCell(new PdfPCell(new Phrase(replacement.NewFridgeInStock?.FridgeNo ?? "Pending", dataFont)) { Padding = 4 });
                    table.AddCell(new PdfPCell(new Phrase(replacement.ActionBy ?? "Pending", dataFont)) { Padding = 4 });
                }

                document.Add(table);
                document.Close();

                var content = memoryStream.ToArray();
                return File(content, "application/pdf", $"Replacement_Requests_Export_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");
            }
            catch (Exception ex)
            {
                TempData[SD.Error] = $"Error generating PDF file: {ex.Message}";
                return RedirectToAction("ManageReplacements");
            }
        }

        private string EscapeCsvField(string field)
        {
            if (string.IsNullOrEmpty(field))
                return "\"\"";

            if (field.Contains(",") || field.Contains("\"") || field.Contains("\n") || field.Contains("\r"))
            {
                return "\"" + field.Replace("\"", "\"\"") + "\"";
            }
            return field;
        }

        private string GetStatusText(string status)
        {
            return status switch
            {
                SD.Pending => "Pending",
                SD.Approved => "Approved",
                SD.Rejected => "Rejected",
                _ => status
            };
        }

        // ===================================================================
        // PRIVATE HELPER METHODS
        // ===================================================================
        private List<SelectListItem> GetReplacementReasons()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Text = "Fridge Beyond Repair", Value = "Fridge Beyond Repair" },
                new SelectListItem { Text = "Frequent Breakdowns", Value = "Frequent Breakdowns" },
                new SelectListItem { Text = "Old Age", Value = "Old Age" },
                new SelectListItem { Text = "Customer Request", Value = "Customer Request" },
                new SelectListItem { Text = "Other", Value = "Other" }
            };
        }

        private int GetCurrentCustomerId()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _db.tblCustomer.FirstOrDefault(c => c.ApplicationUserId == userId);
            return customer?.CustomerID ?? 0;
        }
    }
}