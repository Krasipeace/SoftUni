def count_areas(grid):
    rows, cols = len(grid), len(grid[0])
    visited = [[False] * cols for _ in range(rows)]
    area_counts = {}
    total_areas = 0

    for i in range(rows):
        for j in range(cols):
            if not visited[i][j]:
                letter = grid[i][j]

                dfs(grid, i, j, letter, visited)
                
                total_areas += 1
                area_counts[letter] = area_counts.get(letter, 0) + 1

    print("Areas:", total_areas)
    for letter, count in sorted(area_counts.items()):
        print(f"Letter '{letter}' -> {count}")

def dfs(grid, i, j, letter, visited):
    if i < 0 or i >= len(grid) or j < 0 or j >= len(grid[0]) or grid[i][j] != letter or visited[i][j]:
        return
    
    visited[i][j] = True

    dfs(grid, i-1, j, letter, visited)
    dfs(grid, i+1, j, letter, visited)
    dfs(grid, i, j-1, letter, visited)
    dfs(grid, i, j+1, letter, visited)

rows = int(input())
cols = int(input())
grid = []

for i in range(rows):
    row = input()
    grid.append(list(row))

count_areas(grid)