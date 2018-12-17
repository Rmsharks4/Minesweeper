using Minesweeper.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class GUI : Form
    {
        private Board board;
        private int size;
        private int score;
        private int counter = 0;

        public GUI()
        {
            InitializeComponent();
            ClockIcon.BackgroundImage = System.Drawing.Image.FromFile(@"..\..\Images\clock.gif");
            BombIcon.BackgroundImage = System.Drawing.Image.FromFile(@"..\..\Images\bombCount.png");
            this.size = 9;
            score = 0;
            Start();
            Bombs.Text = "Bombs: " + board.GetBombsCount();
        }

        void Start()
        {
            this.board = new Board(1, 9);
            timer.Start();
        }

        public void StopORContinue(int x, int y)
        {
            if (board.getCells()[x,y].getState() == Bomb.getInstance())
            {
                ShowAll();
                GetWinState(0);
            }
            else if (board.getCells()[x,y].getState() == Flag.getInstance())
                return;
            else
            {
                score++;
                if (score == (size * size - board.GetBombsCount()))
                    GetWinState(1);
                else
                    Reveal(x, y);
            }
        }

        public void Reveal(int x, int y)
        {
            if (RevealNextCell(x - 1, y - 1) &&
            RevealNextCell(x - 1, y) &&
            RevealNextCell(x - 1, y + 1) &&
            RevealNextCell(x + 1, y) &&
            RevealNextCell(x, y - 1) &&
            RevealNextCell(x, y + 1) &&
            RevealNextCell(x + 1, y - 1) &&
            RevealNextCell(x + 1, y + 1)) ;
        }

        public bool RevealNextCell(int x, int y)
        {
            if (x >= size || y >= size || x < 0 || y < 0)
                return false;
            else if (board.getCells()[x,y].getState() == Bomb.getInstance())
                return false;
            else
            {
                Button current = (Button) Game.GetControlFromPosition(x,y);
                if (!current.Enabled)
                    return false;
                current.PerformClick();
                return true;
            }
        }

        public void ShowAll()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Button current = (Button) Game.GetControlFromPosition(i,j);
                    if (current.Enabled)
                        if (board.getCells()[i / size,i % size].getState() == Bomb.getInstance())
                            ChangeIcon(current, i / size, i % size);
                        else if (board.getCells()[i / size,i % size].getState() == Flag.getInstance())
                        {
                            board.getCells()[i / size,i % size].restoreState();
                            ChangeIcon(current, i / size, i % size);
                        }
                        else
                            current.Enabled = false;
                }
            }
        }

        public void ResetAll()
        {
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    board.getCells()[i,j].restoreState();
        }

        public int CalculateScore()
        {
            return score * 100;
        }

        public void GetWinState(int state)
        {
            timer.Stop();
            String result;
            if (state == 0)
                result = "LOOSSEERRR!..";
            else
                result = "YOU WIINNN!!!....";
            MessageBox.Show("GAME OVER!\n" + result + "\nTime (in seconds): " + counter + "\nSCORE: " + CalculateScore());
            newGameToolStripMenuItem_Click(null, null);
        }

        private void ChangeIcon(Button current, int x, int y)
        {
            CellState state = board.getCells()[x,y].getState();
            bool enabled = state.GetTouchable();
            current.Enabled = enabled;
            String icon = state.GetIcon();
            if (icon.Contains(".png"))
            {
                current.BackgroundImage = System.Drawing.Image.FromFile(@icon);
            } else {
                current.Text = icon;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Time.Text = "Seconds: " + counter++;
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI newGUI = new GUI
            {
                Visible = true
            };
            Hide();
            newGUI.Closed += (s, args) => this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CellClicked(object sender, MouseEventArgs e)
        {
            Button current = (Button)sender;
            TableLayoutPanelCellPosition location = Game.GetPositionFromControl(current);
            int x = location.Column;
            int y = location.Row;
            if (e.Button == MouseButtons.Right)
            {
                if (board.getCells()[x,y].getState() != Flag.getInstance())
                    board.getCells()[x,y].setState(Flag.getInstance());
                else
                    board.getCells()[x,y].restoreState();
            }
            ChangeIcon(current, x, y);
            StopORContinue(x, y);
        }
    }
}
