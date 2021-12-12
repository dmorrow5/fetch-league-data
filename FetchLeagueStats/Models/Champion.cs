namespace FetchLeagueStats
{
    public class Champion
    {
        public Champion(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public WinRates WinRates { get; set; } = new WinRates();
    }
}
