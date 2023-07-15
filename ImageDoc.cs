// Image Processing Lab
//
// Copyright ?Andrew Kirillov, 2005
// andrew.kirillov@gmail.com
//

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI;

using AForge;
using AForge.Math;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Imaging.Textures;
using IPLab.Filters_Forms;

namespace IPLab
{
    /// <summary>
    /// Summary description for ImageDoc.
    /// </summary>
    public class ImageDoc : Content
    {
        private System.Drawing.Bitmap backup = null;
        private System.Drawing.Bitmap image = null;
        private string fileName = null;
        private int width;
        private int height;
        private float zoom = 1;
        private IDocumentsHost host = null;

        private bool cropping = false;
        private bool dragging = false;
        private Point start, end, startW, endW;

        private MainMenu mainMenu;
        private MenuItem imageItem;
        private MenuItem cloneImageItem;
        private MenuItem backImageItem;
        private MenuItem menuItem4;
        private MenuItem menuItem5;
        private MenuItem menuItem6;
        private MenuItem menuItem7;
        private MenuItem z10ImageItem;
        private MenuItem z25ImageItem;
        private MenuItem z50ImageItem;
        private MenuItem z75ImageItem;
        private MenuItem z100ImageItem;
        private MenuItem z150ImageItem;
        private MenuItem z200ImageItem;
        private MenuItem z400ImageItem;
        private MenuItem z500ImageItem;
        private MenuItem menuItem8;
        private MenuItem zoomInImageItem;
        private MenuItem zoomOutImageItem;
        private MenuItem menuItem11;
        private MenuItem zoomFitImageItem;
        private MenuItem flipImageItem;
        private MenuItem mirrorItem;
        private MenuItem rotateImageItem;
        private MenuItem menuItem10;
        private MenuItem cropImageItem;
        private MenuItem menuItem3;
        private MenuItem filtersItem;
        private MenuItem colorFiltersItem;
        private MenuItem grayscaleColorFiltersItem;
        private MenuItem toRgbColorFiltersItem;
        private MenuItem menuItem16;
        private MenuItem colorFilteringColorFiltersItem;
        private MenuItem euclideanFilteringColorFiltersItem;
        private MenuItem channelsFilteringColorFiltersItem;
        private MenuItem hslFiltersItem;
        private MenuItem brightnessHslFiltersItem;
        private MenuItem contrastHslFiltersItem;
        private MenuItem saturationHslFiltersItem;
        private MenuItem menuItem29;
        private MenuItem linearHslFiltersItem;
        private MenuItem filteringHslFiltersItem;
        private MenuItem hueHslFiltersItem;
        private MenuItem ycbcrFiltersItem;
        private MenuItem linearYCbCrFiltersItem;
        private MenuItem filteringYCbCrFiltersItem;
        private MenuItem menuItem37;
        private MenuItem extracYFiltersItem;
        private MenuItem extracCbFiltersItem;
        private MenuItem extracCrFiltersItem;
        private MenuItem menuItem38;
        private MenuItem replaceYFiltersItem;
        private MenuItem replaceCbFiltersItem;
        private MenuItem replaceCrFiltersItem;
        private MenuItem binaryFiltersItem;
        private MenuItem thresholdBinaryFiltersItem;
        private MenuItem morphologyFiltersItem;
        private MenuItem customMorphologyFiltersItem;
        private MenuItem hitAndMissFiltersItem;
        private MenuItem convolutionFiltersItem;
        private MenuItem menuItem12;
        private MenuItem customConvolutionFiltersItem;
        private MenuItem gaussianConvolutionFiltersItem;
        private MenuItem sharpenExConvolutionFiltersItem;
        private MenuItem twosrcFiltersItem;
        private MenuItem mergeTwosrcFiltersItem;
        private MenuItem intersectTwosrcFiltersItem;
        private MenuItem menuItem21;
        private MenuItem addTwosrcFiltersItem;
        private MenuItem subtractTwosrcFiltersItem;
        private MenuItem menuItem22;
        private MenuItem differenceTwosrcFiltersItem;
        private MenuItem moveTowardsTwosrcFiltersItem;
        private MenuItem morphTwosrcFiltersItem;
        private MenuItem edgeFiltersItem;
        private MenuItem cannyEdgeFiltersItem;
        private MenuItem menuItem24;
        private MenuItem adaptiveSmoothingFiltersItem;
        private MenuItem conservativeSmoothingFiltersItem;
        private MenuItem menuItem34;
        private MenuItem perlinNoiseFiltersItem;
        private MenuItem oilPaintingFiltersItem;
        private MenuItem jitterFiltersItem;
        private MenuItem pixellateFiltersItem;
        private MenuItem simpleSkeletonizationFiltersItem;
        private MenuItem shrinkFiltersItem;
        private MenuItem menuItem30;
        private MenuItem labelingFiltersItem;
        private MenuItem blobExtractorFiltersItem;
        private MenuItem menuItem23;
        private MenuItem resizeFiltersItem;
        private MenuItem rotateFiltersItem;
        private MenuItem menuItem26;
        private MenuItem levelsFiltersItem;
        private MenuItem medianFiltersItem;
        private MenuItem gammaFiltersItem;
        private MenuItem fourierFiltersItem;
        private MenuItem menuItem13;
        private MenuItem menuItem1;
        private MenuItem menuItem9;
        private MenuItem menuItem2;
        private MenuItem menuItem14;
        private MenuItem menuItem15;
        private System.ComponentModel.IContainer components;

        // Image property
        public Bitmap Image
        {
            get { return image; }
        }
        // Width property
        public int ImageWidth
        {
            get { return width; }
        }
        // Height property
        public int ImageHeight
        {
            get { return height; }
        }
        // Zoom property
        public float Zoom
        {
            get { return zoom; }
        }
        // FileName property
        // return file name if the document was created from file or null
        public string FileName
        {
            get { return fileName; }
        }


        // Events
        public delegate void SelectionEventHandler( object sender, SelectionEventArgs e );

        public event EventHandler DocumentChanged;
        public event EventHandler ZoomChanged;
        public event SelectionEventHandler MouseImagePosition;
        public event SelectionEventHandler SelectionChanged;


        // Constructors
        private ImageDoc( IDocumentsHost host )
        {
            this.host = host;
        }
        // Construct from file
        public ImageDoc( string fileName, IDocumentsHost host )
            : this( host )
        {
            try
            {
                // load image
                image = (Bitmap) Bitmap.FromFile( fileName );

                // format image
                AForge.Imaging.Image.FormatImage( ref image );

                this.fileName = fileName;
            }
            catch ( Exception )
            {
                throw new ApplicationException( "Failed loading image" );
            }

            Init( );
        }
        // Construct from image
        public ImageDoc( Bitmap image, IDocumentsHost host )
            : this( host )
        {
            this.image = image;
            AForge.Imaging.Image.FormatImage( ref this.image );

            Init( );
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
                if ( image != null )
                {
                    image.Dispose( );
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
            this.components = new System.ComponentModel.Container();
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.imageItem = new System.Windows.Forms.MenuItem();
            this.backImageItem = new System.Windows.Forms.MenuItem();
            this.cloneImageItem = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.z10ImageItem = new System.Windows.Forms.MenuItem();
            this.z25ImageItem = new System.Windows.Forms.MenuItem();
            this.z50ImageItem = new System.Windows.Forms.MenuItem();
            this.z75ImageItem = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.z100ImageItem = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.z150ImageItem = new System.Windows.Forms.MenuItem();
            this.z200ImageItem = new System.Windows.Forms.MenuItem();
            this.z400ImageItem = new System.Windows.Forms.MenuItem();
            this.z500ImageItem = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.zoomInImageItem = new System.Windows.Forms.MenuItem();
            this.zoomOutImageItem = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.zoomFitImageItem = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.flipImageItem = new System.Windows.Forms.MenuItem();
            this.mirrorItem = new System.Windows.Forms.MenuItem();
            this.rotateImageItem = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.cropImageItem = new System.Windows.Forms.MenuItem();
            this.filtersItem = new System.Windows.Forms.MenuItem();
            this.colorFiltersItem = new System.Windows.Forms.MenuItem();
            this.grayscaleColorFiltersItem = new System.Windows.Forms.MenuItem();
            this.toRgbColorFiltersItem = new System.Windows.Forms.MenuItem();
            this.menuItem16 = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.colorFilteringColorFiltersItem = new System.Windows.Forms.MenuItem();
            this.euclideanFilteringColorFiltersItem = new System.Windows.Forms.MenuItem();
            this.channelsFilteringColorFiltersItem = new System.Windows.Forms.MenuItem();
            this.hslFiltersItem = new System.Windows.Forms.MenuItem();
            this.brightnessHslFiltersItem = new System.Windows.Forms.MenuItem();
            this.contrastHslFiltersItem = new System.Windows.Forms.MenuItem();
            this.saturationHslFiltersItem = new System.Windows.Forms.MenuItem();
            this.menuItem29 = new System.Windows.Forms.MenuItem();
            this.linearHslFiltersItem = new System.Windows.Forms.MenuItem();
            this.filteringHslFiltersItem = new System.Windows.Forms.MenuItem();
            this.hueHslFiltersItem = new System.Windows.Forms.MenuItem();
            this.ycbcrFiltersItem = new System.Windows.Forms.MenuItem();
            this.linearYCbCrFiltersItem = new System.Windows.Forms.MenuItem();
            this.filteringYCbCrFiltersItem = new System.Windows.Forms.MenuItem();
            this.menuItem37 = new System.Windows.Forms.MenuItem();
            this.extracYFiltersItem = new System.Windows.Forms.MenuItem();
            this.extracCbFiltersItem = new System.Windows.Forms.MenuItem();
            this.extracCrFiltersItem = new System.Windows.Forms.MenuItem();
            this.menuItem38 = new System.Windows.Forms.MenuItem();
            this.replaceYFiltersItem = new System.Windows.Forms.MenuItem();
            this.replaceCbFiltersItem = new System.Windows.Forms.MenuItem();
            this.replaceCrFiltersItem = new System.Windows.Forms.MenuItem();
            this.binaryFiltersItem = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.thresholdBinaryFiltersItem = new System.Windows.Forms.MenuItem();
            this.morphologyFiltersItem = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.customMorphologyFiltersItem = new System.Windows.Forms.MenuItem();
            this.hitAndMissFiltersItem = new System.Windows.Forms.MenuItem();
            this.twosrcFiltersItem = new System.Windows.Forms.MenuItem();
            this.mergeTwosrcFiltersItem = new System.Windows.Forms.MenuItem();
            this.intersectTwosrcFiltersItem = new System.Windows.Forms.MenuItem();
            this.menuItem21 = new System.Windows.Forms.MenuItem();
            this.addTwosrcFiltersItem = new System.Windows.Forms.MenuItem();
            this.subtractTwosrcFiltersItem = new System.Windows.Forms.MenuItem();
            this.menuItem22 = new System.Windows.Forms.MenuItem();
            this.differenceTwosrcFiltersItem = new System.Windows.Forms.MenuItem();
            this.moveTowardsTwosrcFiltersItem = new System.Windows.Forms.MenuItem();
            this.morphTwosrcFiltersItem = new System.Windows.Forms.MenuItem();
            this.convolutionFiltersItem = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.customConvolutionFiltersItem = new System.Windows.Forms.MenuItem();
            this.gaussianConvolutionFiltersItem = new System.Windows.Forms.MenuItem();
            this.sharpenExConvolutionFiltersItem = new System.Windows.Forms.MenuItem();
            this.edgeFiltersItem = new System.Windows.Forms.MenuItem();
            this.cannyEdgeFiltersItem = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.menuItem24 = new System.Windows.Forms.MenuItem();
            this.adaptiveSmoothingFiltersItem = new System.Windows.Forms.MenuItem();
            this.conservativeSmoothingFiltersItem = new System.Windows.Forms.MenuItem();
            this.menuItem34 = new System.Windows.Forms.MenuItem();
            this.perlinNoiseFiltersItem = new System.Windows.Forms.MenuItem();
            this.oilPaintingFiltersItem = new System.Windows.Forms.MenuItem();
            this.jitterFiltersItem = new System.Windows.Forms.MenuItem();
            this.pixellateFiltersItem = new System.Windows.Forms.MenuItem();
            this.simpleSkeletonizationFiltersItem = new System.Windows.Forms.MenuItem();
            this.shrinkFiltersItem = new System.Windows.Forms.MenuItem();
            this.menuItem30 = new System.Windows.Forms.MenuItem();
            this.labelingFiltersItem = new System.Windows.Forms.MenuItem();
            this.blobExtractorFiltersItem = new System.Windows.Forms.MenuItem();
            this.menuItem23 = new System.Windows.Forms.MenuItem();
            this.resizeFiltersItem = new System.Windows.Forms.MenuItem();
            this.rotateFiltersItem = new System.Windows.Forms.MenuItem();
            this.menuItem26 = new System.Windows.Forms.MenuItem();
            this.levelsFiltersItem = new System.Windows.Forms.MenuItem();
            this.medianFiltersItem = new System.Windows.Forms.MenuItem();
            this.gammaFiltersItem = new System.Windows.Forms.MenuItem();
            this.fourierFiltersItem = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.imageItem,
            this.filtersItem});
            // 
            // imageItem
            // 
            this.imageItem.Index = 0;
            this.imageItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.backImageItem,
            this.cloneImageItem,
            this.menuItem4,
            this.menuItem5,
            this.menuItem10,
            this.flipImageItem,
            this.mirrorItem,
            this.rotateImageItem,
            this.menuItem3,
            this.cropImageItem});
            this.imageItem.MergeOrder = 1;
            this.imageItem.Text = "Image";
            this.imageItem.Popup += new System.EventHandler(this.imageItem_Popup);
            // 
            // backImageItem
            // 
            this.backImageItem.Index = 0;
            this.backImageItem.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
            this.backImageItem.Text = "&Back";
            this.backImageItem.Click += new System.EventHandler(this.backImageItem_Click);
            // 
            // cloneImageItem
            // 
            this.cloneImageItem.Index = 1;
            this.cloneImageItem.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.cloneImageItem.Text = "&Clone";
            this.cloneImageItem.Click += new System.EventHandler(this.cloneImageItem_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 2;
            this.menuItem4.Text = "-";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 3;
            this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.z10ImageItem,
            this.z25ImageItem,
            this.z50ImageItem,
            this.z75ImageItem,
            this.menuItem7,
            this.z100ImageItem,
            this.menuItem6,
            this.z150ImageItem,
            this.z200ImageItem,
            this.z400ImageItem,
            this.z500ImageItem,
            this.menuItem8,
            this.zoomInImageItem,
            this.zoomOutImageItem,
            this.menuItem11,
            this.zoomFitImageItem});
            this.menuItem5.Text = "&Zoom";
            // 
            // z10ImageItem
            // 
            this.z10ImageItem.Index = 0;
            this.z10ImageItem.Text = "10%";
            this.z10ImageItem.Click += new System.EventHandler(this.zoomItem_Click);
            // 
            // z25ImageItem
            // 
            this.z25ImageItem.Index = 1;
            this.z25ImageItem.Text = "25%";
            this.z25ImageItem.Click += new System.EventHandler(this.zoomItem_Click);
            // 
            // z50ImageItem
            // 
            this.z50ImageItem.Index = 2;
            this.z50ImageItem.Text = "50%";
            this.z50ImageItem.Click += new System.EventHandler(this.zoomItem_Click);
            // 
            // z75ImageItem
            // 
            this.z75ImageItem.Index = 3;
            this.z75ImageItem.Text = "75%";
            this.z75ImageItem.Click += new System.EventHandler(this.zoomItem_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 4;
            this.menuItem7.Text = "-";
            // 
            // z100ImageItem
            // 
            this.z100ImageItem.Index = 5;
            this.z100ImageItem.Shortcut = System.Windows.Forms.Shortcut.Ctrl0;
            this.z100ImageItem.Text = "100%";
            this.z100ImageItem.Click += new System.EventHandler(this.zoomItem_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 6;
            this.menuItem6.Text = "-";
            // 
            // z150ImageItem
            // 
            this.z150ImageItem.Index = 7;
            this.z150ImageItem.Text = "150%";
            this.z150ImageItem.Click += new System.EventHandler(this.zoomItem_Click);
            // 
            // z200ImageItem
            // 
            this.z200ImageItem.Index = 8;
            this.z200ImageItem.Text = "200%";
            this.z200ImageItem.Click += new System.EventHandler(this.zoomItem_Click);
            // 
            // z400ImageItem
            // 
            this.z400ImageItem.Index = 9;
            this.z400ImageItem.Text = "400%";
            this.z400ImageItem.Click += new System.EventHandler(this.zoomItem_Click);
            // 
            // z500ImageItem
            // 
            this.z500ImageItem.Index = 10;
            this.z500ImageItem.Text = "500%";
            this.z500ImageItem.Click += new System.EventHandler(this.zoomItem_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 11;
            this.menuItem8.Text = "-";
            // 
            // zoomInImageItem
            // 
            this.zoomInImageItem.Index = 12;
            this.zoomInImageItem.Shortcut = System.Windows.Forms.Shortcut.Ctrl8;
            this.zoomInImageItem.Text = "Zoom &In";
            this.zoomInImageItem.Click += new System.EventHandler(this.zoomInImageItem_Click);
            // 
            // zoomOutImageItem
            // 
            this.zoomOutImageItem.Index = 13;
            this.zoomOutImageItem.Shortcut = System.Windows.Forms.Shortcut.Ctrl7;
            this.zoomOutImageItem.Text = "Zoom &Out";
            this.zoomOutImageItem.Click += new System.EventHandler(this.zoomOutImageItem_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 14;
            this.menuItem11.Text = "-";
            // 
            // zoomFitImageItem
            // 
            this.zoomFitImageItem.Index = 15;
            this.zoomFitImageItem.Shortcut = System.Windows.Forms.Shortcut.Ctrl9;
            this.zoomFitImageItem.Text = "Fit to screen";
            this.zoomFitImageItem.Click += new System.EventHandler(this.zoomFitImageItem_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 4;
            this.menuItem10.Text = "-";
            // 
            // flipImageItem
            // 
            this.flipImageItem.Index = 5;
            this.flipImageItem.Text = "&Flip";
            this.flipImageItem.Click += new System.EventHandler(this.flipImageItem_Click);
            // 
            // mirrorItem
            // 
            this.mirrorItem.Index = 6;
            this.mirrorItem.Text = "&Mirror";
            this.mirrorItem.Click += new System.EventHandler(this.mirrorItem_Click);
            // 
            // rotateImageItem
            // 
            this.rotateImageItem.Index = 7;
            this.rotateImageItem.Text = "&Rotate 90 degree";
            this.rotateImageItem.Click += new System.EventHandler(this.rotateImageItem_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 8;
            this.menuItem3.Text = "-";
            // 
            // cropImageItem
            // 
            this.cropImageItem.Index = 9;
            this.cropImageItem.Shortcut = System.Windows.Forms.Shortcut.CtrlE;
            this.cropImageItem.Text = "Cro&p";
            this.cropImageItem.Click += new System.EventHandler(this.cropImageItem_Click);
            // 
            // filtersItem
            // 
            this.filtersItem.Index = 1;
            this.filtersItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.colorFiltersItem,
            this.hslFiltersItem,
            this.ycbcrFiltersItem,
            this.binaryFiltersItem,
            this.morphologyFiltersItem,
            this.twosrcFiltersItem,
            this.convolutionFiltersItem,
            this.edgeFiltersItem,
            this.menuItem24,
            this.menuItem23,
            this.resizeFiltersItem,
            this.rotateFiltersItem,
            this.menuItem26,
            this.levelsFiltersItem,
            this.medianFiltersItem,
            this.gammaFiltersItem,
            this.fourierFiltersItem});
            this.filtersItem.MergeOrder = 1;
            this.filtersItem.Text = "Filters";
            // 
            // colorFiltersItem
            // 
            this.colorFiltersItem.Index = 0;
            this.colorFiltersItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.grayscaleColorFiltersItem,
            this.toRgbColorFiltersItem,
            this.menuItem16,
            this.menuItem13,
            this.colorFilteringColorFiltersItem,
            this.euclideanFilteringColorFiltersItem,
            this.channelsFilteringColorFiltersItem});
            this.colorFiltersItem.Text = "&Color";
            // 
            // grayscaleColorFiltersItem
            // 
            this.grayscaleColorFiltersItem.Index = 0;
            this.grayscaleColorFiltersItem.Text = "&Grayscale";
            this.grayscaleColorFiltersItem.Click += new System.EventHandler(this.grayscaleColorFiltersItem_Click);
            // 
            // toRgbColorFiltersItem
            // 
            this.toRgbColorFiltersItem.Index = 1;
            this.toRgbColorFiltersItem.Text = "Grayscale To RGB";
            this.toRgbColorFiltersItem.Click += new System.EventHandler(this.toRgbColorFiltersItem_Click);
            // 
            // menuItem16
            // 
            this.menuItem16.Index = 2;
            this.menuItem16.Text = "-";
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 3;
            this.menuItem13.Text = "Color Mode";
            this.menuItem13.Click += new System.EventHandler(this.menuItem13_Click);
            // 
            // colorFilteringColorFiltersItem
            // 
            this.colorFilteringColorFiltersItem.Index = 4;
            this.colorFilteringColorFiltersItem.Text = "Color Filtering";
            this.colorFilteringColorFiltersItem.Click += new System.EventHandler(this.colorFilteringColorFiltersItem_Click);
            // 
            // euclideanFilteringColorFiltersItem
            // 
            this.euclideanFilteringColorFiltersItem.Index = 5;
            this.euclideanFilteringColorFiltersItem.Text = "Euclidean Color Filtering";
            this.euclideanFilteringColorFiltersItem.Click += new System.EventHandler(this.euclideanFilteringColorFiltersItem_Click);
            // 
            // channelsFilteringColorFiltersItem
            // 
            this.channelsFilteringColorFiltersItem.Index = 6;
            this.channelsFilteringColorFiltersItem.Text = "Channels Filtering";
            this.channelsFilteringColorFiltersItem.Click += new System.EventHandler(this.channelsFilteringColorFiltersItem_Click);
            // 
            // hslFiltersItem
            // 
            this.hslFiltersItem.Index = 1;
            this.hslFiltersItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.brightnessHslFiltersItem,
            this.contrastHslFiltersItem,
            this.saturationHslFiltersItem,
            this.menuItem29,
            this.linearHslFiltersItem,
            this.filteringHslFiltersItem,
            this.hueHslFiltersItem});
            this.hslFiltersItem.Text = "&HSL Color space";
            // 
            // brightnessHslFiltersItem
            // 
            this.brightnessHslFiltersItem.Index = 0;
            this.brightnessHslFiltersItem.Text = "&Brightness";
            this.brightnessHslFiltersItem.Click += new System.EventHandler(this.brightnessHslFiltersItem_Click);
            // 
            // contrastHslFiltersItem
            // 
            this.contrastHslFiltersItem.Index = 1;
            this.contrastHslFiltersItem.Text = "&Contrast";
            this.contrastHslFiltersItem.Click += new System.EventHandler(this.contrastHslFiltersItem_Click);
            // 
            // saturationHslFiltersItem
            // 
            this.saturationHslFiltersItem.Index = 2;
            this.saturationHslFiltersItem.Text = "&Saturation";
            this.saturationHslFiltersItem.Click += new System.EventHandler(this.saturationHslFiltersItem_Click);
            // 
            // menuItem29
            // 
            this.menuItem29.Index = 3;
            this.menuItem29.Text = "-";
            // 
            // linearHslFiltersItem
            // 
            this.linearHslFiltersItem.Index = 4;
            this.linearHslFiltersItem.Text = "HSL Linear";
            this.linearHslFiltersItem.Click += new System.EventHandler(this.linearHslFiltersItem_Click);
            // 
            // filteringHslFiltersItem
            // 
            this.filteringHslFiltersItem.Index = 5;
            this.filteringHslFiltersItem.Text = "HSL &Filtering";
            this.filteringHslFiltersItem.Click += new System.EventHandler(this.filteringHslFiltersItem_Click);
            // 
            // hueHslFiltersItem
            // 
            this.hueHslFiltersItem.Index = 6;
            this.hueHslFiltersItem.Text = "&Hue Modifier";
            this.hueHslFiltersItem.Click += new System.EventHandler(this.hueHslFiltersItem_Click);
            // 
            // ycbcrFiltersItem
            // 
            this.ycbcrFiltersItem.Index = 2;
            this.ycbcrFiltersItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.linearYCbCrFiltersItem,
            this.filteringYCbCrFiltersItem,
            this.menuItem37,
            this.extracYFiltersItem,
            this.extracCbFiltersItem,
            this.extracCrFiltersItem,
            this.menuItem38,
            this.replaceYFiltersItem,
            this.replaceCbFiltersItem,
            this.replaceCrFiltersItem});
            this.ycbcrFiltersItem.Text = "&YCbCr Color space";
            // 
            // linearYCbCrFiltersItem
            // 
            this.linearYCbCrFiltersItem.Index = 0;
            this.linearYCbCrFiltersItem.Text = "YCbCr Linear";
            this.linearYCbCrFiltersItem.Click += new System.EventHandler(this.linearYCbCrFiltersItem_Click);
            // 
            // filteringYCbCrFiltersItem
            // 
            this.filteringYCbCrFiltersItem.Index = 1;
            this.filteringYCbCrFiltersItem.Text = "YCbCr Filtering";
            this.filteringYCbCrFiltersItem.Click += new System.EventHandler(this.filteringYCbCrFiltersItem_Click);
            // 
            // menuItem37
            // 
            this.menuItem37.Index = 2;
            this.menuItem37.Text = "-";
            // 
            // extracYFiltersItem
            // 
            this.extracYFiltersItem.Index = 3;
            this.extracYFiltersItem.Text = "Extract Y Channel";
            this.extracYFiltersItem.Click += new System.EventHandler(this.extracYFiltersItem_Click);
            // 
            // extracCbFiltersItem
            // 
            this.extracCbFiltersItem.Index = 4;
            this.extracCbFiltersItem.Text = "Extract Cb Channel";
            this.extracCbFiltersItem.Click += new System.EventHandler(this.extracCbFiltersItem_Click);
            // 
            // extracCrFiltersItem
            // 
            this.extracCrFiltersItem.Index = 5;
            this.extracCrFiltersItem.Text = "Extract Cr Channel";
            this.extracCrFiltersItem.Click += new System.EventHandler(this.extracCrFiltersItem_Click);
            // 
            // menuItem38
            // 
            this.menuItem38.Index = 6;
            this.menuItem38.Text = "-";
            // 
            // replaceYFiltersItem
            // 
            this.replaceYFiltersItem.Index = 7;
            this.replaceYFiltersItem.Text = "Replace Y Channel";
            this.replaceYFiltersItem.Click += new System.EventHandler(this.replaceYFiltersItem_Click);
            // 
            // replaceCbFiltersItem
            // 
            this.replaceCbFiltersItem.Index = 8;
            this.replaceCbFiltersItem.Text = "Replace Cb Channel";
            this.replaceCbFiltersItem.Click += new System.EventHandler(this.replaceCbFiltersItem_Click);
            // 
            // replaceCrFiltersItem
            // 
            this.replaceCrFiltersItem.Index = 9;
            this.replaceCrFiltersItem.Text = "Replace Cr Channel";
            this.replaceCrFiltersItem.Click += new System.EventHandler(this.replaceCrFiltersItem_Click);
            // 
            // binaryFiltersItem
            // 
            this.binaryFiltersItem.Index = 3;
            this.binaryFiltersItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2,
            this.thresholdBinaryFiltersItem});
            this.binaryFiltersItem.Text = "&Binarization";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.Text = "FastThreshold";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // thresholdBinaryFiltersItem
            // 
            this.thresholdBinaryFiltersItem.Index = 1;
            this.thresholdBinaryFiltersItem.Text = "ThresValue";
            this.thresholdBinaryFiltersItem.Click += new System.EventHandler(this.thresholdBinaryFiltersItem_Click);
            // 
            // morphologyFiltersItem
            // 
            this.morphologyFiltersItem.Index = 4;
            this.morphologyFiltersItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem9,
            this.customMorphologyFiltersItem,
            this.hitAndMissFiltersItem});
            this.morphologyFiltersItem.Text = "&Morphology";
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "FastMorph";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 1;
            this.menuItem9.Text = "-";
            // 
            // customMorphologyFiltersItem
            // 
            this.customMorphologyFiltersItem.Index = 2;
            this.customMorphologyFiltersItem.Text = "Cus&tom";
            this.customMorphologyFiltersItem.Click += new System.EventHandler(this.customMorphologyFiltersItem_Click);
            // 
            // hitAndMissFiltersItem
            // 
            this.hitAndMissFiltersItem.Index = 3;
            this.hitAndMissFiltersItem.Text = "Hit And Miss, Thickening, Thinning";
            this.hitAndMissFiltersItem.Click += new System.EventHandler(this.hitAndMissFiltersItem_Click);
            // 
            // twosrcFiltersItem
            // 
            this.twosrcFiltersItem.Index = 5;
            this.twosrcFiltersItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mergeTwosrcFiltersItem,
            this.intersectTwosrcFiltersItem,
            this.menuItem21,
            this.addTwosrcFiltersItem,
            this.subtractTwosrcFiltersItem,
            this.menuItem22,
            this.differenceTwosrcFiltersItem,
            this.moveTowardsTwosrcFiltersItem,
            this.morphTwosrcFiltersItem});
            this.twosrcFiltersItem.Text = "Two source filters";
            // 
            // mergeTwosrcFiltersItem
            // 
            this.mergeTwosrcFiltersItem.Index = 0;
            this.mergeTwosrcFiltersItem.Text = "&Merge";
            this.mergeTwosrcFiltersItem.Click += new System.EventHandler(this.mergeTwosrcFiltersItem_Click);
            // 
            // intersectTwosrcFiltersItem
            // 
            this.intersectTwosrcFiltersItem.Index = 1;
            this.intersectTwosrcFiltersItem.Text = "&Intersect";
            this.intersectTwosrcFiltersItem.Click += new System.EventHandler(this.intersectTwosrcFiltersItem_Click);
            // 
            // menuItem21
            // 
            this.menuItem21.Index = 2;
            this.menuItem21.Text = "-";
            // 
            // addTwosrcFiltersItem
            // 
            this.addTwosrcFiltersItem.Index = 3;
            this.addTwosrcFiltersItem.Text = "&Add";
            this.addTwosrcFiltersItem.Click += new System.EventHandler(this.addTwosrcFiltersItem_Click);
            // 
            // subtractTwosrcFiltersItem
            // 
            this.subtractTwosrcFiltersItem.Index = 4;
            this.subtractTwosrcFiltersItem.Text = "&Subtract";
            this.subtractTwosrcFiltersItem.Click += new System.EventHandler(this.subtractTwosrcFiltersItem_Click);
            // 
            // menuItem22
            // 
            this.menuItem22.Index = 5;
            this.menuItem22.Text = "-";
            // 
            // differenceTwosrcFiltersItem
            // 
            this.differenceTwosrcFiltersItem.Index = 6;
            this.differenceTwosrcFiltersItem.Text = "&Difference";
            this.differenceTwosrcFiltersItem.Click += new System.EventHandler(this.differenceTwosrcFiltersItem_Click);
            // 
            // moveTowardsTwosrcFiltersItem
            // 
            this.moveTowardsTwosrcFiltersItem.Index = 7;
            this.moveTowardsTwosrcFiltersItem.Text = "&Move Towards";
            this.moveTowardsTwosrcFiltersItem.Click += new System.EventHandler(this.moveTowardsTwosrcFiltersItem_Click);
            // 
            // morphTwosrcFiltersItem
            // 
            this.morphTwosrcFiltersItem.Index = 8;
            this.morphTwosrcFiltersItem.Text = "Mo&rph";
            this.morphTwosrcFiltersItem.Click += new System.EventHandler(this.morphTwosrcFiltersItem_Click);
            // 
            // convolutionFiltersItem
            // 
            this.convolutionFiltersItem.Index = 6;
            this.convolutionFiltersItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem15,
            this.menuItem12,
            this.customConvolutionFiltersItem,
            this.gaussianConvolutionFiltersItem,
            this.sharpenExConvolutionFiltersItem});
            this.convolutionFiltersItem.Text = "Co&nvolution && Correlation";
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 0;
            this.menuItem15.Text = "FastConvolution";
            this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click);
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 1;
            this.menuItem12.Text = "-";
            // 
            // customConvolutionFiltersItem
            // 
            this.customConvolutionFiltersItem.Index = 2;
            this.customConvolutionFiltersItem.Text = "&Custom";
            this.customConvolutionFiltersItem.Click += new System.EventHandler(this.customConvolutionFiltersItem_Click);
            // 
            // gaussianConvolutionFiltersItem
            // 
            this.gaussianConvolutionFiltersItem.Index = 3;
            this.gaussianConvolutionFiltersItem.Text = "&Gaussian";
            this.gaussianConvolutionFiltersItem.Click += new System.EventHandler(this.gaussianConvolutionFiltersItem_Click);
            // 
            // sharpenExConvolutionFiltersItem
            // 
            this.sharpenExConvolutionFiltersItem.Index = 4;
            this.sharpenExConvolutionFiltersItem.Text = "Sharpen Ex";
            this.sharpenExConvolutionFiltersItem.Click += new System.EventHandler(this.sharpenExConvolutionFiltersItem_Click);
            // 
            // edgeFiltersItem
            // 
            this.edgeFiltersItem.Index = 7;
            this.edgeFiltersItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.cannyEdgeFiltersItem,
            this.menuItem14});
            this.edgeFiltersItem.Text = "&Edge detectors";
            // 
            // cannyEdgeFiltersItem
            // 
            this.cannyEdgeFiltersItem.Index = 0;
            this.cannyEdgeFiltersItem.Text = "&Canny";
            this.cannyEdgeFiltersItem.Click += new System.EventHandler(this.cannyEdgeFiltersItem_Click);
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 1;
            this.menuItem14.Text = "FastEdge";
            this.menuItem14.Click += new System.EventHandler(this.menuItem14_Click);
            // 
            // menuItem24
            // 
            this.menuItem24.Index = 8;
            this.menuItem24.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.adaptiveSmoothingFiltersItem,
            this.conservativeSmoothingFiltersItem,
            this.menuItem34,
            this.perlinNoiseFiltersItem,
            this.oilPaintingFiltersItem,
            this.jitterFiltersItem,
            this.pixellateFiltersItem,
            this.simpleSkeletonizationFiltersItem,
            this.shrinkFiltersItem,
            this.menuItem30,
            this.labelingFiltersItem,
            this.blobExtractorFiltersItem});
            this.menuItem24.Text = "Other";
            // 
            // adaptiveSmoothingFiltersItem
            // 
            this.adaptiveSmoothingFiltersItem.Index = 0;
            this.adaptiveSmoothingFiltersItem.Text = "&Adaptive Smoothing";
            this.adaptiveSmoothingFiltersItem.Click += new System.EventHandler(this.adaptiveSmoothingFiltersItem_Click);
            // 
            // conservativeSmoothingFiltersItem
            // 
            this.conservativeSmoothingFiltersItem.Index = 1;
            this.conservativeSmoothingFiltersItem.Text = "&ConservativeSmoothing";
            this.conservativeSmoothingFiltersItem.Click += new System.EventHandler(this.conservativeSmoothingFiltersItem_Click);
            // 
            // menuItem34
            // 
            this.menuItem34.Index = 2;
            this.menuItem34.Text = "-";
            // 
            // perlinNoiseFiltersItem
            // 
            this.perlinNoiseFiltersItem.Index = 3;
            this.perlinNoiseFiltersItem.Text = "Perlin Noise";
            this.perlinNoiseFiltersItem.Click += new System.EventHandler(this.perlinNoiseFiltersItem_Click);
            // 
            // oilPaintingFiltersItem
            // 
            this.oilPaintingFiltersItem.Index = 4;
            this.oilPaintingFiltersItem.Text = "&Oil Painting";
            this.oilPaintingFiltersItem.Click += new System.EventHandler(this.oilPaintingFiltersItem_Click);
            // 
            // jitterFiltersItem
            // 
            this.jitterFiltersItem.Index = 5;
            this.jitterFiltersItem.Text = "&Jitter";
            this.jitterFiltersItem.Click += new System.EventHandler(this.jitterFiltersItem_Click);
            // 
            // pixellateFiltersItem
            // 
            this.pixellateFiltersItem.Index = 6;
            this.pixellateFiltersItem.Text = "&Pixellate";
            this.pixellateFiltersItem.Click += new System.EventHandler(this.pixellateFiltersItem_Click);
            // 
            // simpleSkeletonizationFiltersItem
            // 
            this.simpleSkeletonizationFiltersItem.Index = 7;
            this.simpleSkeletonizationFiltersItem.Text = "Simple &Skeletonization";
            this.simpleSkeletonizationFiltersItem.Click += new System.EventHandler(this.simpleSkeletonizationFiltersItem_Click);
            // 
            // shrinkFiltersItem
            // 
            this.shrinkFiltersItem.Index = 8;
            this.shrinkFiltersItem.Text = "Shrink";
            this.shrinkFiltersItem.Click += new System.EventHandler(this.shrinkFiltersItem_Click);
            // 
            // menuItem30
            // 
            this.menuItem30.Index = 9;
            this.menuItem30.Text = "-";
            // 
            // labelingFiltersItem
            // 
            this.labelingFiltersItem.Index = 10;
            this.labelingFiltersItem.Text = "Connected Components Labeling";
            this.labelingFiltersItem.Click += new System.EventHandler(this.labelingFiltersItem_Click);
            // 
            // blobExtractorFiltersItem
            // 
            this.blobExtractorFiltersItem.Index = 11;
            this.blobExtractorFiltersItem.Text = "&Blob Extractor";
            this.blobExtractorFiltersItem.Click += new System.EventHandler(this.blobExtractorFiltersItem_Click);
            // 
            // menuItem23
            // 
            this.menuItem23.Index = 9;
            this.menuItem23.Text = "-";
            // 
            // resizeFiltersItem
            // 
            this.resizeFiltersItem.Index = 10;
            this.resizeFiltersItem.Text = "&Resize";
            this.resizeFiltersItem.Click += new System.EventHandler(this.resizeFiltersItem_Click);
            // 
            // rotateFiltersItem
            // 
            this.rotateFiltersItem.Index = 11;
            this.rotateFiltersItem.Text = "Ro&tate";
            this.rotateFiltersItem.Click += new System.EventHandler(this.rotateFiltersItem_Click);
            // 
            // menuItem26
            // 
            this.menuItem26.Index = 12;
            this.menuItem26.Text = "-";
            // 
            // levelsFiltersItem
            // 
            this.levelsFiltersItem.Index = 13;
            this.levelsFiltersItem.Shortcut = System.Windows.Forms.Shortcut.CtrlL;
            this.levelsFiltersItem.Text = "&Levels";
            this.levelsFiltersItem.Click += new System.EventHandler(this.levelsFiltersItem_Click);
            // 
            // medianFiltersItem
            // 
            this.medianFiltersItem.Index = 14;
            this.medianFiltersItem.Text = "Me&dian";
            this.medianFiltersItem.Click += new System.EventHandler(this.medianFiltersItem_Click);
            // 
            // gammaFiltersItem
            // 
            this.gammaFiltersItem.Index = 15;
            this.gammaFiltersItem.Text = "&Gamma Correction";
            this.gammaFiltersItem.Click += new System.EventHandler(this.gammaFiltersItem_Click);
            // 
            // fourierFiltersItem
            // 
            this.fourierFiltersItem.Index = 16;
            this.fourierFiltersItem.Text = "&Fourier Transformation";
            this.fourierFiltersItem.Click += new System.EventHandler(this.fourierFiltersItem_Click);
            // 
            // ImageDoc
            // 
            this.AllowedStates = WeifenLuo.WinFormsUI.ContentStates.Document;
            this.AutoScaleBaseSize = new System.Drawing.Size(13, 28);
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(528, 417);
            this.Menu = this.mainMenu;
            this.Name = "ImageDoc";
            this.Text = "Image";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImageDoc_MouseDown);
            this.MouseLeave += new System.EventHandler(this.ImageDoc_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ImageDoc_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImageDoc_MouseUp);
            this.ResumeLayout(false);

        }
        #endregion

        // Init the document
        private void Init( )
        {
            // init components
            InitializeComponent( );
            //colorFiltersItem.Text = "ÑÕÉ«";

            // form style
            SetStyle( ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw, true );

            // init scroll bars
            this.AutoScroll = true;

            UpdateSize( );
        }

        // Execute command
        public void ExecuteCommand( ImageDocCommands cmd )
        {
            switch ( cmd )
            {
                case ImageDocCommands.Clone:		// clone the image
                    Clone( );
                    break;
                case ImageDocCommands.Crop:			// crop the image
                    Crop( );
                    break;
                case ImageDocCommands.ZoomIn:		// zoom in
                    ZoomIn( );
                    break;
                case ImageDocCommands.ZoomOut:		// zoom out
                    ZoomOut( );
                    break;
                case ImageDocCommands.ZoomOriginal:	// original size
                    zoom = 1;
                    UpdateZoom( );
                    break;
                case ImageDocCommands.FitToSize:	// fit to screen
                    FitToScreen( );
                    break;
                case ImageDocCommands.Levels:		// levels
                    Levels( );
                    break;
                case ImageDocCommands.Grayscale:	// grayscale
                    Grayscale( );
                    break;
                case ImageDocCommands.Threshold:	// threshold
                    Threshold( );
                    break;
                case ImageDocCommands.Morphology:	// morphology
                    Morphology( );
                    break;
                case ImageDocCommands.Convolution:	// convolution
                    Convolution( );
                    break;
                case ImageDocCommands.Resize:		// resize the image
                    ResizeImage( );
                    break;
                case ImageDocCommands.Rotate:		// rotate the image
                    RotateImage( );
                    break;
                case ImageDocCommands.Brightness:	// adjust brightness
                    Brightness( );
                    break;
                case ImageDocCommands.Contrast:		// modify contrast
                    Contrast( );
                    break;
                case ImageDocCommands.Saturation:	// adjust saturation
                    Saturation( );
                    break;
                case ImageDocCommands.Fourier:		// fourier transformation
                    ForwardFourierTransformation( );
                    break;
            }
        }

        // Update document and notify client about changes
        private void UpdateNewImage( )
        {
            // update size
            UpdateSize( );
            // repaint
            Invalidate( );

            // notify host
            if ( DocumentChanged != null )
                DocumentChanged( this, null );
        }

        // Reload image from file
        public void Reload( )
        {
            if ( fileName != null )
            {
                try
                {
                    // load image
                    Bitmap newImage = (Bitmap) Bitmap.FromFile( fileName );

                    // Release current image
                    image.Dispose( );
                    // set document image to just loaded
                    image = newImage;

                    // format image
                    AForge.Imaging.Image.FormatImage( ref image );
                }
                catch ( Exception )
                {
                    throw new ApplicationException( "Failed reloading image" );
                }

                // update
                UpdateNewImage( );
            }
        }

        // Center image in the document
        public void Center( )
        {
            Rectangle rc = ClientRectangle;
            Point p = this.AutoScrollPosition;
            int width = (int) ( this.width * zoom );
            int height = (int) ( this.height * zoom );

            if ( rc.Width < width )
                p.X = ( width - rc.Width ) >> 1;
            if ( rc.Height < height )
                p.Y = ( height - rc.Height ) >> 1;

            this.AutoScrollPosition = p;
        }

        // Update document size 
        private void UpdateSize( )
        {
            // image dimension
            width = image.Width;
            height = image.Height;

            // scroll bar size
            this.AutoScrollMinSize = new Size( (int) ( width * zoom ), (int) ( height * zoom ) );
        }

        // Paint image
        protected override void OnPaint( PaintEventArgs e )
        {
            if ( image != null )
            {
                Graphics g = e.Graphics;
                Rectangle rc = ClientRectangle;
                Pen pen = new Pen( Color.FromArgb( 0, 0, 0 ) );

                int width = (int) ( this.width * zoom );
                int height = (int) ( this.height * zoom );
                int x = ( rc.Width < width ) ? this.AutoScrollPosition.X : ( rc.Width - width ) / 2;
                int y = ( rc.Height < height ) ? this.AutoScrollPosition.Y : ( rc.Height - height ) / 2;

                // draw rectangle around the image
                g.DrawRectangle( pen, x - 1, y - 1, width + 1, height + 1 );

                // set nearest neighbor interpolation to avoid image smoothing
                g.InterpolationMode = InterpolationMode.NearestNeighbor;

                // draw image
                g.DrawImage( image, x, y, width, height );

                pen.Dispose( );
            }
        }

        // Mouse click
        protected override void OnClick( EventArgs e )
        {
            Focus( );
        }

        // Apply filter on the image
        private void ApplyFilter( IFilter filter )
        {
            try
            {
                // set wait cursor
                this.Cursor = Cursors.WaitCursor;

                // apply filter to the image
                Bitmap newImage = filter.Apply( image );

                if ( host.CreateNewDocumentOnChange )
                {
                    // open new image in new document
                    host.NewDocument( newImage );
                }
                else
                {
                    if ( host.RememberOnChange )
                    {
                        // backup current image
                        if ( backup != null )
                            backup.Dispose( );

                        backup = image;
                    }
                    else
                    {
                        // release current image
                        image.Dispose( );
                    }

                    image = newImage;

                    // update
                    UpdateNewImage( );
                }
            }
            catch ( ArgumentException )
            {
                MessageBox.Show( "Selected filter can not be applied to the image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
            finally
            {
                // restore cursor
                this.Cursor = Cursors.Default;
            }
        }

        // on "Image" item popup
        private void imageItem_Popup( object sender, System.EventArgs e )
        {
            this.backImageItem.Enabled = ( backup != null );
            this.cropImageItem.Checked = cropping;
        }

        // Restore image to previous
        private void backImageItem_Click( object sender, System.EventArgs e )
        {
            if ( backup != null )
            {
                // release current image
                image.Dispose( );
                // restore
                image = backup;
                backup = null;

                // update
                UpdateNewImage( );
            }
        }

        // Clone the image
        private void Clone( )
        {
            if ( host != null )
            {
                Bitmap clone = AForge.Imaging.Image.Clone( image );

                if ( !host.NewDocument( clone ) )
                {
                    clone.Dispose( );
                }
            }
        }

        // On "Image->Clone" item click
        private void cloneImageItem_Click( object sender, System.EventArgs e )
        {
            Clone( );
        }

        // Update zoom factor
        private void UpdateZoom( )
        {
            this.AutoScrollMinSize = new Size( (int) ( width * zoom ), (int) ( height * zoom ) );
            this.Invalidate( );

            // notify host
            if ( ZoomChanged != null )
                ZoomChanged( this, null );
        }

        // Zoom image
        private void zoomItem_Click( object sender, System.EventArgs e )
        {
            // get menu item text
            String t = ( (MenuItem) sender ).Text;
            // parse it`s value
            int i = int.Parse( t.Remove( t.Length - 1, 1 ) );
            // calc zoom factor
            zoom = (float) i / 100;

            UpdateZoom( );
        }

        // Zoom In image
        private void ZoomIn( )
        {
            float z = zoom * 1.5f;

            if ( z <= 10 )
            {
                zoom = z;
                UpdateZoom( );
            }
        }

        // On "Image->Zoom->Zoom In" item click
        private void zoomInImageItem_Click( object sender, System.EventArgs e )
        {
            ZoomIn( );
        }

        // Zoom Out image
        private void ZoomOut( )
        {
            float z = zoom / 1.5f;

            if ( z >= 0.05 )
            {
                zoom = z;
                UpdateZoom( );
            }
        }

        // On "Image->Zoom->Zoom out" item click
        private void zoomOutImageItem_Click( object sender, System.EventArgs e )
        {
            ZoomOut( );
        }

        // Fit to size
        public void FitToScreen( )
        {
            Rectangle rc = ClientRectangle;

            zoom = Math.Min( (float) rc.Width / ( width + 2 ), (float) rc.Height / ( height + 2 ) );

            UpdateZoom( );
        }

        // On "Image->Zoom->Fit To Screen" item click
        private void zoomFitImageItem_Click( object sender, System.EventArgs e )
        {
            FitToScreen( );
        }

        // Flip image
        private void flipImageItem_Click( object sender, System.EventArgs e )
        {
            image.RotateFlip( RotateFlipType.RotateNoneFlipY );

            Invalidate( );
        }

        // Mirror image
        private void mirrorItem_Click( object sender, System.EventArgs e )
        {
            image.RotateFlip( RotateFlipType.RotateNoneFlipX );

            Invalidate( );
        }

        // Rotate image 90 degree
        private void rotateImageItem_Click( object sender, System.EventArgs e )
        {
            image.RotateFlip( RotateFlipType.Rotate90FlipNone );

            // update
            UpdateNewImage( );
        }

        // Grayscale image
        private void Grayscale( )
        {
            if ( image.PixelFormat == PixelFormat.Format8bppIndexed )
            {
                MessageBox.Show( "The image is already grayscale", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }
            ApplyFilter( new GrayscaleBT709( ) );
        }

        // On "Filter->Color->Grayscale"
        private void grayscaleColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            Grayscale( );
        }

        // Converts grayscale image to RGB
        private void toRgbColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            if ( image.PixelFormat == PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "The image is already RGB", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }
            ApplyFilter( new GrayscaleToRGB( ) );
        }


        // Color filtering
        private void colorFilteringColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            // check pixel format
            if ( image.PixelFormat != PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "Color filtering can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            ColorFilteringForm form = new ColorFilteringForm( );
            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Euclidean color filtering
        private void euclideanFilteringColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            // check pixel format
            if ( image.PixelFormat != PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "Euclidean color filtering can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            EuclideanColorFilteringForm form = new EuclideanColorFilteringForm( );
            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Channels filtering
        private void channelsFilteringColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            // check pixel format
            if ( image.PixelFormat != PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "Channels filtering can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            ChannelFilteringForm form = new ChannelFilteringForm( );
            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }


        // Adjust brighness using HSL
        private void Brightness( )
        {
            if ( image.PixelFormat != PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "Brightness filter using HSL color space is available for color images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            BrightnessForm form = new BrightnessForm( );
            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // On "Filters->HSL Color space->Brighness" menu item click
        private void brightnessHslFiltersItem_Click( object sender, System.EventArgs e )
        {
            Brightness( );
        }

        // Modify contrast
        private void Contrast( )
        {
            if ( image.PixelFormat != PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "Contrast filter using HSL color space is available for color images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            ContrastForm form = new ContrastForm( );
            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // On "Filters->HSL Color space->Contrast" menu item click
        private void contrastHslFiltersItem_Click( object sender, System.EventArgs e )
        {
            Contrast( );
        }

        // Adjust saturation using HSL
        private void Saturation( )
        {
            if ( image.PixelFormat != PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "Saturation filter using HSL color space is available for color images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            SaturationForm form = new SaturationForm( );
            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // On "Filters->HSL Color space->Saturation" menu item click
        private void saturationHslFiltersItem_Click( object sender, System.EventArgs e )
        {
            Saturation( );
        }

        // HSL linear correction
        private void linearHslFiltersItem_Click( object sender, System.EventArgs e )
        {
            if ( image.PixelFormat != PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "HSL linear correction is available for color images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            HSLLinearForm form = new HSLLinearForm( new ImageStatisticsHSL( image ) );
            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // HSL filtering
        private void filteringHslFiltersItem_Click( object sender, System.EventArgs e )
        {
            if ( image.PixelFormat != PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "HSL filtering is available for color images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            HSLFilteringForm form = new HSLFilteringForm( );
            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Hue modifier
        private void hueHslFiltersItem_Click( object sender, System.EventArgs e )
        {
            if ( image.PixelFormat != PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "Hue modifier is available for color images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            HueModifierForm form = new HueModifierForm( );
            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Linear correction of YCbCr channels
        private void linearYCbCrFiltersItem_Click( object sender, System.EventArgs e )
        {
            if ( image.PixelFormat != PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "YCbCr linear correction is available for color images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            YCbCrLinearForm form = new YCbCrLinearForm( new ImageStatisticsYCbCr( image ) );
            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Filtering of YCbCr channels
        private void filteringYCbCrFiltersItem_Click( object sender, System.EventArgs e )
        {
            if ( image.PixelFormat != PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "YCbCr filtering is available for color images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            YCbCrFilteringForm form = new YCbCrFilteringForm( );
            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Extract Y channel of YCbCr color space
        private void extracYFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new YCbCrExtractChannel( YCbCr.YIndex ) );
        }

        // Extract Cb channel of YCbCr color space
        private void extracCbFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new YCbCrExtractChannel( YCbCr.CbIndex ) );
        }

        // Extract Cr channel of YCbCr color space
        private void extracCrFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new YCbCrExtractChannel( YCbCr.CrIndex ) );
        }

        // Replace Y channel of YCbCr color space
        private void replaceYFiltersItem_Click( object sender, System.EventArgs e )
        {
            // check pixel format
            if ( image.PixelFormat != PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "Channels replacement can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            Bitmap channelImage = host.GetImage( this, "Select an image which will replace the Y channel in the current image", new Size( width, height ), PixelFormat.Format8bppIndexed );

            if ( channelImage != null )
                ApplyFilter( new YCbCrReplaceChannel( YCbCr.YIndex, channelImage ) );
        }

        // Replace Cb channel of YCbCr color space
        private void replaceCbFiltersItem_Click( object sender, System.EventArgs e )
        {
            // check pixel format
            if ( image.PixelFormat != PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "Channels replacement can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            Bitmap channelImage = host.GetImage( this, "Select an image which will replace the Cb channel in the current image", new Size( width, height ), PixelFormat.Format8bppIndexed );

            if ( channelImage != null )
                ApplyFilter( new YCbCrReplaceChannel( YCbCr.CbIndex, channelImage ) );
        }

        // Replace Cr channel of YCbCr color space
        private void replaceCrFiltersItem_Click( object sender, System.EventArgs e )
        {
            // check pixel format
            if ( image.PixelFormat != PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "Channels replacement can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            Bitmap channelImage = host.GetImage( this, "Select an image which will replace the Cr channel in the current image", new Size( width, height ), PixelFormat.Format8bppIndexed );

            if ( channelImage != null )
                ApplyFilter( new YCbCrReplaceChannel( YCbCr.CrIndex, channelImage ) );
        }

        // Threshold binarization
        private void Threshold( )
        {
            ThresholdForm form = new ThresholdForm( );

            // set image to preview
            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // On "Filters->Binarization->Threshold" menu item click
        private void thresholdBinaryFiltersItem_Click( object sender, System.EventArgs e )
        {
            Threshold( );
        }

        // Custom morphology operator
        private void Morphology( )
        {
            if ( image.PixelFormat != PixelFormat.Format8bppIndexed )
            {
                MessageBox.Show( "Mathematical morpholgy filters can by applied to grayscale image only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            MathMorphologyForm form = new MathMorphologyForm( MathMorphologyForm.FilterTypes.Simple );
            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // On "Filters->Morphology->Custom" menu item click
        private void customMorphologyFiltersItem_Click( object sender, System.EventArgs e )
        {
            Morphology( );
        }

        // Hit & Miss mathematical morphology operator
        private void hitAndMissFiltersItem_Click( object sender, System.EventArgs e )
        {
            if ( image.PixelFormat != PixelFormat.Format8bppIndexed )
            {
                MessageBox.Show( "Hit & Miss morpholgy filters can by applied to binary image only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            MathMorphologyForm form = new MathMorphologyForm( MathMorphologyForm.FilterTypes.HitAndMiss );
            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }


        // Gaussian smoothing
        private void gaussianConvolutionFiltersItem_Click( object sender, System.EventArgs e )
        {
            GaussianForm form = new GaussianForm( );

            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Extended sharpening
        private void sharpenExConvolutionFiltersItem_Click( object sender, System.EventArgs e )
        {
            SharpenExForm form = new SharpenExForm( );

            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }



        // Custom convolution filter
        private void Convolution( )
        {
            ConvolutionForm form = new ConvolutionForm( );

            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // On "Filters->Convolution & Correlation->Custom" menu item click
        private void customConvolutionFiltersItem_Click( object sender, System.EventArgs e )
        {
            Convolution( );
        }

        // Merge two images
        private void mergeTwosrcFiltersItem_Click( object sender, System.EventArgs e )
        {
            Bitmap overlayImage = host.GetImage( this, "Select an image to merge with the curren image", new Size( -1, -1 ), image.PixelFormat );

            if ( overlayImage != null )
                ApplyFilter( new Merge( overlayImage ) );
        }

        // Intersect
        private void intersectTwosrcFiltersItem_Click( object sender, System.EventArgs e )
        {
            Bitmap overlayImage = host.GetImage( this, "Select an image to intersect with the curren image", new Size( -1, -1 ), image.PixelFormat );

            if ( overlayImage != null )
                ApplyFilter( new Intersect( overlayImage ) );
        }

        // Add
        private void addTwosrcFiltersItem_Click( object sender, System.EventArgs e )
        {
            Bitmap overlayImage = host.GetImage( this, "Select an image to add to the curren image", new Size( -1, -1 ), image.PixelFormat );

            if ( overlayImage != null )
                ApplyFilter( new Add( overlayImage ) );
        }

        // Subtract
        private void subtractTwosrcFiltersItem_Click( object sender, System.EventArgs e )
        {
            Bitmap overlayImage = host.GetImage( this, "Select an image to subtract from the curren image", new Size( -1, -1 ), image.PixelFormat );

            if ( overlayImage != null )
                ApplyFilter( new Subtract( overlayImage ) );
        }

        // Difference
        private void differenceTwosrcFiltersItem_Click( object sender, System.EventArgs e )
        {
            Bitmap overlayImage = host.GetImage( this, "Select an image to get difference with the curren image", new Size( width, height ), image.PixelFormat );

            if ( overlayImage != null )
                ApplyFilter( new Difference( overlayImage ) );
        }

        // Move towards
        private void moveTowardsTwosrcFiltersItem_Click( object sender, System.EventArgs e )
        {
            Bitmap overlayImage = host.GetImage( this, "Select an image to which the curren image will be moved", new Size( width, height ), image.PixelFormat );

            if ( overlayImage != null )
                ApplyFilter( new MoveTowards( overlayImage, 10 ) );
        }

        // Morph an image
        private void morphTwosrcFiltersItem_Click( object sender, System.EventArgs e )
        {
            // get overlay image
            Bitmap overlayImage = host.GetImage( this, "Select an image to which the curren image will be morphed", new Size( width, height ), image.PixelFormat );

            if ( overlayImage != null )
            {
                // show filter setting dialog
                MorphForm form = new MorphForm( overlayImage );

                form.Image = image;

                // get filter settings
                if ( form.ShowDialog( ) == DialogResult.OK )
                {
                    ApplyFilter( form.Filter );
                }
            }
        }



        // Canny edge detector
        private void cannyEdgeFiltersItem_Click( object sender, System.EventArgs e )
        {
            CannyDetectorForm form = new CannyDetectorForm( );

            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Adaptive smoothing
        private void adaptiveSmoothingFiltersItem_Click( object sender, System.EventArgs e )
        {
            AdaptiveSmoothForm form = new AdaptiveSmoothForm( );

            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Conservative smoothing
        private void conservativeSmoothingFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new ConservativeSmoothing( ) );
        }

        // Perlin noise effects
        private void perlinNoiseFiltersItem_Click( object sender, System.EventArgs e )
        {
            PerlinNoiseForm form = new PerlinNoiseForm( );

            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Oil painting filter
        private void oilPaintingFiltersItem_Click( object sender, System.EventArgs e )
        {
            OilPaintingForm form = new OilPaintingForm( );

            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Random jitter filter
        private void jitterFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Jitter( 1 ) );
        }

        // Pixellate filter
        private void pixellateFiltersItem_Click( object sender, System.EventArgs e )
        {
            PixelateForm form = new PixelateForm( );

            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Simple skeletonization
        private void simpleSkeletonizationFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new SimpleSkeletonization( ) );
        }

        // Shrink the image, removing specified color from it`s borders
        private void shrinkFiltersItem_Click( object sender, System.EventArgs e )
        {
            ShrinkForm form = new ShrinkForm( );

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Conected components labeling
        private void labelingFiltersItem_Click( object sender, System.EventArgs e )
        {
            if ( image.PixelFormat != PixelFormat.Format8bppIndexed )
            {
                MessageBox.Show( "Connected components labeling can be applied to binary images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            ApplyFilter( new ConnectedComponentsLabeling( ) );
        }

        // Extract separate blobs
        private void blobExtractorFiltersItem_Click( object sender, System.EventArgs e )
        {
            if ( image.PixelFormat != PixelFormat.Format8bppIndexed )
            {
                MessageBox.Show( "Blob extractor can be applied to binary images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            BlobCounter blobCounter = new BlobCounter( image );
            Blob[] blobs = blobCounter.GetObjects( image );

            foreach ( Blob blob in blobs )
            {
                host.NewDocument( blob.Image );
            }
        }

        // Resize the image
        private void ResizeImage( )
        {
            ResizeForm form = new ResizeForm( );

            form.OriginalSize = new Size( width, height );

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // On "Filters->Resize" menu item click
        private void resizeFiltersItem_Click( object sender, System.EventArgs e )
        {
            ResizeImage( );
        }

        // Rotate the image
        private void RotateImage( )
        {
            RotateForm form = new RotateForm( );

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // On "Filters->Rotate" menu item click
        private void rotateFiltersItem_Click( object sender, System.EventArgs e )
        {
            RotateImage( );
        }

        // Levels
        private void Levels( )
        {
            LevelsLinearForm form = new LevelsLinearForm( new ImageStatistics( image ) );

            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // On "Filter->Levels" menu item click
        private void levelsFiltersItem_Click( object sender, System.EventArgs e )
        {
            Levels( );
        }

        // Median filter
        private void medianFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Median( ) );
        }

        // Gamma correction
        private void gammaFiltersItem_Click( object sender, System.EventArgs e )
        {
            GammaForm form = new GammaForm( );

            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Fourier transformation
        private void ForwardFourierTransformation( )
        {
            System.Diagnostics.Debug.WriteLine( (int) FourierTransform.Direction.Forward );
            System.Diagnostics.Debug.WriteLine( (int) FourierTransform.Direction.Backward );

            if ( ( !AForge.Math.Tools.IsPowerOf2( width ) ) ||
                ( !AForge.Math.Tools.IsPowerOf2( height ) ) )
            {
                MessageBox.Show( "Fourier trasformation can be applied to an image with width and height of power of 2", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            ComplexImage cImage = ComplexImage.FromBitmap( image );

            cImage.ForwardFourierTransform( );
            host.NewDocument( cImage );
        }

        // On "Filters->Fourier Transformation" click
        private void fourierFiltersItem_Click( object sender, System.EventArgs e )
        {
            ForwardFourierTransformation( );
        }

        // Calculate image and screen coordinates of the point
        private void GetImageAndScreenPoints( Point point, out Point imgPoint, out Point screenPoint )
        {
            Rectangle rc = this.ClientRectangle;
            int width = (int) ( this.width * zoom );
            int height = (int) ( this.height * zoom );
            int x = ( rc.Width < width ) ? this.AutoScrollPosition.X : ( rc.Width - width ) / 2;
            int y = ( rc.Height < height ) ? this.AutoScrollPosition.Y : ( rc.Height - height ) / 2;

            int ix = Math.Min( Math.Max( x, point.X ), x + width - 1 );
            int iy = Math.Min( Math.Max( y, point.Y ), y + height - 1 );

            ix = (int) ( ( ix - x ) / zoom );
            iy = (int) ( ( iy - y ) / zoom );

            // image point
            imgPoint = new Point( ix, iy );
            // screen point
            screenPoint = this.PointToScreen( new Point( (int) ( ix * zoom + x ), (int) ( iy * zoom + y ) ) );
        }

        // Normalize points so, that pt1 becomes top-left point of rectangle
        // and pt2 becomes right-bottom
        private void NormalizePoints( ref Point pt1, ref Point pt2 )
        {
            Point t1 = pt1;
            Point t2 = pt2;

            pt1.X = Math.Min( t1.X, t2.X );
            pt1.Y = Math.Min( t1.Y, t2.Y );
            pt2.X = Math.Max( t1.X, t2.X );
            pt2.Y = Math.Max( t1.Y, t2.Y );
        }

        // Draw selection rectangle
        private void DrawSelectionFrame( Graphics g )
        {
            Point sp = startW;
            Point ep = endW;

            // Normalize points
            NormalizePoints( ref sp, ref ep );
            // Draw reversible frame
            ControlPaint.DrawReversibleFrame( new Rectangle( sp.X, sp.Y, ep.X - sp.X + 1, ep.Y - sp.Y + 1 ), Color.White, FrameStyle.Dashed );
        }

        // Crop the image
        private void Crop( )
        {
            if ( !cropping )
            {
                // turn on
                cropping = true;
                this.Cursor = Cursors.Cross;

            }
            else
            {
                // turn off
                cropping = false;
                this.Cursor = Cursors.Default;
            }
        }

        // On "Image->Crop" - turn on/off cropping mode
        private void cropImageItem_Click( object sender, System.EventArgs e )
        {
            Crop( );
        }

        // On mouse down
        private void ImageDoc_MouseDown( object sender, MouseEventArgs e )
        {
            if ( e.Button == MouseButtons.Right )
            {
                // turn off cropping mode
                if ( !dragging )
                {
                    cropping = false;
                    this.Cursor = Cursors.Default;
                }
            }
            else if ( e.Button == MouseButtons.Left )
            {
                if ( cropping )
                {
                    // start dragging
                    dragging = true;
                    // set mouse capture
                    this.Capture = true;

                    // get selection start point
                    GetImageAndScreenPoints( new Point( e.X, e.Y ), out start, out startW );

                    // end point is the same as start
                    end = start;
                    endW = startW;

                    // draw frame
                    Graphics g = this.CreateGraphics( );
                    DrawSelectionFrame( g );
                    g.Dispose( );
                }
            }
        }

        private void menuItem13_Click(object sender, EventArgs e)
        {
            ColorChanged form = new ColorChanged();

            if (form.ShowDialog() == DialogResult.OK)
            {
                ApplyFilter(form.Filter);
            }
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            MorphologyChanged form = new MorphologyChanged();
            if (form.ShowDialog() == DialogResult.OK)
            {
                ApplyFilter(form.Filter);
            }
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            ThresholdChanged form = new ThresholdChanged();
            if (form.ShowDialog() == DialogResult.OK)
            {
                ApplyFilter(form.Filter);
            }
        }

        private void menuItem14_Click(object sender, EventArgs e)
        {
            EdgeChanged form = new EdgeChanged();
            if (form.ShowDialog() == DialogResult.OK)
            {
                ApplyFilter(form.Filter);
            }
        }

        private void menuItem15_Click(object sender, EventArgs e)
        {
            ConvolutionChanged form = new ConvolutionChanged();
            if (form.ShowDialog() == DialogResult.OK)
            {
                ApplyFilter(form.Filter);
            }
        }

        // On mouse up
        private void ImageDoc_MouseUp( object sender, MouseEventArgs e )
        {
            if ( dragging )
            {
                // stop dragging and cropping
                dragging = cropping = false;
                // release capture
                this.Capture = false;
                // set default mouse pointer
                this.Cursor = Cursors.Default;

                // erase frame
                Graphics g = this.CreateGraphics( );
                DrawSelectionFrame( g );
                g.Dispose( );

                // normalize start and end points
                NormalizePoints( ref start, ref end );

                // crop tge image
                ApplyFilter( new Crop( new Rectangle( start.X, start.Y, end.X - start.X + 1, end.Y - start.Y + 1 ) ) );
            }
        }

        // On mouse move
        private void ImageDoc_MouseMove( object sender, MouseEventArgs e )
        {
            if ( dragging )
            {

                Graphics g = this.CreateGraphics( );

                // erase frame
                DrawSelectionFrame( g );

                // get selection end point
                GetImageAndScreenPoints( new Point( e.X, e.Y ), out end, out endW );

                // draw frame
                DrawSelectionFrame( g );

                g.Dispose( );

                if ( SelectionChanged != null )
                {
                    Point sp = start;
                    Point ep = end;

                    // normalize start and end points
                    NormalizePoints( ref sp, ref ep );

                    SelectionChanged( this, new SelectionEventArgs(
                        sp, new Size( ep.X - sp.X + 1, ep.Y - sp.Y + 1 ) ) );
                }
            }
            else
            {
                if ( MouseImagePosition != null )
                {
                    Rectangle rc = this.ClientRectangle;
                    int width = (int) ( this.width * zoom );
                    int height = (int) ( this.height * zoom );
                    int x = ( rc.Width < width ) ? this.AutoScrollPosition.X : ( rc.Width - width ) / 2;
                    int y = ( rc.Height < height ) ? this.AutoScrollPosition.Y : ( rc.Height - height ) / 2;

                    if ( ( e.X >= x ) && ( e.Y >= y ) &&
                        ( e.X < x + width ) && ( e.Y < y + height ) )
                    {
                        // mouse is over the image
                        MouseImagePosition( this, new SelectionEventArgs(
                            new Point( (int) ( ( e.X - x ) / zoom ), (int) ( ( e.Y - y ) / zoom ) ) ) );
                    }
                    else
                    {
                        // mouse is outside image region
                        MouseImagePosition( this, new SelectionEventArgs( new Point( -1, -1 ) ) );
                    }
                }
            }
        }

        // On mouse leave
        private void ImageDoc_MouseLeave( object sender, System.EventArgs e )
        {
            if ( ( !dragging ) && ( MouseImagePosition != null ) )
            {
                MouseImagePosition( this, new SelectionEventArgs( new Point( -1, -1 ) ) );
            }
        }
    }

    // Selection arguments
    public class SelectionEventArgs : EventArgs
    {
        private Point location;
        private Size size;

        // Constructors
        public SelectionEventArgs( Point location )
        {
            this.location = location;
        }
        public SelectionEventArgs( Point location, Size size )
        {
            this.location = location;
            this.size = size;
        }

        // Location property
        public Point Location
        {
            get { return location; }
        }
        // Size property
        public Size Size
        {
            get { return size; }
        }
    }

    // Commands
    public enum ImageDocCommands
    {
        Clone,
        Crop,
        ZoomIn,
        ZoomOut,
        ZoomOriginal,
        FitToSize,
        Levels,
        Grayscale,
        Threshold,
        Morphology,
        Convolution,
        Resize,
        Rotate,
        Brightness,
        Contrast,
        Saturation,
        Fourier
    }
}
