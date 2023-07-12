using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using AForge;
using AForge.Math;
using AForge.Imaging;

namespace IPLab
{
    /// <summary>
    /// Summary description for FrequencyFilter.
    /// </summary>
    public class FrequencyFilter : Form
    {
        private GroupBox groupBox1;
        private Label label1;
        private TextBox minBox;
        private TrackBar minTrackBar;
        private Label label2;
        private TrackBar maxTrackBar;
        private Button okButton;
        private Button cancelButton;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        private IntRange inputRange = new IntRange( 0, 64 );
        private TextBox maxBox;
        private IntRange outputRange = new IntRange( 0, 64 );

        // Frequency input range property
        public IntRange InputRange
        {
            get { return inputRange; }
            set
            {
                inputRange = value;
                minTrackBar.SetRange( inputRange.Min, inputRange.Max );
                maxTrackBar.SetRange( inputRange.Min, inputRange.Max );
            }
        }
        // Frequency output range property
        public IntRange OutputRange
        {
            get { return outputRange; }
            set
            {
                outputRange = value;
                minBox.Text = outputRange.Min.ToString( );
                maxBox.Text = outputRange.Max.ToString( );
            }
        }

        // Constructor
        public FrequencyFilter( )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
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
            this.maxTrackBar = new System.Windows.Forms.TrackBar();
            this.maxBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.minTrackBar = new System.Windows.Forms.TrackBar();
            this.minBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.maxTrackBar);
            this.groupBox1.Controls.Add(this.maxBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.minTrackBar);
            this.groupBox1.Controls.Add(this.minBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(26, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1169, 511);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Remove frequencies outside the range";
            // 
            // maxTrackBar
            // 
            this.maxTrackBar.Location = new System.Drawing.Point(330, 286);
            this.maxTrackBar.Name = "maxTrackBar";
            this.maxTrackBar.Size = new System.Drawing.Size(650, 90);
            this.maxTrackBar.TabIndex = 5;
            this.maxTrackBar.TickFrequency = 10;
            this.maxTrackBar.ValueChanged += new System.EventHandler(this.maxTrackBar_ValueChanged);
            // 
            // maxBox
            // 
            this.maxBox.Location = new System.Drawing.Point(174, 286);
            this.maxBox.Name = "maxBox";
            this.maxBox.Size = new System.Drawing.Size(130, 45);
            this.maxBox.TabIndex = 4;
            this.maxBox.TextChanged += new System.EventHandler(this.maxBox_TextChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(96, 292);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 33);
            this.label2.TabIndex = 3;
            this.label2.Text = "&Max:";
            // 
            // minTrackBar
            // 
            this.minTrackBar.Location = new System.Drawing.Point(330, 178);
            this.minTrackBar.Name = "minTrackBar";
            this.minTrackBar.Size = new System.Drawing.Size(650, 90);
            this.minTrackBar.TabIndex = 2;
            this.minTrackBar.TickFrequency = 10;
            this.minTrackBar.ValueChanged += new System.EventHandler(this.minTrackBar_ValueChanged);
            // 
            // minBox
            // 
            this.minBox.Location = new System.Drawing.Point(174, 178);
            this.minBox.Name = "minBox";
            this.minBox.Size = new System.Drawing.Size(130, 45);
            this.minBox.TabIndex = 1;
            this.minBox.TextChanged += new System.EventHandler(this.minBox_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(96, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Min:";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(356, 543);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(195, 49);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "&Ok";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(666, 543);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(195, 49);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "&Cancel";
            // 
            // FrequencyFilter
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(15, 38);
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(1229, 684);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("»ªÎÄÖÐËÎ", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrequencyFilter";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frequency Filter";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minTrackBar)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        // On Min edit box changed
        private void minBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                minTrackBar.Value = outputRange.Min = Math.Max( inputRange.Min, Math.Min( inputRange.Max, int.Parse( minBox.Text ) ) );
            }
            catch ( Exception )
            {
            }
        }

        // On Max edit box changed
        private void maxBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                maxTrackBar.Value = outputRange.Max = Math.Max( inputRange.Min, Math.Min( inputRange.Max, int.Parse( maxBox.Text ) ) );
            }
            catch ( Exception )
            {
            }
        }

        // On Min trackbar changed
        private void minTrackBar_ValueChanged( object sender, System.EventArgs e )
        {
            minBox.Text = minTrackBar.Value.ToString( );
        }

        // On Max trackbar changed
        private void maxTrackBar_ValueChanged( object sender, System.EventArgs e )
        {
            maxBox.Text = maxTrackBar.Value.ToString( );
        }



    }
}
