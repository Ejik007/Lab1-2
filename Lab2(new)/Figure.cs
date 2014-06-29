namespace DrawingFigures
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

}
