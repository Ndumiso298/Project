using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project.Models.ViewModel
{
    public class AllocationVM
    {
        public IEnumerable<Allocation> AllocationList { get; set; } = new List<Allocation>();
        public RequestHeader RequestHeader { get; set; } = new RequestHeader();

        public bool AcceptTerms { get; set; }
    }

}