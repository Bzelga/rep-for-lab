#!/bin/bash
curl --location 'https://eruz.zakupki.gov.ru/lkp/filestore/integration/upload/FS_EACTS/session/0393CF9F971D9F3FE06334548D0A6745' \
-X POST  \
-i \
--header 'Content-Type: application/octet-stream' \
--header 'Authorization: Basic MzA1ODMzZGItMTdlOC00YmQ0LWIzMzctMmRmZDY1ZjdiNDU4' \
--header 'Connection: keep-alive' \
--header 'Host: eruz.zakupki.gov.ru' \
--header 'Content-Length: 0' \
--header 'Content-Range: bytes */33' \
--cacert '/home/bzelga/dev/eruz.zakupki.gov.ru.pem'
