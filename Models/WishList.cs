using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class WishList
    {
        public class Wishlist
        {
            [Key]
            public int WishlistId { get; set; }

            [Required]
            public string CustomerId { get; set; }

            [Required]
            public int FridgeId { get; set; }

            public DateTime AddedOn { get; set; }

            public Fridge Fridge { get; set; }
        }


    }
}
