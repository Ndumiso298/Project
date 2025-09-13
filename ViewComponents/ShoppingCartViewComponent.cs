using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Utility;
using System.Security.Claims;

namespace Project.ViewComponents
{
    public class ShoppingCartViewComponent : ViewComponent
    { 
        private readonly ApplicationDbContext _db;
        public ShoppingCartViewComponent(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claim != null)
            {
                if (HttpContext.Session.GetInt32(StaticDetails.SessionCart) == null)
                {
                    if (int.TryParse(claim.Value, out int customerId))
                    {
                        HttpContext.Session.SetInt32(StaticDetails.SessionCart,
                        _db.ShoppingCarts.Where(u => u.CustomerId == customerId).Count());
                    }
                }
                return View(HttpContext.Session.GetInt32(StaticDetails.SessionCart));
            }
            else
            {
                HttpContext.Session.Clear();
                return View(0);
            }
        }
    }
}
