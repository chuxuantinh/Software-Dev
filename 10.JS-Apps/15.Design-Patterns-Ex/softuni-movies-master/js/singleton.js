let data = {};

export default class Singleton {
    static get data() {
        return data;
    }

    static set data(value) {
        data = value;
    }
}