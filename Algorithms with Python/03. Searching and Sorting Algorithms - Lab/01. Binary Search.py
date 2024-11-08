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

numbers = [int(n) for n in input().split()]
target = int(input())
print(binary_search(numbers, target))