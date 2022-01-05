using System.Collections.Generic;

namespace DungeonsAndDragons
{
    public enum EquipmentType
    {
        Armor,
        Equipment,
        Treasure,
        Weapon,
    }

    public enum Armor
    {
        Light,
        Medium,
        Heavy
    }

    public enum EquipmentTags
    {
        Adventuring_Gear,
        Ammunition,
        ArcaneFocus,
        Container,
        Gemstone,
        Magical_Instrument,
        Musical_Instrument,
        Scientific_Instrument,
        Pack_Equipment,
        Poison,
        Potion,
        Tool,
        Vehicle_Air,
        Vehicle_Land,
        Vehicle_Nether,
        Vehicle_Sea,
    }

    public enum Quality
    {
        Common,
        Rare,
        Epic,
        Legendary
    }

    public enum Weapon
    {
        MartialMelee,
        MartialRanged,
        RangedFirearm,
        SimpleMelee,
        SimpleRanged,
    }

    public class Equipment
    {

        public Equipment()
        {
        }
    }
}
