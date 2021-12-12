namespace FetchLeagueStats
{
    public class WinRates
    {
        public double OPAll { get; set; }
        public double OPIron { get; set; }
        public double OPBronze { get; set; }
        public double OPSilver { get; set; }
        public double OPGold { get; set; }
        public double OPPlatinum { get; set; }
        public double OPDiamond { get; set; }
        public double OPMaster { get; set; }
        public double OPGrandMaster { get; set; }
        public double OPChallenger { get; set; }

        public double LOGAllTotal { get; set; }
        public double LOGIronTotal { get; set; }
        public double LOGBronzeTotal { get; set; }
        public double LOGSilverTotal { get; set; }
        public double LOGGoldTotal { get; set; }
        public double LOGPlatinumTotal { get; set; }
        public double LOGDiamondTotal { get; set; }
        public double LOGMasterTotal { get; set; }
        public double LOGGrandMasterTotal { get; set; }
        public double LOGChallengerTotal { get; set; }

        public double LOGAll50 { get; set; }
        public double LOGIron50 { get; set; }
        public double LOGBronze50 { get; set; }
        public double LOGSilver50 { get; set; }
        public double LOGGold50 { get; set; }
        public double LOGPlatinum50 { get; set; }
        public double LOGDiamond50 { get; set; }
        public double LOGMaster50 { get; set; }
        public double LOGGrandMaster50 { get; set; }
        public double LOGChallenger50 { get; set; }

        public double GetWinRate(Elo elo, Site site)
        {
            switch (site)
            {
                case Site.OP:
                    switch (elo)
                    {
                        case Elo.All:
                            return OPAll;
                        case Elo.Iron:
                            return OPIron;
                        case Elo.Bronze:
                            return OPBronze;
                        case Elo.Silver:
                            return OPSilver;
                        case Elo.Gold:
                            return OPGold;
                        case Elo.Platinum:
                            return OPPlatinum;
                        case Elo.Diamond:
                            return OPDiamond;
                        case Elo.Master:
                            return OPMaster;
                        case Elo.GrandMaster:
                            return OPGrandMaster;
                        case Elo.Challenger:
                            return OPChallenger;
                    }
                    break;
                case Site.LOG:
                    switch (elo)
                    {
                        case Elo.All:
                            return LOGAllTotal;
                        case Elo.Iron:
                            return LOGIronTotal;
                        case Elo.Bronze:
                            return LOGBronzeTotal;
                        case Elo.Silver:
                            return LOGSilverTotal;
                        case Elo.Gold:
                            return LOGGoldTotal;
                        case Elo.Platinum:
                            return LOGPlatinumTotal;
                        case Elo.Diamond:
                            return LOGDiamondTotal;
                        case Elo.Master:
                            return LOGMasterTotal;
                        case Elo.GrandMaster:
                            return LOGGrandMasterTotal;
                        case Elo.Challenger:
                            return LOGChallengerTotal;
                    }
                    break;
                case Site.Log50:
                    switch (elo)
                    {
                        case Elo.All:
                            return LOGAll50;
                        case Elo.Iron:
                            return LOGIron50;
                        case Elo.Bronze:
                            return LOGBronze50;
                        case Elo.Silver:
                            return LOGSilver50;
                        case Elo.Gold:
                            return LOGGold50;
                        case Elo.Platinum:
                            return LOGPlatinum50;
                        case Elo.Diamond:
                            return LOGDiamond50;
                        case Elo.Master:
                            return LOGMaster50;
                        case Elo.GrandMaster:
                            return LOGGrandMaster50;
                        case Elo.Challenger:
                            return LOGChallenger50;
                    }
                    break;
            }

            return -1;
        }
        public void SetWinRate(double value, Elo elo, Site site)
        {
            switch (site)
            {
                case Site.OP:
                    switch (elo)
                    {
                        case Elo.All:
                            OPAll = value;
                            break;
                        case Elo.Iron:
                            OPIron = value;
                            break;
                        case Elo.Bronze:
                            OPBronze = value;
                            break;
                        case Elo.Silver:
                            OPSilver = value;
                            break;
                        case Elo.Gold:
                            OPGold = value;
                            break;
                        case Elo.Platinum:
                            OPPlatinum = value;
                            break;
                        case Elo.Diamond:
                            OPDiamond = value;
                            break;
                        case Elo.Master:
                            OPMaster = value;
                            break;
                        case Elo.GrandMaster:
                            OPGrandMaster = value;
                            break;
                        case Elo.Challenger:
                            OPChallenger = value;
                            break;
                    }
                    break;
                case Site.LOG:
                    switch (elo)
                    {
                        case Elo.All:
                            LOGAllTotal = value;
                            break;
                        case Elo.Iron:
                            LOGIronTotal = value;
                            break;
                        case Elo.Bronze:
                            LOGBronzeTotal = value;
                            break;
                        case Elo.Silver:
                            LOGSilverTotal = value;
                            break;
                        case Elo.Gold:
                            LOGGoldTotal = value;
                            break;
                        case Elo.Platinum:
                            LOGPlatinumTotal = value;
                            break;
                        case Elo.Diamond:
                            LOGDiamondTotal = value;
                            break;
                        case Elo.Master:
                            LOGMasterTotal = value;
                            break;
                        case Elo.GrandMaster:
                            LOGGrandMasterTotal = value;
                            break;
                        case Elo.Challenger:
                            LOGChallengerTotal = value;
                            break;
                    }
                    break;
                case Site.Log50:
                    switch (elo)
                    {
                        case Elo.All:
                            LOGAll50 = value;
                            break;
                        case Elo.Iron:
                            LOGIron50 = value;
                            break;
                        case Elo.Bronze:
                            LOGBronze50 = value;
                            break;
                        case Elo.Silver:
                            LOGSilver50 = value;
                            break;
                        case Elo.Gold:
                            LOGGold50 = value;
                            break;
                        case Elo.Platinum:
                            LOGPlatinum50 = value;
                            break;
                        case Elo.Diamond:
                            LOGDiamond50 = value;
                            break;
                        case Elo.Master:
                            LOGMaster50 = value;
                            break;
                        case Elo.GrandMaster:
                            LOGGrandMaster50 = value;
                            break;
                        case Elo.Challenger:
                            LOGChallenger50 = value;
                            break;
                    }
                    break;
            }
        }
    }
}
