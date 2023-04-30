using System.Collections;
using System.Drawing;
using UMLPainter.Arrows;
using UMLPainter.Helpers;

namespace UMLPainter.Test.ArrowsTests.AbstractArrowTests
{
    public class MoveTests
    {
        [TestCaseSource(typeof(MoveTestSource))]
        public void Test(int deltaX, int deltaY, Point startPointAfterMoving, Point endPointAfterMoving)
        {
            AggregationArrow arrow = new AggregationArrow()
            {
                StartPoint = new Point(100, 100),
                EndPoint = new Point(350, 350),
            };

            arrow.Move(deltaX, deltaY);
            List<Point> actual = new List<Point>() { arrow.StartPoint, arrow.EndPoint };
            List<Point> expected = new List<Point>() { startPointAfterMoving, endPointAfterMoving };

            Assert.That(actual, Is.EqualTo(expected));
        }
    }

    public class MoveTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                10, 15,
                new Point(110, 115),
                new Point(360, 365)
            };

            yield return new object[]
            {
                -10, 15,
                new Point(90, 115),
                new Point(340, 365)
            };

            yield return new object[]
            {
                -10, -15,
                new Point(90, 85),
                new Point(340, 335)
            };

            yield return new object[]
            {
                0, 15,
                new Point(100, 115),
                new Point(350, 365)
            };

            yield return new object[]
            {
                0, -15,
                new Point(100, 85),
                new Point(350, 335)
            };
        }
    }
}