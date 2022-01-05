using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonsAndDragons
{

    public class DiceCup
    {
        #region Cup Related
        // Cup object related
        internal int rollID;
        internal readonly int? cupOwnerID;

        // Roll related
        internal RollType rollType;
        internal DiceType diceType;
        internal RollCondition rollCondition;
        internal int numDice;
        internal int multiplier;
        internal int expectedResult;

        // Populated by DiceRoller
        internal List<int> rolls;
        internal object result;
        #endregion

        #region Reporting
        internal RollReport ReportStyle { get; set; }
        #endregion

        public DiceCup(int? ownerID = null)
        {
            cupOwnerID = ownerID;
            Reset();
        }

        public object Roll(string rollInfo, RollType rollType = RollType.Miscellaneous)
        {
            Reset();
            this.rollType = rollType;
            DiceRoller.Roll(this, rollInfo);
            return result;
        }

        public int RollAbility(AbilitySelectionStyle style)
        {
            diceType = DiceType.d6;
            rollType = RollType.Ability;
            multiplier = 1;

            switch (style)
            {
                case AbilitySelectionStyle.ThreeD6:
                    numDice = 3;
                    DiceRoller.Roll(this);
                    break;
                case AbilitySelectionStyle.FourD6DropLowest:
                    numDice = 4;
                    DiceRoller.Roll(this);
                    result = (int)result - rolls.Min();
                    break;
                default:
                    break;
            }
            return (int)result;
        }

        public int RollAttack(RollCondition condition = RollCondition.Normal)
        {
            Reset();
            rollType = RollType.Attack;
            rollCondition = condition;
            DiceRoller.Roll(this);
            return (int)result;
        }

        public int RollSave(RollCondition condition = RollCondition.Normal)
        {
            Reset();
            rollType = RollType.Save;
            rollCondition = condition;
            DiceRoller.Roll(this);
            return (int)result;
        }

        public int RollSkill(Skill skill, RollCondition condition = RollCondition.Normal)
        {
            Reset();
            rollType = RollType.Skill;
            rollCondition = condition;
            DiceRoller.Roll(this);
            return (int)result;
        }

        public int RollInitiative(RollCondition condition = RollCondition.Normal)
        {
            Reset();
            rollType = RollType.Initiative;
            rollCondition = condition;
            DiceRoller.Roll(this);
            return (int)result;
        }

        public int RollDamage(DiceType diceType, int numDice = 1, int multiplier = 1)
        {
            Reset();
            this.diceType = diceType;
            this.numDice = numDice;
            this.multiplier = multiplier;
            rollType = RollType.Damage;
            DiceRoller.Roll(this);
            return (int)result;
        }

        public int RollRestore(DiceType diceType, int numDice = 1, int multiplier = 1)
        {
            Reset();
            this.diceType = diceType;
            this.numDice = numDice;
            this.multiplier = multiplier;
            rollType = RollType.Restore;
            DiceRoller.Roll(this);
            return (int)result;
        }

        public int RollTreasure(DiceType diceType, int numDice = 1, int multiplier = 1)
        {
            Reset();
            this.diceType = diceType;
            this.numDice = numDice;
            this.multiplier = multiplier;
            rollType = RollType.Treasure;
            DiceRoller.Roll(this);
            return (int)result;
        }

        public string FlipCoin(int numFlips = 1)
        {
            Reset();
            rollType = RollType.Coin_Flip;
            numDice = numFlips;
            DiceRoller.Roll(this);
            result = (int)result == 1 ? "Heads" : "Tails";
            return result.ToString();
        }

        public int RollPercentile(int numRolls = 1)
        {
            Reset();
            rollType = RollType.Percentile;
            numDice = numRolls;
            DiceRoller.Roll(this);
            return Convert.ToInt32(result);
        }

        public void CupSummary()
        {
            // TODO: Create cup summary
            throw new NotImplementedException("Not ready yet");
        }

        public List<int> RollResults()
        {
            return rolls;
        }

        public string RollStringResults()
        {
            return " [ " + string.Join(", ", rolls) + " ]";
        }

        private void Reset()
        {
            rollType = RollType.none;
            diceType = DiceType.none;
            rollCondition = RollCondition.Normal;
            expectedResult = 0;
            numDice = 1;
            multiplier = 1;
            rolls = new List<int>();
        }
    }
}