using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDragons
{
    public interface IEquipable
    {
        // Equipped Status
        public bool IsEquipped { get; internal set; }
        public bool IsCursed { get; internal set; }
    }
}
