def dp_fibo(n, memoization={}):
    if n in memoization:
        return memoization[n] 
    if n <= 1:
        return 1
    
    memoization[n] = dp_fibo(n - 1, memoization) + dp_fibo(n - 2, memoization)

    return memoization[n]

print(dp_fibo(int(input())))