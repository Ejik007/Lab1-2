﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using _DCubeNoGimbalLock;
using Spheres;


namespace ConsoleApplication1
{
    //Абстрактный класс фигура
    abstract class Figure
    {
        protected string name; //название фигуры
        //Конструктор класса
        public Figure(string name)
        {
            this.name = name;
        }
        public abstract void ShowInfo();
        public abstract void Draw();
    }

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
                    Console.WriteLine("Неверное значение, попробуйте еще раз...");
                    Thread.Sleep(1000);
                }
            }
            while (this.side <= 0);
            this.GetArea();
        }
        public override void Draw()
        {
            new _DCubeNoGimbalLock.frmFlat(_DCubeNoGimbalLock.FigureType.square, (int)this.side).ShowDialog();
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
        public Rectangle(string name, double sidea, double sideb)
            : base("прямоугольник", 4) //задаваемый конструктор
        {
            this.sidea = sidea;
            this.sideb = sideb;
            this.GetArea();
        }
        public Rectangle()
            : base("прямоугольник", 4) //пользовательский конструктор
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
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверное значение, попробуйте еще раз...");
                    Thread.Sleep(1000);
                }
                if ((this.sidea <= 0) || (this.sideb <= 0))
                {
                    Console.WriteLine("Неверное значение, попробуйте еще раз...");
                    Thread.Sleep(1000);
                }
            }
            while ((this.sidea <= 0) || (this.sideb <= 0));
            this.GetArea();
        }
        public override void Draw()
        {
            new _DCubeNoGimbalLock.frmFlat(_DCubeNoGimbalLock.FigureType.rectangle, 0,(int)this.sidea,(int)this.sideb).ShowDialog();
        }
    }
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
            new _DCubeNoGimbalLock.frmFlat(_DCubeNoGimbalLock.FigureType.round,(int) this.radius).ShowDialog();
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
            new _DCubeNoGimbalLock.FrmRender((int)this.side).ShowDialog();
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
            new _DCubeNoGimbalLock.FrmRender((int)this.sidea,(int)sideb,(int)sidec).ShowDialog();
        }
    }
    class Ball : Space, ShowVolume //шар
    {
        double radius;
        public override double GetVolume()
        {
            return this.volume = 4 / 3 * Math.PI * Math.Pow(radius, 3);
        }
        public Ball(string name, int numberlines, double radius)
            : base("шар", 0) //задаваемый конструктор
        {
            this.radius = radius;
            this.GetVolume();
        }
        public Ball()
            : base("шар", 0) //пользовательский конструктор
        {
            do
            {
                try
                {
                    Console.Clear(); 
                    //#dev
                    Console.WriteLine("Введите радиус шара(от 0 до 2 в условных единицах):");
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
            this.GetVolume();
        }
        public override void Draw()
        {
            FrmMain form = new FrmMain(this.radius);
            form.ShowDialog();
        }
    }
    //интерфейсы
    public interface ShowArea
    {
        string ShowArea(); //По
    }
    public interface ShowVolume
    {
        string ShowVolume();
    }

    class Program
    {

        public enum level { level0, level1, level2, square, rectangle, round, cube, cuboid, ball, exit };

        private static void ShowMenu(level l)
        {
            Console.Clear();
            switch (l)
            {
                case level.level0:
                    Console.WriteLine("************* Меню **************");
                    Console.WriteLine("Инфомация по двумерным фигурам --> 1");
                    Console.WriteLine("Информация по объемным фигурам --> 2");
                    Console.WriteLine("Выход                          --> 0");
                    Levels(l, level.level1, level.level2, level.exit); break;
                case level.level1:
                    Console.Clear();
                    Console.WriteLine("************* Плоскостные фигуры **************");
                    Console.WriteLine("Информация о квадрате          --> 1");
                    Console.WriteLine("Информация о прямоугольнике    --> 2");
                    Console.WriteLine("Информация о круге             --> 3");
                    Console.WriteLine("Переход на предыдущее меню     --> 0");
                    Levels(l, level.square, level.rectangle, level.round, level.level0); break;
                case level.level2:
                    Console.Clear();
                    Console.WriteLine("************* Объемные фигуры **************");
                    Console.WriteLine("Информация о кубе              --> 1");
                    Console.WriteLine("Информация о параллелепипеде   --> 2");
                    Console.WriteLine("Информация о шаре              --> 3");
                    Console.WriteLine("Переход на предыдущее меню     --> 0");
                    Levels(l, level.cube, level.cuboid, level.ball, level.level0); break;
                case level.square:
                    Square square = new Square();
                    square.ShowInfo();
                    square.ShowArea();
                    //#dev
                    Console.WriteLine("Отрисовать?Y/N");
                    string com = Console.ReadLine();
                    if (com == "Y")
                        square.Draw();
                    Console.ReadLine();
                    ShowMenu(level.level1);
                    break;
                case level.rectangle:
                    Rectangle rectangle = new Rectangle();
                    rectangle.ShowInfo();
                    rectangle.ShowArea();
                    //#dev
                    Console.WriteLine("Отрисовать?Y/N");
                    com = Console.ReadLine();
                    if (com == "Y")
                        rectangle.Draw();
                    Console.ReadLine();
                    ShowMenu(level.level1);
                    break;
                case level.round:
                    Round round = new Round();
                    round.ShowInfo();
                    round.ShowArea();
                    //#dev
                    Console.WriteLine("Отрисовать?Y/N");
                    com = Console.ReadLine();
                    if (com == "Y")
                        round.Draw();
                    Console.ReadLine();
                    ShowMenu(level.level1);
                    break;
                case level.cube:
                    Cube cube = new Cube();
                    cube.ShowInfo();
                    cube.ShowVolume();
                    //#dev
                    Console.WriteLine("Отрисовать?Y/N");
                    com = Console.ReadLine();
                    if ( com == "Y")
                        cube.Draw();

                    Console.ReadLine();
                    ShowMenu(level.level2);
                    break;
                case level.cuboid:
                    Cuboid cuboid = new Cuboid();
                    cuboid.ShowInfo();
                    cuboid.ShowVolume();
                    //#dev
                    Console.WriteLine("Отрисовать?Y/N");
                    com = Console.ReadLine();
                    if (com == "Y")
                        cuboid.Draw();

                    Console.ReadLine();
                    ShowMenu(level.level2);
                    break;
                case level.ball:
                    Ball ball = new Ball();
                    ball.ShowInfo();
                    ball.ShowVolume();
                    //#dev
                    Console.WriteLine("Отрисовать?Y/N");
                    com = Console.ReadLine();
                    if (com == "Y")
                        ball.Draw();

                    Console.ReadLine();
                    ShowMenu(level.level2);
                    break;
                case level.exit: break;
                default: Console.WriteLine("Уровень не существует"); break;
            }
        }
        /// <summary>Уровни</summary>
        /// <param name="l">Текущий уровень</param>
        /// <param name="l1">Следующий уровень</param>
        /// <param name="l2">Предыдущий уровень, или тот же или строка</param>
        private static void Levels(level l, level l1, level l2, level l3)
        {
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            cki = Console.ReadKey();    // Считываем нажатую клавишу
            if (cki.Key != ConsoleKey.D0 &&
                cki.Key != ConsoleKey.D1 &&
                cki.Key != ConsoleKey.D2) ShowMenu(l);
            else
            {
                if (cki.Key == ConsoleKey.D1) ShowMenu(l1);
                if (cki.Key == ConsoleKey.D2) ShowMenu(l2);
                else if (cki.Key == ConsoleKey.D0) ShowMenu(l2);
            }

        }
        private static void Levels(level l, level l1, level l2)
        {
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            cki = Console.ReadKey();    // Считываем нажатую клавишу
            if (cki.Key != ConsoleKey.D0 && cki.Key != ConsoleKey.D1) ShowMenu(l);
            if (cki.Key == ConsoleKey.D1) ShowMenu(l1);
            else if (cki.Key == ConsoleKey.D0) ShowMenu(l2);
        }

        private static void Levels(level l, level l1, level l2, level l3, level down)
        {
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            cki = Console.ReadKey();    // Считываем нажатую клавишу
            if (cki.Key != ConsoleKey.D0 &&
                cki.Key != ConsoleKey.D1 &&
                cki.Key != ConsoleKey.D2 &&
                cki.Key != ConsoleKey.D3) ShowMenu(l);
            else
            {
                if (cki.Key == ConsoleKey.D1) ShowMenu(l1);
                if (cki.Key == ConsoleKey.D2) ShowMenu(l2);
                if (cki.Key == ConsoleKey.D3) ShowMenu(l3);
                if (cki.Key == ConsoleKey.D0) ShowMenu(down);
            }

        }

        static void Main(string[] args)
        {
            ShowMenu(level.level0);
        }
    }
}