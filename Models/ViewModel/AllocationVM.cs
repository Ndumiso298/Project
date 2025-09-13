using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project.Models.ViewModel
{
    public class AllocationVM
    {
        public Allocation Allocation { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> UserList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> FridgeList { get; set; }
    }
}
