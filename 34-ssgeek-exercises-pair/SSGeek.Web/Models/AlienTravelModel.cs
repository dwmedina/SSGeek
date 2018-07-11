using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSGeek.Web.Models
{
    public class AlienTravelModel
    {
        public string Planet { get; set; }
        public string ModeOfTransport { get; set; }

        public double CalculateTimeToTravel()
        {
            //Get planet they want to travel to

            //Get mode of transportation

            //return DistancetoPlanet*

            return 0.0;
        }

        public static Dictionary<string, decimal> PlanetDistances = new Dictionary<string, decimal>()
        {

        };

        public static List<SelectListItem> transportationModes = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Walking", Value="walking" },
            new SelectListItem() { Text = "Car", Value = "car" },
            new SelectListItem() { Text = "Bullet Train", Value = "bullet train" },
            new SelectListItem() { Text = "Boeing 747", Value = "boeing 747" },
            new SelectListItem() { Text = "Concorde", Value = "concorde" }
        };
    }
}
