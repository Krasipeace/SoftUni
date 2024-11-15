from collections import deque

def dfs(node, graph, visited, cycles, sorted_nodes):
    if node in cycles:
        raise Exception('Cycle has been detected. Invalid Topological sort!')
    
    if node in visited:
        return
    
    visited.add(node)
    cycles.add(node)

    for child in graph[node]:
        dfs(child, graph, visited, cycles, sorted_nodes)

    cycles.remove(node)
    sorted_nodes.appendleft(node)

nodes = int(input())
graph = {}

for _ in range(nodes):
    line_parts = input().split('->')
    node = line_parts[0].strip()
    children = line_parts[1].strip().split(', ') if line_parts[1] else []
    graph[node] = children

visited = set()
cycles = set()
sorted_nodes = deque()

for node in graph:
    dfs(node, graph, visited, cycles, sorted_nodes)

print(*sorted_nodes, sep=', ')