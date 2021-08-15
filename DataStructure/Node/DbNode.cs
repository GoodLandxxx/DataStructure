using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Node
{
    public class DbNode<T>
    {
        public T Item { get; set; }
        public DbNode<T> Prev { get; set; }
        public DbNode<T> Next { get; set; }

        public DbNode()
        {

        }

        public DbNode(T item)
        {
            this.Item = item;
        }


    }
}
