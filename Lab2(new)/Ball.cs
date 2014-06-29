using System;
using System.Threading;

namespace DrawingFigures
{
    class Ball : Space, ShowVolume //шар
    {
        double radius;
        public override double GetVolume()
        {
            return this.volume = 4 / 3 * Math.PI * Math.Pow(radius, 3);
        }
        public Ball(string name, int numberlines, double radius)
            : base("шар", 0) //задаваемый конструктор
        {
            this.radius = radius;
            this.GetVolume();
        }
        public Ball()
            : base("шар", 0) //пользовательский конструктор
        {
            do
            {
                try
                {
                    Console.Clear();
                    //#dev
                    Console.WriteLine("Введите радиус шара(от 0 до 2 в условных единицах):");
                    this.radius = Convert.ToInt16(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверное значение, попробуйте еще раз...");
                    Thread.Sleep(1000);
                }
                if (this.radius <= 0)
                {
                    Console.WriteLine("Неверное значение, попробуйте еще раз...");
                    Thread.Sleep(1000);
                }
            }
            while (this.radius <= 0);
            this.GetVolume();
        }
        public override void Draw()
        {
            FrmMain form = new FrmMain(this.radius);
            form.ShowDialog();
        }
    }
}
