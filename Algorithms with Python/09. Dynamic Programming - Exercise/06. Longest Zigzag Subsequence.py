def longest_zigzag_subsequence(nums):
    n = len(nums)
    if n == 0:
        return []

    up, down, up_prev, down_prev = init_data(nums, n)

    max_index, is_up = find_max_length(n, up, down)

    return reconstruct(nums, up_prev, down_prev, max_index, is_up)

def init_data(nums, n):
    up = [1] * n
    down = [1] * n
    up_prev = [-1] * n
    down_prev = [-1] * n

    for i in range(1, n):
        for j in range(i):
            if nums[i] > nums[j] and up[i] < down[j] + 1:
                up[i] = down[j] + 1
                up_prev[i] = j
            elif nums[i] < nums[j] and down[i] < up[j] + 1:
                down[i] = up[j] + 1
                down_prev[i] = j
    return up,down,up_prev,down_prev

def find_max_length(n, up, down):
    max_length = 0
    max_index = 0
    is_up = True
    for i in range(n):
        if up[i] > max_length:
            max_length = up[i]
            max_index = i
            is_up = True
        if down[i] > max_length:
            max_length = down[i]
            max_index = i
            is_up = False
    return max_index,is_up

def reconstruct(nums, up_prev, down_prev, max_index, is_up):
    result = []
    while max_index != -1:
        result.append(nums[max_index])
        if is_up:
            max_index = up_prev[max_index]
            is_up = False
        else:
            max_index = down_prev[max_index]
            is_up = True

    return result[::-1]

input = list(map(int, input().split()))
print(*longest_zigzag_subsequence(input), sep=' ')