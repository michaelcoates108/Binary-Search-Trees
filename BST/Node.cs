using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    public class Node
    {
        public int num;
        public Node prev;
        public Node next;

        public Node(int num)
        {
            next = null;
            prev = null;
            this.num = num;
        }
    }
}
