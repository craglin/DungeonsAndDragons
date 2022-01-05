using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndDragons
{
    public class PlayerCharacter : AbstractCharacter
    {
        // Player Character Properties
        public Dictionary<PlayerClass, int> ClassLevel { get; internal set; }
        public Dictionary<CoinType, int> Wallet { get; internal set; }
        public int PlayerLevel
        {
            get { return ClassLevel.Sum(level => level.Value); }
        }
        public bool Inspiration { get; internal set; }
        public HashSet<Equipment> EquipmentSack { get; internal set; }
        public HashSet<Feat> Feats { get; internal set; }
        public override int CharacterID { get; internal set; }
        public override Name Name { get; internal set; }
        public override Size Size { get; internal set; }
        public override Alignment Alignment { get; internal set; }
        public override HashSet<Language> Languages { get; internal set; }
        public override int ProficiencyBonus { get; internal set; }
        public override int Initiative { get; internal set; }
        public override int ArmorClass { get; internal set; }
        public override int HitPoints { get; internal set; }
        public override int Speed { get; internal set; }
        public override List<DamageType> Resistances { get; internal set; }
        public override List<DamageType> Immunities { get; internal set; }
        public override DiceCup DiceCup { get; internal set; }
        public override HashSet<ICastable> SpellBook { get; internal set; }
        public override Race Race { get => throw new NotImplementedException(); internal set => throw new NotImplementedException(); }
        public override HashSet<Skill> Skills { get => throw new NotImplementedException(); internal set => throw new NotImplementedException(); }
        public override Dictionary<Skill, int> SkillProficiencies { get => throw new NotImplementedException(); internal set => throw new NotImplementedException(); }

        public PlayerCharacter(Name name) : base(name)
        {
        }
    }
}
