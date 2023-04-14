// Just a program

//internal class program
//{
//    private static void main(string[] args)
//    {
//        console.writeline("hello, world!");

//        int number2 = 1994;
//        var number = 1993;
//        console.writeline(number2);
//    }
//}

// Iterator 1

//internal class program
//{
//    private static void main(string[] args)
//    {
//        for (int i = 1; i <= 10; i++)
//        {
//            console.writeline("this is iteration number: {0}", i);
//            //console.writeline("this is iteration number: " + i);
//        }
//    }
//}

// Iterator 2

//using System.Linq;

//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        string[] cars = { "Volvo", "BMW", "Audi", "Ford", "Mazda" };

//        //foreach (var car in cars)
//        //{
//        //    Console.WriteLine(car.ToLower());
//        //}

//        foreach (string car in cars)
//        {
//            Console.WriteLine(car.ToLower());
//        }
//    }
//}




//Web scraper

using HtmlAgilityPack;
using System;
using System.Net.Http;

namespace WebScraper
{

    class Program
    {

        static void Main(string[] args)
        {
            // Send get request to weather.com
            String url = "https://weather.com/en-TZ/weather/today/l/e3098160bc6bf690b70244caadff6145e27802d46872aab77148bb873c0cb43b";
            var httpClient = new HttpClient();
            var html = httpClient.GetStringAsync(url).Result;
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            // Get the Date & time
            DateTime now = DateTime.Now;
            

            // Get the location
            var locationElement = htmlDocument.DocumentNode.SelectSingleNode("//h1[@class='CurrentConditions--location--1YWj_']");
            var location = locationElement.InnerText.Trim();

            //Console.WriteLine("Location: {0}", location);
            Console.WriteLine("Weather status report for {0} as of {1}", location, now);

            // Get the temperature
            var temperatureElement = htmlDocument.DocumentNode.SelectSingleNode("//span[@class='CurrentConditions--tempValue--MHmYY']");
            var temperature = temperatureElement.InnerText.Trim();

            Console.WriteLine("Temperature: {0}C", temperature);

            // Get the conditions
            var conditionElement = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='CurrentConditions--phraseValue--mZC_p']");
            var condition = conditionElement.InnerText.Trim();

            Console.WriteLine("Conditions: {0}", condition);
            
        }
    }
}

