using MyApp.Models;
using MyApp.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MyApp.Services
{
    internal class FilmService
    {
        private const string filmUrl = "https://swapi.co/api/films/";
        private List<string> results;
        private async Task<List<Film>> GetFilms()
        {
            WebClient proxy = new WebClient();           
            var data = await proxy.DownloadDataTaskAsync(new Uri(filmUrl));
            Stream mem = new MemoryStream(data);
            var reader = new StreamReader(mem);
            var resultString = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<FilmResult>(resultString).Results;
        }

     
        public async Task Perform(string title, string category, string propertyName)
        {
            results = new List<string>();
            var films = await GetFilms();
            var film = films.Where(f => f.Title.Equals(title, StringComparison.OrdinalIgnoreCase)).SingleOrDefault();
            var categories = (List<string>)ObjHelper.GetPropertyValue(film, category);
            if(categories != null)
            {
                foreach (var url in categories)
                {
                    await RetrieveData(url, category, propertyName);                 
                }
            }

            PrintResults();
        }

        private void PrintResults()
        {
            foreach (string result in results)
            {
                Console.WriteLine(result);
            }
            Console.WriteLine("```");
        }
        private async Task RetrieveData(string url, string category, string propertyName)
        {           
            WebClient proxy = new WebClient();
            var data = await proxy.DownloadDataTaskAsync(new Uri(url));
            Stream mem = new MemoryStream(data);
            var reader = new StreamReader(mem);
            var resultString = reader.ReadToEnd();
            object obj = null;
            switch(category)
            {
                case "characters":
                    obj = JsonConvert.DeserializeObject<Character>(resultString);
                    break;
                case "planets":
                    obj = JsonConvert.DeserializeObject<Planet>(resultString);
                    break;
                case "starships":
                    obj = JsonConvert.DeserializeObject<Starship>(resultString);
                    break;
                case "vehicles":
                    obj = JsonConvert.DeserializeObject<Vehicle>(resultString);
                    break;
                case "species":
                    obj = JsonConvert.DeserializeObject<Species>(resultString);
                    break;
                default:
                    break;
            }

            if(obj != null)
            {
                var val = ObjHelper.GetPropertyValue(obj, propertyName);
                if (val != null && !results.Contains(val.ToString()))
                {
                    results.Add(val.ToString());
                }
            }           
        }
    }
}
