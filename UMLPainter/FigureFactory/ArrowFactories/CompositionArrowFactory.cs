namespace UMLPainter.FigureFactory.ArrowFactories
{
    public class CompositionArrowFactory : IFigureFactory
    {
        public IFigure GetFigure(Color color, int width)
        {
            return new CompositionArrow(color, width);
        }
    }
}