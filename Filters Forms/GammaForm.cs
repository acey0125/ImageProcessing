using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using AForge.Imaging.Filters;

namespace IPLab
{
    /// <summary>
    /// Summary description for GammaForm.
    /// </summary>
    public class GammaForm : Form
    {
        private GammaCorrection filter = new GammaCorrection( );

        private Label label1;
        private TextBox gammaBox;
        private TrackBar gammaTrackBar;
        private GroupBox groupBox1;
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
        public GammaForm( )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );

            //
            gammaBox.Text = filter.Gamma.ToString( );
            gammaTrackBar.Value = (int) ( filter.Gamma * 1000 );

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
            this.gammaBox = new System.Windows.Forms.TextBox();
            this.gammaTrackBar = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.filterPreview = new IPLab.FilterPreview();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gammaTrackBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(31, 323);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gamma value:";
            // 
            // gammaBox
            // 
            this.gammaBox.Location = new System.Drawing.Point(239, 317);
            this.gammaBox.Name = "gammaBox";
            this.gammaBox.Size = new System.Drawing.Size(182, 45);
            this.gammaBox.TabIndex = 1;
            this.gammaBox.TextChanged += new System.EventHandler(this.gammaBox_TextChanged);
            // 
            // gammaTrackBar
            // 
            this.gammaTrackBar.Location = new System.Drawing.Point(12, 423);
            this.gammaTrackBar.Maximum = 5000;
            this.gammaTrackBar.Minimum = 100;
            this.gammaTrackBar.Name = "gammaTrackBar";
            this.gammaTrackBar.Size = new System.Drawing.Size(676, 90);
            this.gammaTrackBar.TabIndex = 2;
            this.gammaTrackBar.TickFrequency = 100;
            this.gammaTrackBar.Value = 1000;
            this.gammaTrackBar.ValueChanged += new System.EventHandler(this.gammaTrackBar_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.filterPreview);
            this.groupBox1.Location = new System.Drawing.Point(728, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(806, 766);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // filterPreview
            // 
            this.filterPreview.Image = null;
            this.filterPreview.Location = new System.Drawing.Point(6, 32);
            this.filterPreview.Name = "filterPreview";
            this.filterPreview.Size = new System.Drawing.Size(794, 728);
            this.filterPreview.TabIndex = 12;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(388, 710);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(195, 50);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "&Cancel";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(130, 710);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(195, 50);
            this.okButton.TabIndex = 15;
            this.okButton.Text = "&Ok";
            // 
            // GammaForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(15, 38);
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(1575, 838);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gammaTrackBar);
            this.Controls.Add(this.gammaBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("»ªÎÄÖÐËÎ", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GammaForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gamma Correction";
            ((System.ComponentModel.ISupportInitialize)(this.gammaTrackBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        // value of gamma track bar changed
        private void gammaTrackBar_ValueChanged( object sender, System.EventArgs e )
        {
            gammaBox.Text = ( (double) gammaTrackBar.Value / 1000 ).ToString( );
        }

        // value of gamma text box changed
        private void gammaBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                filter.Gamma = double.Parse( gammaBox.Text );
                filterPreview.RefreshFilter( );
            }
            catch ( Exception )
            {
            }
        }
    }
}
