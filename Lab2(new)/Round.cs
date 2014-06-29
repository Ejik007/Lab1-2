using System;
using System.Threading;

namespace DrawingFigures
{
    class Round : Plane, ShowArea //круг
    {
        double radius;
        public override double GetArea()
        {
            return this.area = Math.PI * radius * radius;
        }
        public Round(string name, int numberlines, double radius)
            : base("круг", 0) //задаваемый конструктор
        {
            this.radius = radius;
            this.GetArea();
        }
        public Round()
            : base("круг", 1) //пользовательский конструктор
        {
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Введите радиус круга:");
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
            this.GetArea();
        }
        public override void Draw()
        {
            new DrawingFigures.frmFlat(DrawingFigures.FigureType.round, (int)this.radius).ShowDialog();
        }
    }
}
