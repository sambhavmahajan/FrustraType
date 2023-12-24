namespace FrustraType
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
    public static class publicVariables
    {
        public static bool isSaved = false;
        public static string Path = "";
    }
}
