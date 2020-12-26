module.exports = (mongoose) => {

    const { Schema, model: Model } = mongoose;
    const { String, ObjectId } = Schema.Types;

    const courseSchema = new Schema({
        title: {
            type: String,
            required: true,
            unique: true
        },
        description: {
            type: String,
            required: true,
            maxlength: 50
        },
        imageUrl: {
            type: String,
            required: true,
        },
        duration: {
            type: String,
            required: true,
        },
        createdAt: {
            type: Date,
            required: true
        },
        usersEnrolled: [
            {
                type: ObjectId,
                ref: "User"
            }
        ],
        courseCreator: {
            type: ObjectId,
            ref: "User",
        }
    });

    return Model('Course', courseSchema);
};