const { User } = require('../models');
const { jwt, formValidator } = require('../utils');
const { cookie } = require('../config');


module.exports = {
    get: {
        login(req, res, next) {
            res.render('./user/login.hbs')
        },
        register(req, res, next) {
            res.render('./user/register.hbs')
        },
        logout(req, res, next) {
            res
                .clearCookie(cookie)
                .redirect('/home/');
        }
    },

    post: {
        register(req, res, next) {
            const formValidations = formValidator(req);

            if (!formValidations.isOK) {
                res.render('./user/register.hbs', formValidations.contextOptions);
                return;
            }

            const { username, password } = { ...req.body };

            User
                .findOne({ username })
                .then((user) => {
                    if (user) {
                        throw new Error('The given email is already in use...');
                    }
                    return User.create({ username, password })
                })
                .then((createdUser) => {
                    res.redirect('/user/login');
                })
                .catch((e) => {
                    console.log(e);
                    res.redirect('/user/register');
                });
        },

        login(req, res, next) {

            const formValidations = formValidator(req);

            if (!formValidations.isOK) {
                res.render('./user/login.hbs', formValidations.contextOptions);
                return;
            }

            const { username, password } = req.body;

            User
                .findOne({ username })
                .then((user) => {
                    return Promise.all([
                        user.comparePasswords(password),
                        user,
                    ])
                })
                .then(([isPasswordsMatched, user]) => {
                    if (!isPasswordsMatched) {
                        throw new Error('The provided password does not matched.');
                    }

                    const token = jwt.createToken(user._id);

                    res
                        .status(200)
                        .cookie(cookie, token, { maxAge: 3600000 })
                        .redirect('/courses/all');

                })
                .catch((e) => {
                    console.log(e);
                })
        }
    }
};
