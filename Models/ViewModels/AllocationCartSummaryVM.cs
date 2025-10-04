using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class AllocationCartSummaryVM
    {
        public int ItemCount { get; set; }

        [DataType(DataType.Currency)]
        public decimal TotalMonthlyRental { get; set; }

        [DataType(DataType.Currency)]
        public decimal TotalContractValue { get; set; }

        [DataType(DataType.Currency)]
        public decimal DiscountSavings { get; set; }

        [DataType(DataType.Currency)]
        public decimal FinalAmount { get; set; }

        public int AverageRentalDuration { get; set; }
        public int TotalFridges { get; set; }
        public bool HasStockIssues { get; set; }

        // ===== REPLACEMENT-SPECIFIC =====
        public int ReplacementItemCount { get; set; }
        public bool HasReplacementItems => ReplacementItemCount > 0;

        public bool HasItems => ItemCount > 0;
        public bool IsEmpty => ItemCount == 0;

        [Display(Name = "Display Text")]
        public string DisplayText => HasItems
               ? $"{ItemCount} model(s) - {TotalFridges} fridge(s)" +
                 (HasReplacementItems ? $" ({ReplacementItemCount} replacements)" : "")
               : "Cart is empty";

        [Display(Name = "Financial Summary")]
        public string FinancialSummary => !IsEmpty
            ? $"{TotalMonthlyRental:C}/month | {TotalContractValue:C} total"
            : "No items";

        [Display(Name = "Status Color")]
        public string StatusColorClass => !IsEmpty
            ? (HasStockIssues ? "text-warning" : "text-success")
            : "text-muted";

        [Display(Name = "Status Icon")]
        public string StatusIcon => !IsEmpty
            ? (HasStockIssues ? "⚠️" : (HasReplacementItems ? "🔄" : "✅"))
            : "🛒";

        [Display(Name = "Can Checkout")]
        public bool CanCheckout => !IsEmpty && !HasStockIssues;

        // Factory method to create from cart
        public static AllocationCartSummaryVM FromCart(AllocationCartVM cart)
        {
            return new AllocationCartSummaryVM
            {
                ItemCount = cart.TotalModels,
                TotalFridges = cart.TotalFridges,
                TotalMonthlyRental = cart.TotalMonthlyRental,
                TotalContractValue = cart.TotalContractValue,
                HasStockIssues = cart.HasStockIssues,
                ReplacementItemCount = cart.Items.Count(i => i.IsReplacementUnit)
            };
        }

        // Factory method to create from items list
        public static AllocationCartSummaryVM FromItems(List<AllocationCartItemVM> items)
        {
            return new AllocationCartSummaryVM
            {
                ItemCount = items.Count,
                TotalFridges = items.Sum(i => i.Quantity),
                TotalMonthlyRental = items.Sum(i => i.MonthlyTotal),
                TotalContractValue = items.Sum(i => i.LineTotal),
                HasStockIssues = items.Any(i => !i.HasSufficientStock),
                ReplacementItemCount = items.Count(i => i.IsReplacementUnit)
            };
        }
    }
}
