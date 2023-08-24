#!/bin/bash
curl --location "https://eruz.zakupki.gov.ru/lkp/filestore/integration/upload/FS_EACTS/session/$1" \
-X POST  -i \
--header "Content-Type: application/octet-stream" \
--header "Authorization: Basic $2" \
--header "Connection: keep-alive" \
--header "Host: eruz.zakupki.gov.ru" \
--header "Content-Length: 0" \
--header "Content-Range: bytes */$3" \
--cacert 'src/shell/eruz.zakupki.gov.ru.pem' \
