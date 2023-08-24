#!/bin/bash
curl --location 'https://eruz.zakupki.gov.ru/lkp/filestore/integration/upload/FS_EACTS/session/0393CF9F971D9F3FE06334548D0A6745' \
-X POST \
-i \
--header 'Authorization: Basic MzA1ODMzZGItMTdlOC00YmQ0LWIzMzctMmRmZDY1ZjdiNDU4' \
--header 'Host: eruz.zakupki.gov.ru' \
--header 'Connection: keep-alive' \
--header 'Content-Length: 16' \
--header 'Content-Type: application/x-www-form-urlencoded; charset=UTF-8' \
--cacert '/home/bzelga/dev/eruz.zakupki.gov.ru.pem' \
--data-binary 'status=completed'
