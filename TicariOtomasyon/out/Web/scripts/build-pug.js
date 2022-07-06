'use strict';
var path = require('path');
var sh = require('shelljs');
var renderPug = require('./render-pug');
var srcPath = path.resolve(path.dirname(__filename), '../src');
sh.find(srcPath).forEach(_processFile);
function _processFile(filePath) {
    if (filePath.match(/\.pug$/)
        && !filePath.match(/include/)
        && !filePath.match(/\/pug\/layouts\//)) {
        renderPug(filePath);
    }
}
