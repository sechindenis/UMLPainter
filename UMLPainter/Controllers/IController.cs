namespace UMLPainter.Controllers
{
    public interface IController
    {
        void MouseClick(Point e);

        void MouseMove(Point e);

        void KeyDown_Control(KeyEventArgs e);    

        void ChangeWidth();

        void ChangeColor();
    }
}