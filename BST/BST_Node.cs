using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    public class BST_Node
    {
        public int num;
        public BST_Node left, right;

        public BST_Node(int num)
        {
            this.num = num;
            left = right = null;
        }

        
    }
}
