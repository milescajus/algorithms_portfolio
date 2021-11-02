## Data Structures
In Week 8, a class implementing various data structures such as an array, a map, a stack, and a queue was created. This can be compiled using Mono on UNIX systems with `csc *.cs` and executed with `mono DataStructures.exe data.txt`. On all systems, DataStructures takes a single-line plaintext file as a command-line argument. This text file should contain a sequence of integers using a semicolon (';') as a delimiter. The class provides several methods to parse the string sequence into the aforementioned data structures of type `int`.

*Example*

For `data.txt` containing `1231;5135;57247;692;2345;2354;724;129;871;100;`:

```console
$ mono DataStructures.exe data.txt

String Input:
1231;5135;57247;692;2345;2354;724;129;871;100;

Array:
1231 5135 57247 692 2345 2354 724 129 871 100 

Dictionary:
	Key: 1231	Value: 1231
	Key: 5135	Value: 5135
	Key: 57247	Value: 57247
	Key: 692	Value: 692
	Key: 2345	Value: 2345
	Key: 2354	Value: 2354
	Key: 724	Value: 724
	Key: 129	Value: 129
	Key: 871	Value: 871
	Key: 100	Value: 100

Stack peek: 100
Top of stack is end of array: True

Queue peek: 1231
First out of queue is start of array: True
```

### Information about Data Structures
*Array*

An array is (traditionally) a contiguous block of memory with a pre-defined length, which cannot be changed or resized. It is used to store a series of elements of the same pre-defined type which may be accessed by index or by looping through the array. These are useful for any unchanging sequence of elements, or for preserving order, but are costly to modify as this involves copying the array to 'resize' it, or shifting the elements to avoid gaps where elements have been swapped or removed.

*Map*

A map (implemented here as a Dictionary) is an abstract data structure that associates a collection of keys with a collection of values, where all keys are the same type and all values are the same type, but keys do not need to be (and usually aren't) the same type as the values. Values may be accessed by calling the map with a specific key (which must be a hashable type). Maps use a hashing function to store the association between the key and the value, allowing O(1) lookups on average if the key is known, but O(n) if searching by value. These are useful for quickly storing and retrieving data that has an inherent association to it, e.g. names and ages for people, without having to iterate through a data structure to find the required value (if the key is known).

*Stack*

A stack is an abstract data structure that implements the LIFO concept, where the last element added to the stack is the first to be retrieved.  Elements can be pushed to the stack, and the stack can be popped, returning the element at the top of the stack until the stack is empty. These are useful for verifying the balance or symmetry of elements, e.g. when checking for matching parentheses in a code editor, or for reversing a sequence of elements.

*Queue*

A queue is the same as a stack, but instead of LIFO (last in, first out) it implements FIFO (first in, first out) as per the intuitive definition of queue.  These are potentially useful for a buffer of information, or a way of arranging queries based on execution time (the first query submitted to a database should be the first executed, etc.)
