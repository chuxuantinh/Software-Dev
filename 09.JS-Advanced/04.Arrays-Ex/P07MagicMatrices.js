function solve(matrix) {
    let isMagic = true;
    let sum = matrix[0].reduce((a, b) => a + b, 0);
    let currRowSum = 0;
    let currColSum = 0;

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            currRowSum += matrix[row][col];
        }
        if (currRowSum !== sum) {
            isMagic = false;
            break;
        } else {
            currRowSum = 0;
        }
    }

    for (let col = 0; col < matrix[0].length; col++) {
        for (let row = 0; row < matrix.length; row++) {
            currColSum += matrix[row][col];
        }
        if (currColSum !== sum) {
            isMagic = false;
            break;
        } else {
            currColSum = 0;
        }
    }

    console.log(isMagic);
}

solve([[4, 5, 6],
[6, 5, 4],
[5, 5, 5]]
);

function solve(input) {
    let sum = input[0].reduce((a, b) => a + b);
    let result = true;
    for (let i = 0; i < input.length; i++) {
        let row = input[i].reduce((a, b) => a + b);
        let column = input.map((n) => n[i]).reduce((a, b) => a + b);
        if (row != sum || column != sum) {
            result = false;
            break;
        }
    }
    console.log(result);
}