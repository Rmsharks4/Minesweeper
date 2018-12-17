using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Classes
{
    class Board
    {
        private Cell[,] cells;
        private int level;
        private int size;
        private int bombscount;

        public Board(int level, int size)
        {
            this.level = level;
            this.size = size;
            this.bombscount = size * 2;
            cells = new Cell[size,size];
            SetBoard();
            SetMines();
            Traverse();
        }

        public void SetBoard()
        {
            CellState empty = Empty.GetInstance();
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    cells[i,j] = new Cell();
        }

        public void SetMines()
        {
            int mines = 0;
            Random random = new Random(DateTime.Now.Millisecond);
            Bomb bomb = Bomb.getInstance();
            
            while (mines < bombscount)
            {
                int i = random.Next() % size;
                int j = random.Next() % size;
                if (cells[i,j].getState() != bomb)
                {
                    cells[i,j].setState(bomb);
                    mines++;
                }
            }
        }

        public CellState MakeEstimate(int i, int j)
        {
            int mines = 0;
            mines += isBomb(i - 1, j - 1);
            mines += isBomb(i - 1, j);
            mines += isBomb(i - 1, j + 1);
            mines += isBomb(i, j - 1);
            mines += isBomb(i, j + 1);
            mines += isBomb(i + 1, j - 1);
            mines += isBomb(i + 1, j);
            mines += isBomb(i + 1, j + 1);
            if (mines > 0)
            {
                return new Number(mines);
            }
            else
            {
                return Empty.GetInstance();
            }
        }

        public void Traverse()
        {
            Bomb bomb = Bomb.getInstance();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (cells[i,j].getState() != bomb)
                    {
                        cells[i,j].setState(MakeEstimate(i, j));
                    }
                }
            }
        }

        public int isBomb(int i, int j)
        {
            if (i >= 0 && i < size && j >= 0 && j < size && cells[i,j].getState() == Bomb.getInstance())
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public void ChooseLevel(int level)
        {
            this.level = level;
        }

        public void SetBoardSize(int size)
        {
            this.size = size;
        }

        public int GetBombsCount()
        {
            return bombscount;
        }

        public Cell[,] getCells()
        {
            return cells;
        }
    }
}
