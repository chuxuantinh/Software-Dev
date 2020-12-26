function solve(array) {
    let info = [];
    for (let line of array) {
        let [name, level, items] = line.split(' / ');
        items ? items = items.split(', ') : items = [];
        let heroInfo = {
            name: name,
            level: Number(level),
            items: items
        };
        info.push(heroInfo);
    }
    console.log(JSON.stringify(info));
}