using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDragons.Character.Abilities
{
    public interface IEquipable
    {
        // General Item
        public string Description { get; internal set; }
        public EquipmentType Type { get; internal set; }
        public HashSet<Weapon> WeaponSubtype { get; internal set; }
        public HashSet<Armor> ArmorSubtype { get; internal set; }
        public HashSet<EquipmentType> EquipmentType { get; internal set; }
        public int Weight { get; internal set; }
        public CoinType Cost { get; internal set; }
        public CoinType Value { get; internal set; }
        public Source Source { get; internal set; }

        // Equipped Status
        public bool IsEquipped { get; internal set; }
        public bool IsCursed { get; internal set; }
    }
}
