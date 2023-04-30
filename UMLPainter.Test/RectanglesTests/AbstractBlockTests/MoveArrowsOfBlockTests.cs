using System.Collections;
using UMLPainter.Arrows;
using UMLPainter.Rectangles.Blocks;
using System.Drawing;

namespace UMLPainter.Test.RectanglesTests.AbstractBlockTests
{
    public class MoveArrowsOfBlockTests
    {
        [TestCaseSource(typeof(MoveArrowsOfBlockStartedTestSource))]
        public void MoveArrowsOfBlock_StartedArrows(AbstractBlock block, int deltaX, int deltaY, Point expected)
        {
            block.MoveArrowsOfBlock(deltaX, deltaY);
            Point actual = block.StartedArrows[0].StartPoint;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(typeof(MoveArrowsOfBlockEndedTestSource))]
        public void MoveArrowsOfBlock_EndedArrows(AbstractBlock block, int deltaX, int deltaY, Point expected)
        {
            block.MoveArrowsOfBlock(deltaX, deltaY);
            Point actual = block.EndedArrows[0].EndPoint;

            Assert.That(actual, Is.EqualTo(expected));
        }
    }

    public class MoveArrowsOfBlockStartedTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new MethodBlock()
                {
                    StartedArrows = new List<AbstractArrow>(1)
                    {
                        new AggregationArrow() { StartPoint = new Point(100, 100) }
                    }
                },
                50, 100,
                new Point(150, 200)
            };

            yield return new object[]
            {
                new PropertyBlock()
                {
                    StartedArrows = new List<AbstractArrow>(1)
                    {
                        new AssoсiationArrow() { StartPoint = new Point(100, 100) }
                    }
                },
                -50, 100,
                new Point(50, 200)
            };

            yield return new object[]
            {
                new TitleBlock()
                {
                    StartedArrows = new List<AbstractArrow>(1)
                    {
                        new CompositionArrow() { StartPoint = new Point(100, 100) }
                    }
                },
                -50, -50,
                new Point(50, 50)
            };
        }
    }

    public class MoveArrowsOfBlockEndedTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new MethodBlock()
                {
                    EndedArrows = new List<AbstractArrow>(1)
                    {
                        new AggregationArrow() { EndPoint = new Point(100, 100) }
                    }
                },
                50, 100,
                new Point(150, 200)
            };

            yield return new object[]
            {
                new PropertyBlock()
                {
                    EndedArrows = new List<AbstractArrow>(1)
                    {
                        new AssoсiationArrow() { EndPoint = new Point(100, 100) }
                    }
                },
                -50, 100,
                new Point(50, 200)
            };

            yield return new object[]
            {
                new TitleBlock()
                {
                    EndedArrows = new List<AbstractArrow>(1)
                    {
                        new CompositionArrow() { EndPoint = new Point(100, 100) }
                    }
                },
                -50, -50,
                new Point(50, 50)
            };
        }
    }
}