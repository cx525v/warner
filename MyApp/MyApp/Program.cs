using MyApp.Services;
using System.Threading.Tasks;

namespace MyApp
{
    class Program
    {
       static void Main(string[] args)
        {
            if (args != null && args.Length == 3)
            {
                string title = args[0];
                string catrgoty = args[1];
                string propertyName = args[2];
                FilmService fsrv = new FilmService();
                var task = Task.Run(async () => await fsrv.Perform(title, catrgoty, propertyName));
                task.Wait();
            }
            else
            {
                System.Console.WriteLine("Invalid arguments");
            }
        }
    }
}
