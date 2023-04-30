using UMLPainter.Rectangles.Blocks;
using Newtonsoft.Json;
using UMLPainter.Helpers;

namespace UMLPainter.Rectangles
{
    public abstract class AbstractRectangle : IFigure
    {
        protected Pen _pen = new Pen(Color.Black, 1);

        public AbstractRectangle()
        {

        }

        public int FigureWidth { get; set; }

        public Color FigureColor { get; set; }

        public Point StartPoint { get; set; }

        public Point EndPoint { get; set; }

        public int Width { get; set; }

        [JsonIgnore]
        public List<AbstractBlock> TitleBlocks { get; set; }

        public List<AbstractBlock> PropertyBlocks { get; set; }

        public List<AbstractBlock> MethodBlocks { get; set; }

        public TitleBlock TitleBlock { get; set; }

        public AbstractBlock BottomBlock { get; set; }

        public abstract void Draw(Graphics graphics);

        public void DrawTitleBlock(Graphics graphics)
        {
            TitleBlock.StartPoint = StartPoint;
            TitleBlock.Width = GetWidth();
            TitleBlock.Draw(_pen, graphics);
            graphics.DrawRectangle(_pen, TitleBlock.Rectangle);
            EndPoint = TitleBlock.EndPoint;
        }

        public void DrawPropertyBlocks(Graphics graphics)
        {
            DrawNotTitleBlocksAround(graphics, PropertyBlocks);
            DrawNotTitleBlocks(graphics, PropertyBlocks);
        }

        public void DrawMethodBlocks(Graphics graphics)
        {
            DrawNotTitleBlocksAround(graphics, MethodBlocks);
            DrawNotTitleBlocks(graphics, MethodBlocks);
        }

        public void DrawNotTitleBlocks(Graphics graphics, List<AbstractBlock> blockList)
        {
            foreach (AbstractBlock block in blockList)
            {
                block.Width = GetWidth();
                block.StartPoint = new Point(StartPoint.X, EndPoint.Y);
                block.Draw(_pen, graphics);
                EndPoint = block.EndPoint;
            }
        }

        public void DrawNotTitleBlocksAround(Graphics graphics, List<AbstractBlock> blockList)
        {
            Point blocksStartPoint = new Point(StartPoint.X, EndPoint.Y);
            Size size = new Size(GetWidth(), blockList.Count * blockList[0].Height);
            Rectangle blocksRectangle = new Rectangle(blocksStartPoint, size);
            graphics.DrawRectangle(_pen, blocksRectangle);
        }

        public bool IsFigure(Point point)
        {
            bool isFigure = false;

            if (point.X >= StartPoint.X - RectangleOptions.DeltaOfChosenBorderForDrawing
            &&  point.X <= EndPoint.X + RectangleOptions.DeltaOfChosenBorderForDrawing)
            {
                if (point.Y >= StartPoint.Y && point.Y <= EndPoint.Y)
                {
                    isFigure = true;
                }
            }

            return isFigure;
        }

        public void Move(int deltaX, int deltaY)
        {
            StartPoint = new Point(StartPoint.X + deltaX, StartPoint.Y + deltaY);
            MoveAllArrows(deltaX, deltaY);
        }

        public int GetWidth()
        {
            AbstractBlock blockWithLongestString = GetBlockWithLongestString();
            int widthPrevious = Width;

            if (blockWithLongestString.Text.Length < RectangleOptions.StandardTextLength)
            {
                Width = RectangleOptions.StandardWidth;
            }
            else
            {
                Width = blockWithLongestString.Text.Length * blockWithLongestString.FontSize;
            }

            MoveAllArrows(Width - widthPrevious, 0);

            return Width;
        }

        public AbstractBlock? GetChosenBlock(Point point)
        {
            AbstractBlock? chosenRectangle = null;

            foreach (AbstractBlock titleRectangle in TitleBlocks)
            {
                if (titleRectangle.IsBlock(point))
                {
                    chosenRectangle = titleRectangle;
                }
            }

            foreach (AbstractBlock propertyRectangle in PropertyBlocks)
            {
                if (propertyRectangle.IsBlock(point))
                {
                    chosenRectangle = propertyRectangle;
                }
            }

            foreach (AbstractBlock methodRectangle in MethodBlocks)
            {
                if (methodRectangle.IsBlock(point))
                {
                    chosenRectangle = methodRectangle;
                }
            }

            return chosenRectangle;
        }

        public AbstractBlock GetBlockWithLongestString()
        {
            AbstractBlock blockWithLongestString = TitleBlock;

            foreach (AbstractBlock propertyRectangle in PropertyBlocks)
            {
                if (propertyRectangle.Text.Length > blockWithLongestString.Text.Length)
                {
                    blockWithLongestString = propertyRectangle;
                }
            }

            foreach (AbstractBlock methodRectangle in MethodBlocks)
            {
                if (methodRectangle.Text.Length > blockWithLongestString.Text.Length)
                {
                    blockWithLongestString = methodRectangle;
                }
            }

            return blockWithLongestString;
        }

        public void MoveAllArrows(int deltaX, int deltaY)
        {
            MoveArrowsOfBlockList(TitleBlocks, deltaX, deltaY);
            MoveArrowsOfBlockList(PropertyBlocks, deltaX, deltaY);
            MoveArrowsOfBlockList(MethodBlocks, deltaX, deltaY);
        }

        public void MoveAllArrowsDown(AbstractBlock block)
        {
            MoveBottomArrowsDown(block, MethodBlocks);
            MoveArrowsOfBlocksInListLowerCurrentBlock(PropertyBlocks, block, Direction.Down);
            MoveArrowsOfBlocksInListLowerCurrentBlock(MethodBlocks, block, Direction.Down);
        }

        public void MoveAllArrowsUp(AbstractBlock block)
        {
            MoveBottomArrowsUp(block, MethodBlocks);
            MoveArrowsOfBlocksInListLowerCurrentBlock(PropertyBlocks, block, Direction.Up);
            MoveArrowsOfBlocksInListLowerCurrentBlock(MethodBlocks, block, Direction.Up);
        }

        public void MoveArrowsOfBlockList(List<AbstractBlock> blockList, int deltaX, int deltaY)
        {
            foreach (AbstractBlock block in blockList)
            {
                block.MoveArrowsOfBlock(deltaX, deltaY);
            }
        }

        public void MoveArrowsOfBlocksInListLowerCurrentBlock(List<AbstractBlock> blockList, AbstractBlock currentBlock, Direction direction)
        {
            int directionCoefficient = 1;

            if (direction == Direction.Up)
            {
                directionCoefficient = -1;
            }

            foreach (AbstractBlock block in blockList)
            {
                if (block.StartPoint.Y > currentBlock.StartPoint.Y)
                {
                    block.MoveArrowsOfBlock(0, block.Height * directionCoefficient);
                }
            }
        }

        public void MoveBottomArrowsDown(AbstractBlock block, List<AbstractBlock> list)
        {
            if (block == BottomBlock)
            {
                foreach (AbstractArrow arrow in block.StartedArrows)
                {
                    if (arrow.StartSide == Side.Bottom)
                    {
                        list[list.Count - 1].StartedArrows.Add(arrow);
                    }
                }

                block.StartedArrows.Clear();

                foreach (AbstractArrow arrow in block.EndedArrows)
                {
                    if (arrow.EndSide == Side.Bottom)
                    {
                        list[list.Count - 1].EndedArrows.Add(arrow);
                    }
                }

                block.EndedArrows.Clear();

                list[list.Count - 1].MoveArrowsOfBlock(0, block.Height);
            }
        }

        public void MoveBottomArrowsUp(AbstractBlock block, List<AbstractBlock> list)
        {
            if (list.Count >= 2)
            {
                if (block == BottomBlock)
                {
                    foreach (AbstractArrow arrow in block.StartedArrows)
                    {
                        if (arrow.StartSide == Side.Bottom)
                        {
                            list[list.Count - 2].StartedArrows.Add(arrow);
                        }
                    }

                    block.StartedArrows.Clear();

                    foreach (AbstractArrow arrow in block.EndedArrows)
                    {
                        if (arrow.EndSide == Side.Bottom)
                        {
                            list[list.Count - 2].EndedArrows.Add(arrow);
                        }
                    }

                    block.EndedArrows.Clear();
                    list[list.Count - 2].MoveArrowsOfBlock(0, -block.Height);
                }
            }
        }
    }
}