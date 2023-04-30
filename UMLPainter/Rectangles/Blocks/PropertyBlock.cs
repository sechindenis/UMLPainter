namespace UMLPainter.Rectangles.Blocks
{
    public class PropertyBlock : AbstractBlock
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
                _text = string.Concat(RectangleOptions.PropertyDefaultText, value);
            }
        }     

        public PropertyBlock()
        {
            _text = RectangleOptions.PropertyDefaultText;
            FontSize = RectangleOptions.PropertyFontSize;
            Font = new Font(RectangleOptions.Font, FontSize, FontStyle.Regular, GraphicsUnit.Point);
            SetStringFormat();
            Height = RectangleOptions.PropertyHeight;
        }

        public PropertyBlock(Point startPoint) : this()
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