
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Net.Http;

namespace KanyeREST
{
    public class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            for (int i = 0; i < 5; i++)
            {
                string kanyeResponse = client.GetStringAsync("https://api.kanye.rest").Result;
                string ronResponse = client.GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes").Result;
                string kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
                string ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
                Console.WriteLine($"Kanye West - {kanyeQuote}");
                Console.WriteLine($"Ron Swanson - {ronQuote}");
            }
        }
    }
}
