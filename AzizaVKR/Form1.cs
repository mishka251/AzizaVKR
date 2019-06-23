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
            startRects = new List<MyRectangle>();
            borderRects = new List<MyRectangle>();
            resultRects = new List<MyRectangle>();
            rand = new Random();
        }
        /// <summary>
        /// Прямоугольники начального разбиения
        /// </summary>
        List<MyRectangle> startRects;

        List<MyRectangle> resultRects;
        /// <summary>
        /// Прямоугольники запретных областей
        /// </summary>
        List<MyRectangle> borderRects;
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
            foreach (MyRectangle mr in borderRects)
            {
                boredrrsX.Add(mr.X);
                boredrrsX.Add(mr.X + mr.Width);

                boredresY.Add(mr.Y);
                boredresY.Add(mr.Y + mr.Height);
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
            startRects = new List<MyRectangle>();
            for (int i = 0; i < boredrrsX.Count - 1; i++)
            {
                for (int j = 0; j < boredresY.Count - 1; j++)
                {
                    MyRectangle mr = new MyRectangle();
                    mr.X = boredrrsX[i];
                    mr.Y = boredresY[j];
                    mr.Width = boredrrsX[i + 1] - boredrrsX[i];
                    mr.Height = boredresY[j + 1] - boredresY[j];
                    mr.FillColor = getRandColor();




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
                    MyRectangle mri = resultRects[i];

                    Dictionary<double, List<MyRectangle>> nearests = new Dictionary<double, List<MyRectangle>>();

                    for (int j = 0; j < resultRects.Count; j++)
                        if (i != j && mri.isNearest(resultRects[j]))
                        {
                            double O = 0;
                            double h = (double)(pictureBox1.Height);
                            double lambda = (mri.Width + resultRects[j].Width) / h;
                            O = (mri.getM() + resultRects[j].getM()) / lambda;
                            if (!nearests.ContainsKey(O))
                                nearests.Add(O, new List<MyRectangle>());
                            nearests[O].Add(resultRects[j]);

                        }

                    if (nearests.Count > 0)
                    {
                        MyRectangle near = nearests.Last().Value.First();

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

            foreach (MyRectangle mr in startRects)
                mr.Draw(gr);
            foreach (MyRectangle mr in borderRects)
                mr.Draw(gr);


            pictureBox1.Image = bmp;




            Bitmap bmp2 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            Graphics gr2 = Graphics.FromImage(bmp2);

            foreach (MyRectangle mr in resultRects)
                mr.Draw(gr2);

            foreach (MyRectangle mr in borderRects)
                mr.Draw(gr2);


            pictureBox2.Image = bmp2;
        }

        /// <summary>
        /// Проверка пересечения - все ли прямоугольники не пересекаются друг с другому
        /// true - если ошибка, кто-то с кем-то пересекся
        /// false - всё ок
        /// </summary>
        /// <returns></returns>
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
        MyRectangle dragged = null;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            stX = e.X;
            stY = e.Y;

            foreach (var borRect in borderRects)
            {
                borRect.Selected = false;
            }


            draggedRect = borderRects.Any(bord => bord.IsIn(e.Location));
            if (draggedRect)
            {
                dragged = borderRects.Find(bord => bord.IsIn(e.Location));
                dragged.Selected = true;
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



            if (!borderRects.Any(bord => bord.Selected))
            {
                return;
            }

            var selectedRect = borderRects.Find(bord => bord.Selected);

            if (e.KeyData == Keys.Delete)
            {
                borderRects.Remove(selectedRect);
            }

            if (e.KeyData == Keys.Up)
            {
                selectedRect.SafeMove(0, -10, mw, mh);
                if (checkRectCross())
                {
                    selectedRect.SafeMove(0, 10, mw, mh);
                }
            }

            if (e.KeyData == Keys.Down)
            {
                selectedRect.SafeMove(0, 10, mw, mh);
                if (checkRectCross())
                {
                    selectedRect.SafeMove(0, 10, mw, mh);
                }

            }

            if (e.KeyData == Keys.Left)
            {
                selectedRect.SafeMove(-10, 0, mw, mh);
                if (checkRectCross())
                {
                    selectedRect.SafeMove(0, 10, mw, mh);
                }

            }

            if (e.KeyData == Keys.Right)
            {
                selectedRect.SafeMove(10, 0, mw, mh);
                if (checkRectCross())
                {
                    selectedRect.SafeMove(0, 10, mw, mh);
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
            button4.Top = (h - btnH) / 2;

            label1.Top = (h - btnH) / 2;
            label2.Top = (h - btnH) / 2;
            nuW.Top = (h - btnH) / 2;
            nuH.Top = (h - btnH) / 2;

            button1.Height = btnH;
            button2.Height = btnH;
            button3.Height = btnH;
            button4.Height = btnH;


            label1.Height = btnH;
            label2.Height = btnH;
            nuW.Height = btnH;
            nuH.Height = btnH;





            nuH.Value = pictureBox1.Height;
            nuW.Value = pictureBox1.Width;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            resizeElements();
            toolTip1.SetToolTip(pictureBox2, "Rectangle");
            toolTip1.ShowAlways = true;
            nuW.Value = pictureBox1.Width;
            nuH.Value = pictureBox1.Height;

            nuW.Maximum = SystemInformation.PrimaryMonitorSize.Width - (this.Width-this.ClientSize.Width);
            nuH.Maximum = (SystemInformation.PrimaryMonitorSize.Height-(this.Height-this.ClientSize.Height))/2;

        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (borderRects.Any(bord => bord.IsIn(e.Location)))
            {
                MyRectangle clicked = borderRects.Find(rect => rect.IsIn(e.Location));
                InputRect inputRect = new InputRect(pictureBox1.Width, pictureBox1.Height,
                    clicked.X, clicked.Y,
                    clicked.Width, clicked.Height);
                if (inputRect.ShowDialog() == DialogResult.OK)
                {
                    clicked.X = inputRect.x;
                    clicked.Y = inputRect.y;
                    clicked.Width = inputRect.w;
                    clicked.Height = inputRect.h;
                }
            }

            ShowPic();

        }

        private void button4_Click(object sender, EventArgs e)
        {

            InputRect inputRect = new InputRect(pictureBox1.Width, pictureBox1.Height);
            if (inputRect.ShowDialog() == DialogResult.OK)
            {
                MyRectangle newRect = new MyRectangle
                {
                    X = inputRect.x,
                    Y = inputRect.y,
                    Width = inputRect.w,
                    Height = inputRect.h,
                    FillColor = Color.Black
                };

                borderRects.Add(newRect);

                if (checkRectCross())
                {
                    MessageBox.Show("Пересечение!");
                    borderRects.Remove(newRect);
                }

            }
            ShowPic();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (resultRects.Any(rect => rect.IsIn(e.Location)))
            {
                MyRectangle rect = resultRects.Find(rect1 => rect1.IsIn(e.Location));
                toolTip1.ToolTipTitle = "result rect " + rect.ToString();
                toolTip1.Tag = rect;
            }

            if (borderRects.Any(rect => rect.IsIn(e.Location)))
            {
                MyRectangle rect = borderRects.Find(rect1 => rect1.IsIn(e.Location));
                toolTip1.ToolTipTitle = "border rect " + rect.ToString();
                toolTip1.Tag = rect;
            }

        }

        private void nuW_ValueChanged(object sender, EventArgs e)
        {
            int dw = pictureBox1.Width - (int)nuW.Value;       

            this.Width-=dw;

            
        }

        private void nuH_ValueChanged(object sender, EventArgs e)
        {
            int dh = pictureBox1.Height - (int)nuH.Value;

            this.Height -= 2*dh;
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

            int x = Math.Max(0, myRound(Math.Min(e.X, stX)));
            int y = Math.Max(0, myRound(Math.Min(e.Y, stY)));
            MyRectangle mr = new MyRectangle
            {
                X = x,
                Y = y,
                Width = Math.Min(pictureBox1.Width - x, myRound(Math.Abs(stX - e.X))),
                Height = Math.Min(pictureBox1.Height - y, myRound(Math.Abs(stY - e.Y))),
                FillColor = Color.Black
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
