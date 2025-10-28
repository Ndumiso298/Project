namespace Project.Models.ViewModel
{
    public class FridgeReplacementViewModel
    {
        public int VisitId { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string OldFridgeNo { get; set; }
        public string FridgeModel { get; set; }
        public string ReasonForReplacement { get; set; }
        public string AdditionalNotes { get; set; }
        public DateTime ReplacementDate { get; set; } = DateTime.Now;
    }
}