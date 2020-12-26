const express = require('express');
const path = require('path');
const handlebars = require('express-handlebars');

const app = express();

// function logRequestDate(req, res, next) {
//     console.log(new Date());
//     setTimeout(function() {
//         next();
//     }, 3000);
// }

const jsonBodyParser = express.json();
const urlEncodedBodyParser = express.urlencoded({ extended: true });

const users = [
    { name: 'Ivan', age: 20 },
    { name: 'Stefan', age: 30 },
];

app.engine('.hbs', handlebars({
    extname: '.hbs'
}));
app.set('view engine', '.hbs');

app.use(jsonBodyParser);

app.use('/static', express.static('./static'));

// app.use(logRequestDate);

app.get('/', function(req, res) {
    // res.end('HELLO FROM EXPRESS!');
    // res.sendFile(path.resolve('./index.html'));
    res.render('home', { users }); // layout: false
});

app.get('/user/:idx', function(req, res) {
    const selectedUser = users[req.params.idx];
    res.render('home', { users, selectedUser, selectedUserIndex: req.params.idx });
});

app.post('/user/:idx', urlEncodedBodyParser, function(req, res) {
    const { name, age } = req.body; // body empty?
    users[req.params.idx] = { name, age: +age };
    res.redirect('/');
});

app.post('/user', urlEncodedBodyParser, function(req, res) {
    const { name, age } = req.body;
    users.push({ name, age: +age });
    res.redirect('/');
});

app.get('/about', function(req, res) {
    
    res.render('about', { test: 123 });
});
    
app.post('/', function(req, res) {
    console.log(req.body);
    res.send(req.body);
});

app.listen(3000, function() {
    console.log('App is listening on :3000');
});