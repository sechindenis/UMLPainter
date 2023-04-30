using UMLPainter.Helpers;

namespace UMLPainter.Arrows.Heads
{
    public abstract class AbstractHead
    {
        public Point EndPoint { get; set; }

        public Side Side { get; set; }

        public List<Point> Points { get; set; } = new List<Point>();

        public abstract void Draw(Pen pen, Graphics graphics, Point endPoint, Side side);

        public void GetPoints() 
        {
            Point apexOfTriangleFirst;
            Point apexOfTriangleSecond;

            if (Side == Side.Top)
            {
                apexOfTriangleFirst  = new Point(EndPoint.X - ArrowOptions.ThirdSideOfTriangle / 2, EndPoint.Y - ArrowOptions.HeightOfTriangle);
                apexOfTriangleSecond = new Point(EndPoint.X + ArrowOptions.ThirdSideOfTriangle / 2, EndPoint.Y - ArrowOptions.HeightOfTriangle);

            }
            else if (Side == Side.Bottom)
            {
                apexOfTriangleFirst  = new Point(EndPoint.X - ArrowOptions.ThirdSideOfTriangle / 2, EndPoint.Y + ArrowOptions.HeightOfTriangle);
                apexOfTriangleSecond = new Point(EndPoint.X + ArrowOptions.ThirdSideOfTriangle / 2, EndPoint.Y + ArrowOptions.HeightOfTriangle);
            }
            else if (Side == Side.Left)
            {
                apexOfTriangleFirst  = new Point(EndPoint.X - ArrowOptions.HeightOfTriangle, EndPoint.Y - ArrowOptions.ThirdSideOfTriangle / 2);
                apexOfTriangleSecond = new Point(EndPoint.X - ArrowOptions.HeightOfTriangle, EndPoint.Y + ArrowOptions.ThirdSideOfTriangle / 2);
            }
            else //if (Side == Side.Right)
            {
                apexOfTriangleFirst  = new Point(EndPoint.X + ArrowOptions.HeightOfTriangle, EndPoint.Y - ArrowOptions.ThirdSideOfTriangle / 2);
                apexOfTriangleSecond = new Point(EndPoint.X + ArrowOptions.HeightOfTriangle, EndPoint.Y + ArrowOptions.ThirdSideOfTriangle / 2);
            }

            Points.Add(apexOfTriangleFirst);
            Points.Add(EndPoint);
            Points.Add(apexOfTriangleSecond);
        }

    }
}