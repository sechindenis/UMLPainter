using System.Collections;
using System.Drawing;
using UMLPainter.Arrows;
using UMLPainter.Helpers;

namespace UMLPainter.Test.ArrowsTests.AbstractArrowTests
{
    public class GetPointsTests
    {
        [TestCaseSource(typeof(GetPointsTopTopTestSource))]
        public void GetPoints_WhenTopTop_ShouldReturnList(AbstractArrow arrow)
        {
            List<Point> expected = new List<Point>(4)
            {
                new Point(100, 100),
                new Point(100, 100 - ArrowOptions.SimilarSideDelta),
                new Point(350, 100 - ArrowOptions.SimilarSideDelta),
                new Point(350, 350)
            };

            List<Point> actual = arrow.GetPoints();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(typeof(GetPointsBottomBottomTestSource))]
        public void GetPoints_WhenBottomBottom_ShouldReturnList(AbstractArrow arrow)
        {
            List<Point> expected = new List<Point>(4)
            {
                new Point(100, 100),
                new Point(100, 350 + ArrowOptions.SimilarSideDelta),
                new Point(350, 350 + ArrowOptions.SimilarSideDelta),
                new Point(350, 350)
            };

            List<Point> actual = arrow.GetPoints();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(typeof(GetPointsLeftLeftTestSource))]
        public void GetPoints_WhenLeftLeft_ShouldReturnList(AbstractArrow arrow)
        {
            List<Point> expected = new List<Point>(4)
            {
                new Point(100, 100),
                new Point(100 - ArrowOptions.SimilarSideDelta, 100),
                new Point(100 - ArrowOptions.SimilarSideDelta, 350),
                new Point(350, 350)
            };

            List<Point> actual = arrow.GetPoints();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(typeof(GetPointsRightRightTestSource))]
        public void GetPoints_WhenRightRight_ShouldReturnList(AbstractArrow arrow)
        {
            List<Point> expected = new List<Point>(4)
            {
                new Point(100, 100),
                new Point(350 + ArrowOptions.SimilarSideDelta, 100),
                new Point(350 + ArrowOptions.SimilarSideDelta, 350),
                new Point(350, 350)
            };

            List<Point> actual = arrow.GetPoints();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(typeof(GetPointsStartSideLeftOrRightEndSideTopOrBottomTestSource))]
        public void GetPoints_WhenStartSideLeftOrRightEndSideTopOrBottom_ShouldReturnList(AbstractArrow arrow)
        {
            List<Point> expected = new List<Point>(4)
            {
                new Point(100, 100),
                new Point(350, 100),
                new Point(350, 350)
            };

            List<Point> actual = arrow.GetPoints();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(typeof(GetPointsStartSideTopOrBottomEndSideLeftOrRightTestSource))]
        public void GetPoints_WhenStartSideTopOrBottomEndSideLeftOrRight_ShouldReturnList(AbstractArrow arrow)
        {
            List<Point> expected = new List<Point>(4)
            {
                new Point(100, 100),
                new Point(100, 350),
                new Point(350, 350)
            };

            List<Point> actual = arrow.GetPoints();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(typeof(GetPointsStartSideLeftOrRightEndSideRightOrLeftTestSource))]
        public void GetPoints_WhenStartSideLeftOrRightEndSideRightOrLeft_ShouldReturnList(AbstractArrow arrow)
        {
            List<Point> expected = new List<Point>(4)
            {
                new Point(100, 100),
                new Point(225, 100),
                new Point(225, 350),
                new Point(350, 350)
            };

            List<Point> actual = arrow.GetPoints();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(typeof(GetPointsStartSideTopOrBottomEndSideBottomOrTopTestSource))]
        public void GetPoints_WhenStartSideTopOrBottomEndSideBottomOrTop_ShouldReturnList(AbstractArrow arrow)
        {
            List<Point> expected = new List<Point>(4)
            {
                new Point(100, 100),
                new Point(100, 225),
                new Point(350, 225),
                new Point(350, 350)
            };

            List<Point> actual = arrow.GetPoints();

            Assert.That(actual, Is.EqualTo(expected));
        }

        public class GetPointsTopTopTestSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[]
                {
                    new AggregationArrow()
                    {
                        StartPoint = new Point(100, 100),
                        EndPoint = new Point(350, 350),
                        StartSide = Side.Top,
                        EndSide = Side.Top
                    }
                };
            }
        }

        public class GetPointsBottomBottomTestSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[]
                {
                    new AggregationArrow()
                    {
                        StartPoint = new Point(100, 100),
                        EndPoint = new Point(350, 350),
                        StartSide = Side.Bottom,
                        EndSide = Side.Bottom
                    }
                };
            }
        }

        public class GetPointsLeftLeftTestSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[]
                {
                    new AggregationArrow()
                    {
                        StartPoint = new Point(100, 100),
                        EndPoint = new Point(350, 350),
                        StartSide = Side.Left,
                        EndSide = Side.Left
                    }
                };
            }
        }

        public class GetPointsRightRightTestSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[]
                {
                    new AggregationArrow()
                    {
                        StartPoint = new Point(100, 100),
                        EndPoint = new Point(350, 350),
                        StartSide = Side.Right,
                        EndSide = Side.Right
                    }
                };
            }
        }

        public class GetPointsStartSideLeftOrRightEndSideTopOrBottomTestSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[]
                {
                    new AssoсiationArrow()
                    {
                        StartPoint = new Point(100, 100),
                        EndPoint = new Point(350, 350),
                        StartSide = Side.Left,
                        EndSide = Side.Top
                    }
                };

                yield return new object[]
                {
                    new CompositionArrow()
                    {
                        StartPoint = new Point(100, 100),
                        EndPoint = new Point(350, 350),
                        StartSide = Side.Left,
                        EndSide = Side.Bottom
                    }
                };

                yield return new object[]
                {
                    new ImplementationArrow()
                    {
                        StartPoint = new Point(100, 100),
                        EndPoint = new Point(350, 350),
                        StartSide = Side.Right,
                        EndSide = Side.Top
                    }
                };

                yield return new object[]
                {
                    new InheritanceArrow()
                    {
                        StartPoint = new Point(100, 100),
                        EndPoint = new Point(350, 350),
                        StartSide = Side.Right,
                        EndSide = Side.Bottom
                    }
                };
            }
        }

        public class GetPointsStartSideTopOrBottomEndSideLeftOrRightTestSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[]
                {
                    new AssoсiationArrow()
                    {
                        StartPoint = new Point(100, 100),
                        EndPoint = new Point(350, 350),
                        StartSide = Side.Top,
                        EndSide = Side.Left
                    }
                };

                yield return new object[]
                {
                    new CompositionArrow()
                    {
                        StartPoint = new Point(100, 100),
                        EndPoint = new Point(350, 350),
                        StartSide = Side.Top,
                        EndSide = Side.Right
                    }
                };

                yield return new object[]
                {
                    new ImplementationArrow()
                    {
                        StartPoint = new Point(100, 100),
                        EndPoint = new Point(350, 350),
                        StartSide = Side.Bottom,
                        EndSide = Side.Left
                    }
                };

                yield return new object[]
                {
                    new InheritanceArrow()
                    {
                        StartPoint = new Point(100, 100),
                        EndPoint = new Point(350, 350),
                        StartSide = Side.Bottom,
                        EndSide = Side.Right
                    }
                };
            }
        }

        public class GetPointsStartSideLeftOrRightEndSideRightOrLeftTestSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[]
                {
                    new AssoсiationArrow()
                    {
                        StartPoint = new Point(100, 100),
                        EndPoint = new Point(350, 350),
                        StartSide = Side.Left,
                        EndSide = Side.Right
                    }
                };

                yield return new object[]
                {
                    new CompositionArrow()
                    {
                        StartPoint = new Point(100, 100),
                        EndPoint = new Point(350, 350),
                        StartSide = Side.Right,
                        EndSide = Side.Left
                    }
                };
            }
        }

        public class GetPointsStartSideTopOrBottomEndSideBottomOrTopTestSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[]
                {
                    new AssoсiationArrow()
                    {
                        StartPoint = new Point(100, 100),
                        EndPoint = new Point(350, 350),
                        StartSide = Side.Top,
                        EndSide = Side.Bottom
                    }
                };

                yield return new object[]
                {
                    new CompositionArrow()
                    {
                        StartPoint = new Point(100, 100),
                        EndPoint = new Point(350, 350),
                        StartSide = Side.Bottom,
                        EndSide = Side.Top
                    }
                };
            }
        }
    }
}