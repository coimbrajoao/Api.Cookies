# Cookie.API 🍪 - Sistema de Gerenciamento de Estoque

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=for-the-badge&logo=dotnet)](https://dotnet.microsoft.com/)
[![MySQL](https://img.shields.io/badge/MySQL-4479A1?style=for-the-badge&logo=mysql&logoColor=white)](https://www.mysql.com/)
[![Entity Framework](https://img.shields.io/badge/EF%20Core-512BD4?style=for-the-badge&logo=dotnet)](https://learn.microsoft.com/en-us/ef/core/)

O **Cookie.API** é um sistema robusto de gerenciamento de estoque desenvolvido para controlar a vida útil de produtos, desde o cadastro inicial até as movimentações de entrada, saída e reversão. Projetado com princípios de **Clean Architecture**, o projeto garante escalabilidade, testabilidade e fácil manutenção.

## 🚀 Funcionalidades Principais

### 📦 Produtos
* Cadastro completo de novos produtos.
* Consulta detalhada por ID ou listagem geral.
* Atualização de informações técnicas e preços.
* Remoção segura de produtos do catálogo.

### 🏬 Estoque
* Vinculação de produtos a registros de estoque.
* Monitoramento em tempo real das quantidades disponíveis.
* Atualização e controle de inventário.

### 🔄 Movimentações
* **Entrada:** Adição manual ou via processos de novos itens ao estoque.
* **Saída:** Registro de baixas e vendas.
* **Reversão:** Opção de estorna movimentos efetuados de forma errada

---

## 🛠️ Tecnologias Utilizadas

* **Linguagem:** C# (.NET 10)
* **Framework Web:** ASP.NET Core Web API
* **ORM:** Entity Framework Core
* **Banco de Dados:** MySQL
* **Documentação:** Swagger / OpenAPI
* **Testes:** xUnit
* **Geração de Dados:** Bogus (utilizado para massa de dados em testes/seeds)

---

## 📂 Estrutura do Projeto

O projeto segue uma arquitetura em camadas para separação de responsabilidades:

```text
C:\Users\coimb\RiderProjects\Api.Cookies\
├── Cookie.API           # Camada de entrada (Controllers, Middlewares)
├── Cookie.Application   # Regras de Negócio (Services, DTOs, Mappers)
├── Cookie.Domain        # Entidades de Domínio e Interfaces
├── Cookie.Infra.Data    # Persistência (EF Core, Repositories, Migrations)
├── Cookie.Infra.Ioc     # Injeção de Dependências
└── Cookie.Test          # Testes Unitários e Integração
```

---

## ⚙️ Configuração e Execução

### Pré-requisitos
* [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
* [MySQL Server](https://dev.mysql.com/downloads/installer/)

### 1. Clonar o Repositório
```bash
git clone https://github.com/seu-usuario/Api.Cookies.git
cd Api.Cookies
```

### 2. Configurar Banco de Dados
No arquivo `Cookie.API/appsettings.json`, ajuste a string de conexão:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=cookie_db;Uid=root;Pwd=sua_senha;"
}
```

### 3. Executar Migrations
Abra o terminal na raiz do projeto e execute:
```bash
dotnet ef database update --project Cookie.Infra.Data --startup-project Cookie.API
```

### 4. Rodar a Aplicação
```bash
dotnet run --project Cookie.API
```
Acesse `https://localhost:5001/swagger` para visualizar a documentação interativa.

---

## 📖 Exemplos de Endpoints

### Criar Produto (`POST /api/Product`)
**Request Body:**
```json
{
  "name": "Cookie de Chocolate",
  "description": "Cookie artesanal com gotas de chocolate meio amargo",
  "price": 5.50,
  "flavor": "Chocolate"
}
```

### Registrar Movimentação (`POST /api/Movement`)
**Request Body:**
```json
{
  "quantity": 10,
  "stockId": 1,
  "typeMovement": 1 // 0 = Exit, 1 = Entry
}
```

### Reverter Movimentação (`POST /api/Movement/{id}/Revert`)
Reverte o impacto de uma movimentação específica no saldo do estoque.

---

## 🧪 Testes

Para garantir a qualidade e o funcionamento das regras de negócio, execute os testes utilizando o CLI do .NET:

```bash
dotnet test
```

---

## 📄 Licença
Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

---