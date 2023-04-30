using UMLPainter.Helpers;

namespace UMLPainter.Arrows.Starts
{
    public abstract class AbstractStart
    {
        public Point StartPoint { get; set; }

        public Side Side { get; set; }

        public List<Point> Points { get; set; } = new List<Point>();

        public abstract void Draw(Pen pen, Graphics graphics, Point startPoint, Side side);

        public void GetPoints()
        {
            Point apexSecond;
            Point apexForth;
            Point apexThird;

            if (Side == Side.Top)
            {
                apexSecond = new Point(StartPoint.X + ArrowOptions.SmallerRhombusDiagonal / 2, StartPoint.Y - ArrowOptions.BiggerRhombusDiagonal / 2);
                apexForth  = new Point(StartPoint.X - ArrowOptions.SmallerRhombusDiagonal / 2, StartPoint.Y - ArrowOptions.BiggerRhombusDiagonal / 2);

                apexThird  = new Point(StartPoint.X, StartPoint.Y - ArrowOptions.BiggerRhombusDiagonal);
            }
            else if (Side == Side.Bottom)
            {
                apexSecond = new Point(StartPoint.X + ArrowOptions.SmallerRhombusDiagonal / 2, StartPoint.Y + ArrowOptions.BiggerRhombusDiagonal / 2);
                apexForth  = new Point(StartPoint.X - ArrowOptions.SmallerRhombusDiagonal / 2, StartPoint.Y + ArrowOptions.BiggerRhombusDiagonal / 2);

                apexThird  = new Point(StartPoint.X, StartPoint.Y + ArrowOptions.BiggerRhombusDiagonal);
            }
            else if (Side == Side.Left)
            {
                apexSecond = new Point(StartPoint.X - ArrowOptions.BiggerRhombusDiagonal / 2, StartPoint.Y - ArrowOptions.SmallerRhombusDiagonal / 2);
                apexForth  = new Point(StartPoint.X - ArrowOptions.BiggerRhombusDiagonal / 2, StartPoint.Y + ArrowOptions.SmallerRhombusDiagonal / 2);

                apexThird  = new Point(StartPoint.X - ArrowOptions.BiggerRhombusDiagonal, StartPoint.Y);
            }
            else //if (Side == Side.Right)
            {
                apexSecond = new Point(StartPoint.X + ArrowOptions.BiggerRhombusDiagonal / 2, StartPoint.Y - ArrowOptions.SmallerRhombusDiagonal / 2);
                apexForth  = new Point(StartPoint.X + ArrowOptions.BiggerRhombusDiagonal / 2, StartPoint.Y + ArrowOptions.SmallerRhombusDiagonal / 2);

                apexThird  = new Point(StartPoint.X + ArrowOptions.BiggerRhombusDiagonal, StartPoint.Y);
            }

            Points.Add(StartPoint);
            Points.Add(apexSecond);
            Points.Add(apexThird);
            Points.Add(apexForth);
        }

    }
}