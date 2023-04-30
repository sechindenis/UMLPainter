using UMLPainter.Rectangles;
using UMLPainter.Rectangles.Blocks;

namespace UMLPainter.Controllers
{
    public abstract class AbstractController
    {
        public bool IsClicked { get; set; } = false;

        public Bitmap TmpBitmap { get; set; }

        public MainForm MainForm { get; set; } = MainForm.GetForm1();

        public void MakeBlockNotChosenIfNotNull(AbstractBlock block)
        {
            if (block != null)
            {
                block.IsChosen = false;
            }
        }

        public void MakeFigureNotChosenIfNotNull(IFigure figure)
        {
            if (figure != null && figure is AbstractArrow arrow)
            {
                arrow.IsChosen = false;
            }
        }

        public void DrawAllFigures()
        {
            MainForm.MakeBitmapAndColorItWhite();

            foreach (IFigure figure in MainForm.Figures)
            {
                figure.Draw(MainForm.Graphics);
            }

            MainForm.pictureBoxMain.Image = MainForm.MainBitmap;
            GC.Collect();
        }

        public void SetAllElements()
        {
            SetGroupBoxAddingToClass();
            SetButtonDelete();
            SetButtonAddToClass();
        }

        public void SetAllElementsVisionToFalse()
        {
            MainForm.groupBoxAddingInfoToClass.Visible = false;
            MainForm.buttonDeleteFromClass.Visible = false;
            MainForm.buttonAddToClass.Visible = false;
        }

        public void SetGroupBoxAddingToClass()
        {
            MainForm.groupBoxAddingInfoToClass.Location = GetGroupBoxLocation(MainForm.Block);
            MainForm.groupBoxAddingInfoToClass.Visible = true;
            MainForm.textBoxAddToClass.Text = MainForm.Block.Text.TrimStart(RectangleOptions.DefaultText.ToCharArray());
        }

        public void SetButtonDelete()
        {
            MainForm.buttonDeleteFromClass.Width = 55;

            if (MainForm.Block is TitleBlock)
            {
                SetButtonDeleteIfMainFormBlockIsTitleBlock();
            }
            else
            {
                SetButtonDeleteIfMainFormBlockIsNotTitleBlock();
            }

            MainForm.buttonDeleteFromClass.Location = GetButtonDeleteLocation(MainForm.Block);
        }

        public void SetButtonAddToClass()
        {
            MainForm.buttonAddToClass.Width = 55;
            MainForm.buttonAddToClass.Visible = false;

            if (MainForm.Block is not TitleBlock)
            {
                MainForm.buttonAddToClass.Height = MainForm.Block.Height;
                MainForm.buttonAddToClass.Location = GetButtonAddToClassLocation(MainForm.Block);
                MainForm.buttonAddToClass.Visible = true;
            }
        }

        public Point GetButtonDeleteLocation(AbstractBlock blockRectangle)
        {
            int x = blockRectangle.DockingPointLeft.X - MainForm.buttonDeleteFromClass.Width;
            int y = blockRectangle.DockingPointLeft.Y;
            Point buttonDeleteLocation = new Point(MainForm.pictureBoxMain.Location.X + x, MainForm.pictureBoxMain.Location.Y + y);

            return buttonDeleteLocation;
        }

        public Point GetButtonAddToClassLocation(AbstractBlock blockRectangle)
        {
            int x = blockRectangle.DockingPointLeft.X - MainForm.buttonAddToClass.Width;
            int y = blockRectangle.DockingPointLeft.Y + MainForm.buttonAddToClass.Height;
            Point addToClassLocation = new Point(MainForm.pictureBoxMain.Location.X + x, MainForm.pictureBoxMain.Location.Y + y);

            return addToClassLocation;
        }

        public Point GetGroupBoxLocation(AbstractBlock blockRectangle)
        {
            int x = blockRectangle.DockingPointRight.X;
            int y = blockRectangle.DockingPointRight.Y;
            Point groupBoxlocation = new Point(MainForm.pictureBoxMain.Location.X + x, MainForm.pictureBoxMain.Location.Y + y);

            return groupBoxlocation;
        }

        private void SetButtonDeleteIfMainFormBlockIsTitleBlock()
        {
            MainForm.buttonDeleteFromClass.Height = MainForm.Block.Height;
            MainForm.buttonDeleteFromClass.Text += "\nClass";
            MainForm.buttonDeleteFromClass.Visible = true;
        }

        private void SetButtonDeleteIfMainFormBlockIsNotTitleBlock()
        {
            MainForm.buttonDeleteFromClass.Height = MainForm.Block.Height;

            if (MainForm.Block is PropertyBlock && ((AbstractRectangle)MainForm.Figure).PropertyBlocks.Count == 1)
            {
                MainForm.buttonDeleteFromClass.Visible = false;
            }
            else if (MainForm.Block is MethodBlock && ((AbstractRectangle)MainForm.Figure).MethodBlocks.Count == 1)
            {
                MainForm.buttonDeleteFromClass.Visible = false;
            }
            else
            {
                MainForm.buttonDeleteFromClass.Visible = true;
            }
        }
    }
}