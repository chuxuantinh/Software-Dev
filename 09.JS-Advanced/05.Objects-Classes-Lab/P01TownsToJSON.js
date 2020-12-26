// const isNotEmptyString = x => x !== "";
// const trimMyStrings = x => x.trim();
// const parseIfNumber = x => Number(x) ? Math.floor(Number(x) * 100) / 100 : x;

// function deserializeStringToArrayOfValues(str) {
//     return str
//             .split('|')
//             .filter(x => x !== "")
//             .map(x => x.trim())
//             .map(x => Number(x) ? Math.floor(Number(x) * 100) / 100 : x);
// }

function solve(data) {
    let keys = data[0]
                    .split('|')
                    .filter(x => x !== "")
                    .map(x => x.trim())
                    .map(x => Number(x) ? Math.floor(Number(x) * 100) / 100 : x);
    return data
            .slice(1)
            .map(x => x.split('|')
                        .filter(x => x !== "")
                        .map(x => x.trim())
                        .map(x => Number(x) ? Math.floor(Number(x) * 100) / 100 : x))
            .map(x => x.reduce((res, val, i) => {
                res[keys[i]] = val;
                return res;
            }, {}));
}

console.log(solve(['| Town | Latitude | Longitude |',
'| Sofia | 42.696552 | 23.32601 |',
'| Beijing | 39.913818 | 116.363625 |']
));