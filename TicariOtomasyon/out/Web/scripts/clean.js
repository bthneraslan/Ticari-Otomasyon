var sh = require('shelljs');
var path = require('path');
var destPath = path.resolve(path.dirname(__filename), '../dist');
sh.rm('-rf', destPath + "/*");
