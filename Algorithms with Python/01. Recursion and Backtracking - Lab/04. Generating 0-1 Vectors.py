def get_vectors(index, vector):
    if index >= len(vector):
        print("".join([str(n) for n in vector]))
        return
    for number in range(0, 2):
        vector[index] = number
        get_vectors(index + 1, vector)
    return

get_vectors(0, [0] * int(input()))