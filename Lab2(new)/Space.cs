using System;

namespace DrawingFigures
{
    abstract class Space : Figure
    {
        protected double volume; //Объем фигуры
        public abstract double GetVolume();
        public override void ShowInfo()
        {
            Console.WriteLine("Название фигуры {0}", name);
            Console.WriteLine("Объем {0}", volume);
        }
        public Space(string name, int numberlines) : base(name) { }
        public string ShowVolume()
        {
            string a = ("Объем фигуры " + name + " = " + volume);
            return a;
        }
    }
}
