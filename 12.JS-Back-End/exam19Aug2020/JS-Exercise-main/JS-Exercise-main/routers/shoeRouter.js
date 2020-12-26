const { shoeController } = require('../controllers');
const { isAuthNeededMiddleware } = require('../utils');

module.exports = (router) => {

    router.get('/all', isAuthNeededMiddleware(true), shoeController.get.all);
    router.get('/create', isAuthNeededMiddleware(true), shoeController.get.create);
    router.get('/details/:shoeId', isAuthNeededMiddleware(true), shoeController.get.details);
    router.get('/edit/:shoeId', isAuthNeededMiddleware(true), shoeController.get.edit);
    router.get('/delete/:shoeId', isAuthNeededMiddleware(true), shoeController.get.delete);

    router.post('/create', isAuthNeededMiddleware(true), shoeController.post.create);
    router.post('/edit/:shoeId', isAuthNeededMiddleware(true), shoeController.post.edit);

    return router;
};