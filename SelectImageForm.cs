using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace IPLab
{
	/// <summary>
	/// Summary description for SelectImageForm.
	/// </summary>
	public class SelectImageForm : Form
	{
		private Panel panel1;
		private PictureBox pictureBox1;
		private ListView imagesList;
		private Button okButton;
		private Button cancelButton;
		private ColumnHeader columnHeader1;
		private Label descriptionLabel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		// Description property
		public string Description
		{
			set { descriptionLabel.Text = value; }
		}
		// ImageNames property
		public ArrayList ImageNames
		{
			set
			{
				imagesList.Items.Clear();

				if (value != null)
				{
					foreach (String name in value)
					{
						imagesList.Items.Add(name);
					}
				}

				okButton.Enabled = false;
			}
		}
		// SelectedItem property
		public int SelectedItem
		{
			get
			{
				return (imagesList.SelectedIndices.Count == 0) ? -1 : imagesList.SelectedIndices[0];
			}
		}


		// Constructor
		public SelectImageForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.panel1 = new Panel();
            this.descriptionLabel = new Label();
            this.pictureBox1 = new PictureBox();
            this.imagesList = new ListView();
            this.columnHeader1 = ((ColumnHeader)(new ColumnHeader()));
            this.okButton = new Button();
            this.cancelButton = new Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.descriptionLabel);
            this.panel1.Dock = DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(642, 65);
            this.panel1.TabIndex = 0;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.Location = new System.Drawing.Point(12, 11);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(329, 43);
            this.descriptionLabel.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBox1.Dock = DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 65);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(642, 1);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // imagesList
            // 
            this.imagesList.Columns.AddRange(new ColumnHeader[] {
            this.columnHeader1});
            this.imagesList.FullRowSelect = true;
            this.imagesList.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            this.imagesList.HideSelection = false;
            this.imagesList.Location = new System.Drawing.Point(12, 75);
            this.imagesList.MultiSelect = false;
            this.imagesList.Name = "imagesList";
            this.imagesList.Size = new System.Drawing.Size(329, 253);
            this.imagesList.TabIndex = 2;
            this.imagesList.UseCompatibleStateImageBehavior = false;
            this.imagesList.View = View.Details;
            this.imagesList.SelectedIndexChanged += new System.EventHandler(this.imagesList_SelectedIndexChanged);
            this.imagesList.DoubleClick += new System.EventHandler(this.imagesList_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Images";
            this.columnHeader1.Width = 230;
            // 
            // okButton
            // 
            this.okButton.DialogResult = DialogResult.OK;
            this.okButton.Enabled = false;
            this.okButton.FlatStyle = FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(78, 345);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(90, 24);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "Ok";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = DialogResult.Cancel;
            this.cancelButton.FlatStyle = FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(186, 345);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(90, 24);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            // 
            // SelectImageForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(642, 436);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.imagesList);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectImageForm";
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Select Image";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		// Selection changed in list view
		private void imagesList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			okButton.Enabled = (imagesList.SelectedIndices.Count != 0);
		}

		// Double click in list view
		private void imagesList_DoubleClick(object sender, System.EventArgs e)
		{
			if (imagesList.SelectedIndices.Count != 0)
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}
	}
}
