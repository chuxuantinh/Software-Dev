const http = require('http');
const url = require('url');

function methodHandlerFactory(handlers, method) {
    return function (path, ...fns) {
        handlers[method][path] = fns;
    }
}

function iterateAbdExecHandler(req, res, handlersArray) {
    const fn = handlersArray[0];
    if (!fn) {
        done(req, res);
        return;
    }
    fn(req, res, function(err) {
        if (err) {
            console.error(err);
            return;
        }
        iterateAbdExecHandler(req, res, handlersArray.slice(1));
    });
}

module.exports = function() {
    const handlers = {
        get: {},
        post: {},
        delete: {},
        put: {}
    };

    const server = http.createServer(function(req, res) {
        const { path, query } = url.parse(req.url, true);
        const method = req.method.toLowerCase();
        const reqHandlers = handlers[method][path];

        if(!reqHandlers) {
            res.end(`Route ${req.method} ${path} not found!`);
            return;
        }

        const originalEnd = res.end.bind(res);

        res.end = function(data) {
            if (typeof data === 'object') {
                data = JSON.stringify(data);
            }
            originalEnd(data);
        }

        iterateAbdExecHandler(req, res, reqHandlers);
    });

    return {
        listen: server.listen.bind(server),
        get: methodHandlerFactory(handlers, 'get'),
        post: methodHandlerFactory(handlers, 'post'),
    };
};