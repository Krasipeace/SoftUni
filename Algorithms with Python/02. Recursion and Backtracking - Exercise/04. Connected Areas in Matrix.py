class Area:
    def __init__(self, row, col, size):
        self.row = row
        self.col = col
        self.size = size

def read_matrix(rows, cols):
    matrix = []
    for _ in range(rows):
        matrix.append(list(input()))
    return matrix

def is_valid_cell(row, col, matrix):
    return 0 <= row < len(matrix) and 0 <= col < len(matrix[0]) and matrix[row][col] == '-'

def explore_area(row, col, matrix):
    if not is_valid_cell(row, col, matrix):
        return 0

    matrix[row][col] = 'v'
    size = 1
    size += explore_area(row - 1, col, matrix)
    size += explore_area(row + 1, col, matrix)
    size += explore_area(row, col - 1, matrix)
    size += explore_area(row, col + 1, matrix)
    return size

def find_areas(matrix):
    areas = []
    for row in range(len(matrix)):
        for col in range(len(matrix[0])):
            size = explore_area(row, col, matrix)
            if size > 0:
                areas.append(Area(row, col, size))
    return areas

def print_results(areas):
    print(f'Total areas found: {len(areas)}')
    for index, area in enumerate(sorted(areas, key=lambda a: a.size, reverse=True)):
        print(f'Area #{index + 1} at ({area.row}, {area.col}), size: {area.size}')

rows = int(input())
cols = int(input())
matrix = read_matrix(rows, cols)
areas = find_areas(matrix)
print_results(areas)