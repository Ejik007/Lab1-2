
namespace ConsoleApplication1
{
    //Абстрактный класс фигура
    abstract class Figure
    {
        protected string name; //название фигуры
        protected int numberlines; //Количество линий в фигуре
        //Конструктор класса
        public Figure(string name, int numberlines)
        {
            this.name = name;
            this.numberlines = numberlines;
        }
        public abstract void ShowInfo();
    }
}
