function Person(firstName, lastName) {
    this.firstName = firstName;
    this.lastName = lastName;

    Object.defineProperty(this, 'fullName', {
        set(newFullName) {
            const nameArray = newFullName.split(' ');
            if (nameArray.length !== 2) { return; }
            this.firstName = nameArray[0];
            this.lastName = nameArray[1];
        },
        get() {
            return this.firstName + ' ' + this.lastName;
        }
    });
}