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

    public class Treasure : AbstractPossession
    {
        private static int idCounter = 0;

        public TreasureTypes TreasureType {get; set; }

        public Treasure()
        {
            ID = idCounter++;
            DungeonMaster.Vault[ID] = this;
        }
    }
}
