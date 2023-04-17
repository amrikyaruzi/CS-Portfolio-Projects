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


namespace WebScrapers
{

    class Program
    {

        static void Main(string[] args)
        {
            // Send get request to weather.com
            string url = "https://weather.com/en-TZ/weather/today/l/b7d1e1023d5e6e48ed2c66899d60072bde6b0ae320e209995c6c58324047d66c1dfe89ff36c55f147bc93bd74b9c90fc";
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

