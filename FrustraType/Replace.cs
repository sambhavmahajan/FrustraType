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
    public partial class Replace : Form
    {
        public int n;
        public int optionSelected;
        public string replaced;
        public string replaceWith;
        public Replace()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            radioButton2.Text = "First " + textBox2.Text;
            radioButton3.Text = "Last " + textBox2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked) optionSelected = 1;
            else if (radioButton2.Checked) optionSelected = 2;
            else if (radioButton3.Checked) optionSelected = 3;
            else optionSelected = 4;
            if (textBox2.Text == "") textBox2.Text = "0";
            replaced = textBox1.Text;
            replaceWith = textBox3.Text;
            n = int.Parse(textBox2.Text);
            this.DialogResult = DialogResult.OK;
        }
    }
}
