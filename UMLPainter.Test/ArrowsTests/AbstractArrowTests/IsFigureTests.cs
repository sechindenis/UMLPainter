using System.Collections;
using System.Drawing;
using UMLPainter.Arrows;
using UMLPainter.Helpers;

namespace UMLPainter.Test.ArrowsTests.AbstractArrowTests
{
    public class IsFigureTests
    {
        [TestCaseSource(typeof(IsFigureTopTopNegativeTestSource))]
        public void IsFigure_WhenPointOutsideChosenBorderTopTop_ShouldReturnFalse(AbstractArrow arrow, Point point, bool expected)
        {
            bool actual = arrow.IsFigure(point);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(typeof(IsFigureTopTopPositiveTestSource))]
        public void IsFigure_WhenPointInsideChosenBorderTopTop_ShouldReturnTrue(AbstractArrow arrow, Point point, bool expected)
        {
            bool actual = arrow.IsFigure(point);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(typeof(IsFigureBottomBottomNegativeTestSource))]
        public void IsFigure_WhenPointOutsideChosenBorderBottomBottom_ShouldReturnFalse(AbstractArrow arrow, Point point, bool expected)
        {
            bool actual = arrow.IsFigure(point);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(typeof(IsFigureBottomBottomPositiveTestSource))]
        public void IsFigure_WhenPointInsideChosenBorderBottomBottom_ShouldReturnTrue(AbstractArrow arrow, Point point, bool expected)
        {
            bool actual = arrow.IsFigure(point);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(typeof(IsFigureLeftLeftNegativeTestSource))]
        public void IsFigure_WhenPointOutsideChosenBorderLeftLeft_ShouldReturnFalse(AbstractArrow arrow, Point point, bool expected)
        {
            bool actual = arrow.IsFigure(point);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(typeof(IsFigureLeftLeftPositiveTestSource))]
        public void IsFigure_WhenPointInsideChosenBorderLeftLeft_ShouldReturnTrue(AbstractArrow arrow, Point point, bool expected)
        {
            bool actual = arrow.IsFigure(point);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(typeof(IsFigureRightRightNegativeTestSource))]
        public void IsFigure_WhenPointOutsideChosenBorderRightRight_ShouldReturnFalse(AbstractArrow arrow, Point point, bool expected)
        {
            bool actual = arrow.IsFigure(point);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(typeof(IsFigureRightRightPositiveTestSource))]
        public void IsFigure_WhenPointInsideChosenBorderRightRight_ShouldReturnTrue(AbstractArrow arrow, Point point, bool expected)
        {
            bool actual = arrow.IsFigure(point);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }

    public class IsFigureTopTopNegativeTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            AggregationArrow arrowTopTop = new AggregationArrow()
            {
                StartPoint = new Point(100, 100),
                EndPoint = new Point(350, 350),
                StartSide = Side.Top,
                EndSide = Side.Top
            };

            yield return new object[]
            {
                arrowTopTop,
                new Point(100 + 2 * ArrowOptions.DeltaOfChosenBorder, 100 - 3* ArrowOptions.SimilarSideDelta),
                false
            };

            yield return new object[]
            {
                arrowTopTop,
                new Point(250, 100 - ArrowOptions.SimilarSideDelta + 5 * ArrowOptions.DeltaOfChosenBorder),
                false
            };

            yield return new object[]
            {
                arrowTopTop,
                new Point(350 - 3 * ArrowOptions.DeltaOfChosenBorder, 350 - 3 * ArrowOptions.SimilarSideDelta),
                false
            };
        }
    }

    public class IsFigureTopTopPositiveTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            AggregationArrow arrowTopTop = new AggregationArrow(Color.Black, 1)
            {
                StartPoint = new Point(100, 100),
                EndPoint = new Point(350, 350),
                StartSide = Side.Top,
                EndSide = Side.Top
            };

            yield return new object[]
            {
                arrowTopTop,
                new Point(100 + ArrowOptions.DeltaOfChosenBorder / 2, 100 - ArrowOptions.SimilarSideDelta / 2),
                true
            };

            yield return new object[]
            {
                arrowTopTop,
                new Point(250, 100 - ArrowOptions.SimilarSideDelta + ArrowOptions.DeltaOfChosenBorder / 2),
                true
            };

            yield return new object[]
            {
                arrowTopTop,
                new Point(350 - ArrowOptions.DeltaOfChosenBorder / 2, 350 - ArrowOptions.SimilarSideDelta / 2),
                true
            };
        }
    }

    public class IsFigureBottomBottomNegativeTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            AssoсiationArrow arrowBottomBottom = new AssoсiationArrow(Color.Black, 1)
            {
                StartPoint = new Point(100, 100),
                EndPoint = new Point(350, 350),
                StartSide = Side.Bottom,
                EndSide = Side.Bottom
            };

            yield return new object[]
            {
                arrowBottomBottom,
                new Point(100 + 2 * ArrowOptions.DeltaOfChosenBorder, 100 + 3 * ArrowOptions.SimilarSideDelta),
                false
            };

            yield return new object[]
            {
                arrowBottomBottom,
                new Point(250, 350 + 2 * ArrowOptions.SimilarSideDelta + 2 * ArrowOptions.DeltaOfChosenBorder),
                false
            };

            yield return new object[]
            {
                arrowBottomBottom,
                new Point(350 + 2 * ArrowOptions.DeltaOfChosenBorder / 2, 350 + 2 * ArrowOptions.SimilarSideDelta),
                false
            };
        }
    }

    public class IsFigureBottomBottomPositiveTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            AssoсiationArrow arrowBottomBottom = new AssoсiationArrow(Color.Black, 1)
            {
                StartPoint = new Point(100, 100),
                EndPoint = new Point(350, 350),
                StartSide = Side.Bottom,
                EndSide = Side.Bottom
            };

            yield return new object[]
            {
                arrowBottomBottom,
                new Point(100 + ArrowOptions.DeltaOfChosenBorder / 2, 100 + ArrowOptions.SimilarSideDelta / 2),
                true
            };

            yield return new object[]
            {
                arrowBottomBottom,
                new Point(250, 350 + ArrowOptions.SimilarSideDelta + ArrowOptions.DeltaOfChosenBorder / 2),
                true
            };

            yield return new object[]
            {
                arrowBottomBottom,
                new Point(350 + ArrowOptions.DeltaOfChosenBorder / 2, 350 + ArrowOptions.SimilarSideDelta / 2),
                true
            };

        }
    }

    public class IsFigureLeftLeftNegativeTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            CompositionArrow arrowLeftLeft = new CompositionArrow(Color.Black, 1)
            {
                StartPoint = new Point(100, 100),
                EndPoint = new Point(350, 350),
                StartSide = Side.Left,
                EndSide = Side.Left
            };

            yield return new object[]
            {
                arrowLeftLeft,
                new Point(100 - 2 * ArrowOptions.SimilarSideDelta, 100 + 2 * ArrowOptions.DeltaOfChosenBorder),
                false
            };

            yield return new object[]
            {
                arrowLeftLeft,
                new Point(100 + 2 * ArrowOptions.SimilarSideDelta - 2 * ArrowOptions.DeltaOfChosenBorder, 250),
                false
            };

            yield return new object[]
            {
                arrowLeftLeft,
                new Point(250 + 2 * ArrowOptions.DeltaOfChosenBorder / 2, 350 + 2 * ArrowOptions.DeltaOfChosenBorder),
                false
            };
        }
    }

    public class IsFigureLeftLeftPositiveTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {

            CompositionArrow arrowLeftLeft = new CompositionArrow(Color.Black, 1)
            {
                StartPoint = new Point(100, 100),
                EndPoint = new Point(350, 350),
                StartSide = Side.Left,
                EndSide = Side.Left
            };

            yield return new object[]
            {
                arrowLeftLeft,
                new Point(100 - ArrowOptions.SimilarSideDelta / 2, 100 + ArrowOptions.DeltaOfChosenBorder / 2),
                true
            };

            yield return new object[]
            {
                arrowLeftLeft,
                new Point(100 - ArrowOptions.SimilarSideDelta - ArrowOptions.DeltaOfChosenBorder / 2, 250),
                true
            };

            yield return new object[]
            {
                arrowLeftLeft,
                new Point(250 + ArrowOptions.DeltaOfChosenBorder / 2, 350 + ArrowOptions.DeltaOfChosenBorder / 2),
                true
            };
        }
    }

    public class IsFigureRightRightNegativeTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            ImplementationArrow arrowRightRight = new ImplementationArrow(Color.Black, 1)
            {
                StartPoint = new Point(100, 100),
                EndPoint = new Point(350, 350),
                StartSide = Side.Right,
                EndSide = Side.Right
            };

            yield return new object[]
            {
                arrowRightRight,
                new Point(100 + 2 * ArrowOptions.SimilarSideDelta / 2, 100 + 2 * ArrowOptions.DeltaOfChosenBorder),
                false
            };

            yield return new object[]
            {
                arrowRightRight,
                new Point(350 + 2 * ArrowOptions.SimilarSideDelta, 250 + 2 * ArrowOptions.DeltaOfChosenBorder),
                false
            };

            yield return new object[]
            {
                arrowRightRight,
                new Point(350 + 2 * ArrowOptions.SimilarSideDelta, 350 + 2 * ArrowOptions.DeltaOfChosenBorder),
                false
            };
        }
    }

    public class IsFigureRightRightPositiveTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            ImplementationArrow arrowRightRight = new ImplementationArrow(Color.Black, 1)
            {
                StartPoint = new Point(100, 100),
                EndPoint = new Point(350, 350),
                StartSide = Side.Right,
                EndSide = Side.Right
            };

            yield return new object[]
            {
                arrowRightRight,
                new Point(100 + ArrowOptions.SimilarSideDelta / 2, 100 + ArrowOptions.DeltaOfChosenBorder / 2),
                true
            };

            yield return new object[]
            {
                arrowRightRight,
                new Point(350 + ArrowOptions.SimilarSideDelta, 250 + ArrowOptions.DeltaOfChosenBorder / 2),
                true
            };

            yield return new object[]
            {
                arrowRightRight,
                new Point(350 + ArrowOptions.SimilarSideDelta / 2, 350 + ArrowOptions.DeltaOfChosenBorder / 2),
                true
            };
        }
    }
}