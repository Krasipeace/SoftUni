def find_paths(row, col, direction, lab, path):
    if not is_inbound(lab, row, col):
        return

    path.append(direction)

    if is_exit(lab, row, col):
        print_path(path)
    elif is_free(lab, row, col):
        mark(lab, row, col, 'v')
        find_paths(row, col + 1, 'R', lab, path)
        find_paths(row, col - 1, 'L', lab, path)
        find_paths(row + 1, col, 'D', lab, path)
        find_paths(row - 1, col, 'U', lab, path)
        mark(lab, row, col, '-')
    
    path.pop()

def is_inbound(lab, row, col):
    return 0 <= row < len(lab) and 0 <= col < len(lab[0])

def is_exit(lab, row, col):
    return lab[row][col] == 'e'

def is_free(lab, row, col):
    return lab[row][col] == '-'

def mark(lab, row, col, value):
    lab[row][col] = value

def print_path(path):
    print(''.join(path[1:]))

def read_lab():
    rows = int(input())
    cols = int(input()) # python magic here
    
    labyrinth = [list(input().strip()) for _ in range(rows)]
    return labyrinth

lab = read_lab()
find_paths(0, 0, '', lab, [])
