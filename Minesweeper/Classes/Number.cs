using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Classes
{
    class Number : CellState
    {

        private int number;

        public Number(int number)
        {
            this.number = number;
        }

        public int getNumber()
        {
            return number;
        }

        public void setNumber(int number)
        {
            this.number = number;
        }

        public override string GetIcon()
        {
            return number + "";
        }

        public override bool GetTouchable()
        {
            return false;
        }
    }
}
