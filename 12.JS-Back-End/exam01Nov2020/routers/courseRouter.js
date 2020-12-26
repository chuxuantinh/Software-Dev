const { courseController } = require('../controllers');
const { isAuthNeededMiddleware, } = require('../utils');

module.exports = (router) => {

    router.get('/all', isAuthNeededMiddleware(true), courseController.get.all);
    router.get('/create', isAuthNeededMiddleware(true), courseController.get.create);
    router.get('/details/:courseId', isAuthNeededMiddleware(true), courseController.get.details);
    router.get('/edit/:courseId', isAuthNeededMiddleware(true), courseController.get.edit);
    router.get('/delete/:courseId', isAuthNeededMiddleware(true), courseController.get.delete);
    router.get('/enroll/:courseId', isAuthNeededMiddleware(true), courseController.get.enroll);

    router.post('/create', isAuthNeededMiddleware(true), courseController.post.create);
    router.post('/edit/:courseId', isAuthNeededMiddleware(true), courseController.post.edit);

    return router;
};