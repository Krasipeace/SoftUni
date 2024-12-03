from collections import deque

def find_path_size(source, destination, graph):
    queue = deque([source])
    visited = {source}
    parent = {destination: None}

    while queue:
        node = queue.popleft()
        if node == destination:
            break

        for child in graph[node]:
            if child not in visited:
                visited.add(child)
                queue.append(child)
                parent[child] = node

    if parent[destination] is None:
        return -1
    else:
        size = 0
        if parent[destination] is not None:
            node = destination
            while node in parent:
                node = parent[node]
                size += 1

    return size

nodes = int(input())
pairs = int(input())
graph = {}

for _ in range(nodes):
    node, edges_str = input().split(":")
    graph[node] = edges_str.split() if edges_str else []

for _ in range(pairs):
    source, destination = input().split("-")
    size = find_path_size(source, destination, graph)
    print(f"{{{source}, {destination}}} -> {size}")
