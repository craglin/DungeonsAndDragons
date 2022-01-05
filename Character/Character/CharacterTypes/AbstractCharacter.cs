using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonsAndDragons
{
    public enum Alignment
    {
        Lawful_Good,
        Neutral_Good,
        Chaotic_Good,
        Lawful_Neutral,
        True_Neutral,
        Chaotic_Neutral,
        Lawful_Evil,
        Neutral_Evil,
        Chaotic_Evil,
    }

    [Flags]
    public enum Language
    {
        Abyssal,
        Celestial,
        Deep_Speech,
        Draconic,
        Infernal,
        Common,
        Dwarvish,
        Elvish,
        Giant,
        Gnomish,
        Goblin,
        Halfling,
        Primordial,
        Sylvan,
        Orc,
        Undercommon,
    }
    public enum Size
    {
        Tiny,
        Small,
        Medium,
        Large,
        Huge,
        Gargantuan
    }
    public enum Sense
    {
        Blindsight,
        Darkvision,
        Tremorsense,
        Truesight,
    }

    [Flags]
    public enum StatusEffect
    {
        Blinded,
        Charmed,
        Deafened,
        Exhaustion,
        Frightened,
        Grappled,
        Incapacitated,
        Invisible,
        Paralyzed,
        Petrified,
        Poisoned,
        Prone,
        Restrained,
        Stunned,
        Unconscious
    }
    public enum PlayerClass
    {
        Artificer,
        Barbarian,
        Bard,
        Blood_Hunter,
        Cleric,
        Druid,
        Fighter,
        Monk,
        Paladin,
        Ranger,
        Rogue,
        Sorceror,
        Warlock,
        Wizard
    }

    public abstract class AbstractCharacter
    {
        // Universal Counter
        private static int ID = 0;
        // Character Information
        public abstract int CharacterID { get; internal set; }
        public abstract Name Name { get; internal set; }
        public abstract Race Race { get; internal set; }
        public abstract Size Size { get; internal set; }
        public abstract Alignment Alignment { get; internal set; }
        public abstract HashSet<Language> Languages { get; internal set; }
        public abstract int ProficiencyBonus { get; internal set; }

        // Offense
        public abstract int Initiative { get; internal set; }

        // Defense
        public abstract int ArmorClass { get; internal set; }
        public abstract int HitPoints { get; internal set; }
        public abstract int Speed { get; internal set; }
        public abstract List<DamageType> Resistances { get; internal set; }
        public abstract List<DamageType> Immunities { get; internal set; }

        // Rollable attributes
        public abstract DiceCup DiceCup { get; internal set; }
        public abstract HashSet<ICastable> SpellBook { get; internal set; }
        public abstract HashSet<Skill> Skills { get; internal set; }
        public abstract Dictionary<Skill, int> SkillProficiencies { get; internal set; }

        public AbstractCharacter(Name name)
        {
            CharacterID = ID++;
            DungeonMaster.Cast[CharacterID] = this;
            Name = name;
        }
    }
}
