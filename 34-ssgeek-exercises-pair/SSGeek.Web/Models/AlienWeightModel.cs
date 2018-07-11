using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SSGeek.Web.Models
{
    public class AlienWeightModel
    {
        [Display(Name ="Choose a planet")]
        public string Planet { get; set; }
        [Display(Name ="Enter your Earth weight")]
        public int EarthWeight { get; set; }

        public double GetConvertedWeight()
        {
            Dictionary<string, double> conversionRates = new Dictionary<string, double>()
            {
                {"Mercury", 0.38 },
                {"Venus", 0.91 },
                {"Earth",1.0 },
                {"Mars",0.38 },
                {"Jupiter",2.34 },
                {"Saturn",1.06 },
                {"Uranus",0.92 },
                {"Neptune",1.19 }
            };

            return EarthWeight* conversionRates[Planet];

        }

        public static List<SelectListItem> planets = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Mercury" },
            new SelectListItem() { Text = "Venus" },
            new SelectListItem() { Text = "Mars" },
            new SelectListItem() { Text = "Jupiter" },
            new SelectListItem() { Text = "Saturn" },
            new SelectListItem() { Text = "Neptune" },
            new SelectListItem() { Text = "Uranus" }
        };
    }
}