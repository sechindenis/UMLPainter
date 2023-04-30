using System.Collections;
using UMLPainter.Rectangles.Blocks;
using System.Drawing;
using UMLPainter.Rectangles;

namespace UMLPainter.Test.RectanglesTests.AbstractBlockTests
{
    public class SetDockingPointsTests
    {
        [TestCaseSource(typeof(SetDockingPointsTestSource))]
        public void SetDockingPointsTest(AbstractBlock block, Point dockingPointLeftExpected, Point dockingPointRightExpected)
        {
            block.SetDockingPoints();
            List<Point> expected = new List<Point>(2) { dockingPointLeftExpected, dockingPointRightExpected };
            List<Point> actual   = new List<Point>(2) { block.DockingPointLeft, block.DockingPointRight };

            Assert.That(expected, Is.EqualTo(actual));
        }
    }

    public class SetDockingPointsTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            AbstractBlock block = new TitleBlock()
            {
                StartPoint = new Point(100, 100),
                Width = 100,
                Height = 100,
            };

            Bitmap bitmap = new Bitmap(1000, 1000);
            Graphics graphics = Graphics.FromImage(bitmap);
            block.Draw(new Pen(Color.Black), graphics);

            yield return new object[]
            {
                block,
                new Point(100 - 2 * RectangleOptions.DeltaOfChosenBorder, 100),
                new Point((int)(200 + 2.5 * RectangleOptions.DeltaOfChosenBorder), 100 - RectangleOptions.DeltaOfChosenBorder)
            };
        }
    }
}