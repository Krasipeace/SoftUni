def factorial(inputNumber):
    if inputNumber == 0:
        return 1
    return inputNumber * factorial(inputNumber - 1)

print(factorial(int(input())))