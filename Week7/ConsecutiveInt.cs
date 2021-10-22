using System;
using System.Collections.Generic;

class ConsecutiveInt {
    public static void Main(string[] args) {
        int[] arrA = {21,24,22,26,23,25};       // true
        int[] arrB = {11,10,12,14,13};          // true
        int[] arrC = {11,10,14,13};             // false
        int[] arrD = {5, 2, 3, 1, 4};           // true
        int[] arrE = {7, 6, 5, 5, 3, 4};        // false
        int[] arrF = {55, 52, 53, 54, 56, 51};  // true
        int[] arrG = {5, 8, 7, 4, 5};           // false

        int[][] arrs = {arrA, arrB, arrC, arrD, arrE, arrF, arrG};
        bool[] expected = {true, true, false, true, false, true, false};

        int j = 0;

        foreach (int[] arr in arrs) {
            bool c = IsConsecutive(arr);
            Console.Write(c + "\t->\t");
            Console.WriteLine(c == expected[j] ? "Success" : "Failure");
            j++;
        }
    }

    public static bool IsConsecutive(int[] arr) {
        /* weird crazy mod approach that doesn't really work
        int t = 0;

        for (int i = 0; i < arr.Length; i++) {
            t += i % 2 == 0 ? arr[i] : - arr[i];
        }

        return t == 0 ? false : t % 3 == 0;
        */

        int min = FindMin(arr);
        int max = FindMax(arr);

        return max - min == arr.Length - 1 && Distinct(arr);
    }

    public static bool Distinct(int[] arr) {
        var set = new HashSet<int>();

        foreach (int n in arr) {
            if (!set.Add(n)) { return false; }
        }

        return true;
    }

    public static int FindMin(int[] arr) {
        int min = arr[0];
        
        foreach (int n in arr) {
            if (n < min) { min = n; }
        }

        return min;
    }

    public static int FindMax(int[] arr) {
        int max = arr[0];
        
        foreach (int n in arr) {
            if (n > max) { max = n; }
        }

        return max;
    }
}
