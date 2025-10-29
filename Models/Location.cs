//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace Project.Models
//{
    
//        public class Province
//        {
        
//            [Key]
//            public int ProvinceId { get; set; }

//            [Required]
//            [StringLength(100)]
//            [Display(Name = "Province Name")]
//            public string ProvinceName { get; set; }

//            [StringLength(10)]
//            [Display(Name = "Province Code")]
//            public string ProvinceCode { get; set; }

//            // Navigation properties
//            public virtual ICollection<City> Cities { get; set; } = new List<City>();

//            [NotMapped]
//            public string DisplayName => $"{ProvinceName} ({ProvinceCode})";
//        }
    

//        public class City
//    {
//        [Key]
//        public int CityId { get; set; }

//        [Required]
//        [StringLength(100)]
//        [Display(Name = "City Name")]
//        public string CityName { get; set; }

//        [Required]
//        [Display(Name = "Province")]
//        public int ProvinceId { get; set; }

//        // Navigation properties
//        public virtual Province Province { get; set; }
//        public virtual ICollection<Suburb> Suburbs { get; set; } = new List<Suburb>();

//        [NotMapped]
//        public string DisplayName => $"{CityName}, {Province?.ProvinceCode}";
//    }

//        public class Suburb
//        {
//        [Key]
//        public int SuburbId { get; set; }

//        [Required]
//        [StringLength(100)]
//        [Display(Name = "Suburb Name")]
//        public string SuburbName { get; set; }

//        [Required]
//        [Display(Name = "City")]
//        public int CityId { get; set; }

//        [StringLength(10)]
//        [Display(Name = "Postal Code")]
//        public string PostalCode { get; set; }

//        // Navigation properties
//        public virtual City City { get; set; }

//        [NotMapped]
//        public string DisplayName => $"{SuburbName} ({PostalCode})";
//    }



//}
