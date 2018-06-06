using System;
using System.Drawing;
using System.Windows.Forms;

namespace Windows
{
    public partial class Windows : Form
    {
        private int move = -1;
        private int checkX = 6;
        private int checkY = 6;

        public Windows()
        {
            InitializeComponent();
        }

        private void Windows_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                move = 0; 
            }
            else if (e.KeyCode == Keys.Up)
            {
                move = 1;
            }
            else if (e.KeyCode == Keys.Right)
            {
                move = 2;
            }
            else if (e.KeyCode == Keys.Down)
            {
                move = 3;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                move = -1;
                Location = new Point((Screen.PrimaryScreen.Bounds.Size.Width / 2) - (Size.Width / 2), (Screen.PrimaryScreen.Bounds.Size.Height / 2) - (Size.Height / 2));
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (move == 0)
            {
                if (Location.X < 6)
                {
                    Location = new Point(0, Location.Y);
                    move = 2;
                }
                else
                {
                    Location = new Point(Location.X - checkX, Location.Y);
                }
            }
            else if (move == 1)
            {
                if (Location.Y < 6)
                {
                    Location = new Point(Location.X, 0);
                    move = 3;
                }
                else
                {
                    Location = new Point(Location.X, Location.Y - checkY);
                }
            }
            else if (move == 2)
            {
                if (Location.X > Screen.PrimaryScreen.Bounds.Size.Width - (ClientSize.Width + 22))
                {
                    Location = new Point(Screen.PrimaryScreen.Bounds.Size.Width - (ClientSize.Width + 16), Location.Y);
                    move = 0;
                }
                else
                {
                    Location = new Point(Location.X + checkX, Location.Y);
                } 
            }
            else if (move == 3)
            {
                if (Location.Y > Screen.PrimaryScreen.Bounds.Size.Height - (ClientSize.Height + 45))
                {
                    Location = new Point(Location.X, Screen.PrimaryScreen.Bounds.Size.Height - (ClientSize.Height + 39));
                    move = 1;
                }
                else
                {
                    Location = new Point(Location.X, Location.Y + checkY);
                } 
            }
        }
    }
}