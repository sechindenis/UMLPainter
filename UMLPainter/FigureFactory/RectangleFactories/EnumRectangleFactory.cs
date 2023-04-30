namespace UMLPainter.FigureFactory.RectangleFactories
{
    public class EnumRectangleFactory : IFigureFactory
    {
        public IFigure GetFigure(Color color, int width)
        {
            return new EnumRectangle(color, width);
        }
    }
}