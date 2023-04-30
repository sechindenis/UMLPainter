namespace UMLPainter.FigureFactory
{
    public interface IFigureFactory
    {
        IFigure GetFigure(Color color, int width);
    }
}