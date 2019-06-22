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

        /// <summary>
        /// Сдвиг прямоугольника на указанные значения
        /// </summary>
        /// <param name="dx">сдвиг по горизонтали</param>
        /// <param name="dy">сдвиг по вертикали</param>
        public void Move(int dx, int dy)
        {
            x += dx;
            y += dy;
        }
        bool ValidPosition(int mw, int mh)
        {
            return x >= 0 && y >= 0 && x + w <= mw && y + h <= mh;
        }
        public void SafeMove(int dx, int dy, int mw, int mh)
        {
            Move(dx, dy);
            if (!ValidPosition(mw, mh))
                Move(-dx, -dy);
        }

        /// <summary>
        /// Есть ли пересечение двух прямоугольников
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        public bool CheckCross(myRectangle rect)
        {
            if(rect.x<=x&&x<=rect.x+rect.w)
            {
                if (rect.y <= y && y <= rect.y + rect.h)
                    return true;
                if (rect.y <= y+h && y+h <= rect.y + rect.h)
                    return true;
            }
            if (rect.x <= x+w && x+w <= rect.x + rect.w)
            {
                if (rect.y <= y && y <= rect.y + rect.h)
                    return true;
                if (rect.y <= y + h && y + h <= rect.y + rect.h)
                    return true;
            }

            if (x <= rect.x && rect.x <= x + w)
                if (y <= rect.y && rect.y <= y + h)
                    return true;

            return false;
        }

        /// <summary>
        /// Проверка на нахождеине точки в прямоугольники
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool IsIn(Point p)
        {
            return
                ((x <= p.X) && (p.X <= x + w)) &&
                ((y <= p.Y) && (p.Y <= y + h));
        }
        /// <summary>
        /// Рисование рпямоугольника на графике
        /// </summary>
        /// <param name="gr"></param>
        public void Draw(Graphics gr)
        {
            gr.FillRectangle(new SolidBrush(color), x, y, w, h);
            if (selected)
                gr.DrawRectangle(new Pen(selectColor, 2), x - 2, y - 2, w + 2, h + 2);
            else
                gr.DrawRectangle(new Pen(borderColor, 2), x, y, w, h);
        }

        /// <summary>
        /// Проверка является ли прямоугольник сосоедним
        /// </summary>
        /// <param name="mr2"></param>
        /// <returns></returns>

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

        /// <summary>
        /// Слияние двух прямоугольников в один
        /// </summary>
        /// <param name="mr1"></param>
        /// <param name="mr2"></param>
        /// <returns></returns>
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
                    color = mr1.color
                };
            }

            throw new ArgumentException("Произошла хуйня");

        }

        /// <summary>
        /// Оценка прямоугольника(фактически площадь)
        /// </summary>
        /// <returns></returns>
        public int getM()
        {
            return w * h;
        }

        /// <summary>
        /// В строку - чтобы смотреть значения в дебаге
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"x={x} y={y} w={w} h={h}";
        }

        /// <summary>
        /// Является ли аргумент частью этого прямоугольника
        /// </summary>
        /// <param name="mr">прямоугольник, который проверяем на вхождение в данный</param>
        /// <returns></returns>
        public bool isPart(myRectangle mr)
        {
            return mr.x >= this.x &&
                mr.y >= this.y &&
                mr.y + mr.h <= this.y + this.h &&
                mr.x + mr.w <= this.x + this.w;
        }
        public myRectangle Copy()
        {
            return new myRectangle()
            {
                x = this.x,
                y = this.y,
                w = this.w,
                h = this.h,
                color = this.color
            };
        }
    }
}
