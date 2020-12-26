const stream = require('stream');

function createReadableStream(data) {
    let counter = 0;
    const rs = stream.Readable({
        read(size) {
            const item = data[counter++] || null;
            this.push(item ? Buffer.from(item.toString()) : null);
        }
    });
    return rs;
}

function createWritableStream() {
    let data;
    const ws = stream.Writable({
        write(chunk, enc, next) {
            data = !data ? chunk : Buffer.concat([data, chunk]);
            next();
        },
        final() {
            console.log(data);
        }
    });
    return ws;
}

const rs = createReadableStream([1, 2, 3, 4, 5, 6, 7]);
const ws = createWritableStream();

rs.pipe(ws);