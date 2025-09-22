using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project.Models.ViewModels
{
    public class RoleManagementVM
    {
            public ApplicationUser ApplicationUser { get; set; }
            public IEnumerable<SelectListItem> RoleList { get; set; }
            public IEnumerable<SelectListItem> EmployeeList { get; set; }
            public IEnumerable<SelectListItem> CustomerList { get; set; }
    }
}
