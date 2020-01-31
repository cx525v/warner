using System.Collections.Generic;

namespace MyApp.Models
{
    public class Film
    {
        public string Title { get; set; }
        public string Episode_Id { get; set; }

        public List<string> Characters { get; set; }

        public List<string> Planets { get; set; }

        public List<string> Starships { get; set; }

        public List<string> Vehicles { get; set; }

        public List<string> Species { get; set; }

    }


}
