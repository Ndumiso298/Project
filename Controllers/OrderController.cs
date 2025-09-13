using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.ViewModels;
using Project.Utility;
using System.Security.Claims;

namespace Project.Controllers
{
    [Authorize(Roles = StaticDetails.AdminRole)]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public OrderVM OrderVM { get; set; }

        public OrderController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int orderId)
        {
            OrderVM = new OrderVM()
            {
                OrderHeader = _db.OrderHeaders
                    .Include(o => o.Customer)
                    .FirstOrDefault(o => o.Id == orderId),
                OrderDetails = _db.OrderDetails
                    .Include(od => od.Fridge)
                    .Where(od => od.OrderHeaderId == orderId)
                    .ToList()
            };

            return View(OrderVM);
        }

        [HttpPost]
        [Authorize(Roles = StaticDetails.AdminRole + "," + StaticDetails.CustomerSupportRole)]
        public IActionResult UpdateOrderDetail()
        {
            var orderHeaderFromDb = _db.OrderHeaders
                .FirstOrDefault(o => o.Id == OrderVM.OrderHeader.Id);

            if (orderHeaderFromDb == null)
            {
                TempData["Error"] = "Order not found.";
                return RedirectToAction(nameof(Index));
            }

            // Update recipient information
            orderHeaderFromDb.RecipientFirstName = OrderVM.OrderHeader.RecipientFirstName;
            orderHeaderFromDb.RecipientLastName = OrderVM.OrderHeader.RecipientLastName;

            // Update shipping information
            if (!string.IsNullOrEmpty(OrderVM.OrderHeader.Carrier))
            {
                orderHeaderFromDb.Carrier = OrderVM.OrderHeader.Carrier;
            }
            if (!string.IsNullOrEmpty(OrderVM.OrderHeader.TrackingNumber))
            {
                orderHeaderFromDb.TrackingNumber = OrderVM.OrderHeader.TrackingNumber;
            }

            _db.OrderHeaders.Update(orderHeaderFromDb);
            _db.SaveChanges();

            TempData["Success"] = "Order Details Updated Successfully.";

            return RedirectToAction(nameof(Details), new { orderId = orderHeaderFromDb.Id });
        }

        [HttpPost]
        [Authorize(Roles = StaticDetails.AdminRole + "," + StaticDetails.CustomerSupportRole)]
        public IActionResult StartProcessing()
        {
            var orderHeader = _db.OrderHeaders
                .FirstOrDefault(o => o.Id == OrderVM.OrderHeader.Id);

            if (orderHeader == null)
            {
                TempData["Error"] = "Order not found.";
                return RedirectToAction(nameof(Index));
            }

            orderHeader.OrderStatus = StaticDetails.StatusInProcessing;
            _db.OrderHeaders.Update(orderHeader);
            _db.SaveChanges();

            TempData["Success"] = "Order Status Updated to Processing.";
            return RedirectToAction(nameof(Details), new { orderId = OrderVM.OrderHeader.Id });
        }

        [HttpPost]
        [Authorize(Roles = StaticDetails.AdminRole + "," + StaticDetails.CustomerSupportRole)]
        public IActionResult ShipOrder()
        {
            var orderHeader = _db.OrderHeaders
                .FirstOrDefault(o => o.Id == OrderVM.OrderHeader.Id);

            if (orderHeader == null)
            {
                TempData["Error"] = "Order not found.";
                return RedirectToAction(nameof(Index));
            }

            orderHeader.TrackingNumber = OrderVM.OrderHeader.TrackingNumber;
            orderHeader.Carrier = OrderVM.OrderHeader.Carrier;
            orderHeader.OrderStatus = StaticDetails.StatusShipped;
            orderHeader.ShippingDate = DateTime.Now;

            if (orderHeader.PaymentStatus == StaticDetails.PaymentStatusDelayedPayment)
            {
                orderHeader.PaymentDueDate = DateTime.Now.AddDays(30);
            }

            _db.OrderHeaders.Update(orderHeader);
            _db.SaveChanges();

            TempData["Success"] = "Order Shipped Successfully.";
            return RedirectToAction(nameof(Details), new { orderId = OrderVM.OrderHeader.Id });
        }

        [HttpPost]
        [Authorize(Roles = StaticDetails.AdminRole + "," + StaticDetails.CustomerSupportRole)]
        public IActionResult CancelOrder()
        {
            var orderHeader = _db.OrderHeaders
                .FirstOrDefault(o => o.Id == OrderVM.OrderHeader.Id);

            if (orderHeader == null)
            {
                TempData["Error"] = "Order not found.";
                return RedirectToAction(nameof(Index));
            }

            if (orderHeader.PaymentStatus == StaticDetails.PaymentStatusApproved)
            {
                // Refund logic would go here if using Stripe
                orderHeader.OrderStatus = StaticDetails.StatusCancelled;
                orderHeader.PaymentStatus = StaticDetails.StatusRefunded;
            }
            else
            {
                orderHeader.OrderStatus = StaticDetails.StatusCancelled;
                orderHeader.PaymentStatus = StaticDetails.StatusCancelled;
            }

            _db.OrderHeaders.Update(orderHeader);
            _db.SaveChanges();

            TempData["Success"] = "Order Cancelled Successfully.";
            return RedirectToAction(nameof(Details), new { orderId = OrderVM.OrderHeader.Id });
        }

        [ActionName("Details")]
        [HttpPost]
        public IActionResult Details_PAY_NOW()
        {
            OrderVM.OrderHeader = _db.OrderHeaders
                .Include(o => o.Customer)
                .FirstOrDefault(o => o.Id == OrderVM.OrderHeader.Id);

            OrderVM.OrderDetails = _db.OrderDetails
                .Include(od => od.Fridge)
                .Where(od => od.OrderHeaderId == OrderVM.OrderHeader.Id)
                .ToList();

            // For now, redirect to confirmation without payment processing
            return RedirectToAction("PaymentConfirmation", new { orderHeaderId = OrderVM.OrderHeader.Id });
        }

        public IActionResult PaymentConfirmation(int orderHeaderId)
        {
            var orderHeader = _db.OrderHeaders
                .FirstOrDefault(o => o.Id == orderHeaderId);

            if (orderHeader == null)
            {
                TempData["Error"] = "Order not found.";
                return RedirectToAction(nameof(Index));
            }

            if (orderHeader.PaymentStatus == StaticDetails.PaymentStatusDelayedPayment)
            {
                // This is an order with delayed payment
                orderHeader.PaymentStatus = StaticDetails.PaymentStatusApproved;
                orderHeader.PaymentDate = DateTime.Now;

                _db.OrderHeaders.Update(orderHeader);
                _db.SaveChanges();
            }

            return View(orderHeaderId);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll(string status)
        {
            IQueryable<OrderHeader> orderHeadersQuery;

            if (User.IsInRole(StaticDetails.AdminRole) || User.IsInRole(StaticDetails.CustomerSupportRole))
            {
                orderHeadersQuery = _db.OrderHeaders
                    .Include(oh => oh.Customer);
            }
            else
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

                // Get customer ID from user ID
                var customer = _db.Customers.FirstOrDefault(c => c.UserId == userId);
                if (customer == null)
                {
                    return Json(new { data = new List<OrderHeader>() });
                }

                orderHeadersQuery = _db.OrderHeaders
                    .Where(oh => oh.CustomerId == customer.Id)
                    .Include(oh => oh.Customer);
            }

            // Apply status filter if provided
            if (!string.IsNullOrEmpty(status))
            {
                switch (status.ToLower())
                {
                    case "pending":
                        orderHeadersQuery = orderHeadersQuery.Where(u => u.PaymentStatus == StaticDetails.PaymentStatusPending);
                        break;
                    case "inprocessing":
                        orderHeadersQuery = orderHeadersQuery.Where(u => u.OrderStatus == StaticDetails.StatusInProcessing);
                        break;
                    case "completed":
                        orderHeadersQuery = orderHeadersQuery.Where(u => u.OrderStatus == StaticDetails.StatusShipped);
                        break;
                    case "approved":
                        orderHeadersQuery = orderHeadersQuery.Where(u => u.OrderStatus == StaticDetails.StatusApproved);
                        break;
                }
            }

            var orderHeaders = orderHeadersQuery.ToList();
            return Json(new { data = orderHeaders });
        }
        #endregion
    }
}