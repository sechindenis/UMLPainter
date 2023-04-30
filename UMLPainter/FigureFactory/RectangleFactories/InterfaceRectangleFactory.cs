namespace UMLPainter.FigureFactory.RectangleFactories
{
    public class InterfaceRectangleFactory : IFigureFactory
    {
        public IFigure GetFigure(Color color, int width)
        {
            return new InterfaceRectangle(color, width);
        }
    }
}