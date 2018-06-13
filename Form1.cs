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
        //координаты поля
        List<double> coordsX = new List<double>();      
        List<double> coordsY = new List<double>();
        List<double> coordsXLine = new List<double>();
        List<double> coordsYLine = new List<double>();
        List<double> transformCordsX = new List<double>();
        List<double> transformCordsY = new List<double>();
        double koffX, koffY;

        //координаты пересечения поля с отрезками трека
        List<double> crossPointX = new List<double>();
        List<double> crossPointY = new List<double>();

        //трек следования техники
        List<double> xPointsTrack = new List<double>();
        List<double> yPointsTrack = new List<double>();
        double[] yTrackLine = new double[1000];

        //Координаты для теста географических преобразований пересечений трека с полем
        List<double> tempTruncateX = new List<double>();
        List<double> tempTruncateY = new List<double>();
        List<double> testGeoX = new List<double>();
        List<double> testGeoY = new List<double>();

        //Координаты "дырок" в поле
        String troubleZonePath = "";
        double[,,] troubleZones = new double[0,0,0];

        public Form1()
        {
            InitializeComponent();
        }

        //Функции преобразования географических координат из проекции WGS84 в метры
        private void scaleTransform()
        {
            double scale = 0.5;

            double xMin = testGeoX.Min();
            double yMin = testGeoY.Min();
            double xMax = testGeoX.Max();
            double yMax = testGeoY.Max();

            double diffX = xMax - xMin;
            double diffY = yMax - yMin;

            koffX = pictureBoxField.Width / diffX;
            koffY = pictureBoxField.Height / diffY;

            //MessageBox.Show("xkoff: " + koffX.ToString() + "\tykoff: " + koffY.ToString());

            for(int i = 0; i < testGeoX.Count; i++)
            {
                testGeoX[i] = (testGeoX[i] - xMin) * koffX * scale;
                testGeoY[i] = (testGeoY[i] - yMin) * koffY * scale;
            }

            double centrX = (testGeoX.Max() - testGeoX.Min()) / 2;
            double centrY = (testGeoY.Max() - testGeoY.Min()) / 2;

            for (int i = 0; i < testGeoX.Count; i++)
            {
                testGeoX[i] += centrX;
                testGeoY[i] += centrY;
            }
        }
        private double geoTransformX(double xLat)
        {
            double Lekvator = 40007520.41; //длина экватора
            double degreeEkv = Lekvator / 360;
            double degreeEkvLat = degreeEkv * Math.Cos(xLat);
            xLat = degreeEkvLat * xLat;

            return xLat;
        }
        private double geoTransformY(double yLot)
        {
            double Lekvator = 40007520.41; //длина экватора
            double degreeEkv = Lekvator / 360;
            yLot = yLot * degreeEkv;

            return yLot;
        }

        //выбрать файл с полем
        private void добавитьПолеToolStripMenuItem_Click(object sender, EventArgs e)
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
        
        //выбрать файл с препятствиями
        private void добавитьПрепяствияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr1 = new System.IO.StreamReader(openFileDialog2.FileName);
                //MessageBox.Show(sr.ReadToEnd());
                String fileCoords = Path.GetFullPath(openFileDialog2.FileName.ToString());
                troubleZonePath = fileCoords;
                sr1.Close();
            }
        }

        //отрисовать поле 
        private void buttonViewField_Click(object sender, EventArgs e)
        {
            if (textBoxCoordsTest.Text != "")
            {
                Graphics g = pictureBoxField.CreateGraphics();
                g.TranslateTransform((float)pictureBoxField.Width, 0);
                Pen myPen = new Pen(Color.Black);
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
                        coordsX.Add(Convert.ToDouble(temps[i]));
                    }
                    else
                    {
                        coordsY.Add(Convert.ToDouble(temps[i]));
                    }
                    
                }

                
                for (int i = 0; i < coordsX.Count; i++)
                {
                    //tempTruncateX.Add(Math.Truncate(coordsX[i]));
                    //tempTruncateY.Add(Math.Truncate(coordsY[i]));

                    testGeoX.Add(geoTransformX(coordsX[i]));
                    testGeoY.Add(geoTransformY(coordsY[i]));

                    coordsX[i] = (((coordsX[i] - Math.Truncate(coordsX[i])) * 1000) - 800) * 5 - 500;
                    coordsY[i] = (((coordsY[i] - Math.Truncate(coordsY[i])) * 1000) - 200) * 5 - 500;
                    //MessageBox.Show("x: " + testGeoX[i].ToString() + "\t y: " + testGeoY[i].ToString());
                    //MessageBox.Show(testGeoX[i].ToString() + "         " + testGeoY[i].ToString());
                }

                coordsX.Clear();
                coordsY.Clear();

                scaleTransform();
                for(int i = 0; i < testGeoX.Count; i++)
                {
                    coordsX.Add(testGeoX[i]);
                    coordsY.Add(testGeoY[i]);
                    //MessageBox.Show("x: " + testGeoX[i].ToString() + "\t y: " + testGeoY[i].ToString());
                }
                
                //for (int i = 0; i < coordsX.Count; i++)
                //{
                //    MessageBox.Show("x: " + coordsX[i] + "; y: " + coordsY[i] + ";");
                //}


                for (int i = coordsX.Count - 1; i > 0; i--)
                {
                    g.DrawLine(myPen, Convert.ToSingle(coordsX[i - 1] * (-1)), Convert.ToSingle(coordsY[i - 1] * (1)),
                         Convert.ToSingle(coordsX[i] * (-1)), Convert.ToSingle(coordsY[i] * (1)));

                    //g.DrawLine(myPen, Convert.ToSingle(testGeoX[i - 1] * (-1)), Convert.ToSingle(testGeoY[i - 1] * (1)),
                    //     Convert.ToSingle(testGeoX[i] * (-1)), Convert.ToSingle(testGeoY[i] * (1)));
                }
            }
            else
            {
                MessageBox.Show("Файл с полем не выбран!");
            }
        }

        private void buttonAddTrouble_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBoxField.CreateGraphics();
            g.TranslateTransform(pictureBoxField.Width, 0);
            Pen myPen = new Pen(Color.Black);

            if (troubleZonePath != "")
            {
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
                        coordsX.Add(Convert.ToDouble(temps[i]));
                    }
                    else
                    {
                        coordsY.Add(Convert.ToDouble(temps[i]));
                    }

                }
            }
            else
            {
                MessageBox.Show("Файл с препятствиями не выбран!");
            }
        }

        /*Функция определения пересечения отрезков*/
        public static double [] DoLinesIntersect(double X1, double Y1, double X2, double Y2, 
            double X3, double Y3, double X4, double Y4)
        {
            double[] pointCross = new double[2];
            // Denominator for ua and ub are the same, so store this calculation
            // Знаменатель для ua и ub один и тот же, поэтому сохраните этот расчет

            double d = (Y4 - Y3) * (X2 - X1) - (X4 - X3) * (Y2 - Y1);

            //n_a и n_b вычисляются как отдельные значения для удобочитаемости
            //n_a and n_b are calculated as seperate values for readability
            double n_a = (X4 - X3) * (Y1 - Y3) - (Y4 - Y3) * (X1 - X3);
            double n_b = (X2 - X1) * (Y1 - Y3) - (Y2 - Y1) * (X1 - X3);

            // Make sure there is not a division by zero - this also indicates that
            // the lines are parallel.  
            // If n_a and n_b were both equal to zero the lines would be on top of each 
            // other (coincidental).  This check is not done because it is not 
            // necessary for this implementation (the parallel check accounts for this).

            //RU:Убедитесь, что нет деления на ноль - это также указывает на то, 
            //что линии параллельны. Если n_a и n_b равны нулю, линии будут 
            //сверху друг на друга (совпадающие). 
            //Эта проверка не выполняется, потому что это не является 
            //необходимым для этой реализации (для этого проверяется параллельная проверка).

            if (d == 0)
            {
                pointCross[0] = -1;
                pointCross[1] = -1;
                return pointCross;
            }


            // Calculate the intermediate fractional point that the lines potentially intersect.
            // Вычислите промежуточную дробную точку, в которой линии потенциально пересекаются.
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

        //Запись в файл для получения графиков
        private void writeToFileForGraph(int minCross, double longTracks, int iter)
        {
            string writePathK = "testGraph/k(phi).txt";
            string writePathL = "testGraph/L(phi).txt";

            string textK = iter.ToString() + ", " + minCross.ToString() + "; \n";
            //string textK = iter.ToString() + ", " + 
                //((longTracks * koffX * 0.5 / (minCross * 2.2 * 480 + longTracks * koffX * 0.5)) * 100000).ToString() + "; \n";
            string textL = iter.ToString() + ", " + longTracks.ToString() + "; \n";

            try
            {
                using (StreamWriter sw = new StreamWriter(writePathK, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(textK);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                using (StreamWriter sw = new StreamWriter(writePathL, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(textL);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //Нажатие кнопки "оптимальный трек", каждый 50 трек рисует для наглядности
        private void buttonOptymalTrack_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBoxField.CreateGraphics();
            Pen myPen = new Pen(Color.Blue);   //Кисть черного цвета для отрисовки поля
            g.TranslateTransform((float)pictureBoxField.Width, 0);
            g.Clear(Color.White);

            //массив для отрисовки каждых 50 треков
            double[,] drawLines;
            int countCross = 0;
            
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
            double longTrack = 0, longTrackFile = 0;
            double EFC = 0;
            double xTrackStart = 0, xTrackEnd = pictureBoxField.Width;
            
            int minCross = 1000000, countMin = 0;

            for (int i = 0; i < coordsX.Count; i++)
            {
                tempX.Add(0);
                tempY.Add(0);
                tempX1.Add(0);
                tempY1.Add(0);
            }

            progressBar1.Maximum = 180;
            progressBar1.Minimum = 0;

            for (int angle = 0; angle < 180; angle++)
            {
                progressBar1.Visible = true;
                progressBar1.Value += 1;

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
                for (int i = 0; i < 1000; i++)
                {
                    yTrackLine[i] = i*9;
                    //yTrackLine[i] = i * 9 * koffY * 0.5;
                }

                //Цикл, который считает пересечения
                for (int i = 0; i < yTrackLine.Length; i++)
                {
                    for (int j = 0; j < coordsX.Count - 1; j++)
                    {
                        croosTemp = DoLinesIntersect(xTrackStart, yTrackLine[i], xTrackEnd, yTrackLine[i],
                            tempX1[j], tempY1[j], tempX1[j + 1], tempY1[j + 1]);
                        if (croosTemp[0] != -1 && croosTemp[1] != -1)
                        {
                            if(i != countCross)
                            {
                                countCross++;
                            }
                            tempCrossPx.Add(croosTemp[0]);
                            tempCrossPy.Add(croosTemp[1]);
                        }

                    }
                }


                double longTrackOld;
                for (int j = 0; j < tempCrossPx.Count - 1; j++)
                {
                    longTrack += Math.Sqrt((tempCrossPx[j + 1] - tempCrossPx[j]) * (tempCrossPx[j + 1] - tempCrossPx[j])
                        - (tempCrossPy[j + 1] - tempCrossPy[j]) * (tempCrossPy[j + 1] - tempCrossPy[j]));
                }
                if(longTrack.ToString().Equals("NaN"))
                {
                    longTrack = 0;
                }
                double tempEFC = 0;
                EFC = longTrack / (minCross + longTrack);
                writeToFileForGraph(tempCrossPx.Count, longTrack, angle);


                if (tempEFC <= EFC)
                {
                    longTrackFile = longTrack;
                    tempEFC = EFC;
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

                    for (int i = 0; i < tempCrossPx.Count; i++)
                    {
                        crossPointX.Add(tempCrossPx[i]);
                        crossPointY.Add(tempCrossPy[i]);
                    }
                    
                    drawLines = new double[countCross, crossPointX.Count];

                    //for(int i = 0; i < countCross; i++)
                    //{
                    //    for(int j = 0; j < crossPointX.Count; j++)
                    //    {
                    //        for()
                    //    }
                    //}

                }
                longTrack = 0;
            }
            
            MessageBox.Show("Поворотов всего: " + minCross + ", Итерация № " + countMin + 
                "\n EFC: " + longTrackFile);
            
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

            progressBar1.Visible = false;
            progressBar1.Value = 0;

            //Тестирование геоинформационных данных
            //double crosX = crossPointX[0] + 800;
            //crosX = crosX / 10;
            //crosX = crosX + 800;
            //crosX = crosX / 1000;
            //crosX = crosX + tempTruncateX[0];

            //double crosY = crossPointY[0] + 800;
            //crosY = crosY / 10;
            //crosY = crosY + 800;
            //crosY = crosY / 1000;
            //crosY = crosY + tempTruncateY[0];

            //MessageBox.Show("coordsField: x1 = " + coordsX[0] + "   y = " + coordsY[0]
            //    + "\ncrossPoint: x1 = " + crosX + "   y = " + crosY);
        }

        double distance(double x1, double y1, double x2, double y2)
        {
            double full_path_combain = Convert.ToDouble(textBoxForFullWayCombain.Text) * koffX * 0.5;
            double resoult = Math.Sqrt((x2 - x1)*(x2 - x1) + (y2 - y1)*(y2 - y1)); //Расстояние м/у точками
            if (resoult <= full_path_combain) { return 0; } 
            else { return full_path_combain; }
        }

        //Нажатие кнопки для "отрисовать разрез"
        private void buttonTrackView_Click(object sender, EventArgs e)
        {
            if (textBoxForFullWayCombain.Text.Equals(""))
            {
                MessageBox.Show("enter full!!");
            }
            else
            {
                Graphics g = pictureBoxField.CreateGraphics();
                Pen myPen = new Pen(Color.Green);   //Кисть зеленого цвета для отрисовки разреза
                g.TranslateTransform((float)pictureBoxField.Width, 0);

                double fullWayCombain = Convert.ToDouble(textBoxForFullWayCombain.Text) * koffX * 0.5;
                MessageBox.Show(fullWayCombain.ToString());

                int indexMinELem = 0;
                double longLine = 0, longLineTemp = 0;

                List<double> coordsKnifeX = new List<double>();
                List<double> coordsKnifeY = new List<double>();

                double[] prokosX = new double[4];
                double[] prokosY = new double[4];

                int longForProkosCount;
                do
                {
                    longForProkosCount = 0;
                    for (int i = 0; i < crossPointX.Count - 1; i++)
                    {
                        if (i % 2 == 0)
                        {
                            if (distance(crossPointX[i], crossPointY[i], crossPointX[i + 1], crossPointY[i + 1]) != 0)
                            {
                                coordsKnifeX.Add(crossPointX[i]);
                                coordsKnifeY.Add(crossPointY[i]);
                                coordsKnifeX.Add(crossPointX[i + 1]); 
                                coordsKnifeY.Add(crossPointY[i + 1]);
                                longForProkosCount++;
                            }
                        }
                    }

                    for (int i = 0; i < coordsKnifeX.Count - 1; i++)
                    {
                        if (i % 2 == 0)
                        {
                            longLineTemp = Math.Sqrt((coordsKnifeX[i + 1] - coordsKnifeX[i]) *
                                (coordsKnifeX[i + 1] - coordsKnifeX[i]) +
                                (coordsKnifeY[i + 1] - coordsKnifeY[i]) *
                                (coordsKnifeY[i + 1] - coordsKnifeY[i]));
                            if (longLineTemp > longLine)
                            {
                                indexMinELem = i;
                                longLine = longLineTemp;
                            }
                        }
                    }

                    //начало
                    prokosX[0] = coordsKnifeX[indexMinELem];
                    prokosY[0] = coordsKnifeY[indexMinELem];
                    //конец
                    prokosX[1] = prokosX[0] - fullWayCombain;
                    prokosY[1] = prokosY[0];

                    coordsKnifeX.RemoveAt(indexMinELem);
                    coordsKnifeY.RemoveAt(indexMinELem);
                    coordsKnifeX.RemoveAt(indexMinELem);
                    coordsKnifeY.RemoveAt(indexMinELem);

                    longLine = 0;
                    MessageBox.Show(coordsKnifeX.Count.ToString());

                    for (int i = 0; i < coordsKnifeX.Count - 1; i++)
                    {
                        if (i % 2 == 0)
                        {
                            longLineTemp = Math.Sqrt((coordsKnifeX[i + 1] - coordsKnifeX[i]) *
                                (coordsKnifeX[i + 1] - coordsKnifeX[i]) +
                                (coordsKnifeY[i + 1] - coordsKnifeY[i]) *
                                (coordsKnifeY[i + 1] - coordsKnifeY[i]));
                            if (longLineTemp > longLine)
                            {
                                indexMinELem = i;
                                longLine = longLineTemp;
                            }
                        }
                    }

                    //начало
                    prokosX[2] = coordsKnifeX[indexMinELem];
                    prokosY[2] = coordsKnifeY[indexMinELem];
                    //конец
                    prokosX[3] = prokosX[2] - fullWayCombain;
                    prokosY[3] = prokosY[2];

                    coordsKnifeX.RemoveAt(indexMinELem);
                    coordsKnifeY.RemoveAt(indexMinELem);
                    coordsKnifeX.RemoveAt(indexMinELem);
                    coordsKnifeY.RemoveAt(indexMinELem);
                    MessageBox.Show(coordsKnifeX.Count.ToString());
                    //MessageBox.Show(longForProkosCount.ToString());

                    g.DrawLine(myPen, (float)prokosX[0] * -1, (float)prokosY[0],
                        (float)prokosX[1] * -1, (float)prokosY[1]);
                    g.DrawLine(myPen, (float)prokosX[2] * -1, (float)prokosY[2],
                            (float)prokosX[3] * -1, (float)prokosY[3]);

                } while (longForProkosCount <= 2);
            }
        }
    }
}
