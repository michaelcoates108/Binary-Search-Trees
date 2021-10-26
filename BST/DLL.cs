using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    class DLL
    {
        
        public Node head;
        public Node tail;
        public DLL() { 
            head = null; 
            tail = null; 
        }

        public void addToTail(Node p)
        {
            if (tail == null)
            {
                tail = p;
                head = p;
                return;
            }
            tail.next = p;
            p.prev = tail;
            tail = p;
        }
        public int getLength()
        {
            if (head == null) return 0;
            if (head == tail) return 1;
            Node p = head;
            int count = 1;
            while(p != null)
            {
                p = p.next;
                count++;
            }
            return count;
        }

        public int middleNum()
        {
            if (head == tail) return head.num;
            if (head == null) return 0;
            Node p = head;
            int count = 1;
            while(count < getLength() / 2)
            {
                p = p.next;
                count++;
            }
            return p.num;
        }

        public void printPrimes()
        {
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

            Node p = head;
            String out_str = "\r\n";
            int count = 0;
            //Goes through the list once, prints all primes.
            while(p != null)
            {
                if (isPrime(p.num))
                {
                    count++;
                    if(count == 6)
                    {
                        out_str += "\r\n";
                        count = 1;
                    }
                    out_str += p.num.ToString() + "\t";
                } 
                p = p.next;
            }
            Console.WriteLine("Primes in list: "+ out_str);
        }
    }
}
