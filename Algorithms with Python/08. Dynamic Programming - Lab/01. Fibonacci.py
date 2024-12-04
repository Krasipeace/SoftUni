def calc_fib_dp(n, memo):
    if n in memo:
        return memo[n]
    
    if n <= 2:
        return 1
    
    result = calc_fib_dp(n - 1, memo) + calc_fib_dp(n - 2, memo)
    memo[n] = result

    return result

n = int(input())

print(calc_fib_dp(n, {}))