using System.Security.Cryptography.X509Certificates;

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

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(publicVariables.Path, richTextBox1.Text);
                MessageBox.Show("File saved successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Textbox tb = new Textbox();
            if (tb.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < tb.input; ++i) richTextBox1.Paste();
            }
        }
        private void addTextToSelectedPos(string textToAdd)
        {
            int cursorPosition = richTextBox1.SelectionStart;
            richTextBox1.Text = richTextBox1.Text.Insert(cursorPosition, textToAdd);
            richTextBox1.SelectionStart = cursorPosition + textToAdd.Length;
            richTextBox1.Focus();
        }
        private void addFormatedNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Formated_Number formated_Number = new Formated_Number();
            if (formated_Number.ShowDialog() == DialogResult.OK)
            {
                float start = formated_Number.start;
                float end = formated_Number.end;
                string format = formated_Number.format;
                string sep = formated_Number.separator;
                float interval_width = (end - start) / formated_Number.interval_size;
                for (float i = start; i < end; i += interval_width)
                {
                    addTextToSelectedPos(format.Replace("{VALUE}", Convert.ToString(i)) + sep);
                }
            }
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Replace replace = new Replace();
            if (replace.ShowDialog() == DialogResult.OK)
            {
                switch(replace.optionSelected)
                {
                    case 1:
                        richTextBox1.Text = richTextBox1.Text.Replace(replace.replaced,replace.replaceWith);
                        break;
                    case 2:
                        for (int i = 0; i < replace.n; i++)
                        {
                            int startIndex = richTextBox1.Find(replace.replaced);
                            if (startIndex != -1)
                            {
                                richTextBox1.Select(startIndex, replace.replaced.Length);
                                richTextBox1.SelectedText = replace.replaceWith;
                            }
                            else
                            {
                                break;
                            }
                        }
                        break;
                    case 3:
                        for (int i = 0; i < replace.n; i++)
                        {
                            int startIndex = richTextBox1.Text.LastIndexOf(replace.replaced);
                            if (startIndex != -1)
                            {
                                richTextBox1.Select(startIndex, replace.replaced.Length);
                                richTextBox1.SelectedText = replace.replaceWith;
                            }
                            else
                            {
                                break;
                            }
                        }
                        break;
                    case 4:
                        break;
                }
            }
        }
        private FormWindowState prevFWS = FormWindowState.Normal;
        private void fullViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fullViewToolStripMenuItem.Checked = !fullViewToolStripMenuItem.Checked;
            if(fullViewToolStripMenuItem.Checked)
            {
                prevFWS = this.WindowState;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = prevFWS;
            }
        }
    }
    public static class publicVariables
    {
        public static bool isSaved = true;
        public static string Path = "";
    }
}
