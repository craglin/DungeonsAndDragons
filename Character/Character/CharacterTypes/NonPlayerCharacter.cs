using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDragons
{
    public enum CreatureType
    {
        Aberration,
        Beast,
        Celestial,
        Construct,
        Dragon,
        Elemental,
        Fey,
        Fiend,
        Giant,
        Humanoid,
        Monstrosity,
        Ooze,
        Plant,
        Undead
    }

    public class NonPlayerCharacter
    {
        public CreatureType Type { get; internal set; }

        //NonPlayerCharacter() : base(new Name("Jim", "Morgan"))
        //{

        //}
    }
}
