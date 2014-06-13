﻿using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using ZedGraph;
using StationalDat;
using DynamicDat;
using System.Xml.Serialization;
using System.Collections.Generic;
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


        private void button1_Click(object sender, EventArgs e)
        {
            string filename = "data.txt";
            FileStream fs = File.Create(filename);
            fs.Close();
            int n = (Int16)ValueN.Value;
            int m = (Int16)ValueM.Value;
            double lyamda = (double)ValueLyamda.Value;
            double mu = (double)ValueMu.Value;

            PrintingDynamicData dynamic = new PrintingDynamicData(n, m, lyamda, mu, filename, zedGraphControl1);
            dynamic.PrintPk_t();
            dynamic.PrintTube();
            dynamic.PrintProperties();
            PrintStationaryData stat = new PrintStationaryData(n, m, lyamda, mu, filename);
            stat.PrintFull();

            XmlSerializer xml2 = new XmlSerializer(typeof(PrintingDynamicData));
            using (var fStream = new FileStream("DynamicData.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xml2.Serialize(fStream, dynamic);
            }



            if (radioButtonM.Checked)
            {
                int[] mass_of_m = new int[6];
                mass_of_m[0] = m;
                mass_of_m[1] = (int)m1.Value;
                mass_of_m[2] = (int)m2.Value;
                mass_of_m[3] = (int)m3.Value;
                mass_of_m[4] = (int)m4.Value;
                mass_of_m[5] = (int)m5.Value;
                mass_of_m = mass_of_m.Distinct().ToArray(); //удаляем повторяющиеся элементы
                mass_of_m = mass_of_m.OrderBy(x => x).ToArray(); //сортируем по возрастанию
                PrintStationaryData[] variations = new PrintStationaryData[mass_of_m.Length];
                List<PrintStationaryData> variation = new List<PrintStationaryData>();

                for (int i = 0; i < mass_of_m.Length; i++)
                {
                    variations[i] = new PrintStationaryData(n, mass_of_m[i], lyamda, mu, filename);
                    variations[i].PrintShort();
                    variation.Add(variations[i]);
                }
                XmlSerializer xml3 = new XmlSerializer(variation.GetType());
                using (var fStream = new FileStream("Variation.xml", FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    xml3.Serialize(fStream, variation);
                }
            }
            else
            {
                int[] mass_of_n = new int[6];
                mass_of_n[0] = n;
                mass_of_n[1] = (int)n1.Value;
                mass_of_n[2] = (int)n2.Value;
                mass_of_n[3] = (int)n3.Value;
                mass_of_n[4] = (int)n4.Value;
                mass_of_n[5] = (int)n5.Value;
                mass_of_n = mass_of_n.Distinct().ToArray();
                mass_of_n = mass_of_n.OrderBy(x => x).ToArray();
                PrintStationaryData[] variations = new PrintStationaryData[mass_of_n.Length];
                List<PrintStationaryData> variation = new List<PrintStationaryData>();

                for (int i = 0; i < mass_of_n.Length; i++)
                {
                    if (lyamda / mu / mass_of_n[i] != 1)
                    {
                        variations[i] = new PrintStationaryData(mass_of_n[i], m, lyamda, mu, filename);
                        variations[i].PrintShort();
                        variation.Add(variations[i]);
                    }
                }
                XmlSerializer xml3 = new XmlSerializer(variation.GetType());
                using (var fStream = new FileStream("Variation.xml", FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    xml3.Serialize(fStream, variation);
                }
            }
        }

        private void radioButtonM_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonM.Checked)
            {
                ValuesM.Visible = true;
                ValuesN.Visible = false;
            }
        }

        private void radioButtonN_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonN.Checked)
            {
                ValuesM.Visible = false;
                ValuesN.Visible = true;
            }
        }
    }


    [Serializable]
    public class PrintStationaryData : StationalData
    {
        public string filename;
        public PrintStationaryData(int n, int m, double lyamda, double mu, string filename)
            : base(n, m, lyamda, mu) { this.filename = filename; }
        public void PrintFull()
        {
            StreamWriter file = File.AppendText(filename);
            file.WriteLine("Расчитать основные характеристики СМО в стационарном режиме по формулам финальных вероятностей. Сравнить полученные результаты.");
            file.WriteLine("Т.К. число состояний СМО конечно, то в ней существет стационарный режим, и выражения для финальных вероятностей могут быть записаны в следующем виде:");
            file.WriteLine();
            for (int i = 0; i < Probability.Length; i++)
            {
                file.WriteLine("P{0} = {1}", i, Probability[i], 5);
            }
            file.WriteLine();
            file.WriteLine("И в сумме они дают единицу.");
            file.WriteLine("Расчитываю основные характеристики:");
            file.WriteLine("Мат. ожидание канала = {0}", MathWaitСanal, 5);
            file.WriteLine("Мат. ожидание очереди = {0}", MathWaitTurn, 5);
            file.WriteLine("Вероятность обслуживания = {0}", PService, 5);
            file.WriteLine();
            file.WriteLine();
            file.Close();
        }
        public void PrintShort()
        {
            StreamWriter file = File.AppendText(filename);
            file.WriteLine("n = {0}, m = {1}", N, M);
            for (int i = 0; i < Probability.Length; i++)
            {
                file.Write("P{0}={1} ", i, Probability[i]);
            }
            file.WriteLine();
            file.WriteLine("m.кан={0} m.оч={1} Pобс={2}", MathWaitСanal, MathWaitTurn, PService);
            file.WriteLine();
            file.Close();
        }
        public PrintStationaryData() { }
    }

    [Serializable]
    public class PrintingDynamicData : Dynamic
    {
        public string filename = "";
        ZedGraphControl zedGraphControl1;
        public PrintingDynamicData(int n, int m, double lyamda, double mu, string filename, ZedGraphControl zedGraphControl1)
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

            zedGraphControl1.GraphPane.CurveList.Clear();
            GraphPane myPane = zedGraphControl1.GraphPane;
            PointPairList[] spl = new PointPairList[N + M + 1];
            LineItem[] myCurve = new LineItem[N + M + 1];

            double[] K1, K2, K3, K4;
            double h = 0.001;
            double hstat = 0.1;
            double sumdelta, delta;

            double t = 0;
            double[] Pk_tstring = new double[M + N + 1];
            int delt = 0;
            for (int j = 0; j <= N + M; j++)
            {
                if (j == 0) { Pk_tstring[j] = 1; spl[j] = new PointPairList(); spl[j].Add(t, 1); }
                else { Pk_tstring[j] = 0; spl[j] = new PointPairList(); spl[j].Add(t, 0); }
            }

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
                sumdelta = 0;
                for (int j = 0; j <= N + M; j++)
                {
                    delta = h * (K1[j] + 2 * K2[j] + 2 * K3[j] + K4[j]) / 6;
                    sumdelta += Math.Abs(delta);
                    Pk_tstring[j] += delta;
                    spl[j].Add(t, Pk_tstring[j]);
                }
                if (statsum == 0) { delt++; }
            }
            while ((t < 100) && (sumdelta > (h / 10)));

            for (int j = 0; j <= N + M; j++)
            {
                string name = "P[" + j + "]";
                myCurve[j] = myPane.AddCurve(name, spl[j], colors[j % 10], SymbolType.None);
                myCurve[j].Line.Width = 1.5F;
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
                for (int j = 0; j <= N + M; j++) { file.Write("{0:0.00000}\t", ProbabilityTime[i, j], 5); }
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
                file.Write("P{0}\t {1:0.00000}\t ", i, Probability[i]);
                for (int j = 0; j < FivePerCentTube.GetLength(1); j++)
                { file.Write("{0:0.00000}\t ", FivePerCentTube[i, j]); }
                file.WriteLine();
            }
            file.WriteLine();
            file.WriteLine();
            file.Close();

            PrintLines(Time, ProbabilityTime, zedGraphControl1);
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
            for (int i = 0; i < MathWaitCanalTime.Length; i++)
                file.Write("{0:0.00000}\t", MathWaitCanalTime[i]);
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
            for (int i = 0; i < MathWaitTurnTime.Length; i++)
                file.Write("{0:0.00000}\t", MathWaitTurnTime[i]);
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
            for (int i = 0; i < PServiceTime.Length; i++)
                file.Write("{0:0.00000}\t", PServiceTime[i]);
            file.WriteLine();
            file.WriteLine();
            file.WriteLine();
            file.Close();

            PrintLine(Time, MathWaitCanalTime, "Математическое ожидание каналов", zedGraphControl1);
            Image bmp = zedGraphControl1.GetImage();
            bmp.Save("Матожидание_каналов.bmp");
            PrintLine(Time, MathWaitTurnTime, "Средняяя длина очереди", zedGraphControl1);
            bmp = zedGraphControl1.GetImage();
            bmp.Save("Средняя_длина_очереди.bmp");
            PrintLine(Time, PServiceTime, "Вероятность обслуживания, как функция времени", zedGraphControl1);
            bmp = zedGraphControl1.GetImage();
            bmp.Save("Вероятность_обслуживания_t.bmp");
        }
        public PrintingDynamicData() : base() { }
    }

}
