using Project.Models;

public class ReplacementRequest
{
    public int ReplacementRequestId { get; set; }
    public int FaultReportId { get; set; }
    public int CustomerId { get; set; }
    public DateTime RequestDate { get; set; }
    public string Status { get; set; } // Pending, Approved, Declined
    public string Reason { get; set; }
    public int FridgeInStockId { get; set; }

    // Navigation properties
    public FaultReport FaultReport { get; set; }
    public Customer Customer { get; set; }
    public FridgeInStock FridgeInStock { get; set; }
}