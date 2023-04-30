namespace UMLPainter.Forms
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
        }

        private void HelpForm_Load(object sender, EventArgs e)
        {
            label1.Text = "Selection mode on:\r\n" +
                            "\r\nif object of chosen\r\n" +
                            "\r\nCtrl + Delete - delete property, method or class" +
                            "\r\nDelete - delete arrow" +
                            "\r\nCtrl + Up - go to the next block up" +
                            "\r\nCtrl + Down - go to the next block down";
        }
    }
}