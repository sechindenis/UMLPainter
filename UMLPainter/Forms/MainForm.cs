using UMLPainter.FigureFactory.ArrowFactories;
using UMLPainter.FigureFactory.RectangleFactories;
using UMLPainter.Controllers;
using UMLPainter.Rectangles.Blocks;
using UMLPainter.Forms;

namespace UMLPainter
{
    public partial class MainForm : Form
    {
        private static MainForm _mainForm;

        private HelpForm _helpForm;

        public Bitmap MainBitmap { get; set; }

        public Graphics Graphics { get; set; }

        public IFigure Figure { get; set; }

        public List<IFigure> Figures { get; set; }

        public AbstractBlock Block { get; set; }

        public IController Controller { get; set; }

        private MainForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        public static MainForm GetForm1()
        {
            if (_mainForm is null)
            {
                _mainForm = new MainForm();
            }

            return _mainForm;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            MakeBitmapAndColorItWhite();
            pictureBoxMain.Image = MainBitmap;
            colorIndicator.BackColor = colorDialog1.Color;
            Figures = new List<IFigure>();

            Figure = new ClassRectangle(colorDialog1.Color, trackBarLineWidth.Value);
            Figure.StartPoint = new Point(100, 100);
            Figure.Draw(Graphics);
            Figures.Add(Figure);

            Controller = new ControllerOnSelection();
        }

        public void MakeBitmapAndColorItWhite()
        {
            MainBitmap = new Bitmap(pictureBoxMain.Width, pictureBoxMain.Height);
            Graphics = Graphics.FromImage(MainBitmap);
            Graphics.Clear(Color.White);
        }

        public void pictureBoxMain_MouseMove(object sender, MouseEventArgs e)
        {
            Controller.MouseMove(e.Location);
        }
        public void pictureBoxMain_MouseClick(object sender, MouseEventArgs e)
        {
            Controller.MouseClick(e.Location);
        }

        public void buttonAggregation_Click(object sender, EventArgs e)
        {
            Controller = new ControllerOnDrawArrow(new AggregationArrowFactory());
        }

        public void buttonAssociation_Click(object sender, EventArgs e)
        {
            Controller = new ControllerOnDrawArrow(new AssoñiationArrowFactory());
        }

        public void buttonComposition_Click(object sender, EventArgs e)
        {
            Controller = new ControllerOnDrawArrow(new CompositionArrowFactory());
        }

        public void buttonImplemetation_Click(object sender, EventArgs e)
        {
            Controller = new ControllerOnDrawArrow(new ImplementationArrowFactory());
        }

        public void buttonInheritance_Click(object sender, EventArgs e)
        {
            Controller = new ControllerOnDrawArrow(new InheritanceArrowFactory());
        }

        public void buttonClass_Click(object sender, EventArgs e)
        {
            Controller = new ControllerOnDrawRectangle(new ClassRectangleFactory());
        }

        public void buttonInterface_Click(object sender, EventArgs e)
        {
            Controller = new ControllerOnDrawRectangle(new InterfaceRectangleFactory());
        }

        public void buttonEnum_Click(object sender, EventArgs e)
        {
            Controller = new ControllerOnDrawRectangle(new EnumRectangleFactory());
        }

        public void buttonClearAll_Click(object sender, EventArgs e)
        {
            MakeBitmapAndColorItWhite();
            pictureBoxMain.Image = MainBitmap;
            Figure = null;
            Figures.Clear();

            if (Block != null)
            {
                Block.IsChosen = false;
            }

            ((AbstractController)Controller).SetAllElementsVisionToFalse();
        }

        public void trackBarLineWidth_Scroll(object sender, EventArgs e)
        {
            Controller.ChangeWidth();            
        }

        public void buttonColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            Controller.ChangeColor();
            colorIndicator.BackColor = colorDialog1.Color;
        }

        public void buttonSavingTest_Click(object sender, EventArgs e)
        {
            ((AbstractController)Controller).DrawAllFigures();
        }

        public void buttonMovingMode_Click(object sender, EventArgs e)
        {
            Controller = new ControllerOnMove();
        }

        public void buttonSelectionMode_Click(object sender, EventArgs e)
        {
            Controller = new ControllerOnSelection();
        }

        public void textBoxAddToClass_TextChanged(object sender, EventArgs e)
        {
            if (Controller is ControllerOnSelection selection)
            {
                selection.TextBoxAddToClass_TextChanged();
            }
        }

        public void buttonDeleteFromClass_Click(object sender, EventArgs e)
        {
            if (Controller is ControllerOnSelection selection)
            {
                selection.DeleteInAbstractRectangle();
            }
        }

        public void buttonAddToClass_Click(object sender, EventArgs e)
        {
            if (Controller is ControllerOnSelection selection)
            {
                selection.ButtonAddToClass_Click();
            }
        }

        private void KeyDown_Control(object sender, KeyEventArgs e)
        {
            Controller.KeyDown_Control(e);
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            if (_helpForm == null || _helpForm.IsDisposed) 
            { 
                _helpForm = new HelpForm(); 
                _helpForm.Show(); 
            }
            else 
            { 
                _helpForm.Show(); 
                _helpForm.Focus(); 
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Controller = new ControllerOnSelection();
            ((ControllerOnSelection)Controller).ButtonSave_Click();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            Controller = new ControllerOnSelection();
            ((ControllerOnSelection)Controller).ButtonOpen_Click();
        }

        private void pictureBoxMain_SizeChanged(object sender, EventArgs e)
        {
            ((AbstractController)Controller).DrawAllFigures();
        }
    }
}