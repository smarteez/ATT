﻿function downloadFile(fileName, base64) {
    var link = document.createElement('a');
    link.download = fileName;
    link.href = 'data:application/octet-stream;base64,' + base64;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}