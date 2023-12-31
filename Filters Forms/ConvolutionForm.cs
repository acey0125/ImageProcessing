using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using AForge.Imaging.Filters;

namespace IPLab
{
    /// <summary>
    /// Summary description for ConvolutionForm.
    /// </summary>
    public class ConvolutionForm : Form
    {
        private Button cancelButton;
        private ComboBox operatorCombo;
        private Label label2;
        private ComboBox sizeCombo;
        private GroupBox groupBox1;
        private IPLab.GridArrayInt grid;
        private Label label1;

        private static int[] sizes = new int[] { 3, 5, 7, 9, 11, 13, 15 };
        private int[,] kernel;
        private AForge.Imaging.Filters.IFilter filter;
        private Button okButton;
        private Button saveButton;
        private Button loadButton;
        private SaveFileDialog sfd;
        private OpenFileDialog ofd;
        private IPLab.FilterPreview filterPreview;
        private GroupBox groupBox2;

        // Filter property
        public IFilter Filter
        {
            get { return filter; }
        }
        // Image property
        public Bitmap Image
        {
            set { filterPreview.Image = value; }
        }

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        // Constructor
        public ConvolutionForm( )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );

            // default kernel
            kernel = new int[3, 3] {
											 {1, 1, 1},
											 {1, 1, 1},
											 {1, 1, 1}};
            grid.LoadData( kernel );

            // add kernel sizes
            foreach ( int size in sizes )
            {
                string item = size.ToString( ) + " x " + size.ToString( );
                this.sizeCombo.Items.Add( (object) item );
            }

            // default size
            this.sizeCombo.SelectedIndex = 0;

            // default kernel
            this.operatorCombo.SelectedIndex = 0;
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
            this.okButton = new System.Windows.Forms.Button();
            this.operatorCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sizeCombo = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.loadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.grid = new IPLab.GridArrayInt();
            this.label1 = new System.Windows.Forms.Label();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.filterPreview = new IPLab.FilterPreview();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(1273, 946);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(195, 49);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(1052, 946);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(195, 49);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "Ok";
            // 
            // operatorCombo
            // 
            this.operatorCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.operatorCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.operatorCombo.Items.AddRange(new object[] {
            "Convolution",
            "Correlation"});
            this.operatorCombo.Location = new System.Drawing.Point(1004, 152);
            this.operatorCombo.Name = "operatorCombo";
            this.operatorCombo.Size = new System.Drawing.Size(442, 40);
            this.operatorCombo.TabIndex = 3;
            this.operatorCombo.SelectedIndexChanged += new System.EventHandler(this.operatorCombo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(1004, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "Operation:";
            // 
            // sizeCombo
            // 
            this.sizeCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sizeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sizeCombo.Location = new System.Drawing.Point(1004, 55);
            this.sizeCombo.Name = "sizeCombo";
            this.sizeCombo.Size = new System.Drawing.Size(442, 40);
            this.sizeCombo.TabIndex = 1;
            this.sizeCombo.SelectedIndexChanged += new System.EventHandler(this.sizeCombo_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.loadButton);
            this.groupBox1.Controls.Add(this.saveButton);
            this.groupBox1.Controls.Add(this.grid);
            this.groupBox1.Location = new System.Drawing.Point(26, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(961, 988);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kernel";
            // 
            // loadButton
            // 
            this.loadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.loadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadButton.Location = new System.Drawing.Point(740, 922);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(195, 49);
            this.loadButton.TabIndex = 0;
            this.loadButton.TabStop = false;
            this.loadButton.Text = "&Load";
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Location = new System.Drawing.Point(532, 922);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(195, 49);
            this.saveButton.TabIndex = 1;
            this.saveButton.TabStop = false;
            this.saveButton.Text = "&Save";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // grid
            // 
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.AutoSizeMinHeight = 10;
            this.grid.AutoSizeMinWidth = 10;
            this.grid.AutoStretchColumnsToFitWidth = false;
            this.grid.AutoStretchRowsToFitHeight = false;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid.ContextMenuStyle = SourceGrid2.ContextMenuStyle.None;
            this.grid.CustomSort = false;
            this.grid.GridToolTipActive = true;
            this.grid.Location = new System.Drawing.Point(26, 43);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(909, 860);
            this.grid.SpecialKeys = ((SourceGrid2.GridSpecialKeys)(((((((((((SourceGrid2.GridSpecialKeys.Ctrl_C | SourceGrid2.GridSpecialKeys.Ctrl_V) 
            | SourceGrid2.GridSpecialKeys.Ctrl_X) 
            | SourceGrid2.GridSpecialKeys.Delete) 
            | SourceGrid2.GridSpecialKeys.Arrows) 
            | SourceGrid2.GridSpecialKeys.Tab) 
            | SourceGrid2.GridSpecialKeys.PageDownUp) 
            | SourceGrid2.GridSpecialKeys.Enter) 
            | SourceGrid2.GridSpecialKeys.Escape) 
            | SourceGrid2.GridSpecialKeys.Control) 
            | SourceGrid2.GridSpecialKeys.Shift)));
            this.grid.TabIndex = 2;
            this.grid.TabStop = true;
            this.grid.ValueChanged += new IPLab.GridArrayInt.GridEventHandler(this.grid_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(1004, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kernel size:";
            // 
            // sfd
            // 
            this.sfd.DefaultExt = "txt";
            this.sfd.FileName = "kernel.txt";
            this.sfd.Filter = "Text files (*.txt)|*.txt";
            this.sfd.Title = "Save kernel to file";
            // 
            // ofd
            // 
            this.ofd.DefaultExt = "txt";
            this.ofd.Filter = "Text files (*.txt)|*.txt";
            this.ofd.Title = "Load kernel from file";
            // 
            // filterPreview
            // 
            this.filterPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterPreview.Image = null;
            this.filterPreview.Location = new System.Drawing.Point(3, 41);
            this.filterPreview.Name = "filterPreview";
            this.filterPreview.Size = new System.Drawing.Size(461, 586);
            this.filterPreview.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.filterPreview);
            this.groupBox2.Location = new System.Drawing.Point(1007, 219);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(467, 630);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Preview";
            // 
            // ConvolutionForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(15, 38);
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(1486, 1034);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.operatorCombo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sizeCombo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("��������", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ConvolutionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Convolution & Correlation";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        // Selection changed in size combo
        private void sizeCombo_SelectedIndexChanged( object sender, System.EventArgs e )
        {
            if ( kernel != null )
            {
                int size = sizes[this.sizeCombo.SelectedIndex];
                int oldSize = kernel.GetLength( 0 );
                int d = ( size - oldSize ) >> 1;
                int[,] array = new int[size, size];

                // copy old kernel into new
                for ( int i = 0; i < oldSize; i++ )
                {
                    if ( i + d < 0 )
                        continue;
                    if ( i + d >= size )
                        break;

                    for ( int j = 0; j < oldSize; j++ )
                    {
                        if ( j + d < 0 )
                            continue;
                        if ( j + d >= size )
                            break;
                        array[i + d, j + d] = kernel[i, j];
                    }
                }

                kernel = array;
                grid.LoadData( kernel );

                UpdateFilter( );
            }
        }

        // Operator changed
        private void operatorCombo_SelectedIndexChanged( object sender, System.EventArgs e )
        {
            UpdateFilter( );
        }

        // Value changed in grid
        private void grid_ValueChanged( object sender, IPLab.GridEventArgs e )
        {
            UpdateFilter( );
        }

        // Update filter
        private void UpdateFilter( )
        {
            if ( kernel != null )
            {
                switch ( this.operatorCombo.SelectedIndex )
                {
                    case 0:
                        filter = new Convolution( kernel );
                        break;
                    case 1:
                        filter = new Correlation( kernel );
                        break;
                }
            }
            filterPreview.Filter = filter;
        }

        // On "Save" button - save kernel
        private void saveButton_Click( object sender, System.EventArgs e )
        {
            if ( sfd.ShowDialog( ) == DialogResult.OK )
            {
                try
                {
                    Serialize2DimArray.Save( sfd.FileName, kernel );
                }
                catch ( ApplicationException )
                {
                    MessageBox.Show( this, "Failed saving kernel to specified file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }
        }

        // On "Load" button - load kernel
        private void loadButton_Click( object sender, System.EventArgs e )
        {
            if ( ofd.ShowDialog( ) == DialogResult.OK )
            {
                try
                {
                    int[,] array = (int[,]) Serialize2DimArray.Load( ofd.FileName, typeof( int ) );
                    int size = array.GetLength( 0 );
                    int i;

                    // check size
                    if ( size != array.GetLength( 1 ) )
                        throw new ApplicationException( );

                    for ( i = 0; i < sizes.Length; i++ )
                    {
                        if ( size == sizes[i] )
                        {
                            this.sizeCombo.SelectedIndex = i;
                            break;
                        }
                    }
                    if ( i == sizes.Length )
                        throw new ApplicationException( );

                    kernel = array;
                    grid.LoadData( kernel );

                    UpdateFilter( );
                }
                catch ( ApplicationException )
                {
                    MessageBox.Show( this, "Failed loading kernel from specified file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }
        }
    }
}
