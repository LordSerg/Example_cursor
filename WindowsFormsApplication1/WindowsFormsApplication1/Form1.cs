using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Graphics g;
        int mouse;
        bool is_selected = false;
        //1 - default
        //2 - straight line
        //3 - draw any line
        //4 - clear
        //5 - select
        private void Form1_Load(object sender, EventArgs e)
        {
            base.Text = "";
            g = CreateGraphics();
            mouse = 0;
            comboBox1.Items.Add("p(V)");
            comboBox1.Items.Add("p(T)");
            comboBox1.Items.Add("V(T)");
            //comboBox1.Items.Add("V(ρ)");
            timer1.Enabled = true;
            timer1.Interval = 1;
            this.BackColor = Color.White;


            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            mouse = 1;
            if (is_selected == true)
            {

            }
            trackBar1.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mouse = 2;
            if (is_selected == true)
            {

            }
            trackBar1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mouse = 3;
            if (is_selected == true)
            {

            }
            trackBar1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mouse = 4;
            trackBar1.Visible = true;
            if (is_selected==true)
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mouse = 5;
            if (is_selected == true)
            {

            }
            trackBar1.Visible = false;
        }
        int sx,sy;
        Point p0,p1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (mouse == 0)
            {
                this.Cursor = new Cursor(GetType(), "3.cur");
            }
            //делает разные курсоры при разных действиях  
            if (mouse == 1)//стандарт
            {
                this.Cursor = new Cursor(GetType(), "UO - Gauntlet.cur");
            }
            if (mouse == 2)//прямые линии
            {
                this.Cursor = new Cursor(GetType(), "UO - move.cur");
                if (c2 == 1)
                {                    
                    g.DrawLine(Pens.White, p0, p1);
                    p1.X = MousePosition.X - this.Location.X;
                    p1.Y = MousePosition.Y - this.Location.Y;
                    g.DrawLine(Pens.Black, p0, p1);
                }
            }
            if (mouse == 3)//кривые лнии
            {
                this.Cursor = new Cursor(GetType(), "UO - text.cur");
            }
            if (mouse == 4)//стереть
            {
                this.Cursor = new Cursor(GetType(), "UO - precision.cur");
                if(c4==1)
                {
                    r1 = trackBar1.Value;
                    x = MousePosition.X - this.Location.X;
                    y = MousePosition.Y - this.Location.Y;
                    g.FillEllipse(Brushes.LightBlue, x - r1/2, y - r1/2, r1, r1);                    
                    g.FillEllipse(Brushes.White, x - r1 / 2, y - r1 / 2, r1, r1);
                    sx = x0 - x;
                    sy = y0 + y;
                    //for(double ix=0;ix<Math.Abs(sx/10);ix++)
                    //{
                    //    //
                    //}
                }                
            }
            if (mouse == 5)//выделить-передвинуть
            {
                
                this.Cursor = new Cursor(GetType(), "Arrow.cur");
                if(c5==1)
                {
                    x = MousePosition.X - this.Location.X;
                    y = MousePosition.Y - this.Location.Y;
                }
            }

        }

        int r1=120,x,y;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            is_selected = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //записывает нарисованный график в матрицу            
            //if (mouse == 2)//
            //{                
            //    if (c2 == 1)
            //    {
            //        g.DrawLine(Pens.White, p0, p1);
            //        p1.X = MousePosition.X - this.Location.X;
            //        p1.Y = MousePosition.Y - this.Location.Y;
            //        g.DrawLine(Pens.Black, p0, p1);
            //    }
            //}
            //if (mouse == 3)
            //{
            //    this.Cursor = new Cursor(GetType(), "UO - text.cur");
            //}
            //if (mouse == 4)
            //{
            //    this.Cursor = new Cursor(GetType(), "UO - precision.cur");
            //    if (c4 == 1)
            //    {
            //        x = MousePosition.X - this.Location.X;
            //        y = MousePosition.Y - this.Location.Y;
            //        g.FillEllipse(Brushes.LightBlue, x - r1 / 2, y - r1 / 2, r1, r1);
            //        g.FillEllipse(Brushes.White, x - r1 / 2, y - r1 / 2, r1, r1);

            //    }
            //}
        }



        int x0, y0, x1, y1, c2 = 0, c3 = 0, c4 = 0, c5 = 0;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (mouse == 2)
            {
                x0 = MousePosition.X - this.Location.X;
                y0 = MousePosition.Y - this.Location.Y;
                c2 = 1;
                p0.X = x0;
                p0.Y = y0;
            }
            if (mouse == 3)
            {
                x0 = MousePosition.X - this.Location.X;
                y0 = MousePosition.Y - this.Location.Y;
                c3 = 1;
            }
            if (mouse == 4)
            {
                r1 = trackBar1.Value;
                c4 = 1;
                g.DrawEllipse(Pens.White, MousePosition.X - this.Location.X - r1/2, MousePosition.Y - this.Location.Y - r1/2, r1, r1);
            }
            if (mouse == 5)
            {
                x0 = MousePosition.X - this.Location.X;
                y0 = MousePosition.Y - this.Location.Y;
                c5 = 1;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (mouse == 2)
            {
                x1 = MousePosition.X - this.Location.X;
                y1 = MousePosition.Y - this.Location.Y;
                c2 = 0;
                g.DrawLine(Pens.Black, x0, y0, x1, y1);
            }
            if(mouse==3)
            {
                c3 = 0;
            }
            if (mouse == 4)
            {
                g.FillEllipse(Brushes.White, MousePosition.X - this.Location.X - r1/2, MousePosition.Y - this.Location.Y - r1/2, r1, r1);
                c4 = 0;
            }
            if(mouse==5)
            {
                c5 = 0;
            }
        }
    }
}
