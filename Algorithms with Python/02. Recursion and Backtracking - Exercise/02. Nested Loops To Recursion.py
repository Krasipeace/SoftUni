def nested_loops_rec(input, currentLoop = 1, values = []):
    if currentLoop > input:
        print(' '.join(map(str, values)))
        return

    for i in range(1, input + 1):
        nested_loops_rec(input, currentLoop + 1, values + [i])

nested_loops_rec(int(input()))