// Image Processing Lab
//
// Copyright ?Andrew Kirillov, 2005
// andrew.kirillov@gmail.com
//

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI;

using AForge.Math;
using AForge.Imaging;

namespace IPLab
{
    /// <summary>
    /// Summary description for HistogramWindow.
    /// </summary>
    public class HistogramWindow : Content
    {
        private static Color[] colors = new Color[] {
			Color.FromArgb(192, 0, 0),
			Color.FromArgb(0, 192, 0),
			Color.FromArgb(0, 0, 192),
			Color.FromArgb(128, 128, 128),
		};

        private int currentImageHash = 0;

        private ImageStatistics stat;
        private IPLab.Histogram histogram;
        private AForge.Math.Histogram activeHistogram = null;
        private Label label1;
        private ComboBox channelCombo;
        private Label label2;
        private Label meanLabel;
        private Label label3;
        private Label stdDevLabel;
        private Label label4;
        private Label medianLabel;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label levelLabel;
        private Label countLabel;
        private Label percentileLabel;
        private Label label8;
        private Label label9;
        private Label minLabel;
        private Label maxLabel;
        private CheckBox logCheck;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public HistogramWindow( )
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistogramWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.channelCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.meanLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.stdDevLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.medianLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.levelLabel = new System.Windows.Forms.Label();
            this.countLabel = new System.Windows.Forms.Label();
            this.percentileLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.minLabel = new System.Windows.Forms.Label();
            this.maxLabel = new System.Windows.Forms.Label();
            this.logCheck = new System.Windows.Forms.CheckBox();
            this.histogram = new IPLab.Histogram();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(13, 363);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "ColorChannel:";
            // 
            // channelCombo
            // 
            this.channelCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.channelCombo.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.channelCombo.Location = new System.Drawing.Point(283, 355);
            this.channelCombo.Name = "channelCombo";
            this.channelCombo.Size = new System.Drawing.Size(338, 40);
            this.channelCombo.TabIndex = 3;
            this.channelCombo.SelectedIndexChanged += new System.EventHandler(this.channelCombo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(15, 474);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mean:";
            // 
            // meanLabel
            // 
            this.meanLabel.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.meanLabel.Location = new System.Drawing.Point(132, 474);
            this.meanLabel.Name = "meanLabel";
            this.meanLabel.Size = new System.Drawing.Size(104, 30);
            this.meanLabel.TabIndex = 5;
            this.meanLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(15, 517);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "Std Dev:";
            // 
            // stdDevLabel
            // 
            this.stdDevLabel.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.stdDevLabel.Location = new System.Drawing.Point(132, 517);
            this.stdDevLabel.Name = "stdDevLabel";
            this.stdDevLabel.Size = new System.Drawing.Size(104, 30);
            this.stdDevLabel.TabIndex = 7;
            this.stdDevLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(15, 560);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 26);
            this.label4.TabIndex = 8;
            this.label4.Text = "Median:";
            // 
            // medianLabel
            // 
            this.medianLabel.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.medianLabel.Location = new System.Drawing.Point(132, 560);
            this.medianLabel.Name = "medianLabel";
            this.medianLabel.Size = new System.Drawing.Size(104, 30);
            this.medianLabel.TabIndex = 9;
            this.medianLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(327, 474);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 28);
            this.label5.TabIndex = 10;
            this.label5.Text = "Level:";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(327, 517);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 32);
            this.label6.TabIndex = 11;
            this.label6.Text = "Count:";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(327, 560);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(153, 35);
            this.label7.TabIndex = 12;
            this.label7.Text = "Percentile:";
            // 
            // levelLabel
            // 
            this.levelLabel.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.levelLabel.Location = new System.Drawing.Point(496, 474);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(156, 32);
            this.levelLabel.TabIndex = 13;
            // 
            // countLabel
            // 
            this.countLabel.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.countLabel.Location = new System.Drawing.Point(496, 517);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(156, 32);
            this.countLabel.TabIndex = 14;
            // 
            // percentileLabel
            // 
            this.percentileLabel.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.percentileLabel.Location = new System.Drawing.Point(496, 560);
            this.percentileLabel.Name = "percentileLabel";
            this.percentileLabel.Size = new System.Drawing.Size(156, 32);
            this.percentileLabel.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(15, 603);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 30);
            this.label8.TabIndex = 16;
            this.label8.Text = "Min:";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(15, 646);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 30);
            this.label9.TabIndex = 17;
            this.label9.Text = "Max:";
            // 
            // minLabel
            // 
            this.minLabel.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.minLabel.Location = new System.Drawing.Point(132, 603);
            this.minLabel.Name = "minLabel";
            this.minLabel.Size = new System.Drawing.Size(104, 30);
            this.minLabel.TabIndex = 18;
            this.minLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // maxLabel
            // 
            this.maxLabel.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.maxLabel.Location = new System.Drawing.Point(132, 646);
            this.maxLabel.Name = "maxLabel";
            this.maxLabel.Size = new System.Drawing.Size(104, 30);
            this.maxLabel.TabIndex = 19;
            this.maxLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // logCheck
            // 
            this.logCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.logCheck.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.logCheck.Location = new System.Drawing.Point(12, 404);
            this.logCheck.Name = "logCheck";
            this.logCheck.Size = new System.Drawing.Size(296, 34);
            this.logCheck.TabIndex = 20;
            this.logCheck.Text = "Logarithmization:";
            this.logCheck.CheckedChanged += new System.EventHandler(this.logCheck_CheckedChanged);
            // 
            // histogram
            // 
            this.histogram.AllowSelection = true;
            this.histogram.Dock = System.Windows.Forms.DockStyle.Top;
            this.histogram.Location = new System.Drawing.Point(0, 0);
            this.histogram.Name = "histogram";
            this.histogram.Size = new System.Drawing.Size(809, 349);
            this.histogram.TabIndex = 0;
            this.histogram.PositionChanged += new IPLab.Histogram.HistogramEventHandler(this.histogram_PositionChanged);
            this.histogram.SelectionChanged += new IPLab.Histogram.HistogramEventHandler(this.histogram_SelectionChanged);
            // 
            // HistogramWindow
            // 
            this.AllowedStates = ((WeifenLuo.WinFormsUI.ContentStates)(((WeifenLuo.WinFormsUI.ContentStates.Float | WeifenLuo.WinFormsUI.ContentStates.DockLeft) 
            | WeifenLuo.WinFormsUI.ContentStates.DockRight)));
            this.AutoScaleBaseSize = new System.Drawing.Size(13, 28);
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(809, 837);
            this.CloseButton = false;
            this.Controls.Add(this.logCheck);
            this.Controls.Add(this.maxLabel);
            this.Controls.Add(this.minLabel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.percentileLabel);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.levelLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.medianLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.stdDevLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.meanLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.channelCombo);
            this.Controls.Add(this.histogram);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(718, 603);
            this.Name = "HistogramWindow";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowHint = WeifenLuo.WinFormsUI.DockState.DockRight;
            this.ShowInTaskbar = false;
            this.Text = "2";
            this.ResumeLayout(false);

        }
        #endregion

        // Gather image statistics
        public void GatherStatistics( Bitmap image )
        {
            // avoid calculation in the case of the same image
            if ( image != null )
            {
                if ( currentImageHash == image.GetHashCode( ) )
                    return;
                currentImageHash = image.GetHashCode( );
            }

            if ( image != null )
                System.Diagnostics.Debug.WriteLine( "=== Gathering histogram" );

            // busy
            Capture = true;
            Cursor = Cursors.WaitCursor;

            // get statistics
            stat = ( image == null ) ? null : new ImageStatistics( image );

            // free
            Cursor = Cursors.Arrow;
            Capture = false;

            // clean combo
            channelCombo.Items.Clear( );
            channelCombo.Enabled = false;

            if ( stat != null )
            {
                if ( !stat.IsGrayscale )
                {
                    // RGB picture
                    channelCombo.Items.AddRange( new object[] { "Red", "Green", "Blue" } );
                    channelCombo.Enabled = true;
                }
                else
                {
                    // grayscale picture
                    channelCombo.Items.Add( "Gray" );
                }
                channelCombo.SelectedIndex = 0;
            }
            else
            {
                histogram.Values = null;
                meanLabel.Text = String.Empty;
                stdDevLabel.Text = String.Empty;
                medianLabel.Text = String.Empty;
                minLabel.Text = String.Empty;
                maxLabel.Text = String.Empty;
                levelLabel.Text = String.Empty;
                countLabel.Text = String.Empty;
                percentileLabel.Text = String.Empty;
            }
        }

        // selection changed in channels combo
        private void channelCombo_SelectedIndexChanged( object sender, System.EventArgs e )
        {
            if ( stat != null )
            {
                SwitchChannel( ( stat.IsGrayscale ) ? 3 : channelCombo.SelectedIndex );
            }
        }

        // Switch channel
        public void SwitchChannel( int channel )
        {
            if ( ( channel >= 0 ) && ( channel <= 2 ) )
            {
                if ( !stat.IsGrayscale )
                {
                    histogram.Color = colors[channel];
                    activeHistogram = ( channel == 0 ) ? stat.Red : ( channel == 1 ) ? stat.Green : stat.Blue;
                }
            }
            else if ( channel == 3 )
            {
                if ( stat.IsGrayscale )
                {
                    histogram.Color = colors[3];
                    activeHistogram = stat.Gray;
                }
            }

            if ( activeHistogram != null )
            {
                histogram.Values = activeHistogram.Values;

                meanLabel.Text = activeHistogram.Mean.ToString( "F2" );
                stdDevLabel.Text = activeHistogram.StdDev.ToString( "F2" );
                medianLabel.Text = activeHistogram.Median.ToString( );
                minLabel.Text = activeHistogram.Min.ToString( );
                maxLabel.Text = activeHistogram.Max.ToString( );
            }
        }

        // Cursor position changed over the hostogram
        private void histogram_PositionChanged( object sender, IPLab.HistogramEventArgs e )
        {
            int pos = e.Position;

            if ( pos != -1 )
            {
                levelLabel.Text = pos.ToString( );
                countLabel.Text = activeHistogram.Values[pos].ToString( );
                percentileLabel.Text = ( (float) activeHistogram.Values[pos] * 100 / stat.PixelsCount ).ToString( "F2" );
            }
            else
            {
                levelLabel.Text = "";
                countLabel.Text = "";
                percentileLabel.Text = "";
            }
        }

        // Selection changed in the hostogram
        private void histogram_SelectionChanged( object sender, IPLab.HistogramEventArgs e )
        {
            int min = e.Min;
            int max = e.Max;
            int count = 0;

            levelLabel.Text = min.ToString( ) + "..." + max.ToString( );

            // count pixels
            for ( int i = min; i <= max; i++ )
            {
                count += activeHistogram.Values[i];
            }
            countLabel.Text = count.ToString( );
            percentileLabel.Text = ( (float) count * 100 / stat.PixelsCount ).ToString( "F2" );
        }

        // On "Log" check - switch mode
        private void logCheck_CheckedChanged( object sender, System.EventArgs e )
        {
            histogram.LogView = logCheck.Checked;
        }
    }
}
