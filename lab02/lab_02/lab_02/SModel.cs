using System;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace lab_02
{
    class SModel
    {
        public int numState { get; }
        public int defaultNum { get; }

        public static int inputNum;
        public double[,] mtr;

        public double[] pArr;
        public double[] timeArr;

        public SModel()
        {
            numState = 10;
            defaultNum = 5;
            pArr = new double[numState];

            inputNum = defaultNum;
            mtr = new double[numState, numState];
            
            _initP();
        }

        public void Emulate(ref Chart chart)
        {
            double[] tempArr = new double[inputNum];
            timeArr = new double[inputNum];
            double step = 0.01, t = step, temp;

            _initSeries(ref chart);

            while (true)
            {
                double[] klmArr = new double[inputNum];
                
                _draw(t, pArr, ref chart);

                for (int i = 0; i < inputNum; i++)
                {
                    for (int j = 0; j < inputNum; j++)
                    {
                        temp = mtr[j, i] * pArr[j] - mtr[i, j] * pArr[i];
                        tempArr[i] += temp * step;
                        klmArr[i] += temp;
                    }
                }

                for (int i = 0; i < inputNum; i++)
                    pArr[i] += tempArr[i];

                _checkStab(t, klmArr, ref timeArr);

                if (_allZero(tempArr))
                    break;

                _resetArr(ref tempArr);

                t += step;
            }

            _drawPoints(timeArr, pArr, ref chart);
        }

        private void _initP()
        {
            pArr[0] = 1;
            for (int i = 1; i < numState; i++)
                pArr[i] = 0;
        }

        private static void _initSeries(ref Chart chart)
        {
            chart.Series.Clear();
            for (int i = 0; i < inputNum; i++)
            {
                chart.Series.Add((i + 1).ToString());
                chart.Series[i].ChartType = SeriesChartType.Line;
                chart.Series[i].BorderWidth = 3;
            }

            chart.Series.Add("Points");
            chart.Series[inputNum].ChartType = SeriesChartType.Point;
            chart.Series[inputNum].Color = Color.Red;
        }

        private void _resetArr(ref double[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                arr[i] = 0;
        }

        private static bool _allZero(double[] arr)
        {
            double temp = 1e-8;

            for (int i = 0; i < arr.Length; i++)
                if (arr[i] > temp)
                    return false;
            return true;
        }

        private static void _checkStab(double t, double[] klmArr, ref double[] timeArr)
        {
            double cntr = 1e-5;

            for (int i = 0; i < inputNum; i++)
            {
                if (Math.Abs(klmArr[i]) > cntr && timeArr[i] != 0)
                    timeArr[i] = 0;
                else if (Math.Abs(klmArr[i]) < cntr && timeArr[i] == 0)
                    timeArr[i] = t;
            }
        }

        private static void _draw(double t, double[] arr, ref Chart chart)
        {
            for (int i = 0; i < inputNum; i++)
            {
                chart.Series[i].Points.AddXY(t, arr[i]);
            }
        }

        private static void _drawPoints(double[] x, double[] y, ref Chart chart)
        {
            for (int i = 0; i < inputNum; i++)
            {
                chart.Series[inputNum].Points.AddXY(x[i], y[i]);
            }
        }

        private static void _printMtr(double[,] m)
        {
            for (int i = 0; i < inputNum; i++)
            {
                for (int j = 0; j < inputNum; j++)
                    Console.Write(m[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static void _printArr(double[] arr)
        {
            for (int i = 0; i < inputNum; i++)
                Console.WriteLine($"{i}, {arr[i]}");

            Console.WriteLine();
        }
    }
}
