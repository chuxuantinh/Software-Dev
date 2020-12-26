const mongos = require('../mongos');

const userSchema = new mongos.Schema({
    name: {type: String, validate: { validator(value) { return value.length > 3 }, message: 'Name should be longer than 3 symbols' }},
    age: {type: Number},
    email: {type: String}
});

const user = mongos.model('users', userSchema);

user.create({ name: 'Ivan', age: 20, email: 'email@abv.bg' }).then((user) => {
    user.name = 'Test 1';
    return user.save();
}).then(() => console.log('User was successfully modified'))
.catch(err => console.log(err));