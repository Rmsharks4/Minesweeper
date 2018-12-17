using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Classes
{
    class Cell
    {
        private CellState state;
        private CellState savedState = null;

        public Cell()
        {
            this.state = Empty.GetInstance();
        }

        public void setState(CellState state)
        {
            if (state == Flag.getInstance())
                savedState = this.state;
            this.state = state;
        }

        public CellState getState()
        {
            return state;
        }

        public void restoreState()
        {
            if (savedState != null)
                state = savedState;
            savedState = null;
        }

    }
}
