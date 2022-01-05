using System.Collections.Generic;

namespace DungeonsAndDragons
{
    public enum Ability
    {
        Strength,
        Charisma,
        Constitution,
        Dexterity,
        Intelligence,
        Wisdom
    }

    interface IAbilities
    {
        public Ability Strength { get; set; }
        public Ability Charisma { get; set; }
        public Ability Constitution { get; set; }
        public Ability Dexterity { get; set; }
        public Ability Intelligence { get; set; }
        public Ability Wisdom { get; set; }
        public Dictionary<Ability, int> AbilityScores { get; set; }
        public Dictionary<Ability, int> AbilitySaves { get; set; }

    }
}
