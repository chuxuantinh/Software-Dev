//P01 Fruit
function solve(fruit, weightInGrams, price) {
    const weightInKilos = weightInGrams / 1000;
    const total = weightInKilos * price;
    //console.log('I need $' + total.toFixed(2) + ' to buy ' + weightInKilos.toFixed(2) + ' kilograms ' + fruit + '.');
    console.log(`I need $${total.toFixed(2)} to buy ${weightInKilos.toFixed(2)} kilograms ${fruit}.`);
}

//P02 Greatest Common Divisor - GCD
function solve(a, b) {
    const small = Math.min(a, b);
    let gcd = 1;
    for (let i = 1; i <= small; i++) {
        if (a % i == 0 && b % i == 0) {
            gcd = i;
        }
    }
    console.log(gcd);
}

//P02 Greatest Common Divisor - GCD
function solve(a, b) {
    let small = Math.min(a, b);
    let large = Math.max(a, b);
    let remainder = 1;

    do {
        remainder = large % small;
        large = small;
        small = remainder;
    } while (remainder !== 0);

    console.log(large);
}

//P03 Same numbers
function solve(num) {
    const numAsText = num.toString();
    let same = true;
    let sum = 0;
    for (let i = 0; i < numAsText.length; i++) {
        if (i < numAsText.length - 1) {
            if (numAsText[i] != numAsText[i + 1]) {
                same = false;
            }
        }
        sum += Number(numAsText[i]);
    }
    console.log(same);
    console.log(sum);
}

//P04 Time to walk
function solve(steps, footprint, speed) {
    const dist = steps * footprint;
    let time = Math.round(dist / speed * 3.6);
    time += Math.floor(dist / 500) * 60;
    const seconds = time % 60;
    time -= seconds;
    const minutes = (time / 60) % 60;
    time -= minutes * 60;
    const hours = time / 3600;
    console.log(`${pad(hours)}:${pad(minutes)}:${pad(seconds)}`);

    function pad(num) {
        if (num < 10) {
            return '0' + num;
        } else {
            return '' + num;
        }
    }
}

//P04 Time to walk
function solve(steps, footprint, speed) {
    const dist = steps * footprint;
    let time = Math.round(dist / speed * 3.6);
    time += Math.floor(dist / 500) * 60;
    const seconds = time % 60;
    time -= seconds;
    const minutes = (time / 60) % 60;
    time -= minutes * 60;
    const hours = time / 3600;
    console.log(`${pad(hours)}:${pad(minutes)}:${pad(seconds)}`);

    function pad(num) {
        return ('0' + num).slice(-2);
    }
}

//P05 Road radar
function solve([speed, area]) {
    let overLimit = 0;

    switch (area) {
        case 'motorway':
            overLimit = speed - 130;
            break;
        case 'interstate':
            overLimit = speed - 90;
            break;
        case 'city':
            overLimit = speed - 50;
            break;
        case 'residential':
            overLimit = speed - 20;
            break;
    }

    if (overLimit > 40) {
        console.log('reckless driving');
    } else if (overLimit > 20) {
        console.log('excessive speeding');
    } else if (overLimit > 0) {
        console.log('speeding');
    }
}

//P06 Cooking by numbers
function solve([num, ...params]) {
    num = Number(num);
    for (let cmd of params) {
        switch (cmd) {
            case 'chop':
                num /= 2;
                break;
            case 'dice':
                num = Math.sqrt(num);
                break;
            case 'spice':
                num += 1;
                break;
            case 'bake':
                num *= 3;
                break;
            case 'fillet':
                num *= 0.8;
                break;
        }
        console.log(num);
    }
}

//P08 Calorie Object
function solve(params) {
    const calorie = {};
    for (let i = 0; i < params.length; i+= 2) {
        const propName = params[i];
        const value = Number(params[i + 1]);
        calorie[propName] = value;
    }
    console.log(calorie);
}

//P07 Validity Checker
function solve([x1, y1, x2, y2]) {
    isValid(x1, y1, 0, 0);
    isValid(x2, y2, 0, 0);
    isValid(x1, y1, x2, y2);

   

    function isValid(x1, y1, x2, y2) {
        let distH = x1 - x2;
        let distY = y1 - y2;
        const dist = Math.sqrt(distH ** 2 + distY ** 2);

        if (Number.isInteger(dist)) {
            console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
        } else {
            console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
        }
    }
}