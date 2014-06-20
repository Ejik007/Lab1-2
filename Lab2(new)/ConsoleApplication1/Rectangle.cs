﻿using System;
using System.Threading;

namespace ConsoleApplication1
{
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
                    Console.Clear();
                    Console.WriteLine("Неверное значение, попробуйте еще раз...");
                    Thread.Sleep(1000);
                }
            }
            while ((this.sidea <= 0) || (this.sideb <= 0));
            this.GetArea();
        }
    }
}
