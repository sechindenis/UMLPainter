namespace UMLPainter.FigureFactory.ArrowFactories
{
    public class ImplementationArrowFactory : IFigureFactory
    {
        public IFigure GetFigure(Color color, int width)
        {
            return new ImplementationArrow(color, width);
        }
    }
}