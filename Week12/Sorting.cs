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

        if (args.Length != 0 && args[0] == "/debug") {
            Console.WriteLine("Data:");
            foreach (int n in data) { Console.Write($"{n} "); }
            Console.WriteLine("\n");
        }

        string[] tests = {"Bubble Sort", "Insertion Sort", "Selection Sort", "Heap Sort", "Quick Sort", "Merge Sort"};

        foreach (string test in tests) {
            bool verified = false;
            int[] sorted;
            stopwatch = Stopwatch.StartNew();

            switch(test) {
                case "Bubble Sort":
                    sorted = BubbleSort(data);
                    verified = Verify(sorted);
                    break;
                case "Insertion Sort":
                    sorted = InsertionSort(data);
                    verified = Verify(sorted);
                    break;
                case "Selection Sort":
                    sorted = SelectionSort(data);
                    verified = Verify(sorted);
                    break;
                case "Heap Sort":
                    sorted = HeapSort(data);
                    verified = Verify(sorted);
                    break;
                case "Quick Sort":
                    sorted = QuickSort(data);
                    verified = Verify(sorted);
                    break;
                case "Merge Sort":
                    sorted = MergeSort(data);
                    verified = Verify(sorted);
                    break;
            }

            stopwatch.Stop();

            Console.WriteLine($"{test}:\t{stopwatch.ElapsedMilliseconds} ms\t{verified}");
        }
    }

    public static bool Verify(int[] input) {
        /* Confirm that an array of type int
         * is indeed sorted correctly
         */

        for (int i = 1; i < input.Length; i++) {
            if (input[i] < input[i - 1]) {
                Console.Write($"{input[i]} !> {input[i - 1]} -- ");
                return false;
            }
        }

        return true;
    }

    public static void Swap(int[] input, int i, int j) {
        /* Swap elements at indices i and j
         * in array of type int input
         */

        var tmp = input[i];
        input[i] = input[j];
        input[j] = tmp;
    }

    public static void Heapify(int[] input) {
        
    }

    public static int[] BubbleSort(int[] input, bool debug=false) {
        /* Bubble Sort
         * Runtime: O(n) best case, O(n^2) worst case
         * Memory: O(1)
         */

        int[] A = (int[]) input.Clone();

        bool sorted = false;
        while(!sorted) {
            sorted = true;                              // assume is sorted
            for (int i = 0; i < A.Length - 1; i++) {
                if (A[i] > A[i + 1]) {                  // lookahead variant
                    Swap(A, i, i + 1);
                    sorted = false;                     // have found proof of unsorted
                }
            }

        }

        if (debug) {
            foreach (int n in A) { Console.Write($"{n} "); }
            Console.WriteLine("\n");
        }

        return A;
    }

    public static int[] InsertionSort(int[] input, bool debug=false) {
        /* Insertion Sort
         * Runtime: O(n) best case, O(n^2) worst case
         * Memory: O(1) to O(n)
         */

        int[] A = (int[]) input.Clone();
        
        for (int i = 1; i < A.Length; i++) {
            for (int j = i; j > 0; j--) {
                if (A[j] < A[j - 1]) {
                    Swap(A, j, j - 1);
                }
            }
        }

        if (debug) {
            foreach (int n in A) { Console.Write($"{n} "); }
            Console.WriteLine("\n");
        }

        return A;
    }

    public static int[] SelectionSort(int[] input, bool debug=false) {
        /* Selection Sort
         * Runtime: O(n^2) best, average, and worst case
         * Memory: O(1)
         */

        int[] A = (int[]) input.Clone();

        for (int i = 0; i < A.Length - 1; i++) {
            for (int j = i; j < A.Length; j++) {
                if (A[j] < A[i]) {
                    Swap(A, i, j);
                }
            }
        }

        if (debug) {
            foreach (int n in A) { Console.Write($"{n} "); }
            Console.WriteLine("\n");
        }

        return A;
    }

    public static int[] HeapSort(int[] input, bool debug=false) {
        /* Heap Sort
         * Runtime: O(n log n) best, average, and worst case
         * Memory: O(1)
         */

        int[] A = (int[]) input.Clone();

        Heapify(A);

        for (int i = A.Length - 1; i >= 0; i--) {
            Swap(A, 0, i);
            Heapify(A);
        }

        if (debug) {
            foreach (int n in input) { Console.Write($"{n} "); }
            Console.WriteLine("\n");
        }

        return A;
    }

    public static int[] QuickSort(int[] input, bool debug=false) {
        /* Bubble Sort
         * Runtime: O(n^2) average and worst case
         * Memory: O(1)
         */

        int[] A = (int[]) input.Clone();

        if (debug) {
            foreach (int n in input) { Console.Write($"{n} "); }
            Console.WriteLine("\n");
        }

        return A;
    }

    public static int[] MergeSort(int[] input, bool debug=false) {
        /* Bubble Sort
         * Runtime: O(n^2) average and worst case
         * Memory: O(1)
         */

        int[] A = (int[]) input.Clone();

        if (debug) {
            foreach (int n in input) { Console.Write($"{n} "); }
            Console.WriteLine("\n");
        }

        return A;
    }
}
