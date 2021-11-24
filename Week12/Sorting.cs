/* Sorting Algorithms Demo Class
 * by Miles Prinzen
 * for PROG366: Algorithms
 * taught by Holly Moore
 */

using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;

class Sorting {
    public static void Main(string[] args) {
        /* Program reads a fixed text file
         * and parses it into an array of type int
         * and sorts it with various different algorithms
         */

        var stopwatch = new Stopwatch();

        using var reader = new StreamReader("scores.txt");
        int[] data = new int[474];

        for (int i = 0; i < 474; i++) {
            string s = reader.ReadLine();
            data[i] = Int32.Parse(s);
        }

        /*
        Console.WriteLine("Data:");
        foreach (int n in data) { Console.Write($"{n} "); }
        Console.WriteLine("\n");
        */

        // Bubble Sort
        stopwatch = Stopwatch.StartNew();
        BubbleSort(data);
        stopwatch.Stop();
        
        Console.WriteLine($"\n\nBubble Sort:\t{stopwatch.ElapsedMilliseconds} ms");

        // Insertion Sort
        stopwatch = Stopwatch.StartNew();
        InsertionSort(data);
        stopwatch.Stop();
        
        Console.WriteLine($"Insertion Sort:\t{stopwatch.ElapsedMilliseconds} ms");

        // Selection Sort
        stopwatch = Stopwatch.StartNew();
        SelectionSort(data);
        stopwatch.Stop();
        
        Console.WriteLine($"Selection Sort:\t{stopwatch.ElapsedMilliseconds} ms");

        // Heap Sort
        stopwatch = Stopwatch.StartNew();
        HeapSort(data);
        stopwatch.Stop();
        
        Console.WriteLine($"Heap Sort:\t{stopwatch.ElapsedMilliseconds} ms");

        // Quick Sort
        stopwatch = Stopwatch.StartNew();
        QuickSort(data);
        stopwatch.Stop();
        
        Console.WriteLine($"Quick Sort:\t{stopwatch.ElapsedMilliseconds} ms");

        // Merge Sort
        stopwatch = Stopwatch.StartNew();
        MergeSort(data);
        stopwatch.Stop();
        
        Console.WriteLine($"Merge Sort:\t{stopwatch.ElapsedMilliseconds} ms");
    }

    public static int[] BubbleSort(int[] input, bool debug=false) {
        /* Bubble Sort
         * Runtime: O(n^2) average and worst case
         * Memory: O(1)
         * */

        bool sorted = false;
        while(!sorted) {
            sorted = true;                                      // assume is sorted
            for (int i = 0; i < input.Length - 1; i++) {
                if (input[i] > input[i + 1]) {                  // lookahead variant
                    // swap elements
                    var tmp = input[i];
                    input[i] = input[i + 1];
                    input[i + 1] = tmp;

                    sorted = false;                             // have found proof of unsorted
                }
            }

        }

        if (debug)
            foreach (int n in input) { Console.Write($"{n} "); }

        return input;
    }

    public static int[] InsertionSort(int[] input, bool debug=false) {
        /* Insertion Sort
         * Runtime: O(n^2) average and worst case
         * Memory: O(1)
         * */
        if (debug)
            foreach (int n in input) { Console.Write($"{n} "); }

        return input;
    }

    public static int[] SelectionSort(int[] input, bool debug=false) {
        /* Bubble Sort
         * Runtime: O(n^2) average and worst case
         * Memory: O(1)
         * */
        if (debug)
            foreach (int n in input) { Console.Write($"{n} "); }

        return input;
    }

    public static int[] HeapSort(int[] input, bool debug=false) {
        /* Bubble Sort
         * Runtime: O(n^2) average and worst case
         * Memory: O(1)
         * */
        if (debug)
            foreach (int n in input) { Console.Write($"{n} "); }

        return input;
    }

    public static int[] QuickSort(int[] input, bool debug=false) {
        /* Bubble Sort
         * Runtime: O(n^2) average and worst case
         * Memory: O(1)
         * */
        if (debug)
            foreach (int n in input) { Console.Write($"{n} "); }

        return input;
    }

    public static int[] MergeSort(int[] input, bool debug=false) {
        /* Bubble Sort
         * Runtime: O(n^2) average and worst case
         * Memory: O(1)
         * */
        if (debug)
            foreach (int n in input) { Console.Write($"{n} "); }

        return input;
    }
}
