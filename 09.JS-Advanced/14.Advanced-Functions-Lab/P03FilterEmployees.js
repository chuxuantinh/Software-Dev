function solution(string, criteria) {
    const data = JSON.parse(string);
    let propName, propValue;
    const isNotAll = criteria !== 'all';
    if (isNotAll) {
        [propName, propValue] = criteria.split('-');
    }
    data.filter(function(i) {
        return isNotAll ? i[propName] === propValue : true;
    }).forEach((item, i) => {
        console.log(`${i}. ${item.first_name} ${item.last_name} - ${item.email}`);
    });
}