using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using AForge.Imaging;
using AForge.Imaging.Filters;

namespace IPLab
{
    /// <summary>
    /// Summary description for ResizeForm.
    /// </summary>
    public class ResizeForm : Form
    {
        private Size originalSize;
        private FilterResize filter = null;
        private bool updating = false;

        private RadioButton factorButton;
        private TextBox factorBox;
        private RadioButton sizeButton;
        private Label label1;
        private TextBox widthBox;
        private Label label2;
        private TextBox heightBox;
        private Label label3;
        private ComboBox methodCombo;
        private Button okButton;
        private Button cancelButton;
        private CheckBox ratioCheck;
        private GroupBox groupBox1;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        // OriginalSize property
        public Size OriginalSize
        {
            get { return originalSize; }
            set { originalSize = value; }
        }
        // Filter property
        public IFilter Filter
        {
            get { return filter; }
        }

        // Constructor
        public ResizeForm( )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );
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
            this.factorButton = new System.Windows.Forms.RadioButton();
            this.factorBox = new System.Windows.Forms.TextBox();
            this.sizeButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.widthBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.heightBox = new System.Windows.Forms.TextBox();
            this.ratioCheck = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.methodCombo = new System.Windows.Forms.ComboBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // factorButton
            // 
            this.factorButton.Checked = true;
            this.factorButton.Location = new System.Drawing.Point(41, 90);
            this.factorButton.Name = "factorButton";
            this.factorButton.Size = new System.Drawing.Size(260, 43);
            this.factorButton.TabIndex = 0;
            this.factorButton.TabStop = true;
            this.factorButton.Text = "Resize factor:";
            this.factorButton.CheckedChanged += new System.EventHandler(this.factorButton_CheckedChanged);
            // 
            // factorBox
            // 
            this.factorBox.Location = new System.Drawing.Point(41, 161);
            this.factorBox.Name = "factorBox";
            this.factorBox.Size = new System.Drawing.Size(260, 45);
            this.factorBox.TabIndex = 1;
            this.factorBox.TextChanged += new System.EventHandler(this.factorBox_TextChanged);
            // 
            // sizeButton
            // 
            this.sizeButton.Location = new System.Drawing.Point(436, 90);
            this.sizeButton.Name = "sizeButton";
            this.sizeButton.Size = new System.Drawing.Size(260, 43);
            this.sizeButton.TabIndex = 2;
            this.sizeButton.Text = "Resize to size";
            this.sizeButton.CheckedChanged += new System.EventHandler(this.sizeButton_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(430, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 30);
            this.label1.TabIndex = 3;
            this.label1.Text = "Width:";
            // 
            // widthBox
            // 
            this.widthBox.Enabled = false;
            this.widthBox.Location = new System.Drawing.Point(436, 218);
            this.widthBox.Name = "widthBox";
            this.widthBox.Size = new System.Drawing.Size(260, 45);
            this.widthBox.TabIndex = 4;
            this.widthBox.TextChanged += new System.EventHandler(this.widthBox_TextChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(430, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 30);
            this.label2.TabIndex = 5;
            this.label2.Text = "Height:";
            // 
            // heightBox
            // 
            this.heightBox.Enabled = false;
            this.heightBox.Location = new System.Drawing.Point(436, 349);
            this.heightBox.Name = "heightBox";
            this.heightBox.Size = new System.Drawing.Size(260, 45);
            this.heightBox.TabIndex = 6;
            this.heightBox.TextChanged += new System.EventHandler(this.heightBox_TextChanged);
            // 
            // ratioCheck
            // 
            this.ratioCheck.Checked = true;
            this.ratioCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ratioCheck.Enabled = false;
            this.ratioCheck.Location = new System.Drawing.Point(436, 437);
            this.ratioCheck.Name = "ratioCheck";
            this.ratioCheck.Size = new System.Drawing.Size(390, 43);
            this.ratioCheck.TabIndex = 7;
            this.ratioCheck.Text = "Keep aspect ratio";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(147, 569);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 30);
            this.label3.TabIndex = 8;
            this.label3.Text = "Interpolation:";
            // 
            // methodCombo
            // 
            this.methodCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.methodCombo.Items.AddRange(new object[] {
            "Nearest neighbour",
            "Bilinear",
            "Bicubic"});
            this.methodCombo.Location = new System.Drawing.Point(401, 566);
            this.methodCombo.Name = "methodCombo";
            this.methodCombo.Size = new System.Drawing.Size(260, 40);
            this.methodCombo.TabIndex = 9;
            // 
            // okButton
            // 
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(265, 790);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(195, 49);
            this.okButton.TabIndex = 10;
            this.okButton.Text = "Ok";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(595, 790);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(195, 49);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.factorButton);
            this.groupBox1.Controls.Add(this.factorBox);
            this.groupBox1.Controls.Add(this.methodCombo);
            this.groupBox1.Controls.Add(this.sizeButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.widthBox);
            this.groupBox1.Controls.Add(this.heightBox);
            this.groupBox1.Controls.Add(this.ratioCheck);
            this.groupBox1.Location = new System.Drawing.Point(159, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(781, 648);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resize";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // ResizeForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(15, 38);
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(1096, 931);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("»ªÎÄÖÐËÎ", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResizeForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resize image";
            this.Load += new System.EventHandler(this.ResizeForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        // On form load
        private void ResizeForm_Load( object sender, System.EventArgs e )
        {
            // default resize factor
            factorBox.Text = "2";

            // width & height
            widthBox.Text = ( originalSize.Width * 2 ).ToString( );
            heightBox.Text = ( originalSize.Height * 2 ).ToString( );

            methodCombo.SelectedIndex = 1;
        }

        // On size radio button checked state changed
        private void sizeButton_CheckedChanged( object sender, System.EventArgs e )
        {
            bool enable = sizeButton.Checked;

            widthBox.Enabled = enable;
            heightBox.Enabled = enable;
            ratioCheck.Enabled = enable;
        }

        // On factor radio button checked state changed
        private void factorButton_CheckedChanged( object sender, System.EventArgs e )
        {
            factorBox.Enabled = factorButton.Checked;
        }

        // On factor changed
        private void factorBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                float factor = float.Parse( factorBox.Text );

                updating = true;
                widthBox.Text = Math.Max( 1, Math.Min( 5000, (int) ( factor * originalSize.Width ) ) ).ToString( );
                heightBox.Text = Math.Max( 1, Math.Min( 5000, (int) ( factor * originalSize.Height ) ) ).ToString( );
                updating = false;
            }
            catch ( Exception )
            {
            }
        }

        // On width changed
        private void widthBox_TextChanged( object sender, System.EventArgs e )
        {
            if ( ( !updating ) && ( ratioCheck.Checked ) )
            {
                try
                {
                    int width = int.Parse( widthBox.Text );

                    updating = true;
                    heightBox.Text = Math.Max( 1, Math.Min( 5000, (int) ( width * originalSize.Height / originalSize.Width ) ) ).ToString( );
                    updating = false;
                }
                catch ( Exception )
                {
                }
            }
        }

        // On height changed
        private void heightBox_TextChanged( object sender, System.EventArgs e )
        {
            if ( ( !updating ) && ( ratioCheck.Checked ) )
            {
                try
                {
                    int height = int.Parse( heightBox.Text );

                    updating = true;
                    widthBox.Text = Math.Max( 1, Math.Min( 5000, (int) ( height * originalSize.Width / originalSize.Height ) ) ).ToString( );
                    updating = false;
                }
                catch ( Exception )
                {
                }
            }
        }

        // On "Ok" button
        private void okButton_Click( object sender, System.EventArgs e )
        {
            try
            {
                // get new image size
                int width = Math.Max( 1, Math.Min( 5000, int.Parse( widthBox.Text ) ) );
                int height = Math.Max( 1, Math.Min( 5000, int.Parse( heightBox.Text ) ) );

                // create appropriate filter
                switch ( methodCombo.SelectedIndex )
                {
                    case 0:
                        filter = new ResizeNearestNeighbor( width, height );
                        break;
                    case 1:
                        filter = new ResizeBilinear( width, height );
                        break;
                    case 2:
                        filter = new ResizeBicubic( width, height );
                        break;
                }

                // close the dialog
                this.DialogResult = DialogResult.OK;
                this.Close( );
            }
            catch ( Exception )
            {
                MessageBox.Show( this, "Incorrect values are entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
