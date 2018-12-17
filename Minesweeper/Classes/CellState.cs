using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Classes
{
    public abstract class CellState
    {
        public abstract String GetIcon();
        public abstract bool GetTouchable();
    }

}
