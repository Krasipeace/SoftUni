# import time

def insertion_sort(numbers):
    for i in range(1, len(numbers)):
        key = numbers[i]
        j = i - 1

        while j >= 0 and key < numbers[j]:
            numbers[j + 1] = numbers[j]
            j -= 1
        numbers[j + 1] = key

def print_sorted(array):
    for n in array:
        print(n, end=" ")
    print()

numbers = [int(n) for n in input().split()]
# start_time = time.time()
insertion_sort(numbers)
# end_time = time.time()
print_sorted(numbers)
# print(f"Execution time: {end_time - start_time:.6f} seconds.")