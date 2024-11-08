import random
# import time

def quickSort(numbers, low, high):
    if low < high:
        lt, gt = three_way_partition(numbers, low, high)
        quickSort(numbers, low, lt - 1)
        quickSort(numbers, gt + 1, high)

def three_way_partition(numbers, low, high):
    pivot_index = random.randint(low, high)
    pivot = numbers[pivot_index]
    numbers[pivot_index], numbers[high] = numbers[high], numbers[pivot_index]

    less_than_pivot = low  
    great_than_pivot = high  
    i = low    

    while i <= great_than_pivot:
        if numbers[i] < pivot:
            numbers[less_than_pivot], numbers[i] = numbers[i], numbers[less_than_pivot]
            less_than_pivot += 1
            i += 1
        elif numbers[i] > pivot:
            numbers[great_than_pivot], numbers[i] = numbers[i], numbers[great_than_pivot]
            great_than_pivot -= 1
        else:
            i += 1

    return less_than_pivot, great_than_pivot

numbers = [int(n) for n in input().split()]

# start_time = time.time()
quickSort(numbers, 0, len(numbers) - 1)
# end_time = time.time()

print(" ".join(map(str, numbers)))
# print(f"Execution time: {end_time - start_time:.6f} seconds.")