using System.Drawing.Drawing2D;
using UMLPainter.Helpers;

namespace UMLPainter.Arrows.Heads
{
    public class ArrowHead : AbstractHead
    {
        public override void Draw(Pen pen, Graphics graphics, Point endPoint, Side side)
        {
            EndPoint = endPoint;
            Side = side;
            GetPoints();

            pen.DashStyle = DashStyle.Solid;
            graphics.DrawLines(pen, Points.ToArray());
            Points.Clear();
        }
    }
}