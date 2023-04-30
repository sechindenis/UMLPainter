using UMLPainter.Arrows.Heads;

namespace UMLPainter
{
    public class InheritanceArrow : AbstractArrow
    {
        public InheritanceArrow()
        {

        }

        public InheritanceArrow(Color color, int width) : base(color, width)
        {
            HeadType = new TriangleHead();
        }
    }
}