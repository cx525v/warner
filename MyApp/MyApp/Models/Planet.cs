using System.Collections.Generic;

namespace MyApp.Models
{
    public class Planet: Category
    {
        public string Rotation_period { get; set; }
        public string Orbital_period { get; set; }
        public string Diameter { get; set; }
        public string Climate { get; set; }
        public string Gravity { get; set; }
        public string Terrain { get; set; }
        public string Surface_water { get; set; }
        public string Population { get; set; }
        public List<string> Residents { get; set; }
       
    }
}
