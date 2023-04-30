using UMLPainter.Arrows.Heads;
using UMLPainter.Arrows.Starts;

namespace UMLPainter.Arrows
{
    public class AggregationArrow : AbstractArrow
    {
        public AggregationArrow()
        {

        }

        public AggregationArrow(Color color, int width) : base(color, width)
        {
            StartType = new BlankStart();
            HeadType = new ArrowHead();
        }
    }
}