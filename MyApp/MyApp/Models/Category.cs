using System.Collections.Generic;

namespace MyApp.Models
{
    public abstract class Category
    {
        public string Name { get; set; }       
        public List<string> Films { get; set; }
        public string Created { get; set; }
        public string Edited { get; set; }
        public string Url { get; set; }

    }

}
