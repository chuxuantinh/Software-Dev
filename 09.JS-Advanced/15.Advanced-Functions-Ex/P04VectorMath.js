// Not working
function solution() {
    function add(a, b) {
        return [a[0] + b[0], a[1] + b[1]];
    }

    function multiply(a, s) {
        return [a[0] * s, a[1] * s];
    }

    function length(a) {
        return Math.sqrt(a[0] * a[0] + a[1] * a[1]);
    }

    function dot(a, b) {
        return a[0] * b[0] + a[1] * b[1];
    }

    function cross(a, b) {
        return a[0] * b[1] - a[1] * b[0];
    }

    return {
        add,
        multiply,
        length,
        dot,
        cross
    };
}

// 2 Not working
let solution = (() => {
    return {
        add: (v1, v2) => [v1[0] + v2[0], v1[1] + v2[1]],
        multiply: (v1, num) => [v1[0] * num, v1[1] * num],
        length: (v1) => Math.sqrt(v1[0] * v1[0] + v1[1] * v1[1]),
        dot: (v1, v2) => v1[0] * v2[0] + v1[1] * v2[1],
        cross: (v1, v2) => v1[0] * v2[1] - v1[1] * v2[0]
    }
})();