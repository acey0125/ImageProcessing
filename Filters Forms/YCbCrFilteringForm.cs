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
    /// Summary description for YCbCrFilteringForm.
    /// </summary>
    public class YCbCrFilteringForm : Form
    {
        private YCbCrFiltering filter = new YCbCrFiltering( );
        private DoubleRange yRange = new DoubleRange( 0, 1 );
        private DoubleRange cbRange = new DoubleRange( -0.5, 0.5 );
        private DoubleRange crRange = new DoubleRange( -0.5, 0.5 );
        private double fillY = 0, fillCb = 0, fillCr = 0;

        private GroupBox groupBox1;
        private Label label1;
        private TextBox minYBox;
        private Label label2;
        private TextBox maxYBox;
        private IPLab.ColorSlider ySlider;
        private GroupBox groupBox2;
        private Label label3;
        private TextBox minCbBox;
        private Label label4;
        private TextBox maxCbBox;
        private IPLab.ColorSlider cbSlider;
        private GroupBox groupBox3;
        private Label label5;
        private Label label6;
        private IPLab.ColorSlider crSlider;
        private TextBox maxCrBox;
        private TextBox minCrBox;
        private GroupBox groupBox4;
        private Label label7;
        private TextBox fillYBox;
        private Label label8;
        private TextBox fillCbBox;
        private Label label9;
        private TextBox fillCrBox;
        private GroupBox groupBox5;
        private IPLab.FilterPreview filterPreview;
        private Label label10;
        private ComboBox fillTypeCombo;
        private Button okButton;
        private Button cancelButton;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

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
        public YCbCrFilteringForm( )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );

            //
            minYBox.Text = yRange.Min.ToString( "F3" );
            maxYBox.Text = yRange.Max.ToString( "F3" );
            fillYBox.Text = fillY.ToString( "F3" );

            minCbBox.Text = cbRange.Min.ToString( "F3" );
            maxCbBox.Text = cbRange.Max.ToString( "F3" );
            fillCbBox.Text = fillCb.ToString( "F3" );

            minCrBox.Text = crRange.Min.ToString( "F3" );
            maxCrBox.Text = crRange.Max.ToString( "F3" );
            fillCrBox.Text = fillCr.ToString( "F3" );

            fillTypeCombo.SelectedIndex = 0;

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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ySlider = new IPLab.ColorSlider();
            this.maxYBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.minYBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbSlider = new IPLab.ColorSlider();
            this.maxCbBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.minCbBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.crSlider = new IPLab.ColorSlider();
            this.maxCrBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.minCrBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.fillCrBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.fillCbBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.fillYBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.filterPreview = new IPLab.FilterPreview();
            this.label10 = new System.Windows.Forms.Label();
            this.fillTypeCombo = new System.Windows.Forms.ComboBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ySlider);
            this.groupBox1.Controls.Add(this.maxYBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.minYBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(26, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(728, 161);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Y";
            // 
            // ySlider
            // 
            this.ySlider.Location = new System.Drawing.Point(21, 97);
            this.ySlider.Name = "ySlider";
            this.ySlider.Size = new System.Drawing.Size(684, 49);
            this.ySlider.TabIndex = 4;
            this.ySlider.Type = IPLab.ColorSliderType.InnerGradient;
            this.ySlider.ValuesChanged += new System.EventHandler(this.ySlider_ValuesChanged);
            // 
            // maxYBox
            // 
            this.maxYBox.Location = new System.Drawing.Point(567, 43);
            this.maxYBox.Name = "maxYBox";
            this.maxYBox.Size = new System.Drawing.Size(130, 45);
            this.maxYBox.TabIndex = 3;
            this.maxYBox.TextChanged += new System.EventHandler(this.maxYBox_TextChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(484, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Max:";
            // 
            // minYBox
            // 
            this.minYBox.Location = new System.Drawing.Point(104, 43);
            this.minYBox.Name = "minYBox";
            this.minYBox.Size = new System.Drawing.Size(130, 45);
            this.minYBox.TabIndex = 1;
            this.minYBox.TextChanged += new System.EventHandler(this.minYBox_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(26, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Min:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbSlider);
            this.groupBox2.Controls.Add(this.maxCbBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.minCbBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(26, 253);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(728, 161);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cb";
            // 
            // cbSlider
            // 
            this.cbSlider.Location = new System.Drawing.Point(21, 97);
            this.cbSlider.Name = "cbSlider";
            this.cbSlider.Size = new System.Drawing.Size(684, 49);
            this.cbSlider.TabIndex = 4;
            this.cbSlider.Type = IPLab.ColorSliderType.InnerGradient;
            this.cbSlider.ValuesChanged += new System.EventHandler(this.cbSlider_ValuesChanged);
            // 
            // maxCbBox
            // 
            this.maxCbBox.Location = new System.Drawing.Point(567, 43);
            this.maxCbBox.Name = "maxCbBox";
            this.maxCbBox.Size = new System.Drawing.Size(130, 45);
            this.maxCbBox.TabIndex = 3;
            this.maxCbBox.TextChanged += new System.EventHandler(this.maxCbBox_TextChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(484, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 32);
            this.label4.TabIndex = 2;
            this.label4.Text = "Max:";
            // 
            // minCbBox
            // 
            this.minCbBox.Location = new System.Drawing.Point(104, 43);
            this.minCbBox.Name = "minCbBox";
            this.minCbBox.Size = new System.Drawing.Size(130, 45);
            this.minCbBox.TabIndex = 1;
            this.minCbBox.TextChanged += new System.EventHandler(this.minCbBox_TextChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(26, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 32);
            this.label3.TabIndex = 0;
            this.label3.Text = "Min:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.crSlider);
            this.groupBox3.Controls.Add(this.maxCrBox);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.minCrBox);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(26, 425);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(728, 162);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cr";
            // 
            // crSlider
            // 
            this.crSlider.Location = new System.Drawing.Point(21, 97);
            this.crSlider.Name = "crSlider";
            this.crSlider.Size = new System.Drawing.Size(684, 49);
            this.crSlider.TabIndex = 4;
            this.crSlider.Type = IPLab.ColorSliderType.InnerGradient;
            this.crSlider.ValuesChanged += new System.EventHandler(this.crSlider_ValuesChanged);
            // 
            // maxCrBox
            // 
            this.maxCrBox.Location = new System.Drawing.Point(567, 43);
            this.maxCrBox.Name = "maxCrBox";
            this.maxCrBox.Size = new System.Drawing.Size(130, 45);
            this.maxCrBox.TabIndex = 3;
            this.maxCrBox.TextChanged += new System.EventHandler(this.maxCrBox_TextChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(484, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 32);
            this.label5.TabIndex = 2;
            this.label5.Text = "Max:";
            // 
            // minCrBox
            // 
            this.minCrBox.Location = new System.Drawing.Point(104, 43);
            this.minCrBox.Name = "minCrBox";
            this.minCrBox.Size = new System.Drawing.Size(130, 45);
            this.minCrBox.TabIndex = 1;
            this.minCrBox.TextChanged += new System.EventHandler(this.minCrBox_TextChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(26, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 32);
            this.label6.TabIndex = 0;
            this.label6.Text = "Min:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.fillCrBox);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.fillCbBox);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.fillYBox);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(26, 597);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(728, 108);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Fill Color";
            // 
            // fillCrBox
            // 
            this.fillCrBox.Location = new System.Drawing.Point(567, 43);
            this.fillCrBox.Name = "fillCrBox";
            this.fillCrBox.Size = new System.Drawing.Size(130, 45);
            this.fillCrBox.TabIndex = 5;
            this.fillCrBox.TextChanged += new System.EventHandler(this.fillCrBox_TextChanged);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(507, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 34);
            this.label9.TabIndex = 4;
            this.label9.Text = "Cr:";
            // 
            // fillCbBox
            // 
            this.fillCbBox.Location = new System.Drawing.Point(312, 43);
            this.fillCbBox.Name = "fillCbBox";
            this.fillCbBox.Size = new System.Drawing.Size(130, 45);
            this.fillCbBox.TabIndex = 3;
            this.fillCbBox.TextChanged += new System.EventHandler(this.fillCbBox_TextChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(250, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 32);
            this.label8.TabIndex = 2;
            this.label8.Text = "Cb:";
            // 
            // fillYBox
            // 
            this.fillYBox.Location = new System.Drawing.Point(78, 43);
            this.fillYBox.Name = "fillYBox";
            this.fillYBox.Size = new System.Drawing.Size(130, 45);
            this.fillYBox.TabIndex = 1;
            this.fillYBox.TextChanged += new System.EventHandler(this.fillYBox_TextChanged);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(26, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 32);
            this.label7.TabIndex = 0;
            this.label7.Text = "Y:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.filterPreview);
            this.groupBox5.Location = new System.Drawing.Point(780, 22);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(683, 622);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Preview";
            // 
            // filterPreview
            // 
            this.filterPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterPreview.Image = null;
            this.filterPreview.Location = new System.Drawing.Point(3, 41);
            this.filterPreview.Name = "filterPreview";
            this.filterPreview.Size = new System.Drawing.Size(677, 578);
            this.filterPreview.TabIndex = 0;
            this.filterPreview.Text = "filterPreview1";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(793, 673);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(135, 33);
            this.label10.TabIndex = 8;
            this.label10.Text = "Fill type:";
            // 
            // fillTypeCombo
            // 
            this.fillTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fillTypeCombo.Items.AddRange(new object[] {
            "Outside",
            "Inside"});
            this.fillTypeCombo.Location = new System.Drawing.Point(976, 673);
            this.fillTypeCombo.Name = "fillTypeCombo";
            this.fillTypeCombo.Size = new System.Drawing.Size(312, 40);
            this.fillTypeCombo.TabIndex = 9;
            this.fillTypeCombo.SelectedIndexChanged += new System.EventHandler(this.fillTypeCombo_SelectedIndexChanged);
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(479, 766);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(195, 50);
            this.okButton.TabIndex = 10;
            this.okButton.Text = "Ok";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(780, 766);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(195, 50);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            // 
            // YCbCrFilteringForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(15, 38);
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(1494, 860);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.fillTypeCombo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("��������", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "YCbCrFilteringForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YCbCr Filtering";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion


        // Update filter
        private void UpdateFilter( )
        {
            filter.Y = yRange;
            filter.Cb = cbRange;
            filter.Cr = crRange;
            filterPreview.RefreshFilter( );
        }

        // Min Y changed
        private void minYBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                yRange.Min = Math.Max( 0.0, Math.Min( 1.0, double.Parse( minYBox.Text ) ) );
                ySlider.Min = (int) ( yRange.Min * 255 );
                UpdateFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // Max Y changed
        private void maxYBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                yRange.Max = Math.Max( 0.0, Math.Min( 1.0, double.Parse( maxYBox.Text ) ) );
                ySlider.Max = (int) ( yRange.Max * 255 );
                UpdateFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // Min Cb changed
        private void minCbBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                cbRange.Min = Math.Max( -0.5, Math.Min( 0.5, double.Parse( minCbBox.Text ) ) );
                cbSlider.Min = (int) ( ( cbRange.Min + 0.5 ) * 255 );
                UpdateFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // Max Cb changed
        private void maxCbBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                cbRange.Max = Math.Max( -0.5, Math.Min( 0.5, double.Parse( maxCbBox.Text ) ) );
                cbSlider.Max = (int) ( ( cbRange.Max + 0.5 ) * 255 );
                UpdateFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // Min Cb changed
        private void minCrBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                crRange.Min = Math.Max( -0.5, Math.Min( 0.5, double.Parse( minCrBox.Text ) ) );
                crSlider.Min = (int) ( ( crRange.Min + 0.5 ) * 255 );
                UpdateFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // Max Cb changed
        private void maxCrBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                crRange.Max = Math.Max( -0.5, Math.Min( 0.5, double.Parse( maxCrBox.Text ) ) );
                crSlider.Max = (int) ( ( crRange.Max + 0.5 ) * 255 );
                UpdateFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // Y slider changed
        private void ySlider_ValuesChanged( object sender, System.EventArgs e )
        {
            minYBox.Text = ( (double) ySlider.Min / 255 ).ToString( "F3" );
            maxYBox.Text = ( (double) ySlider.Max / 255 ).ToString( "F3" );
        }

        // Cb slider changed
        private void cbSlider_ValuesChanged( object sender, System.EventArgs e )
        {
            minCbBox.Text = ( (double) cbSlider.Min / 255 - 0.5 ).ToString( "F3" );
            maxCbBox.Text = ( (double) cbSlider.Max / 255 - 0.5 ).ToString( "F3" );
        }

        // Cr slider changed
        private void crSlider_ValuesChanged( object sender, System.EventArgs e )
        {
            minCrBox.Text = ( (double) crSlider.Min / 255 - 0.5 ).ToString( "F3" );
            maxCrBox.Text = ( (double) crSlider.Max / 255 - 0.5 ).ToString( "F3" );
        }

        // Fill Y changed
        private void fillYBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                fillY = double.Parse( fillYBox.Text );
                UpdateFillColor( );
            }
            catch ( Exception )
            {
            }
        }

        // Fill Cb changed
        private void fillCbBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                fillCb = double.Parse( fillCbBox.Text );
                UpdateFillColor( );
            }
            catch ( Exception )
            {
            }
        }

        // Fill Cr changed
        private void fillCrBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                fillCr = double.Parse( fillCrBox.Text );
                UpdateFillColor( );
            }
            catch ( Exception )
            {
            }
        }

        // Update fil color
        private void UpdateFillColor( )
        {
            filter.FillColor = new YCbCr( fillY, fillCb, fillCr );
            filterPreview.RefreshFilter( );
        }

        // Fill type changed
        private void fillTypeCombo_SelectedIndexChanged( object sender, System.EventArgs e )
        {
            ColorSliderType[] types = new ColorSliderType[] { ColorSliderType.InnerGradient, ColorSliderType.OuterGradient };
            ColorSliderType type = types[fillTypeCombo.SelectedIndex];

            ySlider.Type = type;
            cbSlider.Type = type;
            crSlider.Type = type;

            filter.FillOutsideRange = ( fillTypeCombo.SelectedIndex == 0 );
            filterPreview.RefreshFilter( );
        }
    }
}
