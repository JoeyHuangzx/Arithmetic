using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic.Code
{
    public class LinkedList<T>
    {
        private class Node
        {
            public T t;
            public Node next;
            public Node(T t,Node next)
            {
                this.t = t;
                this.next = next;
            }

            public Node(T t)
            {
                this.t = t;
                this.next = null;
            }

            public Node()
            {
                //this(null, null);
            }
        }

    }
}
