using System;

namespace ConsoleApplication1
{
    //классы объемных фигур
    abstract class Space : Figure
    {
        protected double volume; //Объем фигуры
        public abstract double GetVolume();
        public override void ShowInfo()
        {
            Console.WriteLine("Название фигуры {0}", name);
            Console.WriteLine("Количество линий в фигуре {0}", numberlines);
            Console.WriteLine("Объем {0}", volume);
        }
        public Space(string name, int numberlines) : base(name, numberlines) { }
        public string ShowVolume()
        {
            string a = ("Объем фигуры " + name + " = " + volume);
            return a;
        }
    }
}
