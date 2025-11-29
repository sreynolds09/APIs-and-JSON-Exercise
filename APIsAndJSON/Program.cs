using System.Threading.Tasks;
using System;

namespace APIsAndJSON
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!\n");

            // Run Kanye vs Ron conversation:
            await RonVSKanyeAPI.RunConversation();

            // Weather section:
            Console.Write("\nEnter a city to check the weather: ");
            string city = Console.ReadLine();

            await OpenWeatherMapAPI.GetWeather(city);

            Console.WriteLine("\nProgram Complete.");
        }
    }
}
