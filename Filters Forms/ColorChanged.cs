using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace IPLab.Filters_Forms
{
    public partial class ColorChanged : Form
    {
        public IFilter filter;
        public ColorChanged()
        {
            InitializeComponent();
        }
        public IFilter Filter
        {
            get { return filter; }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked)
                {
                    filter = new ChannelFiltering(new IntRange(0, 255), new IntRange(0, 0), new IntRange(0, 0));
                }
                else if (radioButton2.Checked)
                {
                    filter = new ChannelFiltering(new IntRange(0, 0), new IntRange(0, 255), new IntRange(0, 0));
                }
                else if (radioButton3.Checked)
                {
                    filter = new ChannelFiltering(new IntRange(0, 0), new IntRange(0, 0), new IntRange(0, 255));
                }
                else if (radioButton4.Checked)
                {
                    filter = new ChannelFiltering(new IntRange(0, 0), new IntRange(0, 255), new IntRange(0, 255));
                }
                else if (radioButton5.Checked)
                {
                    filter = new ChannelFiltering(new IntRange(0, 255), new IntRange(0, 0), new IntRange(0, 255));
                }
                else if (radioButton6.Checked)
                {
                    filter = new ChannelFiltering(new IntRange(0, 255), new IntRange(0, 255), new IntRange(0, 0));
                }
                else if (radioButton7.Checked)
                {
                    filter = new Sepia();
                }
                else if(radioButton8.Checked)
                {
                    filter = new Invert();
                }
                else if(radioButton9.Checked) 
                {
                    filter = new RotateChannels();
                }
                else if(radioButton10.Checked)
                {
                    filter = new ExtractChannel(RGB.R);
                }
                else if(radioButton11.Checked)
                {
                    filter = new ExtractChannel(RGB.G);
                }
                else if (radioButton12.Checked)
                {
                    filter = new ExtractChannel(RGB.B);
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

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
