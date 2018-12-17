using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Classes
{
    class Bomb : CellState
    {
        private static Bomb bomb;

        private Bomb()
        {
        }

        public static Bomb getInstance()
        {
            if (bomb == null)
                bomb = new Bomb();
            return bomb;
        }
        
    public override String GetIcon()
        {
            return "..\\..\\Images\\bomb.png";
        }
        
    public override bool GetTouchable()
        {
            return false;
        }

    }
}
