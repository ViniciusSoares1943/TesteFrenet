-- 1 Cria banco
CREATE DATABASE FrenetDb;
GO

-- 2 Conecta ao banco
USE FrenetDb;
GO

-- 3 Cria schema
CREATE SCHEMA FrenetOrder;
GO

-- 4 Cria login
CREATE LOGIN FrenetUser WITH PASSWORD = 'T3$te&5EC7#0)ç';
GO

-- 4 Cria usuario
CREATE USER FrenetUser FOR LOGIN FrenetUser;
GO

-- 4 Adiciona ao grupo owner
ALTER ROLE db_owner ADD MEMBER FrenetUser;
GO

-- 5 Cria tabela clientes
CREATE TABLE FrenetOrder.Clientes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(255) NOT NULL,
    Endereco NVARCHAR(500) NOT NULL,
    Telefone NVARCHAR(50) NOT NULL,
    Email NVARCHAR(255) NOT NULL
);
GO

-- 6 Cria tabela pedidos
CREATE TABLE FrenetOrder.Pedidos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdClient INT NOT NULL,
    Origem NVARCHAR(255) NOT NULL,
    Destino NVARCHAR(255) NOT NULL,
    DataCriacao DATETIME NOT NULL DEFAULT GETDATE(),
    Status INT NOT NULL,
    CONSTRAINT FK_Pedidos_Clientes FOREIGN KEY (IdClient) REFERENCES FrenetOrder.Clientes(Id)
);
GO

-- 7 Cria tabela de usuários (autenticação)
CREATE TABLE FrenetOrder.Usuarios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Login NVARCHAR(255) NOT NULL UNIQUE,
    Senha NVARCHAR(500) NOT NULL,
);
GO

-- 8 Da permissoes ao usuario nas tabelas criadas
GRANT CONTROL ON SCHEMA::FrenetOrder TO FrenetUser;
GRANT SELECT, INSERT, UPDATE, DELETE ON SCHEMA::FrenetOrder TO FrenetUser;
GO
