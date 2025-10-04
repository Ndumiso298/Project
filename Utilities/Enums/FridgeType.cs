using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum FridgeType
    {
        [Display(Name = "Upright Fridge")]
        UprightFridge,

        [Display(Name = "Chest Freezer")]
        ChestFreezer,

        [Display(Name = "Upright Freezer")]
        UprightFreezer,

        [Display(Name = "Glass Display Fridge")]
        GlassDisplayFridge,

        [Display(Name = "Beverage Cooler")]
        BeverageCooler,

        [Display(Name = "Undercounter Fridge")]
        UndercounterFridge,

        [Display(Name = "Undercounter Freezer")]
        UndercounterFreezer,

        [Display(Name = "Wine Cooler")]
        WineCooler,

        [Display(Name = "Combi Fridge-Freezer")]
        CombiFridgeFreezer,

        [Display(Name = "Ice Maker")]
        IceMaker,

        [Display(Name = "Bottle Cooler")]
        BottleCooler
    }
}
