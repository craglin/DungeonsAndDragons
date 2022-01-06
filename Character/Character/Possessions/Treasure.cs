using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDragons
{
    public enum TreasureSource
    {
        Hoard,
        Individual,
    }

    public enum TreasureTypes
    {
        Art_Objects,
        Currency,
        Gemstone,
        Magic_Item,
        Potion,
        Scroll,
    }

    public enum Rarity
    {
        Common,
        Uncommon,
        Rare,
        Very_Rare,
        Legendary,
    }

    public class Treasure
    {
        public TreasureTypes TreasureType {get; internal set;}

        public Rarity TreasureRarity { get; internal set; }

        public int Value { get; internal set; }

        public string Description { get; internal set; }

    }
}
