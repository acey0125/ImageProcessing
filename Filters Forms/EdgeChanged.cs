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
    public partial class EdgeChanged : Form
    {

        public IFilter filter;
        public IFilter Filter
        {
            get { return filter; }
        }
        public EdgeChanged()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked)
                {
                    filter = new HomogenityEdgeDetector();
                }
                else if (radioButton2.Checked)
                {
                    filter = new DifferenceEdgeDetector();
                }
                else if (radioButton4.Checked)
                {
                    filter = new SobelEdgeDetector();
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
