from collections import deque

def break_cycles(graph, edges):
    edges_to_remove = []

    for start, end in sorted(edges, key=lambda x: (x[0], x[1])):
        if end not in graph[start] or start not in graph[end]:
            continue

        graph[start].remove(end)
        graph[end].remove(start)

        if bfs(start, end, graph):
            edges_to_remove.append((start, end))
        else:
            graph[start].append(end)
            graph[end].append(start)

    return edges_to_remove

def bfs(start, end, graph):
    visited = set()
    queue = deque([start])

    while queue:
        node = queue.popleft()

        if node == end:
            return True

        if node in visited:
            continue

        visited.add(node)
        queue.extend(graph[node])

    return False

num_nodes = int(input())
graph = {}
edges = []

for _ in range(num_nodes):
    node, line = input().split(" -> ")
    children = line.split()
    graph[node] = children

    for child in children:
        edges.append((node, child))

edges_to_remove = break_cycles(graph, edges)

print(f"Edges to remove: {len(edges_to_remove)}")
for start, end in edges_to_remove:
    print(f"{start} - {end}")