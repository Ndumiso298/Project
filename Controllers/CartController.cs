using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.FridgeManagementSystem.Models;
using Project.Models.ViewModels;
using Project.Utility;
using System.Security.Claims;

namespace Project.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IEmailSender _emailSender;

        [BindProperty]
        public ShoppingCartVM ShoppingCartVM { get; set; }

        public CartController(ApplicationDbContext context, IEmailSender emailSender)
        {
            _db = context;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            // Get the customer associated with the current user
            var customer = _db.Customers
                .FirstOrDefault(c => c.UserId == userId);

            if (customer == null)
            {
                // Handle case where customer doesn't exist
                TempData["error"] = "Customer profile not found.";
                return RedirectToAction("Index", "Home");
            }

            ShoppingCartVM = new()
            {
                ShoppingCartList = _db.ShoppingCarts
                    .Where(u => u.CustomerId == customer.Id)
                    .Include(u => u.Fridge)
                    .ToList(),
                OrderHeader = new()
            };

            foreach (var cart in ShoppingCartVM.ShoppingCartList)
            {
                ShoppingCartVM.OrderHeader.OrderTotal += (cart.Price * cart.Quantity);
            }

            return View(ShoppingCartVM);
        }

        public IActionResult Summary()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            // Get the customer associated with the current user
            var customer = _db.Customers
                .FirstOrDefault(c => c.UserId == userId);

            if (customer == null)
            {
                TempData["error"] = "Customer profile not found.";
                return RedirectToAction("Index", "Home");
            }

            ShoppingCartVM = new()
            {
                ShoppingCartList = _db.ShoppingCarts
                    .Where(u => u.CustomerId == customer.Id)
                    .Include(u => u.Fridge)
                    .ToList(),
                OrderHeader = new()
            };

            // Set customer information for the order header
            ShoppingCartVM.OrderHeader.CustomerId = customer.Id;
            ShoppingCartVM.OrderHeader.RecipientFirstName = customer.UserAccount.FirstName;
            ShoppingCartVM.OrderHeader.RecipientLastName = customer.UserAccount.LastName;
            ShoppingCartVM.OrderHeader.RecipientPhone = customer.UserAccount.PhoneNumber;

            // Set default delivery address if available
            var defaultAddress = _db.Locations
                .FirstOrDefault(l => l.Id == customer.BusinessAddressId);

            if (defaultAddress != null)
            {
                ShoppingCartVM.OrderHeader.DeliveryAddressId = defaultAddress.Id;
            }

            // Set order dates
            ShoppingCartVM.OrderHeader.OrderDate = DateTime.Now;
            ShoppingCartVM.OrderHeader.PaymentDueDate = DateTime.Now.AddDays(30);
            ShoppingCartVM.OrderHeader.ShippingDate = DateTime.Now.AddDays(7);

            foreach (var cart in ShoppingCartVM.ShoppingCartList)
            {
                ShoppingCartVM.OrderHeader.OrderTotal += (cart.Price * cart.Quantity);
            }

            return View(ShoppingCartVM);
        }

        [HttpPost]
        [ActionName("Summary")]
        public IActionResult SummaryPOST()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            // Get the customer associated with the current user
            var customer = _db.Customers
                .FirstOrDefault(c => c.UserId == userId);

            if (customer == null)
            {
                TempData["error"] = "Customer profile not found.";
                return RedirectToAction("Index", "Home");
            }

            ShoppingCartVM.ShoppingCartList = _db.ShoppingCarts
                    .Where(u => u.CustomerId == customer.Id)
                    .Include(u => u.Fridge)
                .ToList();

            // Set order details
            ShoppingCartVM.OrderHeader.OrderDate = DateTime.Now;
            ShoppingCartVM.OrderHeader.CustomerId = customer.Id;
            ShoppingCartVM.OrderHeader.PaymentDueDate = DateTime.Now.AddDays(30);
            ShoppingCartVM.OrderHeader.ShippingDate = DateTime.Now.AddDays(7);

            // Calculate order total
            foreach (var cart in ShoppingCartVM.ShoppingCartList)
            {
                ShoppingCartVM.OrderHeader.OrderTotal += (cart.Price * cart.Quantity);
            }

            // Set order status based on customer type
            if (customer.BusinessType == "Shebeen" || customer.BusinessType == "Spaza Shop") // Adjust this based on your customer model
            {
                ShoppingCartVM.OrderHeader.PaymentStatus = StaticDetails.PaymentStatusPending;
                ShoppingCartVM.OrderHeader.OrderStatus = StaticDetails.StatusPending;
            }
            else
            {
                // Company customers might have delayed payment terms
                ShoppingCartVM.OrderHeader.PaymentStatus = StaticDetails.PaymentStatusDelayedPayment;
                ShoppingCartVM.OrderHeader.OrderStatus = StaticDetails.StatusApproved;
            }

            // Add order header to database
            _db.OrderHeaders.Add(ShoppingCartVM.OrderHeader);
            _db.SaveChanges();

            // Create order details and update fridge status
            foreach (var cart in ShoppingCartVM.ShoppingCartList)
            {
                OrderDetail orderDetail = new()
                {
                    FridgeId = cart.FridgeId,
                    OrderHeaderId = ShoppingCartVM.OrderHeader.Id,
                    Price = cart.Price,
                    Quantity = cart.Quantity
                };
                _db.OrderDetails.Add(orderDetail);

                // Update fridge status to allocated
                var fridge = _db.Fridges.Find(cart.FridgeId);
                if (fridge != null)
                {
                    fridge.Status = "Allocated";
                    _db.Fridges.Update(fridge);
                }
            }

            _db.SaveChanges();

            // For regular customers, handle payment processing
            if (ShoppingCartVM.OrderHeader.PaymentStatus == StaticDetails.PaymentStatusPending)
            {
                // Add payment processing logic here (Stripe, etc.)
                // For now, we'll just redirect to confirmation
                return RedirectToAction(nameof(OrderConfirmation), new { id = ShoppingCartVM.OrderHeader.Id });
            }

            return RedirectToAction(nameof(OrderConfirmation), new { id = ShoppingCartVM.OrderHeader.Id });
        }

        public IActionResult OrderConfirmation(int id)
        {
            OrderHeader orderHeader = _db.OrderHeaders
                .Include(u => u.Customer)
                .FirstOrDefault(u => u.Id == id);

            if (orderHeader == null)
            {
                TempData["error"] = "Order not found.";
                return RedirectToAction("Index", "Home");
            }

            if (orderHeader.PaymentStatus != StaticDetails.PaymentStatusDelayedPayment)
            {
                // This is an order by regular customer - handle payment confirmation if needed
                orderHeader.PaymentStatus = StaticDetails.PaymentStatusApproved;
                orderHeader.OrderStatus = StaticDetails.StatusApproved;
                orderHeader.PaymentDate = DateTime.Now;
                _db.OrderHeaders.Update(orderHeader);
                _db.SaveChanges();
            }

            // Send confirmation email
            var customerEmail = _db.ApplicationUsers
                .FirstOrDefault(u => u.Id == orderHeader.Customer.UserId)?.Email;

            if (!string.IsNullOrEmpty(customerEmail))
            {
                _emailSender.SendEmailAsync(
                    customerEmail,
                    "Fridge Allocation Confirmation",
                    $"<p>Your fridge allocation has been confirmed. Reference: {orderHeader.Id}</p>");
            }

            // Clear the cart
            List<ShoppingCart> shoppingCarts = _db.ShoppingCarts
                .Where(u => u.CustomerId == orderHeader.CustomerId)
                .ToList();

            _db.ShoppingCarts.RemoveRange(shoppingCarts);
            _db.SaveChanges();

            HttpContext.Session.Clear();

            return View(id);
        }

        public IActionResult Plus(int cartId)
        {
            var cartFromDb = _db.ShoppingCarts.Find(cartId);
            if (cartFromDb == null)
            {
                TempData["error"] = "Cart item not found.";
                return RedirectToAction(nameof(Index));
            }

            cartFromDb.Quantity += 1;
            _db.ShoppingCarts.Update(cartFromDb);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Minus(int cartId)
        {
            var cartFromDb = _db.ShoppingCarts.Find(cartId);
            if (cartFromDb == null)
            {
                TempData["error"] = "Cart item not found.";
                return RedirectToAction(nameof(Index));
            }

            if (cartFromDb.Quantity <= 1)
            {
                // Remove from cart
                _db.ShoppingCarts.Remove(cartFromDb);
            }
            else
            {
                cartFromDb.Quantity -= 1;
                _db.ShoppingCarts.Update(cartFromDb);
            }

            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int cartId)
        {
            var cartFromDb = _db.ShoppingCarts.Find(cartId);
            if (cartFromDb == null)
            {
                TempData["error"] = "Cart item not found.";
                return RedirectToAction(nameof(Index));
            }

            _db.ShoppingCarts.Remove(cartFromDb);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // Helper method to get the current customer
        private Customer GetCurrentCustomer()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            return _db.Customers
                .FirstOrDefault(c => c.UserId == userId);
        }
    }
}
