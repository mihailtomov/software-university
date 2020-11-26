function requestValidator(request) {
    let validMethods = ['GET', 'POST', 'DELETE', 'CONNECT'];

    if (!request.method || !validMethods.includes(request.method)) {
        throw new Error('Invalid request header: Invalid Method');
    }

    let uriPattern = /^[\w\d\.]+$|^[*]$/g;

    if (!request.uri || !request.uri.match(uriPattern)) {
        throw new Error('Invalid request header: Invalid URI');
    }

    let validVersions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];

    if (!request.version || !validVersions.includes(request.version)) {
        throw new Error('Invalid request header: Invalid Version');
    }

    let messagePattern = /^[^<>\\&'"]*$/g;

    if (request.message == undefined || !request.message.match(messagePattern)) {
        throw new Error('Invalid request header: Invalid Message');
    }

    return request;
}

requestValidator({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: ''
});