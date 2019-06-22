using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzizaVKR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            startRects = new List<myRectangle>();
            borderRects = new List<myRectangle>();
            resultRects = new List<myRectangle>();
            rand = new Random();
        }
        /// <summary>
        /// Прямоугольники начального разбиения
        /// </summary>
        List<myRectangle> startRects;

        List<myRectangle> resultRects;
        /// <summary>
        /// Прямоугольники запретных областей
        /// </summary>
        List<myRectangle> borderRects;
        /// <summary>
        /// Рандом для случ. цвета
        /// </summary>
        Random rand;
        /// <summary>
        /// Границы прямоугольников по иксу
        /// </summary>
        List<int> boredrrsX;
        /// <summary>
        /// Границы прямоугольников по игреку
        /// </summary>
        List<int> boredresY;

        /// <summary>
        /// Вычисляем границы "запретных" прямоугольников
        /// </summary>
        void getBordersXY()
        {
            boredrrsX = new List<int>();
            boredresY = new List<int>();
            foreach (myRectangle mr in borderRects)
            {
                boredrrsX.Add(mr.x);
                boredrrsX.Add(mr.x + mr.w);

                boredresY.Add(mr.y);
                boredresY.Add(mr.y + mr.h);
            }

            boredrrsX.Add(0);//x picturebox boreders
            boredrrsX.Add(pictureBox1.Width);

            boredresY.Add(0);//y picturebox borders
            boredresY.Add(pictureBox1.Height);

            boredrrsX = boredrrsX.Distinct().ToList();//delete duplicates
            boredresY = boredresY.Distinct().ToList();

            boredrrsX.Sort();//sort
            boredresY.Sort();
        }
        /// <summary>
        /// Случайный цвет
        /// </summary>
        /// <returns></returns>
        Color getRandColor()
        {
            Color col = Color.FromArgb(

                40 + rand.Next(215),
                50 + rand.Next(205),
                60 + rand.Next(195)
            );

            return col;

        }
        /// <summary>
        /// Находим все прямоугольники, на которые запретные разбивают экран
        /// </summary>
        void getAllRectangles()
        {
            startRects = new List<myRectangle>();
            for (int i = 0; i < boredrrsX.Count - 1; i++)
            {
                for (int j = 0; j < boredresY.Count - 1; j++)
                {
                    myRectangle mr = new myRectangle();
                    mr.x = boredrrsX[i];
                    mr.y = boredresY[j];
                    mr.w = boredrrsX[i + 1] - boredrrsX[i];
                    mr.h = boredresY[j + 1] - boredresY[j];
                    mr.color = getRandColor();




                    if (!borderRects.Any(border => border.isPart(mr)))
                        startRects.Add(mr);
                }
            }
        }

        /// <summary>
        /// Слияние прямоугольников в нужное
        /// </summary>
        void calcRectangles()
        {
            bool has_changes = true;
            // double h = (double)pictureBox1.Width;

            resultRects.Clear();
            foreach (var rect in startRects)
            {
                resultRects.Add(rect.Copy());
            }

            while (has_changes)
            {
                has_changes = false;
                resultRects.Sort((mr1, mr2) => mr1.getM() > mr2.getM() ? -1 : mr1.getM() == mr2.getM() ? 0 : 1);

                for (int i = 0; i < resultRects.Count - 1; i++)
                {
                    myRectangle mri = resultRects[i];

                    Dictionary<double, List<myRectangle>> nearests = new Dictionary<double, List<myRectangle>>();

                    for (int j = 0; j < resultRects.Count; j++)
                        if (i != j && mri.isNearest(resultRects[j]))
                        {
                            double O = 0;
                            double h = (double)(pictureBox1.Height);
                            double lambda = (mri.w + resultRects[j].w) / h;
                            O = (mri.getM() + resultRects[j].getM()) / lambda;
                            if (!nearests.ContainsKey(O))
                                nearests.Add(O, new List<myRectangle>());
                            nearests[O].Add(resultRects[j]);

                        }

                    if (nearests.Count > 0)
                    {
                        myRectangle near = nearests.Last().Value.First();

                        resultRects[i] += near;
                        resultRects.Remove(near);
                        has_changes = true;
                        i--;
                    }


                }

            }

        }




        /// <summary>
        /// Отрисовка
        /// </summary>
        void ShowPic()
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics gr = Graphics.FromImage(bmp);

            foreach (myRectangle mr in startRects)
                mr.Draw(gr);
            foreach (myRectangle mr in borderRects)
                mr.Draw(gr);


            pictureBox1.Image = bmp;




            Bitmap bmp2 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            Graphics gr2 = Graphics.FromImage(bmp2);

            foreach (myRectangle mr in resultRects)
                mr.Draw(gr2);

            foreach (myRectangle mr in borderRects)
                mr.Draw(gr2);


            pictureBox2.Image = bmp2;
        }


        bool checkRectCross()
        {
            return borderRects.Any(
                bordRect
                => borderRects.Any(
                    bordRect2
                    => bordRect != bordRect2
                    && bordRect.CheckCross(bordRect2)));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkRectCross())
            {
                MessageBox.Show("Пересечение границ");
                return;
            }


            getBordersXY();
            getAllRectangles();
            calcRectangles();
            ShowPic();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            startRects.Clear();
            borderRects.Clear();
            resultRects.Clear();
            ShowPic();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            startRects.Clear();
            resultRects.Clear();
            ShowPic();
        }














        int stX, stY;
        bool draggedRect = false;
        myRectangle dragged = null;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            stX = e.X;
            stY = e.Y;

            foreach (var borRect in borderRects)
            {
                borRect.selected = false;
            }


            draggedRect = borderRects.Any(bord => bord.IsIn(e.Location));
            if (draggedRect)
            {
                dragged = borderRects.Find(bord => bord.IsIn(e.Location));
                dragged.selected = true;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (borderRects.Any(bord => bord.IsIn(e.Location)))
            {
                Cursor = Cursors.SizeAll;
            }
            else
            {
                Cursor = Cursors.Default;
            }

            if (!draggedRect)
                return;


            int mw = pictureBox1.Width;
            int mh = pictureBox1.Height;

            dragged.SafeMove(e.X - stX, e.Y - stY, mw, mh);

            if (checkRectCross())
            {
                dragged.SafeMove(-e.X + stX, -e.Y + stY, mw, mh);
            }
            else
            {
                stX = e.X;
                stY = e.Y;
            }


            ShowPic();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

            int mw = pictureBox1.Width;
            int mh = pictureBox1.Height;


            if (e.KeyData == Keys.Delete)
            {
                if (borderRects.Any(bord => bord.selected))
                {
                    borderRects.Remove(borderRects.Find(bord => bord.selected));
                }
            }

            if (e.KeyData == Keys.Up)
            {
                if (borderRects.Any(bord => bord.selected))
                {
                    borderRects.Find(bord => bord.selected).SafeMove(0, -10, mw, mh);
                }
            }

            if (e.KeyData == Keys.Down)
            {
                if (borderRects.Any(bord => bord.selected))
                {
                    borderRects.Find(bord => bord.selected).SafeMove(0, 10, mw, mh);
                }
            }

            if (e.KeyData == Keys.Left)
            {
                if (borderRects.Any(bord => bord.selected))
                {
                    borderRects.Find(bord => bord.selected).SafeMove(-10, 0, mw, mh);
                }
            }

            if (e.KeyData == Keys.Right)
            {
                if (borderRects.Any(bord => bord.selected))
                {
                    borderRects.Find(bord => bord.selected).SafeMove(10, 0, mw, mh);
                }
            }

            ShowPic();


        }

        int myRound(int num)
        {
            return 10 * (int)Math.Round(num / 10.0);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            resizeElements();
            getBordersXY();
            getAllRectangles();
            calcRectangles();
            ShowPic();
            ShowPic();
        }

        void resizeElements()
        {

            int btnH = 40;
            int padd = 10;
            int h = this.ClientSize.Height;
            int w = this.ClientSize.Width;

            pictureBox1.Left = 0;
            pictureBox1.Width = w;
            pictureBox1.Top = 0;
            pictureBox1.Height = (h - btnH) / 2 - 2 * padd;

            pictureBox2.Left = 0;
            pictureBox2.Width = w;
            pictureBox2.Top = (h + btnH) / 2 + 2 * padd;
            pictureBox2.Height = (h - btnH) / 2 - 2 * padd;

            button1.Top = (h - btnH) / 2;
            button2.Top = (h - btnH) / 2;
            button3.Top = (h - btnH) / 2;


            button1.Height = btnH;
            button2.Height = btnH;
            button3.Height = btnH;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            resizeElements();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

            if (draggedRect)
            {
                draggedRect = false;
                dragged = null;
            }

            ShowPic();
            if (Math.Abs(stX - e.X) < 20 || Math.Abs(stY - e.Y) < 10)
                return;

            myRectangle mr = new myRectangle
            {
                x = myRound(Math.Min(e.X, stX)),
                y = myRound(Math.Min(e.Y, stY)),
                w = myRound(Math.Abs(stX - e.X)),
                h = myRound(Math.Abs(stY - e.Y)),
                color = Color.Black
            };
            borderRects.Add(mr);
            if (checkRectCross())
            {
                MessageBox.Show("Пересечение границ");
                borderRects.Remove(mr);
            }
            ShowPic();
        }

    }
}
