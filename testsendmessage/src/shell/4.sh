#!/bin/bash
curl --location "https://eruz.zakupki.gov.ru/lkp/filestore/integration/upload/FS_EACTS/session/$1" \
-X POST -i \
--header "Authorization: Basic $2" \
--header "Host: eruz.zakupki.gov.ru" \
--header "Connection: keep-alive" \
--header "Content-Length: 16" \
--header "Content-Type: application/x-www-form-urlencoded; charset=UTF-8" \
--cacert "src/shell/eruz.zakupki.gov.ru.pem" \
--data-binary 'status=completed'
