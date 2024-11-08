# import time

def bubble_sort(numbers):
    for i in range(len(numbers)):
        is_swapped = False
    
        for j in range(0, len(numbers) - i - 1):
            if numbers[j] > numbers[j + 1]:
                numbers[j], numbers[j + 1] = numbers[j + 1], numbers[j]
                is_swapped = True
        
        if (is_swapped == False):
            break

def print_sorted(array):
    for n in array:
        print(n, end=" ")
    print()

numbers = [int(n) for n in input().split()]
# start_time = time.time()
bubble_sort(numbers)
# end_time = time.time()
print_sorted(numbers)
# print(f"Execution time: {end_time - start_time:.6f} seconds.")