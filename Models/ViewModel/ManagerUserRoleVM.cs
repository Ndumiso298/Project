using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project.Models.ViewModel
{
    public class ManagerUserRoleVM
    {
      
            public string UserId { get; set; }
            public string Email { get; set; }
            public List<SelectListItem> RoleList { get; set; }
        
    }
}
