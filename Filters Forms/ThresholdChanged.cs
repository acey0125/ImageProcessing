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
    public partial class ThresholdChanged : Form
    {
        public IFilter filter;

        public IFilter Filter
        {
            get { return filter; }
        }
        public ThresholdChanged()
        {
            InitializeComponent();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked)
                {
                    filter = new ThresholdWithCarry();
                }
                else if (radioButton2.Checked)
                {
                    filter = new OrderedDithering();
                }
                else if (radioButton3.Checked)
                {
                    filter = new BayerDithering();
                }
                else if (radioButton4.Checked)
                {
                    filter = new SISThreshold();
                }
                else if (radioButton7.Checked)
                {
                    filter = new FloydSteinbergDithering();
                }
                else if (radioButton8.Checked)
                {
                    filter = new BurkesDithering();
                }
                else if (radioButton9.Checked)
                {
                    filter = new StuckiDithering();
                }
                else if (radioButton10.Checked)
                {
                    filter = new JarvisJudiceNinkeDithering();
                }
                else if (radioButton11.Checked)
                {
                    filter = new SierraDithering();
                }
                else if (radioButton12.Checked)
                {
                    filter = new StevensonArceDithering();
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
