using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph;

namespace MessageTool.Items
{
    internal sealed class NodeParameterItem : NodeItem
    {

        public NodeParameterItem() { }

        public NodeParameterItem(string parameterName, Type dataType)
        {

        }

        internal override SizeF Measure(Graphics context)
        {
            return new SizeF();
        }
        internal override void Render(Graphics graphics, SizeF sizeF, PointF pointF)
        {

        }
    }
}
