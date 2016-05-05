var connect = require('connect');
var serveStatic = require('serve-static');

connect().use(serveStatic(__dirname)).listen(8081, function(){
    console.log('app alive!');
});
//http://localhost:8081   ,    https://github.com/tzvikaya/FinalProject  ///