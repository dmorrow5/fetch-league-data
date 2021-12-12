using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchLeagueStats
{
    public static class Extensions
    {
        public static string EnumToString(this Elo enumValue)
        {
            switch (enumValue)
            {
                case Elo.Iron:
                    return "iron";
                case Elo.Bronze:
                    return "bronze";
                case Elo.Silver:
                    return "silver";
                case Elo.Gold:
                    return "gold";
                case Elo.Platinum:
                    return "platinum";
                case Elo.Diamond:
                    return "diamond";
                case Elo.Master:
                    return "master";
            }

            return "";
        }

        public static string EnumToString(this Region enumValue)
        {
            switch (enumValue)
            {
                case Region.EUNE:
                    return "eune";
                case Region.EUW:
                    return "euw";
                case Region.JP:
                    return "jp";
                case Region.NA:
                    return "na";
                case Region.LAN:
                    return "lan";
                case Region.RU:
                    return "ru";
                case Region.TR:
                    return "tr";
                case Region.OCE:
                    return "oce";
                case Region.LAS:
                    return "las";
                case Region.KR:
                    return "kr";
                case Region.BR:
                    return "br";
            }

            return "";
        }

        public static string EnumToString(this PlayMode enumValue)
        {
            switch (enumValue)
            {
                case PlayMode.Ranked:
                    return "sr-ranked";
                case PlayMode.ARAM:
                    return "aram";
                case PlayMode.UltimateSpellbook:
                    return "ultimate-spellbook";
            }

            return "";
        }
    }
}
