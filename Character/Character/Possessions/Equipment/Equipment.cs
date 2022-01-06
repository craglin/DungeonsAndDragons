using System.Collections.Generic;

namespace DungeonsAndDragons
{
    public enum EquipmentType
    {
        Adventuring_Gear, 
        Ammunition,
        Armor,
        ArcaneFocus,
        Container,
        Magical_Instrument,
        Musical_Instrument,
        Scientific_Instrument,
        Pack_Equipment,
        Poison,
        Tool,
        Vehicle_Air,
        Vehicle_Land,
        Vehicle_Nether,
        Vehicle_Sea,
        Weapon,
    }

    public class Equipment : AbstractPossession /* TODO implement , IEquipable */
    {
        public EquipmentType Type { get; internal set; }
        public int Weight { get; internal set; }

        public Equipment()
        {
        }

    }
}
