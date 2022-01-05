using System;
using System.Collections.Generic;

namespace DungeonsAndDragons
{
    public class DungeonDelver
    {
        public delegate void MenuOption();
        private static Random rng = new Random();
        private static DiceCup cup0 = new DiceCup();
        private static DiceCup cup1 = new DiceCup(1);
        private static DiceCup cup2 = new DiceCup(2);
        private static DiceCup cup3 = new DiceCup(3);

        public static void Main(string[] args)
        {
            MainMenu(SelectRandomCup());
            Console.ReadLine();
        }

        private static DiceCup SelectRandomCup()
        {
            int choice = rng.Next(4);
            switch (choice)
            {
                case 0:
                    return cup0;
                case 1:
                    return cup1;
                case 2:
                    return cup2;
                case 3:
                default:
                    return cup3;
            }
        }

        private static void GenerateRandomHistory(int historySize)
        {
            for (int i = 0; i < historySize; i++)
                RandomRoll();
        }

        private static void RandomRoll()
        {
            var rollTypes = Enum.GetValues(typeof(RollType));
            var dice = Enum.GetValues(typeof(DiceType));
            int numRolls = rng.Next(1, 11);

            DiceCup rngCup = SelectRandomCup();
            DiceType rngDice = (DiceType)dice.GetValue(rng.Next(1, dice.Length));
            RollType rngRoll = (RollType)rollTypes.GetValue(rng.Next(1, rollTypes.Length));

            string rngString = $"{rng.Next(0, numRolls) + 1}{rngDice}";

            switch (rngRoll)
            {
                case RollType.none:
                    break;
                case RollType.Ability:
                    //rngCup.RollAbility();
                    break;
                case RollType.Attack:
                    rngCup.RollAttack();
                    break;
                case RollType.Coin_Flip:
                    rngCup.FlipCoin(numRolls);
                    break;
                case RollType.Damage:
                    rngCup.RollDamage(rngDice, numRolls);
                    break;
                case RollType.Initiative:
                    rngCup.RollInitiative();
                    break;
                case RollType.Miscellaneous:
                    rngCup.Roll(rngString);
                    break;
                case RollType.Percentile:
                    rngCup.RollPercentile(numRolls);
                    break;
                case RollType.Restore:
                    rngCup.RollRestore(rngDice, numRolls);
                    break;
                case RollType.Save:
                    rngCup.RollSave();
                    break;
                case RollType.Skill:
                    //rngCup.RollSkill();
                    break;
                case RollType.Treasure:
                    rngCup.RollTreasure(rngDice, numRolls);
                    break;
                default:
                    break;
            }
        }

        private static void MainMenu(DiceCup cup)
        {
            // TODO: Check for critical hits, build delegate for crit damage calculation method, bring delegates into cup object
            ConsoleKey keyPress;
            do
            {
                Console.Write(
                         "Please select the application of choice:\r\n" +
                         "1. Roll to hit\r\n" +
                         "2. Roll Damage\r\n" +
                         "3. View Roll History \r\n" +
                         "Select a number or press Q or ESC to quit.\r\n"
                         );
                keyPress = Console.ReadKey(true).Key;
                switch (keyPress)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        RollToHit(cup);
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        RollDamage(cup);
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        GetHistory();
                        break;
                    case ConsoleKey.Q:
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
            while (true);
        }

        private static void RollToHit(DiceCup cup)
        {
            ConsoleKey keyPress;

            Console.Clear();
            Console.Write(
                "Select roll conditions: \r\n" +
                "1. Roll to hit\r\n" +
                "2. Roll with advantage\r\n" +
                "3. Roll with disadvantage\r\n" +
                "Select a number or press Q or ESC to return to menu.\r\n"
                );
            Console.WriteLine();
            do
            {
                keyPress = Console.ReadKey(true).Key;
                switch (keyPress)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.WriteLine($"Roll: {cup.RollAttack()}, out of {cup.RollStringResults()}");
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.WriteLine($"Roll: {cup.RollAttack(RollCondition.Advantage)}, out of {cup.RollStringResults()}");
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Console.WriteLine($"Roll: {cup.RollAttack(RollCondition.Disadvantage)}, out of {cup.RollStringResults()}");
                        break;
                    case ConsoleKey.Q:
                    case ConsoleKey.Escape:
                        return;
                    default:
                        break;
                }
            }
            while (true);
        }

        private static void RollDamage(DiceCup cup)
        {
            do
            {
                Console.Clear();
                Console.Write("Select Dice Number and Type: ");
                Console.WriteLine($"Roll: {cup.Roll(Console.ReadLine(), RollType.Damage)}, out of {cup.RollStringResults()} \n");
                Console.WriteLine("Press Q to return to main menu or any other key to roll again");
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Q || key == ConsoleKey.Escape)
                    return;
            } while (true);
        }

        private static void ConsoleMenu(int numOptions, string optionsList, Func<MenuOption>[] funcs)
        {
            Console.WriteLine(optionsList);
            ConsoleKey keyPress = Console.ReadKey(true).Key;
            switch (keyPress)
            {
                case ConsoleKey.Backspace:
                    break;
                case ConsoleKey.Tab:
                    break;
                case ConsoleKey.Clear:
                    break;
                case ConsoleKey.Enter:
                    break;
                case ConsoleKey.Pause:
                    break;
                case ConsoleKey.Escape:
                    break;
                case ConsoleKey.Spacebar:
                    break;
                case ConsoleKey.PageUp:
                    break;
                case ConsoleKey.PageDown:
                    break;
                case ConsoleKey.End:
                    break;
                case ConsoleKey.Home:
                    break;
                case ConsoleKey.LeftArrow:
                    break;
                case ConsoleKey.UpArrow:
                    break;
                case ConsoleKey.RightArrow:
                    break;
                case ConsoleKey.DownArrow:
                    break;
                case ConsoleKey.Select:
                    break;
                case ConsoleKey.Print:
                    break;
                case ConsoleKey.Execute:
                    break;
                case ConsoleKey.PrintScreen:
                    break;
                case ConsoleKey.Insert:
                    break;
                case ConsoleKey.Delete:
                    break;
                case ConsoleKey.Help:
                    break;
                case ConsoleKey.D0:
                    break;
                case ConsoleKey.D1:
                    break;
                case ConsoleKey.D2:
                    break;
                case ConsoleKey.D3:
                    break;
                case ConsoleKey.D4:
                    break;
                case ConsoleKey.D5:
                    break;
                case ConsoleKey.D6:
                    break;
                case ConsoleKey.D7:
                    break;
                case ConsoleKey.D8:
                    break;
                case ConsoleKey.D9:
                    break;
                case ConsoleKey.A:
                    break;
                case ConsoleKey.B:
                    break;
                case ConsoleKey.C:
                    break;
                case ConsoleKey.D:
                    break;
                case ConsoleKey.E:
                    break;
                case ConsoleKey.F:
                    break;
                case ConsoleKey.G:
                    break;
                case ConsoleKey.H:
                    break;
                case ConsoleKey.I:
                    break;
                case ConsoleKey.J:
                    break;
                case ConsoleKey.K:
                    break;
                case ConsoleKey.L:
                    break;
                case ConsoleKey.M:
                    break;
                case ConsoleKey.N:
                    break;
                case ConsoleKey.O:
                    break;
                case ConsoleKey.P:
                    break;
                case ConsoleKey.Q:
                    break;
                case ConsoleKey.R:
                    break;
                case ConsoleKey.S:
                    break;
                case ConsoleKey.T:
                    break;
                case ConsoleKey.U:
                    break;
                case ConsoleKey.V:
                    break;
                case ConsoleKey.W:
                    break;
                case ConsoleKey.X:
                    break;
                case ConsoleKey.Y:
                    break;
                case ConsoleKey.Z:
                    break;
                case ConsoleKey.LeftWindows:
                    break;
                case ConsoleKey.RightWindows:
                    break;
                case ConsoleKey.Applications:
                    break;
                case ConsoleKey.Sleep:
                    break;
                case ConsoleKey.NumPad0:
                    break;
                case ConsoleKey.NumPad1:
                    break;
                case ConsoleKey.NumPad2:
                    break;
                case ConsoleKey.NumPad3:
                    break;
                case ConsoleKey.NumPad4:
                    break;
                case ConsoleKey.NumPad5:
                    break;
                case ConsoleKey.NumPad6:
                    break;
                case ConsoleKey.NumPad7:
                    break;
                case ConsoleKey.NumPad8:
                    break;
                case ConsoleKey.NumPad9:
                    break;
                case ConsoleKey.Multiply:
                    break;
                case ConsoleKey.Add:
                    break;
                case ConsoleKey.Separator:
                    break;
                case ConsoleKey.Subtract:
                    break;
                case ConsoleKey.Decimal:
                    break;
                case ConsoleKey.Divide:
                    break;
                case ConsoleKey.F1:
                    break;
                case ConsoleKey.F2:
                    break;
                case ConsoleKey.F3:
                    break;
                case ConsoleKey.F4:
                    break;
                case ConsoleKey.F5:
                    break;
                case ConsoleKey.F6:
                    break;
                case ConsoleKey.F7:
                    break;
                case ConsoleKey.F8:
                    break;
                case ConsoleKey.F9:
                    break;
                case ConsoleKey.F10:
                    break;
                case ConsoleKey.F11:
                    break;
                case ConsoleKey.F12:
                    break;
                case ConsoleKey.F13:
                    break;
                case ConsoleKey.F14:
                    break;
                case ConsoleKey.F15:
                    break;
                case ConsoleKey.F16:
                    break;
                case ConsoleKey.F17:
                    break;
                case ConsoleKey.F18:
                    break;
                case ConsoleKey.F19:
                    break;
                case ConsoleKey.F20:
                    break;
                case ConsoleKey.F21:
                    break;
                case ConsoleKey.F22:
                    break;
                case ConsoleKey.F23:
                    break;
                case ConsoleKey.F24:
                    break;
                case ConsoleKey.BrowserBack:
                    break;
                case ConsoleKey.BrowserForward:
                    break;
                case ConsoleKey.BrowserRefresh:
                    break;
                case ConsoleKey.BrowserStop:
                    break;
                case ConsoleKey.BrowserSearch:
                    break;
                case ConsoleKey.BrowserFavorites:
                    break;
                case ConsoleKey.BrowserHome:
                    break;
                case ConsoleKey.VolumeMute:
                    break;
                case ConsoleKey.VolumeDown:
                    break;
                case ConsoleKey.VolumeUp:
                    break;
                case ConsoleKey.MediaNext:
                    break;
                case ConsoleKey.MediaPrevious:
                    break;
                case ConsoleKey.MediaStop:
                    break;
                case ConsoleKey.MediaPlay:
                    break;
                case ConsoleKey.LaunchMail:
                    break;
                case ConsoleKey.LaunchMediaSelect:
                    break;
                case ConsoleKey.LaunchApp1:
                    break;
                case ConsoleKey.LaunchApp2:
                    break;
                case ConsoleKey.Oem1:
                    break;
                case ConsoleKey.OemPlus:
                    break;
                case ConsoleKey.OemComma:
                    break;
                case ConsoleKey.OemMinus:
                    break;
                case ConsoleKey.OemPeriod:
                    break;
                case ConsoleKey.Oem2:
                    break;
                case ConsoleKey.Oem3:
                    break;
                case ConsoleKey.Oem4:
                    break;
                case ConsoleKey.Oem5:
                    break;
                case ConsoleKey.Oem6:
                    break;
                case ConsoleKey.Oem7:
                    break;
                case ConsoleKey.Oem8:
                    break;
                case ConsoleKey.Oem102:
                    break;
                case ConsoleKey.Process:
                    break;
                case ConsoleKey.Packet:
                    break;
                case ConsoleKey.Attention:
                    break;
                case ConsoleKey.CrSel:
                    break;
                case ConsoleKey.ExSel:
                    break;
                case ConsoleKey.EraseEndOfFile:
                    break;
                case ConsoleKey.Play:
                    break;
                case ConsoleKey.Zoom:
                    break;
                case ConsoleKey.NoName:
                    break;
                case ConsoleKey.Pa1:
                    break;
                case ConsoleKey.OemClear:
                    break;
                default:
                    break;
            }
        }

        private static void ErrorMessage(string message)
        {
            Console.WriteLine(message);
            Console.Read();
        }

        private static void GetHistory()
        {
            Console.Clear();
            GenerateRandomHistory(100);

            string rolls;
            string titleBar = string.Format("{0,-5}{1,-6}{2,-11}{3,-14}{4,-9}{5,-7}{6,-11}", "ID", "Owner", "DateTime", "RollType", "DiceType", "Result", "Rolls");
            Console.WriteLine(titleBar);

            foreach (KeyValuePair<int, Tuple<int?, DateTime, RollType, DiceType, object, List<int>>> roll in DiceRoller.RollHistory)
            {

                string cupID = roll.Value.Item1 is null ? "null" : roll.Value.Item1.ToString();
                if (roll.Value.Item4 == DiceType.d2)
                {
                    List<CoinFlip> newRoll = new();
                    foreach (var result in roll.Value.Item6)
                        newRoll.Add((CoinFlip)result);
                    rolls = "[ " + string.Join(", ", newRoll) + " ]";
                }
                else
                    rolls = "[ " + string.Join(", ", roll.Value.Item5) + " ]";
                string output = string.Format("{0,-5}{1,-6}{2,-11:yyyy-MM-dd}{3,-14}{4,-9}{5,-7:0.##}{6,-11}", roll.Key, cupID, roll.Value.Item2, roll.Value.Item3, roll.Value.Item4, roll.Value.Item5, rolls);
                Console.WriteLine(output);
            }
            XMLConverter.ExportRollHistory();
            Console.ReadLine();
        }
    }
}