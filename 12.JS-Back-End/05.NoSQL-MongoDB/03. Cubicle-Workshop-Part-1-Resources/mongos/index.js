const mongodb = require('mongodb');

class Schema {
    constructor(definition) {
        this.definition = definition;
    }
}

const modelSymbol = Symbol('model');

class Document {
    constructor(record, model) {
        this[modelSymbol] = model;
        Object.entries(record).forEach((key, value) => {
            this[key] = value;
        });
    }
    save() {
        this[modelSymbol].update({ _id: this._id }, this);
    }
}

let _client;

module.exports = {
  connect(connectionString, options) {
    const client = new mongodb.MongoClient(connectionString, options);
    return client.connect().then(client => {
        _client = client;
        return client;
    });
  },
  Schema,
  model(name, schema) {
    const db = _client.db('softuni');
    const collection = db.collection(name);
    return {
        create(entry) {
            const result = Object.entries(schema.definition).reduce((acc, [key, config]) => {
                const entryValue = entry[key];
                const isValidType = typeof entryValue === typeof config.type();
                let isValid = true;
                if (config.validate && config.validate.validator) {
                    isValid = config.validate.validator(entryValue);
                }
                const errors = [];
                if (!isValidType) {
                    errors.push(`${key} is not the correct type`);
                }
                if (!isValid) {
                    errors.push(config.validate.message);
                }
                return acc.concat(errors);
            }, []);
            if (result.length === 0) {
                return collection.insert(entry).then(result => {
                    return new Document(result.ops[0], this);
                });
            }
            return Promise.reject(result);
        },
        update(query, data) {
            if (query._id && !(query._id instanceof mongodb.ObjectID)) {
                query._id = mongodb.ObjectId(query._id);
            }
            if (data.$set) {
                data = { $set: data };
            }
            return collection.update(query, data);
        }
    }
  }
};