// Image Processing Lab
//
// Copyright ?Andrew Kirillov, 2005
// andrew.kirillov@gmail.com
//

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

using WeifenLuo.WinFormsUI;
using rpaulo.toolbar;
using AForge.Imaging;

namespace IPLab
{
   

    public class MainForm : Form, IDocumentsHost
	{
		private static string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "app.config");
		private static string dockManagerConfigFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockManager.config");

		private int unnamedNumber = 0;
		private Configuration config = new Configuration();
		private HistogramWindow histogramWin = new HistogramWindow();
		private ImageStatisticsWindow statisticsWin = new ImageStatisticsWindow();

		private ToolBarManager toolBarManager;
		private DockManager dockManager;
		private MainMenu mainMenu;
		private MenuItem fileItem;
		private MenuItem exitFileItem;
		private MenuItem OpenItem;
		private MenuItem menuItem2;
		private MenuItem closeFileItem;
		private MenuItem closeAllFileItem;
		private MenuItem optionsItem;
		private MenuItem openInNewOptionsItem;
		private MenuItem viewItem;
		private MenuItem windowItem;
		private MenuItem helpItem;
		private MenuItem histogramViewItem;
		private StatusBarPanel zoomPanel;
		private StatusBarPanel sizePanel;
		private StatusBarPanel infoPanel;
		private Panel panel1;
		private Controls.CustomStatusBar statusBar;
		private MenuItem rememberOptionsItem;
		private MenuItem menuItem1;
		private MenuItem reloadFileItem;
		private MenuItem menuItem3;
		private MenuItem centerViewItem;
		private StatusBarPanel selectionPanel;
		private OpenFileDialog ofd;
		private StatusBarPanel colorPanel;
		private ImageList imageList;
		private ImageList imageList2;
		private StatusBarPanel hslPanel;
		private MenuItem copyFileItem;
		private MenuItem pasteFileItem;
		private MenuItem menuItem5;
		private MenuItem saveFileItem;
		private SaveFileDialog sfd;
		private PrintDocument printDocument;
		private PrintPreviewDialog printPreviewDialog;
		private MenuItem printPreviewFileItem;
		private MenuItem pageSetupFileItem;
		private MenuItem printFileItem;
		private MenuItem menuItem8;
		private PageSetupDialog pageSetupDialog;
		private PrintDialog printDialog;
		private StatusBarPanel ycbcrPanel;
		private MenuItem statisticsViewItem;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel3;
        private Panel ViewPanel;
        private Button button1;
        private Button ViewButton;
        private Panel filePanel;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button fileButton;
        private Panel panelComplex;
        private Button button21;
        private Button button20;
        private Button button19;
        private Button button18;
        private Button button17;
        private Button button16;
        private Button ComplexButton;
        private Panel panelBasic;
        private Button button15;
        private Button button14;
        private Button button13;
        private Button button12;
        private Button BasicButton;
        private Panel panelSize;
        private Button button11;
        private Button button10;
        private Button button9;
        private Button button8;
        private Button SizeButton;
        private Button button7;
        private Button button6;
        private Button button22;
        private Panel panel4;
        private PictureBox pictureBox1;
        private Panel panel5;
        private IContainer components;

		public MainForm()
		{

			InitializeComponent();
            customizeDesing();
			toolBarManager = new ToolBarManager(this, this);


			histogramWin.DockStateChanged += new EventHandler(histogram_DockStateChanged);
			statisticsWin.DockStateChanged += new EventHandler(statistics_DockStateChanged);

			histogramWin.VisibleChanged += new EventHandler( histogram_VisibleChanged );
			statisticsWin.VisibleChanged += new EventHandler( statistics_VisibleChanged );
		}

        private void customizeDesing()
        {
            panelBasic.Visible = false;
            panelComplex.Visible = false;
            panelSize.Visible = false;
            filePanel.Visible = false;
            ViewPanel.Visible = false;
        }

        private void hideSubMenu()
        {
            if (panelBasic.Visible == true)
                panelBasic.Visible = false;
            if (panelComplex.Visible == true)
                panelComplex.Visible = false;
            if (panelSize.Visible == true)
                panelSize.Visible = false;
            if (filePanel.Visible == true)
                filePanel.Visible = false;
            if (ViewPanel.Visible == true)
                ViewPanel.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.fileItem = new System.Windows.Forms.MenuItem();
            this.OpenItem = new System.Windows.Forms.MenuItem();
            this.reloadFileItem = new System.Windows.Forms.MenuItem();
            this.saveFileItem = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.copyFileItem = new System.Windows.Forms.MenuItem();
            this.pasteFileItem = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.closeFileItem = new System.Windows.Forms.MenuItem();
            this.closeAllFileItem = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.pageSetupFileItem = new System.Windows.Forms.MenuItem();
            this.printFileItem = new System.Windows.Forms.MenuItem();
            this.printPreviewFileItem = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.exitFileItem = new System.Windows.Forms.MenuItem();
            this.viewItem = new System.Windows.Forms.MenuItem();
            this.histogramViewItem = new System.Windows.Forms.MenuItem();
            this.statisticsViewItem = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.centerViewItem = new System.Windows.Forms.MenuItem();
            this.optionsItem = new System.Windows.Forms.MenuItem();
            this.openInNewOptionsItem = new System.Windows.Forms.MenuItem();
            this.rememberOptionsItem = new System.Windows.Forms.MenuItem();
            this.windowItem = new System.Windows.Forms.MenuItem();
            this.helpItem = new System.Windows.Forms.MenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dockManager = new WeifenLuo.WinFormsUI.DockManager();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.pageSetupDialog = new System.Windows.Forms.PageSetupDialog();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelComplex = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button22 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.ComplexButton = new System.Windows.Forms.Button();
            this.panelBasic = new System.Windows.Forms.Panel();
            this.button15 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.BasicButton = new System.Windows.Forms.Button();
            this.panelSize = new System.Windows.Forms.Panel();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.SizeButton = new System.Windows.Forms.Button();
            this.ViewPanel = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ViewButton = new System.Windows.Forms.Button();
            this.filePanel = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.fileButton = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusBar = new IPLab.Controls.CustomStatusBar();
            this.zoomPanel = new System.Windows.Forms.StatusBarPanel();
            this.sizePanel = new System.Windows.Forms.StatusBarPanel();
            this.selectionPanel = new System.Windows.Forms.StatusBarPanel();
            this.colorPanel = new System.Windows.Forms.StatusBarPanel();
            this.hslPanel = new System.Windows.Forms.StatusBarPanel();
            this.ycbcrPanel = new System.Windows.Forms.StatusBarPanel();
            this.infoPanel = new System.Windows.Forms.StatusBarPanel();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelComplex.SuspendLayout();
            this.panelBasic.SuspendLayout();
            this.panelSize.SuspendLayout();
            this.ViewPanel.SuspendLayout();
            this.filePanel.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizePanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectionPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hslPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ycbcrPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.fileItem,
            this.viewItem,
            this.optionsItem,
            this.windowItem,
            this.helpItem});
            // 
            // fileItem
            // 
            this.fileItem.Index = 0;
            this.fileItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.OpenItem,
            this.reloadFileItem,
            this.saveFileItem,
            this.menuItem1,
            this.copyFileItem,
            this.pasteFileItem,
            this.menuItem5,
            this.closeFileItem,
            this.closeAllFileItem,
            this.menuItem8,
            this.pageSetupFileItem,
            this.printFileItem,
            this.printPreviewFileItem,
            this.menuItem2,
            this.exitFileItem});
            this.fileItem.Text = "File";
            this.fileItem.Popup += new System.EventHandler(this.fileItem_Popup);
            // 
            // OpenItem
            // 
            this.OpenItem.Index = 0;
            this.OpenItem.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.OpenItem.Text = "Open";
            this.OpenItem.Click += new System.EventHandler(this.OpenItem_Click);
            // 
            // reloadFileItem
            // 
            this.reloadFileItem.Index = 1;
            this.reloadFileItem.Shortcut = System.Windows.Forms.Shortcut.CtrlR;
            this.reloadFileItem.Text = "Reload";
            this.reloadFileItem.Click += new System.EventHandler(this.reloadFileItem_Click);
            // 
            // saveFileItem
            // 
            this.saveFileItem.Index = 2;
            this.saveFileItem.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.saveFileItem.Text = "Save";
            this.saveFileItem.Click += new System.EventHandler(this.saveFileItem_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 3;
            this.menuItem1.Text = "-";
            // 
            // copyFileItem
            // 
            this.copyFileItem.Index = 4;
            this.copyFileItem.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
            this.copyFileItem.Text = "Copy";
            this.copyFileItem.Click += new System.EventHandler(this.copyFileItem_Click);
            // 
            // pasteFileItem
            // 
            this.pasteFileItem.Index = 5;
            this.pasteFileItem.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
            this.pasteFileItem.Text = "Paste";
            this.pasteFileItem.Click += new System.EventHandler(this.pasteFileItem_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 6;
            this.menuItem5.Text = "-";
            // 
            // closeFileItem
            // 
            this.closeFileItem.Index = 7;
            this.closeFileItem.Shortcut = System.Windows.Forms.Shortcut.CtrlF4;
            this.closeFileItem.Text = "Close";
            this.closeFileItem.Click += new System.EventHandler(this.closeFileItem_Click);
            // 
            // closeAllFileItem
            // 
            this.closeAllFileItem.Index = 8;
            this.closeAllFileItem.Text = "Close All";
            this.closeAllFileItem.Click += new System.EventHandler(this.closeAllFileItem_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 9;
            this.menuItem8.Text = "-";
            // 
            // pageSetupFileItem
            // 
            this.pageSetupFileItem.Index = 10;
            this.pageSetupFileItem.Text = "PrintSettings";
            this.pageSetupFileItem.Click += new System.EventHandler(this.pageSetupFileItem_Click);
            // 
            // printFileItem
            // 
            this.printFileItem.Index = 11;
            this.printFileItem.Text = "Print";
            this.printFileItem.Click += new System.EventHandler(this.printFileItem_Click);
            // 
            // printPreviewFileItem
            // 
            this.printPreviewFileItem.Index = 12;
            this.printPreviewFileItem.Text = "Print Preview";
            this.printPreviewFileItem.Click += new System.EventHandler(this.printPreviewFileItem_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 13;
            this.menuItem2.Text = "-";
            // 
            // exitFileItem
            // 
            this.exitFileItem.Index = 14;
            this.exitFileItem.Text = "Exit";
            this.exitFileItem.Click += new System.EventHandler(this.exitFileItem_Click);
            // 
            // viewItem
            // 
            this.viewItem.Index = 1;
            this.viewItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.histogramViewItem,
            this.statisticsViewItem,
            this.menuItem3,
            this.centerViewItem});
            this.viewItem.MergeOrder = 1;
            this.viewItem.Text = "View";
            this.viewItem.Popup += new System.EventHandler(this.viewItem_Popup);
            // 
            // histogramViewItem
            // 
            this.histogramViewItem.Index = 0;
            this.histogramViewItem.Shortcut = System.Windows.Forms.Shortcut.CtrlH;
            this.histogramViewItem.Text = "Histogram";
            this.histogramViewItem.Click += new System.EventHandler(this.histogramViewItem_Click);
            // 
            // statisticsViewItem
            // 
            this.statisticsViewItem.Index = 1;
            this.statisticsViewItem.Shortcut = System.Windows.Forms.Shortcut.CtrlT;
            this.statisticsViewItem.Text = "Statistics";
            this.statisticsViewItem.Click += new System.EventHandler(this.statisticsViewItem_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 2;
            this.menuItem3.Text = "-";
            // 
            // centerViewItem
            // 
            this.centerViewItem.Index = 3;
            this.centerViewItem.Shortcut = System.Windows.Forms.Shortcut.F9;
            this.centerViewItem.Text = "Center";
            this.centerViewItem.Click += new System.EventHandler(this.centerViewItem_Click);
            // 
            // optionsItem
            // 
            this.optionsItem.Index = 2;
            this.optionsItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.openInNewOptionsItem,
            this.rememberOptionsItem});
            this.optionsItem.MergeOrder = 2;
            this.optionsItem.Text = "Options";
            this.optionsItem.Popup += new System.EventHandler(this.optionsItem_Popup);
            // 
            // openInNewOptionsItem
            // 
            this.openInNewOptionsItem.Index = 0;
            this.openInNewOptionsItem.Text = "ChangeOnNew";
            this.openInNewOptionsItem.Click += new System.EventHandler(this.openInNewOptionsItem_Click);
            // 
            // rememberOptionsItem
            // 
            this.rememberOptionsItem.Index = 1;
            this.rememberOptionsItem.Text = "RememberChange";
            this.rememberOptionsItem.Click += new System.EventHandler(this.rememberOptionsItem_Click);
            // 
            // windowItem
            // 
            this.windowItem.Index = 3;
            this.windowItem.MdiList = true;
            this.windowItem.MergeOrder = 3;
            this.windowItem.Text = "Windows";
            // 
            // helpItem
            // 
            this.helpItem.Index = 4;
            this.helpItem.MergeOrder = 4;
            this.helpItem.Text = "About";
            this.helpItem.Click += new System.EventHandler(this.aboutHelpItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dockManager);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(252, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1408, 1244);
            this.panel1.TabIndex = 2;
            // 
            // dockManager
            // 
            this.dockManager.ActiveAutoHideContent = null;
            this.dockManager.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.dockManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockManager.Location = new System.Drawing.Point(0, 0);
            this.dockManager.Name = "dockManager";
            this.dockManager.Size = new System.Drawing.Size(1408, 1244);
            this.dockManager.TabIndex = 2;
            this.dockManager.ActiveDocumentChanged += new System.EventHandler(this.dockManager_ActiveDocumentChanged);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "");
            this.imageList.Images.SetKeyName(1, "");
            this.imageList.Images.SetKeyName(2, "");
            this.imageList.Images.SetKeyName(3, "");
            this.imageList.Images.SetKeyName(4, "");
            this.imageList.Images.SetKeyName(5, "");
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "");
            this.imageList2.Images.SetKeyName(1, "");
            this.imageList2.Images.SetKeyName(2, "");
            this.imageList2.Images.SetKeyName(3, "");
            this.imageList2.Images.SetKeyName(4, "");
            this.imageList2.Images.SetKeyName(5, "");
            this.imageList2.Images.SetKeyName(6, "");
            this.imageList2.Images.SetKeyName(7, "");
            this.imageList2.Images.SetKeyName(8, "");
            this.imageList2.Images.SetKeyName(9, "");
            this.imageList2.Images.SetKeyName(10, "");
            this.imageList2.Images.SetKeyName(11, "");
            this.imageList2.Images.SetKeyName(12, "");
            this.imageList2.Images.SetKeyName(13, "");
            this.imageList2.Images.SetKeyName(14, "");
            // 
            // ofd
            // 
            this.ofd.Filter = "Image files (*.jpg,*.png,*.tif,*.bmp,*.gif)|*.jpg;*.png;*.tif;*.bmp;*.gif|JPG fil" +
    "es (*.jpg)|*.jpg|PNG files (*.png)|*.png|TIF files (*.tif)|*.tif|BMP files (*.bm" +
    "p)|*.bmp|GIF files (*.gif)|*.gif";
            this.ofd.Title = "Open image";
            // 
            // sfd
            // 
            this.sfd.Filter = "JPG files (*.jpg)|*.jpg|BMP files (*.bmp)|*.bmp";
            this.sfd.Title = "Save image";
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog";
            this.printPreviewDialog.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1663, 370);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.statusBar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 370);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1663, 50);
            this.panel3.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel2.BackgroundImage = global::IPLab.Properties.Resources.OIP1;
            this.panel2.Controls.Add(this.panelComplex);
            this.panel2.Controls.Add(this.ComplexButton);
            this.panel2.Controls.Add(this.panelBasic);
            this.panel2.Controls.Add(this.BasicButton);
            this.panel2.Controls.Add(this.panelSize);
            this.panel2.Controls.Add(this.SizeButton);
            this.panel2.Controls.Add(this.ViewPanel);
            this.panel2.Controls.Add(this.ViewButton);
            this.panel2.Controls.Add(this.filePanel);
            this.panel2.Controls.Add(this.fileButton);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(243, 1244);
            this.panel2.TabIndex = 4;
            // 
            // panelComplex
            // 
            this.panelComplex.Controls.Add(this.panel5);
            this.panelComplex.Controls.Add(this.button22);
            this.panelComplex.Controls.Add(this.button21);
            this.panelComplex.Controls.Add(this.button20);
            this.panelComplex.Controls.Add(this.button19);
            this.panelComplex.Controls.Add(this.button18);
            this.panelComplex.Controls.Add(this.button17);
            this.panelComplex.Controls.Add(this.button16);
            this.panelComplex.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelComplex.Location = new System.Drawing.Point(0, 1067);
            this.panelComplex.Name = "panelComplex";
            this.panelComplex.Size = new System.Drawing.Size(209, 292);
            this.panelComplex.TabIndex = 9;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 287);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(209, 5);
            this.panel5.TabIndex = 2;
            // 
            // button22
            // 
            this.button22.BackColor = System.Drawing.Color.Azure;
            this.button22.Dock = System.Windows.Forms.DockStyle.Top;
            this.button22.FlatAppearance.BorderSize = 0;
            this.button22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button22.Image = global::IPLab.Properties.Resources._9022973_wave_sine_duotone_icon;
            this.button22.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button22.Location = new System.Drawing.Point(0, 246);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(209, 41);
            this.button22.TabIndex = 6;
            this.button22.Text = "Fourier";
            this.button22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button22.UseVisualStyleBackColor = false;
            this.button22.Click += new System.EventHandler(this.button22_Click);
            // 
            // button21
            // 
            this.button21.BackColor = System.Drawing.Color.Azure;
            this.button21.Dock = System.Windows.Forms.DockStyle.Top;
            this.button21.FlatAppearance.BorderSize = 0;
            this.button21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button21.Image = global::IPLab.Properties.Resources._1041639_light_saturation_icon;
            this.button21.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button21.Location = new System.Drawing.Point(0, 205);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(209, 41);
            this.button21.TabIndex = 5;
            this.button21.Text = "Saturation";
            this.button21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button21.UseVisualStyleBackColor = false;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.Color.Azure;
            this.button20.Dock = System.Windows.Forms.DockStyle.Top;
            this.button20.FlatAppearance.BorderSize = 0;
            this.button20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button20.Image = global::IPLab.Properties.Resources._4879884_circle_round_spinner_icon;
            this.button20.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button20.Location = new System.Drawing.Point(0, 164);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(209, 41);
            this.button20.TabIndex = 4;
            this.button20.Text = "Convolution";
            this.button20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button20.UseVisualStyleBackColor = false;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // button19
            // 
            this.button19.BackColor = System.Drawing.Color.Azure;
            this.button19.Dock = System.Windows.Forms.DockStyle.Top;
            this.button19.FlatAppearance.BorderSize = 0;
            this.button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button19.Image = global::IPLab.Properties.Resources._9081517_vector_triangle_icon;
            this.button19.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button19.Location = new System.Drawing.Point(0, 123);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(209, 41);
            this.button19.TabIndex = 3;
            this.button19.Text = "Morphology";
            this.button19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button19.UseVisualStyleBackColor = false;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // button18
            // 
            this.button18.BackColor = System.Drawing.Color.Azure;
            this.button18.Dock = System.Windows.Forms.DockStyle.Top;
            this.button18.FlatAppearance.BorderSize = 0;
            this.button18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button18.Image = global::IPLab.Properties.Resources._9043657_threshold_icon;
            this.button18.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button18.Location = new System.Drawing.Point(0, 82);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(209, 41);
            this.button18.TabIndex = 2;
            this.button18.Text = "Threshold";
            this.button18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button18.UseVisualStyleBackColor = false;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // button17
            // 
            this.button17.BackColor = System.Drawing.Color.Azure;
            this.button17.Dock = System.Windows.Forms.DockStyle.Top;
            this.button17.FlatAppearance.BorderSize = 0;
            this.button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button17.Image = global::IPLab.Properties.Resources._9042834_menu_scale_icon;
            this.button17.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button17.Location = new System.Drawing.Point(0, 41);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(209, 41);
            this.button17.TabIndex = 1;
            this.button17.Text = "Grayscale";
            this.button17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button17.UseVisualStyleBackColor = false;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.Azure;
            this.button16.Dock = System.Windows.Forms.DockStyle.Top;
            this.button16.FlatAppearance.BorderSize = 0;
            this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button16.Image = global::IPLab.Properties.Resources._8201378_adjust_settings_levels_ui_icon;
            this.button16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button16.Location = new System.Drawing.Point(0, 0);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(209, 41);
            this.button16.TabIndex = 0;
            this.button16.Text = "Levels";
            this.button16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button16.UseVisualStyleBackColor = false;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // ComplexButton
            // 
            this.ComplexButton.AutoSize = true;
            this.ComplexButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ComplexButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ComplexButton.FlatAppearance.BorderSize = 0;
            this.ComplexButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComplexButton.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ComplexButton.Location = new System.Drawing.Point(0, 1015);
            this.ComplexButton.Name = "ComplexButton";
            this.ComplexButton.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.ComplexButton.Size = new System.Drawing.Size(209, 52);
            this.ComplexButton.TabIndex = 8;
            this.ComplexButton.Text = "Complex";
            this.ComplexButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ComplexButton.UseVisualStyleBackColor = false;
            this.ComplexButton.Click += new System.EventHandler(this.ComplexButton_Click);
            // 
            // panelBasic
            // 
            this.panelBasic.Controls.Add(this.button15);
            this.panelBasic.Controls.Add(this.button14);
            this.panelBasic.Controls.Add(this.button13);
            this.panelBasic.Controls.Add(this.button12);
            this.panelBasic.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBasic.Location = new System.Drawing.Point(0, 848);
            this.panelBasic.Name = "panelBasic";
            this.panelBasic.Size = new System.Drawing.Size(209, 167);
            this.panelBasic.TabIndex = 7;
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.Azure;
            this.button15.Dock = System.Windows.Forms.DockStyle.Top;
            this.button15.FlatAppearance.BorderSize = 0;
            this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button15.Image = global::IPLab.Properties.Resources._8665088_arrow_rotate_right_icon;
            this.button15.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button15.Location = new System.Drawing.Point(0, 123);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(209, 41);
            this.button15.TabIndex = 3;
            this.button15.Text = "Rotate";
            this.button15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button15.UseVisualStyleBackColor = false;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.Azure;
            this.button14.Dock = System.Windows.Forms.DockStyle.Top;
            this.button14.FlatAppearance.BorderSize = 0;
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button14.Image = global::IPLab.Properties.Resources._9035906_resize_sharp_icon;
            this.button14.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button14.Location = new System.Drawing.Point(0, 82);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(209, 41);
            this.button14.TabIndex = 2;
            this.button14.Text = "Resize";
            this.button14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.Azure;
            this.button13.Dock = System.Windows.Forms.DockStyle.Top;
            this.button13.FlatAppearance.BorderSize = 0;
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.Image = global::IPLab.Properties.Resources._352293_crop_icon;
            this.button13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button13.Location = new System.Drawing.Point(0, 41);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(209, 41);
            this.button13.TabIndex = 1;
            this.button13.Text = "Crop";
            this.button13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.Azure;
            this.button12.Dock = System.Windows.Forms.DockStyle.Top;
            this.button12.FlatAppearance.BorderSize = 0;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Image = global::IPLab.Properties.Resources._8723058_copy_clone_icon;
            this.button12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button12.Location = new System.Drawing.Point(0, 0);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(209, 41);
            this.button12.TabIndex = 0;
            this.button12.Text = "Clone";
            this.button12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // BasicButton
            // 
            this.BasicButton.AutoSize = true;
            this.BasicButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BasicButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.BasicButton.FlatAppearance.BorderSize = 0;
            this.BasicButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BasicButton.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BasicButton.Location = new System.Drawing.Point(0, 796);
            this.BasicButton.Name = "BasicButton";
            this.BasicButton.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.BasicButton.Size = new System.Drawing.Size(209, 52);
            this.BasicButton.TabIndex = 6;
            this.BasicButton.Text = "Basic";
            this.BasicButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BasicButton.UseVisualStyleBackColor = false;
            this.BasicButton.Click += new System.EventHandler(this.BasicButton_Click);
            // 
            // panelSize
            // 
            this.panelSize.Controls.Add(this.button11);
            this.panelSize.Controls.Add(this.button10);
            this.panelSize.Controls.Add(this.button9);
            this.panelSize.Controls.Add(this.button8);
            this.panelSize.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSize.Location = new System.Drawing.Point(0, 630);
            this.panelSize.Name = "panelSize";
            this.panelSize.Size = new System.Drawing.Size(209, 166);
            this.panelSize.TabIndex = 5;
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Azure;
            this.button11.Dock = System.Windows.Forms.DockStyle.Top;
            this.button11.FlatAppearance.BorderSize = 0;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Image = global::IPLab.Properties.Resources._8550621_normal_size_full_screen_resize_icon;
            this.button11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button11.Location = new System.Drawing.Point(0, 123);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(209, 41);
            this.button11.TabIndex = 3;
            this.button11.Text = "FitToSize";
            this.button11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Azure;
            this.button10.Dock = System.Windows.Forms.DockStyle.Top;
            this.button10.FlatAppearance.BorderSize = 0;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Image = global::IPLab.Properties.Resources._326690_magnify_search_zoom_icon;
            this.button10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button10.Location = new System.Drawing.Point(0, 82);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(209, 41);
            this.button10.TabIndex = 2;
            this.button10.Text = "Original";
            this.button10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Azure;
            this.button9.Dock = System.Windows.Forms.DockStyle.Top;
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Image = global::IPLab.Properties.Resources._1110958_essential_out_plus_round_set_icon;
            this.button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button9.Location = new System.Drawing.Point(0, 41);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(209, 41);
            this.button9.TabIndex = 1;
            this.button9.Text = "ZoomOut";
            this.button9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Azure;
            this.button8.Dock = System.Windows.Forms.DockStyle.Top;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Image = global::IPLab.Properties.Resources._1110960_essential_in_minus_round_set_icon;
            this.button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button8.Location = new System.Drawing.Point(0, 0);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(209, 41);
            this.button8.TabIndex = 0;
            this.button8.Text = "ZoomIn";
            this.button8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // SizeButton
            // 
            this.SizeButton.AutoSize = true;
            this.SizeButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.SizeButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.SizeButton.FlatAppearance.BorderSize = 0;
            this.SizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SizeButton.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SizeButton.Location = new System.Drawing.Point(0, 578);
            this.SizeButton.Name = "SizeButton";
            this.SizeButton.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.SizeButton.Size = new System.Drawing.Size(209, 52);
            this.SizeButton.TabIndex = 4;
            this.SizeButton.Text = "Size";
            this.SizeButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SizeButton.UseVisualStyleBackColor = false;
            this.SizeButton.Click += new System.EventHandler(this.SizeButton_Click);
            // 
            // ViewPanel
            // 
            this.ViewPanel.Controls.Add(this.button7);
            this.ViewPanel.Controls.Add(this.button6);
            this.ViewPanel.Controls.Add(this.button1);
            this.ViewPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ViewPanel.Location = new System.Drawing.Point(0, 456);
            this.ViewPanel.Name = "ViewPanel";
            this.ViewPanel.Size = new System.Drawing.Size(209, 122);
            this.ViewPanel.TabIndex = 3;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Azure;
            this.button7.Dock = System.Windows.Forms.DockStyle.Top;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Image = global::IPLab.Properties.Resources._8207898_about_info_information_help_ui_icon;
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.Location = new System.Drawing.Point(0, 82);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(209, 41);
            this.button7.TabIndex = 2;
            this.button7.Text = "About";
            this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Azure;
            this.button6.Dock = System.Windows.Forms.DockStyle.Top;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Image = global::IPLab.Properties.Resources._353433_chart_pie_analytics_statistics_icon;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(0, 41);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(209, 41);
            this.button6.TabIndex = 1;
            this.button6.Text = "Statistics";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Azure;
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::IPLab.Properties.Resources._9069626_chart_histogram_icon;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(209, 41);
            this.button1.TabIndex = 0;
            this.button1.Text = "Histogram";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ViewButton
            // 
            this.ViewButton.AutoSize = true;
            this.ViewButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ViewButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ViewButton.FlatAppearance.BorderSize = 0;
            this.ViewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ViewButton.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ViewButton.Location = new System.Drawing.Point(0, 404);
            this.ViewButton.Name = "ViewButton";
            this.ViewButton.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.ViewButton.Size = new System.Drawing.Size(209, 52);
            this.ViewButton.TabIndex = 2;
            this.ViewButton.Text = "Views";
            this.ViewButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ViewButton.UseVisualStyleBackColor = false;
            this.ViewButton.Click += new System.EventHandler(this.ViewButton_Click);
            // 
            // filePanel
            // 
            this.filePanel.Controls.Add(this.button5);
            this.filePanel.Controls.Add(this.button4);
            this.filePanel.Controls.Add(this.button3);
            this.filePanel.Controls.Add(this.button2);
            this.filePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.filePanel.Location = new System.Drawing.Point(0, 239);
            this.filePanel.Name = "filePanel";
            this.filePanel.Size = new System.Drawing.Size(209, 165);
            this.filePanel.TabIndex = 1;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Azure;
            this.button5.Dock = System.Windows.Forms.DockStyle.Top;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Image = global::IPLab.Properties.Resources._8665765_paste_icon;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(0, 123);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(209, 41);
            this.button5.TabIndex = 3;
            this.button5.Text = "Paste";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Azure;
            this.button4.Dock = System.Windows.Forms.DockStyle.Top;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Image = global::IPLab.Properties.Resources._326595_content_copy_duplicate_icon;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(0, 82);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(209, 41);
            this.button4.TabIndex = 2;
            this.button4.Text = "Copy";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Azure;
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = global::IPLab.Properties.Resources._8666542_save_icon;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(0, 41);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(209, 41);
            this.button3.TabIndex = 1;
            this.button3.Text = "Save";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Azure;
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::IPLab.Properties.Resources._8530619_folder_open_icon;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button2.Size = new System.Drawing.Size(209, 41);
            this.button2.TabIndex = 0;
            this.button2.Text = "Open";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // fileButton
            // 
            this.fileButton.AutoSize = true;
            this.fileButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.fileButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.fileButton.FlatAppearance.BorderSize = 0;
            this.fileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fileButton.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fileButton.Location = new System.Drawing.Point(0, 187);
            this.fileButton.Name = "fileButton";
            this.fileButton.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.fileButton.Size = new System.Drawing.Size(209, 52);
            this.fileButton.TabIndex = 0;
            this.fileButton.Text = "File";
            this.fileButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.fileButton.UseVisualStyleBackColor = false;
            this.fileButton.Click += new System.EventHandler(this.fileButton_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(209, 187);
            this.panel4.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::IPLab.Properties.Resources.app;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(209, 187);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // statusBar
            // 
            this.statusBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusBar.Font = new System.Drawing.Font("»ªÎÄÖÐËÎ", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.statusBar.Location = new System.Drawing.Point(0, 0);
            this.statusBar.Name = "statusBar";
            this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.zoomPanel,
            this.sizePanel,
            this.selectionPanel,
            this.colorPanel,
            this.hslPanel,
            this.ycbcrPanel,
            this.infoPanel});
            this.statusBar.ShowPanels = true;
            this.statusBar.Size = new System.Drawing.Size(1663, 50);
            this.statusBar.TabIndex = 1;
            // 
            // zoomPanel
            // 
            this.zoomPanel.Name = "zoomPanel";
            this.zoomPanel.ToolTipText = "Zoom coefficient";
            this.zoomPanel.Width = 50;
            // 
            // sizePanel
            // 
            this.sizePanel.Name = "sizePanel";
            this.sizePanel.ToolTipText = "Image size";
            // 
            // selectionPanel
            // 
            this.selectionPanel.Name = "selectionPanel";
            this.selectionPanel.ToolTipText = "Current point and selection size";
            // 
            // colorPanel
            // 
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.ToolTipText = "Current color";
            this.colorPanel.Width = 135;
            // 
            // hslPanel
            // 
            this.hslPanel.Name = "hslPanel";
            this.hslPanel.Width = 185;
            // 
            // ycbcrPanel
            // 
            this.ycbcrPanel.Name = "ycbcrPanel";
            this.ycbcrPanel.Width = 230;
            // 
            // infoPanel
            // 
            this.infoPanel.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Width = 830;
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(15, 37);
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1663, 420);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel3);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Menu = this.mainMenu;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Processing Lab";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelComplex.ResumeLayout(false);
            this.panelBasic.ResumeLayout(false);
            this.panelSize.ResumeLayout(false);
            this.ViewPanel.ResumeLayout(false);
            this.filePanel.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizePanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectionPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hslPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ycbcrPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoPanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		#region IDocumentsHost implementation

		// Create new document on change on existent or modify it
		public bool CreateNewDocumentOnChange
		{
			get { return config.openInNewDoc; }
		}

		// Remember or not an image, so we can back one step
		public bool RememberOnChange
		{
			get { return config.rememberOnChange; }
		}

		// Create new document
		public bool NewDocument(Bitmap image)
		{
			unnamedNumber++;

			ImageDoc imgDoc = new ImageDoc(image, (IDocumentsHost) this);

			imgDoc.Text = "Image " + unnamedNumber.ToString();
			imgDoc.Show(dockManager);
			imgDoc.Focus();

			// set events
			SetupDocumentEvents(imgDoc);

			return true;
		}

		// Create new document for ComplexImage
		public bool NewDocument(ComplexImage image)
		{
			unnamedNumber++;

			FourierDoc imgDoc = new FourierDoc(image, (IDocumentsHost) this);

			imgDoc.Text = "Image " + unnamedNumber.ToString();
			imgDoc.Show(dockManager);
			imgDoc.Focus();

			return true;
		}

		// Get an image with specified dimension and pixel format
		public Bitmap GetImage(object sender, String text, Size size, PixelFormat format)
		{
			ArrayList	names = new ArrayList();
			ArrayList	images = new ArrayList();

			foreach (Content doc in dockManager.Documents)
			{
				if ((doc != sender) && (doc is ImageDoc))
				{
					Bitmap img = ((ImageDoc) doc).Image;

					// check pixel format, width and height
					if ((img.PixelFormat == format) &&
						((size.Width == -1) ||
						((img.Width == size.Width) && (img.Height == size.Height))))
					{
						names.Add(doc.Text);
						images.Add(img);
					}
				}
			}

			return null;
		}

		#endregion

		// On form closing
		private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// close all files
			foreach (Content c in dockManager.Documents)
				c.Close();

			// save configuration
			config.mainWindowLocation = this.Location;
			config.mainWindowSize = this.Size;
			config.Save(configFile);
			// save dock manager configuration
			dockManager.SaveAsXml(dockManagerConfigFile);
		}

		// On form load
		private void MainForm_Load(object sender, System.EventArgs e)
		{
			// load configuration
			if (config.Load(configFile))
			{
				this.Location = config.mainWindowLocation;
				this.Size = config.mainWindowSize;
			}

			try
			{
				// load dock manager configuration
				if (File.Exists(dockManagerConfigFile))
					dockManager.LoadFromXml(dockManagerConfigFile, new GetContentCallback(GetContentFromPersistString));
			}
			catch (Exception)
			{
			}

			// show histogram
			ShowHistogram(config.histogramVisible);
		}

		// Callback for loading Dock Manager
		private Content GetContentFromPersistString(string persistString)
		{
			if (persistString == typeof(HistogramWindow).ToString())
				return histogramWin;
			if (persistString == typeof(ImageStatisticsWindow).ToString())
				return statisticsWin;

			return null;
		}

		// Main tool bar clicked
		private void mainToolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
		{
			switch (e.Button.ImageIndex)
			{
				case 0:		// open an image
					OpenFile();
					break;
				case 1:		// save file
					SaveFile();
					break;
				case 2:		// copy
					CopyToClipboard();
					break;
				case 3:		// paste
					PasteFromClipboard();
					break;
				case 4:		// show histogram window
					ShowHistogram(!config.histogramVisible);
					break;
				case 5:		//about
					About();
					break;
			}
		}

		// active document changed
		private void dockManager_ActiveDocumentChanged(object sender, System.EventArgs e)
		{
			Content		doc = dockManager.ActiveDocument;
			ImageDoc	imgDoc = (doc is ImageDoc) ? (ImageDoc) doc : null;

			UpdateHistogram(imgDoc);
			UpdateStatistics(imgDoc);
			UpdateZoomStatus(imgDoc);

			UpdateSizeStatus(doc);
		}

		// About
		private void About()
		{
			AboutForm	about = new AboutForm();

			about.ShowDialog();
		}

		// On "Help->About"
		private void aboutHelpItem_Click(object sender, System.EventArgs e)
		{
			About();
		}

		// on File item popum - set state ot child menu items
		private void fileItem_Popup(object sender, System.EventArgs e)
		{
			Content	doc = dockManager.ActiveDocument;
			bool	docOpened = (doc != null);

			closeFileItem.Enabled = docOpened;
			closeAllFileItem.Enabled = (dockManager.Documents.Length > 0);
			reloadFileItem.Enabled = ((docOpened) && (doc is ImageDoc) && (((ImageDoc) doc).FileName != null));

			saveFileItem.Enabled = docOpened;
			copyFileItem.Enabled = docOpened;
			pasteFileItem.Enabled = (Clipboard.GetDataObject().GetDataPresent(DataFormats.Bitmap));

			printFileItem.Enabled = docOpened;
			printPreviewFileItem.Enabled = docOpened;
		}

		// Exit application
		private void exitFileItem_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		// Setup events
		private void SetupDocumentEvents(ImageDoc doc)
		{
			doc.DocumentChanged += new System.EventHandler(this.document_DocumentChanged);
			doc.ZoomChanged += new System.EventHandler(this.document_ZoomChanged);
			doc.MouseImagePosition += new ImageDoc.SelectionEventHandler(this.document_MouseImagePosition);
			doc.SelectionChanged += new ImageDoc.SelectionEventHandler(this.document_SelectionChanged);
		}

		// Open file
		private void OpenFile()
		{
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				ImageDoc imgDoc = null;
				
				try
				{
					// create image document
					imgDoc = new ImageDoc(ofd.FileName, (IDocumentsHost) this);
					imgDoc.Text = Path.GetFileName(ofd.FileName);

				}
				catch (ApplicationException ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

				if (imgDoc != null)
				{
					imgDoc.Show(dockManager);
					imgDoc.FitToScreen();
					imgDoc.Focus();

					// set events
					SetupDocumentEvents(imgDoc);
				}
			}		
		}

		// Show/hide histogram
		private void ShowHistogram(bool show)
		{
			config.histogramVisible = show;

			histogramViewItem.Checked = show;

			if (show)
			{
				histogramWin.Show(dockManager);
			}
			else
			{
				histogramWin.Hide();
			}
		}

		// Show/hide statistics
		private void ShowStatistics(bool show)
		{
			config.statisticsVisible = show;

			statisticsViewItem.Checked = show;

			if ( show )
			{
				statisticsWin.Show( dockManager );
			}
			else
			{
				statisticsWin.Hide( );
			}
		}



		// On "File->Open" item clicked
		private void OpenItem_Click(object sender, System.EventArgs e)
		{
			OpenFile();
		}

		// Reload file
		private void reloadFileItem_Click(object sender, System.EventArgs e)
		{
			Content	doc = dockManager.ActiveDocument;

			if ((doc != null) && (doc is ImageDoc))
			{
				try
				{
					((ImageDoc) doc).Reload();
				}
				catch (ApplicationException ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		// Save file
		private void SaveFile()
		{
			Content	doc = dockManager.ActiveDocument;

			if (doc != null)
			{
				// set initial file name
				if ((doc is ImageDoc) && (((ImageDoc) doc).FileName != null))
				{
					sfd.FileName = Path.GetFileName(((ImageDoc) doc).FileName);
				}
				else
				{
					sfd.FileName = doc.Text + ".jpg";
				}

				sfd.FilterIndex = 0;

				// show dialog
				if (sfd.ShowDialog(this) == DialogResult.OK)
				{
					ImageFormat format = ImageFormat.Jpeg;

					// resolve file format
					switch (Path.GetExtension(sfd.FileName).ToLower())
					{
						case ".jpg":
							format = ImageFormat.Jpeg;
							break;
						case ".bmp":
							format = ImageFormat.Bmp;
							break;
						default:
							MessageBox.Show(this, "Unsupported image format was specified", "Error",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
					}

					// save the image
					try
					{
						if (doc is ImageDoc)
						{
							((ImageDoc) doc).Image.Save(sfd.FileName, format);
						}
						if (doc is FourierDoc)
						{
							((FourierDoc) doc).Image.Save(sfd.FileName, format);
						}
					}
					catch (Exception)
					{
						MessageBox.Show(this, "Failed writing image file", "Error",
							MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		// On "File->Save" - save the file
		private void saveFileItem_Click(object sender, System.EventArgs e)
		{
			SaveFile();
		}

		// Copy image to clipboard
		private void CopyToClipboard()
		{
			Content	doc = dockManager.ActiveDocument;

			if (doc != null)
			{
				if (doc is ImageDoc)
				{
					Clipboard.SetDataObject(((ImageDoc) doc).Image, true);
				}
				if (doc is FourierDoc)
				{
					Clipboard.SetDataObject(((FourierDoc) doc).Image, true);
				}
			}
		}

		// On "File->Copy" - copy image to clipboard
		private void copyFileItem_Click(object sender, System.EventArgs e)
		{
			CopyToClipboard();
		}

		// Paste image from clipboard
		private void PasteFromClipboard()
		{
			if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Bitmap))
			{
				ImageDoc imgDoc = new ImageDoc((Bitmap) Clipboard.GetDataObject().GetData(DataFormats.Bitmap), (IDocumentsHost) this);

				imgDoc.Text = "Image " + unnamedNumber.ToString();
				imgDoc.Show(dockManager);
				imgDoc.Focus();

				// set events
				SetupDocumentEvents(imgDoc);
			}
		}

		// On "File->Paste" - paste image from clipboard
		private void pasteFileItem_Click(object sender, System.EventArgs e)
		{
			PasteFromClipboard();
		}

		// Close file
		private void closeFileItem_Click(object sender, System.EventArgs e)
		{
			if (dockManager.ActiveDocument != null)
				dockManager.ActiveDocument.Close();
		}

		// Close all files
		private void closeAllFileItem_Click(object sender, System.EventArgs e)
		{
			foreach (Content c in dockManager.Documents)
				c.Close();
		}

		// Page setup
		private void pageSetupFileItem_Click(object sender, System.EventArgs e)
		{
			try
			{
				pageSetupDialog.Document = printDocument;
				pageSetupDialog.ShowDialog();
			}
			catch (InvalidPrinterException)
			{
				MessageBox.Show(this, "Failed accessing printer device", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		// Print image
		private void printFileItem_Click(object sender, System.EventArgs e)
		{
			if (dockManager.ActiveDocument != null)
			{
				try
				{
					printDialog.Document = printDocument;
					if (printDialog.ShowDialog() == DialogResult.OK)
					{
						printDocument.Print();
					}
				}
				catch (InvalidPrinterException)
				{
					MessageBox.Show(this, "Failed accessing printer device", "Error",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		// Print preview
		private void printPreviewFileItem_Click(object sender, System.EventArgs e)
		{
			if (dockManager.ActiveDocument != null)
			{
				try
				{
					printPreviewDialog.Document = printDocument;
					printPreviewDialog.ShowDialog();
				}
				catch (InvalidPrinterException)
				{
					MessageBox.Show(this, "Failed accessing printer device", "Error",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}		
		}

		// On "Options" popup
		private void optionsItem_Popup(object sender, System.EventArgs e)
		{
			this.openInNewOptionsItem.Checked = config.openInNewDoc;
			this.rememberOptionsItem.Checked = config.rememberOnChange;
		}

		// On "Options->Open in new Document" click
		private void openInNewOptionsItem_Click(object sender, System.EventArgs e)
		{
			config.openInNewDoc = !config.openInNewDoc;
		}

		// On "Options->Remember on change" click
		private void rememberOptionsItem_Click(object sender, System.EventArgs e)
		{
			config.rememberOnChange = !config.rememberOnChange;
		}

		// On "View" popup
		private void viewItem_Popup(object sender, System.EventArgs e)
		{
			centerViewItem.Enabled = ((dockManager.ActiveDocument != null) && (dockManager.ActiveDocument is ImageDoc));
		}

		// On "View->Histogram" - show histogram
		private void histogramViewItem_Click(object sender, System.EventArgs e)
		{
			ShowHistogram( !config.histogramVisible );
		}

		// On "View->Statistics" - show histogram
		private void statisticsViewItem_Click(object sender, System.EventArgs e)
		{
			ShowStatistics( !config.statisticsVisible );
		}

		// Histogram visibility changed		
		private void histogram_VisibleChanged(object sender, System.EventArgs e)
		{
			if ( histogramWin.Visible )
				histogramWin.GatherStatistics( ( ( dockManager.ActiveDocument == null ) || !( dockManager.ActiveDocument is ImageDoc ) ) ? null : ((ImageDoc) dockManager.ActiveDocument).Image );
		}

		// Statistics visibility changed		
		private void statistics_VisibleChanged(object sender, System.EventArgs e)
		{
			if ( statisticsWin.Visible )
				statisticsWin.GatherStatistics( ( ( dockManager.ActiveDocument == null ) || !( dockManager.ActiveDocument is ImageDoc ) ) ? null : ((ImageDoc) dockManager.ActiveDocument).Image );
		}

		// On "View->Center" - center image
		private void centerViewItem_Click(object sender, System.EventArgs e)
		{
			Content	doc = dockManager.ActiveDocument;

			if ((doc != null) && (doc is ImageDoc))
				((ImageDoc) doc).Center();
		}

		// Switch histogram to red channel
		private void redHistogramViewItem_Click(object sender, System.EventArgs e)
		{
			if (histogramWin.Visible)
				histogramWin.SwitchChannel(0);
		}

		// Switch histogram to green channel
		private void greenHistogramViewItem_Click(object sender, System.EventArgs e)
		{
			if (histogramWin.Visible)
				histogramWin.SwitchChannel(1);
		}

		// Switch histogram to blue channel
		private void blueHistogramViewItem_Click(object sender, System.EventArgs e)
		{
			if (histogramWin.Visible)
				histogramWin.SwitchChannel(2);
		}

		// On document changed
		private void document_DocumentChanged(object sender, System.EventArgs e)
		{
			UpdateHistogram((ImageDoc) sender);
			UpdateStatistics((ImageDoc) sender);
			UpdateSizeStatus((ImageDoc) sender);
		}

		// On zoom factor changed
		private void document_ZoomChanged(object sender, System.EventArgs e)
		{
			UpdateZoomStatus((ImageDoc) sender);
		}

		// On mouse position over image changed
		private void document_MouseImagePosition(object sender, SelectionEventArgs e)
		{
			if (e.Location.X >= 0)
			{
				this.selectionPanel.Text = string.Format( "({0}, {1})", e.Location.X, e.Location.Y );

				// get current color
				Bitmap image = ((ImageDoc) sender).Image;
				if (image.PixelFormat == PixelFormat.Format24bppRgb)
				{
					Color	color = image.GetPixel(e.Location.X, e.Location.Y);
					RGB		rgb = new RGB( color );
					YCbCr	ycbcr = new YCbCr( );

					AForge.Imaging.ColorConverter.RGB2YCbCr( rgb, ycbcr );

					// RGB
					this.colorPanel.Text = string.Format( "RGB: {0}; {1}; {2}", color.R, color.G, color.B );
					// HSL
					this.hslPanel.Text = string.Format( "HSL: {0}; {1:F3}; {2:F3}", (int) color.GetHue(), color.GetSaturation(), color.GetBrightness() );
					// YCbCr
					this.ycbcrPanel.Text = string.Format( "YCbCr: {0:F3}; {1:F3}; {2:F3}", ycbcr.Y, ycbcr.Cb, ycbcr.Cr );
				}
				else if (image.PixelFormat == PixelFormat.Format8bppIndexed)
				{
					Color color = image.GetPixel(e.Location.X, e.Location.Y);
					this.colorPanel.Text	= "Gray: " + color.R.ToString();
					this.hslPanel.Text		= "";
					this.ycbcrPanel.Text	= "";
				}
			}
			else
			{
				this.selectionPanel.Text	= "";
				this.colorPanel.Text		= "";
				this.hslPanel.Text			= "";
				this.ycbcrPanel.Text		= "";
			}
		}

		// On selection changed
		private void document_SelectionChanged(object sender, SelectionEventArgs e)
		{
			this.selectionPanel.Text = string.Format( "({0}, {1}) - {2} x {3}", e.Location.X, e.Location.Y, e.Size.Width, e.Size.Height );
		}

		// Update histogram
		private void UpdateHistogram(ImageDoc imgDoc)
		{
			if ( histogramWin.Visible )
				histogramWin.GatherStatistics( ( imgDoc == null ) ? null : imgDoc.Image );
		}

		private void UpdateStatistics( ImageDoc imgDoc )
		{
			if ( statisticsWin.Visible )
				statisticsWin.GatherStatistics( ( imgDoc == null ) ? null : imgDoc.Image );
		}

		// Update size status
		private void UpdateSizeStatus(Content doc)
		{
			if (doc != null)
			{
				int w = 0, h = 0;

				if (doc is ImageDoc)
				{
					w = ((ImageDoc) doc).ImageWidth;
					h = ((ImageDoc) doc).ImageHeight;
				}
				else if (doc is FourierDoc)
				{
					w = ((FourierDoc) doc).ImageWidth;
					h = ((FourierDoc) doc).ImageHeight;
				}

				sizePanel.Text = w.ToString() + " x " + h.ToString();
			}
			else
			{
				sizePanel.Text = String.Empty;
			}
		}

		// Update zoom status
		private void UpdateZoomStatus(ImageDoc imgDoc)
		{
			if (imgDoc != null)
			{
				int zoom = (int)(imgDoc.Zoom * 100);
				zoomPanel.Text = zoom.ToString() + "%";
			}
			else
			{
				zoomPanel.Text = String.Empty;
			}
		}

		// On image toolbar clicked
		private void imageToolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
		{
			Content	doc = dockManager.ActiveDocument;

			if (doc != null)
			{
				if (doc is ImageDoc)
				{
					ImageDocCommands[] cmd = new ImageDocCommands[]
					{
						ImageDocCommands.Clone, ImageDocCommands.Crop,
						ImageDocCommands.ZoomIn, ImageDocCommands.ZoomOut,
						ImageDocCommands.ZoomOriginal, ImageDocCommands.FitToSize,
						ImageDocCommands.Levels, ImageDocCommands.Grayscale,
						ImageDocCommands.Threshold, ImageDocCommands.Morphology,
						ImageDocCommands.Convolution, ImageDocCommands.Resize,
						ImageDocCommands.Rotate, ImageDocCommands.Saturation,
						ImageDocCommands.Fourier
					};

					((ImageDoc) doc).ExecuteCommand(cmd[e.Button.ImageIndex]);
				}
			}
		}


		// Histogram docking state changed
		private void histogram_DockStateChanged(object sender, System.EventArgs e)
		{
			if ( histogramWin.DockState != DockState.Unknown )
			{
				bool visible = (histogramWin.DockState != DockState.Hidden);

				// save to config
				config.histogramVisible = visible;

				// update menu & tool bar
				histogramViewItem.Checked = visible;
			}
		}

		// Statistics docking state changed
		private void statistics_DockStateChanged(object sender, System.EventArgs e)
		{
			if ( statisticsWin.DockState != DockState.Unknown )
			{
				bool visible = (statisticsWin.DockState != DockState.Hidden);

				// save to config
				config.statisticsVisible = visible;

				// update menu & tool bar
				statisticsViewItem.Checked = visible;
			}
		}

		// Print document page
		private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			Content	doc = dockManager.ActiveDocument;

			if (doc != null)
			{
				Bitmap image = null;

				// get an image to print
				if (doc is ImageDoc)
				{
					image = ((ImageDoc) doc).Image;
				}
				else if (doc is FourierDoc)
				{
					image = ((FourierDoc) doc).Image;
				}

				System.Diagnostics.Debug.WriteLine("X: " + e.MarginBounds.Left + ", Y = " + e.MarginBounds.Top + ", width = " + e.MarginBounds.Width + ", height = " + e.MarginBounds.Height);
				System.Diagnostics.Debug.WriteLine("X: " + e.PageBounds.Left + ", Y = " + e.PageBounds.Top + ", width = " + e.PageBounds.Width + ", height = " + e.PageBounds.Height);

				int		width = image.Width;
				int		height = image.Height;

				if ((width > e.MarginBounds.Width) || (height > e.MarginBounds.Height))
				{
					float f = Math.Min((float) e.MarginBounds.Width / width, (float) e.MarginBounds.Height / height);

					width = (int)(f * width);
					height = (int)(f * height);
				}

				e.Graphics.DrawImage(image, e.MarginBounds.Left, e.MarginBounds.Top, width, height);
			}
		}

        private void optionsItem_Click(object sender, EventArgs e)
        {

        }

        private void fileButton_Click(object sender, EventArgs e)
        {
            showSubMenu(filePanel);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //
            OpenFile();
            hideSubMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //
            SaveFile();
            hideSubMenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //
            CopyToClipboard();
            hideSubMenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //
            PasteFromClipboard();
            hideSubMenu();
        }

        private void ViewButton_Click(object sender, EventArgs e)
        {
            showSubMenu(ViewPanel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //
            ShowHistogram(!config.histogramVisible);
            hideSubMenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //
            ShowStatistics(!config.statisticsVisible);
            hideSubMenu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //
            About();
            hideSubMenu();
        }

        private void SizeButton_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSize);
        }


        private void button8_Click(object sender, EventArgs e)
        {
            //
            Content doc = dockManager.ActiveDocument;
            if (doc != null)
            {
                if (doc is ImageDoc)
                {
                    ((ImageDoc)doc).ExecuteCommand(ImageDocCommands.ZoomIn);
                }
            }
            hideSubMenu();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //
            Content doc = dockManager.ActiveDocument;
            if (doc != null)
            {
                if (doc is ImageDoc)
                {
                    ((ImageDoc)doc).ExecuteCommand(ImageDocCommands.ZoomOut);
                }
            }
            hideSubMenu();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //
            Content doc = dockManager.ActiveDocument;
            if (doc != null)
            {
                if (doc is ImageDoc)
                {
                    ((ImageDoc)doc).ExecuteCommand(ImageDocCommands.ZoomOriginal);
                }
            }
            hideSubMenu();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //
            Content doc = dockManager.ActiveDocument;
            if (doc != null)
            {
                if (doc is ImageDoc)
                {
                    ((ImageDoc)doc).ExecuteCommand(ImageDocCommands.FitToSize);
                }
            }
            hideSubMenu();
        }

        private void BasicButton_Click(object sender, EventArgs e)
        {
            showSubMenu(panelBasic);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //
            Content doc = dockManager.ActiveDocument;
            if (doc != null)
            {
                if (doc is ImageDoc)
                {
                    ((ImageDoc)doc).ExecuteCommand(ImageDocCommands.Clone);
                }
            }
            hideSubMenu();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //
            Content doc = dockManager.ActiveDocument;
            if (doc != null)
            {
                if (doc is ImageDoc)
                {
                    ((ImageDoc)doc).ExecuteCommand(ImageDocCommands.Crop);
                }
            }
            hideSubMenu();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //
            Content doc = dockManager.ActiveDocument;
            if (doc != null)
            {
                if (doc is ImageDoc)
                {
                    ((ImageDoc)doc).ExecuteCommand(ImageDocCommands.Resize);
                }
            }
            hideSubMenu();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //
            Content doc = dockManager.ActiveDocument;
            if (doc != null)
            {
                if (doc is ImageDoc)
                {
                    ((ImageDoc)doc).ExecuteCommand(ImageDocCommands.Rotate);
                }
            }
            hideSubMenu();
        }
        private void ComplexButton_Click(object sender, EventArgs e)
        {
            showSubMenu(panelComplex);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //
            Content doc = dockManager.ActiveDocument;
            if (doc != null)
            {
                if (doc is ImageDoc)
                {
                    ((ImageDoc)doc).ExecuteCommand(ImageDocCommands.Levels);
                }
            }
            hideSubMenu();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //
            Content doc = dockManager.ActiveDocument;
            if (doc != null)
            {
                if (doc is ImageDoc)
                {
                    ((ImageDoc)doc).ExecuteCommand(ImageDocCommands.Grayscale);
                }
            }
            hideSubMenu();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            //
            Content doc = dockManager.ActiveDocument;
            if (doc != null)
            {
                if (doc is ImageDoc)
                {
                    ((ImageDoc)doc).ExecuteCommand(ImageDocCommands.Threshold);
                }
            }
            hideSubMenu();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            //
            Content doc = dockManager.ActiveDocument;
            if (doc != null)
            {
                if (doc is ImageDoc)
                {
                    ((ImageDoc)doc).ExecuteCommand(ImageDocCommands.Morphology);
                }
            }
            hideSubMenu();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            //
            Content doc = dockManager.ActiveDocument;
            if (doc != null)
            {
                if (doc is ImageDoc)
                {
                    ((ImageDoc)doc).ExecuteCommand(ImageDocCommands.Convolution);
                }
            }
            hideSubMenu();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            //
            Content doc = dockManager.ActiveDocument;
            if (doc != null)
            {
                if (doc is ImageDoc)
                {
                    ((ImageDoc)doc).ExecuteCommand(ImageDocCommands.Saturation);
                }
            }
            hideSubMenu();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            //
            Content doc = dockManager.ActiveDocument;
            if (doc != null)
            {
                if (doc is ImageDoc)
                {
                    ((ImageDoc)doc).ExecuteCommand(ImageDocCommands.Fourier);
                }
            }
            hideSubMenu();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            About();
        }
    }
}
