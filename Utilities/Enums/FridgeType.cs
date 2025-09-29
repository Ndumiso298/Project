using System.ComponentModel.DataAnnotations;

namespace Project.Utilities.Enums
{
    public enum FridgeType
    {
        [Display(Name = "Single Door")]
        SingleDoor,

        [Display(Name = "Double Door")]
        DoubleDoor,

        [Display(Name = "Chest Freezer")]
        ChestFreezer,

        [Display(Name = "Upright Freezer")]
        UprightFreezer,

        [Display(Name = "Glass Door")]
        GlassDoor,

        [Display(Name = "Beverage Cooler")]
        BeverageCooler,

        [Display(Name = "Commercial Refrigerator")]
        CommercialRefrigerator,

        [Display(Name = "Walk-in Cooler")]
        WalkInCooler
    }
}
