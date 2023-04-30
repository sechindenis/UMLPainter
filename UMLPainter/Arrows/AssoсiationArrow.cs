using UMLPainter.Arrows.Heads;    
    
namespace UMLPainter
{
    public class AssoсiationArrow : AbstractArrow
    {
        public AssoсiationArrow()
        {

        }

        public AssoсiationArrow(Color color, int width) : base(color, width)
        {
            HeadType = new ArrowHead();
        }
    }
}