using System;
using System.Drawing;
using System.Windows.Forms;

namespace Windows
{
    public partial class Window : Form
    {
        private const int stay = -1;
        private const int left = 0;
        private const int up = 1;
        private const int right = 2;
        private const int down = 3;
        private int status = -1; 
        private const int checkX = 6; //Дальность шага у окна по оси Х
        private const int checkY = 6; //Дальность шага у окна по оси У
        private const int widthFirst = 16;
        private const int widthSecond = 22;
        private const int heightFirst = 39;
        private const int heightSecond = 45;

        public Window()
        {
            InitializeComponent();
        }

        private void Windows_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                status = left; 
            }
            else if (e.KeyCode == Keys.Up)
            {
                status = up;
            }
            else if (e.KeyCode == Keys.Right)
            {
                status = right; 
            }
            else if (e.KeyCode == Keys.Down)
            {
                status = down; 
            }
            else if (e.KeyCode == Keys.Enter)
            {
                status = stay; 
                Location = new Point((Screen.PrimaryScreen.Bounds.Size.Width / 2) - (Size.Width / 2), (Screen.PrimaryScreen.Bounds.Size.Height / 2) - (Size.Height / 2));
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (status == left)
            {
                if (Location.X < checkX)
                {
                    Location = new Point(0, Location.Y);
                    status = right;
                }
                else
                {
                    Location = new Point(Location.X - checkX, Location.Y);
                }
            }
            else if (status == up)
            {
                if (Location.Y < checkY)
                {
                    Location = new Point(Location.X, 0);
                    status = down;
                }
                else
                {
                    Location = new Point(Location.X, Location.Y - checkY);
                }
            }
            else if (status == right)
            {
                if (Location.X > Screen.PrimaryScreen.Bounds.Size.Width - (ClientSize.Width + widthSecond))
                {
                    Location = new Point(Screen.PrimaryScreen.Bounds.Size.Width - (ClientSize.Width + widthFirst), Location.Y);
                    status = left;
                }
                else
                {
                    Location = new Point(Location.X + checkX, Location.Y);
                } 
            }
            else if (status == down)
            {
                if (Location.Y > Screen.PrimaryScreen.Bounds.Size.Height - (ClientSize.Height + heightSecond))
                {
                    Location = new Point(Location.X, Screen.PrimaryScreen.Bounds.Size.Height - (ClientSize.Height + heightFirst));
                    status = up;
                }
                else
                {
                    Location = new Point(Location.X, Location.Y + checkY);
                } 
            }
        }
    }
}