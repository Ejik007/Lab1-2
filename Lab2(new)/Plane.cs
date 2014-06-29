using System;

namespace DrawingFigures
{
    abstract class Plane : Figure
    {
        protected double area; //Площадь фигуры
        public abstract double GetArea();
        public override void ShowInfo()
        {
            Console.WriteLine("Название фигуры {0}", name);
            Console.WriteLine("Площадь фигуры {0}", area);
        }
        public Plane(string name, int numberlines) : base(name) { }
        public string ShowArea()
        {
            string a = ("Площадь фигуры " + name + " = " + area);
            return a;
        }
    }
}
