namespace FrustraType
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Form1(string name)
        {
            InitializeComponent();
            richTextBox1.Text = File.ReadAllText(name);
            publicVariables.Path = name;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private bool save()
        {
            if (!publicVariables.isSaved && publicVariables.Path.Length == 0)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                    saveFileDialog.Title = "Save Text File";

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
            }
            return true;
        }
        public bool Open()
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
                        publicVariables.Path = filePath;
                        MessageBox.Show("File opened successfully!", "Opened", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error opening file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    publicVariables.isSaved = true;
                    return true;
                }
            }
            return false;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            publicVariables.isSaved = false;
        }


        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!publicVariables.isSaved)
            {
                DialogResult result = MessageBox.Show("Do you want to save the file before creating a new file?", "Save File", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (result)
                {
                    case DialogResult.Yes:
                        if (save())
                        {
                            publicVariables.isSaved = true;
                            publicVariables.Path = string.Empty;
                            richTextBox1.Text = "";
                        }
                        break;
                    case DialogResult.No:
                        publicVariables.isSaved = true;
                        publicVariables.Path = string.Empty;
                        richTextBox1.Text = "";
                        break;
                }
            }
            else
            {
                publicVariables.isSaved = true;
                publicVariables.Path = string.Empty;
            }
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!publicVariables.isSaved || publicVariables.Path.Length > 0)
            {
                DialogResult result = MessageBox.Show("Do you want to save the file before opening a new file?", "Save File", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (save())
                {
                    Open();
                }
            }
            else Open();
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            save();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
    public static class publicVariables
    {
        public static bool isSaved = true;
        public static string Path = "";
    }
}
