/* Data Structures Demo Class
 * by Miles Prinzen
 * for PROG366: Algorithms
 * taught by Holly Moore
 */

using System;
using System.IO;
using System.Collections.Generic;

class DataStructures {
    public static void Main(string[] args) {
        /* Program takes a text file as a command-line argument
         * and parses it into various data structures of type int
         * assuming a semicolon ';' as a delimiter
         */

        using var reader = new StreamReader(args[0]);
        string s = reader.ReadLine();                   // expected structure: "1231;5135;57247;62;2345;2354;72;1;71;0;"

        var myArr = StrToIntArray(s);
        var myDict = StrToIntDict(s);

        var myStack = StrToIntStack(s);
        var myQueue = StrToIntQueue(s);

        // Print initial string input
        Console.WriteLine("\nString Input:" + "\n" + s);

        // Print each element in the array by accessing their indices
        Console.WriteLine("\nArray:");
        for (int i = 0; i < myArr.Length; i++) { Console.Write(myArr[i] + " "); }

        // Print each key, value pair in the dictionary by iterating through
        // the keys and accessing the value at that key with the Dictionary[Key] syntax
        Console.WriteLine("\n\nDictionary:");
        foreach (string key in myDict.Keys) { Console.WriteLine("\tKey: " + key + "\tValue: " + myDict[key]); }

        // Print the value at the top of the stack, which should be the last element of the array
        Console.WriteLine("\nStack peek: " + myStack.Peek());
        Console.WriteLine("Top of stack is end of array: " + (myStack.Pop() == myArr[myArr.Length - 1]));

        // Print the next value of the queue, which should be the first element of the array
        Console.WriteLine("\nQueue peek: " + myQueue.Peek());
        Console.WriteLine("First out of queue is start of array: " + (myQueue.Dequeue() == myArr[0]));
    }

    public static int[] StrToIntArray(string input) {
        /* An array is (traditionally) a contiguous block of memory
         * with a pre-defined length, which cannot be changed or resized.
         * It is used to store a series of elements of the same pre-defined type
         * which may be accessed by index or by looping through the array.
         *
         * These are useful for any unchanging sequence of elements,
         * or for preserving order, but are costly to modify as this
         * involves copying the array to 'resize' it, or shifting the elements
         * to avoid gaps where elements have been swapped or removed.
         * The other data structures used in this class do not have this fixed-size limitation,
         * but potentially require more overhead (as such consuming more than O(n) space)
         * to keep track of the abstracted relationships.
         */

        string[] sa = input.Split(";");
        int[] ia = new int[sa.Length - 1];              // int array can be one element shorter as sa[-1] is assumed to be ""

        for (int i = 0; i < ia.Length; i++) {
            ia[i] = Int32.Parse(sa[i]);
        }

        return ia;
    }

    public static Dictionary<string, int> StrToIntDict(string input) {
        /* A map (implemented here as a Dictionary) is an abstract data structure
         * that associates a collection of keys with a collection of values,
         * where all keys are the same type and all values are the same type,
         * but keys do not need to be (and usually aren't) the same type as the values.
         * Values may be accessed by calling the map with a specific key (which must be a hashable type).
         *
         * Maps use a hashing function to store the association between the key and the value,
         * allowing O(1) lookups on average if the key is known, but O(n) if searching by value.
         *
         * These are useful for quickly storing and retrieving data that has
         * an inherent association to it, e.g. names and ages for people, without having
         * to iterate through a data structure to find the required value (if the key is known).
         */

        string[] sa = input.Split(";");
        var dict = new Dictionary<string, int>();

        for (int i = 0; i < sa.Length - 1; i++) {       // loop ignores last element as it is assumed to be empty
            dict.Add(sa[i], Int32.Parse(sa[i]));
        }

        return dict;
    }

    public static Stack<int> StrToIntStack(string input) {
        /* A stack is an abstract data structure that implements the LIFO concept,
         * where the last element added to the stack is the first to be retrieved.
         * Elements can be pushed to the stack, and the stack can be popped, returning
         * the element at the top of the stack until the stack is empty.
         *
         * These are useful for verifying the balance or symmetry of elements,
         * e.g. when checking for matching parentheses in a code editor,
         * for reversing a sequence of elements, or for any situation with inverse priority
         * (i.e. the most recent elements are the most relevant).
         */

        string[] sa = input.Split(";");
        var stack = new Stack<int>();

        for (int i = 0; i < sa.Length - 1; i++) {       // loop ignores last element as it is assumed to be empty
            stack.Push(Int32.Parse(sa[i]));
        }

        return stack;
    }

    public static Queue<int> StrToIntQueue(string input) {
        /* A queue is the same as a stack, but instead of LIFO (last in, first out) it implements
         * FIFO (first in, first out) as per the intuitive definition of queue.
         *
         * These are potentially useful for a buffer of information, or a way of arranging queries based
         * on execution time (the first query submitted to a database should be the first executed, etc.)
         */

        string[] sa = input.Split(";");
        var queue = new Queue<int>();

        for (int i = 0; i < sa.Length - 1; i++) {       // loop ignores last element as it is assumed to be empty
            queue.Enqueue(Int32.Parse(sa[i]));
        }

        return queue;
    }
}
