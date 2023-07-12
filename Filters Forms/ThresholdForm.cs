using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using AForge.Imaging.Filters;

namespace IPLab
{
    /// <summary>
    /// Summary description for ThresholdForm.
    /// </summary>
    public class ThresholdForm : Form
    {
        private Threshold filter = new Threshold( );
        private byte threshold = 128;

        private Label label1;
        private TextBox thresholdBox;
        private IPLab.ColorSlider slider;
        private Button okButton;
        private Button cancelButton;
        private IPLab.FilterPreview filterPreview;
        private GroupBox groupBox1;
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
        public ThresholdForm( )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            thresholdBox.Text = threshold.ToString( );
            slider.Min = threshold;

            // initial filter values
            filter.ThresholdValue = threshold;

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
            this.thresholdBox = new System.Windows.Forms.TextBox();
            this.slider = new IPLab.ColorSlider();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.filterPreview = new IPLab.FilterPreview();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(26, 391);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Threshold value:";
            // 
            // thresholdBox
            // 
            this.thresholdBox.Location = new System.Drawing.Point(260, 385);
            this.thresholdBox.Name = "thresholdBox";
            this.thresholdBox.Size = new System.Drawing.Size(130, 45);
            this.thresholdBox.TabIndex = 1;
            this.thresholdBox.TextChanged += new System.EventHandler(this.minBox_TextChanged);
            // 
            // slider
            // 
            this.slider.DoubleArrow = false;
            this.slider.Location = new System.Drawing.Point(21, 449);
            this.slider.Min = 127;
            this.slider.Name = "slider";
            this.slider.Size = new System.Drawing.Size(681, 50);
            this.slider.TabIndex = 4;
            this.slider.Type = IPLab.ColorSliderType.Threshold;
            this.slider.ValuesChanged += new System.EventHandler(this.slider_ValuesChanged);
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(382, 836);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(195, 49);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "&Ok";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(835, 836);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(195, 49);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "&Cancel";
            // 
            // filterPreview
            // 
            this.filterPreview.Image = null;
            this.filterPreview.Location = new System.Drawing.Point(6, 32);
            this.filterPreview.Name = "filterPreview";
            this.filterPreview.Size = new System.Drawing.Size(776, 743);
            this.filterPreview.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.filterPreview);
            this.groupBox1.Location = new System.Drawing.Point(708, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(788, 781);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // ThresholdForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(15, 38);
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(1508, 958);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.slider);
            this.Controls.Add(this.thresholdBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("»ªÎÄÖÐËÎ", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ThresholdForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Threshold";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        // Min edit box changed
        private void minBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                slider.Min = threshold = byte.Parse( thresholdBox.Text );

                // refresh filter
                filter.ThresholdValue = threshold;
                filterPreview.RefreshFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // Slider position changed
        private void slider_ValuesChanged( object sender, System.EventArgs e )
        {
            threshold = (byte) slider.Min;
            thresholdBox.Text = threshold.ToString( );
        }
    }
}
