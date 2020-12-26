function solve(arr) {
    let bigger = arr[0];
    const result = [];
    arr.map(x => {
        if (x >= bigger) {
            result.push(x);
            bigger = x;
        }
    });
    return result.join('\n')
}