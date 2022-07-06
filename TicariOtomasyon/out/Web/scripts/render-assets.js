'use strict';
var fs = require('fs');
var path = require('path');
var sh = require('shelljs');
module.exports = function renderAssets() {
    var sourcePath = path.resolve(path.dirname(__filename), '../src/assets');
    var destPath = path.resolve(path.dirname(__filename), '../dist/.');
    sh.cp('-R', sourcePath, destPath);
};
