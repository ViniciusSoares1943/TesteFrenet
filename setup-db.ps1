$SQL_SERVER_CONTAINER = "sql_server"
$SQL_SCRIPT = "..\FrenetOrderSolution\FrenetOrder\Data\Scripts\initial.sql"

# Executa o script no SQL Server rodando no Docker
docker exec -i $SQL_SERVER_CONTAINER sqlcmd -S localhost -U sa -P "MinhaSenha123" -d master -i /tmp/$SQL_SCRIPT

Write-Host "Banco de dados e tabelas criados com sucesso!"
