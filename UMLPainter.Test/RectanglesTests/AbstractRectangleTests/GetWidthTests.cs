using System.Collections;
using System.Drawing;
using UMLPainter.Rectangles;
using UMLPainter.Rectangles.Blocks;

namespace UMLPainter.Test.RectanglesTests.AbstractRectangleTests
{
    public class GetWidthTests
    {
        [TestCaseSource(typeof(GetWidthTextLengthIsLessThanTwentyTestSource))]
        public void GetWidth_WhenTextLengthIsLessThanTwenty_ShouldReturnStandardWidth(AbstractRectangle classRectangle)
        {
            int expected = RectangleOptions.StandardWidth;
            int actual = classRectangle.GetWidth();

            Assert.That(actual, Is.EqualTo(expected));
        }
        
        [TestCaseSource(typeof(GetWidthTextLengthIsMoreThanTwentyTestSource))]
        public void GetWidth_WhenTextLengthIsMoreThanTwenty_ShouldReturnNewWidth(AbstractRectangle classRectangle, int expected)
        {
            int actual = classRectangle.GetWidth();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }

    public class GetWidthTextLengthIsLessThanTwentyTestSource : IEnumerable
    {        
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new ClassRectangle(Color.Black, 1)
                {
                    TitleBlocks = new List<AbstractBlock>{ new TitleBlock { Text = "A".Repeat(10) } }
                }
            };

            yield return new object[]
            {
                new EnumRectangle(Color.Black, 1)
                {
                    PropertyBlocks = new List<AbstractBlock>{ new PropertyBlock { Text = "A".Repeat(18) } }
                }
            };
            
            yield return new object[]
            {
                new InterfaceRectangle(Color.Black, 1)
                {
                    MethodBlocks = new List<AbstractBlock>{ new MethodBlock { Text = "A".Repeat(2) } }
                }
            };
        }
    }

    public class GetWidthTextLengthIsMoreThanTwentyTestSource: IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            AbstractRectangle rectangle = new ClassRectangle(Color.Black, 1)
            {
                PropertyBlocks = new List<AbstractBlock> { new PropertyBlock { Text = "A".Repeat(15) } },
                MethodBlocks = new List<AbstractBlock> { new MethodBlock { Text = "A".Repeat(25) } }
            };
            rectangle.TitleBlock.Text = "A".Repeat(30);

            yield return new object[]
            {
                rectangle,
                (30) * RectangleOptions.TitleFontSize
            };

            yield return new object[]
            {
                new EnumRectangle(Color.Black, 1)
                { 
                    TitleBlocks = new List<AbstractBlock>{ new TitleBlock { Text = "A".Repeat(15) } },
                    PropertyBlocks = new List<AbstractBlock>{ new PropertyBlock { Text = "A".Repeat(30) } },
                },
                (30 + 3) * RectangleOptions.PropertyFontSize
            };

            yield return new object[]
            {
                new InterfaceRectangle(Color.Black, 1)
                {
                    TitleBlocks = new List<AbstractBlock>{ new TitleBlock { Text = "A".Repeat(15) } },
                    MethodBlocks = new List<AbstractBlock>{ new MethodBlock { Text = "A".Repeat(30) } }
                },
                (30 + 3) * RectangleOptions.MethodFontSize
            };
        }
    }

    public static class StringExtensions
    {
        public static string Repeat(this string value, int count)
        {
            return string.Concat(Enumerable.Repeat(value, count));
        }
    }
}