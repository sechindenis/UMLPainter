namespace UMLPainter
{
    public interface IFigure
    {
        int FigureWidth { get; set; }

        Color FigureColor { get; set; }

        Point StartPoint { get; set; }

        Point EndPoint { get; set; }

        void Draw(Graphics graphics);

        bool IsFigure(Point point);

        void Move(int deltaX, int deltaY);
    }
}