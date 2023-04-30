using UMLPainter.Arrows.Heads;
using UMLPainter.Arrows.Starts;

namespace UMLPainter
{
    public class CompositionArrow : AbstractArrow
    {
        public CompositionArrow()
        {

        }

        public CompositionArrow(Color color, int width) : base(color, width)
        {
            StartType = new FilledStart();
            HeadType = new ArrowHead();
        }
    }
}