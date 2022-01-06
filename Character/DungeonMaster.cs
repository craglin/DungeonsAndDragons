using System;
using System.Collections.Generic;

namespace DungeonsAndDragons
{
    public enum Source
    {
        Players_Handbook,
        Dungeon_Masters_Guide
    }

    public class DungeonMaster
    {
        // Containers for World Objects
        public static Dictionary<int, AbstractCharacter> Cast { get; internal set; }

        public static Dictionary<int, Spell> Library { get; internal set; }

        public static Dictionary<CoinType, int> Mint { get; internal set; }

        public static Dictionary<int, Treasure> Vault { get; internal set; }

        public static Dictionary<int, Equipment> Armory { get; internal set; }

        public DungeonMaster()
        {
            Cast = new();
            Library = new();
            Mint = new();
            Vault = new();
            Armory = new();
        }

        public DungeonMaster(string saveName)
        {

        }

        public void AddToMint()
        {

        }


    }
}
