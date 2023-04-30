using System.Collections;
using System.Drawing;
using UMLPainter.Rectangles;

namespace UMLPainter.Test.RectanglesTests.AbstractRectangleTests
{
    public class IsFigureTests
    {
        [TestCaseSource(typeof(IsFigureTestSource))]
        public void IsFigureTest(AbstractRectangle rectangle, Point e, bool expected)
        {
            bool actual = rectangle.IsFigure(e);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }

    public class IsFigureTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new ClassRectangle(Color.Black, 1)
                {
                    StartPoint = new Point(100, 100),
                    EndPoint = new Point(200, 200)
                },                
                new Point(150, 150),
                true
            };

            yield return new object[]
            {
                new EnumRectangle(Color.Black, 1)
                {
                    StartPoint = new Point(100, 100),
                    EndPoint = new Point(200, 200)
                },
                new Point(50, 150),
                false
            };

            yield return new object[]
            {
                new InterfaceRectangle(Color.Black, 1)
                {
                    StartPoint = new Point(100, 100),
                    EndPoint = new Point(200, 200)
                },
                new Point(150, 250),
                false
            };

            yield return new object[]
            {
                new ClassRectangle(Color.Black, 1)
                {
                    StartPoint = new Point(100, 100),
                    EndPoint = new Point(200, 200)
                },
                new Point(50, 50),
                false
            };
        }
    }
}