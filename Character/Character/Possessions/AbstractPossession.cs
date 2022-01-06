using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDragons
{
    public abstract class AbstractPossession
    {
        public string Name { get; set; }

        public int ID { get; set; }

        public Rarity Rarity { get; set; }

        public int Value { get; set; }
        public CoinType Currency { get; internal set; }

        public Source Source { get; set; }

        public string Description { get; set; }
    }

}
