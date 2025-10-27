using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModel
{
    public class ManagerUserRoleVM
    {
      
            public string UserId { get; set; }
            public string Email { get; set; }
            public List<SelectListItem> RoleList { get; set; }
        
    }
}
