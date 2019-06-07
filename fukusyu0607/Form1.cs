using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fukusyu0607
{
    public partial class Form1 : Form
    {
        int vx = -10;
        int vy = -10;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Left += vx;
            label1.Top += vy;

            Point p = PointToClient(MousePosition);

            if (label1.Left < 0)
            {
                vx = Math.Abs(vx);
            }
            if (label1.Left > ClientSize.Width - label1.Width) 
            {
                vx = -Math.Abs(vx);
            }
            if (label1.Top < 0)
            {
                vy = Math.Abs(vy);
            }
            if (label1.Top > ClientSize.Height - label1.Height) 
            {
                vy = -Math.Abs(vy);
            }

            if ((label1.Top <= p.Y) && (label1.Bottom >= p.Y) && (label1.Left <= p.X) && (label1.Right >= p.X))  
            {
                timer1.Enabled = false;
            }
            if ((label1.Bottom >= label2.Top) && (label1.Top <= label2.Bottom)&&(label1.Right >= label2.Left) && (label1.Left <= label2.Right))
            {
                vx = -vx;
                vy = -vy;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
