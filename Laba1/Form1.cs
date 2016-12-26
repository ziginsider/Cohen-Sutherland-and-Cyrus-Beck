using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba1
{
    public partial class Form1 : Form
    {
        Graphics gPanel; //панель на которой будем рисовать фигуры
        Pen pen; //перо рисования
        Int32 X1, X2, X3, Y1, Y2, Y3; //координаты точек треугольника
        Int32 Xcentre, Ycentre; //координаты центра треугольника
        Int32 offsetx1, offsetx2, offsetx3, offsety1, offsety2, offsety3; //смещения координат при изменении масштаба
        int coef = 30; //коэффициент изменения масштаба
        int coef_const; //коеф неизменяемый
        int rmin, rmax, smin, smax; //диапазоны смещения при хаотическом движение
        int iter = 0;
        int ix, iy; //смещение при хаотическом движении

        //для алгоритма отсечения Сазерленла-Коуэна:
        //коды
        int CodeLeft = 1;   //0001
        int CodeRight = 2;  //0010
        int CodeButtom = 4; //0100
        int CodeTop = 8;    //1000

        //координаты (диагоналей) трёх прямоугольников, которые образуют наше окно сложной формы по варианту 6
        int left1 = 200, right1 = 400, bottom1 = 100, top1 = 500;
        int left2 = 400, right2 = 600, bottom2 = 100, top2 = 300;
        int left3 = 600, right3 = 800, bottom3 = 100, top3 = 500;



        Point3D P1, P2, P3, P4, P5, P6, P7, P8;

        //если меняем смещение оси X
        private void trackBar_Y_ValueChanged(object sender, EventArgs e)
        {
            //displacement_y = trackBar_Y.Value;
        }

        //если меняем смещение оси X
        private void trackBar_X_ValueChanged(object sender, EventArgs e)
        {
            //displacement_x = trackBar_X.Value;
        }

        //множество вершин в трехмерной системе
        List<Point3D> Prisma = new List<Point3D>();
        //угол вращения призмы
        double angle;

        //множество вершин в двумерной системе
        List<PointF> Projection = new List<PointF>();

        //смещения для осей для более раглядного представления лабы 6
        int displacement_x;
        int displacement_y;


        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox_rotate_CheckedChanged(object sender, EventArgs e)
        {
            angle = 0.0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //связываем панель рисования с виджетом на экране
            gPanel = panel_draw.CreateGraphics();


            //значения координат точек треугольника по-умолчанию
            numericUpDown_x1.Value = 100;
            numericUpDown_y1.Value = 300;

            numericUpDown_x2.Value = 900;
            numericUpDown_y2.Value = 400;

            numericUpDown_x3.Value = 400;
            numericUpDown_y3.Value = 250;

            //значения диапазона рандомных смещений фигуры (дельтаX и дельтаY принимаем за 1 т.е. одно деление шкалы панели рисования)
            numericUpDown_rmin.Value = -2;
            numericUpDown_rmax.Value = 2;
            numericUpDown_smin.Value = -2;
            numericUpDown_smax.Value = 2;

            numericUpDown_coef.Value = 30;

            checkBox_scale.Checked = true;

            //вращать призму?
            checkBox_rotate.Checked = true;

            //удалять невидимые рёбра?
            checkBox_segment.Checked = true;

            //рисовать оси?
            checkBox_axis.Checked = false;

            trackBar_speedanimate.Value = 5;

            timer_start.Interval = 250 / trackBar_speedanimate.Value;

            radioButton_l1.Checked = true;

            displacement_x = 300;
            displacement_y = 300;

            iter = 0;

            //задаем координаты вершин призмы в трёхмерной системе для лаб. 6

            P1 = new Point3D(250, 25, 10);
            P2 = new Point3D(30, 25, 10);
            P3 = new Point3D(30, 200, 10);
            P4 = new Point3D(250, 200, 10);
            P5 = new Point3D(250, 25, 550);
            P6 = new Point3D(30, 25, 550);
            P7 = new Point3D(30, 200, 550);
            P8 = new Point3D(250, 200, 550);

            //первоначальный угол вращения
            angle = 1.0;

            //множество вершин в трехмерной системе
            Prisma.Clear();
            Prisma.Add(P1);
            Prisma.Add(P2);
            Prisma.Add(P3);
            Prisma.Add(P4);
            Prisma.Add(P5);
            Prisma.Add(P6);
            Prisma.Add(P7);
            Prisma.Add(P8);

        }
        private void button_start_Click(object sender, EventArgs e)
        {
            //заносим первоначальные значения точек треугольника
            X1 = (int)numericUpDown_x1.Value;
            X2 = (int)numericUpDown_x2.Value;
            X3 = (int)numericUpDown_x3.Value;
            Y1 = (int)numericUpDown_y1.Value;
            Y2 = (int)numericUpDown_y2.Value;
            Y3 = (int)numericUpDown_y3.Value;

            //заносим диапазоны смщения хаотического движения фигуры
            rmin = (int)numericUpDown_rmin.Value;
            rmax = (int)numericUpDown_rmax.Value;
            smin = (int)numericUpDown_smin.Value;
            smax = (int)numericUpDown_smax.Value;

            //скорость анимации
            timer_start.Interval = 250 / trackBar_speedanimate.Value;

            //проверяем не перекрываются ли диапазоны
            if (rmin > rmax)
            {
                MessageBox.Show("Минимальное значение должно быть <= максимального", "Неправильный диапазон! (Пределы значений рандомного...)");
                return; //выходим
            }
            if (smin > smax)
            {
                MessageBox.Show("Минимальное значение должно быть <= максимального", "Неправильный диапазон! (Пределы значений рандомного...)");
                return;
            }


            //делаем неактивными элементы меню
            numericUpDown_x1.Enabled = false;
            numericUpDown_x2.Enabled = false;
            numericUpDown_x3.Enabled = false;
            numericUpDown_y1.Enabled = false;
            numericUpDown_y2.Enabled = false;
            numericUpDown_y3.Enabled = false;

            numericUpDown_rmax.Enabled = false;
            numericUpDown_rmin.Enabled = false;
            numericUpDown_smax.Enabled = false;
            numericUpDown_smin.Enabled = false;

            numericUpDown_coef.Enabled = false;
            checkBox_scale.Enabled = false;

            button_start.Enabled = false;

            checkBox_clear.Enabled = false;

            trackBar_pen.Enabled = false;

            trackBar_speedanimate.Enabled = false;

            button_stop.Enabled = true;

            gPanel.Clear(Color.White); //очищаем экран

            //настраиваем перо
            int penWidth = (int)trackBar_pen.Value;
            pen = new Pen(Color.Green, penWidth);

            //коэффициент уменьшения масштаба (каждый шаг на 1/coef меньше)
            coef = (int)numericUpDown_coef.Value;
            coef_const = coef;
            if (coef < 1) coef = 1;
            if (coef > 500) coef = 500;

            //анимация
            iter = 0;
            timer_start.Start(); //запускаем анимацию по таймеру

        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            timer_start.Stop(); //останавливаем анимацию

            //делаем активными элементы меню
            numericUpDown_x1.Enabled = true;
            numericUpDown_x2.Enabled = true;
            numericUpDown_x3.Enabled = true;
            numericUpDown_y1.Enabled = true;
            numericUpDown_y2.Enabled = true;
            numericUpDown_y3.Enabled = true;

            numericUpDown_rmax.Enabled = true;
            numericUpDown_rmin.Enabled = true;
            numericUpDown_smax.Enabled = true;
            numericUpDown_smin.Enabled = true;

            numericUpDown_coef.Enabled = true;
            checkBox_scale.Enabled = true;

            button_start.Enabled = true;

            trackBar_pen.Enabled = true;

            checkBox_clear.Enabled = true;

            trackBar_speedanimate.Enabled = true;

            button_stop.Enabled = false;
        }

        //рисуем линию
        private void DrawLine(int x1, int y1, int x2, int y2)
        {
            //т.к. координаты ординат панели перевернуты относительно человеческого восприятия - переворачиваем их
            //рисуем линию
            gPanel.DrawLine(pen, x1, panel_draw.Size.Height - y1, x2, panel_draw.Size.Height - y2);
        }

        //рисуем треугольник
        private void DrawTriange(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            DrawLine(x1, y1, x2, y2);
            DrawLine(x2, y2, x3, y3);
            DrawLine(x3, y3, x1, y1);
        }

        //рисуем прямоугольник по 4-м ограничениям
        private void DrawRectangle(int xmin, int xmax, int ymin, int ymax)
        {
            DrawLine(xmin, ymin, xmin, ymax);
            DrawLine(xmin, ymax, xmax, ymax);
            DrawLine(xmax, ymax, xmax, ymin);
            DrawLine(xmax, ymin, xmin, ymin);
        }




        //каждый шаг анимации:
        private void timer_start_Tick(object sender, EventArgs e)
        {
            if (iter == 4000) //предельное кол-во шагов
            {
                iter = 0;
                timer_start.Stop();
            }
            else
            {
                if (checkBox_clear.Checked == false)
                {
                    gPanel.Clear(Color.White); //очищаем экран
                }

                int penWidth = (int)trackBar_pen.Value;

                if (radioButton_l1.Checked == true)
                {
                    //Задание 1
                    //рисуем треугольник
                    pen = new Pen(Color.Blue, penWidth);
                    DrawTriange(X1, Y1, X2, Y2, X3, Y3);
                }

                if (radioButton_l2.Checked == true)
                {
                    //начинаем алгоритм Сазерленда-Коуэна:

                    //рисуем наше отсекающее окно состоящее из трёх прямоугольников (вариант f-6)

                    pen = new Pen(Color.Red, penWidth);

                    DrawRectangle(left1, right1, bottom1, top1);
                    DrawRectangle(left2, right2, bottom2, top2);
                    DrawRectangle(left3, right3, bottom3, top3);

                    //pen = new Pen(Color.Blue, penWidth);
                    //DrawLine(100, 300, 600, 400);

                    pen = new Pen(Color.Green, penWidth);

                    //отсечение отрезков треугольника методом Сазерленда-Коэна
                    Lauch_Suth(X1, Y1, X2, Y2);
                    Lauch_Suth(X3, Y3, X2, Y2);
                    Lauch_Suth(X1, Y1, X3, Y3);
                }
                if (radioButton_l3.Checked == true)
                {
                    //начинаем алгоритм отсечения Кируса-Бека 
                    //рисуем форму окна вариант b
                    pen = new Pen(Color.Black, penWidth);

                    PointF A1 = new PointF(400, 225);
                    PointF A2 = new PointF(450, 300);
                    PointF A3 = new PointF(400, 375);
                    PointF A4 = new PointF(500, 375);
                    PointF A5 = new PointF(550, 450);
                    PointF A6 = new PointF(600, 375);
                    PointF A7 = new PointF(700, 375);
                    PointF A8 = new PointF(650, 300);
                    PointF A9 = new PointF(700, 225);
                    PointF A10 = new PointF(600, 225);
                    PointF A11 = new PointF(550, 150);
                    PointF A12 = new PointF(500, 225);

                    DrawLinePointF(A1, A2);
                    DrawLinePointF(A2, A3);
                    DrawLinePointF(A3, A4);
                    DrawLinePointF(A4, A5);
                    DrawLinePointF(A5, A6);
                    DrawLinePointF(A6, A7);
                    DrawLinePointF(A7, A8);
                    DrawLinePointF(A8, A9);
                    DrawLinePointF(A9, A10);
                    DrawLinePointF(A10, A11);
                    DrawLinePointF(A11, A12);
                    DrawLinePointF(A12, A1);

                    //Polygon myPolygon = new Polygon(new List<PointF> { A1, A5, A9 });
                    //List<Segment> Result = new List<Segment>();
                    //PointF test1 = new PointF(420, 450);
                    //PointF test2 = new PointF(650, 150);
                    //Segment seg1 = new Segment(test1, test2);

                    //List<Segment> Test = new List<Segment>();
                    //Test.Add(seg1);

                    //Result = myPolygon.CyrusBeckClip(Test);

                    //DrawLinePointF(Result[0].A, Result[0].B);

                    pen = new Pen(Color.Crimson, penWidth); //настраиваем перо

                    //разбиваем наш невыпуклый многоульник на несколько выпуклых: 7 треугольников и один шестигранник
                    List<Polygon> convexPolygons = new List<Polygon> {
                        new Polygon (new List<PointF> { A1, A2, A12 }),
                        new Polygon (new List<PointF> { A2, A3, A4 }),
                        new Polygon (new List<PointF> { A4, A5, A6 }),
                        new Polygon (new List<PointF> { A6, A7, A8 }),
                        new Polygon (new List<PointF> { A10, A8, A9 }),
                        new Polygon (new List<PointF> { A12, A10, A11 }),
                        new Polygon (new List<PointF> { A12, A2, A4, A6, A8, A10})
                    };

                    //получаем три сегмента (три отрезка составляющие наш треугольник) которые нужно отсечь окном с исп. алг. Кируса-Бека
                    List<Segment> triangleSegments = new List<Segment>
                    {
                        GetSegmentFromLine(X1, Y1, X2, Y2),
                        GetSegmentFromLine(X2, Y2, X3, Y3),
                        GetSegmentFromLine(X1, Y1, X3, Y3)
                    };

                    List<Segment> result = new List<Segment>(); //результат отсечения: сегменты

                    //проходим по всем выпуклым многоугольникам составляющим наше окно и отсекаем отрезки составляющие треугольникв
                    foreach (Polygon polygon in convexPolygons) //для каждого выпуклого многоугольника
                    {
                        //для каждого отсекаемого отрезка 
                        //применяем алгоритм внутреннего отсечения окном Кируса-Бека
                        result = polygon.CyrusBeckClip(triangleSegments);

                        //рисуем отсеченные отрезки на экране
                        DrawSegments(result);

                        //обнуляем результат
                        result.Clear();

                    }


                }

                if (radioButton_l4.Checked == true)
                {
                    //строим изометрическую проекцию призмы с основанием прямоугольник - вар. 14
                    //задаем координаты вершин призмы в трёхмерной системе (задали при инициализации формы)

                    //Point3D P1 = new Point3D(350, 250, 100);
                    //Point3D P2 = new Point3D(200, 250, 100);
                    //Point3D P3 = new Point3D(200, 400, 100);
                    //Point3D P4 = new Point3D(350, 400, 100);
                    //Point3D P5 = new Point3D(350, 250, 550);
                    //Point3D P6 = new Point3D(200, 250, 550);
                    //Point3D P7 = new Point3D(200, 400, 550);
                    //Point3D P8 = new Point3D(350, 400, 550);

                    //задаем матрицу преобразования
                    // |0.71  0.41  0  |
                    // |0     0.82  0  |
                    // |0.71  -0.41 0  |

                    List<double> Matrix = new List<double> {
                        0.71, 0.41, 0,
                        0, 0.82, 0,
                        0.71, -0.41, 0
                    };


                    displacement_x = trackBar_X.Value;
                    displacement_y = trackBar_Y.Value;

                    if (checkBox_axis.Checked == true)
                    {
                        pen = new Pen(Color.Black, 1); //настраиваем перо
                                                       //рисуем координатные оси для наглядности
                        DrawLine(displacement_x, displacement_y, displacement_x, panel_draw.Size.Height - 20); //ось Х
                        DrawLine(displacement_x, displacement_y, panel_draw.Size.Width - 100, displacement_y); //Y
                        //DrawLine(displacement_x - 300, displacement_y - 300, displacement_x + 300, displacement_y + 300); //Z
                        string strX = "X", strY = "Y";
                        Font drawFont = new Font("Arial", 16);
                        SolidBrush drawBrush = new SolidBrush(Color.Black);
                        StringFormat drawFormat = new StringFormat();
                        gPanel.DrawString(strX, drawFont, drawBrush, (float)displacement_x - 30, 20.0F, drawFormat);
                        gPanel.DrawString(strY, drawFont, drawBrush, (float)(panel_draw.Size.Width - 100), (float)(panel_draw.Size.Height - displacement_y + 10), drawFormat);
                        drawFont.Dispose();
                        drawBrush.Dispose();
                    }


                    pen = new Pen(Color.DarkKhaki, penWidth); //настраиваем перо

                    if (checkBox_rotate.Checked == true) //вращаем призму вокруг Z
                    {

                        Projection = GetIsometricPointsWithRotation(Prisma, Matrix, angle);


                        angle = angle + 1.0;
                        if (angle > 360.0) angle = 0;
                    }
                    else
                    {
                        //множество вершин в двумерной системе
                        Projection = GetIsometricPoints(Prisma, Matrix);
                    }

                    if (checkBox_segment.Checked == true) //удаляем невидимые ребра, рисуем
                    {
                        DrawProjectionSegment(Projection);
                    }
                    else
                    {
                        DrawProjection(Projection); //выводим без удаления невидимых ребер
                    }

                }
                else
                {
                    //Хаотическое движение треугольника
                    if (iter % 10 == 0) //направление смещения меняется каждые 10 шагов
                    {
                        //получаем рандомное смещение от -2 до 2 (по условию) для следующего шага анимации
                        Random rndx = new Random();
                        ix = rndx.Next(rmin, (rmax + 1)); //смещение по оси абсцисс
                        System.Threading.Thread.Sleep(25);
                        Random rndy = new Random();
                        iy = rndy.Next(smin, (smax + 1)); //смещение по оси ординат
                    }

                    //меняем значения координат точек (смещаем треугольник) для следующего шага 
                    X1 += ix;
                    X2 += ix;
                    X3 += ix;
                    Y1 += iy;
                    Y2 += iy;
                    Y3 += iy;

                    if (checkBox_scale.Checked == true) //уменьшение масштаба
                    {
                        if (coef <= 0) coef = 1; //проверка допустимого коэф

                        //меняем масштаб меньше на 1/30 (или как настроим) треугольника для следующего шага
                        //находим координаты центра треугольника
                        double divisionx = (X1 + X2 + X3) / 3;
                        Xcentre = (int)Math.Ceiling(divisionx); //округляем до верхнего целочисленного
                        double divisiony = (Y1 + Y2 + Y3) / 3;
                        Ycentre = (int)Math.Ceiling(divisiony);

                        //MessageBox.Show(Xcentre.ToString());

                        //находим смещения координат для уменьшения масштаба
                        double j = (X1 - Xcentre) / coef;
                        offsetx1 = (int)Math.Round(j);
                        j = (X2 - Xcentre) / coef;
                        offsetx2 = (int)Math.Round(j);
                        j = (X3 - Xcentre) / coef;
                        offsetx3 = (int)Math.Round(j);
                        j = (Y1 - Ycentre) / coef;
                        offsety1 = (int)Math.Round(j);
                        j = (Y2 - Ycentre) / coef;
                        offsety2 = (int)Math.Round(j);
                        j = (Y3 - Ycentre) / coef;
                        offsety3 = (int)Math.Round(j);

                        //координаты треугольника с уменьшенным на 1/coef масштабом: 
                        X1 = X1 - offsetx1;
                        X2 = X2 - offsetx2;
                        X3 = X3 - offsetx3;
                        Y1 = Y1 - offsety1;
                        Y2 = Y2 - offsety2;
                        Y3 = Y3 - offsety3;

                        //если размерность кооэффициента мастабирования превышает масштаб фигуры, то уменьшаем коэф для дальнейшего уменьшения фигуры
                        if ((coef < iter) && (coef != 1))
                        {
                            coef = (int)coef / 2;
                            iter = 0;
                        }
                    }
                }

                iter += 1;
            }
        }

        //функция возвращает двоичный код Сазерленда-Коуэна типа xxxx
        //получает координаты точки x и y, и 4-ре ограничения окна отсечения left, right, bottom, top
        private int Code(int x, int y, int left, int right, int bottom, int top)
        {
            int c = 0; //0000
            if (x < left)
            {
                c = c | CodeLeft; // операция побитового ИЛИ
            }
            else if (x > right)
            {
                c = c | CodeRight;
            }
            if (y > top)
            {
                c = c | CodeTop;
            }
            else if (y < bottom)
            {
                c = c | CodeButtom;
            }
            return c;
        }

        //Функция алгоритма отсечения Сазерленда-Коуэна
        //Отсекает отрезок (x1,y1)(x2,y2) окном с ограничениями по сторонам left, right, bottom, top
        //coun - порядковый номер прохода т.к. у нас три окна
        private void CohenSutherland(int x1, int y1, int x2, int y2, int left, int right, int bottom, int top, int count)
        {
            int x1_const = x1, x2_const = x2, y1_const = y1, y2_const = y2; //запоминаем координаты концов отрезка
            bool flag1 = false; //случай, когда отрезок не пересекает окно
            bool flag2 = false; //случай, когда точка x1,y1 лежит в окне, а другая снаружи
            bool flag3 = false; //случай, когда точка x2,y2 лежит в окне, а другая снаружи
            bool flag4 = false; //случай, когда обе точки лежат в окне

            int C1 = Code(x1, y1, left, right, bottom, top), C2 = Code(x2, y2, left, right, bottom, top); //коды точек отсекаемого отрезка
            int C;
            int Px = 0, Py = 0;//  пересечения

            if ((C1 & C2) != 0) flag1 = true;
            if (C1 == 0 && C2 != 0) flag2 = true;
            if (C1 != 0 && C2 == 0) flag3 = true;
            if (!flag1 && !flag2 && !flag3) flag4 = true;

            while (C1 != 0 || C2 != 0)//?P1x,P1y?,?P2x,P2y??  //пока не находим точки пересечения
            {
                if ((C1 & C2) != 0)   // побитовое И  -отрезок не пересекает окно
                {
                    x1 = 0;
                    y1 = 0;
                    x2 = 0;
                    y2 = 0;
                    break;
                }
                C = C1;
                if (C1 == 0)//по крайней мере одна точка находится вне прямоугольника   
                {
                    C = C2;
                }

                //находим точку пересечения y = y0 + slope * (x - x0), x = x0 + (1 / slope) * (y - y0)
                if ((C & CodeLeft) != 0)
                {
                    Px = left; //точка слева от окна
                    Py = y1 + (int)(Convert.ToDouble(y2 - y1) / (x2 - x1) * (left - x1));
                }
                else if ((C & CodeRight) != 0)//   
                {
                    Px = right; //точка справа от окна
                    Py = y1 + (int)(Convert.ToDouble(y2 - y1) / (x2 - x1) * (right - x1));
                }
                else if ((C & CodeTop) != 0)//  
                {
                    Py = top; //точка выше окна
                    Px = x1 + (int)(Convert.ToDouble(x2 - x1) / (y2 - y1) * (top - y1));
                }
                else if ((C & CodeButtom) != 0)//  
                {
                    Py = bottom; //точка ниже окна
                    Px = x1 + (int)(Convert.ToDouble(x2 - x1) / (y2 - y1) * (bottom - y1));
                }

                if (C == C1) //находим точки пересечения с продолжением и готовимся к следующему проходу  
                {
                    x1 = Px;
                    y1 = Py;
                    C1 = Code(x1, y1, left, right, bottom, top);
                }
                else
                {
                    x2 = Px;
                    y2 = Py;
                    C2 = Code(x2, y2, left, right, bottom, top);
                }
            }

            //DrawLine(x1, y1, x2, y2);
            if (flag1)
            {
                if (count == 1)
                {
                    //проверяем для второго окна
                    CohenSutherland(x1_const, y1_const, x2_const, y2_const, left2, right2, bottom2, top2, 2);
                }
                if (count == 2)
                {
                    //проверяем для третьего окна
                    CohenSutherland(x1_const, y1_const, x2_const, y2_const, left3, right3, bottom3, top3, 3);
                }
                if (count == 3) DrawLine(x1_const, y1_const, x2_const, y2_const);
            }
            if (flag2)
            {
                if (count == 1)
                {
                    CohenSutherland(x2, y2, x2_const, y2_const, left2, right2, bottom2, top2, 2);
                }
                if (count == 2)
                {
                    CohenSutherland(x2, y2, x2_const, y2_const, left3, right3, bottom3, top3, 3);
                }
                if (count == 3) DrawLine(x2, y2, x2_const, y2_const);
            }
            if (flag3)
            {
                if (count == 1)
                {
                    CohenSutherland(x1_const, y1_const, x1, y1, left2, right2, bottom2, top2, 2);
                }
                if (count == 2)
                {
                    CohenSutherland(x1_const, y1_const, x1, y1, left3, right3, bottom3, top3, 3);
                }
                if (count == 3) DrawLine(x1_const, y1_const, x1, y1);
            }
            if (flag4)
            {
                if (count == 1)
                {
                    CohenSutherland(x1_const, y1_const, x1, y1, left2, right2, bottom2, top2, 2);
                    CohenSutherland(x2, y2, x2_const, y2_const, left2, right2, bottom2, top2, 2);
                }
                if (count == 2)
                {
                    CohenSutherland(x1_const, y1_const, x1, y1, left3, right3, bottom3, top3, 3);
                    CohenSutherland(x2, y2, x2_const, y2_const, left3, right3, bottom3, top3, 3);
                }
                if (count == 3)
                {
                    DrawLine(x1_const, y1_const, x1, y1);
                    DrawLine(x2, y2, x2_const, y2_const);
                }
            }
        }

        void Lauch_Suth(int x1, int y1, int x2, int y2)
        {
            CohenSutherland(x1, y1, x2, y2, left1, right1, bottom1, top1, 1);
        }

        //алгоритм Кируса-Бека вспомогательные функции
        private void DrawLinePointF(PointF A, PointF B)
        {
            int x1 = (int)Math.Round(A.X);
            int x2 = (int)Math.Round(B.X);
            int y1 = (int)Math.Round(A.Y);
            int y2 = (int)Math.Round(B.Y);
            DrawLine(x1, y1, x2, y2);
        }

        //возвращаем Segment по полученным целочисленным координатам отрезка
        private Segment GetSegmentFromLine(int x1, int y1, int x2, int y2)
        {
            PointF p1 = new PointF((float)x1, (float)y1);
            PointF p2 = new PointF((float)x2, (float)y2);

            Segment segment = new Segment(p1, p2);

            return segment;
        }

        //рисуем отрезки на экране по полученному массиву сегментов
        private void DrawSegments(List<Segment> listSegments)
        {
            foreach (Segment segment in listSegments)
            {
                DrawLinePointF(segment.A, segment.B);
            }
        }


        //изометрическая проекция, вспомогательные функции

        //функция возвращает список точек в двумерной системе координат, являющихся точками изометрической проекции призмы
        // принимает список вершин призмы и матрицу преобразования
        private List<PointF> GetIsometricPoints(List<Point3D> listVertex3D, List<double> listMatrix)
        {
            List<PointF> listVertex2D = new List<PointF>();
            PointF point = new PointF();

            foreach (Point3D vertex in listVertex3D)
            {
                point.X = (float)(vertex.X * listMatrix[0] + vertex.Y * listMatrix[3] + vertex.Z * listMatrix[6]);
                point.Y = (float)(vertex.X * listMatrix[1] + vertex.Y * listMatrix[4] + vertex.Z * listMatrix[7]);
                listVertex2D.Add(point);
            }
            return listVertex2D;
        }

        //функция возвращает список точек в двумерной системе координат, являющихся точками изометрической проекции призмы
        //функция фращает призму относительно оси Z на данный угол
        // принимает список вершин призмы, матрицу преобразования и угол вращения
        private List<PointF> GetIsometricPointsWithRotation(List<Point3D> listVertex3D, List<double> listMatrix, double angle)
        {
            List<PointF> listVertex2D = new List<PointF>();
            PointF point = new PointF();
            List<Point3D> newList3D = new List<Point3D>();
            Point3D newPoint = new Point3D();

            double grad = Math.PI * angle / 180.0;
            double sina = Math.Sin(grad);
            double cosa = Math.Cos(grad);

            //поворачиваем на угол angle
            foreach (Point3D vertex in listVertex3D)
            {
                newPoint.X = vertex.X * cosa - vertex.Y * sina;
                newPoint.Y = vertex.X * sina + vertex.Y * cosa;
                newPoint.Z = vertex.Z;

                newList3D.Add(newPoint);
            }

            //строим двумерную проволочную модель
            foreach (Point3D vertex in newList3D)
            {
                point.X = (float)(vertex.X * listMatrix[0] + vertex.Y * listMatrix[3] + vertex.Z * listMatrix[6]);
                point.Y = (float)(vertex.X * listMatrix[1] + vertex.Y * listMatrix[4] + vertex.Z * listMatrix[7]);
                listVertex2D.Add(point);
            }
            return listVertex2D;
        }

        //рисуем проекцию
        private void DrawProjection(List<PointF> listPoints)
        {

            //делаем смещение чтобы поместть начало координат ближе к центру
            //таким образом более наглядно будет показываться вращение относительно оси Z

            if (listPoints.Count < 8) return;
            DrawLinePointFDisplacement(listPoints[0], listPoints[1], displacement_x, displacement_y);
            DrawLinePointFDisplacement(listPoints[1], listPoints[2], displacement_x, displacement_y);
            DrawLinePointFDisplacement(listPoints[2], listPoints[3], displacement_x, displacement_y);
            DrawLinePointFDisplacement(listPoints[3], listPoints[0], displacement_x, displacement_y);
            DrawLinePointFDisplacement(listPoints[4], listPoints[5], displacement_x, displacement_y);
            DrawLinePointFDisplacement(listPoints[5], listPoints[6], displacement_x, displacement_y);
            DrawLinePointFDisplacement(listPoints[6], listPoints[7], displacement_x, displacement_y);
            DrawLinePointFDisplacement(listPoints[7], listPoints[4], displacement_x, displacement_y);
            DrawLinePointFDisplacement(listPoints[0], listPoints[4], displacement_x, displacement_y);
            DrawLinePointFDisplacement(listPoints[1], listPoints[5], displacement_x, displacement_y);
            DrawLinePointFDisplacement(listPoints[2], listPoints[6], displacement_x, displacement_y);
            DrawLinePointFDisplacement(listPoints[3], listPoints[7], displacement_x, displacement_y);
        }

        private void DrawLinePointFDisplacement(PointF A, PointF B, int dis_x, int dis_y)
        {
            int x1 = (int)Math.Round(A.X) + dis_x;
            int x2 = (int)Math.Round(B.X) + dis_x;
            int y1 = (int)Math.Round(A.Y) + dis_y;
            int y2 = (int)Math.Round(B.Y) + dis_y;
            DrawLine(x1, y1, x2, y2);
        }

        //рисуем проекцию и удаляем невидимые рёбра
        private void DrawProjectionSegment(List<PointF> listPoints)
        {
            //делим призму на шесть граней
            Polygon polygon1 = new Polygon(new List<PointF> { listPoints[0], listPoints[1], listPoints[2], listPoints[3] }); //P1 P2 P3 P4
            Polygon polygon2 = new Polygon(new List<PointF> { listPoints[3], listPoints[7], listPoints[4], listPoints[0] }); //P1 P5 P8 P4
            Polygon polygon3 = new Polygon(new List<PointF> { listPoints[0], listPoints[4], listPoints[5], listPoints[1] }); //P1 P5 P6 P2
            Polygon polygon4 = new Polygon(new List<PointF> { listPoints[1], listPoints[5], listPoints[6], listPoints[2] }); //P2 P6 P7 P3
            Polygon polygon5 = new Polygon(new List<PointF> { listPoints[2], listPoints[6], listPoints[7], listPoints[3] }); //P4 P8 P7 P3
            Polygon polygon6 = new Polygon(new List<PointF> { listPoints[7], listPoints[6], listPoints[5], listPoints[4] }); //P5 P6 P7 P8

            //грань фронтальная true или тыльная false? Polygon.isConvex
            //если ребро принадлежит двум тыльным граням, то оно невидимо - не рисуем его
            //иначе - рисуем
            if (polygon1.IsConvex || polygon2.IsConvex) //если ни одна ни вторая грань не тыльныя - рисуем
            {
                DrawLinePointFDisplacement(listPoints[3], listPoints[0], displacement_x, displacement_y);
            }
            if (polygon1.IsConvex || polygon3.IsConvex)
            {
                DrawLinePointFDisplacement(listPoints[0], listPoints[1], displacement_x, displacement_y);
            }
            if (polygon1.IsConvex || polygon4.IsConvex)
            {
                DrawLinePointFDisplacement(listPoints[1], listPoints[2], displacement_x, displacement_y);
            }
            if (polygon1.IsConvex || polygon5.IsConvex)
            {
                DrawLinePointFDisplacement(listPoints[2], listPoints[3], displacement_x, displacement_y);
            }
            if (polygon2.IsConvex || polygon3.IsConvex)
            {
                DrawLinePointFDisplacement(listPoints[0], listPoints[4], displacement_x, displacement_y);
            }
            if (polygon3.IsConvex || polygon4.IsConvex)
            {
                DrawLinePointFDisplacement(listPoints[1], listPoints[5], displacement_x, displacement_y);
            }
            if (polygon4.IsConvex || polygon5.IsConvex)
            {
                DrawLinePointFDisplacement(listPoints[2], listPoints[6], displacement_x, displacement_y);
            }
            if (polygon5.IsConvex || polygon2.IsConvex)
            {
                DrawLinePointFDisplacement(listPoints[3], listPoints[7], displacement_x, displacement_y);
            }
            if (polygon2.IsConvex || polygon6.IsConvex)
            {
                DrawLinePointFDisplacement(listPoints[7], listPoints[4], displacement_x, displacement_y);
            }
            if (polygon3.IsConvex || polygon6.IsConvex)
            {
                DrawLinePointFDisplacement(listPoints[4], listPoints[5], displacement_x, displacement_y);
            }
            if (polygon4.IsConvex || polygon6.IsConvex)
            {
                DrawLinePointFDisplacement(listPoints[5], listPoints[6], displacement_x, displacement_y);
            }
            if (polygon5.IsConvex || polygon6.IsConvex)
            {
                DrawLinePointFDisplacement(listPoints[6], listPoints[7], displacement_x, displacement_y);
            }
        }

    }
}
