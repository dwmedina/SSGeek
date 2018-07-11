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
        public int EarthAge { get; set; }

        public double CalculateTimeToTravel()
        {
            var distanceToPlanet = DistanceToPlanetInMiles[Planet];
            //Get planet they want to travel to
            //get distance

            //Get mode of transportation
            //calculate time based on mode of travel
            var timeToPlanet = distanceToPlanet / (TransportationRateInMPH[ModeOfTransport]);


            //return TimeToPlanet*

            return timeToPlanet;
        }

        public static Dictionary<string, long> DistanceToPlanetInMiles = new Dictionary<string, long>()
        {
            { "Mars",48678219 },
            { "Jupiter",390674710 },
            { "Saturn",792248270 },
            { "Uranus",1692662530 },
            { "Neptune",2703959960 },
            { "Mercury" ,56974146 },
            { "Venus",25724767 }
        };

        public static Dictionary<string, double> TransportationRateInMPH = new Dictionary<string, double>()
        {
            { "walking", 3 },
            { "car", 100 },
            { "bullet train",200},
            { "Boeing 747", 570 },
            { "Concorde", 1350 }
        };

        public static List<SelectListItem> planets = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Mercury" },
            new SelectListItem() { Text = "Venus" },
            new SelectListItem() { Text = "Mars" },
            new SelectListItem() { Text = "Jupiter" },
            new SelectListItem() { Text = "Saturn" },
            new SelectListItem() { Text = "Neptune" },
            new SelectListItem() { Text = "Uranus" },
        };

        public static List<SelectListItem> transportationModes = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "walking", Value="walking" },
            new SelectListItem() { Text = "car", Value = "car" },
            new SelectListItem() { Text = "bullet train", Value = "bullet train" },
            new SelectListItem() { Text = "Boeing 747", Value = "Boeing 747" },
            new SelectListItem() { Text = "Concorde", Value = "Concorde" }
        };
    }
}
