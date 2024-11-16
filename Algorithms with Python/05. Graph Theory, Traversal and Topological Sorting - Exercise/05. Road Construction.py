def get_important_streets(nodes, street_edges, streets):
    graph = [[] for _ in range(nodes)]
    edges = set()

    for start, end in streets:
        graph[start].append(end)
        graph[end].append(start)
        edges.add((min(start, end), max(start, end)))

    important_streets = []

    for start, end in edges:
        graph[start].remove(end)
        graph[end].remove(start)

        visited = [False] * nodes
        dfs(0, graph, visited)

        if not all(visited):
            important_streets.append((start, end))

        graph[start].append(end)
        graph[end].append(start)

    return important_streets

def dfs(node, graph, visited):
    if visited[node]:
        return

    visited[node] = True

    for child in graph[node]:
        dfs(child, graph, visited)

nodes = int(input()) 
edges = int(input()) 
streets = []

for _ in range(edges):
    start, end = input().split(' - ')
    start, end = int(start), int(end)
    streets.append((start, end))

important_streets = get_important_streets(nodes, edges, streets)

print('Important streets:')
for start, end in important_streets:
    print(f'{start} {end}')