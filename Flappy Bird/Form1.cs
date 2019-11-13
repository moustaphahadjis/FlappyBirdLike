using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird
{
    public partial class Form1 : Form
    {
        int x, y, s;
        int score;
        Pipe  pipe1, pipe2;
        
        bool pressed;
        public Form1()
        {
            InitializeComponent();
            y = this.Height / 2;
            s = pictureBox1.Height;
            x = 100;

            createPipes();
            
        }
        void createPipes()
        {
            pipe1 = new Pipe(pictureBox2, pictureBox3, this.Width, this.Height);
            pipe2 = new Pipe(pictureBox4, pictureBox5, this.Width + 160, this.Height);

        }
        private void gravity_Tick(object sender, EventArgs e)
        {
            if (y < this.Height)
                y += 3;
            label2.Text = Convert.ToString(score);
            if (pipe1.collide(pictureBox1) || pipe2.collide(pictureBox1) || pictureBox1.Location.X>this.Height)
            {
                
                jump.Stop();
                pipeFlow.Stop();
                gravity.Stop();
                show_menu();
                
            }
            refresh();
        }


        private void jump_Tick(object sender, EventArgs e)
        {
            //gravity.Stop();
            if (pressed)
            {
                if (y >= 0)
                    y -= 20;
                else
                    y = 0;

                refresh();
            }


        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
        
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
               pressed = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                pressed = true;
            }
        }
        
        
        private void pipeFlow_Tick(object sender, EventArgs e)
        {
            pipe1.changeX();
            pipe2.changeX();
            if (pipe1.getX() <= (-60))
            {
                pipe1 = new Pipe(pictureBox2, pictureBox3, pipe2.getX() + this.Width-120, this.Height);
                score++;
            }
            if (pipe2.getX() <= (-60))
            {
                 pipe2 = new Pipe(pictureBox4, pictureBox5, pipe1.getX() + this.Width-120, this.Height);
                score++;
            }
        }

        
        void refresh()
        {
            pictureBox1.Location = new System.Drawing.Point(x, y);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            start();
            //hide_menu();
            Form1 form = new Form1();
            form.Show();
            
        }
        
        public void start()
        {
            createPipes();
            jump.Start();
            gravity.Start();
            
            pipeFlow.Start();
            x = 100;
            y = this.Height / 2;
            pictureBox1.Location = new System.Drawing.Point(x, y);
            score = 0;
        }
        
        void hide_menu()
        {
            pictureBox6.Visible = false;
            pictureBox6.Enabled = false;

            button1.Visible = false;
            button1.Enabled = false;

            button2.Visible = false;
            button2.Enabled = false;

        }
        void show_menu()
        {
            pictureBox6.Visible = true;
            pictureBox6.Enabled = true;

            button1.Visible = true;
            button1.Enabled = true;
            
            button2.Visible = true;
            button2.Enabled = true;
            
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            hide_menu();
        }
    }
}
