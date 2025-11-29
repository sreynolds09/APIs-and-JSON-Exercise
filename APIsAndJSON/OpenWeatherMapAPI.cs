using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace APIsAndJSON
{
    internal class OpenWeatherMapAPI
    {
        public static async Task GetWeather(string city)
        {
            string apiKey = "aca4591335fd642010037e0a1995a1b3"; 
            string url =
                $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=imperial";

            HttpClient client = new HttpClient();

            try
            {
                var response = await client.GetStringAsync(url);
                var json = JObject.Parse(response);

                string description = json["weather"][0]["description"].ToString();
                double temp = (double)json["main"]["temp"];
                double feels = (double)json["main"]["feels_like"];
                int humidity = (int)json["main"]["humidity"];
                double wind = (double)json["wind"]["speed"];

                Console.WriteLine("\n=== Current Weather ===\n");
                Console.WriteLine($"City:        {city}");
                Console.WriteLine($"Conditions:   {description}");
                Console.WriteLine($"Temperature:  {temp} °F");
                Console.WriteLine($"Feels Like:   {feels} °F");
                Console.WriteLine($"Humidity:     {humidity}%");
                Console.WriteLine($"Wind Speed:   {wind} mph");
                Console.WriteLine("\n========================");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching weather:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
