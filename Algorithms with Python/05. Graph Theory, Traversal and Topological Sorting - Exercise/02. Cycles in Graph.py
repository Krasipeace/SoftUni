from collections import deque

def is_acyclic(edges):
    graph = {}
    incoming_edges = {}
    vertices = set()

    for start, end in edges:
        if start not in graph:
            graph[start] = []
        
        graph[start].append(end)

        if end not in incoming_edges:
            incoming_edges[end] = 0

        incoming_edges[end] += 1
        vertices.add(start)
        vertices.add(end)

        if start not in incoming_edges:
            incoming_edges[start] = 0

    queue = deque([v for v in vertices if incoming_edges[v] == 0])
    count = 0

    while queue:
        vertex = queue.popleft()
        count += 1

        for neighbor in graph.get(vertex, []):
            incoming_edges[neighbor] -= 1

            if incoming_edges[neighbor] == 0:
                queue.append(neighbor)

    return count == len(vertices)

graph_edges = [tuple(edge.split('-')) for edge in iter(input, 'End')]

if is_acyclic(graph_edges):
    print("Acyclic: Yes")
else:
    print("Acyclic: No")