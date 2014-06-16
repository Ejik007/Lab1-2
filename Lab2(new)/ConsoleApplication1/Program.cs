using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{   
    //Абстрактный класс фигура
    abstract class Figure
    {
        protected string name; //название фигуры
        protected int numberlines; //Количество линий в фигуре
        //Конструктор класса
        public Figure( string name, int numberlines)
        {
            this.name = name;
            this.numberlines = numberlines;
        }
        public abstract void GetInfo();
    }
    
    abstract class Plane : Figure
    {
        protected double area; //Площадь фигуры
        public abstract double GetArea();
        public override void GetInfo()
        {
            Console.WriteLine("Название фигуры {0}", name);
            Console.WriteLine("Количество линий в фигуре {0}", numberlines);
            Console.WriteLine("Площадь фигуры {0}", area);
        }
        public Plane(string name, int numberlines) : base( name, numberlines) {}
        public string ShowArea()
        {
            string a = ("Площадь фигуры " + name + " = " + area);
            return a;        
        }
    }

    abstract class Space : Figure
    {
        protected double volume; //Объем фигуры
        public abstract double GetVolume();
        public override void GetInfo()
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
    //Классы плоскостных фигур
    class Square : Plane, ShowArea //квадрат
    {
        double side;
        public override double GetArea()
        {
            return this.area = side * side;
        }
        public Square(string name, int numberlines, double side ) :base( name, numberlines)
        {
            this.side = side;
            this.GetArea();
        }
    }
    class Rectangle : Plane, ShowArea //прямоугольник
    {
        double sidea;
        double sideb;
        public override double GetArea()
        {
            return this.area = sidea * sideb;
        }
        public Rectangle(string name, int numberlines, double sidea, double sideb)
            : base(name, numberlines)
        {
            this.sidea = sidea;
            this.sideb = sideb;
            this.GetArea();
        }
    }
    class Round : Plane, ShowArea //круг
    {
        double radius;
        public override double GetArea()
        {
            return this.area = Math.PI * radius * radius;
        }
        public Round(string name, int numberlines, double radius) : base( name, numberlines)
        {
            this.radius =radius;
            this.GetArea();
        }
    }

    //классы объемных фигур
    class Cube : Space, ShowVolume //куб
    {
        double side;
        public override double GetVolume()
        {
            return this.volume = side * side * side;
        }
        public Cube(string name, int numberlines, double side ) :base( name, numberlines)
        {
            this.side = side;
            this.GetVolume();
        }
    }
    class Cuboid : Space, ShowVolume //прямоугольный параллелепипед
    {
        double sidea;
        double sideb;
        double sidec;
        public override double GetVolume()
        {
            return this.volume = sidea * sideb * sidec;
        }
        public Cuboid(string name, int numberlines, double sidea, double sideb, double sidec) :base( name, numberlines)
        {
            this.sidea = sidea;
            this.sideb = sideb;
            this.sidec = sidec;
            this.GetVolume();
        }
    }
    class Ball : Space, ShowVolume //шар
    {
        double radius;
        public override double GetVolume()
        {
            return this.volume = 4 / 3 * Math.PI * Math.Pow(radius, 3);
        }
        public Ball(string name, int numberlines, double radius) :base( name, numberlines)
        {
            this.radius = radius;
            this.GetVolume();
        }
    }
    //интерфейсы
    public interface ShowArea
    {
        string ShowArea();
    }
    public interface ShowVolume
    {
        string ShowVolume();
    }
    class Program
    {
        static void Main(string[] args)
        {
            //инициализируем плоскостные объекты и выводим о них информацию
            Console.WriteLine("Двумерные объекты:");
            Console.WriteLine("****************************");
            Square square = new Square("квадрат", 4, 3);
            square.GetInfo();
            Console.WriteLine("****************************");
            Rectangle rectangle = new Rectangle("прямоугольник", 4, 3, 2);
            rectangle.GetInfo();
            Console.WriteLine("****************************");
            Round round = new Round("круг", 1, 2.5);
            round.GetInfo();
            Console.WriteLine();
            //инициализируем объемные объекты и выводим о них информацию
            Console.WriteLine("Трехмерные объекты:");
            Console.WriteLine("****************************");
            Cube cube = new Cube("куб", 12, 3);
            cube.GetInfo();
            Console.WriteLine("****************************");
            Cuboid cuboid = new Cuboid("прямоугольный параллелепипед", 12, 3, 4, 5);
            cuboid.GetInfo();
            Console.WriteLine("****************************");
            Ball ball = new Ball("шар", 0, 2.5);
            ball.GetInfo();
            Console.WriteLine();
            //Выполним методы показать объем/площадь
            Console.WriteLine(square.ShowArea());
            Console.WriteLine(rectangle.ShowArea());
            Console.WriteLine(round.ShowArea());
            Console.WriteLine();
            Console.WriteLine(cube.ShowVolume());
            Console.WriteLine(cuboid.ShowVolume());
            Console.WriteLine(ball.ShowVolume());
            Console.ReadLine();
        }
    }
}