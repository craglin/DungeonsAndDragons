using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DungeonsAndDragons
{
    public enum DiceType
    {
        none = 0,
        d2 = 2,
        d4 = 4,
        d6 = 6,
        d8 = 8,
        d10 = 10,
        d12 = 12,
        d20 = 20,
        d100 = 100
    }

    public enum CoinFlip
    {
        Heads = 1,
        Tails = 2,
    }

    public enum RollCondition
    {
        Advantage,
        Normal,
        Disadvantage
    }

    public enum AbilitySelectionStyle
    {
        ThreeD6,
        FourD6DropLowest,
    }

    public enum RollType
    {
        none,
        Ability,
        Attack,
        Coin_Flip,
        Damage,
        Initiative,
        Miscellaneous,
        Percentile,
        Restore,
        Save,
        Skill,
        Treasure,
    }
    public enum RollReport
    {
        None,
        Simple,
        Verbose
    }

    public static class DiceRoller
    {
        // Key: rollID Tuple<cupOwnerID, DateTime, RollType, DiceType, Rolls, Result
        public static Dictionary<int, Tuple<int?, DateTime, RollType, DiceType, object, List<int>>> RollHistory { get; private set; }
        public static int RollCounter { get; private set; }
        private static Random randomRoll;

        public delegate void DiceChooser(DiceCup cup);

        #region Testing
        public static bool UseTestSeed { get; set; }
        internal const int TEST_SEED = 20210317;
        #endregion

        // Reads in a string as a dice roll command in the format "1d6 × 100" (300) where 1 is the number of dice, d6 is the dice type, × 100 is the multiplier and (300) is the average expected value.
        private readonly static Regex diceShorthand = new(@"\b(\d+)(d(?:1(?:(?:0{1,2})|2{1})|20?|4|6|8))\b(?:\s*[×*]\s*(\d+))*\b(?:\s*\((\d+)\))*", RegexOptions.IgnoreCase);

        static DiceRoller()
        {
            RollHistory = new();
            ResetSeed();
            RollCounter = 0;
        }

        public static void Roll(DiceCup cup, string rollString)
        {
            TryParseRegex(cup, rollString);
            Roll(cup);
        }

        public static void Roll(object[] rollConds)
        {
            // TODO: Parse roll condtions
        }

        public static void Roll(DiceCup cup)
        {
            cup.rollID = RollCounter++;

            switch (cup.rollType)
            {
                case RollType.Attack:
                case RollType.Initiative:
                case RollType.Save:
                case RollType.Skill:
                    cup.diceType = DiceType.d20;
                    RollWithCondition(cup);
                    break;
                case RollType.Ability:
                case RollType.Damage:
                case RollType.Miscellaneous:
                case RollType.Restore:
                case RollType.Treasure:
                    RollDice(cup);
                    cup.result = cup.rolls.Sum() * cup.multiplier;
                    break;
                case RollType.Coin_Flip:
                    cup.diceType = DiceType.d2;
                    RollDice(cup);
                    CoinDecider(cup);
                    break;
                case RollType.Percentile:
                    cup.diceType = DiceType.d100;
                    RollDice(cup);
                    cup.result = cup.numDice > 1 ? cup.rolls.Average() : cup.rolls[0];
                    break;
                default:
                    break;
            }
            AddToHistory(cup);
        }

        private static void RollWithCondition(DiceCup cup)
        {
            switch (cup.rollCondition)
            {
                case RollCondition.Advantage:
                    cup.numDice = 2;
                    RollDice(cup);
                    cup.result = cup.rolls.Max();
                    break;
                case RollCondition.Normal:
                    RollDice(cup);
                    cup.result = cup.rolls[0];
                    break;
                case RollCondition.Disadvantage:
                    cup.numDice = 2;
                    RollDice(cup);
                    cup.result = cup.rolls.Min();
                    break;
                default:
                    break;
            }
        }

        private static void RollDice(DiceCup cup)
        {
            for (int i = 0; i < cup.numDice; i++)
                cup.rolls.Add(randomRoll.Next(0, (int)cup.diceType) + 1);
        }

        private static int ExpectedValue(DiceCup cup)
        {
            return (cup.rolls.Sum() / (int)cup.diceType);
        }

        private static void AddToHistory(DiceCup cup)
        {
            RollHistory[cup.rollID] = new(cup.cupOwnerID, DateTime.Now, cup.rollType, cup.diceType, cup.result, cup.rolls);
        }


        #region Parse
        private static void TryParseRegex(DiceCup cup, string rollInfo)
        {
            Match rollMatch = diceShorthand.Match(rollInfo);

            if (int.TryParse(rollMatch.Groups[1].Value, out int numDice))
                cup.numDice = numDice;
            if (TryParseDice(rollMatch.Groups[2].Value, out DiceType diceType))
                cup.diceType = diceType;

            if (int.TryParse(rollMatch.Groups[3].Value, out int multiplier))
                cup.multiplier = multiplier;
            else
                cup.multiplier = 1;
            if (int.TryParse(rollMatch.Groups[4].Value, out int expectedResult))
                cup.expectedResult = expectedResult;
            TryParseCondition(cup, rollInfo);
        }

        private static void TryParseCondition(DiceCup cup, string rollInfo)
        {
            if (Regex.IsMatch(rollInfo, @"\badvantage\b|\badv\b", RegexOptions.IgnoreCase))
                cup.rollCondition = RollCondition.Advantage;
            else if (Regex.IsMatch(rollInfo, @"(\bdisadvantage\b|\bdis\b)", RegexOptions.IgnoreCase))
                cup.rollCondition = RollCondition.Disadvantage;
            else
                cup.rollCondition = RollCondition.Normal;
        }

        private static bool TryParseDice(string diceString, out DiceType diceType)
        {
            diceType = DiceType.none;
            switch (diceString.ToLower().Trim())
            {
                case "d2":
                    diceType = DiceType.d2;
                    break;
                case "d4":
                    diceType = DiceType.d4;
                    break;
                case "d6":
                    diceType = DiceType.d6;
                    break;
                case "d8":
                    diceType = DiceType.d8;
                    break;
                case "d10":
                    diceType = DiceType.d10;
                    break;
                case "d12":
                    diceType = DiceType.d12;
                    break;
                case "d20":
                    diceType = DiceType.d20;
                    break;
                case "d100":
                    diceType = DiceType.d100;
                    break;
                default:
                    break;
            }

            if (diceType == DiceType.none)
                return false;
            return true;
        }
        #endregion

        private static void CoinDecider(DiceCup cup)
        {
            var headNumQuery =
                from result in cup.rolls
                where result == 1
                select result;

            var tailsNumQuery =
                from result in cup.rolls
                where result == 2
                select result;

            int numHeads = headNumQuery.Count();
            int numTails = tailsNumQuery.Count();

            cup.result = numHeads >= numTails ? 1 : 2;
        }

        public static void ResetSeed(bool useTestSeed = false)
        {
            randomRoll = useTestSeed ? new(TEST_SEED) : new();
        }
    }
}