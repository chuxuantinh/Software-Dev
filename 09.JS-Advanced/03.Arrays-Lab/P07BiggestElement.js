function solve(matrix) {
    const arr = matrix.flat();
    arr.sort(compareNumbers);
    function compareNumbers(a, b) { return b - a; }
    console.log(arr.slice(0, 1).join(' '));
}