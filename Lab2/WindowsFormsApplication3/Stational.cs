using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Stationaldat
{
    [Serializable]
    public class StationalData
    {
        int n = 1;               //Количество каналов 
        int m = 1;               //Количество мест в очереди
        double lyamda = 1;       //Интенсивность входного потока
        double mu = 1;           //Интенсивность обслуживания
        double ro = 1;           // lyamda/mu
        double[] probability;    //Вероятность нахождения в системе К требований
        double math_wait_canal;  //Математическое ожидание канала
        double math_wait_turn;   //Математическое ожидание очереди
        double p_of_service;     //Вероятность обслуживания = 1 - Вероятность отказа

        public int N
        {
            get { return this.n; }
            set { this.n = value; }
        }
        public int M
        {
            get { return this.m; }
            set { this.m = value; }
        }
        public double Lyamda
        {
            get { return this.lyamda; }
            set { this.lyamda = value; }
        }
        public double Mu
        {
            get { return this.mu; }
            set { this.mu = value; }
        }
        public double[] Probability
        {
            get { return this.probability; }
            set { this.probability = value; }
        }
        public double Math_wait_canal
        {
            get { return this.math_wait_canal; }
            set { this.math_wait_canal = value; }
        }
        public double Math_wait_turn
        {
            get { return this.math_wait_turn; }
            set { this.math_wait_turn = value; }
        }
        public double P_of_service
        {
            get { return this.p_of_service; }
            set { this.p_of_service = value; }
        }

        long Fact(int n) //Вычисление факториала
        {
            long x = 1;
            for (int i = 1; i <= n; i++)
                x *= i;
            return x;
        }

        public void calculation_properties() //Вычисление математического ожидания канала, очереди, вероятности обслуживания
        {
            math_wait_canal = 0;
            for (int k = 0; k < n; k++)
            {
                math_wait_canal += k * probability[k];
            }
            math_wait_turn = 0;
            for (int k = n; k <= n + m; k++)
            {
                math_wait_canal += n * probability[k];
                math_wait_turn += (k - n) * probability[k];
            }
            p_of_service = 1 - probability[m + n];
        }

        void calculate_of_probability() //Расчет стационарных значений вероятностей
        {   
            probability[0] = 1;  //Расчет нулевого значения
            for (int k = 1; k < n; k++)
            {
                probability[0] += Math.Pow(ro, k) / Fact(k);
            }
            probability[0] += Math.Pow(ro, n) / Fact(n) * ((1 - Math.Pow(ro / n, m + 1)) / (1 - ro / n));
            probability[0] = Math.Pow(probability[0], -1);
            //Расчет остальных значений (зависят от нулевого)
            for (int k = 1; k <= n; k++)
            {
                probability[k] = (Math.Pow(ro, k) / Fact(k)) * probability[0];
            }
            for (int k = n + 1; k <= n + m; k++)
            {
                probability[k] = (Math.Pow(ro, n) / Fact(n)) * Math.Pow(ro / n, k - n) * probability[0];
            }
            calculation_properties(); //Расчет остальных параметров использую значения вероятностей
        }
        public StationalData(int n, int m, double lyamda, double mu)
        {
            this.n = n;
            this.m = m;
            this.lyamda = lyamda;
            this.mu = mu;
            this.ro = this.lyamda / this.mu;
            this.probability = new double[m + n + 1];
            calculate_of_probability();
        }
        public StationalData() { }
    }

}
