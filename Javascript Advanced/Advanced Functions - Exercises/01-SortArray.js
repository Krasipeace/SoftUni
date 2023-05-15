function sortArray(array, method) {
    let ascendingComparator = (a, b) => a - b;

    let descendingComparator = (a, b) => b - a;

    let getSort = {
        'asc': ascendingComparator,
        'desc': descendingComparator
    };

    return array.sort(getSort[method]);
}