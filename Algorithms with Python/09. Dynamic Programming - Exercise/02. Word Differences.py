def word_differences(first_string, second_string):
    def longest_common_subsequence(str1, str2, len1, len2):
        lcs_table = [[0] * (len2 + 1) for _ in range(len1 + 1)]
        for i in range(len1 + 1):
            for j in range(len2 + 1):
                if i == 0 or j == 0:
                    lcs_table[i][j] = 0
                elif str1[i - 1] == str2[j - 1]:
                    lcs_table[i][j] = lcs_table[i - 1][j - 1] + 1
                else:
                    lcs_table[i][j] = max(lcs_table[i - 1][j], lcs_table[i][j - 1])
        return lcs_table[len1][len2]

    len1 = len(first_string)
    len2 = len(second_string)
    lcs_length = longest_common_subsequence(first_string, second_string, len1, len2)
    deletions = len1 - lcs_length
    insertions = len2 - lcs_length

    return deletions + insertions

first_string = input()
second_string = input()
print("Deletions and Insertions:", word_differences(first_string, second_string))