using System;
using System.Collections.Generic;

namespace DungeonsAndDragons
{
    public interface ICastable
    {
        public static Dictionary<int, ICastable> SpellList;
        public string Name { get; internal set; }
        public string Description { get; internal set; }
        public int Duration { get; internal set; }
        public int Range { get; internal set; }
        public int AreaMinEffect { get; internal set; }
        public int AreaMaxEffect { get; internal set; }
        public int SpellLevel { get; internal set; }
        public int CastLevel { get; internal set; }
        public bool RangedSpellAttack { get; internal set; }
        public ActionType CastTime { get; internal set; }
        public DamageType DamageType { get; internal set; }
        public Ability SaveType { get; internal set; }
        public Source Source { get; internal set; }
        public HashSet<PlayerClass> AvailableClasses { get; internal set; }

        public enum SpellSchool
        {
            Abjuration,
            Divination,
            Enchantment,
            Necromancy,
            Illusion,
            Conjuration,
            Evocation,
            Transmutation
        }

        /// <summary>
        /// A spell may use material, verbal, and/or somatic components.
        /// </summary>
        [Flags]
        public enum ComponentType
        {
            Material,
            Verbal,
            Somatic
        }

        /// <summary>
        /// A spell area of effect only uses one area effect type, where applicable.
        /// </summary>
        public enum AreaEffectType
        {
            Cone,
            Cube,
            Cylinder,
            Line,
            Sphere,
            Square
        }

    }
}
