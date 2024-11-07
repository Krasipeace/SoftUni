def reverse_arr(array):
    if len(array) <= 1:
        return array
    return reverse_arr(array[1:]) + [array[0]]

array = [int(n) for n in input().split()]
print(*reverse_arr(array)) 