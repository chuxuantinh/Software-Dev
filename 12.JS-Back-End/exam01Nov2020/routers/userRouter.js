const { userController } = require('../controllers');
const { registerMiddlewareValidator, loginMiddlewareValidator, isAuthNeededMiddleware } = require('../utils');

module.exports = (router) => {
    router.get('/login', isAuthNeededMiddleware(), userController.get.login);
    router.get('/register', isAuthNeededMiddleware(), userController.get.register);
    router.get('/logout',isAuthNeededMiddleware(true), userController.get.logout);

    router.post('/register', isAuthNeededMiddleware(), registerMiddlewareValidator, userController.post.register);
    router.post('/login', isAuthNeededMiddleware(), loginMiddlewareValidator, userController.post.login);

    return router;
};