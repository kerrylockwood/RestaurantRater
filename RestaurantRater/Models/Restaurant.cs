using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantRater.Models
{
    public class Restaurant
    {
        [Key]  // requires System.ComponentModel.DataAnnotations;
        public int Id { get; set; }

        [Required]
        public string Style { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0d, 5d)]
        public double Rating { get; set; }

        [Required]
        [Range(1, 5, "Dollar Sign must be between 1 and 5")]
        public int DollarSigns { get; set; }
    }
}