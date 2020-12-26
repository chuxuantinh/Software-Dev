const { Course } = require('../models');

module.exports = {
    get: {
        home(req, res, next) {
            Course
                .find({})
                .lean()
                .sort({ usersEnrolled: -1 })
                .limit(3)
                .then((courses) => {
                    console.log(courses);
                    res.render('./home/home.hbs', {
                        courses
                    });
                })
                .catch((e) => console.log(e));
        },
    }
};
