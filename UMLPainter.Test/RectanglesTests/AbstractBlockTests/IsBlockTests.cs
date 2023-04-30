using System.Collections;
using System.Drawing;
using UMLPainter.Rectangles;
using UMLPainter.Rectangles.Blocks;

namespace UMLPainter.Test.RectanglesTests.AbstractBlockTests
{
    public class IsBlockTests
    {
        [TestCaseSource(typeof(IsBlockPointInsideBorderTestSource))]
        public void IsBlock_WhenPointInsideBorder_ShouldReturnTrue(AbstractBlock block, Point e, bool expected)
        {
            bool actual = block.IsBlock(e);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(typeof(IsBlockPointOutsideBorderTestSource))]
        public void IsBlock_WhenPointInsideBorder_ShouldReturnFalse(AbstractBlock block, Point e, bool expected)
        {
            bool actual = block.IsBlock(e);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }

    public class IsBlockPointInsideBorderTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new MethodBlock()
                {
                    StartPoint = new Point(100, 100),
                    EndPoint = new Point(200, 200),
                },
                new Point (150, 150),
                true
            };

            yield return new object[]
            {
                new PropertyBlock()
                {
                    StartPoint = new Point(100, 100),
                    EndPoint = new Point(200, 200),
                },
                new Point (100 - RectangleOptions.DeltaOfChosenBorderForDrawing / 5, 150),
                true
            };

            yield return new object[]
            {
                new TitleBlock()
                {
                    StartPoint = new Point(100, 100),
                    EndPoint = new Point(200, 200),
                },
                new Point (200 + RectangleOptions.DeltaOfChosenBorderForDrawing / 2, 150),
                true
            };
        }
    }

    public class IsBlockPointOutsideBorderTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new MethodBlock()
                {
                    StartPoint = new Point(100, 100),
                    EndPoint = new Point(200, 200),
                },
                new Point (300, 300),
                false
            };

            yield return new object[]
            {
                new PropertyBlock()
                {
                    StartPoint = new Point(100, 100),
                    EndPoint = new Point(200, 200),
                },
                new Point (100, 100 - RectangleOptions.DeltaOfChosenBorderForDrawing / 2),
                false
            };

            yield return new object[]
            {
                new PropertyBlock()
                {
                    StartPoint = new Point(100, 100),
                    EndPoint = new Point(200, 200),
                },
                new Point (200, 200 + RectangleOptions.DeltaOfChosenBorderForDrawing),
                false
            };
        }
    }
}