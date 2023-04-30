﻿using System.Drawing.Drawing2D;
using UMLPainter.Helpers;

namespace UMLPainter.Arrows.Starts
{
    public class FilledStart : AbstractStart
    {
        public override void Draw(Pen pen, Graphics graphics, Point startPoint, Side side)
        {
            StartPoint = startPoint;
            Side = side;
            GetPoints();

            pen.DashStyle = DashStyle.Solid;
            Brush brush = new SolidBrush(pen.Color);
            graphics.FillPolygon(brush, Points.ToArray());
            graphics.DrawPolygon(pen, Points.ToArray());
            Points.Clear();
        }
    }
}