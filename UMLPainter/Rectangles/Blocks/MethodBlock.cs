namespace UMLPainter.Rectangles.Blocks
{
    public class MethodBlock : AbstractBlock
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
                value = value.TrimStart(RectangleOptions.DefaultText.ToCharArray());
                _text = string.Concat(RectangleOptions.MethodDefaultText, value);
            }
        }

        public MethodBlock()
        {
            _text = RectangleOptions.MethodDefaultText;
            FontSize = RectangleOptions.MethodFontSize;
            Font = new Font(RectangleOptions.Font, FontSize, FontStyle.Regular, GraphicsUnit.Point);
            SetStringFormat();
            Height = RectangleOptions.MethodHeight;
        }

        public MethodBlock(Point startPoint) : this()
        {
            StartPoint = startPoint;
        }

        public override void SetStringFormat()
        {
            StringFormat.Alignment = StringAlignment.Near;
            StringFormat.LineAlignment = StringAlignment.Center;
        }
    }
}