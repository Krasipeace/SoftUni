# import time

def selection_sort(numbers):
    for i in range(len(numbers) - 1):
        min_index = i

        for j in range(i + 1, len(numbers)):
            if numbers[j] < numbers[min_index]:
                min_index = j
        
        numbers[i], numbers[min_index] = numbers[min_index], numbers[i]

def print_sorted(array):
    for n in array:
        print(n, end=" ")
    print()

numbers = [int(n) for n in input().split()]
# start_time = time.time()
selection_sort(numbers)
# end_time = time.time()
print_sorted(numbers)
# print(f"Execution time: {end_time - start_time:.6f} seconds.")