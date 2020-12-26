function getFibonator() {
    let current = 0;
    let next = 1;

    function fibonator() {
        let newNumber = current + next;
        current = next;
        next = newNumber;
        return current;
    };

    return fibonator;
}