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

