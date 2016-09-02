using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebShop.Models
{
    public class Wine
    {
        [Key]
        public int WineId { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "The field {0} must be shorter than {1} characters.....")]
        [Display(Name = "Wine Name")]
        public string Name { get; set; }

        [Range(10, 200)]
        public double Price { get; set; }

        [Range(2000, 2999)]
        [Display(Name = "Year Of Bottling")]
        public int YearOfBottling { get; set; }

        [Range(8.5, 22, ErrorMessage = "The field {0} must be between {1} and {2} %.....")]
        [Display(Name = "Alcohol Percentage")]
        public double AlcoholPercentage { get; set; }

        public string ImagePath { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Wine Type")]
        public WineType WineType { get; set; }

        [Display(Name = "Winery")]
        public int WineryId { get; set; }


        //relación muchos:
        public virtual Winery Winery { get; set; }
    }

    public enum WineType
    {
        Sauvighon, Rieslinger, Syrah, Merlot, Cabernet, Other

    }
}