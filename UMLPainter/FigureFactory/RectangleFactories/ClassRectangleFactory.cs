namespace UMLPainter.FigureFactory.RectangleFactories
{
    public class ClassRectangleFactory : IFigureFactory
    {
        public IFigure GetFigure(Color color, int width)
        {
            return new ClassRectangle(color, width);
        }
    }
}