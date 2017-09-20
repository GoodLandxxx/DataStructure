using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class LinkedList
    {
        public Node PreNode { get; set;}
        public Node NextNode{ get; set;}
        public object Value { get; set; }
        public LinkedList()
        {

        }
        public Node Pre()
        {
            return this.PreNode;
        }
        public Node next()
        {
            return this.NextNode;         
        }
        public string toString()
        {
            return this.Value.ToString();
        }
    }
 
}
