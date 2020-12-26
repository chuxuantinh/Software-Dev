function solve(array, string) {
    const obj = {
        asc: (a, b) => a - b,
        desc: (a, b) => b - a
    }
    return array.sort(obj[string]);
}