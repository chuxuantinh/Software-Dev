function solve() {
    function fighter(name) {
        const instance = {
            name,
            health: 100,
            stamina: 100,
            fight
        };

        function fight() {
            instance.stamina--;
            console.log(`${instance.name} slashes at the foe!`);
        }

        return instance;
    }

    function mage(name) {
        const instance = {
            name,
            health: 100,
            mana: 100,
            cast
        };

        function cast(spell) {
            instance.mana--;
            console.log(`${instance.name} cast ${spell}`);
        }

        return instance;
    }

    return {
        fighter,
        mage
    };
}

// 2
function solve() {
    const fighterProto = {
        fight
    };

    function fight() {
        this.stamina--;
        console.log(`${this.name} slashes at the foe!`);
    }

    function fighter(name) {
        const instance = Object.create(fighterProto);
        Object.assign(instance, {
            name,
            health: 100,
            stamina: 100
        });
        return instance;
    }

    const mageProto = {
        cast
    };

    function cast(spell) {
        this.mana--;
        console.log(`${this.name} cast ${spell}`);
    }

    function mage(name) {
        const instance = Object.create(mageProto);
        Object.assign(instance, {
            name,
            health: 100,
            mana: 100,
        });
        return instance;
    }

    return {
        fighter,
        mage
    };
}