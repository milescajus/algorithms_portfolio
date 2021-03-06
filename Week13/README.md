# Searching Algorithms
See code comments for asymptotic analysis.

## Linear Search
### Description
Sequentially checks all items in an array to see if they match the search term.
### Pseudocode
```
Begin
1) Set i = 0
2) If Li = T, go to line 4
3) Increase i by 1 and go to line 2
4) If i < n then return i
End
```


## Binary Search
### Description
Relies on a pre-sorted array. Breaks down the array into two halves around a midpoint, first checking the midpoint to see if it matches the search term, then discarding the half of the array that does not contain the search term (determined by whether the midpoint is smaller or larger than the term). This process is repeated until the midpoint matches the search term.
### Pseudocode
```
function binary_search(A, n, T) is
    L := 0
    R := n − 1
    while L ≤ R do
        m := floor((L + R) / 2)
        if A[m] < T then
            L := m + 1
        else if A[m] > T then
            R := m − 1
        else:
            return m
    return unsuccessful
```


## Interpolation Search
### Description
Similar to binary search, interpolation search also progressively reduces the search space, but chooses the key to compare by interpolating the edges of the search space with the key being sought (i.e. if the sought key is large, the algorithm will check closer to the upper end of the array).
### Pseudocode
```
1) In a loop, calculate the value of “pos” using the probe position formula.
2) If there is a match, return the index of the item, and exit.
3) If the item is less than the arr[pos], calculate the probe position of the left sub-array. Otherwise calculate the same in the right sub-array.
4) Repeat until a match is found or the sub-array reduces to zero.
```

## Summary
Linear search has the advantage of not requiring pre-sorted data, but is potentially the slowest as its worst-case scenario involves checking every element of the array with no deduction or comparison (O(n)). The other two searching algorithms use the sought key in comparison with the search space to more quickly traverse the array and find the matching term. Binary search always chooses the midpoint of the (sub-)array, whereas interpolation search chooses comparison values based on the sought key. This works best when the data being searched is uniformly distributed.