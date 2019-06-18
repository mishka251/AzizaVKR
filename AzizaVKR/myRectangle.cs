using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace AzizaVKR
{
    class myRectangle
    {
        public int x;
        public int y;
        public int w;
        public int h;

        public Color color;
        public static Color selectColor = Color.Violet;
        public static Color borderColor = Color.Black;
        public bool selected;

        public void Move(int dx, int dy)
        {
            x += dx;
            y += dy;
        }

        public bool IsIn(Point p)
        {
            return
                ((x <= p.X) && (p.X <= x + w)) &&
                ((y <= p.Y) && (p.Y <= y + h));
        }

        public void Draw(Graphics gr)
        {
            gr.FillRectangle(new SolidBrush(color), x, y, w, h);
            if (selected)
                gr.DrawRectangle(new Pen(selectColor, 2), x -2, y - 2, w + 2, h + 2);
            else
                gr.DrawRectangle(new Pen(borderColor, 2), x, y , w , h );
        }

        public bool isNearest(myRectangle mr2)
        {

            if (this.x == mr2.x && this.w == mr2.w)
            {
                if (this.y == mr2.y + mr2.h || this.y + this.h == mr2.y)
                    return true;
                else
                    return false;
            }

            if (this.y == mr2.y && this.h == mr2.h)
            {
                if (this.x == mr2.x + mr2.w || this.x + this.w == mr2.x)
                    return true;
                else
                    return false;
            }
            return false;

        }
        //public static bool operator ==(myRectangle mr1, myRectangle mr2)
        //{
        //    return
        //        Math.Abs(mr1.x - mr2.x) < 2 &&
        //        Math.Abs(mr1.y - mr2.y) < 2 &&
        //        Math.Abs(mr1.w - mr2.w) < 2 &&
        //        Math.Abs(mr1.h - mr2.h) < 2;
        //}

        //public static bool operator !=(myRectangle mr1, myRectangle mr2)
        //{
        //    return !(
        //        Math.Abs(mr1.x - mr2.x) < 2 &&
        //        Math.Abs(mr1.y - mr2.y) < 2 &&
        //        Math.Abs(mr1.w - mr2.w) < 2 &&
        //        Math.Abs(mr1.h - mr2.h) < 2);
        //}

        public static myRectangle operator +(myRectangle mr1, myRectangle mr2)
        {
            if (!mr1.isNearest(mr2))
                throw new ArgumentException("Не соседи");

            if (mr1.x == mr2.x && mr1.w == mr2.w)
            {
                return new myRectangle()
                {
                    x = mr1.x,
                    w = mr1.w,
                    y = Math.Min(mr2.y, mr1.y),
                    h = mr1.h + mr2.h,
                    color = mr1.color
                };
            }

            if (mr1.y == mr2.y && mr1.h == mr2.h)
            {
                return new myRectangle()
                {
                    x = Math.Min(mr2.x, mr1.x),
                    w = mr1.w + mr2.w,
                    y = mr1.y,
                    h = mr1.h,
                    color=mr1.color
                };
            }

            throw new ArgumentException("Произошла хуйня");

        }

        public int getM()
        {
            return w * h;
        }


        public override string ToString()
        {
            return $"x={x} y={y} w={w} h={h}";
        }

        //public override bool Equals(object obj)
        //{
        //    if (!(obj is myRectangle))
        //        return false;
        //    myRectangle mr = (myRectangle)obj;

        //    return mr == this;
        //}

        public bool isPart(myRectangle mr)
        {
            return mr.x >= this.x &&
                mr.y >= this.y &&
                mr.y + mr.h <= this.y + this.h &&
                mr.x + mr.w <= this.x + this.w;
        }

    }
}
