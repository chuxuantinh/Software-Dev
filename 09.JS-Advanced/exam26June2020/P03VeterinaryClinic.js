class VeterinaryClinic {
    constructor(clinicName, capacity) {
        this.clinicName = clinicName;
        this.capacity = Number(capacity);
        this.clients = [];
        this.totalProfit = 0;
        this.currentWorkload = 0;
    }

    newCustomer(ownerName, petName, kind, procedures) {
        if (this.capacity <= this.currentWorkload) {
            throw new Error('Sorry, we are not able to accept more patients!');
        }

        if (this.clients.filter(o => o['ownerName'] === ownerName).length > 0
            && this.clients.filter(o => o['ownerName'] === ownerName)[0]['pets'].length > 0
            && this.clients.filter(o => o['ownerName'] === ownerName)[0]['pets'].filter(p => p['petName'] === petName).length > 0
            && this.clients.filter(o => o['ownerName'] === ownerName)[0]['pets'].filter(p => p['petName'] === petName)[0]['procedures'].length > 0) {
            throw new Error(`This pet is already registered under ${ownerName} name! ${petName} is on our lists, waiting for ${pet.procedures.join(', ')}.`);
        }

        if (this.clients.filter(o => o['ownerName'] === ownerName).length === 0) {
            const owner = {};
            owner['ownerName'] = ownerName;
            owner['pets'] = [];
            const pet = {
                'petName': petName,
                'kind': kind,
                'procedures': procedures
            };
            owner['pets'].push(pet);
            this.clients.push(owner);
            this.currentWorkload++;
            return `Welcome ${petName}!`;
        } else {
            const pet = {
                'petName': petName,
                'kind': kind,
                'procedures': procedures
            };
            const owner = this.clients.filter(o => o['ownerName'] === ownerName)[0];
            owner['pets'].push(pet);
            
            this.currentWorkload++;
            return `Welcome ${petName}!`;
        }
    }

    onLeaving(ownerName, petName) {
        if (this.clients.filter(o => o['ownerName'] === ownerName).length === 0) {
            throw new Error('Sorry, there is no such client!');
        }

        if (this.clients.filter(o => o['ownerName'] === ownerName)[0]['pets'].length === 0
            || (this.clients.filter(o => o['ownerName'] === ownerName)[0]['pets'].length > 0
                && this.clients.filter(o => o['ownerName'] === ownerName)[0]['pets'].filter(p => p['petName'] === petName).length === 0)
            || (this.clients.filter(o => o['ownerName'] === ownerName)[0]['pets'].length > 0
                && this.clients.filter(o => o['ownerName'] === ownerName)[0]['pets'].filter(p => p['petName'] === petName).length > 0
                && this.clients.filter(o => o['ownerName'] === ownerName)[0]['pets'].filter(p => p['petName'] === petName)[0]['procedures'].length === 0)) {
            throw new Error(`Sorry, there are no procedures for ${petName}!`);
        }

        const numberOfProcedures = this.clients.filter(o => o['ownerName'] === ownerName)[0]['pets'].filter(p => p['petName'] === petName)[0]['procedures'].length;
        this.totalProfit += numberOfProcedures * 500;
        this.currentWorkload--;
        this.clients.filter(o => o['ownerName'] === ownerName)[0].pets.filter(p => p['petName'] === petName)[0]['procedures'] = [];//?

        return `Goodbye ${petName}. Stay safe!`;
    }

    toString() {
        const result = [];
        let numberOfPets = 0;
        this.clients.forEach(o => o.pets.forEach(p => {
            if(p.procedures.length > 0) {
                numberOfPets++;
            }
        }));
        const percentage = Math.floor(numberOfPets / this.capacity * 100);
        result.push(`${this.clinicName} is ${percentage}% busy today!`);
        result.push(`Total profit: ${this.totalProfit.toFixed(2)}$`);
        const owners = this.clients.slice();
        owners.sort((a, b) => a.ownerName.localeCompare(b.ownerName));
        owners.forEach(o => {
            result.push(`${o.ownerName} with:`);
            const pets = o.pets.slice();
            pets.sort((a, b) => a.petName.localeCompare(b.petName));
            pets.forEach(p => result.push(`---${p.petName} - a ${p.kind.toLowerCase()} that needs: ${p.procedures.join(', ')}`));
        });

        return result.join('\n');
    }
}

let clinic = new VeterinaryClinic('SoftCare', 10);
console.log(clinic.newCustomer('Jim Jones', 'Tom', 'Cat', ['A154B', '2C32B', '12CDB']));
console.log(clinic.newCustomer('Anna Morgan', 'Max', 'Dog', ['SK456', 'DFG45', 'KS456']));
console.log(clinic.newCustomer('Jim Jones', 'Tiny', 'Cat', ['A154B']));
console.log(clinic.onLeaving('Jim Jones', 'Tiny'));
console.log(clinic.toString());
clinic.newCustomer('Jim Jones', 'Sara', 'Dog', ['A154B']);
console.log(clinic.toString());
