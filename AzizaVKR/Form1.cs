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
            finalRects = new List<myRectangle>();
            borderRects = new List<myRectangle>();
            rand = new Random();
        }
        /// <summary>
        /// Прямоугольники разбиения
        /// </summary>
        List<myRectangle> finalRects;
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
            finalRects = new List<myRectangle>();
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
                        finalRects.Add(mr);
                }
            }
        }

        /// <summary>
        /// Слияние прямоугольников в нужное
        /// </summary>
        void calcRectangles()
        {
            bool has_changes = true;
            double h = (double)pictureBox1.Width;
            while (has_changes)
            {
                has_changes = false;
                finalRects.Sort((mr1, mr2) => mr1.getM() > mr2.getM() ? -1 : mr1.getM() == mr2.getM() ? 0 : 1);

                for (int i = 0; i < finalRects.Count - 1; i++)
                {
                    myRectangle mri = finalRects[i];

                    Dictionary<double, List<myRectangle>> nearests = new Dictionary<double, List<myRectangle>>();

                    for (int j = 0; j < finalRects.Count; j++)
                        if (i != j && mri.isNearest(finalRects[j]))
                        {
                            double O = 0;
                            double lambda = (mri.w + finalRects[j].w) / h;
                            O = (mri.getM() + finalRects[j].getM()) / lambda;
                            if (!nearests.ContainsKey(O))
                                nearests.Add(O, new List<myRectangle>());
                            nearests[O].Add(finalRects[j]);

                        }

                    if (nearests.Count > 0)
                    {
                        myRectangle near = nearests.Last().Value.First();

                        finalRects[i] += near;
                        finalRects.Remove(near);
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


            foreach (myRectangle mr in finalRects)
                mr.Draw(gr);

            foreach (myRectangle mr in borderRects)
                mr.Draw(gr);



            pictureBox1.Image = bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getBordersXY();
            getAllRectangles();
            calcRectangles();
            ShowPic();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            finalRects.Clear();
            borderRects.Clear();
            ShowPic();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            finalRects.Clear();
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
            dragged.Move(e.X - stX, e.Y - stY);
            stX = e.X;
            stY = e.Y;
            ShowPic();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
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
                    borderRects.Find(bord => bord.selected).Move(0, -10);
                }
            }

            if (e.KeyData == Keys.Down)
            {
                if (borderRects.Any(bord => bord.selected))
                {
                    borderRects.Find(bord => bord.selected).Move(0, 10);
                }
            }

            if (e.KeyData == Keys.Left)
            {
                if (borderRects.Any(bord => bord.selected))
                {
                    borderRects.Find(bord => bord.selected).Move(-10, 0);
                }
            }

            if (e.KeyData == Keys.Right)
            {
                if (borderRects.Any(bord => bord.selected))
                {
                    borderRects.Find(bord => bord.selected).Move(10, 0);
                }
            }

            ShowPic();


        }

        int myRound(int num)
        {
            return 10 * (int)Math.Round(num / 10.0);
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
                y = myRound(Math.Min(e.Y, stY) ),
                w = myRound(Math.Abs(stX - e.X)),
                h = myRound(Math.Abs(stY - e.Y)),
                color = Color.Black
            };
            borderRects.Add(mr);
            ShowPic();
        }

    }
}
