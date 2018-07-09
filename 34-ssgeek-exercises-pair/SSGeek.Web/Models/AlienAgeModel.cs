using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSGeek.Web.Models
{
    public class AlienAgeModel
    {
        [Display(Name = "Choose a planet")]
        public string Planet { get; set; }
        [Display(Name = "Enter your Age")]
        public int EarthAge { get; set; }

        public double GetConvertedAge ()
        {
            Dictionary<string, double> ageConversionRates = new Dictionary<string, double>()
            {
                {"Mercury",4.15 },
                {"Venus",1.62 },
                {"Earth",1.00 },
                {"Mars",.53 },
                {"Jupiter",.084 },
                {"Saturn",.033 },
                {"Uranus",.011 },
                {"Neptune",.006 },
                {"Pluto",.004 }

            };

            return EarthAge * ageConversionRates[Planet];

        }

        public static List<SelectListItem> planets = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Mercury" },
            new SelectListItem() { Text = "Venus" },
            new SelectListItem() { Text = "Mars" },
            new SelectListItem() { Text = "Jupiter" },
            new SelectListItem() { Text = "Saturn" },
            new SelectListItem() { Text = "Neptune" },
            new SelectListItem() { Text = "Uranus" },
            new SelectListItem() {Text= "Pluto"}
        };
    }

}

