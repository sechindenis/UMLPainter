using System.Collections;
using System.Drawing;
using UMLPainter.Rectangles;

namespace UMLPainter.Test.RectanglesTests.AbstractRectangleTests
{
    public class MoveTests
    {
        [TestCaseSource(typeof(MoveTestSource))]
        public void MoveTest(AbstractRectangle rectangle, int deltaX, int deltaY, Point expected)
        {
            rectangle.Move(deltaX, deltaY);
            Point actual = rectangle.StartPoint;

            Assert.That(actual, Is.EqualTo(expected));
        }
    }

    public class MoveTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new ClassRectangle(Color.Black, 1)
                {
                    StartPoint = new Point(100, 100)
                },
                15, 15,
                new Point(115, 115)
            };

            yield return new object[]
            {
                new EnumRectangle(Color.Black, 1)
                {
                    StartPoint = new Point(100, 100)
                },
                -15, 15,
                new Point(85, 115)
            };

            yield return new object[]
            {
                new InterfaceRectangle(Color.Black, 1)
                {
                    StartPoint = new Point(100, 100)
                },
                -15, -15,
                new Point(85, 85)
            };

            yield return new object[]
            {
                new ClassRectangle(Color.Black, 1)
                {
                    StartPoint = new Point(100, 100)
                },
                0, 0,
                new Point(100, 100)
            };
        }
    }
}