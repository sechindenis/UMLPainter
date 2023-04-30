using UMLPainter.Rectangles;
using UMLPainter.Rectangles.Blocks;

namespace UMLPainter.Helpers
{
    public class DrawingArrowHelper
    {
        public const int Delta = RectangleOptions.DeltaOfChosenBorderForDrawing;

        public AbstractRectangle RectangleOfClass { get; set; }

        public AbstractBlock BlockRectangle { get; set; } = null;

        public Point StartPoint { get; set; }

        public Point EndPoint { get; set; }

        public Point CurrentPoint { get; set; }

        public Side Side { get; set; } = Side.None;

        public Rectangle BorderRectangle { get; set; } = new Rectangle();

        public int Width { get; set; }

        public int Height { get; set; }

        public MainForm MainForm { get; set; } = MainForm.GetForm1();

        public DrawingArrowHelper(IFigure? rectangleOfClass, Point e)
        {
            if (rectangleOfClass != null)
            {
                RectangleOfClass = rectangleOfClass as AbstractRectangle;
                BlockRectangle = RectangleOfClass.GetChosenBlock(e);
                StartPoint = BlockRectangle.StartPoint;
                EndPoint = BlockRectangle.EndPoint;
                Width = BlockRectangle.Width;
                Height = BlockRectangle.Height;
                CurrentPoint = e;
            }
        }

        public void ChooseAndDrawBorder(Bitmap bitmap)
        {
            Pen borderPen = new Pen(Color.Black, 1);
            borderPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            if (BlockRectangle is not null)
            {
                if (BlockRectangle is TitleBlock
                && CurrentPoint.Y < StartPoint.Y + Delta && CurrentPoint.Y > StartPoint.Y - Delta)
                {
                    BorderRectangle = new Rectangle(StartPoint.X, StartPoint.Y - Delta, Width, Delta * 2);
                }
                else if (BlockRectangle == RectangleOfClass.BottomBlock
                && CurrentPoint.Y < EndPoint.Y + Delta && CurrentPoint.Y > EndPoint.Y - Delta)
                {
                    BorderRectangle = new Rectangle(EndPoint.X - Width, EndPoint.Y - Delta, Width, Delta * 2);
                }
                else if (CurrentPoint.X < StartPoint.X + Delta && CurrentPoint.X > StartPoint.X - Delta)
                {
                    BorderRectangle = new Rectangle(StartPoint.X - Delta, StartPoint.Y, Delta * 2, Height);
                }
                else if (CurrentPoint.X < EndPoint.X + Delta && CurrentPoint.X > EndPoint.X - Delta)
                {
                    BorderRectangle = new Rectangle(EndPoint.X - Delta, EndPoint.Y - Height, Delta * 2, Height);
                }

                MainForm.Graphics.DrawRectangle(borderPen, BorderRectangle);
                MainForm.pictureBoxMain.Image = bitmap;
            }
        }

        public Point GetPoint()
        {
            Point point = new Point();

            if (BlockRectangle != null)
            {
                if (BlockRectangle is TitleBlock
                && CurrentPoint.Y < StartPoint.Y + Delta && CurrentPoint.Y > StartPoint.Y - Delta)
                {
                    point = new Point(CurrentPoint.X, StartPoint.Y);
                    Side = Side.Top;
                }
                else if (BlockRectangle == RectangleOfClass.BottomBlock
                && CurrentPoint.Y < EndPoint.Y + Delta && CurrentPoint.Y > EndPoint.Y - Delta)
                {
                    point = new Point(CurrentPoint.X, EndPoint.Y);
                    Side = Side.Bottom;
                }
                else if (CurrentPoint.X < StartPoint.X + Delta && CurrentPoint.X > StartPoint.X - Delta)
                {
                    point = new Point(StartPoint.X, CurrentPoint.Y);
                    Side = Side.Left;
                }
                else if (CurrentPoint.X < EndPoint.X + Delta && CurrentPoint.X > EndPoint.X - Delta)
                {
                    point = new Point(EndPoint.X, CurrentPoint.Y);
                    Side = Side.Right;
                }
            }

            return point;
        }
    }
}