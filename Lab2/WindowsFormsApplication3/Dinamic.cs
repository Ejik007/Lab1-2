using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stationaldat;
using System.Xml.Serialization;

namespace Dinamicdat
{
    [Serializable]
    public class Dinamic : StationalData
    {
        //Значения данных, зависимых от времени системы
        double[] time; 
        double[,] probability_of_time; 
        double[] math_wait_canal_of_time; 
        double[] math_wait_turn_of_time;
        double[] p_of_service_of_time;
        double[,] five_per_cent_tube; //Значения пятипроцентной трубки

        public double[,] Five_per_cent_tube
        {
            get { return this.five_per_cent_tube; }
            set { this.five_per_cent_tube = value; }
        }
        public double[,] Probability_of_time
        {
            get { return this.probability_of_time; }
            set { this.probability_of_time = value; }
        }
        public double[] Time
        {
            get { return this.time; }
            set { this.time = value; }
        }
        public double[] Math_wait_canal_of_time
        {
            get { return this.math_wait_canal_of_time; }
            set { this.math_wait_canal_of_time = value; }
        }
        public double[] Math_wait_turn_of_time
        {
            get { return this.math_wait_turn_of_time; }
            set { this.math_wait_turn_of_time = value; }
        }
        public double[] P_of_service_of_time
        {
            get { return this.p_of_service_of_time; }
            set { this.p_of_service_of_time = value; }
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

        void Calculation_of_properties_of_time()
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

            probability_of_time = new double[delt + 1, N + M + 1];
            probability_of_time[0, 0] = 1;
            for (int j = 1; j < N + M + 1; j++)
                probability_of_time[0, j] = 0;
            time = new double[delt + 1];
            time[0] = 0;
            for (int j = 0; j < delt; j++)
            {
                for (int k = 0; k <= N + M; k++) { probability_of_time[j + 1, k] = Pk_t[j, k]; }
                time[j + 1] = Time_[j];
            }
        }
        
        /* 
         * Процедура не будет переделываться под сериализацию, так как предназначена 
         * для считывания файла с данными, которые выдавала исходная программа на Delphi
         * на случай если не получилось бы переписать код с Delphi на C#
         */ 
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
            probability_of_time = new double[mass.GetLength(0), mass.GetLength(1) - 1];
            for (int i = 0; i < mass.GetLength(0); i++)
                for (int j = 1; j < mass.GetLength(1); j++)
                {
                    probability_of_time[i, j - 1] = mass[i, j];
                }
        }

        void calculation_properties_of_time() //вычисление величин зависящих от времени
        {
            math_wait_canal_of_time = new double[probability_of_time.GetLength(0)];
            math_wait_turn_of_time = new double[probability_of_time.GetLength(0)];
            p_of_service_of_time = new double[probability_of_time.GetLength(0)];
            for (int i = 0; i < probability_of_time.GetLength(0); i++)
            {
                math_wait_canal_of_time[i] = 0;
                for (int k = 0; k < N; k++)
                {
                    math_wait_canal_of_time[i] += k * probability_of_time[i, k];
                }
                math_wait_turn_of_time[i] = 0;
                double summ = 0;
                for (int k = N; k <= N + M; k++)
                {
                    summ += probability_of_time[i, k];
                    math_wait_turn_of_time[i] += (k - N) * probability_of_time[i, k];
                }
                math_wait_canal_of_time[i] += N * summ;
                p_of_service_of_time[i] = 1 - probability_of_time[i, M + N];
            }
        }

        void calc_five_per_cent_tube()
        {
            five_per_cent_tube = new double[N + M + 1, 2];
            for (int i = 0; i <= N + M; i++)
            {
                five_per_cent_tube[i, 0] = Probability[i] * 0.975;
                five_per_cent_tube[i, 1] = Probability[i] * 1.025;
            }
        }
        
        public Dinamic(int n, int m, double lyamda, double mu, string file) //Расчет данных производится на основе входного файла из другой программы
            : base(n, m, lyamda, mu)
        {
            readfile(file);
            calculation_properties();
            calc_five_per_cent_tube();
        }
        public Dinamic(int n, int m, double lyamda, double mu) //Данные расчитываются самостоятельно
            : base(n, m, lyamda, mu)
        {
            Calculation_of_properties_of_time();
            calculation_properties_of_time();
            calc_five_per_cent_tube();
        }
        public Dinamic() { }
    }
}
