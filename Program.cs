using System;
using System.Collections;
using System.Text;
using System.Threading;
using Newtonsoft.Json;

namespace Countries_List
{
    class Program
    {
        static void Main(string[] args)
        {
            // WELCOME TO MY NEW PROGRAM
            Console.WriteLine("Welcome to my Country Database APP.\n");
            while (true) {
            Console.Write("Enter Country's Name: ");
            string name = Console.ReadLine();
            if (name == "") {
                Console.WriteLine("\nInput a Valid String.\n");
                continue;
            }
            Console.WriteLine("\nSearching..\n");
            Thread.Sleep(1000);
            JsonReader content = new JsonReader("countries.json", name.ToLower());
            }
        }
    }

    class JsonReader 
    {
        public JsonReader(string file, string name)
        {
            string raw = System.IO.File.ReadAllText(file);
            dynamic data = JsonConvert.DeserializeObject(raw);
            for(int i = 0; i < data["countries"]["country"].Count; i++) 
            {
                if (data["countries"]["country"][i]["countryName"].ToString().ToLower() == name) 
                {
                    country info = new country(data["countries"]["country"][i]);
                    Console.WriteLine("Name: " + info.name);
                    Console.WriteLine("Code: " + info.code);
                    Console.WriteLine("Population: " + info.population);
                    Console.WriteLine("Currency: " + info.currency);
                    Console.WriteLine("Capital: " + info.capital);
                    Console.WriteLine("It is from: " + info.continent);
                    Console.WriteLine("");
                    break;
                }
                else if(i == data["countries"]["country"].Count - 1) {
                    Console.WriteLine("Country not found.");
                }
            }
        }
    }
}
    class country 
    {
        public string code;
        public string name;
        public string currency;
        public int population;
        public string capital;
        public string continent;
        public country(dynamic country)
        {
            code = country["countryCode"];
            name = country["countryName"];
            currency = country["currencyCode"];
            population = Convert.ToInt32(country["population"]);
            capital = country["capital"];
            continent = country["continentName"];
        }
    }