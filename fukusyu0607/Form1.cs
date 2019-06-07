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
        //疑似乱数
        //ランダムのシード（種）を指定して初期化したら、
        //それを使い続ける
        private static Random rand = new Random();
        int vx = rand.Next(-10, 11);
        int vy = rand.Next(-10, 11);

        public Form1()
        {
            InitializeComponent();

            //以下に、label1.Leftとlabel1.Topの座標をランダムで求めよ
            label1.Top = rand.Next(0, ClientSize.Height - label1.Height);
            label1.Left = rand.Next(0, ClientSize.Width - label1.Width);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Left += vx;
            label1.Top += vy;

            Point p = PointToClient(MousePosition);

            if (label1.Left < 0)
            {
                vx = Math.Abs(rand.Next(-10, 0));
            }
            if (label1.Left > ClientSize.Width - label1.Width) 
            {
                vx = -Math.Abs(rand.Next(1, 11));
            }
            if (label1.Top < 0)
            {
                vy = Math.Abs(rand.Next(-10, 0));
            }
            if (label1.Top > ClientSize.Height - label1.Height) 
            {
                vy = -Math.Abs(rand.Next(1, 11));
            }

            /*
            if ((label1.Top <= p.Y) && (label1.Bottom >= p.Y) && (label1.Left <= p.X) && (label1.Right >= p.X))  
            {
                timer1.Enabled = false;
            }
            */ 

            if ((label1.Bottom >= label2.Top)&&(label1.Top<=label2.Bottom) && (label1.Right >= label2.Left)&&(label1.Left<=label2.Right))
            {
                if ((vy > 0) && (label1.Bottom < label2.Bottom))
                    vy = rand.Next(-10, 0);
                if ((vy < 0) && (label1.Top > label2.Top))
                    vy = rand.Next(1, 11);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }
    }
}
