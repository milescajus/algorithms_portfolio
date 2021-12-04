/* Sorting Algorithms Demo Class
 * by Miles Prinzen
 * for PROG366: Algorithms
 * taught by Holly Moore
 */

using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;

class Searching {
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
        string[] tests = {"Linear Search",
                          "Binary Search",
                          "Inter~ Search"};

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

        int[] sorted = (int[]) data.Clone();
        Array.Sort(sorted);

        if (debug) Print(data); // print unsorted data if debug flag used

        // Execute sorting tests
        foreach (string test in tests) {
            bool verified;
            int result;
            int find = 99;

            stopwatch = Stopwatch.StartNew();

            switch(test) {
                case "Linear Search":
                    result = LinearSearch(sorted, find, debug);
                    break;
                case "Binary Search":
                    result = BinarySearch(sorted, find, debug);
                    break;
                case "Inter~ Search":
                    result = InterpolationSearch(sorted, find, debug);
                    break;
                default:
                    result = -1;
                    break;
            }

            stopwatch.Stop();
            string elapsed = stopwatch.Elapsed.TotalMilliseconds.ToString("F4");
            
            verified = find == sorted[result];

            Console.WriteLine($"{test}:\t{elapsed} ms\tSuccess: {verified}\t Found at index {result}");
        }
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

    public static int LinearSearch(int[] data, int find, bool debug=false)
    {
        /* Linear Search
         * Best Runtime: O(1)
         * Worst Runtime: O(n)
         */

        for (int i = 0; i < data.Length; i++) {
            if (data[i] == find)
                return i;
        }

        return -1;
    }

    public static int BinarySearch(int[] data, int find, bool debug=false)
    {
        /* Binary Search
         * Best Runtime: O(1)
         * Worst Runtime: O(log n)
         */

        int left = 0;
        int right = data.Length - 1;
        int m;

        while (left <= right) {
            m = (left + right) / 2;
            if (data[m] < find)
                left = m + 1;
            else if (data[m] > find)
                right = m - 1;
            else
                return m;
        }

        return -1;
    }

    public static int InterpolationSearch(int[] data, int find, bool debug=false)
    {
        /* Interpolation Search
         * Best Runtime: O(log log n)
         * Worst Runtime: O(n)
         */

        int left = 0;
        int right = data.Length - 1;
        int pos;

        while (left <= right && find >= data[left] && find <= data[right]) {
            pos = left + ((find - data[left]) * (right - left) / (data[right] - data[left]));

            if (data[pos] < find)
                left = pos + 1;
            else if (data[pos] > find)
                right = pos - 1;
            else
                return pos;
        }

        return -1;
    }
}
