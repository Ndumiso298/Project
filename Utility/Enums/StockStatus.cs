namespace Project.Utility.Enums
{
    using System.ComponentModel.DataAnnotations;

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
