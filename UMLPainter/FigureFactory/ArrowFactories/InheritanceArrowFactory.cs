namespace UMLPainter.FigureFactory.ArrowFactories
{
    public class InheritanceArrowFactory : IFigureFactory
    {
        public IFigure GetFigure(Color color, int width)
        {
            return new InheritanceArrow(color, width);
        }
    }
}