//P04 Largest Number
function largestNumber() {
    var args = Array.from(arguments);
    var max = args[0];
    for (var i = 1; i < args.length; i++) {
        if (max < args[i]) { max = args[i]; }
    }
    console.log(`The largest number is ${max}.`);
}

//P08 Aggregate Elements
function aggregateElements(items) {
    let sum = 0;
    let sum2 = 0;
    let concatResult = '';
    for (var i = 0; i < items.length; i++) {
        const currentItem = items[i];
        sum += currentItem;
        concatResult += currentItem;
        sum2 += 1 / currentItem;
    }
    console.log(sum);
    console.log(sum2);
    console.log(concatResult);
}

//P02 Math Operations
function solve(num1, num2, op) {
    // switch (op) {
    //     case '+': return num1 + num2;
    //     case '-': return num1 - num2;
    // }
    const cases = {
        '+': (a, b) => a + b,
        '-': (a, b) => a - b,
        '*': (a, b) => a * b,
        '/': (a, b) => a / b,
        '%': (a, b) => a % b,
        '**': (a, b) => a ** b,
    };
    console.log(cases[op](num1, num2));
}

//P01 String Length
function solve(arr1, arr2, arr3) {
    let sumLength;
    let averageLength;

    let firstArgumentLength = arr1.length;
    let secondArgumentLength = arr2.length;
    let thirdArgumentLength = arr3.length;

    sumLength = firstArgumentLength + secondArgumentLength + thirdArgumentLength;
    averageLength = Math.floor(sumLength / 3);

    console.log(sumLength);
    console.log(averageLength);
}

//P03 Sum of Numbers N…M
function solve(n, m) {
    let num1 = Number(n);
    let num2 = Number(m);

    let result = 0;

    for (let i = num1; i <= num2; i++) {
        result += i;
    }
    return result;
}

//P05 Circle Area
function solve(input) {
    let result;
    let inputType = typeof (input);
    if (inputType === 'number') {
        result = Math.pow(input, 2) * Math.PI;
        console.log(result.toFixed(2));
    }
    else {
        console.log(`We can not calculate the circle area, because we receive a ${inputType}.`);
    }
}

//P06Square of Stars
function solve(count = 5) {
    for (i = 1; i <= count; i++) {
        console.log("* ".repeat(count));
    }
}

//P06Square of Stars
function solve(count = 5) {
    for (i = 1; i <= count; i++) {
        let print = "";
        for (j = 1; j <= count; j++) {
            print += "* ";
        }
        console.log(print);
    }
}

//P07 day of week
function solve(input) {
    switch (input) {
        case 'Monday': return 1;
        case 'Tuesday': return 2;
        case 'Wednesday': return 3;
        case 'Thursday': return 4;
        case 'Friday': return 5;
        case 'Saturday': return 6;
        case 'Sunday': return 7;
        default: return 'error';
    }
}

//P09 Words Uppercase
function wordUpperCase(input) {
    return input.match(/\w+/gim).map(x => x.toUpperCase()).join(', ');
}