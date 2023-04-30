using UMLPainter.Rectangles.Blocks;
using UMLPainter.Rectangles;

namespace UMLPainter.Controllers
{
    public class ControllerOnMove : AbstractController, IController
    {
        private Point _clickedPoint;

        public IFigure Figure { get; set; }

        public ControllerOnMove()
        {
            MakeFigureNotChosenIfNotNull(MainForm.Figure);
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
            if (IsClicked && Figure != null)
            {
                TmpBitmap = (Bitmap)MainForm.MainBitmap.Clone();
                MainForm.Graphics = Graphics.FromImage(TmpBitmap);
                Figure.Move(e.X - _clickedPoint.X, e.Y - _clickedPoint.Y);
                _clickedPoint = e;
                DrawAllArrowsInAbstractRectangle((AbstractRectangle)Figure);
                Figure.Draw(MainForm.Graphics);
                MainForm.pictureBoxMain.Image = TmpBitmap;
                GC.Collect();
            }
        }

        public void MouseClickWhenIsNotClicked(Point e)
        {
            foreach (IFigure figure in MainForm.Figures)
            {
                if (figure.IsFigure(e) && figure is AbstractRectangle)
                {
                    Figure = figure;
                    break;
                }
            }

            if (Figure != null)
            {
                IsClicked = true;
                MainForm.Figures.Remove(Figure);
                RemovellArrowsFromAbstractRectangle((AbstractRectangle)Figure);
                DrawAllFigures();
                _clickedPoint = e;
            }
        }

        public void MouseClickWhenIsClicked(Point e)
        {
            MainForm.MainBitmap = TmpBitmap;
            IsClicked = false;            
            MainForm.Figures.Add(Figure);
            AddAllArrowsToAbstractRectangle((AbstractRectangle)Figure);
            Figure = null;
        }

        private void DrawAllArrowsInAbstractRectangle(AbstractRectangle abstractRectangle)
        {
            DrawAllArrowsInBlockList(abstractRectangle.TitleBlocks);
            DrawAllArrowsInBlockList(abstractRectangle.PropertyBlocks);
            DrawAllArrowsInBlockList(abstractRectangle.MethodBlocks);
        }

        private void RemovellArrowsFromAbstractRectangle(AbstractRectangle abstractRectangle)
        {
            RemovellArrowsFromBlockList(abstractRectangle.TitleBlocks);
            RemovellArrowsFromBlockList(abstractRectangle.PropertyBlocks);
            RemovellArrowsFromBlockList(abstractRectangle.MethodBlocks);
        }

        private void AddAllArrowsToAbstractRectangle(AbstractRectangle abstractRectangle)
        {
            AddAllArrowsToBlockList(abstractRectangle.TitleBlocks);
            AddAllArrowsToBlockList(abstractRectangle.PropertyBlocks);
            AddAllArrowsToBlockList(abstractRectangle.MethodBlocks);
        }

        private void DrawAllArrowsInBlockList(List<AbstractBlock> blockList)
        {
            foreach (AbstractBlock block in blockList)
            {
                DrawAllArrowsInList(block.StartedArrows);
                DrawAllArrowsInList(block.EndedArrows);
            }
        }

        private void RemovellArrowsFromBlockList(List<AbstractBlock> blockList)
        {
            foreach (AbstractBlock block in blockList)
            {
                RemovellArrowsFromList(block.StartedArrows);
                RemovellArrowsFromList(block.EndedArrows);
            }
        }

        private void AddAllArrowsToBlockList(List<AbstractBlock> blockList)
        {
            foreach (AbstractBlock block in blockList)
            {
                AddAllArrowsToList(block.StartedArrows);
                AddAllArrowsToList(block.EndedArrows);
            }
        }

        private void DrawAllArrowsInList(List<AbstractArrow> listOfArrows)
        {
            foreach (AbstractArrow arrow in listOfArrows)
            {
                arrow.Draw(MainForm.Graphics);
            }
        }

        private void RemovellArrowsFromList(List<AbstractArrow> listOfArrows)
        {
            foreach (AbstractArrow arrow in listOfArrows)
            {
                MainForm.Figures.Remove(arrow);
            }
        }

        private void AddAllArrowsToList(List<AbstractArrow> listOfArrows)
        {
            foreach (AbstractArrow arrow in listOfArrows)
            {
                MainForm.Figures.Add(arrow);
            }
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