from collections import deque

def longest_string_chain(size, prev):
    for curr_idx in range(1, len(input)):
        current_str = input[curr_idx]
        current_best_size = 1
        current_parent = None
        for prev_idx in range(curr_idx - 1, -1, -1):
            prev_word = input[prev_idx]
            if len(prev_word) >= len(current_str):
                continue
            new_best_size = size[prev_idx] + 1
            if new_best_size >= current_best_size:
                current_best_size = new_best_size
                current_parent = prev_idx
        size[curr_idx] = current_best_size
        prev[curr_idx] = current_parent

def reconstruct_lsc(best_idx, inputs, prev):
    result = deque()
    while best_idx is not None:
        result.appendleft(inputs[best_idx])
        best_idx = prev[best_idx]

    return result

input = [x for x in input().split()]
size = [0] * len(input)
size[0] = 1
prev = [None] * len(input)
longest_string_chain(size, prev)
best_idx = size.index(max(size))
print(*reconstruct_lsc(best_idx, input, prev), sep=' ')