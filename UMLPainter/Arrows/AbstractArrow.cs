using Newtonsoft.Json;
using UMLPainter.Arrows;
using UMLPainter.Arrows.Heads;
using UMLPainter.Arrows.Starts;
using UMLPainter.Helpers;

namespace UMLPainter
{
    public abstract class AbstractArrow : IFigure
    {
        private List<Point> _points = new List<Point>();

        private List<Point> _chosenPoints = new List<Point>();

        private Color _colorOfChosen = Color.Red;

        private Pen _pen = new(Color.Black, 1);

        public AbstractArrow()
        {

        }

        public AbstractArrow(Color color, int width)
        {
            _pen = new Pen(color, width);

            FigureColor = color;
            FigureWidth = width;
        }

        public int FigureWidth { get; set; }

        public Color FigureColor { get; set; }

        public Point StartPoint { get; set; }

        public Point EndPoint { get; set; }

        public Side StartSide { get; set; }

        public Side EndSide { get; set; }

        public AbstractStart? StartType { get; set; }

        public AbstractHead? HeadType { get; set; }

        public float[]? DashPatternCustom { get; set; }

        [JsonIgnore]
        public bool IsChosen { get; set; } = false;

        public void Draw(Graphics graphics)
        {
            DrawLines(graphics);

            if (IsChosen)
            {
                DrawChosenPointsIfChosen(graphics);
            }

            DrawStartAndHead(graphics);
        }

        public void DrawLines(Graphics graphics)
        {
            _pen = new Pen(FigureColor, FigureWidth);

            if (DashPatternCustom != null)
            {
                _pen.DashPattern = DashPatternCustom;
            }

            _points = GetPoints();
            graphics.DrawLines(_pen, _points.ToArray());
        }

        public void DrawChosenPointsIfChosen(Graphics graphics)
        {
            _chosenPoints = GetChosenPoints();

            foreach (Point point in _chosenPoints)
            {
                Rectangle rect = new Rectangle(point.X - ArrowOptions.ChosenCircleRadius, point.Y - ArrowOptions.ChosenCircleRadius,
                                               ArrowOptions.ChosenCircleRadius * 2, ArrowOptions.ChosenCircleRadius * 2);
                Brush brush = new SolidBrush(_colorOfChosen);
                graphics.FillEllipse(brush, rect);
            }
        }

        public void DrawStartAndHead(Graphics graphics)
        {
            StartType?.Draw(_pen, graphics, StartPoint, StartSide);
            HeadType?.Draw(_pen, graphics, EndPoint, EndSide);
        }

        public List<Point> GetPoints()
        {
            _points.Clear();
            _points.Add(StartPoint);

            if (StartSide == EndSide)
            {
                if (StartSide == Side.Top)
                {
                    int middleY = Math.Min(StartPoint.Y, EndPoint.Y) - ArrowOptions.SimilarSideDelta;
                    _points.Add(new Point(StartPoint.X, middleY));
                    _points.Add(new Point(EndPoint.X, middleY));
                }
                else if (StartSide == Side.Bottom)
                {
                    int middleY = Math.Max(StartPoint.Y, EndPoint.Y) + ArrowOptions.SimilarSideDelta;
                    _points.Add(new Point(StartPoint.X, middleY));
                    _points.Add(new Point(EndPoint.X, middleY));
                }
                else if (StartSide == Side.Left)
                {
                    int middleX = Math.Min(StartPoint.X, EndPoint.X) - ArrowOptions.SimilarSideDelta;
                    _points.Add(new Point(middleX, StartPoint.Y));
                    _points.Add(new Point(middleX, EndPoint.Y));
                }
                else if (StartSide == Side.Right)
                {
                    int middleX = Math.Max(StartPoint.X, EndPoint.X) + ArrowOptions.SimilarSideDelta;
                    _points.Add(new Point(middleX, StartPoint.Y));
                    _points.Add(new Point(middleX, EndPoint.Y));
                }
            }
            else //if (StartSide != EndSide)
            {
                if ((StartSide == Side.Right && (EndSide == Side.Top || EndSide == Side.Bottom)) 
                || (StartSide == Side.Left && (EndSide == Side.Top || EndSide == Side.Bottom)))
                {
                    _points.Add(new Point(EndPoint.X, StartPoint.Y));
                }
                else if((EndSide == Side.Right && (StartSide == Side.Top || StartSide == Side.Bottom))
                || (EndSide == Side.Left && (StartSide == Side.Top || StartSide == Side.Bottom)))
                {
                    _points.Add(new Point(StartPoint.X, EndPoint.Y));
                }
                else if ((StartSide == Side.Left && EndSide == Side.Right) 
                || (StartSide == Side.Right && EndSide == Side.Left))
                {
                    int middleX = (StartPoint.X + EndPoint.X) / 2;
                    _points.Add(new Point(middleX, StartPoint.Y));
                    _points.Add(new Point(middleX, EndPoint.Y));
                }
                else if ((StartSide == Side.Top && EndSide == Side.Bottom) 
                || (StartSide == Side.Bottom && EndSide == Side.Top))
                {
                    int middleY = (StartPoint.Y + EndPoint.Y) / 2;
                    _points.Add(new Point(StartPoint.X, middleY));
                    _points.Add(new Point(EndPoint.X, middleY));
                }
            }

            _points.Add(EndPoint);

            return _points;
        }

        public bool IsFigure(Point point)
        {
            _points = GetPoints();
            bool isFigure = false;
            int index = 0;

            while (index < _points.Count - 1)
            {
                List<int> pointsXs = new List<int>() { _points[index].X, _points[index + 1].X };
                List<int> pointsYs = new List<int>() { _points[index].Y, _points[index + 1].Y };
                pointsXs.Sort();
                pointsYs.Sort();

                if (_points[index].Y == _points[index + 1].Y)
                {
                    if ((point.X >= pointsXs[0] && point.X <= pointsXs[1])
                    && (point.Y >= _points[index].Y - ArrowOptions.DeltaOfChosenBorder && point.Y <= _points[index].Y + ArrowOptions.DeltaOfChosenBorder))
                    {
                        isFigure = true;
                        break;
                    }
                }
                else if (_points[index].X == _points[index + 1].X)
                {
                    if ((point.X >= _points[index].X - ArrowOptions.DeltaOfChosenBorder && point.X <= _points[index].X + ArrowOptions.DeltaOfChosenBorder)
                    && (point.Y >= pointsYs[0] && point.Y <= pointsYs[1]))
                    {
                        isFigure = true;
                        break;
                    }
                }

                index++;
            }

            return isFigure;
        }

        public void Move(int deltaX, int deltaY)
        {
            StartPoint = new Point(StartPoint.X + deltaX, StartPoint.Y + deltaY);
            EndPoint   = new Point(EndPoint.X + deltaX, EndPoint.Y + deltaY);
        }

        public List<Point> GetChosenPoints()
        {
            _chosenPoints.Clear();
            int index = 0;

            while (index < _points.Count - 1)
            {
                if (_points[index].Y == _points[index + 1].Y)
                {
                    _chosenPoints.Add(new Point((_points[index].X + _points[index + 1].X) / 2, _points[index].Y));
                }
                else if (_points[index].X == _points[index + 1].X)
                {
                    _chosenPoints.Add(new Point(_points[index].X, (_points[index].Y + _points[index + 1].Y) / 2));
                }

                index++;
            }

            return _chosenPoints;
        }
    }
}