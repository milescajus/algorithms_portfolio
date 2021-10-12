using System;
using System.IO;
using Algorithms;

class Program {
    public static void Main(string[] args) {
        // read single-line CSV file given as command-line argument
        using var reader = new StreamReader(args[0]);

        // split line by comma to get string[]
        var MyArray = reader.ReadLine().Split(",");

        // var MyArray = new string[] {"A", "B", "C", "D", "E", "F", "G"};

        MyArray.Shuffle(); // shuffle in-place

        foreach (string s in MyArray) {
            Console.Write(s + " ");
        }

        Console.WriteLine(); // final newline
    }
}
