using UMLPainter.Arrows;

namespace UMLPainter.FigureFactory.ArrowFactories
{
    public class AssoсiationArrowFactory : IFigureFactory
    {
        public IFigure GetFigure(Color color, int width)
        {
            return new AssoсiationArrow(color, width);
        }
    }
}