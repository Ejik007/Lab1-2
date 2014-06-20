using System;
using System.Threading;

namespace ConsoleApplication1
{
    class Cuboid : Space, ShowVolume //прямоугольный параллелепипед
    {
        double sidea;
        double sideb;
        double sidec;
        public override double GetVolume()
        {
            return this.volume = sidea * sideb * sidec;
        }
        public Cuboid(string name, int numberlines, double sidea, double sideb, double sidec)
            : base("параллелепипед", 12) //задаваемый конструктор
        {
            this.sidea = sidea;
            this.sideb = sideb;
            this.sidec = sidec;
            this.GetVolume();
        }
        public Cuboid()
            : base("параллелепипед", 12) //пользовательский конструктор
        {
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Введите длину параллелепипеда:");
                    this.sidea = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("Введите ширину параллелепипеда:");
                    this.sideb = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("Введите высоту параллелепипеда:");
                    this.sidec = Convert.ToInt16(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверное значение, попробуйте еще раз...");
                    Thread.Sleep(1000);
                }
                if ((this.sidea <= 0) || (this.sideb <= 0) || (this.sidec <= 0))
                {
                    Console.Clear();
                    Console.WriteLine("Неверное значение, попробуйте еще раз...");
                    Thread.Sleep(1000);
                }
            }
            while ((this.sidea <= 0) || (this.sideb <= 0) || (this.sidec <= 0));
            this.GetVolume();
        }
    }
}
