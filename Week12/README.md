# Sorting Algorithms
See code comments for asymptotic analysis.
## Bubble Sort
### Description
Bubble Sort passes through the array and compare adjacent elements, swapping them if the lower element is larger than the upper element in the pair. This is repeated until the larger element has 'bubbled' its way to its correctly sorted position.

This procedure loops until the array is passed through with no swaps occurring.
### Pseudocode
```
Bubblesort(Data: values[])
    // Repeat until the array is sorted.
    Boolean: not_sorted = True
    While (not_sorted)
        // Assume we won't find a pair to swap.
        not_sorted = False
        // Search the array for adjacent items that are out of order.
        For i = 0 To <length of values> - 1

	// See if items i and i - 1 are out of order.
            If (values[i] < values[i - 1]) Then
                // Swap them.
                Data: temp = values[i]
                values[i] = values[i - 1]
                values[i - 1] = temp
 
                // The array isn't sorted after all.
                not_sorted = True
            End If
        Next i
    End While
End Bubblesort  
```


## Insertion Sort
### Description
Much like how people sort cards in their hand when playing a card game, the index represents a separation between the sorted and unsorted segments of the array. For each element considered, the sorted section is looped through until the appropriate place is found for that element.

Like Bubble Sort, this algorithm checks for unsorted adjacent pairs, but maintains sorting at the start of the array, and also avoids the many repeated scans of the array which significantly slow down Bubble Sort.
### Pseudocode
```
Insertionsort(Data: values[])
   For i = 0 To <length of values> - 1
       // Move item i into position
       //in the sorted part of the array
       < Find  the first index j where
         j < i and values[j] > values[i].>
       <Move the item into position j.>
   Next i
End Insertionsort
```


## Selection Sort
### Description
Like Insertion Sort, this algorithm is well suited for small arrays. It also functions similarly, albeit somewhat reversed, by finding the smallest not-yet-sorted element in the array and swapping it with the currently considered element (the end of the sorted portion of the array which lies at the start as with Insertion Sort).
### Pseudocode
```
Selectionsort(Data: values[])
    For i = 0 To <length of values> - 1
        // Find the item that belongs in position i.
        <Find the smallest item with index j >= i.>
        <Swap values[i] and values[j].>
    Next i
End Selectionsort
```


## Heap Sort
### Description
This is a rather different algorithm, relying more on the creation of the heap data structure and using its inherent properties to sort the input array with a relatively minimal algorithm. Nevertheless, getting the input array into the heap structure is complex, despite the conceptual elegance.

A heap is a type of ordered binary tree, where each node is smaller than its parents. By arranging the array into a heap (where the root, often the maximum value, lies at `A[0]` and the indices of the left and right children of any given node are calculated as `2 * i + 1` and `2 * i + 2` respectively), the sorting is simply performed by swapping the root to the end of the array and working down the heap/tree structure to place the elements backwards in decreasing size, resulting in a sorted array. This requires repeatedly repairing the heap structure using a `heapify()` method.
### Pseudocode
```
procedure heapsort(a, count) is
    input: an unordered array a of length count
 
    (Build the heap in array a so that largest value is at the root)
    heapify(a, count)

    (The following loop maintains the invariants that a[0:end] is a heap and every element
     beyond end is greater than everything before it (so a[end:count] is in sorted order))
    end ← count - 1
    while end > 0 do
        (a[0] is the root and largest value. The swap moves it in front of the sorted elements.)
        swap(a[end], a[0])
        (the heap size is reduced by one)
        end ← end - 1
        (the swap ruined the heap property, so restore it)
        siftDown(a, 0, end)(Put elements of 'a' in heap order, in-place)

procedure heapify(a, count) is
    (start is assigned the index in 'a' of the last parent node)
    (the last element in a 0-based array is at index count-1; find the parent of that element)
    start ← iParent(count-1)
    
    while start ≥ 0 do
        (sift down the node at index 'start' to the proper place such that all nodes below
         the start index are in heap order)
        siftDown(a, start, count - 1)
        (go to the next parent node)
        start ← start - 1
    (after sifting down the root all nodes/elements are in heap order)

(Repair the heap whose root element is at index 'start', assuming the heaps rooted at its children are valid)
procedure siftDown(a, start, end) is
    root ← start

    while iLeftChild(root) ≤ end do    (While the root has at least one child)
        child ← iLeftChild(root)   (Left child of root)
        swap ← root                (Keeps track of child to swap with)

        if a[swap] < a[child] then
            swap ← child
        (If there is a right child and that child is greater)
        if child+1 ≤ end and a[swap] < a[child+1] then
            swap ← child + 1
        if swap = root then
            (The root holds the largest element. Since we assume the heaps rooted at the
             children are valid, this means that we are done.)
            return
        else
            swap(a[root], a[swap])
            root ← swap          (repeat to continue sifting down the child now)


```


## Quicksort
### Description
One of the major divide-and-conquer algorithms, Quicksort recursively breaks down the array by choosing a 'pivot' element and comparing the values of the elements either side of the pivot, swapping them if they are on the 'wrong side', i.e. are unsorted relative to the pivot.

As each partition of the array is recursively further partitioned, the swapping around the pivot eventually results in a completely sorted array. This algorithm was consistently the fastest in my measurements.
### Pseudocode
```
// Sorts a (portion of an) array, divides it into partitions, then sorts those
algorithm quicksort(A, lo, hi) is 
  if lo >= 0 && hi >= 0 && lo < hi then
    p := partition(A, lo, hi) 
    quicksort(A, lo, p) // Note: the pivot is now included
    quicksort(A, p + 1, hi) 

// Divides array into two partitions
algorithm partition(A, lo, hi) is 
  // Pivot value
  pivot := A[ floor((hi + lo) / 2) ] // The value in the middle of the array

  // Left index
  i := lo - 1 

  // Right index
  j := hi + 1

  loop forever 
    // Move the left index to the right at least once and while the element at 
    // the left index is less than the pivot 
    do i := i + 1 while A[i] < pivot 
    
    // Move the right index to the left at least once and while the element at
    // the right index is greater than the pivot 
    do j := j - 1 while A[j] > pivot 

    // If the indices crossed, return
    if i ≥ j then return j
    
    // Swap the elements at the left and right indices
    swap A[i] with A[j]
```


## Merge Sort
### Description
Similarly to Quicksort, this divide-and-conquer algorithm also recursively breaks down the array, but instead simply compares element pairs at the deepest level of recursion and relies on merging these subdivided partitions correctly to maintain order.

As this is recursive, the actual swapping takes place with minimal elements and as the recursion 'flows' back upwards the array becomes fully sorted. This was the second-fastest algorithm in my measurements, after Quicksort.
### Pseudocode
```
Mergesort(Data: values[], Data: scratch[], Integer: start, Integer: end)
    // If the array contains only one item, it is already sorted.

If (start == end) Then Return
 
    // Break the array into left and right halves.
    Integer: midpoint = (start + end) / 2
 
    // Call Mergesort to sort the two halves.
    Mergesort(values, scratch, start, midpoint)
    Mergesort(values, scratch, midpoint + 1, end)
 
    // Merge the two sorted halves.
    Integer: left_index = start
    Integer: right_index = midpoint + 1
    Integer: scratch_index = left_index
    While ((left_index <= midpoint) And (right_index <= end))
        If (values[left_index] <= values[right_index]) Then
            scratch[scratch_index] = values[left_index]
            left_index = left_index + 1
        Else
            scratch[scratch_index] = values[right_index]
            right_index = right_index + 1
        End If
        scratch_index = scratch_index + 1    End While
 
    // Finish copying whichever half is not empty.
    For i = left_index To midpoint
        scratch[scratch_index] = values[i]
        scratch_index = scratch_index + 1
    Next i
    For i = right_index To end

scratch[scratch_index] = values[i]
        scratch_index = scratch_index + 1
    Next i
    // Copy the values back into the original values array.
    For i = start To end
        values[i] = scratch[i]
    Next i
End Mergesort
```
