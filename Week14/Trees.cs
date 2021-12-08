/* Sorting Algorithms Demo Class
 * by Miles Prinzen
 * for PROG366: Algorithms
 * taught by Holly Moore
 */

using System;
using System.IO;
// using System.Diagnostics;
// using System.Collections.Generic;

class Node {
    /* simple class for a binary tree node */

    public Node Left;
    public Node Right;
    public int Value;

    public Node(int data)
    {
        this.Left = null;
        this.Right = null;
        this.Value = data;
    }
}

class Trees {
    static bool debug;
    static int[] data;
    static Node root;

    public static void Main(string[] args)
    {
        /* Program reads a fixed text file
         * and parses it into an array of type int
         * which is then sorted and arranged into a binary tree
         */

        // Initialize variables
        debug = false;
        data = new int[474];

        // Determine debug flag
        if (args.Length != 0) {
            debug = args[0] == "/debug";
        }

        // Parse input data
        using var reader = new StreamReader("scores.txt");

        for (int i = 0; i < 474; i++) {
            string s = reader.ReadLine();
            data[i] = Int32.Parse(s);
        }

        Array.Sort(data);               // C# Array Sort method uses insertion, heap, or quicksort
                                        // see README for link to C# documentation of the API
        if (debug) Print(data);         // print unsorted data if debug flag used

        root = new Node(data[0]);       // root node initialized with first value in sorted array

        foreach (int n in data) {       // find place in tree to insert new value
            Node current = root;
            Node previous = null;       // used to track final valid node to which a child will be appended

            while (current != null) {   // traverse the tree to find the appropriate place for the new node
                previous = current;     // store current in case we need to add children

                if (n < current.Value)
                    current = current.Left;
                else
                    current = current.Right;
            }

            if (n < previous.Value)
                previous.Left = new Node(n);
            else
                previous.Right = new Node(n);
        }

        PrintTree(root);
        Console.WriteLine();
    }

    public static void Print(int[] input)
    {
        /* Helper function to print
         * all elements in array of type int
         */

        Console.WriteLine();
        foreach (int n in input) { Console.Write($"{n} "); }
        Console.WriteLine("\n");
    }

    public static void PrintTree(Node node)
    {
        /* Helper function to print the tree
         * using pre-order (root, left, right)
         *
         * TODO: implement pretty printing
         * in order to show tree structure
         */

        if (node != null) {
            Console.Write(node.Value + " ");
            PrintTree(node.Left);
            PrintTree(node.Right);
        }
    }
}
