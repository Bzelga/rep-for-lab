#!/bin/bash
curl -L 'https://eruz.zakupki.gov.ru/lkp/filestore/integration/upload/FS_EACTS/new' \
-i -X POST \
-H "Authorization: Basic $1" \
-H 'Content-Type: application/json; charset=UTF-8' \
-H 'Host: eruz.zakupki.gov.ru' \
--cacert 'src/shell/eruz.zakupki.gov.ru.pem' \
-d "$2"
