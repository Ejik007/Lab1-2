using System;
using System.Threading;

namespace DrawingFigures
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
                    Console.WriteLine("Введите длину прямоугольника:");
                    this.sidea = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("Введите ширину прямоугольника:");
                    this.sideb = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("Введите высоту прямоугольника:");
                    this.sidec = Convert.ToInt16(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверное значение, попробуйте еще раз...");
                    Thread.Sleep(1000);
                }
                if ((this.sidea <= 0) || (this.sideb <= 0) || (this.sidec <= 0))
                {
                    Console.WriteLine("Неверное значение, попробуйте еще раз...");
                    Thread.Sleep(1000);
                }
            }
            while ((this.sidea <= 0) || (this.sideb <= 0) || (this.sidec <= 0));
            this.GetVolume();
        }
        public override void Draw()
        {
            // отрисовка куба по ширине ребра
            new DrawingFigures.FrmRender((int)this.sidea, (int)sideb, (int)sidec).ShowDialog();
        }
    }
}
