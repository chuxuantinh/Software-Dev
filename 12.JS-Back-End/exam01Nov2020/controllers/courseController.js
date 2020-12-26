const { Course, User } = require('../models');
const { formValidator } = require('../utils');

module.exports = {
    get: {
        all(req, res, next) {
            
            Course
                .find({ })
                .lean()
                .sort({ createdAt: 1 })
                .then((courses) => {
                    console.log(courses);
                    res.render('./courses/courses.hbs', {
                        courses
                    });
                })
                .catch((e) => console.log(e));
        },

        create(req, res, next) {
            res.render('./courses/create.hbs');
        },

        details(req, res, next) {
            let courseId = req.params.courseId;
            let isCreator = false;
            let isEnrolled = false;
            let userId = req.user._id.toString();
            Course
                .findOne({ _id: courseId })
                .lean()
                .then((course) => {
                    course.courseCreator.toString() === userId ? (isCreator = true) : (isCreator = false);
                    if (course.usersEnrolled) {
                        if (course.usersEnrolled.toString().includes(userId)) {
                            isEnrolled = true;
                        }
                    }
                    res.render('./courses/details.hbs', { ...course, isCreator, isEnrolled });
                })
        },

        edit(req, res, next) {

            Course
                .findOne({ _id: req.params.courseId })
                .then((course) => {
                    res.render('./courses/edit.hbs', course);
                });
        },

        delete(req, res, next) {

            Course
                .deleteOne({ _id: req.params.courseId })
                .then((result) => {
                    res.redirect('/courses/all');
                })
        },

        enroll(req, res, next) {
            let courseId = req.params.courseId;
            let userId = req.user._id;
            Promise.all([
                User.updateOne({_id: userId}, {$push: {enrolledCourses: courseId}}),
                Course.updateOne({_id: courseId}, {$push: {usersEnrolled: userId}})
            ]).then(() => {
                
                res.redirect(`/courses/details/${courseId}`)
            })
                .catch(next)
        }
    },

    post: {
        create(req, res, next) {
            const formValidations = formValidator(req);

            if (!formValidations.isOK) {
                res.render('./courses/create.hbs', formValidations.contextOptions);
                return;
            }

            Course
                .create({ ...req.body, courseCreator: req.user._id, createdAt: new Date() })
                .then((createdCourse) => {
                    console.log(createdCourse);
                    res.redirect('/courses/all');
                });
        },

        edit(req, res, next) {
            const formValidations = formValidator(req);

            if (!formValidations.isOK) {
                res.render('./courses/edit.hbs', formValidations.contextOptions);
                return;
            }

            const { courseId } = req.params;

            Course
                .updateOne(
                    { _id: courseId },
                    { $set: { ...req.body } }
                ).then((updatedCourse) => {
                    res.redirect(`/courses/details/${courseId}`)
                })
        }
    }
}