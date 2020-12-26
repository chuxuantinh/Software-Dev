function solve(arr) {
    const step = Number(arr.pop());
    let result = [];
    for (let index = 0; index < arr.length; index += step) {
        result.push(arr[index]);
    }
    return result.join('\n');
}