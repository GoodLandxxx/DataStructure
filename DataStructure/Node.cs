using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class Node
    {
        public int nodeId { get; set; }
        public Node preNode { get; set; }
        public Node NextNode { get; set; }
        public Object Value { get; set; }
    }
}
