def calc_sum(arrayNumbers, index):
    if index == len(arrayNumbers) - 1:
        return arrayNumbers[index]
    return arrayNumbers[index] + calc_sum(arrayNumbers, index + 1)

print(calc_sum([int(x) for x in input().split(" ")], 0))