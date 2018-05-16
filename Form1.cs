using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace LogistikField
{
    
    public partial class Form1 : Form
    {
        List<double> coordsX = new List<double>();      //координаты поля по x
        List<double> coordsY = new List<double>();      //ккординаты поля по у
        List<double> crossPointX = new List<double>();  //координаты пересечения поля по x
        List<double> crossPointY = new List<double>();  //ккординаты пересечения поля по у
        List<double> xPointsTrack = new List<double>(); //координаты отрисовки трека по х
        List<double> yPointsTrack = new List<double>(); //координаты отрисовки трека по у
        List<double> coordsXLine = new List<double>();  //координаты поля по x
        List<double> coordsYLine = new List<double>();  //координаты поля по у
        double[] yTrackLine = new double[100];         //координаты отрезков трека
        double full_path_combain = 90;                  //полный ход комбайна
        double field;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName);
                //MessageBox.Show(sr.ReadToEnd());
                String fileCoords = Path.GetFullPath(openFileDialog1.FileName.ToString());
                textBoxCoordsTest.Text = fileCoords;
                sr.Close();
            }
        }

        private void buttonViewField_Click(object sender, EventArgs e)
        {
            if (textBoxCoordsTest.Text != "")
            {
                //pictureBoxField.Scale(0.1f);
                Graphics g = pictureBoxField.CreateGraphics();
                g.TranslateTransform((float)pictureBoxField.Width, 0);
                //g.TranslateTransform(48, 40);
                Pen myPen = new Pen(Color.Black);   //Кисть черного цвета для отрисовки поля
                StreamReader fcoords = new StreamReader(textBoxCoordsTest.Text);
                
                string temp = "";   //хранит текущее число в файле до точки с запятой

                while (true)    //Считывание с файла
                {
                    string text = fcoords.ReadLine();
                    if (text == null) break;
                    temp += text;
                }

                String[] temps = temp.Split(';');   //создаем массив для списка координат

                for (int i = 0; i < temps.Count() - 1; i++)
                {
                    if (i % 2 == 0)
                    {
                        //coordsX.Add((Convert.ToDouble(temps[i]) - 50) * 1000);
                        coordsX.Add(Convert.ToDouble(temps[i]));
                    }
                    else
                    {
                        //coordsY.Add((Convert.ToDouble(temps[i]) - 44) * 1000);
                        coordsY.Add(Convert.ToDouble(temps[i]));
                    }
                    
                }

                for (int i = 0; i < coordsX.Count; i++)
                {
                    //coordsX[i] = (((coordsX[i] * 10) - 438) * 500 - 400) * 2;
                    //coordsY[i] = (((coordsY[i] * 10) - 502) * 500 - 200) * 2;
                    coordsX[i] = (((coordsX[i] - Math.Truncate(coordsX[i])) * 1000) - 800)*10 - 800;
                    coordsY[i] = (((coordsY[i] - Math.Truncate(coordsY[i])) * 1000) - 200)*10 - 400;

                }

                //for (int i = 0; i < coordsX.Count; i++)
                //{
                //    MessageBox.Show("x: " + coordsX[i] + "; y: " + coordsY[i] + ";");
                //}


                for (int i = coordsX.Count - 1; i > 0; i--)
                {
                    //g.DrawLine(myPen, Convert.ToSingle(coordsX[i - 1] * (-0.1)), Convert.ToSingle(coordsY[i - 1] * (0.1)),
                    //     Convert.ToSingle(coordsX[i] * (-0.1)), Convert.ToSingle(coordsY[i] * (0.1)));
                    g.DrawLine(myPen, Convert.ToSingle(coordsX[i - 1] * (-1)), Convert.ToSingle(coordsY[i - 1] * (1)),
                         Convert.ToSingle(coordsX[i] * (-1)), Convert.ToSingle(coordsY[i] * (1)));

                }
            }
            else
            {
                MessageBox.Show("Файл с полем не выбран!");
            }
        }

        /*Функция определения пересечения отрезков*/
        public static double [] DoLinesIntersect(double X1, double Y1, double X2, double Y2, 
            double X3, double Y3, double X4, double Y4)
        {
            double[] pointCross = new double[2];
            // Denominator for ua and ub are the same, so store this calculation
            double d = (Y4 - Y3) * (X2 - X1) - (X4 - X3) * (Y2 - Y1);

            //n_a and n_b are calculated as seperate values for readability
            double n_a = (X4 - X3) * (Y1 - Y3) - (Y4 - Y3) * (X1 - X3);

            double n_b = (X2 - X1) * (Y1 - Y3) - (Y2 - Y1) * (X1 - X3);

            // Make sure there is not a division by zero - this also indicates that
            // the lines are parallel.  
            // If n_a and n_b were both equal to zero the lines would be on top of each 
            // other (coincidental).  This check is not done because it is not 
            // necessary for this implementation (the parallel check accounts for this).
            if (d == 0)
            {
                pointCross[0] = -1;
                pointCross[1] = -1;
                return pointCross;
            }
            

            // Calculate the intermediate fractional point that the lines potentially intersect.
            double ua = n_a / d;
            double ub = n_b / d;

            // The fractional point will be between 0 and 1 inclusive if the lines
            // intersect.  If the fractional calculation is larger than 1 or smaller
            // than 0 the lines would need to be longer to intersect.
            if (ua >= 0d && ua <= 1d && ub >= 0d && ub <= 1d)
            {
                pointCross[0] = X1 + (ua * (X2 - X1));
                pointCross[1] = Y1 + (ua * (Y2 - Y1));
                return pointCross;
            }
            else
            {
                pointCross[0] = -1;
                pointCross[1] = -1;
                return pointCross;
            }
            
        }

        //Нажатие кнопки "оптимальный трек"
        private void buttonOptymalTrack_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBoxField.CreateGraphics();
            Pen myPen = new Pen(Color.Blue);   //Кисть черного цвета для отрисовки поля
            g.TranslateTransform((float)pictureBoxField.Width, 0);
            g.Clear(Color.White);

            //Вращение полигона
            double x0 = (coordsX.Max() + coordsX.Min()) / 2;
            double y0 = (coordsY.Max() + coordsY.Min()) / 2;
            List<double> tempX = new List<double>();  //координаты поля по x
            List<double> tempY = new List<double>();  //ккординаты поля по у
            List<double> tempX1 = new List<double>();  //координаты поля по x
            List<double> tempY1 = new List<double>();  //ккординаты поля по у
            List<double> tempCrossPx = new List<double>();  //координаты пересечения поля по x
            List<double> tempCrossPy = new List<double>();  //ккординаты пересечения поля по у
            double[] croosTemp = new double[2];
            double xTrackStart = 0, xTrackEnd = pictureBoxField.Width;
            
            int minCross = 1000000, countMin = 0;

            for (int i = 0; i < coordsX.Count; i++)
            {
                tempX.Add(0);
                tempY.Add(0);
                tempX1.Add(0);
                tempY1.Add(0);
            }
            for (int angle = 0; angle < 180; angle++)
            {
                tempCrossPx.Clear();
                tempCrossPy.Clear();
                for (int i = 0; i < coordsX.Count; i++)
                {
                    tempX[i] = ((coordsX[i] - x0) * Math.Cos(angle) -
                        (coordsY[i] - y0) * Math.Sin(angle) + x0);
                    tempY[i] = ((coordsX[i] - x0) * Math.Sin(angle) +
                        (coordsY[i] - y0) * Math.Cos(angle) + y0);
                    tempX1[i] = tempX[i];
                    tempY1[i] = tempY[i];
                }

                /*Все повернули, считаем кол-во пересечений*/

                //Отрезки трека y = 10 + i;
                for (int i = 0; i < 100; i++)
                {
                    yTrackLine[i] = i*4;
                }

                //Цикл, который считает пересечения
                for (int i = 0; i < yTrackLine.Length; i++)
                {
                    if (i % 2 == 1) { continue; }
                    else
                    {
                        for (int j = 0; j < coordsX.Count - 1; j++)
                        {
                            croosTemp = DoLinesIntersect(xTrackStart, yTrackLine[i], xTrackEnd, yTrackLine[i],
                                tempX1[j], tempY1[j], tempX1[j + 1], tempY1[j + 1]);
                            if (croosTemp[0] != -1 && croosTemp[1] != -1)
                            {
                                tempCrossPx.Add(croosTemp[0]);
                                tempCrossPy.Add(croosTemp[1]);
                            }

                        }
                    }
                }
                if(tempCrossPx.Count <= minCross)
                {
                    minCross = tempCrossPx.Count;
                    countMin = angle;
                    coordsX.Clear();
                    coordsY.Clear();
                    crossPointX.Clear();
                    crossPointY.Clear();

                    for (int i = 0; i < tempX1.Count; i++)
                    {
                        coordsX.Add(tempX1[i]);
                        coordsY.Add(tempY1[i]);
                    }

                    for(int i = 0; i < tempCrossPx.Count; i++)
                    {
                        crossPointX.Add(tempCrossPx[i]);
                        crossPointY.Add(tempCrossPy[i]);
                    }
                }
            }
            MessageBox.Show("Поворотов всего: " + minCross + ", Итерация № " + countMin);
            //Цикл, который рисует все треки
            for (int i = 0; i < crossPointX.Count - 1; i++)
            {
                if (i % 2 == 0)
                {
                    g.DrawLine(myPen, (float)crossPointX[i] * -1, (float)crossPointY[i],
                        (float)crossPointX[i + 1] * -1, (float)crossPointY[i + 1]);
                }
            }


            for (int i = 0; i < coordsX.Count - 1; i++)
            {
                g.DrawLine(myPen, (float)coordsX[i + 1] * (-1), (float)coordsY[i + 1] * (1),
                     (float)coordsX[i] * (-1), (float)coordsY[i] * (1));
            }
        }

        double distance(double x1, double y1, double x2, double y2)
        {
            double resoult = Math.Sqrt((x2 - x1) + (y2 - y1));
            if (resoult <= full_path_combain) { return 0; }
            else { return full_path_combain; }
        }


        //Нажатие кнопки для "отрисовать разрез"
        private void buttonTrackView_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBoxField.CreateGraphics();
            Pen myPen = new Pen(Color.Green);   //Кисть зеленого цвета для отрисовки разреза
            g.TranslateTransform((float)pictureBoxField.Width, 0);

            //double full_path_combain = Convert.ToDouble(textBoxForFullWayCombain.Text);   //Полный ход комбайна
            List<double> temp_knife_x1 = new List<double>();
            List<double> temp_knife_y1 = new List<double>();
            List<double> temp_knife_x2 = new List<double>();
            List<double> temp_knife_y2 = new List<double>();
            List<double> start_min_points = new List<double>(); //Список, хранящий две минимальные точки
            int[] countPointTrack = new int[2];

            for (int i = 0; i < crossPointX.Count; i++)
            {
                if (i % 2 == 0)
                {
                    temp_knife_x1.Add(crossPointX[i]);
                    temp_knife_y1.Add(crossPointY[i]);
                    temp_knife_x2.Add(crossPointX[i] - distance(crossPointX[i], crossPointY[i], crossPointX[i + 1], crossPointY[i + 1]));
                    temp_knife_y2.Add(crossPointY[i]);
                    //g.DrawLine(myPen,
                    //    (float)crossPointX[i] * -1,
                    //    (float)crossPointY[i],
                    //    ((float)crossPointX[i] - (float)distance(crossPointX[i], crossPointY[i], crossPointX[i + 1], crossPointY[i + 1])) * -1,
                    //    (float)crossPointY[i + 1]);
                }
            }
            List<double> minCoordsX = new List<double>();
            List<double> minCoordsY = new List<double>();

            double[] temp_array_min = new double[temp_knife_x2.Count];

            for(int i = 0; i < temp_knife_x2.Count; i++)
            {
                temp_array_min[i] = temp_knife_x2[i];
            }

            int indexMinCrossPointX = Array.IndexOf(temp_array_min, temp_knife_x2.Max());
            minCoordsX.Add(temp_knife_x2[indexMinCrossPointX]);
            minCoordsY.Add(temp_knife_y2[indexMinCrossPointX]);
            temp_knife_x1.RemoveAt(indexMinCrossPointX);
            temp_knife_y1.RemoveAt(indexMinCrossPointX);
            temp_knife_x2.RemoveAt(indexMinCrossPointX);
            temp_knife_y2.RemoveAt(indexMinCrossPointX);

            double[] temp_array_min2 = new double[temp_knife_x2.Count];
            for (int i = 0; i < temp_knife_x2.Count; i++)
            {
                temp_array_min2[i] = temp_knife_x2[i];
            }

            indexMinCrossPointX = Array.IndexOf(temp_array_min2, temp_knife_x2.Max());
            minCoordsX.Add(temp_knife_x2[indexMinCrossPointX]);
            minCoordsY.Add(temp_knife_y2[indexMinCrossPointX]);
            temp_knife_x1.RemoveAt(indexMinCrossPointX);
            temp_knife_y1.RemoveAt(indexMinCrossPointX);
            temp_knife_x2.RemoveAt(indexMinCrossPointX);
            temp_knife_y2.RemoveAt(indexMinCrossPointX);

            //MessageBox.Show("1) " + minCoordsX[0].ToString() + " " + minCoordsY[0].ToString() +
            //    "\n2) " + minCoordsX[1].ToString() + " " + minCoordsY[1].ToString());

            g.DrawLine(myPen, (float)minCoordsX[0] * -1, (float)minCoordsY[0],
                (float)minCoordsX[1] * -1, (float)minCoordsY[1]);

            double k = (minCoordsY[0] - minCoordsY[1]) / (minCoordsX[0] - minCoordsX[1]);
            double b = minCoordsY[0] - k * minCoordsX[0];

            double y = minCoordsY[0], x = minCoordsX[0];

            while(y > 0)
            {
                x++;
                y = k * x + b;
                
            }

            g.DrawLine(myPen, (float)minCoordsX[0] * -1, (float)minCoordsY[0],
               (float)x * -1, (float)y);

            while (y < 400)
            {
                x--;
                y = k * x + b;
                //MessageBox.Show(x + " " + y);
            }

            g.DrawLine(myPen, (float)minCoordsX[0] * -1, (float)minCoordsY[0],
                (float)x * -1, (float)y);
        }
    }
}
