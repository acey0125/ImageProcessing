using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using AForge.Imaging.Filters;

namespace IPLab
{
    /// <summary>
    /// Summary description for AdaptiveSmoothForm.
    /// </summary>
    public class AdaptiveSmoothForm : Form
    {
        private AdaptiveSmooth filter = new AdaptiveSmooth( 1.0 );
        private double factor = 1.0;

        private Label label1;
        private TextBox factorBox;
        private Button cancelButton;
        private Button okButton;
        private GroupBox groupBox1;
        private TrackBar trackBar;
        private IPLab.FilterPreview filterPreview;
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
        public AdaptiveSmoothForm( )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );

            //
            factorBox.Text = factor.ToString( );
            trackBar.Value = (int) factor * 10;

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
            this.factorBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.filterPreview = new IPLab.FilterPreview();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(30, 337);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Factor:";
            // 
            // factorBox
            // 
            this.factorBox.Location = new System.Drawing.Point(160, 330);
            this.factorBox.Name = "factorBox";
            this.factorBox.Size = new System.Drawing.Size(130, 45);
            this.factorBox.TabIndex = 1;
            this.factorBox.TextChanged += new System.EventHandler(this.factorBox_TextChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(759, 859);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(195, 49);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(377, 859);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(195, 49);
            this.okButton.TabIndex = 10;
            this.okButton.Text = "Ok";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.filterPreview);
            this.groupBox1.Location = new System.Drawing.Point(598, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(780, 766);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // filterPreview
            // 
            this.filterPreview.Image = null;
            this.filterPreview.Location = new System.Drawing.Point(26, 32);
            this.filterPreview.Name = "filterPreview";
            this.filterPreview.Size = new System.Drawing.Size(732, 728);
            this.filterPreview.TabIndex = 13;
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(30, 395);
            this.trackBar.Maximum = 100;
            this.trackBar.Minimum = 1;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(520, 90);
            this.trackBar.TabIndex = 7;
            this.trackBar.TickFrequency = 5;
            this.trackBar.Value = 2;
            this.trackBar.ValueChanged += new System.EventHandler(this.trackBar_ValueChanged);
            // 
            // AdaptiveSmoothForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(15, 38);
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(1456, 959);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.factorBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("��������", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdaptiveSmoothForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adaptive Smooth";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        // Factor changed
        private void factorBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                factor = Math.Max( 0.1f, Math.Min( 10.0f, double.Parse( factorBox.Text ) ) );

                filter.Factor = factor;
                filterPreview.RefreshFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // Trackbar scrolled
        private void trackBar_ValueChanged( object sender, System.EventArgs e )
        {
            factorBox.Text = ( (double) trackBar.Value / 10 ).ToString( );
        }
    }
}
