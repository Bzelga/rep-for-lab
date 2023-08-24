curl --location 'https://eruz.zakupki.gov.ru/lkp/filestore/integration/upload/FS_EACTS/new' \
-i -X POST \
--header 'Authorization: Basic MzA1ODMzZGItMTdlOC00YmQ0LWIzMzctMmRmZDY1ZjdiNDU4' \
--header 'Content-Type: application/json; charset=UTF-8' \
--header 'Host: eruz.zakupki.gov.ru' \
--cacert 'eruz.zakupki.gov.ru.pem' \
--data '{"name":"minifile.txt","size":33,"digest":"49af56433f7d90a6a5f954fec034661e1fb81820343f248cc7b1194f1225b653"}'
