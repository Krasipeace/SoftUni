from collections import deque
from queue import PriorityQueue

class Edge:
    def __init__(self, source, destination, weight):
        self.source = source
        self.destination = destination
        self.weight = weight

    def __gt__(self, other):
        return self.weight > other.weight

def get_reliability(start_node, end_node, graph, parent, reliability):
    reliability[start_node] = 100

    pq = PriorityQueue()
    pq.put((-100, start_node))

    while not pq.empty():
        max_reliability, node = pq.get()
        if node == end_node:
            break
        for edge in graph[node]:
            child = edge.destination
            new_reliability = -max_reliability * edge.weight / 100
            if new_reliability > reliability[child]:
                reliability[child] = new_reliability
                parent[child] = node
                pq.put((-new_reliability, edge.destination))

    return reliability[end_node]

def reconstruct_path(end_node, parent):
    path = deque()
    node = end_node
    while node is not None:
        path.appendleft(node)
        node = parent[node]

    return path

nodes_count = int(input())
edges_count = int(input())
graph = []
[graph.append([]) for _ in range(nodes_count)]

for _ in range(edges_count):
    source, destination, weight = [int(x) for x in input().split()]
    edge = Edge(source, destination, weight)
    graph[source].append(Edge(source, destination, weight))
    graph[destination].append(Edge(destination, source, weight))

start_node = int(input())
end_node = int(input())
reliability = [float("-inf")] * nodes_count
parent = [None] * nodes_count
path_reliability = get_reliability(start_node, end_node, graph, parent, reliability)
path = reconstruct_path(end_node, parent)

print(f"Most reliable path reliability: {path_reliability:.2f}%")
print(*path, sep=" -> ")