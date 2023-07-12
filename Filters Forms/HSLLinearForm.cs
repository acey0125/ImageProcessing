using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using AForge;
using AForge.Math;
using AForge.Imaging;
using AForge.Imaging.Filters;

namespace IPLab
{
    /// <summary>
    /// Summary description for HSLLinearForm.
    /// </summary>
    public class HSLLinearForm : Form
    {
        private HSLLinear filter = new HSLLinear( );
        private DoubleRange inSaturation = new DoubleRange( 0, 1 );
        private DoubleRange inLuminance = new DoubleRange( 0, 1 );
        private DoubleRange outSaturation = new DoubleRange( 0, 1 );
        private DoubleRange outLuminance = new DoubleRange( 0, 1 );
        private AForge.Imaging.ImageStatisticsHSL imgStat;

        private Label label1;
        private ComboBox componentCombo;
        private Label label2;
        private TextBox inMaxBox;
        private TextBox inMinBox;
        private IPLab.Histogram histogram;
        private IPLab.ColorSlider inSlider;
        private IPLab.ColorSlider outSlider;
        private TextBox outMaxBox;
        private TextBox outMinBox;
        private Label label3;
        private GroupBox groupBox4;
        private IPLab.FilterPreview filterPreview;
        private Button cancelButton;
        private Button okButton;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        // Image property
        public Bitmap Image
        {
            set { filterPreview.Image = value; }
        }
        // Filter property
        public IFilter Filter
        {
            get { return filter; }
        }

        // Constructor
        public HSLLinearForm( AForge.Imaging.ImageStatisticsHSL imgStat )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );

            //
            this.imgStat = imgStat;

            componentCombo.SelectedIndex = 0;

            filterPreview.Filter = filter;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if ( disposing )
            {
                if ( components != null )
                {
                    components.Dispose( );
                }
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            this.label1 = new System.Windows.Forms.Label();
            this.componentCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.inMaxBox = new System.Windows.Forms.TextBox();
            this.inMinBox = new System.Windows.Forms.TextBox();
            this.histogram = new IPLab.Histogram();
            this.inSlider = new IPLab.ColorSlider();
            this.outSlider = new IPLab.ColorSlider();
            this.outMaxBox = new System.Windows.Forms.TextBox();
            this.outMinBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.filterPreview = new IPLab.FilterPreview();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(36, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Component:";
            // 
            // componentCombo
            // 
            this.componentCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.componentCombo.Items.AddRange(new object[] {
            "Saturation",
            "Luminance"});
            this.componentCombo.Location = new System.Drawing.Point(218, 183);
            this.componentCombo.Name = "componentCombo";
            this.componentCombo.Size = new System.Drawing.Size(234, 40);
            this.componentCombo.TabIndex = 1;
            this.componentCombo.SelectedIndexChanged += new System.EventHandler(this.componentCombo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(36, 275);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 37);
            this.label2.TabIndex = 11;
            this.label2.Text = "&Input levels:";
            // 
            // inMaxBox
            // 
            this.inMaxBox.Location = new System.Drawing.Point(374, 269);
            this.inMaxBox.Name = "inMaxBox";
            this.inMaxBox.Size = new System.Drawing.Size(130, 45);
            this.inMaxBox.TabIndex = 13;
            this.inMaxBox.TextChanged += new System.EventHandler(this.inMaxBox_TextChanged);
            // 
            // inMinBox
            // 
            this.inMinBox.Location = new System.Drawing.Point(218, 269);
            this.inMinBox.Name = "inMinBox";
            this.inMinBox.Size = new System.Drawing.Size(130, 45);
            this.inMinBox.TabIndex = 12;
            this.inMinBox.TextChanged += new System.EventHandler(this.inMinBox_TextChanged);
            // 
            // histogram
            // 
            this.histogram.Location = new System.Drawing.Point(36, 323);
            this.histogram.Name = "histogram";
            this.histogram.Size = new System.Drawing.Size(671, 348);
            this.histogram.TabIndex = 14;
            // 
            // inSlider
            // 
            this.inSlider.Location = new System.Drawing.Point(31, 661);
            this.inSlider.Max = 253;
            this.inSlider.Min = 2;
            this.inSlider.Name = "inSlider";
            this.inSlider.Size = new System.Drawing.Size(681, 43);
            this.inSlider.TabIndex = 17;
            this.inSlider.TabStop = false;
            this.inSlider.ValuesChanged += new System.EventHandler(this.inSlider_ValuesChanged);
            // 
            // outSlider
            // 
            this.outSlider.Location = new System.Drawing.Point(31, 796);
            this.outSlider.Name = "outSlider";
            this.outSlider.Size = new System.Drawing.Size(681, 43);
            this.outSlider.TabIndex = 22;
            this.outSlider.TabStop = false;
            this.outSlider.ValuesChanged += new System.EventHandler(this.outSlider_ValuesChanged);
            // 
            // outMaxBox
            // 
            this.outMaxBox.Location = new System.Drawing.Point(374, 743);
            this.outMaxBox.Name = "outMaxBox";
            this.outMaxBox.Size = new System.Drawing.Size(130, 45);
            this.outMaxBox.TabIndex = 20;
            this.outMaxBox.TextChanged += new System.EventHandler(this.outMaxBox_TextChanged);
            // 
            // outMinBox
            // 
            this.outMinBox.Location = new System.Drawing.Point(218, 743);
            this.outMinBox.Name = "outMinBox";
            this.outMinBox.Size = new System.Drawing.Size(130, 45);
            this.outMinBox.TabIndex = 19;
            this.outMinBox.TextChanged += new System.EventHandler(this.outMinBox_TextChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(36, 749);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 37);
            this.label3.TabIndex = 18;
            this.label3.Text = "&Output levels:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.filterPreview);
            this.groupBox4.Location = new System.Drawing.Point(692, 82);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(807, 821);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Preview";
            // 
            // filterPreview
            // 
            this.filterPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterPreview.Image = null;
            this.filterPreview.Location = new System.Drawing.Point(3, 41);
            this.filterPreview.Name = "filterPreview";
            this.filterPreview.Size = new System.Drawing.Size(801, 777);
            this.filterPreview.TabIndex = 0;
            this.filterPreview.TabStop = false;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(807, 966);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(195, 50);
            this.cancelButton.TabIndex = 25;
            this.cancelButton.Text = "Cancel";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(459, 966);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(195, 50);
            this.okButton.TabIndex = 24;
            this.okButton.Text = "Ok";
            // 
            // HSLLinearForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(15, 38);
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(1520, 1074);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.outSlider);
            this.Controls.Add(this.outMaxBox);
            this.Controls.Add(this.outMinBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.inSlider);
            this.Controls.Add(this.histogram);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inMaxBox);
            this.Controls.Add(this.inMinBox);
            this.Controls.Add(this.componentCombo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("»ªÎÄÖÐËÎ", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HSLLinearForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HSL Linear correction";
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        // Selection changed in component combo
        private void componentCombo_SelectedIndexChanged( object sender, System.EventArgs e )
        {
            AForge.Math.ContinuousHistogram h = null;
            DoubleRange input = new DoubleRange( 0, 1 );
            DoubleRange output = new DoubleRange( 0, 1 );

            if ( componentCombo.SelectedIndex == 0 )
            {
                // satureation
                h = imgStat.Saturation;
                input = inSaturation;
                output = outSaturation;
            }
            else
            {
                // luminance
                h = imgStat.Luminance;
                input = inLuminance;
                output = outLuminance;
            }

            histogram.Values = h.Values;

            inMinBox.Text = input.Min.ToString( "F3" );
            inMaxBox.Text = input.Max.ToString( "F3" );
            outMinBox.Text = output.Min.ToString( "F3" );
            outMaxBox.Text = output.Max.ToString( "F3" );

            // input slider
            inSlider.Min = (int) ( input.Min * 255 );
            inSlider.Max = (int) ( input.Max * 255 );
            // output slider
            outSlider.Min = (int) ( output.Min * 255 );
            outSlider.Max = (int) ( output.Max * 255 );
        }

        // inMin changed
        private void inMinBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                double v = double.Parse( inMinBox.Text );

                if ( componentCombo.SelectedIndex == 0 )
                {
                    inSaturation.Min = v;
                }
                else
                {
                    inLuminance.Min = v;
                }
                inSlider.Min = (int) ( v * 255 );
                UpdateFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // inMax changed
        private void inMaxBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                double v = double.Parse( inMaxBox.Text );

                if ( componentCombo.SelectedIndex == 0 )
                {
                    inSaturation.Max = v;
                }
                else
                {
                    inLuminance.Max = v;
                }
                inSlider.Max = (int) ( v * 255 );
                UpdateFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // outMin changed
        private void outMinBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                double v = double.Parse( outMinBox.Text );

                if ( componentCombo.SelectedIndex == 0 )
                {
                    outSaturation.Min = v;
                }
                else
                {
                    outLuminance.Min = v;
                }
                outSlider.Min = (int) ( v * 255 );
                UpdateFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // outMax changed
        private void outMaxBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                double v = double.Parse( outMaxBox.Text );

                if ( componentCombo.SelectedIndex == 0 )
                {
                    outSaturation.Max = v;
                }
                else
                {
                    outLuminance.Max = v;
                }
                outSlider.Max = (int) ( v * 255 );
                UpdateFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // Input slider`s values changed
        private void inSlider_ValuesChanged( object sender, System.EventArgs e )
        {
            inMinBox.Text = ( (double) inSlider.Min / 255 ).ToString( "F3" );
            inMaxBox.Text = ( (double) inSlider.Max / 255 ).ToString( "F3" );
        }

        // Output slider`s values changed
        private void outSlider_ValuesChanged( object sender, System.EventArgs e )
        {
            outMinBox.Text = ( (double) outSlider.Min / 255 ).ToString( "F3" );
            outMaxBox.Text = ( (double) outSlider.Max / 255 ).ToString( "F3" );
        }

        // Update filert
        private void UpdateFilter( )
        {
            // input values
            filter.InLuminance = inLuminance;
            filter.InSaturation = inSaturation;
            // output values
            filter.OutLuminance = outLuminance;
            filter.OutSaturation = outSaturation;

            filterPreview.RefreshFilter( );
        }
    }
}
