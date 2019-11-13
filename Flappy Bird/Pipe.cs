using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird
{
    class Pipe
    {
        int diff, l;
        int x, y;
        PictureBox[] line;
        PictureBox pipe1, pipe2;
       
        public void changeX()
        {
            x-=3;
            refresh();
        }
        public int getX()
        {
            return x;
        }
        public void setX(int a)
        {
            x = a;
            refresh();
        }
        public bool collide(PictureBox tmp)
        {
            if ((tmp.Location.X < x && (tmp.Location.X + tmp.Width-10) > x && (tmp.Location.Y+10 <= pipe1.Location.Y + pipe1.Height || tmp.Location.Y-10 >= pipe2.Location.Y)))
                return true;
            else
                return false;
        }
        void refresh()
        {
            line[0].Location = new System.Drawing.Point(x, 0);
            line[1].Location = new System.Drawing.Point(x, (l+diff));

        }
        public void add()
        {
            
            
            line[0] = pipe1;
            line[0].Height = getLenght();
            

            line[1] = pipe2;
            line[1].Height = y - line[0].Height - diff;

            refresh();
        }
        int  getLenght()
        {
            Random num = new Random();
            l = Convert.ToInt32(num.Next(100, 500));
            return l;
        }
        public void setLenght()
        {

            Random num = new Random();
            l = Convert.ToInt32(num.Next(100, 500));
            refresh();
        }
        public Pipe(PictureBox tmp1,PictureBox tmp2, int a, int b)
        {
            diff = 200;
            
            x = a;
            y = b;
            line = new PictureBox[2];
            pipe1 = tmp1;
            pipe2 = tmp2;
            add();
        }
    }
}
