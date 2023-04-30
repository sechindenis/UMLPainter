using UMLPainter.Arrows.Heads;
using UMLPainter.Helpers;
using System.Drawing;
using UMLPainter.Arrows;

namespace UMLPainter.Test.ArrowsTests
{
    public class AbstractHeadTests
    {
        [Test]
        public void GetPoints_WhenSideTop_ShouldGetList()
        {
            AbstractHead head = new ArrowHead()
            { 
                EndPoint = new Point(100, 100),
                Side = Side.Top,
            };

            List<Point> expected = new List<Point>(3)
            {
                new Point(100 - ArrowOptions.ThirdSideOfTriangle / 2, 100 - ArrowOptions.HeightOfTriangle),
                new Point(100, 100),
                new Point(100 + ArrowOptions.ThirdSideOfTriangle / 2, 100 - ArrowOptions.HeightOfTriangle)
            };

            head.GetPoints();
            List<Point> actual = head.Points;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetPoints_WhenSideBottom_ShouldGetList()
        {
            AbstractHead head = new ArrowHead()
            {
                EndPoint = new Point(100, 100),
                Side = Side.Bottom,
            };

            List<Point> expected = new List<Point>(3)
            {
                new Point(100 - ArrowOptions.ThirdSideOfTriangle / 2, 100 + ArrowOptions.HeightOfTriangle),
                new Point(100, 100),
                new Point(100 + ArrowOptions.ThirdSideOfTriangle / 2, 100 + ArrowOptions.HeightOfTriangle)
            };

            head.GetPoints();
            List<Point> actual = head.Points;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetPoints_WhenSideLeft_ShouldGetList()
        {
            AbstractHead head = new TriangleHead()
            {
                EndPoint = new Point(100, 100),
                Side = Side.Left,
            };

            List<Point> expected = new List<Point>(3)
            {
                new Point(100 - ArrowOptions.HeightOfTriangle, 100 - ArrowOptions.ThirdSideOfTriangle / 2),
                new Point(100, 100),
                new Point(100 - ArrowOptions.HeightOfTriangle, 100 + ArrowOptions.ThirdSideOfTriangle / 2)
            };

            head.GetPoints();
            List<Point> actual = head.Points;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetPoints_WhenSideRIght_ShouldGetList()
        {
            AbstractHead head = new TriangleHead()
            {
                EndPoint = new Point(100, 100),
                Side = Side.Right,
            };

            List<Point> expected = new List<Point>(3)
            {
                new Point(100 + ArrowOptions.HeightOfTriangle, 100 - ArrowOptions.ThirdSideOfTriangle / 2),
                new Point(100, 100),
                new Point(100 + ArrowOptions.HeightOfTriangle, 100 + ArrowOptions.ThirdSideOfTriangle / 2)
            };

            head.GetPoints();
            List<Point> actual = head.Points;

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}