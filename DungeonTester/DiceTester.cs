using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace DungeonsAndDragons
{
    /// <summary>
    /// Testing the dicecup object tied to players/GMs, the DiceRoller utility static class, and the DungeonSystem's implementation
    /// </summary>
    [TestClass]
    public class DiceTester
    {
        private static DiceCup cup;
        private static Random rng;

        [ClassInitialize]
        public static void ClassInitializer(TestContext testContext)
        {
            cup = new DiceCup();
            rng = new Random(20210317);
            DiceRoller.ResetSeed(true);
        }

        [TestInitialize]
        public void TestInitializer()
        {
            //rng = new Random(20210317);
        }

        #region DiceCup Methods
        [TestMethod]
        public void RollString1d6()
        {
            int control = rng.Next(0, 6) + 1;
            string rollString = "1d6";
            Assert.AreEqual(control, cup.Roll(rollString));
        }

        [TestMethod]
        public void RollString2d4()
        {
            string rollString = "2d4";
            int[] control = new int[2];
            for (int i = 0; i < 2; i++)
                control[i] = rng.Next(0, 4) + 1;
            Assert.AreEqual(control.Sum(), cup.Roll(rollString));
        }

        [TestMethod]
        public void RollString3d8()
        {
            string rollString = "3d8 * 10";
            int[] control = new int[3];
            for (int i = 0; i < 3; i++)
                control[i] = rng.Next(0, 8) + 1;
            Assert.AreEqual(control.Sum() * 10, cup.Roll(rollString));
        }

        [TestMethod]
        public void RollString4d10()
        {
            string rollString = "4d10 * 10 advantage";
            int[] control = new int[4];
            for (int i = 0; i < 4; i++)
                control[i] = rng.Next(0, 10) + 1;
            Assert.AreEqual(control.Sum() * 10, cup.Roll(rollString));
        }

        [TestMethod]
        public void RollString5d12()
        {
            string rollString = "5d12*10";
            int[] control = new int[5];
            for (int i = 0; i < 5; i++)
                control[i] = rng.Next(0, 12) + 1;
            Assert.AreEqual(control.Sum() * 10, cup.Roll(rollString));
        }

        [TestMethod]
        public void RollAttack()
        {
            int control = rng.Next(0, 20) + 1;
            Assert.AreEqual(control, cup.RollAttack());
        }

        [TestMethod]
        public void RollAttackDisadvantage()
        {
            int[] control = new int[2];
            for (int i = 0; i < 2; i++)
                control[i] = rng.Next(0, 20) + 1;
            Assert.AreEqual(control.Min(), cup.RollAttack(RollCondition.Disadvantage));
        }

        [TestMethod]
        public void RollAttackAdvantage()
        {
            int[] control = new int[2];
            for (int i = 0; i < 2; i++)
                control[i] = rng.Next(0, 20) + 1;
            Assert.AreEqual(control.Max(), cup.RollAttack(RollCondition.Advantage));
        }

        [TestMethod]
        public void RollDamageOneD4()
        {
            int control = rng.Next(0, 4) + 1;
            Assert.AreEqual(control, cup.RollDamage(DiceType.d4, 1));
        }

        [TestMethod]
        public void RollDamageTwoD4()
        {
            int[] control = new int[2];
            for (int i = 0; i < 2; i++)
                control[i] = rng.Next(0, 4) + 1;
            Assert.AreEqual(control.Sum(), cup.RollDamage(DiceType.d4, 2));
        }

        [TestMethod]
        public void RollDamageFourD4()
        {
            int[] control = new int[4];
            for (int i = 0; i < 4; i++)
                control[i] = rng.Next(0, 4) + 1;
            Assert.AreEqual(control.Sum(), cup.RollDamage(DiceType.d4, 4));
        }

        [TestMethod]
        public void RollDamageEightD4()
        {
            int[] control = new int[8];
            for (int i = 0; i < 8; i++)
                control[i] = rng.Next(0, 4) + 1;
            Assert.AreEqual(control.Sum(), cup.RollDamage(DiceType.d4, 8));
        }

        [TestMethod]
        public void RollDamageOneD6()
        {
            int control = rng.Next(0, 6) + 1;
            Assert.AreEqual(control, cup.RollDamage(DiceType.d6, 1));
        }

        [TestMethod]
        public void RollDamageTwoD6()
        {
            int[] control = new int[2];
            for (int i = 0; i < 2; i++)
                control[i] = rng.Next(0, 6) + 1;
            Assert.AreEqual(control.Sum(), cup.RollDamage(DiceType.d6, 2));
        }

        [TestMethod]
        public void RollDamageOneD8()
        {
            int[] control = new int[2];
            for (int i = 0; i < 1; i++)
                control[i] = rng.Next(0, 8) + 1;
            Assert.AreEqual(control.Sum(), cup.RollDamage(DiceType.d8, 1));
        }

        [TestMethod]
        public void RollDamageTwoD8Times100()
        {
            int[] control = new int[2];
            for (int i = 0; i < 2; i++)
                control[i] = rng.Next(0, 8) + 1;
            Assert.AreEqual(control.Sum() * 100, cup.RollDamage(DiceType.d8, 2, 100));
        }

        [TestMethod]
        public void FlipCoin()
        {
            int[] control = new int[1];
            for (int i = 0; i < 1; i++)
                control[i] = rng.Next(0, 2) + 1;
            string result = control[0] == 1 ? "Heads" : "Tails";
            Assert.AreEqual(result, cup.FlipCoin());
        }

        [TestMethod]
        public void RollPercentile()
        {
            int[] control = new int[1];
            for (int i = 0; i < 1; i++)
                control[i] = rng.Next(0, 100) + 1;
            Assert.AreEqual(control[0], cup.RollPercentile());
        }
        #endregion

        [TestMethod]
        public void GetSummary()
        {
            for (int i = 0; i < 20; i++)
            {
                cup.FlipCoin();
            }
            foreach (var roll in DiceRoller.RollHistory)
            {

            }
        }

        [TestMethod]
        public void CheckRollHistory()
        {

        }
    }
}
