using UMLPainter.Rectangles;
using UMLPainter.Rectangles.Blocks;

namespace UMLPainter
{
    public class ClassRectangle : AbstractRectangle, IFigure
    {
        public ClassRectangle()
        {
            TitleBlock = new TitleBlock(StartPoint) { Text = "New class" };
            TitleBlocks = new List<AbstractBlock>() { TitleBlock };
        }

        public ClassRectangle(Color color, int width) : this()
        {
            PropertyBlocks = new List<AbstractBlock>() { new PropertyBlock(StartPoint) };
            MethodBlocks = new List<AbstractBlock>() { new MethodBlock(StartPoint) };

            FigureColor = color;
            FigureWidth = width;

            _pen = new Pen(color, width);
        }

        public override void Draw(Graphics graphics)
        {
            _pen = new Pen(FigureColor, FigureWidth);

            DrawTitleBlock(graphics);
            DrawPropertyBlocks(graphics);
            DrawMethodBlocks(graphics);
        }
    }
}