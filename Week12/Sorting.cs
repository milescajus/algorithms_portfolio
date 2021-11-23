/* Data Structures Demo Class
 * by Miles Prinzen
 * for PROG366: Algorithms
 * taught by Holly Moore
 */

using System;
using System.IO;
using System.Collections.Generic;

class Sorting {
    public static void Main(string[] args) {
        /* Program reads a fixed text file
         * and parses it into an array of type int
         * and sorts it with various different algorithms
         */

        using var reader = new StreamReader("scores.txt");
        int[] data = new int[474];

        for (int i = 0; i < 474; i++) {
            string s = reader.ReadLine();
            data[i] = Int32.Parse(s);
        }

        foreach (int n in data) { Console.Write(n + " "); }
    }

    public static int[] BubbleSort(int[] input) {
        /* Bubble Sort
         * Runtime: O(n^2) average and worst case
         * Memory: O(1)
         * */

        return null;
    }

    public static int[] InsertionSort(int[] input) {
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

        return null;
    }

    public static int[] SelectionSort(int[] input) {
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

        return null;
    }

    public static int[] HeapSort(int[] input) {
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

        return null;
    }

    public static int[] QuickSort(int[] input) {
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

        return null;
    }

    public static int[] MergeSort(int[] input) {
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

        return null;
    }
}
