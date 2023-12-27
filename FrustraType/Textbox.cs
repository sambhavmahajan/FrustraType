using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrustraType
{
    public partial class Textbox : Form
    {
        public int input;
        public Textbox()
        {
            InitializeComponent();
        }
        public Textbox(string _title, string placeHolder)
        {
            InitializeComponent();
            this.Text = _title;
            textBox1.PlaceholderText = placeHolder;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            input = int.Parse(textBox1.Text);
            this.Close();
        }
    }
}
