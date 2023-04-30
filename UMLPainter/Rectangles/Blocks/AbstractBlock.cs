using Newtonsoft.Json;
using System.Drawing.Drawing2D;

namespace UMLPainter.Rectangles.Blocks
{
    public abstract class AbstractBlock
    {
        protected const int DeltaOfBorder = RectangleOptions.DeltaOfChosenBorder;

        protected string? _text;

        public AbstractBlock()
        {

        }

        public abstract string Text { get; set; }

        public Point StartPoint { get; set; }

        public Point EndPoint { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public Font Font { get; set; }

        public int FontSize { get; set; }

        public StringFormat StringFormat { get; set; } = new StringFormat();

        public Rectangle Rectangle { get; set; }

        public Point DockingPointRight { get; set; }

        public Point DockingPointLeft { get; set; }

        [JsonIgnore]
        public bool IsChosen { get; set; } = false;

        [JsonIgnore]
        public List<AbstractArrow> StartedArrows { get; set; } = new List<AbstractArrow>();

        [JsonIgnore]
        public List<AbstractArrow> EndedArrows { get; set; } = new List<AbstractArrow>();

        public abstract void SetStringFormat();

        public void Draw(Pen pen, Graphics graphics)
        {
            Rectangle = new Rectangle(StartPoint.X, StartPoint.Y, Width, Height);
            DrawText(pen, graphics);
            SetDockingPoints();
            EndPoint = new Point(StartPoint.X + Width, StartPoint.Y + Height);

            if (IsChosen)
            {
                DrawChosenBorderIfChosen(pen, graphics);
            }
        }
        
        public void DrawText(Pen pen, Graphics graphics)
        {
            Brush brush = new SolidBrush(pen.Color);
            graphics.DrawString(Text, Font, brush, Rectangle, StringFormat);
        }

        public void SetDockingPoints()
        {
            DockingPointLeft = new Point(StartPoint.X - 2 * DeltaOfBorder, StartPoint.Y);
            DockingPointRight = new Point((int)(Rectangle.Right + 2.5 * DeltaOfBorder), Rectangle.Y - DeltaOfBorder);
        }

        public void DrawChosenBorderIfChosen(Pen pen, Graphics graphics)
        {
            Pen borderPen = new Pen(pen.Color, 1);
            borderPen.DashStyle = DashStyle.Dash;
            Rectangle borderRectangle = new Rectangle(StartPoint.X - DeltaOfBorder, StartPoint.Y - DeltaOfBorder,
                                                      Width + 2 * DeltaOfBorder, Height + 2 * DeltaOfBorder);
            graphics.DrawRectangle(borderPen, borderRectangle);
        }

        public bool IsBlock(Point point)
        {
            bool isRectangle = false;

            if (point.X >= StartPoint.X - RectangleOptions.DeltaOfChosenBorderForDrawing
            &&  point.X <= EndPoint.X + RectangleOptions.DeltaOfChosenBorderForDrawing)
            {
                if (point.Y >= StartPoint.Y &&  point.Y <= EndPoint.Y)
                {
                    isRectangle = true;
                }
            }

            return isRectangle;
        }

        public void MoveArrowsOfBlock(int deltaX, int deltaY)
        {
            foreach (AbstractArrow arrow in StartedArrows)
            {
                arrow.StartPoint = new Point(arrow.StartPoint.X + deltaX, arrow.StartPoint.Y + deltaY);
            }

            foreach (AbstractArrow arrow in EndedArrows)
            {
                arrow.EndPoint = new Point(arrow.EndPoint.X + deltaX, arrow.EndPoint.Y + deltaY);
            }
        }
    }
}