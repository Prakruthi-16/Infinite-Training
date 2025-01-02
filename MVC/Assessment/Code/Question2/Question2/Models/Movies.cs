
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Question2.Models
{
    public class Movies
    {
        [Key]
        public int Mid { get; set; }

        public string Moviename { get; set; }

        [Display(Name = "Release Date")]
        public DateTime DateofRelease { get; set; }
    }
}
