﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ZedGraph;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }


        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void radioButtonN_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonN.Checked)
            {
                ValuesM.Visible = false;
                ValuesN.Visible = true;
            }
        }

        private void radioButtonM_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                ValuesM.Visible = true;
                ValuesN.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filename = "data.txt";
            FileStream fs = File.Create(filename);
            fs.Close();
            int n = (Int16)ValueN.Value;
            int m = (Int16)ValueM.Value;
            double lyamda = (double)ValueLyamda.Value;
            double mu = (double)ValueMu.Value;

            PrintDinam dinamic = new PrintDinam(n, m, lyamda, mu, filename, zedGraphControl1);
            dinamic.PrintPk_t();
            dinamic.PrintTube();
            dinamic.PrintProperties();
            PrintStat stat = new PrintStat(n, m, lyamda, mu, filename);
            stat.PrintFull();

            if (radioButton2.Checked)
            {
                int[] mmas = new int[6];
                mmas[0] = m;
                mmas[1] = (int)m1.Value;
                mmas[2] = (int)m2.Value;
                mmas[3] = (int)m3.Value;
                mmas[4] = (int)m4.Value;
                mmas[5] = (int)m5.Value;
                mmas = mmas.Distinct().ToArray(); //удаляем повторяющиеся элементы
                mmas = mmas.OrderBy(x => x).ToArray(); //сортируем по возрастанию
                PrintStat[] classmas = new PrintStat[mmas.Length];
                for (int i = 0; i < mmas.Length; i++)
                {
                    classmas[i] = new PrintStat(n, mmas[i], lyamda, mu, filename);
                    classmas[i].PrintShort();
                }
            }
            else
            {
                int[] nmas = new int[6];
                nmas[0] = n;
                nmas[1] = (int)n1.Value;
                nmas[2] = (int)n2.Value;
                nmas[3] = (int)n3.Value;
                nmas[4] = (int)n4.Value;
                nmas[5] = (int)n5.Value;
                nmas = nmas.Distinct().ToArray();
                nmas = nmas.OrderBy(x => x).ToArray();
                PrintStat[] classmas = new PrintStat[nmas.Length];
                for (int i = 0; i < nmas.Length; i++)
                {
                    if (lyamda / mu / nmas[i] != 1)
                    {
                        classmas[i] = new PrintStat(nmas[i], m, lyamda, mu, filename);
                        classmas[i].PrintShort();
                    }

                }
            }
        }
    }

    class Stational
    {
        int n = 1, m = 1;
        double lyamda = 1, mu = 1;
        double ro = 1;
        double[] p;
        double mkan;
        double moch;
        double pobc;

        public int N
        {
            get { return this.n; }
        }
        public int M
        {
            get { return this.m; }
        }
        public double Lyamda
        {
            get { return this.lyamda; }
        }
        public double Mu
        {
            get { return this.mu; }
        }
        public double[] P
        {
            get { return this.p; }
        }
        public double Mkan
        {
            get { return this.mkan; }
        }
        public double Moch
        {
            get { return this.moch; }
        }
        public double Pobc
        {
            get { return this.pobc; }
        }

        long Fact(int n)
        {
            long x = 1;
            for (int i = 1; i <= n; i++)
                x *= i;
            return x;
        }

        public void calc_mkan_och_obc() //Вычисление математического ожидания канала, очереди, отказа
        {
            mkan = 0;
            for (int k = 0; k < n; k++)
            {
                mkan += k * p[k];
            }
            moch = 0;
            for (int k = n; k <= n + m; k++)
            {
                mkan += n * p[k];
                moch += (k - n) * p[k];
            }
            pobc = 1 - p[m + n];
        }

        void calculate()
        {
            p[0] = 1;
            for (int k = 1; k < n; k++)
            {
                p[0] += Math.Pow(ro, k) / Fact(k);
            }
            p[0] += Math.Pow(ro, n) / Fact(n) * ((1 - Math.Pow(ro / n, m + 1)) / (1 - ro / n));
            p[0] = Math.Pow(p[0], -1);

            for (int k = 1; k <= n; k++)
            {
                p[k] = (Math.Pow(ro, k) / Fact(k)) * p[0];
            }
            for (int k = n + 1; k <= n + m; k++)
            {
                p[k] = (Math.Pow(ro, n) / Fact(n)) * Math.Pow(ro / n, k - n) * p[0];
            }
            calc_mkan_och_obc();
        }
        public Stational(int n, int m, double lyamda, double mu)
        {
            this.n = n;
            this.m = m;
            this.lyamda = lyamda;
            this.mu = mu;
            this.ro = this.lyamda / this.mu;
            this.p = new double[m + n + 1];
            calculate();
        }
    }

    class Dinamic : Stational
    {
        double[] time;
        double[,] p_t;
        double[] mkan_t;
        double[] moch_t;
        double[] pobc_t;
        double[,] tube;

        public double[,] Tube
        {
            get { return this.tube; }
        }
        public double[,] P_t
        {
            get { return this.p_t; }
        }
        public double[] Time
        {
            get { return this.time; }
        }
        public double[] Mkan_t
        {
            get { return this.mkan_t; }
        }
        public double[] Moch_t
        {
            get { return this.moch_t; }
        }
        public double[] Pobc_t
        {
            get { return this.pobc_t; }
        }
        //Просьба строго не судить, код переделывался с Delphi
        double[] f(double[] CurP)
        {
            double tmp = 0;
            double[] mass = new double[N + M + 1];
            for (int i = 0; i <= M + N; i++)
            {
                if (i == 0) { tmp = -Lyamda * CurP[0] + Mu * CurP[1]; }
                if ((i >= 1) && (i < N)) { tmp = -(Lyamda + i * Mu) * CurP[i] + Lyamda * CurP[i - 1] + (i + 1) * Mu * CurP[i + 1]; }
                if ((i >= N) && (i < N + M)) { tmp = -(Lyamda + N * Mu) * CurP[i] + Lyamda * CurP[i - 1] + N * Mu * CurP[i + 1]; }
                if (i == N + M) { tmp = -N * Mu * CurP[i] + Lyamda * CurP[i - 1]; }
                mass[i] = tmp;
            }
            return mass;
        }

        double[] VectAM(double[] V1, double[] V2, double C)
        {
            double[] mass = new double[V1.Length];
            for (int i = 0; i < V1.Length - 1; i++)
                mass[i] = V1[i] + C * V2[i];
            return mass;
        }

        void CalcPk()
        {
            double[] K1, K2, K3, K4;
            double h = 0.0001;
            double hstat = 0.1;
            double sumdelta, delta;


            double[,] Pk_t = new double[1100, M + N + 1];
            double[] Pk_tstring = new double[M + N + 1];
            int i = 0;
            for (int j = 0; j <= N + M; j++)
            {
                if (j == 0) { Pk_tstring[j] = 1; }
                else { Pk_tstring[j] = 0; }
            }
            double t = 0;
            double[] Time_ = new double[1100];
            double statsum = 0;

            do
            {
                K1 = f(Pk_tstring);
                K2 = f(VectAM(Pk_tstring, K1, h / 2));
                K3 = f(VectAM(Pk_tstring, K2, h / 2));
                K4 = f(VectAM(Pk_tstring, K3, h));
                t += h;
                if (statsum + h < hstat) { statsum += h; }
                else { statsum = 0; }
                if (statsum == 0) { Time_[i] = t; }
                sumdelta = 0;
                for (int j = 0; j <= N + M; j++)
                {
                    delta = h * (K1[j] + 2 * K2[j] + 2 * K3[j] + K4[j]) / 6;
                    sumdelta += Math.Abs(delta);
                    Pk_tstring[j] += delta;
                    if (statsum == 0)
                    {
                        Pk_t[i, j] = Pk_tstring[j];
                    }
                }
                if (statsum == 0) { i++; }
            }
            while ((t < 100) && (sumdelta > (h / 10)));

            p_t = new double[i + 1, N + M + 1];
            p_t[0, 0] = 1;
            for (int j = 1; j < N + M + 1; j++)
                p_t[0, j] = 0;
            time = new double[i + 1];
            time[0] = 0;
            for (int j = 0; j < i; j++)
            {
                for (int k = 0; k <= N + M; k++) { p_t[j + 1, k] = Pk_t[j, k]; }
                time[j + 1] = Time_[j];
            }
        }

        void readfile(string file)
        {
            string[] lines = System.IO.File.ReadAllLines("file");
            //Подсчет количества чисел в строке
            int coulum = 0;
            for (int i = 0; i < lines[0].Length; i++)
            {
                if (lines[0][i] == '.') { coulum++; }
            }
            //Считывание чисел и занесение их в отдельный массив
            double[,] mass = new double[lines.Length, coulum];
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = lines[i].Replace('.', ',');
                string number = "";
                int k = 0;
                for (int j = 1; j < lines[i].Length; j++)
                {
                    if (lines[i][j] != ' ')
                    {
                        number += Convert.ToString(lines[i][j]);
                    }
                    else
                    {
                        if (number != "")
                        {
                            mass[i, k] = Convert.ToDouble(number);
                            k++;
                            number = "";
                        }
                    }

                }
            }

            //Разбиение значений времени и значений вероятностей по разным массивам
            time = new double[lines.Length];
            for (int i = 0; i < time.Length; i++)
            {
                time[i] = mass[i, 1];
            }
            p_t = new double[mass.GetLength(0), mass.GetLength(1) - 1];
            for (int i = 0; i < mass.GetLength(0); i++)
                for (int j = 1; j < mass.GetLength(1); j++)
                {
                    p_t[i, j - 1] = mass[i, j];
                }
        }

        void calc_mkan_och_obc_t() //вычисление величин зависящих от времени
        {
            mkan_t = new double[p_t.GetLength(0)];
            moch_t = new double[p_t.GetLength(0)];
            pobc_t = new double[p_t.GetLength(0)];
            for (int i = 0; i < p_t.GetLength(0); i++)
            {
                mkan_t[i] = 0;
                for (int k = 0; k < N; k++)
                {
                    mkan_t[i] += k * p_t[i, k];
                }
                moch_t[i] = 0;
                double summ = 0;
                for (int k = N; k <= N + M; k++)
                {
                    summ += p_t[i, k];
                    moch_t[i] += (k - N) * p_t[i, k];
                }
                mkan_t[i] += N * summ;
                pobc_t[i] = 1 - p_t[i, M + N];
            }
        }

        void calc_tube()
        {
            tube = new double[N + M + 1, 2];
            for (int i = 0; i <= N + M; i++)
            {
                tube[i, 0] = P[i] * 0.975;
                tube[i, 1] = P[i] * 1.025;
            }
        }

        public Dinamic(int n, int m, double lyamda, double mu, string file)
            : base(n, m, lyamda, mu)
        {
            readfile(file);
            calc_mkan_och_obc();
            calc_tube();
        }
        public Dinamic(int n, int m, double lyamda, double mu)
            : base(n, m, lyamda, mu)
        {
            CalcPk();
            calc_mkan_och_obc_t();
            calc_tube();
        }
    }
    class PrintStat : Stational
    {
        string filename;
        public PrintStat(int n, int m, double lyamda, double mu, string filename)
            : base(n, m, lyamda, mu) { this.filename = filename; }
        public void PrintFull()
        {
            StreamWriter file = File.AppendText(filename);
            file.WriteLine("Расчитать основные характеристики СМО в стационарном режиме по формулам финальных вероятностей. Сравнить полученные результаты.");
            file.WriteLine("Т.К. число состояний СМО конечно, то в ней существет стационарный режим, и выражения для финальных вероятностей могут быть записаны в следующем виде:");
            file.WriteLine();
            for (int i = 0; i < P.Length; i++)
            {
                file.WriteLine("P{0} = {1}", i, P[i], 5);
            }
            file.WriteLine();
            file.WriteLine("И в сумме они дают единицу.");
            file.WriteLine("Расчитываю основные характеристики:");
            file.WriteLine("Мат. ожидание канала = {0}", Mkan, 5);
            file.WriteLine("Мат. ожидание очереди = {0}", Moch, 5);
            file.WriteLine("Вероятность обслуживания = {0}", Pobc, 5);
            file.WriteLine();
            file.WriteLine();
            file.Close();
        }
        public void PrintShort()
        {
            StreamWriter file = File.AppendText(filename);
            file.WriteLine("n = {0}, m = {1}", N, M);
            for (int i = 0; i < P.Length; i++)
            {
                file.Write("P{0}={1} ", i, P[i]);
            }
            file.WriteLine();
            file.WriteLine("m.кан={0} m.оч={1} Pобс={2}", Mkan, Moch, Pobc);
            file.WriteLine();
            file.Close();
        }
    }
    class PrintDinam : Dinamic
    {
        string filename;
        ZedGraphControl zedGraphControl1;
        public PrintDinam(int n, int m, double lyamda, double mu, string filename, ZedGraphControl zedGraphControl1)
            : base(n, m, lyamda, mu) { this.filename = filename; this.zedGraphControl1 = zedGraphControl1; }
        public void PrintLine(double[] x, double[] y, string name, ZedGraphControl zedGraphControl1)
        {
            zedGraphControl1.GraphPane.CurveList.Clear();
            GraphPane myPane = zedGraphControl1.GraphPane;
            BarItem myCurve1 = myPane.AddBar(name, x, y, Color.Blue);
            myPane.BarSettings.MinClusterGap = 0.0f;
            myPane.Title.Text = "График";
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            zedGraphControl1.Refresh();
        }
        public void PrintLines(double[] x, double[,] y, ZedGraphControl zedGraphControl1)
        {
            Color[] colors = new Color[10];
            colors[0] = Color.Green;
            colors[1] = Color.Blue;
            colors[2] = Color.Red;
            colors[3] = Color.Black;
            colors[4] = Color.Orange;
            colors[5] = Color.Pink;
            colors[6] = Color.Silver;
            colors[7] = Color.Yellow;
            colors[8] = Color.Purple;
            colors[9] = Color.RoyalBlue;

            double[][] lines = new double[y.GetLength(1)][];
            for (int j = 0; j <= N + M; j++)
                lines[j] = new double[y.GetLength(0)];

            for (int i = 0; i < y.GetLength(0); i++)
                for (int j = 0; j <= N + M; j++)
                    lines[j][i] = y[i, j];

            zedGraphControl1.GraphPane.CurveList.Clear();
            GraphPane myPane = zedGraphControl1.GraphPane;
            PointPairList[] spl = new PointPairList[N + M + 1];
            LineItem[] myCurve = new LineItem[N + M + 1];

            for (int j = 0; j <= N + M; j++)
            {
                string name = "P[" + j + "]";
                spl[j] = new PointPairList(x, lines[j]);
                myCurve[j] = myPane.AddCurve(name, spl[j], colors[j % 10], SymbolType.None);
                myCurve[j].Line.Width = 1.0F;
            }

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            zedGraphControl1.Refresh();
        }
        public void PrintPk_t()
        {
            StreamWriter file = File.AppendText(filename);
            file.WriteLine("Для базового варианта СМО с помощью стандартной программы рассчитать значения вероятностей Pk(t). Определить время переходного процесса для 5% трубки. Построить графики зависимости вероятностей, МО занятых каналов, средней длины очереди, вероятности обслуживания как функции времени.");
            file.WriteLine();
            file.WriteLine("Расчет Pk(t) с помощью программы:");
            file.WriteLine("Параметры системы");
            file.WriteLine();
            file.WriteLine("Интенсивность входного потока: {0}", Lyamda);
            file.WriteLine("Число каналов обслуживания: {0}", N);
            file.WriteLine("Интенсивность обслуживания заявок: {0}", Mu);
            file.WriteLine("Число мест в очереди: {0}", M);
            file.WriteLine();
            file.Write("Время\t");
            for (int i = 0; i <= N + M; i++)
                file.Write("P{0}\t", i);
            file.WriteLine();
            for (int i = 0; i < Time.Length; i++)
            {
                file.Write("{0:0.0}\t", Time[i]);
                for (int j = 0; j <= N + M; j++) { file.Write("{0:0.00000}\t", P_t[i, j], 5); }
                file.WriteLine();
            }
            file.WriteLine();
            file.WriteLine("Время переходного процесса = {0:0.0}c.", Time[Time.Length - 1]);
            file.WriteLine();
            file.WriteLine();
            file.Close();
        }
        public void PrintTube()
        {
            StreamWriter file = File.AppendText(filename);
            file.WriteLine("\t Значение\t -2.5%\t\t +2.5%\t");
            for (int i = 0; i <= N + M; i++)
            {
                file.Write("P{0}\t {1:0.00000}\t ", i, P[i]);
                for (int j = 0; j < Tube.GetLength(1); j++)
                { file.Write("{0:0.00000}\t ", Tube[i, j]); }
                file.WriteLine();
            }
            file.WriteLine();
            file.WriteLine();
            file.Close();

            PrintLines(Time, P_t, zedGraphControl1);
            Image bmp = zedGraphControl1.GetImage();
            bmp.Save("Pk(t).bmp");
        }
        public void PrintProperties()
        {
            StreamWriter file = File.AppendText(filename);
            file.WriteLine("Математическое ожидание числа занятых каналов");
            file.WriteLine();
            file.Write("t\t");
            for (int i = 0; i < Time.Length; i++)
                file.Write("{0:0.0}\t", Time[i]);
            file.WriteLine();
            file.Write("m.оч\t");
            for (int i = 0; i < Mkan_t.Length; i++)
                file.Write("{0:0.00000}\t", Mkan_t[i]);
            file.WriteLine();
            file.WriteLine();
            file.WriteLine();

            file.WriteLine("Средняя длина очереди");
            file.WriteLine();
            file.Write("t\t");
            for (int i = 0; i < Time.Length; i++)
                file.Write("{0:0.0}\t", Time[i]);
            file.WriteLine();
            file.Write("m.оч\t");
            for (int i = 0; i < Moch_t.Length; i++)
                file.Write("{0:0.00000}\t", Moch_t[i]);
            file.WriteLine();
            file.WriteLine();
            file.WriteLine();

            file.WriteLine("Вероятность обслуживания как функция времени");
            file.WriteLine();
            file.Write("t\t");
            for (int i = 0; i < Time.Length; i++)
                file.Write("{0:0.0}\t", Time[i]);
            file.WriteLine();
            file.Write("Р.обс\t");
            for (int i = 0; i < Pobc_t.Length; i++)
                file.Write("{0:0.00000}\t", Pobc_t[i]);
            file.WriteLine();
            file.WriteLine();
            file.WriteLine();
            file.Close();

            PrintLine(Time, Mkan_t, "Математическое ожидание каналов", zedGraphControl1);
            Image bmp = zedGraphControl1.GetImage();
            bmp.Save("Матожидание_каналов.bmp");
            PrintLine(Time, Moch_t, "Средняяя длина очереди", zedGraphControl1);
            bmp = zedGraphControl1.GetImage();
            bmp.Save("Средняя_длина_очереди.bmp");
            PrintLine(Time, Pobc_t, "Вероятность обслуживания, как функция времени", zedGraphControl1);
            bmp = zedGraphControl1.GetImage();
            bmp.Save("Вероятность_обслуживания_t.bmp");
        }

    }
}
