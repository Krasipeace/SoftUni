function solve(m, n) {
    if (m < n) {
      for (let i = m; i <= n; i++) {
        console.log(i);
      }
    } else {
      for (let i = m; i >= n; i--) {
        console.log(i);
      }
    }
}

solve(1, 5); // 1 2 3 4 5
solve(-5, 5); // -5 -4 -3 -2 -1 0 1 2 3 4 5