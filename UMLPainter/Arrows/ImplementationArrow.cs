using UMLPainter.Arrows;
using UMLPainter.Arrows.Heads;

namespace UMLPainter
{
    public class ImplementationArrow : AbstractArrow
    {
        private const int dp = ArrowOptions.DashPatternNumber;

        public ImplementationArrow()
        {

        }

        public ImplementationArrow(Color color, int width) : base(color, width)
        {
            DashPatternCustom = new float[] { dp, dp, dp, dp };
            HeadType = new TriangleHead();
        }
    }
}