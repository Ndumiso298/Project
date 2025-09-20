using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project.Models.ViewModels
{
    public class AllocationVM
    {
        public IEnumerable<FridgeAllocation> AllocationList { get; set; }
        public RequestHeader RequestHeader { get; set; }
        //[ValidateNever]
        //public IEnumerable<SelectListItem> FridgeList { get; set; }
    }
}
