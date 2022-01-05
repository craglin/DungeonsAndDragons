using System.Collections.Generic;

namespace DungeonsAndDragons
{
    public class Feat
    {
        public Dictionary<int, Feat> FeatList;
        public string FeatTitle { get; private set; }
        public Source Source { get; private set; }

        private Dictionary<CreatureType, int> bonus;

        // Need a rollable C# class

        public Feat()
        {
            Source = Source.Players_Handbook;
        }

        // Feat confers bonus to skill
        public void SkillBonus(Skill skill, int bonus)
        {

        }

        public void SkillBonus(Dictionary<Skill, int> skillsBonuses)
        {
            //foreach (Skill skill in skillsBonuses)
            //{
            //    this.
            //}
        }

    }
}
