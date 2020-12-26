function solve(arr) {
    const res = [];
    for (let i = 0; i < arr.length; i++) {
        if (arr[i] < 0) {
            res.unshift(arr[i])
        } else {
            res.push(arr[i])
        };
    }
    res.forEach(item => console.log(item));
}