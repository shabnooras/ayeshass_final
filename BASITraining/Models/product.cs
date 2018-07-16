using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BASITraining.Models
{
    public class product
    {
        [ScaffoldColumn(false)]
        public int ProductID { get; set; }

        [Required, StringLength(50), Display(Name = "Name")]
        public string ProductName { get; set; }

        [Required, StringLength(50), Display(Name = "Duration")]
        public string Duration { get; set; }

        public string ImagePath { get; set; }

        [Display(Name = "Price")]
        public double? UnitPrice { get; set; }

        public int? CategoryID { get; set; }

        public virtual category Category { get; set; }

    }
}