function printAggregatedTownIncome(params) {
    let arrowDelimiter = ' -> ';
    let colonDelimiter = ':';

    let stat = {};

    for (const row of params) {
        let [town, product, countAndPrice] = row.split(arrowDelimiter);
        let[soldCount, unitPrice] = countAndPrice.split(colonDelimiter)
            .map(e => Number(e));

        if (!stat[town]) {
            stat[town] = {};
        }

        if (!stat[town][product]) {
            stat[town][product] = 0;
        } 

        stat[town][product] += soldCount * unitPrice;
    }

    let result = '';
    for (const townName in stat) {
        result += `Town - ${townName}\n`;

        for (const productName in stat[townName]) {
            result += `$$$${productName} : ${stat[townName][productName]}\n`;
        }
    }

    console.log(result.trim());
}