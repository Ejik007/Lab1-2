using System;
using System.Threading;

namespace ConsoleApplication1
{
    //Классы плоскостных фигур
    class Square : Plane, ShowArea //квадрат
    {
        double side;
        public override double GetArea()
        {
            return this.area = side * side;
        }
        public Square(string name, double side)
            : base("квадрат", 4) //задаваемый конструктор
        {
            this.side = side;
            this.GetArea();
        }
        public Square()
            : base("квадрат", 4) //пользовательский конструктор
        {
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Введите длину стороны квадрата:");
                    this.side = Convert.ToInt16(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверное значение, попробуйте еще раз...");
                    Thread.Sleep(1000);
                }
                if (this.side <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Неверное значение, попробуйте еще раз...");
                    Thread.Sleep(1000);
                }
            }
            while (this.side <= 0);
            this.GetArea();
        }

    }
}
