/* Sorting Algorithms Demo Class
 * by Miles Prinzen
 * for PROG366: Algorithms
 * taught by Holly Moore
 */

using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;

class Node {
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
         * and sorts it with various different algorithms
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

        // Array.Sort(data);

        if (debug) Print(data); // print unsorted data if debug flag used

        root = new Node(data[0]);

        foreach (int n in data) {       // find place in tree to insert new value
            Node current = root;
            Node previous = null;

            while (current != null) {
                previous = current;

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

        PrintTree(root, 0);
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

    public static void PrintTree(Node node, int indent)
    {
        if (node != null) {
            for (int i = 0; i < indent; i++) {
                Console.Write(' ');
            }
            Console.WriteLine(node.Value);
            PrintTree(node.Left, ++indent);
            PrintTree(node.Right, ++indent);
        }
    }
}
