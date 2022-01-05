namespace DungeonsAndDragons
{
    public class Skill
    {
        public SkillTitle SkillName { get; private set; }
        public string Description { get; private set; }
        public int SkillBonus { get; private set; }
        public bool Proficient { get; private set; }
        public Source Source { get; private set; }

        public enum SkillTitle
        {
            ACROBATICS,
            ANIMAL_HANDLING,
            ARCANA,
            ATHLETICS,
            DECEPTION,
            HISTORY,
            INSIGHT,
            INTIMIDATION,
            INVESTIGATION,
            MEDICINE,
            NATURE,
            PERCEPTION,
            PERFORMANCE,
            PERSUASION,
            RELIGION,
            SLEIGHT_OF_HAND,
            STEALTH,
            SURVIVAL,
        }

        public Skill(SkillTitle skillName, bool proficient)
        {
            SkillName = skillName;
            Description = "";
            SkillBonus = 0;
            Proficient = proficient;
            Source = Source.Players_Handbook;
        }
    }
}