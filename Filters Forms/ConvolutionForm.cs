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
            this.cancelButton = new Button( );
            this.okButton = new Button( );
            this.operatorCombo = new ComboBox( );
            this.label2 = new Label( );
            this.sizeCombo = new ComboBox( );
            this.groupBox1 = new GroupBox( );
            this.loadButton = new Button( );
            this.saveButton = new Button( );
            this.grid = new IPLab.GridArrayInt( );
            this.label1 = new Label( );
            this.sfd = new SaveFileDialog( );
            this.ofd = new OpenFileDialog( );
            this.filterPreview = new IPLab.FilterPreview( );
            this.groupBox2 = new GroupBox( );
            this.groupBox1.SuspendLayout( );
            this.groupBox2.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ( AnchorStyles.Bottom | AnchorStyles.Right );
            this.cancelButton.DialogResult = DialogResult.Cancel;
            this.cancelButton.FlatStyle = FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point( 545, 355 );
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            // 
            // okButton
            // 
            this.okButton.Anchor = ( AnchorStyles.Bottom | AnchorStyles.Right );
            this.okButton.DialogResult = DialogResult.OK;
            this.okButton.FlatStyle = FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point( 460, 355 );
            this.okButton.Name = "okButton";
            this.okButton.TabIndex = 4;
            this.okButton.Text = "Ok";
            // 
            // operatorCombo
            // 
            this.operatorCombo.Anchor = ( AnchorStyles.Top | AnchorStyles.Right );
            this.operatorCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.operatorCombo.Items.AddRange( new object[] {
															   "Convolution",
															   "Correlation"} );
            this.operatorCombo.Location = new System.Drawing.Point( 450, 75 );
            this.operatorCombo.Name = "operatorCombo";
            this.operatorCombo.Size = new System.Drawing.Size( 170, 21 );
            this.operatorCombo.TabIndex = 3;
            this.operatorCombo.SelectedIndexChanged += new System.EventHandler( this.operatorCombo_SelectedIndexChanged );
            // 
            // label2
            // 
            this.label2.Anchor = ( AnchorStyles.Top | AnchorStyles.Right );
            this.label2.Location = new System.Drawing.Point( 450, 60 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 62, 15 );
            this.label2.TabIndex = 2;
            this.label2.Text = "Operation:";
            // 
            // sizeCombo
            // 
            this.sizeCombo.Anchor = ( AnchorStyles.Top | AnchorStyles.Right );
            this.sizeCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.sizeCombo.Location = new System.Drawing.Point( 450, 30 );
            this.sizeCombo.Name = "sizeCombo";
            this.sizeCombo.Size = new System.Drawing.Size( 170, 21 );
            this.sizeCombo.TabIndex = 1;
            this.sizeCombo.SelectedIndexChanged += new System.EventHandler( this.sizeCombo_SelectedIndexChanged );
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ( ( ( AnchorStyles.Top | AnchorStyles.Bottom )
                | AnchorStyles.Left )
                | AnchorStyles.Right );
            this.groupBox1.Controls.AddRange( new Control[] {
																					this.loadButton,
																					this.saveButton,
																					this.grid} );
            this.groupBox1.Location = new System.Drawing.Point( 10, 10 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 425, 375 );
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kernel";
            // 
            // loadButton
            // 
            this.loadButton.Anchor = ( AnchorStyles.Bottom | AnchorStyles.Right );
            this.loadButton.FlatStyle = FlatStyle.Flat;
            this.loadButton.Location = new System.Drawing.Point( 340, 344 );
            this.loadButton.Name = "loadButton";
            this.loadButton.TabIndex = 0;
            this.loadButton.TabStop = false;
            this.loadButton.Text = "&Load";
            this.loadButton.Click += new System.EventHandler( this.loadButton_Click );
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ( AnchorStyles.Bottom | AnchorStyles.Right );
            this.saveButton.FlatStyle = FlatStyle.Flat;
            this.saveButton.Location = new System.Drawing.Point( 260, 344 );
            this.saveButton.Name = "saveButton";
            this.saveButton.TabIndex = 1;
            this.saveButton.TabStop = false;
            this.saveButton.Text = "&Save";
            this.saveButton.Click += new System.EventHandler( this.saveButton_Click );
            // 
            // grid
            // 
            this.grid.Anchor = ( ( ( AnchorStyles.Top | AnchorStyles.Bottom )
                | AnchorStyles.Left )
                | AnchorStyles.Right );
            this.grid.AutoSizeMinHeight = 10;
            this.grid.AutoSizeMinWidth = 10;
            this.grid.AutoStretchColumnsToFitWidth = false;
            this.grid.AutoStretchRowsToFitHeight = false;
            this.grid.BorderStyle = BorderStyle.FixedSingle;
            this.grid.ContextMenuStyle = SourceGrid2.ContextMenuStyle.None;
            this.grid.CustomSort = false;
            this.grid.GridToolTipActive = true;
            this.grid.Location = new System.Drawing.Point( 10, 20 );
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size( 405, 315 );
            this.grid.SpecialKeys = SourceGrid2.GridSpecialKeys.Default;
            this.grid.TabIndex = 2;
            this.grid.TabStop = true;
            this.grid.ValueChanged += new IPLab.GridArrayInt.GridEventHandler( this.grid_ValueChanged );
            // 
            // label1
            // 
            this.label1.Anchor = ( AnchorStyles.Top | AnchorStyles.Right );
            this.label1.Location = new System.Drawing.Point( 450, 15 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 66, 15 );
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
            this.filterPreview.Location = new System.Drawing.Point( 10, 15 );
            this.filterPreview.Name = "filterPreview";
            this.filterPreview.Size = new System.Drawing.Size( 150, 150 );
            this.filterPreview.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ( AnchorStyles.Top | AnchorStyles.Right );
            this.groupBox2.Controls.AddRange( new Control[] {
																					this.filterPreview} );
            this.groupBox2.Location = new System.Drawing.Point( 450, 105 );
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size( 170, 175 );
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Preview";
            // 
            // ConvolutionForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size( 627, 396 );
            this.Controls.AddRange( new Control[] {
																		  this.groupBox2,
																		  this.cancelButton,
																		  this.okButton,
																		  this.operatorCombo,
																		  this.label2,
																		  this.sizeCombo,
																		  this.groupBox1,
																		  this.label1} );
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            this.Name = "ConvolutionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Convolution & Correlation";
            this.groupBox1.ResumeLayout( false );
            this.groupBox2.ResumeLayout( false );
            this.ResumeLayout( false );

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
