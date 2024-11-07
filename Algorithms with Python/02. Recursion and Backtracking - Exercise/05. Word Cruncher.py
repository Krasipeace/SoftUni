def read_data():
    words = input().split(", ")
    target = input()
    words_by_index = {}
    words_count = {}
    
    return words,target,words_by_index,words_count

def evaluate_syllables(target, words_by_index, word):
    try: 
        index = 0
        while True:
            index = target.index(word, index)
            
            if index not in words_by_index:
                words_by_index[index] = []
            words_by_index[index].append(word)
            index += len(word)
    except ValueError:
        pass

def find_syllables_rec(index, target, words_by_index, words_count, used_words):
    if index >= len(target):
        print(' '.join(used_words))

    if index not in words_by_index:
        return
    
    for word in words_by_index[index]:
        if words_count[word] == 0:
            continue

        used_words.append(word)
        words_count[word] -= 1

        find_syllables_rec(index + len(word), target, words_by_index, words_count, used_words)

        used_words.pop()
        words_count[word] += 1

words, target, words_by_index, words_count = read_data()

for word in words:
    if word in words_count:
        words_count[word] += 1
        continue
    
    words_count[word] = 1
    
    evaluate_syllables(target, words_by_index, word)

find_syllables_rec(0, target, words_by_index, words_count, [])