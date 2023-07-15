using AForge.Imaging.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IPLab.Filters_Forms
{
    public partial class ConvolutionChanged : Form
    {
        public IFilter filter;
        public IFilter Filter
        {
            get { return filter; }
        }
        public ConvolutionChanged()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked)
                {
                    filter = new Mean();
                }
                else if (radioButton2.Checked)
                {
                    filter = new Blur();
                }
                else if (radioButton4.Checked)
                {
                    filter = new Sharpen();
                }
                else if (radioButton5.Checked)
                {
                    filter = new Edges();
                }

                // close the dialog
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Incorrect values are entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
