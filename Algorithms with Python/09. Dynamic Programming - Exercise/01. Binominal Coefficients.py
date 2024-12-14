def binomial_coefficient(n, k, memo={}): 
    if k == 0 or k == n: 
        return 1 
    if (n, k) in memo: 
        return memo[(n, k)] 
    
    memo[(n, k)] = binomial_coefficient(n-1, k-1, memo) + binomial_coefficient(n-1, k, memo) 
    
    return memo[(n, k)]

n = int(input())
k = int(input())
print(binomial_coefficient(n, k))