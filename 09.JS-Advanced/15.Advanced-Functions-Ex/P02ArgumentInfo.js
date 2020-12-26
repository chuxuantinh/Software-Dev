function solve() {
    const argTypes = [];
    const index = {};
    for (let arg of arguments) {
        const type = typeof arg;
        console.log(`${type}: ${arg}`);
        let argIndex = index[type];
        if (argIndex === undefined) {
            argIndex = argTypes.length;
            argTypes.push({
                type,
                count: 0
            });
            index[type] = argIndex;
        }
        argTypes[argIndex].count++;
    }
    argTypes.sort((a, b) => b.count - a.count).forEach(e => console.log(`${e.type} = ${e.count}`));
}