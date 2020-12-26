function solve(input) {
    const rows = [];
    for (let line of input) {
        const person = JSON.parse(line);
        rows.push(`\t<tr>\n\t\t<td>${person.name}</td>\n\t\t<td>${person.position}</td>\n\t\t<td>${person.salary}</td>\n\t</tr>`);
    }
    console.log('<table>');
    console.log(rows.join('\n'));
    console.log('</table>');
}
