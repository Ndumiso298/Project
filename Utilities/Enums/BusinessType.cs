using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum BusinessType
    {
        [Display(Name = "Spaza Shop")]
        SpazaShop,

        [Display(Name = "Shebeen")]
        Shebeen,

        [Display(Name = "Supermarket")]
        Supermarket,

        [Display(Name = "Convenience Store")]
        ConvenienceStore,

        [Display(Name = "Restaurant")]
        Restaurant,

        [Display(Name = "Bar")]
        Bar,

        [Display(Name = "Hotel")]
        Hotel,

        [Display(Name = "Liquor Store")]
        LiquorStore,

        [Display(Name = "Other")]
        Other
    }
}
