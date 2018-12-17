using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Classes
{
    class Flag : CellState
    {

    private static Flag flag;

    private Flag()
    {
    }

    public static Flag getInstance()
    {
        if (flag == null)
            flag = new Flag();
        return flag;
    }

    
    public override String GetIcon()
    {
        return "..\\..\\Images\\flag.png";
    }
        
    public override bool GetTouchable()
    {
        return true;
    }
}
}
