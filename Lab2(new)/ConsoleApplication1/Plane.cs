using System;

namespace ConsoleApplication1
{
    abstract class Plane : Figure
    {
        protected double area; //Площадь фигуры
        public abstract double GetArea();
        public override void ShowInfo()
        {
            Console.WriteLine("Название фигуры {0}", name);
            Console.WriteLine("Количество линий в фигуре {0}", numberlines);
            Console.WriteLine("Площадь фигуры {0}", area);
        }
        public Plane(string name, int numberlines) : base(name, numberlines) { }
        public string ShowArea()
        {
            string a = ("Площадь фигуры " + name + " = " + area);
            return a;
        }
    }
}
