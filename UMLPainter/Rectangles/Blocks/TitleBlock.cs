namespace UMLPainter.Rectangles.Blocks
{
    public class TitleBlock : AbstractBlock
    {
        public override string Text
        {
            get
            {
                if (_text != null)
                {
                    return _text;
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                _text = value;
            }
        }

        public TitleBlock()
        {
            FontSize = RectangleOptions.TitleFontSize;
            Font = new Font(RectangleOptions.Font, FontSize, FontStyle.Bold, GraphicsUnit.Point);
            SetStringFormat();
            Height = RectangleOptions.TitleHeight;
        }

        public TitleBlock(Point startPoint) : this()
        {
            StartPoint = startPoint;
        }

        public override void SetStringFormat()
        {
            StringFormat.Alignment = StringAlignment.Center;
            StringFormat.LineAlignment = StringAlignment.Center;
        }
    }
}