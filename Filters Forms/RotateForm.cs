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
    /// Summary description for RotateForm.
    /// </summary>
    public class RotateForm : Form
    {
        private FilterRotate filter = null;

        private Label label1;
        private TextBox angleBox;
        private ComboBox methodCombo;
        private Label label3;
        private CheckBox keepSizeCheck;
        private GroupBox groupBox1;
        private Label label2;
        private TextBox redBox;
        private Label label4;
        private TextBox greenBox;
        private Label label5;
        private TextBox blueBox;
        private Button okButton;
        private Button cancelButton;
        private Label label6;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        // Filter property
        public IFilter Filter
        {
            get { return filter; }
        }

        // Constructor
        public RotateForm( )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            angleBox.Text = "45";
            redBox.Text = "0";
            greenBox.Text = "0";
            blueBox.Text = "0";

            methodCombo.SelectedIndex = 1;
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
            this.angleBox = new System.Windows.Forms.TextBox();
            this.methodCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.keepSizeCheck = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.greenBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.redBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.blueBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(52, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Angle:";
            // 
            // angleBox
            // 
            this.angleBox.Location = new System.Drawing.Point(331, 261);
            this.angleBox.Name = "angleBox";
            this.angleBox.Size = new System.Drawing.Size(260, 45);
            this.angleBox.TabIndex = 1;
            // 
            // methodCombo
            // 
            this.methodCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.methodCombo.Items.AddRange(new object[] {
            "Nearest neighbour",
            "Bilinear",
            "Bicubic"});
            this.methodCombo.Location = new System.Drawing.Point(331, 347);
            this.methodCombo.Name = "methodCombo";
            this.methodCombo.Size = new System.Drawing.Size(260, 40);
            this.methodCombo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(46, 347);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "Interpolation:";
            // 
            // keepSizeCheck
            // 
            this.keepSizeCheck.Location = new System.Drawing.Point(52, 448);
            this.keepSizeCheck.Name = "keepSizeCheck";
            this.keepSizeCheck.Size = new System.Drawing.Size(242, 51);
            this.keepSizeCheck.TabIndex = 4;
            this.keepSizeCheck.Text = "Keep size";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.greenBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.methodCombo);
            this.groupBox1.Controls.Add(this.keepSizeCheck);
            this.groupBox1.Controls.Add(this.angleBox);
            this.groupBox1.Controls.Add(this.redBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.blueBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(193, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(657, 565);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rotate";
            // 
            // greenBox
            // 
            this.greenBox.Location = new System.Drawing.Point(264, 137);
            this.greenBox.Name = "greenBox";
            this.greenBox.Size = new System.Drawing.Size(91, 45);
            this.greenBox.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(215, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 30);
            this.label4.TabIndex = 2;
            this.label4.Text = "G:";
            // 
            // redBox
            // 
            this.redBox.Location = new System.Drawing.Point(103, 137);
            this.redBox.Name = "redBox";
            this.redBox.Size = new System.Drawing.Size(91, 45);
            this.redBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(51, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "R:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(363, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 30);
            this.label5.TabIndex = 6;
            this.label5.Text = "B:";
            // 
            // blueBox
            // 
            this.blueBox.Location = new System.Drawing.Point(415, 137);
            this.blueBox.Name = "blueBox";
            this.blueBox.Size = new System.Drawing.Size(91, 45);
            this.blueBox.TabIndex = 6;
            // 
            // okButton
            // 
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(245, 727);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(195, 50);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "Ok";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(589, 727);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(195, 50);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(195, 32);
            this.label6.TabIndex = 7;
            this.label6.Text = "Fill in color£º";
            // 
            // RotateForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(15, 38);
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(1026, 842);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("»ªÎÄÖÐËÎ", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RotateForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rotate image";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        // On "Ok" button
        private void okButton_Click( object sender, System.EventArgs e )
        {
            try
            {
                // get rotation angle
                double angle = double.Parse( angleBox.Text );

                // create appropriate rotation filter
                switch ( methodCombo.SelectedIndex )
                {
                    case 0:
                        filter = new RotateNearestNeighbor( angle );
                        break;
                    case 1:
                        filter = new RotateBilinear( angle );
                        break;
                    case 2:
                        filter = new RotateBicubic( angle );
                        break;
                }

                // fill color
                filter.FillColor = Color.FromArgb(
                    byte.Parse( redBox.Text ),
                    byte.Parse( greenBox.Text ),
                    byte.Parse( blueBox.Text ) );

                // keep size
                filter.KeepSize = keepSizeCheck.Checked;

                // close dialog
                this.DialogResult = DialogResult.OK;
                this.Close( );
            }
            catch ( Exception )
            {
                MessageBox.Show( this, "Incorrect values are entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }
    }
}
