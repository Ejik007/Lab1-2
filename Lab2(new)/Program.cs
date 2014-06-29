using System;
namespace DrawingFigures
{
    //интерфейсы
    public interface ShowArea
    {
        string ShowArea();
        void Draw();
    }
    public interface ShowVolume
    {
        string ShowVolume();
        void Draw();
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
                    Console.WriteLine("Отрисовать? Y/N");
                    string com = Console.ReadLine();
                    if (com == "Y")
                        square.Draw();
                    Console.ReadLine();
                    ShowMenu(level.level1);
                    break;
                case level.rectangle:
                    MyRectangle rectangle = new MyRectangle();
                    rectangle.ShowInfo();
                    rectangle.ShowArea();
                    //#dev
                    Console.WriteLine("Отрисовать? Y/N");
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
                    Console.WriteLine("Отрисовать? Y/N");
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
                    Console.WriteLine("Отрисовать? Y/N");
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
                    Console.WriteLine("Отрисовать? Y/N");
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
                    Console.WriteLine("Отрисовать? Y/N");
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