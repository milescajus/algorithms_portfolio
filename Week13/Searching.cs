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
                          "Interpolation Search"};

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
            int find = 0;

            stopwatch = Stopwatch.StartNew();

            switch(test) {
                case "Linear Search":
                    result = LinearSearch(data, find, debug);
                    break;
                case "Binary Search":
                    result = BinarySearch(sorted, find, debug);
                    break;
                case "Interpolation Search":
                    result = InterpolationSearch(sorted, find, debug);
                    break;
                default:
                    result = data[0];
                    break;
            }

            stopwatch.Stop();
            string elapsed = stopwatch.Elapsed.TotalMilliseconds.ToString("F4");
            
            verified = result == 0;

            Console.WriteLine($"{test}:\t{elapsed} ms\tSuccess: {verified}");
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
                return data[i];
        }

        return data[0];
    }

    public static int BinarySearch(int[] data, int find, bool debug=false)
    {
        /* Binary Search
         * Best Runtime: O()
         * Worst Runtime: O()
         */

        int left = 0;
        int right = data.Length - 1;

        while (left <= right) {
            int m = (left + right) / 2;
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

        return data[0];
    }
}
