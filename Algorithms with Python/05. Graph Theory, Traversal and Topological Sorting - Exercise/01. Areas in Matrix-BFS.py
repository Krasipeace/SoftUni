from collections import deque

def count_areas(grid):
    rows, cols = len(grid), len(grid[0])
    visited = [[False] * cols for _ in range(rows)]
    area_counts = {}
    total_areas = 0

    for i in range(rows):
        for j in range(cols):
            if not visited[i][j]:
                letter = grid[i][j]

                bfs(grid, i, j, letter, visited)
                
                total_areas += 1
                area_counts[letter] = area_counts.get(letter, 0) + 1

    print("Areas:", total_areas)
    for letter, count in sorted(area_counts.items()):
        print(f"Letter '{letter}' -> {count}")

def bfs(grid, i, j, letter, visited):
    queue = deque([(i, j)])
    visited[i][j] = True

    while queue:
        x, y = queue.popleft()

        for direction_x, direction_y in [(0, 1), (1, 0), (-1, 0), (0, -1)]:
            neighbour_x, neighbour_y = x + direction_x, y + direction_y
            
            if 0 <= neighbour_x < len(grid) and 0 <= neighbour_y < len(grid[0]) and grid[neighbour_x][neighbour_y] == letter and not visited[neighbour_x][neighbour_y]:
                queue.append((neighbour_x, neighbour_y))
                visited[neighbour_x][neighbour_y] = True

rows = int(input())
cols = int(input())
grid = []

for i in range(rows):
    row = input()
    grid.append(list(row))

count_areas(grid)