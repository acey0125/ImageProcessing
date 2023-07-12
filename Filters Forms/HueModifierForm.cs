using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using AForge.Imaging.Filters;

namespace IPLab
{
    /// <summary>
    /// Summary description for HueModifierForm.
    /// </summary>
    public class HueModifierForm : Form
    {
        private HueModifier filter = new HueModifier( );

        private GroupBox groupBox1;
        private Label label1;
        private GroupBox groupBox2;
        private IPLab.FilterPreview filterPreview;
        private TextBox hueBox;
        private IPLab.HuePicker huePicker;
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
        public HueModifierForm( )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );

            //
            hueBox.Text = filter.Hue.ToString( );
            huePicker.Min = filter.Hue;

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
            this.huePicker = new IPLab.HuePicker();
            this.hueBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.filterPreview = new IPLab.FilterPreview();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.huePicker);
            this.groupBox1.Controls.Add(this.hueBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(26, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(564, 599);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Hue Value";
            // 
            // huePicker
            // 
            this.huePicker.Location = new System.Drawing.Point(65, 191);
            this.huePicker.Name = "huePicker";
            this.huePicker.Size = new System.Drawing.Size(442, 366);
            this.huePicker.TabIndex = 2;
            this.huePicker.TabStop = false;
            this.huePicker.ValuesChanged += new System.EventHandler(this.huePicker_ValuesChanged);
            // 
            // hueBox
            // 
            this.hueBox.Location = new System.Drawing.Point(150, 96);
            this.hueBox.Name = "hueBox";
            this.hueBox.Size = new System.Drawing.Size(260, 45);
            this.hueBox.TabIndex = 1;
            this.hueBox.TextChanged += new System.EventHandler(this.hueBox_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(59, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Hue:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.filterPreview);
            this.groupBox2.Location = new System.Drawing.Point(596, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(704, 589);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Preview";
            // 
            // filterPreview
            // 
            this.filterPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterPreview.Image = null;
            this.filterPreview.Location = new System.Drawing.Point(3, 41);
            this.filterPreview.Name = "filterPreview";
            this.filterPreview.Size = new System.Drawing.Size(698, 545);
            this.filterPreview.TabIndex = 12;
            this.filterPreview.TabStop = false;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(695, 691);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(195, 49);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "&Cancel";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(338, 691);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(195, 49);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "&Ok";
            // 
            // HueModifierForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(15, 38);
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(1312, 795);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("»ªÎÄÖÐËÎ", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HueModifierForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hue Modifier";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        // hue picker's value changed
        private void huePicker_ValuesChanged( object sender, System.EventArgs e )
        {
            hueBox.Text = huePicker.Min.ToString( );
        }

        // Hue changed
        private void hueBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                huePicker.Min = filter.Hue = int.Parse( hueBox.Text );
                filterPreview.RefreshFilter( );
            }
            catch ( Exception )
            {
            }
        }
    }
}
