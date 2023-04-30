using System.Drawing;
using UMLPainter.Arrows;
using UMLPainter.Helpers;
using UMLPainter.Arrows.Starts;

namespace UMLPainter.Test.ArrowsTests
{
    public class AbstractStartTests
    {
        [Test]
        public void GetPoints_WhenSideTop_ShouldGetList()
        {
            AbstractStart head = new BlankStart()
            {
                StartPoint = new Point(100, 100),
                Side = Side.Top,
            };

            List<Point> expected = new List<Point>(3)
            {
                new Point(100, 100),
                new Point(100 + ArrowOptions.SmallerRhombusDiagonal / 2, 100 - ArrowOptions.BiggerRhombusDiagonal / 2),
                new Point(100, 100 - ArrowOptions.BiggerRhombusDiagonal),
                new Point(100 - ArrowOptions.SmallerRhombusDiagonal / 2, 100 - ArrowOptions.BiggerRhombusDiagonal / 2),
            };

            head.GetPoints();
            List<Point> actual = head.Points;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetPoints_WhenSideBottom_ShouldGetList()
        {
            AbstractStart head = new BlankStart()
            {
                StartPoint = new Point(100, 100),
                Side = Side.Bottom,
            };

            List<Point> expected = new List<Point>(3)
            {
                new Point(100, 100),
                new Point(100 + ArrowOptions.SmallerRhombusDiagonal / 2, 100 + ArrowOptions.BiggerRhombusDiagonal / 2),
                new Point(100, 100 + ArrowOptions.BiggerRhombusDiagonal),
                new Point(100 - ArrowOptions.SmallerRhombusDiagonal / 2, 100 + ArrowOptions.BiggerRhombusDiagonal / 2),
            };

            head.GetPoints();
            List<Point> actual = head.Points;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetPoints_WhenSideLeft_ShouldGetList()
        {
            AbstractStart head = new FilledStart()
            {
                StartPoint = new Point(100, 100),
                Side = Side.Left,
            };

            List<Point> expected = new List<Point>(3)
            {
                new Point(100, 100),
                new Point(100 - ArrowOptions.BiggerRhombusDiagonal / 2, 100 - ArrowOptions.SmallerRhombusDiagonal / 2),
                new Point(100 - ArrowOptions.BiggerRhombusDiagonal, 100),
                new Point(100 - ArrowOptions.BiggerRhombusDiagonal / 2, 100 + ArrowOptions.SmallerRhombusDiagonal / 2),
        };

            head.GetPoints();
            List<Point> actual = head.Points;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetPoints_WhenSideRIght_ShouldGetList()
        {
            AbstractStart head = new FilledStart()
            {
                StartPoint = new Point(100, 100),
                Side = Side.Right,
            };

            List<Point> expected = new List<Point>(3)
            {
                new Point(100, 100),
                new Point(100 + ArrowOptions.BiggerRhombusDiagonal / 2, 100 - ArrowOptions.SmallerRhombusDiagonal / 2),
                new Point(100 + ArrowOptions.BiggerRhombusDiagonal, 100),
                new Point(100 + ArrowOptions.BiggerRhombusDiagonal / 2, 100 + ArrowOptions.SmallerRhombusDiagonal / 2),
            };

            head.GetPoints();
            List<Point> actual = head.Points;

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}