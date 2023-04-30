using UMLPainter.Arrows;

namespace UMLPainter.FigureFactory.ArrowFactories
{
    public class AggregationArrowFactory : IFigureFactory
    {
        public IFigure GetFigure(Color color, int width)
        {
            return new AggregationArrow(color, width);
        }
    }
}