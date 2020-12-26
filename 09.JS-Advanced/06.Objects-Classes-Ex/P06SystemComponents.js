function solve(input) {
    const catalog = {};
    for (let line of input) {
        const[system, component, sub] = line.split(' | ');
        if (catalog.hasOwnProperty(system) === false) {
            catalog[system] = {};
        }
        if (catalog[system].hasOwnProperty(component) === false) {
            catalog[system][component] = [];
        }
        catalog[system][component].push(sub);
    }
    Object.entries(catalog).sort((a, b) => {
        return Object.keys(b[1]).length - Object.keys(a[1]).length || a[0].localeCompare(b[0]);
    }).forEach(([system, component]) => {
        console.log(system);
        Object.entries(component)
            .sort((a, b) => b[1].length - a[1].length)
            .forEach(([name, sub]) => {
                console.log("|||" + name);
                sub.forEach(s => {
                    console.log('||||||' + s);
                });
            });
    });
}