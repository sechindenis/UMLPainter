using Newtonsoft.Json;
using UMLPainter.Helpers;
using UMLPainter.Rectangles;
using UMLPainter.Rectangles.Blocks;

namespace UMLPainter.Controllers
{
    public class ControllerOnSelection : AbstractController, IController
    {
        private IFigure _figure;

        public List<IFigure> SelectedFigures { get; set; } = new List<IFigure>();

        public List<IFigure>? TmpFigures = new List<IFigure>();

        public ControllerOnSelection()
        {
            if (MainForm.Figure is AbstractRectangle)
            {
                MainForm.Block = ((AbstractRectangle)MainForm.Figure).TitleBlock;
                MainForm.Block.IsChosen = true;
                DrawAllFigures();
                SetAllElements();
            }
        }

        public void MouseClick(Point e)
        {
            foreach (IFigure figure in MainForm.Figures)
            {
                if (figure.IsFigure(e))
                {
                    _figure = figure;
                    break;
                }
                else
                {
                    _figure = null;
                }
            }

            MakeBlockNotChosenIfNotNull(MainForm.Block);

            if (_figure != null)
            {
                MouseClickIfFigureNotNull(e);
            }
            else if (_figure == null && MainForm.Figure != null)
            {
                MouseClickIfFigureNullAndMainFormFigureNotNull(e);
            }
        }

        private void MouseClickIfFigureNotNull(Point e)
        {
            MainForm.Figure = _figure;

            if (_figure is AbstractRectangle rectangle)
            {
                MainForm.Block = rectangle.GetChosenBlock(e);
                MainForm.Block.IsChosen = true;
                SetAllElements();
            }
            else
            {
                ((AbstractArrow)_figure).IsChosen = true;
                SetAllElementsVisionToFalse();
            }

            DrawAllFigures();
        }

        private void MouseClickIfFigureNullAndMainFormFigureNotNull(Point e)
        {
            if (MainForm.Figure is AbstractRectangle)
            {
                MainForm.Block.IsChosen = false;
                MainForm.Block = null;
            }
            else
            {
                ((AbstractArrow)MainForm.Figure).IsChosen = false;
            }

            DrawAllFigures();
            SetAllElementsVisionToFalse();
            MainForm.Figure = null;
        }

        public void MouseMove(Point e)
        {

        }

        public void KeyDown_Control(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MainForm.Figure is AbstractArrow arrow && arrow.IsChosen)
                {
                    MainForm.Figures.Remove(MainForm.Figure);
                    DeleteArrow(arrow);
                    DrawAllFigures();
                }
                else if (MainForm.Figure is AbstractRectangle && e.Control)
                {
                    DeleteInAbstractRectangle();
                }
            }
            else if (e.KeyCode == Keys.Add)
            {
                ButtonAddToClass_Click();
            }
            else if (e.KeyCode == Keys.Down)
            {
                GoDownInBlocks();
            }
            else if (e.KeyCode == Keys.Up)
            {
                GoUpInBlocks();
            }
        }
        
        public void ChangeWidth()
        {
            if (MainForm.Figure != null)
            {
                MainForm.Figure.FigureWidth = MainForm.trackBarLineWidth.Value;
                DrawAllFigures();
            }
        }

        public void ChangeColor()
        {
            if (MainForm.Figure != null)
            {
                MainForm.Figure.FigureColor = MainForm.colorDialog1.Color;
                DrawAllFigures();
            }
        }

        public void MultypleSelection(Point e)
        {
            foreach (IFigure figure in MainForm.Figures)
            {
                if (figure.IsFigure(e))
                {
                    SelectedFigures.Add(figure);
                    break;
                }
            }
        }

        public void GoDownInBlocks()
        {
            AbstractRectangle abstractRectangle = (AbstractRectangle)MainForm.Figure;
            MainForm.Block.IsChosen = false;

            if (MainForm.Block is TitleBlock)
            {
                MainForm.Block = abstractRectangle.PropertyBlocks[0];
            }
            else if (MainForm.Block is PropertyBlock)
            {
                GoDownInBlocksIfBlockIsPropertyBlock(abstractRectangle);
            }
            else if (MainForm.Block is MethodBlock)
            {
                GoDownInBlocksIfBlockIsMethodBlock(abstractRectangle);
            }

            MainForm.Block.IsChosen = true;
            DrawAllFigures();
            SetAllElements();
        }

        private void GoDownInBlocksIfBlockIsPropertyBlock(AbstractRectangle abstractRectangle)
        {
            int index = abstractRectangle.PropertyBlocks.IndexOf(MainForm.Block);

            if (index < abstractRectangle.PropertyBlocks.Count - 1)
                MainForm.Block = abstractRectangle.PropertyBlocks[index + 1];            
            else
                MainForm.Block = abstractRectangle.MethodBlocks[0];
        }

        private void GoDownInBlocksIfBlockIsMethodBlock(AbstractRectangle abstractRectangle)
        {
            int index = abstractRectangle.MethodBlocks.IndexOf(MainForm.Block);

            if (index < abstractRectangle.MethodBlocks.Count - 1)
                MainForm.Block = abstractRectangle.MethodBlocks[index + 1];
        }

        public void GoUpInBlocks()
        {
            AbstractRectangle abstractRectangle = (AbstractRectangle)MainForm.Figure;
            MainForm.Block.IsChosen = false;

            if (MainForm.Block is MethodBlock)
            {
                GoUpInBlocksIfBlockIsMethodBlock(abstractRectangle);
            }
            else if (MainForm.Block is PropertyBlock)
            {
                GoUpInBlocksIfBlockIsPropertyBlock(abstractRectangle);
            }

            MainForm.Block.IsChosen = true;
            DrawAllFigures();
            SetAllElements();
        }

        private void GoUpInBlocksIfBlockIsMethodBlock(AbstractRectangle abstractRectangle)
        {
            int index = abstractRectangle.MethodBlocks.IndexOf(MainForm.Block);

            if (index > 0)
                MainForm.Block = abstractRectangle.MethodBlocks[index - 1];
            else
                MainForm.Block = abstractRectangle.PropertyBlocks[^1];
        }

        private void GoUpInBlocksIfBlockIsPropertyBlock(AbstractRectangle abstractRectangle)
        {
            int index = abstractRectangle.PropertyBlocks.IndexOf(MainForm.Block);
            MainForm.Block.IsChosen = false;

            if (index > 0)
                MainForm.Block = abstractRectangle.PropertyBlocks[index - 1];            
            else            
                MainForm.Block = abstractRectangle.TitleBlock;
        }

        public void DeleteAllArrowsOfBlock(AbstractBlock block)
        {
            AbstractArrow[] startedArrowsTmp = new AbstractArrow[block.StartedArrows.Count];
            block.StartedArrows.CopyTo(startedArrowsTmp);
            List<AbstractArrow> startedArrows = new List<AbstractArrow>(startedArrowsTmp);

            foreach (AbstractArrow arrow in startedArrows)
            {
                if (arrow.StartSide != Side.Bottom)
                {
                    DeleteArrow(arrow);
                    MainForm.Figures.Remove(arrow);
                }
            }

            AbstractArrow[] endedArrowsTmp = new AbstractArrow[block.EndedArrows.Count];
            block.EndedArrows.CopyTo(startedArrowsTmp);
            List<AbstractArrow> endedArrows = new List<AbstractArrow>(endedArrowsTmp);

            foreach (AbstractArrow arrow in endedArrows)
            {
                if (arrow.EndSide != Side.Bottom)
                {
                    DeleteArrow(arrow);
                    MainForm.Figures.Remove(arrow);
                }
            }

            DrawAllFigures();
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

        public void DeleteArrow(AbstractArrow arrow)
        {
            AbstractRectangle tmpAbstractRectangle = GetChosenAbstractRectangleOrNull(arrow.StartPoint);
            AbstractBlock tmpBlock = tmpAbstractRectangle.GetChosenBlock(arrow.StartPoint);
            tmpBlock.StartedArrows.Remove(arrow);

            tmpAbstractRectangle = GetChosenAbstractRectangleOrNull(arrow.EndPoint);
            tmpBlock = tmpAbstractRectangle.GetChosenBlock(arrow.EndPoint);
            tmpBlock.EndedArrows.Remove(arrow);
        }

        public void TextBoxAddToClass_TextChanged()
        {
            MainForm.Figures.Remove(MainForm.Figure);
            MainForm.Block.Text = MainForm.textBoxAddToClass.Text;
            MainForm.Figure.Draw(MainForm.Graphics);
            MainForm.Figures.Add(MainForm.Figure);

            DrawAllFigures();
            SetGroupBoxAddingToClass();
        }

        public void ButtonAddToClass_Click()
        {
            if (MainForm.Block is PropertyBlock)
            {
                AddToClassAndMoveChosenBorderAndArrows(((AbstractRectangle)MainForm.Figure).PropertyBlocks);
            }
            else if (MainForm.Block is MethodBlock)
            {
                AddToClassAndMoveChosenBorderAndArrows(((AbstractRectangle)MainForm.Figure).MethodBlocks);
            }
        }

        public void AddToClassAndMoveChosenBorderAndArrows(List<AbstractBlock> list)
        {
            int index = list.IndexOf(MainForm.Block);

            if (MainForm.Block is PropertyBlock)
            {
                list.Insert(index + 1, new PropertyBlock());
            }
            else if (MainForm.Block is MethodBlock)
            {
                list.Insert(index + 1, new MethodBlock());
            }

            ((AbstractRectangle)MainForm.Figure).MoveAllArrowsDown(MainForm.Block);
            SetAllElements();
            DrawAllFigures();
        }

        public void DeleteInAbstractRectangle()
        {
            if (MainForm.Block is TitleBlock)
            {
                DeleteAllArrowsOfAbstractRectangle((AbstractRectangle)MainForm.Figure);
                MainForm.Figures.Remove(MainForm.Figure);

                SetAllElementsVisionToFalse();
            }
            else
            {
                if (MainForm.Block is PropertyBlock)
                {
                    DeleteFromClassAndMoveChosenBorderAndArrows(((AbstractRectangle)MainForm.Figure).PropertyBlocks);
                }
                else if (MainForm.Block is MethodBlock)
                {
                    DeleteFromClassAndMoveChosenBorderAndArrows(((AbstractRectangle)MainForm.Figure).MethodBlocks);
                }
            }

            DrawAllFigures();
        }

        public void DeleteAllArrowsOfAbstractRectangle(AbstractRectangle rectangle)
        {
            DeleteAllArrowsOfBlock(rectangle.TitleBlock);

            foreach (AbstractBlock block in rectangle.PropertyBlocks)
            {
                DeleteAllArrowsOfBlock(block);
            }

            foreach (AbstractBlock block in rectangle.MethodBlocks)
            {
                DeleteAllArrowsOfBlock(block);
            }
        }

        public void DeleteFromClassAndMoveChosenBorderAndArrows(List<AbstractBlock> list)
        {
            DeleteAllArrowsOfBlock(MainForm.Block);
            ((AbstractRectangle)MainForm.Figure).MoveAllArrowsUp(MainForm.Block);
            int index = list.IndexOf(MainForm.Block);

            if (list.Count != 1)
            {
                list.Remove(MainForm.Block);
            }
            else
            {
                MainForm.Block.Text = string.Empty;
                MainForm.textBoxAddToClass.Text = string.Empty;
            }

            MainForm.Block = null;

            if (index < list.Count - 1 || (index == list.Count - 1 && list.Count > 1))
            {
                MainForm.Block = list[index];
            }
            else if (list.Count == 1 && index == 0)
            {
                MainForm.Block = list[0];
                MainForm.buttonDeleteFromClass.Visible = false;
            }
            else
            {
                MainForm.Block = list[index - 1];
                SetAllElements();
            }

            MainForm.Block.IsChosen = true;
        }

        public void ButtonSave_Click()
        {
            DialogResult result = MainForm.saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string path = MainForm.saveFileDialog.FileName;

                JsonSerializer serializer = new JsonSerializer();
                serializer.Converters.Add(new Newtonsoft.Json.Converters.JavaScriptDateTimeConverter());
                serializer.NullValueHandling = NullValueHandling.Ignore;
                serializer.TypeNameHandling = TypeNameHandling.Auto;
                serializer.Formatting = Formatting.Indented;

                using (StreamWriter sw = new StreamWriter(path))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, MainForm.Figures);
                }
            }
        }

        public void ButtonOpen_Click()
        {
            DialogResult result = MainForm.openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string path = MainForm.openFileDialog.FileName;
                TmpFigures = new List<IFigure>();

                using (StreamReader sw = new StreamReader(path))
                {
                    TmpFigures = JsonConvert.DeserializeObject<List<IFigure>>(File.ReadAllText(path), new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Auto,
                        NullValueHandling = NullValueHandling.Ignore,
                    });
                }

                MainForm.Figures.Clear();

                foreach (IFigure figure in TmpFigures)
                {
                    if (figure is AbstractArrow arrow)
                    {
                        AddArrowToBlocks(arrow);
                    }

                    MainForm.Figures.Add(figure);
                }

                DrawAllFigures();
                SetAllElementsVisionToFalse();
            }

        }

        public void AddArrowToBlocks(AbstractArrow arrow)
        {
            AbstractRectangle abstractRectangleFirst = GetChosenAbstractRectangleOrNull(arrow.StartPoint);
            DrawingArrowHelper drawingArrowHover = new DrawingArrowHelper(abstractRectangleFirst, arrow.StartPoint);
            AbstractBlock blockFirst = drawingArrowHover.BlockRectangle;

            AbstractRectangle abstractRectangleSecond = GetChosenAbstractRectangleOrNull(arrow.EndPoint);
            drawingArrowHover = new DrawingArrowHelper(abstractRectangleSecond, arrow.EndPoint);
            AbstractBlock blockSecond = drawingArrowHover.BlockRectangle;

            blockFirst.StartedArrows.Add(arrow);
            blockSecond.EndedArrows.Add(arrow);
        }
    }
}