using System;
using StationalDat;
using System.Collections.Generic;

namespace DynamicDat
{
    [Serializable]
    public class Dynamic : StationalData
    {
        //Значения данных, зависимых от времени системы
        double[] time;
        double[,] probabilitytime;
        double[] mathwaitcanaltime;
        double[] mathwaitturnoftime;
        double[] pservicetime;
        double[,] fivepercenttube; //Значения пятипроцентной трубки

        //Дополнительные переменные для сериализации
        double[] tubeup, tubedown;
        List<double[]> probabilitytimeline = new List<double[]>();

        public double[] TubeUp
        {
            get { return this.tubeup; }
            set { this.tubeup = value; }
        }
        public double[] TubeDown
        {
            get { return this.tubedown; }
            set { this.tubedown = value; }
        }
        public List<double[]>  ProbabilitytimeLine
        {
            get { return this.probabilitytimeline; }
            set { this.probabilitytimeline = value; }
        }

        public double[,] FivePerCentTube
        {
            get { return this.fivepercenttube; }
        }
        public double[,] ProbabilityTime
        {
            get { return this.probabilitytime; }
        }
        public double[] Time
        {
            get { return this.time; }
            set { this.time = value; }
        }
        public double[] MathWaitCanalTime
        {
            get { return this.mathwaitcanaltime; }
            set { this.mathwaitcanaltime = value; }
        }
        public double[] MathWaitTurnTime
        {
            get { return this.mathwaitturnoftime; }
            set { this.mathwaitturnoftime = value; }
        }
        public double[] PServiceTime
        {
            get { return this.pservicetime; }
            set { this.pservicetime = value; }
        }
        //Просьба строго не судить, код переделывался с Delphi
        protected double[] f(double[] CurP)
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

        protected double[] VectAM(double[] V1, double[] V2, double C)
        {
            double[] mass = new double[V1.Length];
            for (int i = 0; i < V1.Length - 1; i++)
                mass[i] = V1[i] + C * V2[i];
            return mass;
        }

        void CalculationProbabilityTime()
        {
            double[] K1, K2, K3, K4;
            double h = 0.001; //Шаг интегрирования
            double hstat = 0.1; //Времянной интервал записи данных
            double sumdelta, delta;


            double[,] Pk_t = new double[1100, M + N + 1];
            double[] Pk_tstring = new double[M + N + 1];
            int delt = 0;
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
                if (statsum == 0) { Time_[delt] = t; }
                sumdelta = 0;
                for (int j = 0; j <= N + M; j++)
                {
                    delta = h * (K1[j] + 2 * K2[j] + 2 * K3[j] + K4[j]) / 6;
                    sumdelta += Math.Abs(delta);
                    Pk_tstring[j] += delta;
                    if (statsum == 0)
                    {
                        Pk_t[delt, j] = Pk_tstring[j];
                    }
                }
                if (statsum == 0) { delt++; }
            }
            while ((t < 100) && (sumdelta > (h / 10)));

            probabilitytime = new double[delt + 1, N + M + 1];
            probabilitytime[0, 0] = 1;
            for (int j = 1; j < N + M + 1; j++)
                probabilitytime[0, j] = 0;
            time = new double[delt + 1];
            time[0] = 0;
            for (int j = 0; j < delt; j++)
            {
                for (int k = 0; k <= N + M; k++) { probabilitytime[j + 1, k] = Pk_t[j, k]; }
                time[j + 1] = Time_[j];
            }
            //Преобразовываем объект для сериализации
            for (int j = 0; j <= N + M; j++ )
            {
                double[] Pj = new double[probabilitytime.GetLength(0)];
                for (int i = 0; i < probabilitytime.GetLength(0); i++ )
                { Pj[i] = probabilitytime[i, j]; }
                probabilitytimeline.Add(Pj);
            }

        }

        /* 
         * Процедура не будет переделываться под сериализацию, так как предназначена 
         * для считывания файла с данными, которые выдавала исходная программа на Delphi.
         * Писалась на случай если бы не получилось переписать код с Delphi на C#
          
        void ReadFile(string file)
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
            probabilitytime = new double[mass.GetLength(0), mass.GetLength(1) - 1];
            for (int i = 0; i < mass.GetLength(0); i++)
                for (int j = 1; j < mass.GetLength(1); j++)
                {
                    probabilitytime[i, j - 1] = mass[i, j];
                }
        }
        */
        void СalculationPropertiesTime() //вычисление величин зависящих от времени
        {
            mathwaitcanaltime = new double[probabilitytime.GetLength(0)];
            mathwaitturnoftime = new double[probabilitytime.GetLength(0)];
            pservicetime = new double[probabilitytime.GetLength(0)];
            for (int i = 0; i < probabilitytime.GetLength(0); i++)
            {
                mathwaitcanaltime[i] = 0;
                for (int k = 0; k < N; k++)
                {
                    mathwaitcanaltime[i] += k * probabilitytime[i, k];
                }
                mathwaitturnoftime[i] = 0;
                double summ = 0;
                for (int k = N; k <= N + M; k++)
                {
                    summ += probabilitytime[i, k];
                    mathwaitturnoftime[i] += (k - N) * probabilitytime[i, k];
                }
                mathwaitcanaltime[i] += N * summ;
                pservicetime[i] = 1 - probabilitytime[i, M + N];
            }
        }

        void CalcFivePerCentTube()
        {
            fivepercenttube = new double[N + M + 1, 2];
            
            tubeup = new double[N + M + 1];
            tubedown = new double[N + M + 1];
            for (int i = 0; i <= N + M; i++)
            {
                fivepercenttube[i, 0] = Probability[i] * 0.975;
                tubedown[i] = fivepercenttube[i, 0];
                fivepercenttube[i, 1] = Probability[i] * 1.025;
                tubeup[i] = fivepercenttube[i, 1];
            }
        }
        /*
        public Dynamic(int n, int m, double lyamda, double mu, string file) //Расчет данных производится на основе входного файла из другой программы
            : base(n, m, lyamda, mu)
        {
            ReadFile(file);
            CalculationProperties();
            CalcFivePerCentTube();
        }
        */
        public Dynamic(int n, int m, double lyamda, double mu) //Данные расчитываются самостоятельно
            : base(n, m, lyamda, mu)
        {
            CalculationProbabilityTime();
            СalculationPropertiesTime();
            CalcFivePerCentTube();
        }
        public Dynamic() { }
    }
}
