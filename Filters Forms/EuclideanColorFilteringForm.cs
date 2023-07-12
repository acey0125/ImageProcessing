using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using AForge.Imaging.Filters;

namespace IPLab
{
    /// <summary>
    /// Summary description for EuclideanColorFilteringForm.
    /// </summary>
    public class EuclideanColorFilteringForm : Form
    {
        private EuclideanColorFiltering filter = new EuclideanColorFiltering( );
        private byte red = 255, green = 255, blue = 255;
        private byte fillR = 0, fillG = 0, fillB = 0;
        private short radius = 100;

        private GroupBox groupBox4;
        private Label label4;
        private Label label3;
        private Label label10;
        private TextBox redBox;
        private TextBox greenBox;
        private TextBox blueBox;
        private GroupBox groupBox5;
        private IPLab.FilterPreview filterPreview;
        private IPLab.ColorSlider redSlider;
        private IPLab.ColorSlider greenSlider;
        private IPLab.ColorSlider blueSlider;
        private GroupBox groupBox1;
        private TextBox radiusBox;
        private GroupBox groupBox2;
        private Label label1;
        private Label label2;
        private Label label5;
        private TextBox fillRBox;
        private TextBox fillGBox;
        private TextBox fillBBox;
        private Button cancelButton;
        private Button okButton;
        private TrackBar radiusTrackBar;
        private ComboBox fillTypeCombo;
        private Label label7;
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
        public EuclideanColorFilteringForm( )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );

            //
            redBox.Text = red.ToString( );
            greenBox.Text = green.ToString( );
            blueBox.Text = blue.ToString( );

            radiusBox.Text = radius.ToString( );

            fillRBox.Text = fillR.ToString( );
            fillGBox.Text = fillG.ToString( );
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.blueSlider = new IPLab.ColorSlider();
            this.greenSlider = new IPLab.ColorSlider();
            this.redSlider = new IPLab.ColorSlider();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.redBox = new System.Windows.Forms.TextBox();
            this.greenBox = new System.Windows.Forms.TextBox();
            this.blueBox = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.filterPreview = new IPLab.FilterPreview();
            this.radiusTrackBar = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radiusBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.fillRBox = new System.Windows.Forms.TextBox();
            this.fillGBox = new System.Windows.Forms.TextBox();
            this.fillBBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.fillTypeCombo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radiusTrackBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.blueSlider);
            this.groupBox4.Controls.Add(this.greenSlider);
            this.groupBox4.Controls.Add(this.redSlider);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.redBox);
            this.groupBox4.Controls.Add(this.greenBox);
            this.groupBox4.Controls.Add(this.blueBox);
            this.groupBox4.Location = new System.Drawing.Point(29, 162);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(728, 258);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Center color";
            // 
            // blueSlider
            // 
            this.blueSlider.Color2 = System.Drawing.Color.Blue;
            this.blueSlider.DoubleArrow = false;
            this.blueSlider.Location = new System.Drawing.Point(21, 194);
            this.blueSlider.Name = "blueSlider";
            this.blueSlider.Size = new System.Drawing.Size(681, 43);
            this.blueSlider.TabIndex = 8;
            this.blueSlider.TabStop = false;
            this.blueSlider.ValuesChanged += new System.EventHandler(this.blueSlider_ValuesChanged);
            // 
            // greenSlider
            // 
            this.greenSlider.Color2 = System.Drawing.Color.Lime;
            this.greenSlider.DoubleArrow = false;
            this.greenSlider.Location = new System.Drawing.Point(21, 151);
            this.greenSlider.Name = "greenSlider";
            this.greenSlider.Size = new System.Drawing.Size(681, 43);
            this.greenSlider.TabIndex = 7;
            this.greenSlider.TabStop = false;
            this.greenSlider.ValuesChanged += new System.EventHandler(this.greenSlider_ValuesChanged);
            // 
            // redSlider
            // 
            this.redSlider.Color2 = System.Drawing.Color.Red;
            this.redSlider.DoubleArrow = false;
            this.redSlider.Location = new System.Drawing.Point(21, 108);
            this.redSlider.Name = "redSlider";
            this.redSlider.Size = new System.Drawing.Size(681, 43);
            this.redSlider.TabIndex = 6;
            this.redSlider.TabStop = false;
            this.redSlider.ValuesChanged += new System.EventHandler(this.redSlider_ValuesChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(512, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 30);
            this.label4.TabIndex = 4;
            this.label4.Text = "B:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(260, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 30);
            this.label3.TabIndex = 2;
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
            // redBox
            // 
            this.redBox.Location = new System.Drawing.Point(78, 43);
            this.redBox.Name = "redBox";
            this.redBox.Size = new System.Drawing.Size(130, 45);
            this.redBox.TabIndex = 1;
            this.redBox.TextChanged += new System.EventHandler(this.redBox_TextChanged);
            // 
            // greenBox
            // 
            this.greenBox.Location = new System.Drawing.Point(312, 43);
            this.greenBox.Name = "greenBox";
            this.greenBox.Size = new System.Drawing.Size(130, 45);
            this.greenBox.TabIndex = 3;
            this.greenBox.TextChanged += new System.EventHandler(this.greenBox_TextChanged);
            // 
            // blueBox
            // 
            this.blueBox.Location = new System.Drawing.Point(567, 43);
            this.blueBox.Name = "blueBox";
            this.blueBox.Size = new System.Drawing.Size(130, 45);
            this.blueBox.TabIndex = 5;
            this.blueBox.TextChanged += new System.EventHandler(this.blueBox_TextChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.filterPreview);
            this.groupBox5.Location = new System.Drawing.Point(763, 58);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(735, 753);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Preview";
            // 
            // filterPreview
            // 
            this.filterPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterPreview.Image = null;
            this.filterPreview.Location = new System.Drawing.Point(3, 41);
            this.filterPreview.Name = "filterPreview";
            this.filterPreview.Size = new System.Drawing.Size(729, 709);
            this.filterPreview.TabIndex = 0;
            this.filterPreview.TabStop = false;
            // 
            // radiusTrackBar
            // 
            this.radiusTrackBar.Location = new System.Drawing.Point(13, 97);
            this.radiusTrackBar.Maximum = 450;
            this.radiusTrackBar.Minimum = 1;
            this.radiusTrackBar.Name = "radiusTrackBar";
            this.radiusTrackBar.Size = new System.Drawing.Size(697, 90);
            this.radiusTrackBar.TabIndex = 1;
            this.radiusTrackBar.TickFrequency = 10;
            this.radiusTrackBar.Value = 100;
            this.radiusTrackBar.Scroll += new System.EventHandler(this.radiusTrackBar_Scroll);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radiusBox);
            this.groupBox1.Controls.Add(this.radiusTrackBar);
            this.groupBox1.Location = new System.Drawing.Point(29, 431);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(728, 194);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Radius";
            // 
            // radiusBox
            // 
            this.radiusBox.Location = new System.Drawing.Point(34, 43);
            this.radiusBox.Name = "radiusBox";
            this.radiusBox.Size = new System.Drawing.Size(130, 45);
            this.radiusBox.TabIndex = 0;
            this.radiusBox.TextChanged += new System.EventHandler(this.radiusBox_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.fillRBox);
            this.groupBox2.Controls.Add(this.fillGBox);
            this.groupBox2.Controls.Add(this.fillBBox);
            this.groupBox2.Location = new System.Drawing.Point(29, 635);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(728, 108);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fill color";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(512, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 30);
            this.label1.TabIndex = 7;
            this.label1.Text = "B:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(260, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 30);
            this.label2.TabIndex = 6;
            this.label2.Text = "G:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(26, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 30);
            this.label5.TabIndex = 0;
            this.label5.Text = "R:";
            // 
            // fillRBox
            // 
            this.fillRBox.Location = new System.Drawing.Point(78, 43);
            this.fillRBox.Name = "fillRBox";
            this.fillRBox.Size = new System.Drawing.Size(130, 45);
            this.fillRBox.TabIndex = 0;
            this.fillRBox.TextChanged += new System.EventHandler(this.fillBox_TextChanged);
            // 
            // fillGBox
            // 
            this.fillGBox.Location = new System.Drawing.Point(312, 43);
            this.fillGBox.Name = "fillGBox";
            this.fillGBox.Size = new System.Drawing.Size(130, 45);
            this.fillGBox.TabIndex = 1;
            this.fillGBox.TextChanged += new System.EventHandler(this.fillBox_TextChanged);
            // 
            // fillBBox
            // 
            this.fillBBox.Location = new System.Drawing.Point(567, 43);
            this.fillBBox.Name = "fillBBox";
            this.fillBBox.Size = new System.Drawing.Size(130, 45);
            this.fillBBox.TabIndex = 2;
            this.fillBBox.TextChanged += new System.EventHandler(this.fillBox_TextChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(736, 882);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(195, 50);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(430, 882);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(195, 50);
            this.okButton.TabIndex = 10;
            this.okButton.Text = "Ok";
            // 
            // fillTypeCombo
            // 
            this.fillTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fillTypeCombo.Items.AddRange(new object[] {
            "Outside",
            "Inside"});
            this.fillTypeCombo.Location = new System.Drawing.Point(293, 777);
            this.fillTypeCombo.Name = "fillTypeCombo";
            this.fillTypeCombo.Size = new System.Drawing.Size(312, 40);
            this.fillTypeCombo.TabIndex = 9;
            this.fillTypeCombo.SelectedIndexChanged += new System.EventHandler(this.fillTypeCombo_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(120, 780);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 31);
            this.label7.TabIndex = 12;
            this.label7.Text = "Fill type:";
            // 
            // EuclideanColorFilteringForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(15, 38);
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(1528, 982);
            this.Controls.Add(this.fillTypeCombo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Font = new System.Drawing.Font("»ªÎÄÖÐËÎ", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EuclideanColorFilteringForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Euclidean Color Filtering";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radiusTrackBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        // Red changed
        private void redBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                red = byte.Parse( redBox.Text );
                redSlider.Min = red;
                UpdateCenterColor( );
            }
            catch ( Exception )
            {
            }
        }

        // Green changed
        private void greenBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                green = byte.Parse( greenBox.Text );
                greenSlider.Min = green;
                UpdateCenterColor( );
            }
            catch ( Exception )
            {
            }
        }

        // Blue changed
        private void blueBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                blue = byte.Parse( blueBox.Text );
                blueSlider.Min = blue;
                UpdateCenterColor( );
            }
            catch ( Exception )
            {
            }
        }

        // Red slider changed
        private void redSlider_ValuesChanged( object sender, System.EventArgs e )
        {
            redBox.Text = redSlider.Min.ToString( );
        }

        // Green slider changed
        private void greenSlider_ValuesChanged( object sender, System.EventArgs e )
        {
            greenBox.Text = greenSlider.Min.ToString( );
        }

        // Blue slider changed
        private void blueSlider_ValuesChanged( object sender, System.EventArgs e )
        {
            blueBox.Text = blueSlider.Min.ToString( );
        }

        // Update center color
        private void UpdateCenterColor( )
        {
            // update slider colors
            redSlider.Color1 = Color.FromArgb( 0, green, blue );
            redSlider.Color2 = Color.FromArgb( 255, green, blue );
            greenSlider.Color1 = Color.FromArgb( red, 0, blue );
            greenSlider.Color2 = Color.FromArgb( red, 255, blue );
            blueSlider.Color1 = Color.FromArgb( red, green, 0 );
            blueSlider.Color2 = Color.FromArgb( red, green, 255 );

            // update filter
            filter.CenterColor = Color.FromArgb( red, green, blue );
            filterPreview.RefreshFilter( );
        }

        // Radius changed
        private void radiusBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                radius = Math.Max( (short) 1, Math.Min( (short) 450, short.Parse( radiusBox.Text ) ) );

                radiusTrackBar.Value = filter.Radius = radius;
                filterPreview.RefreshFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // Radius trackbar scrolled
        private void radiusTrackBar_Scroll( object sender, System.EventArgs e )
        {
            radiusBox.Text = radiusTrackBar.Value.ToString( );
        }

        // Fill color changed
        private void fillBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                fillR = byte.Parse( fillRBox.Text );
                fillG = byte.Parse( fillGBox.Text );
                fillB = byte.Parse( fillBBox.Text );

                filter.FillColor = Color.FromArgb( fillR, fillG, fillB );
                filterPreview.RefreshFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // Fill type changed
        private void fillTypeCombo_SelectedIndexChanged( object sender, System.EventArgs e )
        {
            filter.FillOutside = ( fillTypeCombo.SelectedIndex == 0 );
            filterPreview.RefreshFilter( );
        }
    }
}
