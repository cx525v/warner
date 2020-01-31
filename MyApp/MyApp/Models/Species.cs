using System.Collections.Generic;

namespace MyApp.Models
{
    public class Species: Category
    {
        public string Classification { get; set; }
        public string Designation { get; set; }
        public string Average_height { get; set; }
        public string Skin_color { get; set; }
        public string Hair_colors { get; set; }
        public string Eye_color { get; set; }
        public string Average_lifespan { get; set; }
        public string Homeworld { get; set; }
        public string Language { get; set; }
        public List<string> People { get; set; }

    }
}
