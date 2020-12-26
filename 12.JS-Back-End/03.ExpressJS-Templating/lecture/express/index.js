const express = require('express');
const path = require('path');

const app = express();

// function logRequestDate(req, res, next) {
//     console.log(new Date());
//     setTimeout(function() {
//         next();
//     }, 3000);
// }

const jsonBodyParser = express.json();

app.use('/static', express.static('./static'));

// app.use(logRequestDate);

app.get('/', function(req, res) {
    // res.end('HELLO FROM EXPRESS!');
    res.sendFile(path.resolve('./index.html'));
});

    
app.post('/', jsonBodyParser, function(req, res) {
    console.log(req.body);
    res.send(req.body);
});

app.listen(3000, function() {
    console.log('App is listening on :3000');
});