using System.Collections;
using System.Drawing;
using UMLPainter.Rectangles;
using UMLPainter.Rectangles.Blocks;

namespace UMLPainter.Test.RectanglesTests.AbstractRectangleTests
{
    public class GetChosenBlockTests
    {
        [TestCaseSource(typeof(GetChosenBlockPointInsideRectangleTestSource))]
        public void GetChosenBlock_WhenPointInsideRectangle_ShouldReturnAbstractBlock(AbstractRectangle rectangle, Point e, AbstractBlock expected)
        {
            AbstractBlock? actual = rectangle.GetChosenBlock(e);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(typeof(GetChosenBlockPointOutsideRectangleTestSource))]
        public void GetChosenBlock_WhenPointOutsideRectangle_ShouldReturnNull(AbstractRectangle rectangle, Point e, AbstractBlock expected)
        {
            AbstractBlock? actual = rectangle.GetChosenBlock(e);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }

    public class GetChosenBlockPointInsideRectangleTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            AbstractRectangle rectangle = new ClassRectangle(Color.Black, 1)
            {
                StartPoint = new Point(100, 100),
            };

            Bitmap bitmap = new Bitmap(1000, 1000);
            Graphics graphics = Graphics.FromImage(bitmap);
            rectangle.Draw(graphics);

            yield return new object[]
            {
                rectangle,
                new Point(100 + RectangleOptions.StandardWidth / 2, 100 + RectangleOptions.TitleHeight / 2),
                rectangle.TitleBlock
            };


            yield return new object[]
            {
                rectangle,
                new Point(100 + RectangleOptions.StandardWidth / 2, 100 + RectangleOptions.TitleHeight + RectangleOptions.PropertyHeight / 2),
                rectangle.PropertyBlocks[0]
            };


            yield return new object[]
            {
                rectangle,
                new Point(100 + RectangleOptions.StandardWidth / 2, 100 + RectangleOptions.TitleHeight + RectangleOptions.PropertyHeight 
                                                                                                       + RectangleOptions.MethodHeight / 2),
                rectangle.MethodBlocks[0]
            };
        }
    }

    public class GetChosenBlockPointOutsideRectangleTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            AbstractRectangle rectangle = new ClassRectangle(Color.Black, 1)
            {
                StartPoint = new Point(100, 100),
            };

            Bitmap bitmap = new Bitmap(1000, 1000);
            Graphics graphics = Graphics.FromImage(bitmap);
            rectangle.Draw(graphics);

            yield return new object[]
            {
                rectangle,
                new Point(100 + 2 * RectangleOptions.StandardWidth, 100 + RectangleOptions.TitleHeight / 2),
                null
            };


            yield return new object[]
            {
                rectangle,
                new Point(100 + 2 * RectangleOptions.StandardWidth, 100 + RectangleOptions.TitleHeight + RectangleOptions.PropertyHeight / 2),
                null
            };


            yield return new object[]
            {
                rectangle,
                new Point(100 + 2 * RectangleOptions.StandardWidth, 100 + RectangleOptions.TitleHeight + RectangleOptions.PropertyHeight
                                                                                                       + RectangleOptions.MethodHeight / 2),
                null
            };
        }
    }
}