# Projeto .NET 8 - README

## Visão Geral
Este repositório contém um projeto de API em .NET 8 que interage com um banco de dados MySQL contendo uma tabela `Company`.

## Configuração do Banco de Dados

### MySQL no Docker
Execute o seguinte comando para iniciar um contêiner MySQL:

```bash
docker run --name my-mysql -e MYSQL_ROOT_PASSWORD=mysecretpassword -p 3308:3306 -d --rm mysql:latest
```

### Estrutura do Banco de Dados
O projeto utiliza a seguinte estrutura de tabela:

```sql
CREATE TABLE Company (
    Id BIGINT PRIMARY KEY AUTO_INCREMENT,
    AvatarUrl VARCHAR(255),
    NomeFantasia VARCHAR(255),
    RazaoSocial VARCHAR(255),
    QtdeFuncionarios BIGINT,
    Active BOOLEAN
);
```

## Estrutura do Projeto
- **Controllers**: Contém os endpoints da API
- **Models**: Modelos de dados, incluindo a entidade Company
- **Services**: Lógica de negócios
- **Repositories**: Camada de acesso a dados
- **Dto**: Objetos de Transferência de Dados

## Começando

### Pré-requisitos
- SDK do .NET 8
- Docker (para executar o MySQL)

### Instalação
1. Clone o repositório
   ```bash
   git clone https://github.com/helena-teste-back/helena-teste-back.git
   cd helena-teste-back
   ```

2. Inicie o banco de dados MySQL usando Docker (como mostrado acima)

3. Atualize a string de conexão no `launchSettings.json` para corresponder à sua configuração de banco de dados

4. Execute a aplicação
   ```bash
   dotnet restore
   dotnet run
   ```

### Endpoints da API
- `GET /api/company` - Obter todas as empresas
- `GET /api/company/{id}` - Obter uma empresa específica
- `POST /api/company` - Criar uma nova empresa
- `PUT /api/company/{id}` - Atualizar uma empresa
- `DELETE /api/company/{id}` - Deletar uma empresa

## Configuração
A aplicação pode ser configurada através do arquivo `launchSettings.json`.

## Tecnologias
- .NET 8
- Dapper
- MySQL
- Docker


