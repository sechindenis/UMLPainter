using System.Drawing.Drawing2D;
using UMLPainter.Helpers;

namespace UMLPainter.Arrows.Heads
{
    public class TriangleHead : AbstractHead
    {
        public override void Draw(Pen pen, Graphics graphics, Point endPoint, Side side)
        {
            EndPoint = endPoint;
            Side = side;
            GetPoints();

            Brush brush = new SolidBrush(Color.White);
            graphics.FillPolygon(brush, Points.ToArray());

            pen.DashStyle = DashStyle.Solid;
            graphics.DrawPolygon(pen, Points.ToArray());
            Points.Clear();
        }
    }
}