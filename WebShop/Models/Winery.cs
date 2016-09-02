using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebShop.Models
{
    public class Winery
    {
      [Key]
        public int WineryId { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The field {0} must be shorter than {1} characters.....")]
        public string Name { get; set; }


        public Country Country { get; set; }

        //relacion uno
        public virtual ICollection<Wine> Wines { get; set; }


    }

    public enum Country
    {
        France, Germany, Italy, Poland, India, UK, Netherlands, Spain, Other
    }
}