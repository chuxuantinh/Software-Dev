function solve(arr) {
    arr.sort(compareNumbers);
    function compareNumbers(a, b) { return a - b; }
    console.log(arr.slice(0, 2).join(' '));
}