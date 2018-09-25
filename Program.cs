using System;

namespace Laboratory_work_3
{


    class Program
    {
        static void Main(string[] args)
        {
            ConveyerControl conveyer = new ConveyerControl();

            Console.WriteLine("Управление \nСтрелка влево - Стоп \nСтрелка вверх - Вперед \nСтрелка вправо - Старт \nСтрелка вниз - Назад \nESC - Выход");

            while (conveyer.But())
            {
            }
        }
    }

    /// <summary>
    /// Структура, описывающая точку на плоскости
    /// </summary>
    struct Point
    {
        private double x;
        private double y;

        public double X { get { return x; } set { x = value; } }
        public double Y { get { return y; } set { y = value; } }

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Метод вычисляющий расстояние до заданной точки
        /// </summary>
        /// <returns></returns>
        private double Distance()
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }
    }

    /// <summary>
    /// Структура, описывающая линию на плоскости
    /// </summary>
    struct Line
    {
        Point startLine;
        Point endLine;

        public Line(Point startLine, Point endLine)
        {
            this.startLine = startLine;
            this.endLine = endLine;
        }

        /// <summary>
        /// Метод, вычисляющий длину линии
        /// </summary>
        public void LenghtLine()
        {
            double lenght = Math.Sqrt(Math.Pow(startLine.X - endLine.X, 2) + Math.Pow(startLine.Y - endLine.Y, 2));
            Console.WriteLine("Длина линии - {0}", lenght);
        }

        /// <summary>
        /// Метод, определяющий принадлежность заданной точки линии
        /// </summary>
        /// <param name="pointBelongLine">Точка, которую следует проверить.</param>
        /// <returns></returns>
        public bool BelongLine(Point pointBelongLine)
        {
            if (((pointBelongLine.X - startLine.X) / (endLine.X - startLine.X)) == (((pointBelongLine.Y - startLine.Y) / (endLine.Y - startLine.Y))))
                return true;
            return false;
        }
    }

    /// <summary>
    /// Структура, описывающая квадрат на плоскости
    /// </summary>
    struct Square
    {
        Point point_start;

        public int SideSquare { get; set; }

        public Square(Point point_start, int SideSquare)
        {
            this.point_start = point_start;
            this.SideSquare = SideSquare;
        }

        /// <summary>
        /// Метод вычисляющий площадь и периметр квадрата
        /// </summary>
        public void SquareAndPerimeter()
        {
            double square = Math.Pow(SideSquare, 2);
            double perimeter = 4 * SideSquare;
            Console.WriteLine("Периметр квадрата = {0} \nПлощадь квадрата = {1}", square, perimeter);
        }

        /// <summary>
        /// Метод, определяющий принадлежность заданной точки квадрату
        /// </summary>
        /// <param name="pointBelongSquary">Точка, которую следует проверить.</param>
        /// <returns></returns>
        public bool BelongSquare(Point pointBelongSquary)
        {
            if ((pointBelongSquary.X >= point_start.X && pointBelongSquary.X <= (point_start.X + SideSquare)) &&
               ((pointBelongSquary.Y <= point_start.Y && pointBelongSquary.Y <= (point_start.Y + SideSquare))))
                return true;
            return false;
        }
    }

    /// <summary>
    /// Структура, описывающая круг на плоскости
    /// </summary>
    struct Circle
    {
        Point centrePoint;

        public int SideCircle { get; set; }

        public Circle(Point centrePoint, int SideCircle)
        {
            this.centrePoint = centrePoint;
            this.SideCircle = SideCircle;
        }

        /// <summary>
        /// Метод, вычисляющий площадь и периметр круга
        /// </summary>
        public void SquareAndPerimeter()
        {
            double square = Math.PI * Math.Pow(SideCircle, 2);
            double perimeter = 2 * Math.PI * SideCircle;
            Console.WriteLine("Периметр круга = {0} \nПлощадь круга = {1}", perimeter, square);
        }

        /// <summary>
        /// Метод, определяющий принадлежность заданной точки кругу
        /// </summary>
        /// <param name="pointBelongCircle">Точка, которую следует проверить.</param>
        /// <returns></returns>
        public bool BelongCircle(Point pointBelongCircle)
        {
            double belong = (Math.Sqrt(Math.Pow(pointBelongCircle.X - centrePoint.X, 2) +
                             Math.Pow(pointBelongCircle.Y - centrePoint.Y, 2)));
            if (belong <= SideCircle)
                return true;
            return false;
        }
    }

    /// <summary>
    /// Структура, описывающая прямоугольник на плоскости
    /// </summary>
    struct Rectangle
    {
        Point pointStart;
        private int SideHorizontal { get; set; }
        private int SideVertical { get; set; }

        public Rectangle(Point pointStart, int SideHorizontal, int SideVertical)
        {
            this.pointStart = pointStart;
            this.SideHorizontal = SideHorizontal;
            this.SideVertical = SideVertical;
        }

        /// <summary>
        /// Метод, вычисляющий площадь и периметр прямоугольника
        /// </summary>
        public void SquareAndPerimeter()
        {
            double square = SideHorizontal * SideVertical;
            double perimeter = 2 * (SideHorizontal + SideVertical);
            Console.WriteLine("Периметр прямоугольника = {0} \nПлощадь прямоугольника = {1}", perimeter, square);
        }

        /// <summary>
        /// Метод, определяющий принадлежность заданной точки прямоугольнику
        /// </summary>
        /// <param name="pointBelongRectangle">Точка, которую следует проверить.</param>
        /// <returns></returns>
        public bool BelongRectangle(Point pointBelongRectangle)
        {
            if ((pointBelongRectangle.X >= pointStart.X && pointBelongRectangle.X <= pointStart.X + SideHorizontal) &&
                (pointBelongRectangle.Y <= pointStart.Y && pointBelongRectangle.Y <= pointStart.Y + SideVertical))
                return true;
            return false;
        }

    }

    /// <summary>
    /// Структура описывающая ромб на плоскости
    /// </summary>
    struct Rhomb
    {
        public Point centrePoint;
        private int DiagonalHorizontal { get; set; }
        private int DiagonalVertical { get; set; }

        public Rhomb(Point centrePoint, int DiagonalHorizontal, int DiagonalVertical)
        {
            this.centrePoint = centrePoint;
            this.DiagonalHorizontal = DiagonalHorizontal;
            this.DiagonalVertical = DiagonalVertical;
        }

        /// <summary>
        /// Метод вычисляющий площадь и периметр ромба
        /// </summary>
        public void SquareAndPerimeter()
        {
            double square = 4 * (Math.Sqrt(Math.Pow(DiagonalHorizontal, 2) + Math.Pow(DiagonalVertical, 2)) / 2);
            double perimeter = (DiagonalHorizontal + DiagonalVertical) / 2;
            Console.WriteLine("Периметр ромба = {0} \nПлощадь ромба = {1}", perimeter, square);
        }

        /// <summary>
        /// Метод, определяющий принадлежность заданной точки ромбу
        /// </summary>
        /// <param name="pointBelongRhomb">Точка, которую следует проверить.</param>
        /// <returns></returns>
        public bool BelongRhomb(Point pointBelongRhomb)
        {
            if (Math.Abs((pointBelongRhomb.X - centrePoint.X) / DiagonalHorizontal) +
               (Math.Abs((pointBelongRhomb.Y - centrePoint.Y) / DiagonalVertical)) <= 0.5)
                return true;
            return false;
        }
    }


    class ConveyerControl
    {
        public enum Action { STOP = 37, BEFORE, START, BACKWARD };        //Стоп, вперед, старт, назад


        public string Conveyer(Action comanda)
        {
            switch (comanda)
            {
                case (Action.BACKWARD):
                    return "Перемещение назад";
                case (Action.START):
                    return "Запуск";
                case (Action.BEFORE):
                    return "Перемещение вперед";
                case (Action.STOP):
                    return "Остановка";
                default:
                    return " - Неккоретный ввод";
            }
        }
        public bool But()
        {
            Action but = (Action)Console.ReadKey().Key;
            if ((int)but == 27)
            {
                return false;
            }
            else
            {
                Console.WriteLine(Conveyer(but));
                return true;
            }
        }
    }
}
