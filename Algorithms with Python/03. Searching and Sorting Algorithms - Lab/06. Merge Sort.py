# import time

def merge_sort(array):
    if len(array) <= 1:
        return array

    mid = len(array) // 2
    left_half = array[:mid]
    right_half = array[mid:]

    left_half = merge_sort(left_half)
    right_half = merge_sort(right_half)

    return merge(left_half, right_half)

def merge(left, right):
    merged_array = []

    while left and right:
        if left[0] <= right[0]:
            merged_array.append(left.pop(0))
        else:
            merged_array.append(right.pop(0))  


    merged_array.extend(left)
    merged_array.extend(right)

    return merged_array

numbers = [int(n) for n in input().split()]

# start_time = time.time()
numbers = merge_sort(numbers)
# end_time = time.time()

print(" ".join(map(str, numbers)))
# print(f"Execution time: {end_time - start_time:.6f} seconds.")