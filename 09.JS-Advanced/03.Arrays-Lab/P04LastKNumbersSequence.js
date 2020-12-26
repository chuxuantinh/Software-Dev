function solve(n, k) {
    const res = [1];
    let sum = 0; 
    for (let i = 1; i < n; i++) {
        for (let j = i - 1; j >= i - k; j--) {
            if (j >= 0) {
                sum += res[j];
            }
            
        }
        res.push(sum);
        sum = 0; 
    }
    console.log(res.join(' '));
}

solve(6, 3)