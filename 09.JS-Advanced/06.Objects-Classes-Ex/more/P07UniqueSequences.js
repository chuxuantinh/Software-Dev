function solve(input) {
    let arrays = [];
    for (let line of input) {
        let arr = JSON.parse(line)
            .sort((a, b) => b - a);
        arrays.push(arr);
    }
    let filteredArrays = new Set(arrays
        .sort((a, b) => a.length - b.length)
        .map((arr) => arr.join(', ')));
    let result = [...filteredArrays];
    for(let i of result){
        console.log(`[${i}]`)
    }
}