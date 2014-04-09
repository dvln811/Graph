using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Graph.Items;
using Graph;

namespace Graph
{
    public delegate void AddNodeItemEvent(object sender, AddNodeItemEventArgs ane);

    public sealed class AddNodeItem : NodeItem
    {
        private string internalTitle;
        public string InternalTitle { get { return internalTitle; } private set { internalTitle = value; } }

        public NodeLabelItem Label { get; private set; }

        private string internalText;
        public string InternalText
        {
            get { return internalText; }
            private set
            {
                if (internalText == value)
                    return;
                internalText = value;
                TextSize = Size.Empty;
            }
        }

        internal SizeF TextSize;
        public NodeItemType ItemType { get; private set; }

        public event AddNodeItemEvent OnNodeAdded;

        public AddNodeItem()
        { }

        public AddNodeItem(NodeItemType type)
        {
            ItemType = type;
            InternalText = "+";
            this.Label = new NodeLabelItem(InternalText);
        }

        internal override SizeF Measure(Graphics context)
        {
            if (!string.IsNullOrEmpty(this.InternalText))
            {
                if (this.TextSize.IsEmpty)
                {
                    var size = new Size(GraphConstants.MinimumItemWidth, GraphConstants.MinimumItemHeight);
                    this.TextSize = context.MeasureString(this.InternalText, SystemFonts.MenuFont, size, GraphConstants.LeftMeasureTextStringFormat);

                    this.TextSize.Width = Math.Max(size.Width, this.TextSize.Width + 8);
                    this.TextSize.Height = Math.Max(size.Height, this.TextSize.Height + 2);
                }
                return this.TextSize;
            }
            else
            {
                return new SizeF(GraphConstants.MinimumItemWidth, GraphConstants.MinimumItemHeight);
            }
        }

        internal override void Render(Graphics graphics, SizeF minimumSize, PointF position)
        {
            var size = Measure(graphics);
            size.Width = Math.Max(minimumSize.Width / 8, size.Width / 8);
            size.Height = Math.Max(minimumSize.Height, size.Height);

            size.Height -= GraphConstants.TopHeight;
            position.Y += GraphConstants.TopHeight;

            var path = GraphRenderer.CreateRoundedRectangle(size, position);
            position.Y += 1;
            position.X += 1;

            if ((state & RenderState.Hover) == RenderState.Hover)
            {
                graphics.DrawPath(Pens.White, path);
                graphics.DrawString(this.InternalText, SystemFonts.MenuFont, Brushes.Black, new RectangleF(position, size),
                    GraphConstants.LeftTextStringFormat);
            }
            else
            {
                graphics.DrawPath(Pens.Black, path);
                graphics.DrawString(this.InternalText, SystemFonts.MenuFont, Brushes.Black, new RectangleF(position, size),
                    GraphConstants.LeftTextStringFormat);
            }
        }

        public override bool OnClick()
        {
            base.OnClick();
            
            if (OnNodeAdded != null)
                OnNodeAdded(AddItem(this.ItemType), new AddNodeItemEventArgs());
            
            return true;
        }

        private NodeItem AddItem(NodeItemType type)
        {
            switch (type)
            {
                case NodeItemType.TextBox:
                    return new NodeTextBoxItem("Test", true, true) { Tag = 1337 };
            }

            return null;
        }
    }
}
