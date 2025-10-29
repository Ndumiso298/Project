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
        public string OldFridgeModel { get; set; }

        public int FridgeReplacementId { get; set; }
   
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        
        public DateTime RequestDate { get; set; }
        public string ReplacementStatus { get; set; }
        public string NewFridgeNo { get; set; }
        public string NewFridgeModel { get; set; }
       public DateTime VisitDate { get; set; }
       public string TechnicianNotes { get; set; }
        
    }
}