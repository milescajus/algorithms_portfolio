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
    public static void Main(string[] args)
    {
        /* Program reads a fixed text file
         * and parses it into an array of type int
         * and sorts it with various different algorithms
         */

        // Initialize variables
        var stopwatch = new Stopwatch();
        bool debug = false;
        int[] data = new int[474];
        string[] tests = {"Bubble Sort",
                          "Insertion Sort",
                          "Selection Sort",
                          "Heap Sort",
                          "Quick Sort",
                          "Merge Sort"};

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

        if (debug) Print(data); // print unsorted data if debug flag used

        // Execute sorting tests
        foreach (string test in tests) {
            bool verified;
            int[] sorted;

            stopwatch = Stopwatch.StartNew();

            switch(test) {
                case "Bubble Sort":
                    sorted = BubbleSort(data, debug);
                    break;
                case "Insertion Sort":
                    sorted = InsertionSort(data, debug);
                    break;
                case "Selection Sort":
                    sorted = SelectionSort(data, debug);
                    break;
                case "Heap Sort":
                    sorted = HeapSort(data, debug);
                    break;
                case "Quick Sort":
                    sorted = QuickSort(data, debug);
                    break;
                case "Merge Sort":
                    sorted = MergeSort(data, debug);
                    break;
                default:
                    sorted = data;
                    break;
            }

            stopwatch.Stop();
            string elapsed = stopwatch.Elapsed.TotalMilliseconds.ToString("F4");
            
            verified = Verify(sorted);

            Console.WriteLine($"{test}:\t{elapsed} ms\tSuccess: {verified}");
        }
    }

    public static bool Verify(int[] input)
    {
        /* Helper function to confirm that
         * an array of type int is sorted
         */

        for (int i = 1; i < input.Length; i++) {
            if (input[i] < input[i - 1]) {
                Console.Write($"{input[i]} !> {input[i - 1]} -- ");
                return false;
            }
        }

        return true;
    }

    public static void Swap(int[] input, int i, int j)
    {
        /* Helper function to swap elements
         * at indices i and j in array of type int
         */

        var tmp = input[i];
        input[i] = input[j];
        input[j] = tmp;
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

    public static int[] BubbleSort(int[] input, bool debug=false)
    {
        /* Bubble Sort
         * Best Runtime: O(n)
         * Worst Runtime: O(n^2)
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

        if (debug) Print(A);

        return A;
    }

    public static int[] InsertionSort(int[] input, bool debug=false)
    {
        /* Insertion Sort
         * Best Runtime: O(n)
         * Worst Runtime: O(n^2)
         */

        int[] A = (int[]) input.Clone();
        
        for (int i = 1; i < A.Length; i++) {
            for (int j = i; j > 0; j--) {
                if (A[j] < A[j - 1]) {
                    Swap(A, j, j - 1);
                }
            }
        }

        if (debug) Print(A);

        return A;
    }

    public static int[] SelectionSort(int[] input, bool debug=false)
    {
        /* Selection Sort
         * Best Runtime: O(n^2)
         * Worst Runtime: O(n^2)
         */

        int[] A = (int[]) input.Clone();

        for (int i = 0; i < A.Length - 1; i++) {
            for (int j = i; j < A.Length; j++) {
                if (A[j] < A[i]) {
                    Swap(A, i, j);
                }
            }
        }

        if (debug) Print(A);

        return A;
    }

    public static int[] HeapSort(int[] input, bool debug=false)
    {
        /* Heap Sort
         * Best Runtime: O(n log n)
         * Worst Runtime: O(n log n)
         */

        int[] A = (int[]) input.Clone();

        Heapify(A, A.Length);

        int end = A.Length - 1;

        while (end > 0) {
            Swap(A, 0, end);
            end--;
            SiftDown(A, 0, end);
        }

        if (debug) Print(A);

        return A;
    }

    public static void Heapify(int[] A, int count)
    {
        int start = HParent(count - 1);

        while (start >= 0) {
            SiftDown(A, start, count - 1);
            start--;
        }
    }

    public static void SiftDown(int[] A, int start, int end)
    {
        int root = start;

        while (HLeftChild(root) <= end) {
            int child = HLeftChild(root);
            int swap = root;

            if (A[swap] < A[child])
                swap = child;
            if (child + 1 <= end && A[swap] < A[child + 1])
                swap = child + 1;
            if (swap == root)
                return;
            else {
                Swap(A, root, swap);
                root = swap;
            }
        }
    }

    public static int HParent(int i) { return (i - 1) / 2; }
    public static int HLeftChild(int i) { return 2 * i + 1; }
    public static int HRightChild(int i) { return 2 * i + 2; }

    public static int[] QuickSort(int[] input, bool debug=false)
    {
        /* Quick Sort
         * Best Runtime: O(n log n)
         * Worst Runtime: O(n^2)
         */

        int[] A = (int[]) input.Clone();

        QS(A, 0, A.Length - 1);

        if (debug) Print(A);

        return A;
    }

    public static void QS(int[] A, int lo, int hi)
    {
        /* Actual Quicksort algorithm function
         * called recursively for each partition
         */

        if (lo < hi) {
            int p = Partition(A, lo, hi);
            QS(A, lo, p);
            QS(A, p + 1, hi);
        }
    }

    public static int Partition(int[] A, int lo, int hi)
    {
        /* Hoare's partition scheme:
         * choose median as pivot,
         * approach pivot from both sides
         * until value is on wrong side,
         * swap values to correct placement
         */

        int pivot = A[(lo + hi) / 2];   // C# automatically chooses floor value for int
        int i = lo - 1;                 // left pointer
        int j = hi + 1;                 // right pointer

        while(true) {
            do { i++; } while (A[i] < pivot);
            do { j--; } while (A[j] > pivot);

            if (i >= j) return j;       // i overtook j, returns new bounds for recursive QS

            Swap(A, i, j);              // swap elements on wrong side of pivot
        }
    }

    public static int[] MergeSort(int[] input, bool debug=false)
    {
        /* Merge Sort
         * Best Runtime: O(n log n)
         * Worst Runtime: O(n log n)
         */

        int[] A = (int[]) input.Clone();

        MS(A, new int[A.Length], 0, A.Length - 1);

        if (debug) Print(A);

        return A;
    }

    public static void MS(int[] A, int[] scratch, int start, int end)
    {
        /* Actual Merge Sort algorithm function
         * called recursively for each partition
         * includes merge step as well as division
         * based on Rod Stephens' pseudocode
         */

        if (start == end) return;
        int midpoint = (start + end) / 2;

        MS(A, scratch, start, midpoint);
        MS(A, scratch, midpoint + 1, end);

        int left_index = start;
        int right_index = midpoint + 1;
        int scratch_index = left_index;

        while (left_index <= midpoint && right_index <= end) {
            if (A[left_index] <= A[right_index]) {
                scratch[scratch_index] = A[left_index];
                left_index++;
            } else {
                scratch[scratch_index] = A[right_index];
                right_index++;
            }
            scratch_index++;
        }

        for (int i = left_index; i <= midpoint; i++) {
            scratch[scratch_index] = A[i];
            scratch_index++;
        }

        for (int i = right_index; i <= end; i++) {
            scratch[scratch_index] = A[i];
            scratch_index++;
        }

        for (int i = start; i <= end; i++) {
            A[i] = scratch[i];
        }
    }
}
