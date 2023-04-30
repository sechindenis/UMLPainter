using UMLPainter.FigureFactory;
using UMLPainter.Helpers;
using UMLPainter.Rectangles;
using UMLPainter.Rectangles.Blocks;

namespace UMLPainter.Controllers
{
    public class ControllerOnDrawArrow : AbstractController, IController
    {
        private AbstractArrow _arrow;
        
        private bool _IsAbstractRectangleSecondChosen = false;

        private AbstractRectangle _abstractRectangleFirst = null;

        private AbstractRectangle _abstractRectangleSecond = null;

        private AbstractBlock _blockFirst = null;

        private AbstractBlock _blockSecond = null;

        public IFigureFactory FigureFactory { get; set; }

        public ControllerOnDrawArrow(IFigureFactory figureFactory)
        {
            FigureFactory = figureFactory;

            MainForm.Figure = null;
            MakeBlockNotChosenIfNotNull(MainForm.Block);
            SetAllElementsVisionToFalse();
            DrawAllFigures();
        }

        public void MouseClick(Point e)
        {
            if (!IsClicked)
                MouseClickWhenIsNotClicked(e);
            else
                MouseClickWhenIsClicked(e);
        }

        private void MouseClickWhenIsNotClicked(Point e)
        {
            _abstractRectangleFirst = GetChosenAbstractRectangleOrNull(e);

            if (_abstractRectangleFirst != null)
            {
                _arrow = (AbstractArrow)FigureFactory.GetFigure(MainForm.colorDialog1.Color, MainForm.trackBarLineWidth.Value);
                DrawingArrowHelper drawingArrowHover = new DrawingArrowHelper(_abstractRectangleFirst, e);
                _arrow.StartPoint = drawingArrowHover.GetPoint();

               _blockFirst = drawingArrowHover.BlockRectangle;

                if (_arrow.StartPoint != new Point())
                {
                    _arrow.StartSide = drawingArrowHover.Side;
                    IsClicked = true;
                }
            }
        }

        private void MouseClickWhenIsClicked(Point e)
        {
            _abstractRectangleSecond = GetChosenAbstractRectangleOrNull(e);

            if (_abstractRectangleSecond != null
            && _abstractRectangleSecond != _abstractRectangleFirst)
            {
                DrawingArrowHelper drawingArrowHover = new DrawingArrowHelper(_abstractRectangleSecond, e);
                _arrow.EndPoint = drawingArrowHover.GetPoint();
                _blockSecond = drawingArrowHover.BlockRectangle;

                if (_arrow.EndPoint != new Point())
                {
                    _blockFirst.StartedArrows.Add(_arrow);
                    _blockSecond.EndedArrows.Add(_arrow);

                    MainForm.Graphics = Graphics.FromImage(MainForm.MainBitmap);
                    _arrow.EndSide = drawingArrowHover.Side;
                    _arrow.Draw(MainForm.Graphics);
                    MainForm.Figures.Add(_arrow);
                    _arrow = null;
                    MainForm.pictureBoxMain.Image = TmpBitmap;
                    GC.Collect();

                    IsClicked = false;
                }
            }
        }

        public void MouseMove(Point e)
        {
            _abstractRectangleSecond = GetChosenAbstractRectangleOrNull(e);
            TmpBitmap = (Bitmap)MainForm.MainBitmap.Clone();
            MainForm.Graphics = Graphics.FromImage(TmpBitmap);
            DrawingArrowHelper drawingArrowHover = new DrawingArrowHelper(_abstractRectangleSecond, e);            

            if (!IsClicked)
            {
                drawingArrowHover.ChooseAndDrawBorder(TmpBitmap);
            }
            else
            {
                if (_abstractRectangleSecond != null && _abstractRectangleSecond != _abstractRectangleFirst)
                {
                    _IsAbstractRectangleSecondChosen = true;
                }

                if (!_IsAbstractRectangleSecondChosen)
                {
                    _arrow.EndSide = GetTemporarySide(e);
                    _arrow.EndPoint = e;
                }
                else
                {
                    if (_abstractRectangleSecond != _abstractRectangleFirst)
                    {
                        drawingArrowHover.ChooseAndDrawBorder(TmpBitmap);
                    }

                    _arrow.EndPoint = drawingArrowHover.GetPoint();

                    if (_arrow.EndPoint != new Point() && _abstractRectangleSecond != _abstractRectangleFirst)
                    {
                        _arrow.EndSide = drawingArrowHover.Side;
                    }
                    else
                    {
                        _arrow.EndPoint = e;
                    }
                }

                _arrow.Draw(MainForm.Graphics);
            }

            MainForm.pictureBoxMain.Image = TmpBitmap;
            GC.Collect();
        }

        public AbstractRectangle GetChosenAbstractRectangleOrNull(Point e)
        {
            IFigure chosenRectangleOfClass = null;

            foreach (IFigure figure in MainForm.Figures)
            {
                if (figure is AbstractRectangle)
                {
                    if (figure.IsFigure(e))
                    {
                        chosenRectangleOfClass = figure;
                        break;
                    }
                }
            }

            return (AbstractRectangle)chosenRectangleOfClass;
        }

        private Side GetTemporarySide(Point e)
        {
            Side side;

            if (_arrow.StartSide == Side.Left)
            {
                if (e.X > _arrow.StartPoint.X)
                {
                    side = Side.Right;
                }
                else
                {
                    side = Side.Left;
                }
            }
            else
            {
                if (e.X > _arrow.StartPoint.X)
                {
                    side = Side.Left;
                }
                else
                {
                    side = Side.Right;
                }
            }

            return side;
        }
        public void KeyDown_Control(KeyEventArgs e)
        {
            
        }

        public void ChangeWidth()
        {

        }

        public void ChangeColor()
        {

        }
    }
}