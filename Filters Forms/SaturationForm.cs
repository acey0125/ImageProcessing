using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using AForge.Imaging.Filters;

namespace IPLab
{
    /// <summary>
    /// Summary description for SaturationForm.
    /// </summary>
    public class SaturationForm : Form
    {
        private SaturationCorrection filter = new SaturationCorrection( );

        private Label label1;
        private TextBox saturationBox;
        private GroupBox groupBox1;
        private IPLab.FilterPreview filterPreview;
        private TrackBar saturationTrackBar;
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
        public SaturationForm( )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );

            //
            saturationBox.Text = filter.AdjustValue.ToString( );
            saturationTrackBar.Value = (int) ( filter.AdjustValue * 1000 );

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
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.filterPreview = new IPLab.FilterPreview();
            this.label1 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.saturationTrackBar = new System.Windows.Forms.TrackBar();
            this.saturationBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saturationTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(857, 931);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(195, 50);
            this.cancelButton.TabIndex = 24;
            this.cancelButton.Text = "&Cancel";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.filterPreview);
            this.groupBox1.Location = new System.Drawing.Point(702, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(848, 914);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // filterPreview
            // 
            this.filterPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterPreview.Image = null;
            this.filterPreview.Location = new System.Drawing.Point(3, 41);
            this.filterPreview.Name = "filterPreview";
            this.filterPreview.Size = new System.Drawing.Size(842, 870);
            this.filterPreview.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(67, 335);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "Adjust saturation by:";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(420, 931);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(195, 50);
            this.okButton.TabIndex = 23;
            this.okButton.Text = "&Ok";
            // 
            // saturationTrackBar
            // 
            this.saturationTrackBar.Location = new System.Drawing.Point(30, 682);
            this.saturationTrackBar.Maximum = 1000;
            this.saturationTrackBar.Minimum = -1000;
            this.saturationTrackBar.Name = "saturationTrackBar";
            this.saturationTrackBar.Size = new System.Drawing.Size(650, 90);
            this.saturationTrackBar.TabIndex = 22;
            this.saturationTrackBar.TickFrequency = 50;
            this.saturationTrackBar.ValueChanged += new System.EventHandler(this.saturationTrackBar_ValueChanged);
            // 
            // saturationBox
            // 
            this.saturationBox.Location = new System.Drawing.Point(420, 335);
            this.saturationBox.Name = "saturationBox";
            this.saturationBox.Size = new System.Drawing.Size(130, 45);
            this.saturationBox.TabIndex = 2;
            this.saturationBox.TextChanged += new System.EventHandler(this.saturationBox_TextChanged);
            // 
            // SaturationForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(15, 38);
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(1579, 1040);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.saturationTrackBar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.saturationBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("»ªÎÄÖÐËÎ", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaturationForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Saturation";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.saturationTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        // value of saturation track bar changed
        private void saturationTrackBar_ValueChanged( object sender, System.EventArgs e )
        {
            saturationBox.Text = ( (double) saturationTrackBar.Value / 1000 ).ToString( );
        }

        // value of saturation text box changed
        private void saturationBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                filter.AdjustValue = double.Parse( saturationBox.Text );
                filterPreview.RefreshFilter( );
            }
            catch ( Exception )
            {
            }
        }
    }
}
