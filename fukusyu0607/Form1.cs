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
        int vx = rand.Next(-20, 21);
        int vy = rand.Next(-20, 21);
        int vx1 = rand.Next(-20, 21);
        int vy1 = rand.Next(-20, 21);
        int vx2 = rand.Next(-20, 21);
        int vy2 = rand.Next(-20, 21);

        int a = 0;
        int time = 300;

        public Form1()
        {
            InitializeComponent();

            //以下に、label1.Leftとlabel1.Topの座標をランダムで求めよ
            label1.Top = rand.Next(0, ClientSize.Height - label1.Height);
            label1.Left = rand.Next(0, ClientSize.Width - label1.Width);

            label2.Top = rand.Next(0, ClientSize.Height - label1.Height);
            label2.Left = rand.Next(0, ClientSize.Width - label1.Width);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Left += vx;
            label1.Top += vy;
            label3.Left += vx1;
            label3.Top += vy1;
            label4.Left += vx2;
            label4.Top += vy2;

            time--;
            label5.Text = "time:" + time;
            if (time == 0)
            {
                timer1.Enabled = false;
                MessageBox.Show("終了");
            }
            if (a == 3)
            {
                timer1.Enabled = false;
                MessageBox.Show("クリア！");
            }

            Point p = PointToClient(MousePosition);

            if (label1.Left < 0)
            {
                vx = Math.Abs(rand.Next(-20, -9));
            }
            if (label1.Left > ClientSize.Width - label1.Width) 
            {
                vx = -Math.Abs(rand.Next(10, 21));
            }
            if (label1.Top < 0)
            {
                vy = Math.Abs(rand.Next(-20, -9));
            }
            if (label1.Top > ClientSize.Height - label1.Height) 
            {
                vy = -Math.Abs(rand.Next(10, 21));
            }


            if ((label1.Top <= p.Y) && (label1.Bottom >= p.Y) && (label1.Left <= p.X) && (label1.Right >= p.X))  
            {
                a++;
                label1.Enabled = false;
                label1.Visible = false;
            }
            if ((label3.Top <= p.Y) && (label3.Bottom >= p.Y) && (label3.Left <= p.X) && (label3.Right >= p.X))
            {
                a++;
                label3.Enabled = false;
                label3.Visible = false;
            }
            if ((label4.Top <= p.Y) && (label4.Bottom >= p.Y) && (label4.Left <= p.X) && (label4.Right >= p.X))
            {
                a++;
                label4.Enabled = false;
                label4.Visible = false;
            }


            if ((label1.Bottom >= label2.Top)&&(label1.Top<=label2.Bottom) && (label1.Right >= label2.Left)&&(label1.Left<=label2.Right))
            {
                if ((vy > 0) && (label1.Bottom < label2.Bottom))
                    vy = rand.Next(-20, -9);
                if ((vy < 0) && (label1.Top > label2.Top))
                    vy = rand.Next(10, 21);
            }

            if (label3.Left < 0)
            {
                vx1 = Math.Abs(rand.Next(-20, -9));
            }
            if (label3.Left > ClientSize.Width - label3.Width)
            {
                vx1 = -Math.Abs(rand.Next(10, 21));
            }
            if (label3.Top < 0)
            {
                vy1 = Math.Abs(rand.Next(-20, -9));
            }
            if (label3.Top > ClientSize.Height - label3.Height)
            {
                vy1 = -Math.Abs(rand.Next(10, 21));
            }
            if ((label3.Bottom >= label2.Top) && (label3.Top <= label2.Bottom) && (label3.Right >= label2.Left) && (label3.Left <= label2.Right))
            {
                if ((vy1 > 0) && (label3.Bottom < label2.Bottom))
                    vy = rand.Next(-20, -9);
                if ((vy1 < 0) && (label3.Top > label2.Top))
                    vy = rand.Next(10, 21);
            }

            if (label4.Left < 0)
            {
                vx2 = Math.Abs(rand.Next(-20, -9));
            }
            if (label4.Left > ClientSize.Width - label4.Width)
            {
                vx2 = -Math.Abs(rand.Next(10, 21));
            }
            if (label4.Top < 0)
            {
                vy2 = Math.Abs(rand.Next(-20, -9));
            }
            if (label4.Top > ClientSize.Height - label4.Height)
            {
                vy2 = -Math.Abs(rand.Next(10, 21));
            }
            if ((label4.Bottom >= label2.Top) && (label4.Top <= label2.Bottom) && (label4.Right >= label2.Left) && (label4.Left <= label2.Right))
            {
                if ((vy2 > 0) && (label4.Bottom < label2.Bottom))
                    vy2 = rand.Next(-20, -9);
                if ((vy2 < 0) && (label4.Top > label2.Top))
                    vy2 = rand.Next(10, 21);
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
