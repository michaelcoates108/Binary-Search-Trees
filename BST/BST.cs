using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    public class BST
    {
        public BST_Node root;

        public BST(int key)
        {
            root = new BST_Node(key);
        }

        public BST()
        {
            root = null;
        }
        public int getHeight(BST_Node p)
        {
            if (p == null) return 0;
            int left = getHeight(p.left);
            int right = getHeight(p.right);
            return Math.Max(left, right) + 1;
        }
        public BST_Node insert(BST_Node p)
        {
            BST_Node temp = root;
            //Empty BST
            if (temp == null)
            {
                root = p;
                return root;
            }
            //Find appropriate spot in BST
            while (true)
            {
                //If number exists in tree, skip it.
                if (p.num == temp.num) return root;
                if (p.num < temp.num)
                {
                    if (temp.left == null)
                    {
                        temp.left = p;
                        break;
                    }
                    temp = temp.left;
                }
                else
                {
                    if (temp.right == null)
                    {
                        temp.right = p;
                        break;
                    }
                    temp = temp.right;
                }
            }
            return root;
        }
        

        public void printInOrder(BST_Node p)
        {
            //Recursive method to print BST from lowest to highest
            if (p == null) return;
            printInOrder(p.left);
            Console.WriteLine(p.num);
            printInOrder(p.right);
        }

        public void printPrimes(BST_Node p)
        {
            //Recursive method to print primes
            static Boolean isPrime(int num)
            {
                Boolean FindPrime(int value)
                {
                    var root = Math.Sqrt(num);
                    for (var i = 2; i <= root; i++)
                    {
                        if (value % i == 0)
                        {
                            return false;
                        }
                    }
                    return true;
                }
                return num > 1 && FindPrime(num);
            }

            if (p == null) return;
            printPrimes(p.left);
            if(isPrime(p.num)) Console.WriteLine(p.num);
            printPrimes(p.right);

        }

        public void printByLevel(BST_Node p)
        {
            Console.WriteLine("\r\nLevel by level:");
            // Base Case
            if (root == null)
                return;
            // Create an empty queue for level order traversal
            Queue<BST_Node> q = new Queue<BST_Node>();
            // Enqueue Root and initialize height
            q.Enqueue(root);
            while (true)
            {
                // nodeCount (queue size) indicates number of nodes at current level.
                int nodeCount = q.Count;
                if (nodeCount == 0)
                    break;
                //Print and Dequeue all nodes of current level and Enqueue all nodes of next level
                while (nodeCount > 0)
                {
                    BST_Node node = q.Peek();
                    Console.Write(node.num + " ");
                    q.Dequeue();
                    if (node.left != null)
                        q.Enqueue(node.left);
                    if (node.right != null)
                        q.Enqueue(node.right);
                    nodeCount--;
                }
                Console.WriteLine();
            }
        }
    }
}
