def calculate_salary(node, graph, salaries):
    if salaries[node] is not None:
        return salaries[node]
    
    if not graph[node]:
        salaries[node] = 1

        return 1

    salaries[node] = sum(calculate_salary(child, graph, salaries) for child in graph[node])

    return salaries[node]

nodes = int(input())
graph = []

for _ in range(nodes):
    graph.append([child for child, letter in enumerate(input().strip()) if letter == "Y"])

salaries = [None] * nodes
total_salary = sum(calculate_salary(node, graph, salaries) for node in range(nodes))

print(total_salary)