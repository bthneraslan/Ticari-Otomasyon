'use strict';
var fs = require('fs');
var packageJSON = require('../package.json');
var path = require('path');
var sh = require('shelljs');
module.exports = function renderScripts() {
    var sourcePath = path.resolve(path.dirname(__filename), '../src/js/scripts.js');
    var destPath = path.resolve(path.dirname(__filename), '../dist/js/scripts.js');
    var copyright = "/*!\n    * Start Bootstrap - " + packageJSON.title + " v" + packageJSON.version + " (" + packageJSON.homepage + ")\n    * Copyright 2013-" + new Date().getFullYear() + " " + packageJSON.author + "\n    * Licensed under " + packageJSON.license + " (https://github.com/BlackrockDigital/" + packageJSON.name + "/blob/master/LICENSE)\n    */\n    ";
    var scriptsJS = fs.readFileSync(sourcePath);
    var destPathDirname = path.dirname(destPath);
    if (!sh.test('-e', destPathDirname)) {
        sh.mkdir('-p', destPathDirname);
    }
    fs.writeFileSync(destPath, copyright + scriptsJS);
};
