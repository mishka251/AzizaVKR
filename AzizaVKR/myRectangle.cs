using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace AzizaVKR
{
    /// <summary>
    /// Класс прямоугольника
    /// Описывает прямоугольник на плоскости с координатами левого верхнего угла
    /// И размерами - высотой и шириной
    /// Может рисоваться определенным цветом и рамкой в зависимости от выбранности
    /// </summary>
    class MyRectangle
    {
        /// <summary>
        /// Координата Х левого верхнего угла
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Координата У левого верхнего угла
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// Ширина прямоугольника
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// Высота прямоугольника
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Цвет заливки прямоугольника
        /// </summary>
        public Color FillColor { get; set; }
        /// <summary>
        /// Цвет границы выделенного прямоугольника
        /// </summary>
        public static Color SelectBorderColor = Color.Violet;
        /// <summary>
        /// Цвет границы не выделенного прямоугольника
        /// </summary>
        public static Color BorderColor = Color.Black;
        /// <summary>
        /// Выбран ли прямоугольник
        /// </summary>
        public bool Selected { get; set; }

        /// <summary>
        /// Сдвиг прямоугольника на указанные значения
        /// </summary>
        /// <param name="dx">сдвиг по горизонтали</param>
        /// <param name="dy">сдвиг по вертикали</param>
        public void Move(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }
        /// <summary>
        /// Проверка на возможность нахождение в данной позиции
        /// Вернет true если норм
        /// false - если выход за границы
        /// </summary>
        /// <param name="mw">ширина, за которую нельзя выйти</param>
        /// <param name="mh">высота, за которую нельзя выйти</param>
        /// <returns></returns>
        bool ValidPosition(int mw, int mh)
        {
            return X >= 0 && Y >= 0 && X + Width <= mw && Y + Height <= mh;
        }
        /// <summary>
        /// Безопасное движение - с проверкой на границы
        /// </summary>
        /// <param name="dx">на сколько двигаем по иксу</param>
        /// <param name="dy">на сколько двигаем по игреку</param>
        /// <param name="mw">граница по ширине</param>
        /// <param name="mh">граница по игреку</param>
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
        public bool CheckCross(MyRectangle rect)
        {
            if (rect.X <= X && X <= rect.X + rect.Width)
            {
                if (rect.Y <= Y && Y <= rect.Y + rect.Height)
                    return true;
                if (rect.Y <= Y + Height && Y + Height <= rect.Y + rect.Height)
                    return true;
            }
            if (rect.X <= X + Width && X + Width <= rect.X + rect.Width)
            {
                if (rect.Y <= Y && Y <= rect.Y + rect.Height)
                    return true;
                if (rect.Y <= Y + Height && Y + Height <= rect.Y + rect.Height)
                    return true;
            }

            if (X <= rect.X && rect.X <= X + Width)
                if (Y <= rect.Y && rect.Y <= Y + Height)
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
                ((X <= p.X) && (p.X <= X + Width)) &&
                ((Y <= p.Y) && (p.Y <= Y + Height));
        }
        /// <summary>
        /// Рисование рпямоугольника на графике
        /// </summary>
        /// <param name="gr"></param>
        public void Draw(Graphics gr)
        {
            gr.FillRectangle(new SolidBrush(FillColor), X, Y, Width, Height);
            if (Selected)
                gr.DrawRectangle(new Pen(SelectBorderColor, 2), X - 2, Y - 2, Width + 2, Height + 2);
            else
                gr.DrawRectangle(new Pen(BorderColor, 2), X, Y, Width, Height);
        }

        /// <summary>
        /// Проверка является ли прямоугольник сосоедним
        /// </summary>
        /// <param name="mr2"></param>
        /// <returns></returns>

        public bool isNearest(MyRectangle mr2)
        {

            if (this.X == mr2.X && this.Width == mr2.Width)
            {
                if (this.Y == mr2.Y + mr2.Height || this.Y + this.Height == mr2.Y)
                    return true;
                else
                    return false;
            }

            if (this.Y == mr2.Y && this.Height == mr2.Height)
            {
                if (this.X == mr2.X + mr2.Width || this.X + this.Width == mr2.X)
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
        public static MyRectangle operator +(MyRectangle mr1, MyRectangle mr2)
        {
            if (!mr1.isNearest(mr2))
                throw new ArgumentException("Не соседи");

            if (mr1.X == mr2.X && mr1.Width == mr2.Width)
            {
                return new MyRectangle()
                {
                    X = mr1.X,
                    Width = mr1.Width,
                    Y = Math.Min(mr2.Y, mr1.Y),
                    Height = mr1.Height + mr2.Height,
                    FillColor = mr1.FillColor
                };
            }

            if (mr1.Y == mr2.Y && mr1.Height == mr2.Height)
            {
                return new MyRectangle()
                {
                    X = Math.Min(mr2.X, mr1.X),
                    Width = mr1.Width + mr2.Width,
                    Y = mr1.Y,
                    Height = mr1.Height,
                    FillColor = mr1.FillColor
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
            return Width * Height;
        }

        /// <summary>
        /// В строку - чтобы смотреть значения в дебаге
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"x={X} y={Y} w={Width} h={Height}";
        }

        /// <summary>
        /// Является ли аргумент частью этого прямоугольника
        /// </summary>
        /// <param name="mr">прямоугольник, который проверяем на вхождение в данный</param>
        /// <returns></returns>
        public bool isPart(MyRectangle mr)
        {
            return mr.X >= this.X &&
                mr.Y >= this.Y &&
                mr.Y + mr.Height <= this.Y + this.Height &&
                mr.X + mr.Width <= this.X + this.Width;
        }
        /// <summary>
        /// Возвращает копию текущего прямоугольника
        /// </summary>
        /// <returns></returns>
        public MyRectangle Copy()
        {
            return new MyRectangle()
            {
                X = this.X,
                Y = this.Y,
                Width = this.Width,
                Height = this.Height,
                FillColor = this.FillColor
            };
        }
    }
}
