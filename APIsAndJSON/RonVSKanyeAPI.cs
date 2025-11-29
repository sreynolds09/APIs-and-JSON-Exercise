using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace APIsAndJSON
{
    internal class RonVSKanyeAPI
    {
        public static async Task RunConversation()
        {
            HttpClient client = new HttpClient();

            Console.WriteLine("\n=== Kanye West vs Ron Swanson Conversation ===\n");

            for (int i = 0; i < 5; i++)
            {
                // Kanye
                var kanyeResponse = await client.GetStringAsync("https://api.kanye.rest");
                var kanyeQuote = JObject.Parse(kanyeResponse)["quote"].ToString();

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Kanye: \"{kanyeQuote}\"");
                Console.ResetColor();

                // Ron Swanson
                var ronResponse = await client.GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes");

                var ronQuote = JArray.Parse(ronResponse)
                                     .ToString()
                                     .Replace("[", "")
                                     .Replace("]", "")
                                     .Replace("\"", "")
                                     .Trim();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Ron Swanson: \"{ronQuote}\"");
                Console.ResetColor();

                Console.WriteLine();
            }
        }
    }
}

