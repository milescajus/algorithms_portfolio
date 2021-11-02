### Data Structures
In Week 8, a class implementing various data structures such as an array, a map, a stack, and a queue was created. This can be compiled using Mono on UNIX systems with `csc *.cs` and executed with `mono DataStructures.exe data.txt`. On all systems, DataStructures takes a single-line plaintext file as a command-line argument. This text file should contain a sequence of integers using a semicolon (';') as a delimiter. The class provides several methods to parse the string sequence into the aforementioned data structures of type `int`.

*Example*

For `data.txt` containing `A,B,C,D,E,F,G`:

```console
$ mono Program.exe data.csv
B D G C F A E
```
