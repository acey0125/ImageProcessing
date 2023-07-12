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
    /// Summary description for ColorFilteringForm.
    /// </summary>
    public class ColorFilteringForm : Form
    {
        private ColorFiltering filter = new ColorFiltering( );
        private IntRange red = new IntRange( 0, 255 );
        private IntRange green = new IntRange( 0, 255 );
        private IntRange blue = new IntRange( 0, 255 );
        private byte fillR = 0, fillG = 0, fillB = 0;

        private GroupBox groupBox3;
        private IPLab.ColorSlider blueSlider;
        private TextBox fillBBox;
        private TextBox maxBBox;
        private Label label8;
        private TextBox minBBox;
        private Label label9;
        private GroupBox groupBox2;
        private IPLab.ColorSlider greenSlider;
        private TextBox fillGBox;
        private TextBox maxGBox;
        private Label label5;
        private TextBox minGBox;
        private Label label6;
        private GroupBox groupBox1;
        private IPLab.ColorSlider redSlider;
        private TextBox fillRBox;
        private TextBox maxRBox;
        private Label label2;
        private TextBox minRBox;
        private Label label1;
        private GroupBox groupBox4;
        private Label label10;
        private Label label3;
        private Label label4;
        private GroupBox groupBox5;
        private IPLab.FilterPreview filterPreview;
        private Button cancelButton;
        private Button okButton;
        private Label label7;
        private ComboBox fillTypeCombo;
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
        public ColorFilteringForm( )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );

            //
            minRBox.Text = red.Min.ToString( );
            maxRBox.Text = red.Max.ToString( );
            fillRBox.Text = fillR.ToString( );
            //
            minGBox.Text = green.Min.ToString( );
            maxGBox.Text = green.Max.ToString( );
            fillGBox.Text = fillG.ToString( );
            //
            minBBox.Text = blue.Min.ToString( );
            maxBBox.Text = blue.Max.ToString( );
            fillBBox.Text = fillB.ToString( );

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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.blueSlider = new IPLab.ColorSlider();
            this.maxBBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.minBBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.fillBBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.greenSlider = new IPLab.ColorSlider();
            this.maxGBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.minGBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.fillGBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.redSlider = new IPLab.ColorSlider();
            this.maxRBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.minRBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fillRBox = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.filterPreview = new IPLab.FilterPreview();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.fillTypeCombo = new System.Windows.Forms.ComboBox();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.blueSlider);
            this.groupBox3.Controls.Add(this.maxBBox);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.minBBox);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(44, 546);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(728, 162);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Blue";
            // 
            // blueSlider
            // 
            this.blueSlider.Color2 = System.Drawing.Color.Blue;
            this.blueSlider.Location = new System.Drawing.Point(21, 97);
            this.blueSlider.Name = "blueSlider";
            this.blueSlider.Size = new System.Drawing.Size(681, 49);
            this.blueSlider.TabIndex = 6;
            this.blueSlider.TabStop = false;
            this.blueSlider.Type = IPLab.ColorSliderType.InnerGradient;
            this.blueSlider.ValuesChanged += new System.EventHandler(this.blueSlider_ValuesChanged);
            // 
            // maxBBox
            // 
            this.maxBBox.Location = new System.Drawing.Point(567, 43);
            this.maxBBox.Name = "maxBBox";
            this.maxBBox.Size = new System.Drawing.Size(130, 45);
            this.maxBBox.TabIndex = 3;
            this.maxBBox.TextChanged += new System.EventHandler(this.maxBBox_TextChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(484, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 30);
            this.label8.TabIndex = 2;
            this.label8.Text = "Max:";
            // 
            // minBBox
            // 
            this.minBBox.Location = new System.Drawing.Point(104, 43);
            this.minBBox.Name = "minBBox";
            this.minBBox.Size = new System.Drawing.Size(130, 45);
            this.minBBox.TabIndex = 1;
            this.minBBox.TextChanged += new System.EventHandler(this.minBBox_TextChanged);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(26, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 30);
            this.label9.TabIndex = 0;
            this.label9.Text = "Min:";
            // 
            // fillBBox
            // 
            this.fillBBox.Location = new System.Drawing.Point(567, 43);
            this.fillBBox.Name = "fillBBox";
            this.fillBBox.Size = new System.Drawing.Size(130, 45);
            this.fillBBox.TabIndex = 2;
            this.fillBBox.TextChanged += new System.EventHandler(this.fillBBox_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.greenSlider);
            this.groupBox2.Controls.Add(this.maxGBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.minGBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(44, 374);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(728, 161);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Green";
            // 
            // greenSlider
            // 
            this.greenSlider.Color2 = System.Drawing.Color.Lime;
            this.greenSlider.Location = new System.Drawing.Point(21, 97);
            this.greenSlider.Name = "greenSlider";
            this.greenSlider.Size = new System.Drawing.Size(681, 49);
            this.greenSlider.TabIndex = 6;
            this.greenSlider.TabStop = false;
            this.greenSlider.Type = IPLab.ColorSliderType.InnerGradient;
            this.greenSlider.ValuesChanged += new System.EventHandler(this.greenSlider_ValuesChanged);
            // 
            // maxGBox
            // 
            this.maxGBox.Location = new System.Drawing.Point(567, 43);
            this.maxGBox.Name = "maxGBox";
            this.maxGBox.Size = new System.Drawing.Size(130, 45);
            this.maxGBox.TabIndex = 3;
            this.maxGBox.TextChanged += new System.EventHandler(this.maxGBox_TextChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(484, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 30);
            this.label5.TabIndex = 2;
            this.label5.Text = "Max:";
            // 
            // minGBox
            // 
            this.minGBox.Location = new System.Drawing.Point(104, 43);
            this.minGBox.Name = "minGBox";
            this.minGBox.Size = new System.Drawing.Size(130, 45);
            this.minGBox.TabIndex = 1;
            this.minGBox.TextChanged += new System.EventHandler(this.minGBox_TextChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(26, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 30);
            this.label6.TabIndex = 0;
            this.label6.Text = "Min:";
            // 
            // fillGBox
            // 
            this.fillGBox.Location = new System.Drawing.Point(312, 43);
            this.fillGBox.Name = "fillGBox";
            this.fillGBox.Size = new System.Drawing.Size(130, 45);
            this.fillGBox.TabIndex = 1;
            this.fillGBox.TextChanged += new System.EventHandler(this.fillGBox_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.redSlider);
            this.groupBox1.Controls.Add(this.maxRBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.minRBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(44, 202);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(728, 161);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Red";
            // 
            // redSlider
            // 
            this.redSlider.Color2 = System.Drawing.Color.Red;
            this.redSlider.Location = new System.Drawing.Point(21, 97);
            this.redSlider.Name = "redSlider";
            this.redSlider.Size = new System.Drawing.Size(681, 49);
            this.redSlider.TabIndex = 6;
            this.redSlider.TabStop = false;
            this.redSlider.Type = IPLab.ColorSliderType.InnerGradient;
            this.redSlider.ValuesChanged += new System.EventHandler(this.redSlider_ValuesChanged);
            // 
            // maxRBox
            // 
            this.maxRBox.Location = new System.Drawing.Point(567, 43);
            this.maxRBox.Name = "maxRBox";
            this.maxRBox.Size = new System.Drawing.Size(130, 45);
            this.maxRBox.TabIndex = 3;
            this.maxRBox.TextChanged += new System.EventHandler(this.maxRBox_TextChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(484, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Max:";
            // 
            // minRBox
            // 
            this.minRBox.Location = new System.Drawing.Point(104, 43);
            this.minRBox.Name = "minRBox";
            this.minRBox.Size = new System.Drawing.Size(130, 45);
            this.minRBox.TabIndex = 1;
            this.minRBox.TextChanged += new System.EventHandler(this.minRBox_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(26, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Min:";
            // 
            // fillRBox
            // 
            this.fillRBox.Location = new System.Drawing.Point(78, 43);
            this.fillRBox.Name = "fillRBox";
            this.fillRBox.Size = new System.Drawing.Size(130, 45);
            this.fillRBox.TabIndex = 0;
            this.fillRBox.TextChanged += new System.EventHandler(this.fillRBox_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.fillRBox);
            this.groupBox4.Controls.Add(this.fillGBox);
            this.groupBox4.Controls.Add(this.fillBBox);
            this.groupBox4.Location = new System.Drawing.Point(44, 718);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(728, 108);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Fill color";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(512, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 30);
            this.label4.TabIndex = 7;
            this.label4.Text = "B:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(260, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 30);
            this.label3.TabIndex = 6;
            this.label3.Text = "G:";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(26, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 30);
            this.label10.TabIndex = 0;
            this.label10.Text = "R:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.filterPreview);
            this.groupBox5.Location = new System.Drawing.Point(794, 78);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(748, 783);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Preview";
            // 
            // filterPreview
            // 
            this.filterPreview.Image = null;
            this.filterPreview.Location = new System.Drawing.Point(6, 32);
            this.filterPreview.Name = "filterPreview";
            this.filterPreview.Size = new System.Drawing.Size(736, 745);
            this.filterPreview.TabIndex = 0;
            this.filterPreview.TabStop = false;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(834, 993);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(195, 50);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(447, 993);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(195, 50);
            this.okButton.TabIndex = 8;
            this.okButton.Text = "Ok";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(556, 889);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 31);
            this.label7.TabIndex = 9;
            this.label7.Text = "Fill type:";
            // 
            // fillTypeCombo
            // 
            this.fillTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fillTypeCombo.Items.AddRange(new object[] {
            "Outside",
            "Inside"});
            this.fillTypeCombo.Location = new System.Drawing.Point(757, 886);
            this.fillTypeCombo.Name = "fillTypeCombo";
            this.fillTypeCombo.Size = new System.Drawing.Size(312, 40);
            this.fillTypeCombo.TabIndex = 7;
            this.fillTypeCombo.SelectedIndexChanged += new System.EventHandler(this.fillTypeCombo_SelectedIndexChanged);
            // 
            // ColorFilteringForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(15, 38);
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(1554, 1094);
            this.Controls.Add(this.fillTypeCombo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox5);
            this.Font = new System.Drawing.Font("»ªÎÄÖÐËÎ", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColorFilteringForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Color Filtering";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        // Update filter
        private void UpdateFilter( )
        {
            filter.Red = red;
            filter.Green = green;
            filter.Blue = blue;
            filterPreview.RefreshFilter( );
        }

        // Min red changed
        private void minRBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                redSlider.Min = red.Min = Math.Min( red.Max, byte.Parse( minRBox.Text ) );
                UpdateFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // Max red changed
        private void maxRBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                redSlider.Max = red.Max = Math.Max( red.Min, byte.Parse( maxRBox.Text ) );
                UpdateFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // Min green changed
        private void minGBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                greenSlider.Min = green.Min = Math.Min( green.Max, byte.Parse( minGBox.Text ) );
                UpdateFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // Max green changed
        private void maxGBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                greenSlider.Max = green.Max = Math.Max( green.Min, byte.Parse( maxGBox.Text ) );
                UpdateFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // Min blue changed
        private void minBBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                blueSlider.Min = blue.Min = Math.Min( blue.Max, byte.Parse( minBBox.Text ) );
                UpdateFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // Max blue changed
        private void maxBBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                blueSlider.Max = blue.Max = Math.Max( blue.Min, byte.Parse( maxBBox.Text ) );
                UpdateFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // Red slider changed
        private void redSlider_ValuesChanged( object sender, System.EventArgs e )
        {
            minRBox.Text = redSlider.Min.ToString( );
            maxRBox.Text = redSlider.Max.ToString( );
        }

        // Green slider changed
        private void greenSlider_ValuesChanged( object sender, System.EventArgs e )
        {
            minGBox.Text = greenSlider.Min.ToString( );
            maxGBox.Text = greenSlider.Max.ToString( );
        }

        // Blue slider changed
        private void blueSlider_ValuesChanged( object sender, System.EventArgs e )
        {
            minBBox.Text = blueSlider.Min.ToString( );
            maxBBox.Text = blueSlider.Max.ToString( );
        }

        // Fill red changed
        private void fillRBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                fillR = byte.Parse( fillRBox.Text );
                UpdateFillColor( );
            }
            catch ( Exception )
            {
            }
        }

        // Fill green changed
        private void fillGBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                fillG = byte.Parse( fillGBox.Text );
                UpdateFillColor( );
            }
            catch ( Exception )
            {
            }
        }

        // Fil blue changed
        private void fillBBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                fillB = byte.Parse( fillBBox.Text );
                UpdateFillColor( );
            }
            catch ( Exception )
            {
            }
        }

        // Update fil color
        private void UpdateFillColor( )
        {
            redSlider.Color3 = greenSlider.Color3 = blueSlider.Color3 = Color.FromArgb( fillR, fillG, fillB );
            filter.FillColor = new RGB( fillR, fillG, fillB );
            filterPreview.RefreshFilter( );
        }

        // Fill type changed
        private void fillTypeCombo_SelectedIndexChanged( object sender, System.EventArgs e )
        {
            ColorSliderType[] types = new ColorSliderType[] { ColorSliderType.InnerGradient, ColorSliderType.OuterGradient };
            ColorSliderType type = types[fillTypeCombo.SelectedIndex];

            redSlider.Type = type;
            greenSlider.Type = type;
            blueSlider.Type = type;

            filter.FillOutsideRange = ( fillTypeCombo.SelectedIndex == 0 );
            filterPreview.RefreshFilter( );
        }
    }
}
