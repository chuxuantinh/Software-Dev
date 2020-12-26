function solve(matrix) {
    return matrix.reduce((acc, currRow, rowIndex) => {
        const count = currRow.reduce((acc, currItem, itemIndex) => {
            if (currItem === currRow[itemIndex + 1]) {
                acc += 1;
            }
            if (currItem === (matrix[rowIndex + 1] || [])[itemIndex]) {
                acc += 1;
            }
            return acc;
        }, 0);
        return acc + count;
    }, 0);
}