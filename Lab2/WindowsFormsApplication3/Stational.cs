using System;

namespace StationalDat
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
        double mathwaitсanal;  //Математическое ожидание канала
        double mathwaitturn;   //Математическое ожидание очереди
        double pservice;     //Вероятность обслуживания = 1 - Вероятность отказа

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
        public double MathWaitСanal
        {
            get { return this.mathwaitсanal; }
            set { this.mathwaitсanal = value; }
        }
        public double MathWaitTurn
        {
            get { return this.mathwaitturn; }
            set { this.mathwaitturn = value; }
        }
        public double PService
        {
            get { return this.pservice; }
            set { this.pservice = value; }
        }

        long Fact(int n) //Вычисление факториала
        {
            long x = 1;
            for (int i = 1; i <= n; i++)
                x *= i;
            return x;
        }

        public void CalculationProperties() //Вычисление математического ожидания канала, очереди, вероятности обслуживания
        {
            mathwaitсanal = 0;
            for (int k = 0; k < n; k++)
            {
                mathwaitсanal += k * probability[k];
            }
            mathwaitturn = 0;
            for (int k = n; k <= n + m; k++)
            {
                mathwaitсanal += n * probability[k];
                mathwaitturn += (k - n) * probability[k];
            }
            pservice = 1 - probability[m + n];
        }

        void CalculateProbability() //Расчет стационарных значений вероятностей
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
            CalculationProperties(); //Расчет остальных параметров использую значения вероятностей
        }
        public StationalData(int n, int m, double lyamda, double mu)
        {
            this.n = n;
            this.m = m;
            this.lyamda = lyamda;
            this.mu = mu;
            this.ro = this.lyamda / this.mu;
            this.probability = new double[m + n + 1];
            CalculateProbability();
        }
        public StationalData() { }
    }

}
