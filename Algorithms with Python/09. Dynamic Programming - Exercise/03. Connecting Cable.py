def connecting_cables(cables):
    n = len(cables)
    dp = [1] * n

    for i in range(1, n):
        for j in range(i):
            if cables[i] > cables[j]:
                dp[i] = max(dp[i], dp[j] + 1)

    return max(dp)

cables = list(map(int, input().split()))
print("Maximum pairs connected:", connecting_cables(cables))