# import time
def binary_search(numbers, target):
    left = 0
    right = len(numbers) - 1

    while left <= right:
        mid = (left + right) // 2
        mid_element = numbers[mid]

        if mid_element == target:
            return mid
        
        if mid_element < target:
            left = mid + 1
        else:
            right = mid - 1

    return -1

def binary_search_recursive(numbers, target, left, right):
    if left > right:
        return -1

    mid = (left + right) // 2
    mid_element = numbers[mid]

    if mid_element == target:
        return mid
    elif mid_element < target:
        return binary_search_recursive(numbers, target, mid + 1, right)
    else:
        return binary_search_recursive(numbers, target, left, mid - 1)

numbers = [int(n) for n in input().split()]
# numbers2 = numbers
target = int(input())

# start_time = time.time()
print(binary_search(numbers, target))
# end_time = time.time()
# print(f"Execution time: {end_time - start_time:.6f} seconds.")

# start_time = time.time()
# print(binary_search_recursive(numbers2, target, 0, len(numbers2) - 1))
# end_time = time.time()
# print(f"Execution time Recursively: {end_time - start_time:.6f} seconds.")
