# Teste Técnico Frenet - Vinicius Correia Soares

Este projeto é uma Web API desenvolvida em .NET 8, seguindo os requisitos do teste técnico. Esta documentação o guiará na obtenção do repositório e na execução da aplicação.

### Pré-requisitos

Certifique-se de ter os seguintes softwares instalados:

-   [Docker Desktop](https://www.docker.com/get-started)
-   [Git](https://git-scm.com/) (para clonar o repositório)

### Passos para Execução

1.  **Clone o repositório:**

    ```bash
    git clone https://github.com/ViniciusSoares1943/TesteFrenet.git
    cd TesteFrenet
    ```

2.  **Estrutura do projeto:**

    A estrutura de pastas do projeto deve ser semelhante a esta:

    ```
    TesteFrenet/
    └───FrenetOrderSolution/
        ├───FrenetOrder/
        │   ├───Controllers/
        │   ├───Data/
        │   │   └───Scripts/
        │   ├───Models/
        │   │   ├───Dto/
        │   │   ├───Entity/
        │   │   └───Enum/
        │   ├───Properties/
        │   ├───Repository/
        │   │   └───Interface/
        │   └───Service/
        │       └───Interface/
        └───FrenetOrderTest/
            └───Service/
    ```
### Executando via container Docker

-  **Execute o Docker Compose:**

    Na pasta raiz do projeto ("TesteFrenet"), execute o seguinte comando para construir a imagem Docker da aplicação e baixar a imagem do banco de dados SQL Server:

    ```bash
    docker compose up -d
    ```
    **Observação 1:** Pode dar erro ao iniciar a aplicação caso a porta 8080 já esteja em uso na sua máquina, o mesmo acontece com o banco de dados.

    **Observação 2:** A imagem do banco de dados tem aproximadamente 500MB, e o tempo de inicialização pode variar dependendo da sua conexão com a internet.

-  **Verifique a execução:**

    Após a execução bem-sucedida, você deverá ver uma saída semelhante a esta:

    ```plaintext
    [+] Running 3/3
    ✔ Network testefrenet_default Created
    ✔ Container sql_server         Started
    ✔ Container testefrenet-app-1  Started
    ```

-  **Execução do script SQL:**

    O script SQL para criar a estrutura do banco de dados está localizado em:

    -   `TesteFrenet/initial.sql`
    -   `FrenetOrderSolution/FrenetOrder/Data/Scripts/initial.sql`

    Você pode executar este script usando qualquer ferramenta de sua preferência. As informações de conexão com o banco de dados são:

    -   **Host:** `localhost`
    -   **Porta:** `1433`
    -   **Usuário:** `sa`
    -   **Senha:** `T3@te&5EC70)*`
    -   **Banco de dados:** `master`

    O script deve ser executado por inteiro ou usando os comando sql seguindo a sequência estabelecida nos comentários.
    
### Executando sem container

- **Instalando e configurando o banco de dados**

    1.  Acesse o site da Microsoft para baixar o instalador do SQL Server: [https://www.microsoft.com/en-us/sql-server/sql-server-downloads](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
    2.  Escolha a versão do SQL Server "Developer"
    3.  Execute o instalador siga os passos para iniciar a instalação.
    4.  Após a conclusão da instalação, você será solicitado a configurar o SQL Server, preencha os dados e clique em "Instalar" para concluir a configuração.

    **Observação:** A forma de autenticação do banco deve ser "SQL server Autentication", no script será criado um banco, usuário e schema além das tabelas a serem usadas.

    O script SQL para criar a estrutura do banco de dados está localizado em:

    -   `TesteFrenet/initial.sql`
    -   `FrenetOrderSolution/FrenetOrder/Data/Scripts/initial.sql`

    Você pode executar este script usando qualquer ferramenta de sua preferência acessando com as credenciais que você usou para configurar o banco de dados.

    O script deve ser executado por inteiro ou usando os comando sql seguindo a sequência estabelecida nos comentários.

- **Executando a aplicação**

    Execute o comando para restaurar as dependências da aplicação

    ```bash
    cd .\FrenetOrderSolution\
    dotnet restore
    ```
    Em seguida o comando para executar da aplicação

    ```bash
    dotnet run --project FrenetOrder
    ```


-  ### Acessando a aplicação:

    A aplicação pode ser acessada através do endereço:

    http://localhost:8080

    Onde você deve ser redirecionado direto para swagger da aplicação contendo todas as rotas e suas respectivas documentações, os parâmetros de entrada e objetos de saída também estão documentados.



### Questionário de Avaliação Técnica

**Seção 1: C# e Desenvolvimento de API RESTful**

1. **Qual é o propósito do comando using em C#?**

- A) Declarar uma variável 
- > B) Importar um namespace
- C) Definir um método 
- D) Criar um objeto

2. **Qual é o tipo de dado mais apropriado para armazenar uma data e hora em C#?**

- A) int 
- B) string 
- >C) DateTime 
- D) bool

3. **Qual é o método mais comum para criar uma instância de uma classe em C#?**

- >A) new 
- B) Create 
- C) Instantiate 
- D) Construct

4. **Qual é o propósito do atributo [ApiController] em ASP.NET Core?**

- >A) Definir um controlador de API 
- B) Definir um modelo de dados 
- C) Definir um serviço de dependência 
- D) Definir um middleware

5. **Qual é o tipo de retorno mais comum para um método de API Restful em C#?**

- A) void
- B) int 
- C) string 
- >D) IActionResult

6. **Qual é o propósito do método ConfigureServices no arquivo Startup.cs em ASP.NET Core?**

- >A) Configurar os serviços de dependência 
- B) Configurar as rotas de API 
- C) Configurar o banco de dados 
- D) Configurar a autenticação
7. **Qual é o propósito do atributo [Route] em ASP.NET Core?**

- >A) Definir uma rota de API 
- B) Definir um modelo de dados 
- C) Definir um serviço de dependência 
- D) Definir um middleware


8. **Qual é o tipo de retorno mais comum para um método de API Restful que retorna uma lista de objetos em C#?**

- A) IActionResult 
- B) IEnumerable<T> 
- C) IQueryable<T> 
- >D) List<T>

9. **Qual é o propósito do método AddDbContext no arquivo Startup.cs em ASP.NET Core?**

- > A) Adicionar um contexto de banco de dados 
- B) Adicionar um serviço de dependência 
- C) Adicionar um middleware 
- D) Adicionar uma rota de API

10. **Qual é o tipo de dado mais apropriado para armazenar uma chave primária em C#?**

- >A) int 
- B) string 
- C) Guid 
- D) DateTime

11. **Qual é o propósito do método AddSwaggerGen no arquivo Startup.cs em ASP.NET Core?**

- A) Adicionar um serviço de dependência 
- B) Adicionar um middleware 
- C) Adicionar uma rota de API 
- >D) Gerar documentação de API com Swagger

12. **Qual é o tipo de exceção mais comum para lidar com erros de validação de dados em C#?**

- A) Exception
- B) ValidationException 
- >C) ArgumentException 
- D) InvalidOperationException



**Seção 2: Banco de Dados Microsoft SQL Server**

1. **Qual é o comando SQL utilizado para criar uma tabela no Microsoft SQL Server?**

- >A) CREATE TABLE 
- B) DROP TABLE 
- C) ALTER TABLE 
- D) TRUNCATE TABLE

2. **Qual é o tipo de dado mais comum utilizado para armazenar datas e horas no Microsoft SQL Server?**

- A) INT 
- B) VARCHAR 
- >C) DATETIME 
- D) FLOAT

3. **Qual é o comando SQL utilizado para atualizar dados em uma tabela no Microsoft SQL Server?**

- >A) UPDATE 
- B) INSERT INTO 
- C) DELETE 
- D) SELECT

4. **Qual é o comando SQL utilizado para excluir dados de uma tabela no Microsoft SQL Server?**

- >A) DELETE 
- B) TRUNCATE TABLE 
- C) DROP TABLE 
- D) ALTER TABLE

5. **Qual é o conceito de transação no Microsoft SQL Server?**

- >A) Conjunto de operações que devem ser executadas como uma unidade 
- B) Conjunto de operações que podem ser executadas independentemente 
- C) Conjunto de operações que devem ser executadas em paralelo 
- D) Conjunto de operações que devem ser executadas em série


6. **Qual é o comando SQL utilizado para criar um índice em uma tabela no Microsoft SQL Server?**

- >A) CREATE INDEX 
- B) ALTER TABLE 
- C) DROP INDEX 
- D) TRUNCATE TABLE

7. **Qual é o comando SQL utilizado para criar uma visão em uma tabela no Microsoft SQL Server?**

- >A) CREATE VIEW 
- B) ALTER TABLE 
- C) DROP VIEW 
- D) TRUNCATE TABLE

8. **Qual é o objetivo do uso de particionamento de tabelas no SQL Server**?

- >A) Melhorar a performance de consultas 
- B) Reduzir o tamanho da tabela 
- C) Aumentar a segurança dos dados 
- D) Facilitar a manutenção de dados

9. **Qual é o uso do comando WITH (NOLOCK) em uma consulta SQL Server?**

- A) Para bloquear a tabela durante a consulta 
- >B) Para evitar bloqueios de tabela durante a consulta 
- C) Para melhorar a performance de consultas 
- D) Para reduzir o uso de recursos do sistema

10. **Qual é o objetivo do uso de índices compostos no SQL Server?**

- A) Melhorar a performance de consultas que usam apenas uma coluna 
- >B) Melhorar a performance de consultas que usam várias colunas 
- C) Reduzir o tamanho da tabela 
- D) Aumentar a segurança dos dados

11. **Qual é o objetivo do uso de triggers no SQL Server?**

- A) Melhorar a performance de consultas 
- B) Reduzir o tamanho da tabela 
- C) Aumentar a segurança dos dados 
- >D) Automatizar tarefas de manutenção de dados

12. **Qual é o uso do comando CHECKPOINT no SQL Server?**

- >A) Para salvar os dados da tabela em um arquivo 
- B) Para restaurar os dados da tabela de um arquivo 
- C) Para liberar recursos do sistema 
- D) Para forçar a gravação de dados no disco

**Seção 3: Padrão Swagger**

1. **Qual é o objetivo principal do Swagger?**

- >A) Documentar APIs RESTful 
- B) Gerar código mínimo para APIs 
- C) Realizar testes de integração 
- D) Implementar autenticação e autorização

2. **Qual é o padrão de especificação de API mais comumente utilizado em conjunto com o Swagger?**

- >A) OpenAPI 
- B) API Blueprint
- C) RAML 
- D) WADL

3. **Qual é o benefício de utilizar o Swagger First em desenvolvimento de APIs?**

- A) Reduzir o tempo de desenvolvimento 
- B) Aumentar a complexidade da API 
- >C) Melhorar a documentação da API 
- D) Reduzir a necessidade de testes

4. **Qual é o recurso do Swagger que permite gerar código mínimo para APIs?**

- >A) Swagger Codegen 
- B) Swagger UI 
- C) Swagger Editor 
- D) Swagger Hub
