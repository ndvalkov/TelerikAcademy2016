function solve(args) {
    let str = args[0];

    let protocol = str.substring(0, str.indexOf('://'));
    let server = str.substring(str.indexOf('://') + 3, str.indexOf('/', str.indexOf('://') + 3));
    let resource = str.substring(str.indexOf(server) + server.length);

    console.log('protocol: ' + protocol);
    console.log('server: ' + server);
    console.log('resource: ' + resource);
}