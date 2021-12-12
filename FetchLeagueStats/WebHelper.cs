using HtmlAgilityPack;
using RestSharp;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchLeagueStats
{
    public class WebHelper
    {
        public static Region _region = Region.NA;
        public static Elo _elo = Elo.Platinum;
        public static PlayMode _playMode = PlayMode.Ranked;

        public static async Task FetchChampData()
        {
            string url = "";

            for (int i = 1; i < 8; i++)
            {
                _elo = (Elo)i;
                url = BuildUrl();
                await StartCrawlerAsync(url);
            }
        }

        public static async Task StartCrawlerAsync(string url)
        {
            Console.WriteLine($"Fetching data for {_elo.EnumToString()}");

            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Cookie", "lolg_euconsent=nitro");
            IRestResponse response = await client.ExecuteAsync(request);

            var html = response.Content;

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            var rows = htmlDocument.DocumentNode
                .SelectNodes("//table//tr")
                .Select(x => new
                {
                    Cells = x.ChildNodes.Where(c => c.NodeType == HtmlNodeType.Element)
                })
                .ToList();

            rows.ForEach(row =>
            {
                var columns = row.Cells.ToArray();

                var champNameNode = columns[1].Descendants().FirstOrDefault(x => x.HasClass("name"));
                if (champNameNode == null) return;

                var champName = champNameNode.InnerText.Trim();
                if (!Program.IncludedChamps.Contains(champName)) return;

                var winRateNode = columns[2];
                var winRateNode50 = winRateNode.Descendants().FirstOrDefault(x => x.Line == (champNameNode.Line + 7));
                var winRateNode50Value = double.Parse(winRateNode50.NextSibling.GetAttributeValue("data-value", ""));

                var winRateNodes = columns[3];
                var winRateNodeTotal = winRateNodes.Descendants().FirstOrDefault(x => x.Line == (winRateNode50.Line + 3));
                var winRateNodeTotalValue = double.Parse(winRateNodeTotal.NextSibling.GetAttributeValue("data-value", ""));

                var champ = Program.Champions.FirstOrDefault(o => o.Name == champName);
                if (champ == null)
                {
                    champ = new Champion(champName);
                    Program.Champions.Add(champ);
                }

                champ.WinRates.SetWinRate(winRateNode50Value, _elo, Site.Log50);
                champ.WinRates.SetWinRate(winRateNodeTotalValue, _elo, Site.LOG);
            });

            Console.WriteLine($"Fetching data for {_elo.EnumToString()} complete!");
            return;
        }

        private static string BuildUrl()
        {
            var url = new StringBuilder(Program.Webpage);
            
            if (_region != Region.All)
            {
                url.Append("/");
                url.Append(_region.EnumToString());
            }

            if (_elo != Elo.All && _elo != Elo.Platinum)
            {
                url.Append("/");
                url.Append(_elo.EnumToString());
            }

            if (_playMode != PlayMode.NormalAndRanked)
            {
                url.Append("/");
                url.Append(_playMode.EnumToString());
            }

            return url.ToString();
        }
    }
}
