board = [[0] * 8 for _ in range(8)]

def eight_queens_puzzle(row):
    if row == 8:
        print_solution()
        return

    for col in range(8):
        if can_place_queen(row, col):
            set_queen(row, col)
            eight_queens_puzzle(row + 1)
            remove_queen(row, col)

def print_solution():
    for row in range(8):
        for col in range(8):
            print('*' if board[row][col] == 1 else '-', end=' ')
        print()
    print()

def can_place_queen(row, col):
    for i in range(row):
        if board[i][col] == 1:
            return False

    i, j = row, col
    while i >= 0 and j >= 0:
        if board[i][j] == 1:
            return False
        i -= 1
        j -= 1

    i, j = row, col
    while i >= 0 and j < 8:
        if board[i][j] == 1:
            return False
        i -= 1
        j += 1
    return True

def set_queen(row, col):
    board[row][col] = 1

def remove_queen(row, col):
    board[row][col] = 0

eight_queens_puzzle(0)