using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自製linklist
{
    internal class Node<T>
    {
        public T Body;
        public Node<T> Next=null;

        public Node(T Body) { 
            
            this.Body = Body;
        }
    }
}
