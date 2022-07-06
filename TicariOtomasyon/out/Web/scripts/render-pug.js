'use strict';
var fs = require('fs');
var path = require('path');
var pug = require('pug');
var sh = require('shelljs');
var prettier = require('prettier');
module.exports = function renderPug(filePath) {
    var destPath = filePath.replace(/src\/pug\/\pages\//, 'dist/').replace(/\.pug$/, '.html');
    console.log("### INFO: Rendering " + filePath + " to " + destPath);
    var html = pug.renderFile(filePath, {
        doctype: 'html',
        filename: filePath
    });
    var destPathDirname = path.dirname(destPath);
    if (!sh.test('-e', destPathDirname)) {
        sh.mkdir('-p', destPathDirname);
    }
    var prettified = prettier.format(html, {
        printWidth: 1000,
        tabWidth: 4,
        singleQuote: true,
        proseWrap: 'preserve',
        endOfLine: 'lf',
        parser: 'html'
    });
    fs.writeFileSync(destPath, prettified);
};
