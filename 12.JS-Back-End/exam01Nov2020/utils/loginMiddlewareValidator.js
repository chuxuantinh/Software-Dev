const { body } = require('express-validator');

module.exports = [
    body('username', 'The username should be at least 5 characters!').isLength({min: 5}).isAlphanumeric(),
    body('password', 'The password should be at least 5 characters!').isLength({min: 5}).isAlphanumeric(),
];

