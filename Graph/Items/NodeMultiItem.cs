using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Graph.Items
{
    public class NodeMultiItem : NodeItem
    {
        List<NodeItem> Items { get; set; }
        AddNodeItem AddNodeItem { get; set; }

        public NodeMultiItem(List<NodeItem> items)
        {
            Items = items;
        }

        internal override SizeF Measure(Graphics context)
        {
            throw new NotImplementedException();
        }

        internal override void Render(Graphics graphics, SizeF minimumSize, PointF position)
        {
            throw new NotImplementedException();
        }
    }
}
