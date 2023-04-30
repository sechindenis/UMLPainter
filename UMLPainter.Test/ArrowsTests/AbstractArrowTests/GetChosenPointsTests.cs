using static UMLPainter.Test.ArrowsTests.AbstractArrowTests.GetPointsTests;
using System.Drawing;
using UMLPainter.Arrows;

namespace UMLPainter.Test.ArrowsTests.AbstractArrowTests
{
    public class GetChosenPointsTests
    {
        [TestCaseSource(typeof(GetPointsTopTopTestSource))]
        public void GetChosenPoints_WhenTopTop_ShouldReturnList(AbstractArrow arrow)
        {
            List<Point> expected = new List<Point>(4)
            {
                new Point(100, 100 - ArrowOptions.SimilarSideDelta / 2),
                new Point(225, 100 - ArrowOptions.SimilarSideDelta),
                new Point(350, 225 - ArrowOptions.SimilarSideDelta / 2)
            };

            arrow.GetPoints();
            List<Point> actual = arrow.GetChosenPoints();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(typeof(GetPointsBottomBottomTestSource))]
        public void GetChosenPoints_WhenBottomBottom_ShouldReturnList(AbstractArrow arrow)
        {
            List<Point> expected = new List<Point>(4)
            {
                new Point(100, 225 + ArrowOptions.SimilarSideDelta / 2),
                new Point(225, 350 + ArrowOptions.SimilarSideDelta),
                new Point(350, 350 + ArrowOptions.SimilarSideDelta / 2)
            };

            arrow.GetPoints();
            List<Point> actual = arrow.GetChosenPoints();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(typeof(GetPointsLeftLeftTestSource))]
        public void GetChosenPoints_WhenLeftLeft_ShouldReturnList(AbstractArrow arrow)
        {
            List<Point> expected = new List<Point>(4)
            {
                new Point(100 - ArrowOptions.SimilarSideDelta / 2, 100),
                new Point(100 - ArrowOptions.SimilarSideDelta, 225),
                new Point(225 - ArrowOptions.SimilarSideDelta / 2, 350)
            };

            arrow.GetPoints();
            List<Point> actual = arrow.GetChosenPoints();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(typeof(GetPointsRightRightTestSource))]
        public void GetChosenPoints_WhenRightRight_ShouldReturnList(AbstractArrow arrow)
        {
            List<Point> expected = new List<Point>(4)
            {
                new Point(225 + ArrowOptions.SimilarSideDelta / 2, 100),
                new Point(350 + ArrowOptions.SimilarSideDelta, 225),
                new Point(350 + ArrowOptions.SimilarSideDelta / 2, 350)
            };

            arrow.GetPoints();
            List<Point> actual = arrow.GetChosenPoints();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(typeof(GetPointsStartSideLeftOrRightEndSideTopOrBottomTestSource))]
        public void GetChosenPoints_WhenStartSideLeftOrRightEndSideTopOrBottom_ShouldReturnList(AbstractArrow arrow)
        {
            List<Point> expected = new List<Point>(4)
            {
                new Point(225, 100),
                new Point(350, 225),
            };

            arrow.GetPoints();
            List<Point> actual = arrow.GetChosenPoints();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(typeof(GetPointsStartSideTopOrBottomEndSideLeftOrRightTestSource))]
        public void GetChosenPoints_WhenStartSideTopOrBottomEndSideLeftOrRight_ShouldReturnList(AbstractArrow arrow)
        {
            List<Point> expected = new List<Point>(4)
            {
                new Point(100, 225),
                new Point(225, 350),
            };

            arrow.GetPoints();
            List<Point> actual = arrow.GetChosenPoints();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(typeof(GetPointsStartSideLeftOrRightEndSideRightOrLeftTestSource))]
        public void GetChosenPoints_WhenStartSideLeftOrRightEndSideRightOrLeft_ShouldReturnList(AbstractArrow arrow)
        {
            List<Point> expected = new List<Point>(4)
            {
                new Point(162, 100),
                new Point(225, 225),
                new Point(287, 350),
            };

            arrow.GetPoints();
            List<Point> actual = arrow.GetChosenPoints();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(typeof(GetPointsStartSideTopOrBottomEndSideBottomOrTopTestSource))]
        public void GetChosenPoints_WhenStartSideTopOrBottomEndSideBottomOrTop_ShouldReturnList(AbstractArrow arrow)
        {
            List<Point> expected = new List<Point>(4)
            {
                new Point(100, 162),
                new Point(225, 225),
                new Point(350, 287),
            };

            arrow.GetPoints();
            List<Point> actual = arrow.GetChosenPoints();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}