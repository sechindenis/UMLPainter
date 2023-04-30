using UMLPainter.FigureFactory;
using UMLPainter.Rectangles;

namespace UMLPainter.Controllers
{
    public class ControllerOnDrawRectangle : AbstractController, IController
    {
        public IFigureFactory FigureFactory { get; set; }

        public ControllerOnDrawRectangle(IFigureFactory figureFactory)
        {
            FigureFactory = figureFactory;

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

        public void MouseMove(Point e)
        {
            if (IsClicked)
            {
                TmpBitmap = (Bitmap)MainForm.MainBitmap.Clone();
                MainForm.Graphics = Graphics.FromImage(TmpBitmap);
                MainForm.Figure.StartPoint = e;
                MainForm.Figure.Draw(MainForm.Graphics);
                MainForm.pictureBoxMain.Image = TmpBitmap;
                GC.Collect();
            }
        }

        private void MouseClickWhenIsNotClicked(Point e)
        {
            MainForm.Figure = FigureFactory.GetFigure(MainForm.colorDialog1.Color, MainForm.trackBarLineWidth.Value);
            MainForm.Figure.StartPoint = e;
            IsClicked = true;
        }

        private void MouseClickWhenIsClicked(Point e)
        {
            MainForm.MainBitmap = TmpBitmap;
            IsClicked = false;
            MainForm.Figures.Add(MainForm.Figure);
            MainForm.Block = ((AbstractRectangle)MainForm.Figure).TitleBlock;
            SetAllElements();
            DrawAllFigures();            
            MainForm.Controller = new ControllerOnSelection();
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