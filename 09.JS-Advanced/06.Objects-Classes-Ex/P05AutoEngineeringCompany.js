function solve(input) {
    let brandMark = {};
    let markCars = {};
    for(let line of input){
        let [mark, model, cars] = line.split(' | ');
        if(!brandMark.hasOwnProperty(mark)){
            brandMark[mark] = [];
        }
        if(!brandMark[mark].includes(model)){
            brandMark[mark].push(model);
        }
        if(!markCars.hasOwnProperty(model)){
            markCars[model] = 0;
        }
        markCars[model] += Number(cars); 
    }
    Object.keys(brandMark).forEach(element => {
        console.log(element);
        for(let i of brandMark[element]){
            console.log(`###${i} -> ${markCars[i]}`);
        }
    });
}