using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IPLab.Controls
{
    public class CustomStatusBar : StatusBar
    {
        public CustomStatusBar()
        {
         
        }

        protected override void OnDrawItem(StatusBarDrawItemEventArgs sbdevent)
        {
            StatusBarPanel panel = Panels[sbdevent.Index];


            // 绘制背景颜色
            sbdevent.Graphics.FillRectangle(Brushes.Blue, sbdevent.Bounds);

            sbdevent.Graphics.DrawString(panel.Text, Font, Brushes.White, sbdevent.Bounds.X + 2, sbdevent.Bounds.Y + 2);
        }
    }
}
