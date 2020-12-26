const express = require('express');
const cookieParser = require('cookie-parser');
const COOKIE_NAME = 'COOKIE_NAME';
const uuid = require('uuid');
const session = require('express-session');
var jwt = require('jsonwebtoken');
const TOKEN_KEY = 'TOKEN_KEY';
const secret = 'secret';

const sessionStore = {

};

function session(config) {
    return function (req, res, next) {
        if (!req.cookies[COOKIE_NAME]) {
            const id = uuid.v1();
            sessionStore[id] = {};
            res.cookie(COOKIE_NAME, id, { httpOnly: config ? !!config.httpOnly : false });
            req.session = sessionStore[id];
        } else {
            const id = req.cookies[COOKIE_NAME];
            req.session = sessionStore[id];
        }
        next();
    };
}

function jwtSession(config) {
    return function (req, res, next) {
        let token = req.cookies[TOKEN_KEY] || req.headers[TOKEN_KEY];
        if (!token) {
            req.session = {};
            function setToken(cb) {
                jwt.sign(req.session, secret, config, (err, token) => {
                    if (err) {
                        next(err);
                        return;
                    }
                    res.cookie(TOKEN_KEY, token);
                    res.set(TOKEN_KEY, token);
                    cb();
                });
            }
            const originalSend = res.send;
            res.send = function(...args) {
                setToken();
                originalWrite.apply(res, args);
            };
            res.write = function(...args) {
                setToken(() => {
                    originalSend.apply(res, args);
                });
            };
            res.on();
            next();
            return;
        }
        jwt.verify(token, secret, function(err, decoded) {
            req.session = decoded;
            next();
        });

    }
}

const app = express();
app.use(cookieParser());
app.use(jwtSession());
app.use(session({ httpOnly: true, secret: '123' }));

app.get('/', function (req, res) {
    req.session.value = 123;
    res.send('HOME');
});

app.get('/about', function (req, res) {
    console.log(req.session);
    res.send('ABOUT');
});

app.listen(3000, function () {
    console.log('Server is listening on 3000');
});