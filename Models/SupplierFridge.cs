namespace Project.Models
{
    public class SupplierFridge
    {
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public int FridgeId { get; set; }
        public Fridge Fridge { get; set; }

        // Optional extra fields
        public decimal? CostPrice { get; set; }
        public int? LeadTimeDays { get; set; }
    }
}
