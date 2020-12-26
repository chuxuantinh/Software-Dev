function solve() {
    class Balloon {
        constructor(color, gasWeight) {
            this.color = color;
            this.gasWeight = gasWeight;
        }
    }

    class PartyBalloon extends Balloon {
        constructor(color, gasWeight, ribbonColor, ribbonLength) {
            super(color, gasWeight);
            this._ribbon = {
                color: ribbonColor,
                length: ribbonLength
            };
        }

        get ribbon() {
            return this._ribbon;
        }
    }

    class BirthdayBalloon extends PartyBalloon {
        constructor(color, gasWeight, ribbonColor, ribbonLength, text) {
            super(color, gasWeight, ribbonColor, ribbonLength);
            this._text = text;
        }

        get text() {
            return this._text;
        }
    }

    return {
        Balloon,
        PartyBalloon,
        BirthdayBalloon
    };
}

// Private ribbon
function solve() {
    class Balloon {
        constructor(color, gasWeight) {
            this.color = color;
            this.gasWeight = gasWeight;
        }
    }

    class PartyBalloon extends Balloon {
        constructor(color, gasWeight, ribbonColor, ribbonLength) {
            super(color, gasWeight);
            const _ribbon = {
                color: ribbonColor,
                length: ribbonLength
            };
            Object.defineProperty(this, 'ribbon', {
                get: () => _ribbon
            });
        }
    }

    class BirthdayBalloon extends PartyBalloon {
        constructor(color, gasWeight, ribbonColor, ribbonLength, text) {
            super(color, gasWeight, ribbonColor, ribbonLength);
            this._text = text;
        }

        get text() {
            return this._text;
        }
    }

    return {
        Balloon,
        PartyBalloon,
        BirthdayBalloon
    };
}

// 2
function solve() {
    function Balloon(color, gasWeight) {
        this.color = color;
        this.gasWeight = gasWeight;
    }

    function PartyBalloon(color, gasWeight, ribbonColor, ribbonLength) {
        Balloon.call(this, color, gasWeight);
        this._ribbon = {
            color: ribbonColor,
            length: ribbonLength
        };

    }

    // Object.setPrototypeOf(PartyBalloon, Balloon);
    // Object.setPrototypeOf(PartyBalloon.prototype, Balloon.prototype);
    PartyBalloon.prototype = Object.create(Balloon.prototype);
    PartyBalloon.prototype.constructor = PartyBalloon;

    Object.defineProperty(PartyBalloon.prototype, 'ribbon', {
        get: function () { return this._ribbon; }
    });

    function BirthdayBalloon(color, gasWeight, ribbonColor, ribbonLength, text) {
        PartyBalloon.call(this, color, gasWeight, ribbonColor, ribbonLength);
        this._text = text;
    }

    // Object.setPrototypeOf(BirthdayBalloon, PartyBalloon);
    // Object.setPrototypeOf(BirthdayBalloon.prototype, PartyBalloon.prototype);
    BirthdayBalloon.prototype = Object.create(PartyBalloon.prototype);
    BirthdayBalloon.prototype.constructor = BirthdayBalloon;

    Object.defineProperty(BirthdayBalloon.prototype, 'text', {
        get: function () { return this._text; }
    });


    return {
        Balloon,
        PartyBalloon,
        BirthdayBalloon
    };
}