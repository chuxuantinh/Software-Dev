const mongoose = require('mongoose');

const userSchema = mongoose.Schema({
    name: {
        type: String,
        required: [true, 'User name required']
    },
    age: {
        type: Number,
        min: [10, 'Age must be no less than 10'],
        required: [true, 'User age required']
    },
    email: String
});

const userPostSchema = mongoose.Schema({
    title: String,
    body: String,
    userId: { type: mongoose.Schema.Types.ObjectId, ref: 'user' }
});

userSchema.virtual('allNames').get(function() {
    return this.name.split(' ');
});

userSchema.methods.printAllData = function() {
    console.log(this.name, this.age, this.email);
}

mongoose.connect('mongodb://127.0.0.1:27017/softuni').then(() => {
    console.log('Connected to database!');

    userSchema.pre('save', function(next) {
        setTimeout(function() {
            next();
        }, 3000)
        console.log('Pre save');
    });

    const User = mongoose.model('user', userSchema);
    const UserPosts = mongoose.model('userPost', userPostSchema);
    User.create({ name: "Test", age: 10, email: "test@test.bg" }).then(() => {}).catch(err => console.error(err));

    UserPosts.create({ title: 'Post 1', body: 'Hello world', userId: 'someUserID' }).then(() => console.log('Post added'));
    UserPosts.findById('somePostId').populate('userId').then(post => console.log(JSON.stringify(post, null, 2)));

    User.update({ _id: 'someId' }, { name: "123" }).then(() => console.log('Completed!'));

    User.find({ age: { $eq: 20 } }).then((data) => {
        data.forEach(user => user.printAllData());// user => console.log(user.allNames)
    });

    const newUser = new User({ name: "Test", age: 10, email: "test@test.bg" });
    newUser.save().then(() => { console.log('User was added to db'); });

    User.insertMany([{ name: "Test", age: 40, email: "email" }]).then(() => console.log('Completed'));

    User.find({ name: /v/ }).then(users => {
        const updates = users.map(user => {
            user.name = user.name + ' ' + user.name;
            return user.save();
        });

        return Promise.all(updates);
    }).then(() => {
        console.log('All entries have been updated!');
    })
});