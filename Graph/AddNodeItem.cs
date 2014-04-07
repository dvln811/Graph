using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Graph
{
    internal sealed class AddNodeItem : NodeItem
    {
        private string internalTitle;
        public string InternalTitle { get { return internalTitle; } set { internalTitle = value; } }
        
        internal override SizeF Measure(Graphics context)
        {
            throw new NotImplementedException();
        }

        internal override void Render(Graphics graphics, SizeF minimumSize, PointF position)
        {
            var size = Measure(graphics);
            size.Width = Math.Max(minimumSize.Width, size.Width);
            size.Height = Math.Max(minimumSize.Height, size.Height);

            size.Height -= GraphConstants.TopHeight;
            position.Y += GraphConstants.TopHeight;

            if ((state & RenderState.Hover) == RenderState.Hover)
                graphics.DrawString(this.InternalTitle, SystemFonts.CaptionFont, Brushes.White, new RectangleF(position, size), 
                    GraphConstants.TitleStringFormat);
            else
                graphics.DrawString(this.InternalTitle, SystemFonts.CaptionFont, Brushes.Black, new RectangleF(position, size), 
                    GraphConstants.TitleStringFormat);
        }
    }
}
