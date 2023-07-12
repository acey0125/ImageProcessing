using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using AForge.Imaging.Filters;
using AForge.Imaging.Textures;

namespace IPLab
{
    /// <summary>
    /// Summary description for PerlinNoiseForm.
    /// </summary>
    public class PerlinNoiseForm : Form
    {
        private IFilter filter = null;
        private Label label1;
        private ComboBox effectComboBox;
        private Button cancelButton;
        private Button okButton;
        private GroupBox groupBox1;
        private IPLab.FilterPreview filterPreview;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        private int imageWidth;
        private int imageHeight;

        // Image property
        public Bitmap Image
        {
            set
            {
                filterPreview.Image = value;
                imageWidth = value.Width;
                imageHeight = value.Height;
            }
        }
        // Filter property
        public IFilter Filter
        {
            get { return filter; }
        }

        // Constructor
        public PerlinNoiseForm( )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );

            //
            effectComboBox.SelectedIndex = 0;
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
            this.effectComboBox = new System.Windows.Forms.ComboBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.filterPreview = new IPLab.FilterPreview();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(55, 468);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Effect:";
            // 
            // effectComboBox
            // 
            this.effectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.effectComboBox.Items.AddRange(new object[] {
            "Marble",
            "Wood",
            "Clouds",
            "Labyrinth",
            "Textile",
            "Dirty",
            "Rusty"});
            this.effectComboBox.Location = new System.Drawing.Point(193, 464);
            this.effectComboBox.Name = "effectComboBox";
            this.effectComboBox.Size = new System.Drawing.Size(364, 40);
            this.effectComboBox.TabIndex = 1;
            this.effectComboBox.SelectedIndexChanged += new System.EventHandler(this.effectComboBox_SelectedIndexChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(793, 929);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(195, 50);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(445, 929);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(195, 50);
            this.okButton.TabIndex = 8;
            this.okButton.Text = "Ok";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.filterPreview);
            this.groupBox1.Location = new System.Drawing.Point(598, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(897, 859);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // filterPreview
            // 
            this.filterPreview.Image = null;
            this.filterPreview.Location = new System.Drawing.Point(6, 32);
            this.filterPreview.Name = "filterPreview";
            this.filterPreview.Size = new System.Drawing.Size(885, 810);
            this.filterPreview.TabIndex = 0;
            this.filterPreview.TabStop = false;
            // 
            // PerlinNoiseForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(15, 38);
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(1532, 1037);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.effectComboBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("»ªÎÄÖÐËÎ", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PerlinNoiseForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Perlin Noise";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        // On selected index changed in effects combo box
        private void effectComboBox_SelectedIndexChanged( object sender, System.EventArgs e )
        {
            switch ( effectComboBox.SelectedIndex )
            {
                case 0:			// Marble effect
                    filter = new Texturer( new MarbleTexture( imageWidth / 96, imageHeight / 48 ), 0.7f, 0.3f );
                    break;
                case 1:			// Wood effect
                    filter = new Texturer( new WoodTexture( ), 0.7f, 0.3f );
                    break;
                case 2:			// Clouds
                    filter = new Texturer( new CloudsTexture( ), 0.7f, 0.3f );
                    break;
                case 3:			// Labyrinth
                    filter = new Texturer( new LabyrinthTexture( ), 0.7f, 0.3f );
                    break;
                case 4:			// Textile
                    filter = new Texturer( new TextileTexture( ), 0.7f, 0.3f );
                    break;
                case 5:			// Dirty
                    TexturedFilter f = new TexturedFilter( new CloudsTexture( ), new Sepia( ) );

                    f.PreserveLevel = 0.30f;
                    f.FilterLevel = 0.90f;

                    filter = f;

                    break;
                case 6:			// Rusty
                    filter = new TexturedFilter( new CloudsTexture( ), new Sepia( ), new GrayscaleBT709( ) );

                    break;
            }

            filterPreview.Filter = filter;
        }
    }
}
