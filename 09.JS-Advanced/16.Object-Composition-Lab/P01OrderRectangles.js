function solution(data) {
    const recPrototype = {
        area() {
            return this.width * this.height;
        },
        compareTo(otherRec) {
            const currentRecArea = this.area();
            const otherRecArea = otherRec.area();
            return otherRecArea - currentRecArea  || otherRec.width - this.width;
            // return currentRecArea < otherRecArea ? -1 : currentRecArea === otherRecArea ? 0 : 1;
        }
    };
    function createRec(width, height) {
        const result = Object.create(recPrototype);
        result.width = width;
        result.height = height;
        return result;
    }
    return data.reduce(function(acc, [width, height]) {
        return acc.concat(createRec(width, height));
    }, []).sort((a, b) => a.compareTo(b));
}