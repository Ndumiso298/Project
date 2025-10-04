using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum StockStatus
    {
        [Display(Name = "In Stock")]
        InStock,

        [Display(Name = "Low Stock")]
        LowStock,

        [Display(Name = "Out of Stock")]
        OutOfStock
    }
}
