using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDragons
{
    public enum ActionType
    {
        Action,
        At_Will,
        Bonus_Action,
        Time
    }
    public enum Actions
    {
        Attack,
        Cast_A_Spell,
        Dash,
        Disengage,
        Dodge,
        Grapple,
        Help,
        Hide,
        Improvise,
        Ready,
        Search,
        Shove,
        Use_An_Object
    }
    interface IActionable
    {
    }
}
