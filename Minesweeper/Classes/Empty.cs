using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Classes
{
    class Empty : CellState
    {
        private static Empty empty;

        private Empty()
        {
        }

        public static Empty GetInstance()
        {
            if (empty == null)
                empty = new Empty();
            return empty;
        }
        
    public override String GetIcon()
        {
            return "";
        }
        
    public override bool GetTouchable()
        {
            return false;
        }

    }
}
