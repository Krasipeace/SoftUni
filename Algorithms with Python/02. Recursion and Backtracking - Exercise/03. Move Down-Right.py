# backtracking
def move_down_right(rows, cols, row = 0, col = 0):
    if row == rows - 1 and col == cols - 1:
        return 1 

    count = 0
    if row < rows - 1:
        count += move_down_right(rows, cols, row + 1, col)
    if col < cols - 1:
        count += move_down_right(rows, cols, row, col + 1)

    return count

inputRows = int(input())
inputCols = int(input())
print(move_down_right(inputRows, inputCols))

# dp
# def move_down_right(row, col):
#     dp = [[1] * col for _ in range(row)]

#     for i in range(1, row):
#         for j in range(1, col):
#             dp[i][j] = dp[i - 1][j] + dp[i][j - 1]

#     return dp[row - 1][col - 1]

# inputRows = int(input())
# inputCols = int(input())
# print(move_down_right(inputRows, inputCols))

