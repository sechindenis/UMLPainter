using UMLPainter.Rectangles;
using UMLPainter.Rectangles.Blocks;

namespace UMLPainter
{
    public class EnumRectangle : AbstractRectangle, IFigure
    {
        public EnumRectangle()
        {
            TitleBlock = new TitleBlock(StartPoint) { Text = "New enum" };
            TitleBlocks = new List<AbstractBlock>() { TitleBlock };
        }

        public EnumRectangle(Color color, int width) : this()
        {
            PropertyBlocks = new List<AbstractBlock>() { new PropertyBlock(StartPoint) };
            MethodBlocks = new List<AbstractBlock>() { };

            FigureColor = color;
            FigureWidth = width;

            _pen = new Pen(color, width);
        }

        public override void Draw(Graphics graphics)
        {
            _pen = new Pen(FigureColor, FigureWidth);

            DrawTitleBlock(graphics);
            DrawPropertyBlocks(graphics);
        }
    }
}