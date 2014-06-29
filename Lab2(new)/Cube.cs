using System;
using System.Threading;

namespace DrawingFigures
{
    class Cube : Space, ShowVolume //куб
    {
        double side;
        public override double GetVolume()
        {
            return this.volume = side * side * side;
        }
        public Cube(string name, int numberlines, double side)
            : base(name, numberlines) //задаваемый конструктор
        {
            this.side = side;
            this.GetVolume();
        }
        public Cube()
            : base("куб", 12)
        {
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Введите длину стороны куба:");
                    this.side = Convert.ToInt16(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверное значение, попробуйте еще раз...");
                    Thread.Sleep(1000);
                }
                if (this.side <= 0)
                {
                    Console.WriteLine("Неверное значение, попробуйте еще раз...");
                    Thread.Sleep(1000);
                }
            }
            while (this.side <= 0);
            this.GetVolume();
        }

        public override void Draw()
        {
            // отрисовка куба по ширине ребра
            new DrawingFigures.FrmRender((int)this.side).ShowDialog();
        }
    }
}
