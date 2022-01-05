using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DungeonsAndDragons
{
    public enum CoinType
    {
        None = 0,
        Copper = 2,
        Silver = 4,
        Electrum = 8,
        Gold = 16,
        Platinum = 32,
    }

    public enum TreasureTable1
    {
        Hoard,
        Individual
    }

    public static class Currency
    {
        private static readonly List<Regex> coinPatterns;
        private static readonly Regex platinumPattern;
        private static readonly Regex goldPattern;
        private static readonly Regex electrumPattern;
        private static readonly Regex silverPattern;
        private static readonly Regex copperPattern;

        public static readonly double[,] CoinConversionTable;


        static Currency()
        {
            platinumPattern = new Regex(@"(\d+)\s(platinum|pp|p)", RegexOptions.IgnoreCase);
            goldPattern = new Regex(@"(\d+)\s(gold|gp|g)", RegexOptions.IgnoreCase);
            electrumPattern = new Regex(@"(\d+)\s(electrum|ep|e)", RegexOptions.IgnoreCase);
            silverPattern = new Regex(@"(\d+)\s(silver|sp|s)", RegexOptions.IgnoreCase);
            copperPattern = new Regex(@"(\d+)\s(copper|cp|c)", RegexOptions.IgnoreCase);

            CoinConversionTable = new double[5, 5]
            {
                { 1.0,    0.1,   0.02, 0.01, 0.001 },
                { 10.0,   1.0,   0.2,  0.1,  0.01  },
                { 50.0,   5.0,   1.0,  0.5,  0.05  },
                { 100.0,  10.0,  2.0,  1.0,  0.1   },
                { 1000.0, 100.0, 20.0, 10.0, 1.0   }
            };

            coinPatterns = new List<Regex>() { platinumPattern, goldPattern, electrumPattern, silverPattern, copperPattern };
        }

        private static bool TryParseCurrency(string s, out CoinType coin)
        {
            coin = CoinType.None;

            switch (s.ToString())
            {
                case "p":
                case "pp":
                case "platinum":
                    coin = CoinType.Gold;
                    return true;
                case "g":
                case "gp":
                case "gold":
                    coin = CoinType.Gold;
                    return true;
                case "e":
                case "ep":
                case "electrum":
                    coin = CoinType.Gold;
                    return true;
                case "s":
                case "sp":
                case "silver":
                    coin = CoinType.Silver;
                    return true;
                case "c":
                case "cp":
                case "copper":
                    coin = CoinType.Copper;
                    return true;
                default:
                    break;
            }
            return false;
        }

        /// <summary>
        /// Adds coins to the character's wallet based on an input string.
        /// </summary>
        /// <param name="reward"> String representing the award from a kill or quest completion.</param>
        public static void AddCoins(string reward, Dictionary<CoinType, int> wallet)
        {
            foreach (Regex coinPattern in coinPatterns)
            {
                foreach (Match m in Regex.Matches(reward, coinPattern.ToString()))
                {
                    if (TryParseCurrency(m.Groups[2].Value, out CoinType coin))
                        if (int.TryParse(m.Groups[1].Value, out int value))
                            if (!wallet.TryAdd(coin, value))
                                wallet[coin] += value;
                }
            }
        }

        public static int CoinConverter(double value, CoinType input, CoinType output)
        {
            double[,] inputArray = new double[5, 1];
            double[,] outputArray;
            double currencyTotal = 0;

            // Define input array
            switch (input)
            {
                case CoinType.Copper:
                    inputArray = new double[5, 1] { { value }, { 0 }, { 0 }, { 0 }, { 0 } };
                    break;
                case CoinType.Silver:
                    inputArray = new double[5, 1] { { 0 }, { value }, { 0 }, { 0 }, { 0 } };
                    break;
                case CoinType.Electrum:
                    inputArray = new double[5, 1] { { 0 }, { 0 }, { value }, { 0 }, { 0 } };
                    break;
                case CoinType.Gold:
                    inputArray = new double[5, 1] { { 0 }, { 0 }, { 0 }, { value }, { 0 } };
                    break;
                case CoinType.Platinum:
                    inputArray = new double[5, 1] { { 0 }, { 0 }, { 0 }, { 0 }, { value } };
                    break;
                default:
                    break;
            }

            // Multiply conversion array by inputArray
            for (int i = 0; i < inputArray.Length; i++)
            {
                currencyTotal += inputArray[i, 1] * CoinConversionTable[i, (int)output];
            }

            // Define output array
            switch (output)
            {
                case CoinType.Copper:
                    outputArray = new double[1, 5] { { 1, 0, 0, 0, 0 } };
                    break;
                case CoinType.Silver:
                    outputArray = new double[1, 5] { { 0, 1, 0, 0, 0 } };
                    break;
                case CoinType.Electrum:
                    outputArray = new double[1, 5] { { 0, 0, 1, 0, 0 } };
                    break;
                case CoinType.Gold:
                    outputArray = new double[1, 5] { { 0, 0, 0, 1, 0 } };
                    break;
                case CoinType.Platinum:
                    outputArray = new double[1, 5] { { 0, 0, 0, 0, 1 } };
                    break;
                default:
                    break;
            }

            // Multiply input array by output array 

            return 0;
        }
    }
}
