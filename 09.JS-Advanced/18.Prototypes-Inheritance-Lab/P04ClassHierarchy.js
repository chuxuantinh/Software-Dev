function solution() {

    class Figure {
        constructor(units = 'cm') {
            this.units = units;
        }
        changeUnits(newUnits) {
            this.units = newUnits;
        }

        transformMetric(valInCM) {
            return this.units === 'm' ? valInCM / 100 : this.units === 'mm' ? valInCM * 10 : valInCM;
        }

        get area() {
            throw new Error('Not implemented!');
        }

        toString() {
            return `Figures units: ${this.units} Area: ${this.area}`;
        }
    }

    class Circle extends Figure {
        constructor(radius, units) {
            super(units);
            this.radius = radius;
        }

        get area() {
            const radius = this.transformMetric(this.radius);
            return Math.PI * radius * radius;
        }

        toString() {
            const r = this.transformMetric(this.radius);
            return `${super.toString()} - radius: ${r}`;
        }
    }

    class Rectangle extends Figure {
        constructor(width, height, units) {
            super(units);
            this.width = width;
            this.height = height;
        }

        get area() {
            const width = this.transformMetric(this.width);
            const height = this.transformMetric(this.height);
            return height * width;
        }

        toString() {
            const width = this.transformMetric(this.width);
            const height = this.transformMetric(this.height);
            return `${super.toString()} - width: ${width}, height: ${height}`;
        }
    }

    return {
        Figure,
        Circle,
        Rectangle
    };
}