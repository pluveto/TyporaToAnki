using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TyporaToAnki
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            var pattern = @"(\$\$)((.|\n)+?)(\$\$)";
            var pattern2 = @"\$(.+?)\$";

            var input = inputBox.Text;
            var output = Regex.Replace(input, pattern, "\\[$2\\]");

            output = Regex.Replace(output, pattern2, "\\($1\\)");
            outputBox.Text = output;
            try
            {
                Clipboard.SetText(output);
            }
            catch (Exception)
            {
                return;
            }

        }

        private void mainForm_Load(object sender, EventArgs e)
        {

        }

        private void inputBox_DoubleClick(object sender, EventArgs e)
        {
            inputBox.Text = Clipboard.GetText();
            btnConvert_Click(sender, e);
        }
    }
}
