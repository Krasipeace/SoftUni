def min_edit_distance(replace_cost, insert_cost, delete_cost, first_string, second_string):
    fs_size = len(first_string)
    ss_size = len(second_string)
    dp = [[0] * (ss_size + 1) for _ in range(fs_size + 1)]

    return cost_calc(replace_cost, insert_cost, delete_cost, first_string, second_string, fs_size, ss_size, dp)

def cost_calc(replace_cost, insert_cost, delete_cost, first_string, second_string, fs_size, ss_size, dp):
    for i in range(fs_size + 1):
        for j in range(ss_size + 1):
            if i == 0:
                dp[i][j] = j * insert_cost
            elif j == 0:
                dp[i][j] = i * delete_cost
            elif first_string[i - 1] == second_string[j - 1]:
                dp[i][j] = dp[i - 1][j - 1]
            else:
                dp[i][j] = min(dp[i - 1][j - 1] + replace_cost, dp[i][j - 1] + insert_cost, dp[i - 1][j] + delete_cost)

    return dp[fs_size][ss_size]

replace_cost = int(input())
insert_cost = int(input())
delete_cost = int(input())
first_string = input()
second_string = input()

print("Minimum edit distance:", min_edit_distance(replace_cost, insert_cost, delete_cost, first_string, second_string))