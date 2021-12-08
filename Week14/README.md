## Simple Binary Tree C# Implementation

`Trees.cs` contains two classes: one simple binary tree node class, and a main class to implement and populate the tree. The code takes the same `scores.txt` data as used in previous exercises, sorts it using C#'s Array.Sort method\*, and creates a binary tree to store the data.

The binary tree node comprises three properties: its value, a left child node, and a right child node. Each node is larger than any of its left-branch children and smaller than any right-branch children. Each node has only one parent and only two children. The root node has no parent, and the final children have their left and right child properties initialized as `null`.

\* [Microsoft C# API Documentation: Array.Sort](https://docs.microsoft.com/en-us/dotnet/api/system.array.sort?view=net-6.0#System_Array_Sort_System_Array_)

This method uses one of insertion sort, heapsort, or quicksort depending on the size and structure of the array.
