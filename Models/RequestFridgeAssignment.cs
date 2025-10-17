//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

//namespace Project.Models
//{
//    public class RequestFridgeAssignment
//    {
//        [Key]
//        public int RequestFridgeAssignmentId { get; set; }

//        [Required]
//        public int RequestDetailId { get; set; }
//        [ForeignKey("RequestDetailId")]
//        [ValidateNever]
//        public RequestDetails RequestDetail { get; set; }

//        [Required]
//        public int FridgeInStockId { get; set; }
//        [ForeignKey("FridgeInStockId")]
//        [ValidateNever]
//        public FridgeInStock FridgeInStock { get; set; }

//        [Required]
//        public int EmployeeID { get; set; }
//        [ForeignKey("EmployeeID")]
//        [ValidateNever]
//        public Employee Employee { get; set; }

//        [Required]
//        public DateTime AssignedDate { get; set; }

//       // public string? Notes { get; set; } 
//    }
//}