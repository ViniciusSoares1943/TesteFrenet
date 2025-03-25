#!/bin/bash

# Configurações
SQL_SERVER_CONTAINER="sql_server"
SQL_SCRIPT="../FrenetOrderSolution/FrenetOrder/Data/Scripts/initial.sql"

# Executa o script no SQL Server rodando no Docker
docker exec -i $SQL_SERVER_CONTAINER /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "T3$te&5EC7#0)ç" -d master -i /tmp/$SQL_SCRIPT

echo "Banco de dados e tabelas criados com sucesso!"
