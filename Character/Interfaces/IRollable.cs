using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDragons
{

    interface IRollable
    {
        public void Roll();
        public void RollWithAdvantage();
        public void RollWithDisadvantage();
        public void RollAgainstTable();
    }
}
