using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDragons
{ 
    interface IMagical : ICursable
    {
        int Bonus { get; set; }
        bool HasCharges { get; set; }
    }
}
