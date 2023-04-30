using System.Collections;
using UMLPainter.Rectangles;
using UMLPainter.Rectangles.Blocks;

namespace UMLPainter.Test.RectanglesTests.AbstractBlockTests
{
    public class TextTests
    {
        [TestCaseSource(typeof(TitleTextTestSource))]
        public void TitleTextTest(TitleBlock block, string expected)
        {
            string actual = block.Text;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(typeof(PropertyTextTestSource))]
        public void PropertyTextTest(PropertyBlock block, string expected)
        {
            string actual = block.Text;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(typeof(MethodTextTestSource))]
        public void MethodTextTest(MethodBlock block, string expected)
        {
            string actual = block.Text;

            Assert.That(actual, Is.EqualTo(expected));
        }
    }

    public class TitleTextTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new TitleBlock()
                {
                    Text = "Hello",
                },
                "Hello"
            };

            yield return new object[]
            {
                new TitleBlock()
                {
                    Text = RectangleOptions.PropertyDefaultText + "Hello",
                },
                RectangleOptions.PropertyDefaultText + "Hello"
            };

            yield return new object[]
            {
                new TitleBlock()
                {
                    Text = RectangleOptions.MethodDefaultText + "Hello",
                },
                RectangleOptions.MethodDefaultText + "Hello"
            };
        }
    }

    public class PropertyTextTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new PropertyBlock()
                {
                    Text = "Hello",
                },
                RectangleOptions.PropertyDefaultText + "Hello"
            };

            yield return new object[]
            {
                new PropertyBlock()
                {
                    Text = RectangleOptions.PropertyDefaultText + "Hello",
                },
                RectangleOptions.PropertyDefaultText + "Hello"
            };

            yield return new object[]
            {
                new PropertyBlock()
                {
                    Text = RectangleOptions.PropertyDefaultText[0] + "Hello",
                },
                RectangleOptions.PropertyDefaultText + "Hello"
            };

            yield return new object[]
            {
                new PropertyBlock()
                {
                    Text = RectangleOptions.PropertyDefaultText[1] + "Hello",
                },
                RectangleOptions.PropertyDefaultText + "Hello"
            };
        }
    }

    public class MethodTextTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new MethodBlock()
                {
                    Text = "Hello",
                },
                RectangleOptions.MethodDefaultText + "Hello"
            };

            yield return new object[]
            {
                new MethodBlock()
                {
                    Text = RectangleOptions.MethodDefaultText + "Hello",
                },
                RectangleOptions.MethodDefaultText + "Hello"
            };

            yield return new object[]
            {
                new MethodBlock()
                {
                    Text = RectangleOptions.MethodDefaultText[0] + "Hello",
                },
                RectangleOptions.MethodDefaultText + "Hello"
            };

            yield return new object[]
            {
                new MethodBlock()
                {
                    Text = RectangleOptions.MethodDefaultText[1] + "Hello",
                },
                RectangleOptions.MethodDefaultText + "Hello"
            };
        }
    }
}