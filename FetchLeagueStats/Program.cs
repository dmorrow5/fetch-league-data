using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace FetchLeagueStats
{
    public class Program
    {
        public static string Webpage { get; set; } = "";
        public static string SaveDirectory { get; set; } = "";

        public static Elo StartElo { get; set; } = Elo.All;
        public static Elo StopElo { get; set; } = Elo.All;

        static HttpClient client = new HttpClient();
        public static List<Champion> Champions { get; set; } = new List<Champion>();
        public static List<string> IncludedChamps { get; set; } = new List<string>();

        public static void Main(string[] args)
        {
            try
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .AddJsonFile("Configs/characters.json", optional: true)
                    .AddJsonFile("Configs/elos.json", optional: true)
                    .AddJsonFile("Configs/appsettings.json", optional: true)
                    .Build();

                Webpage = configuration["baseUrl"];
                SaveDirectory = configuration["saveDirectory"];
                IncludedChamps = configuration.GetSection("includeChamps").Get<List<string>>();

                Console.WriteLine("Starting to fetch data...");
                WebHelper.FetchChampData().Wait();

                var startElo = configuration["startElo"];
                StartElo = (Elo)Enum.Parse(typeof(Elo), startElo);

                var stopElo = configuration["stopElo"];
                StopElo = (Elo)Enum.Parse(typeof(Elo), stopElo);

                Console.WriteLine("Finished fetching data. Beginning Excel export...");
                StatsToExcel.Export();

                Console.WriteLine("Export Complete.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            
            Console.Write("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
