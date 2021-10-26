using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;

namespace BST
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //File paths, and desired number of lines per file.
            String file1 = "C:\\Wintec\\Data Structures\\assignment 3\\file3.txt";
            String file2 = "C:\\Wintec\\Data Structures\\assignment 3\\file4.txt";
            String file3 = "C:\\Wintec\\Data Structures\\assignment 3\\file5.txt";
            String file4 = "C:\\Wintec\\Data Structures\\assignment 4\\file1.txt";
            int length = 20;

            // TASK 1
            Console.WriteLine("----------TASK 1----------");
            try
            {
                if (checkFile(1, length, file1))
                {
                    //Store numbers from the file to an array
                    int i = 0;
                    int[] array = new int[length];
                    System.IO.StreamReader file = new System.IO.StreamReader(file1);
                    String line;
                    while ((line = file.ReadLine()) != null)
                    {
                        array[i] = Convert.ToInt32(line);
                        i++;
                    }
                    //Prints all numbers in the array and counts the primes.
                    String output_str = "";
                    int count = 0;
                    foreach (int num in array)
                    {
                        if (isPrime(num))
                        {
                            output_str += "(" + num.ToString() + ") ";
                            count++;
                        }
                        else
                        {
                            output_str += num.ToString() + " ";
                        }
                    }
                    Console.WriteLine("Numbers in file: ");
                    Console.WriteLine(output_str);
                    Console.WriteLine("There are {0} primes.", count);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            // END OF TASK 1
            // TASK 2
            Console.WriteLine("\r\n----------TASK 2----------");
            Console.WriteLine("FILE1");
            if (checkFile(2, length, file1))
            {
                DLL list1 = new DLL();
                fillList(list1, file1);
                if (list1.getLength() != 0)
                {
                    Console.WriteLine("Middle number: {0}", list1.middleNum());
                    list1.printPrimes();
                }
                else
                {
                    Console.WriteLine("Empty file.");
                }
            }

            Console.WriteLine("\r\nFILE2");
            if (checkFile(2, length, file2))
            {
                DLL list2 = new DLL();
                fillList(list2, file2);
                if (list2.getLength() != 0)
                {
                    Console.WriteLine("Middle number: {0}", list2.middleNum());
                    list2.printPrimes();
                }
                else
                {
                    Console.WriteLine("Empty file.");
                }
            }

            Console.WriteLine("\r\nFILE3");
            if (checkFile(2, length, file3))
            {
                DLL list3 = new DLL();
                fillList(list3, file3);
                if (list3.getLength() != 0)
                {
                    Console.WriteLine("Middle number: {0}", list3.middleNum());
                    list3.printPrimes();
                } else
                {
                    
                }
            }
            // END OF TASK 2
            // TASK 3
            Console.WriteLine("\r\n-----------TASK 3----------");
            Console.WriteLine("FILE1");
            if (checkFile(3, length, file1))
            {
                BST tree1 = new BST();
                fillBST(tree1, file1);
                if(tree1.getHeight(tree1.root) != 0) 
                {
                    Console.WriteLine("Primes in tree1: ");
                    tree1.printPrimes(tree1.root);
                    tree1.printByLevel(tree1.root);
                }
                else
                {
                    Console.WriteLine("Empty file.");
                }
            }

            Console.WriteLine("\r\nFILE2");
            if (checkFile(3, length, file2))
            {
                BST tree2 = new BST();
                fillBST(tree2, file2);
                if (tree2.getHeight(tree2.root) != 0)
                {
                    Console.WriteLine("Primes in tree1: ");
                    tree2.printPrimes(tree2.root);
                    tree2.printByLevel(tree2.root);
                }
                else
                {
                    Console.WriteLine("Empty file.");
                }
            }

            Console.WriteLine("\r\nFILE3");
            if (checkFile(3, length, file3))
            {
                BST tree3 = new BST();
                fillBST(tree3, file3);
                if (tree3.getHeight(tree3.root) != 0)
                {
                    Console.WriteLine("Primes in tree1: ");
                    tree3.printPrimes(tree3.root);
                    tree3.printByLevel(tree3.root);
                }
                else
                {
                    Console.WriteLine("Empty file.");
                }
            }
            // END OF TASK3 
            // TASK4
            Console.WriteLine("\r\n----------TASK 4----------");
            Hashtable words = new Hashtable();
            fillTable(words, file4);
            if (words.Count != 0) printMostCommonWord(words);
            // END OF TASK4
        }
        static Boolean checkFile(int task, int length, String filename)
        {
            try
            {
                //Checks whether the file is valid. Returns true or false.
                System.IO.StreamReader file = new System.IO.StreamReader(filename);
                String line;
                int count = 0;
                bool goodfile = true;
                while ((line = file.ReadLine()) != null)
                {
                    int number;
                    if (!(Int32.TryParse(line, out number)))
                    {
                        Console.WriteLine("Non-integer encountered in file");
                        goodfile = false;
                        break;
                    }
                    count++;
                }
                if ((count != length) && (task == 1))
                {
                    goodfile = false;
                    Console.WriteLine("There are not {0} numbers in file", length);
                }
                return goodfile;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        static Boolean isPrime(int num)
        {
            //Checks if a number is prime. Returns true or false.
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
        static String toTitle(String word)
        {
            //Converts first letter of word to upper case
            if (word.Length == 1)
            {
                return char.ToUpper(word[0]).ToString();
            }
            else
            {
                return char.ToUpper(word[0]).ToString() + word.Substring(1).ToLower();
            }
        }
        static void fillList(DLL list, String filename)
        {
            //Converts each line from a file to an integer, then adds to a DLL.
            System.IO.StreamReader file = new System.IO.StreamReader(filename);
            String line;
            try
            {
                while ((line = file.ReadLine()) != null)
                {
                    Node p = new Node(Convert.ToInt32(line));
                    list.addToTail(p);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void fillBST(BST tree, String filename)
        {
            //Converts each line from a file to an integer, then adds to a BST.
            System.IO.StreamReader file = new System.IO.StreamReader(filename);
            String line;
            try
            {
                while ((line = file.ReadLine()) != null)
                {
                    BST_Node p = new BST_Node(Convert.ToInt32(line));
                    tree.insert(p);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void fillTable(Hashtable words, String filename)
        {
            //Adds each word from a file to a hashtable
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(filename);
                String line;
                //This loop has time complexity O(n) because it looks at each line of the file only once.
                while ((line = file.ReadLine()) != null)
                {
                    //Accounts for words with unusual casing. Converts to Title.
                    String temp = toTitle(line);
                    //If word already exists in dictionary, add 1 to its value. If it doesn't, make a new word in with value 1
                    if (words.ContainsKey(temp))
                    {
                        words[temp] = (int) words[temp] + 1;
                    }
                    else
                    {
                        words.Add(temp, 1);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void printMostCommonWord(Hashtable words)
        {
            //Finds the key/value pair with highest value (frequency of word in file)
            int maxValue = 0;
            String maxKey = "";
            //This loop has time complexity O(n) because it goes through the dictionary only once to find max value.
            foreach(DictionaryEntry pair in words)
            {
                String word = pair.Key.ToString();
                int num = Convert.ToInt32(pair.Value);
                if (num > maxValue)
                {
                    maxValue = num;
                    maxKey = word;
                }
                else
                {
                    if(num == maxValue)
                    {
                        maxKey += ", " + word;
                    }
                }
            }
            Console.WriteLine("\r\nMost common word: {0}\t {1} times", maxKey, maxValue);
        }
        

        

        

        

        
    }
}
