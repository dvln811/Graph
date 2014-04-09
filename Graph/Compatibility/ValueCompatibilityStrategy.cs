using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graph.Compatibility
{
    class ValueCompatibilityStrategy : ICompatibilityStrategy
    {
        public bool CanConnect(NodeConnector from, NodeConnector to)
        {
            if (null == from.Item.Tag || null == to.Item.Tag) return false;

            var fromStr = from.Item.Tag as string;
            var toStr = to.Item.Tag as string;

            if (fromStr.Equals(toStr))
                return true;

            return false;
        }
    }
}
