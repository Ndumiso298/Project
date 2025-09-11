using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project.Models.ViewModel
{
    public class AllocationVM
    {


     
        public IEnumerable<Allocation> AllocationList { get; set; }
        public RequestHeader RequestHeader { get; set; }
        //[ValidateNever]
        //public IEnumerable<SelectListItem> FridgeList { get; set; }
    }
}
