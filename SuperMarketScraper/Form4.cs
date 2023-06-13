using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMarketScraper
{
    public partial class Form4 : Form
    {
        public string New_search { get; set; }
        public Form4(string text, string caption)
        {
            InitializeComponent();
            this.Text = caption;
            this.label1.Text = text;
            this.AcceptButton = button1;
            var w = (TextRenderer.MeasureText(label1.Text, label1.Font)).Width / 2;
            this.textBox1.Width = w+80;
            this.textBox1.Location = new Point(this.textBox1.Location.X + (w / 2)-40, textBox1.Location.Y);
            this.button1.Width = this.textBox1.Width / 2;
            this.button1.Location = new Point(this.textBox1.Location.X + (textBox1.Width / 4), button1.Location.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                New_search = textBox1.Text;
                button1.DialogResult = DialogResult.OK;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
