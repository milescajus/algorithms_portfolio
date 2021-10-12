# PROG 366: Algorithms - Portfolio
## Portfolio Structure & Conventions
- Every week for which there is work will have its own folder, e.g. "Week2".
- Therein, assignments are named with by week and assignment numbers, e.g. WK2_A1 or WK3_A2, etc., unless otherwise specified.

### Fisher-Yates Shuffle
In Week 5, a class implementing version 1 of the Fisher-Yates shuffle was created. This can be compiled on UNIX systems with `csc *.cs` and executed with `mono Program.exe data.csv`. On all systems, Program takes a single-line CSV file as a command-line argument, interprets it as a string array without escape checking, and outputs a shuffled permutation of the data to stdout.

*Example*

For `data.csv` containing `A,B,C,D,E,F,G`:

```console
$ mono Program.exe data.csv
B D G C F A E
```

## Changelog
Week 2
- added Assignment I: Big O Code Examples

Week 3
- added Group 03 breakout assignment as PDF

Week 5
- added Fisher-Yates shuffle
