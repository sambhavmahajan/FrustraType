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
        private bool save()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                saveFileDialog.Title = "Save Text File";
                if (publicVariables.Path.Length > 0) {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;
                        try
                        {
                            File.WriteAllText(filePath, richTextBox1.Text);
                            MessageBox.Show("File saved successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else return false;
                }
                else
                {
                    try
                    {
                        File.WriteAllText(publicVariables.Path, richTextBox1.Text);
                        MessageBox.Show("File saved successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }
        private bool open()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                openFileDialog.Title = "Open Text File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    try
                    {
                        string fileContent = File.ReadAllText(filePath);
                        richTextBox1.Text = fileContent;
                        MessageBox.Show("File opened successfully!", "Opened", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error opening file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!publicVariables.isSaved)
            {
                DialogResult result = MessageBox.Show("Do you want to save the file before creating a new file?", "Save File", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (DialogResult)
                {
                    case DialogResult.Yes:
                        if (save())
                        {
                            publicVariables.isSaved = false;
                            publicVariables.Path = string.Empty;

                        }
                        break;
                    case DialogResult.No:
                        publicVariables.isSaved = false;
                        publicVariables.Path = string.Empty;
                        break;
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!publicVariables.isSaved)
            {
                if(save())
                {
                    open();
                }
            }
        }
    }
    public static class publicVariables
    {
        public static bool isSaved = false;
        public static string Path = "";
    }
}
