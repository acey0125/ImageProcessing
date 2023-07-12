using AForge.Imaging;
using AForge;
using AForge.Imaging.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace IPLab.Filters_Forms
{
    public partial class MorphologyChanged : Form
    {
        public IFilter filter;
        public IFilter Filter
        {
            get { return filter; }
        }
        public MorphologyChanged()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked)
                {
                    filter = new Erosion();
                }
                else if (radioButton2.Checked)
                {
                    filter = new Dilatation();
                }
                else if (radioButton4.Checked)
                {
                    filter = new Opening();
                }
                else if (radioButton5.Checked)
                {
                    filter = new Closing();
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
