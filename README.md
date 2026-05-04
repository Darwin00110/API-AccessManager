<div align="center">

# API Access Manager

### API RESTful de gerenciamento de usuários e controle de acesso

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![JWT](https://img.shields.io/badge/JWT-black?style=for-the-badge&logo=jsonwebtokens)](https://jwt.io/)
[![Docker](https://img.shields.io/badge/Docker-2496ED?style=for-the-badge&logo=docker&logoColor=white)](https://www.docker.com/)
[![Deploy](https://img.shields.io/badge/Deploy-Render-46E3B7?style=for-the-badge&logo=render&logoColor=white)](https://api-accessmaneger.onrender.com)

**[🌐 API em produção](https://api-accessmaneger.onrender.com) · [📋 Documentação de rotas](#-endpoints)**

</div>

---

## 📖 Sobre o projeto

Sistema backend completo de **autenticação e controle de acesso por roles**, construído com ASP.NET Core e Clean Architecture. O projeto resolve um problema real presente em qualquer sistema corporativo: como garantir que cada usuário acesse somente o que lhe é permitido, de forma segura e escalável.

A arquitetura foi desenhada para ser próxima do que se encontra em ambientes de produção reais — com separação clara de responsabilidades, autenticação stateless via JWT e tratamento centralizado de erros.

---

## 🏗️ Arquitetura

O projeto segue os princípios da **Clean Architecture**, separando as responsabilidades em camadas independentes:

```
API-AccessManager/
│
├── Domain/              # Entidades e regras de negócio puras
├── Application/         # Casos de uso e interfaces
├── Infrastructure/      # Persistência (EF Core), JWT, serviços externos
└── API/                 # Controllers, middlewares, ponto de entrada HTTP
```

> Essa separação garante que mudanças na camada de infraestrutura (banco de dados, autenticação) não impactem as regras de negócio — um padrão amplamente adotado em sistemas .NET corporativos.

---

## ✨ Funcionalidades

| Recurso | Descrição |
|---|---|
| 🔐 **Autenticação JWT** | Login retorna token stateless; sem necessidade de sessão no servidor |
| 👥 **Controle de Roles** | Dois perfis — `Admin` e `User` — com permissões distintas por endpoint |
| 🧾 **CRUD de Usuários** | Criação, leitura, atualização e remoção com validações |
| 📦 **DTOs** | Separação entre modelos de domínio e contratos da API |
| ⚠️ **Tratamento global de erros** | Middleware centralizado que padroniza respostas de erro |
| 🧩 **Injeção de dependência** | 100% nativa do .NET, sem frameworks externos |
| 🐳 **Docker** | Dockerfile incluído para facilitar deploy e ambiente local |

---

## 🛠️ Stack tecnológica

- **ASP.NET Core Web API** — framework principal
- **Entity Framework Core** — ORM e migrations
- **SQL Server** — banco de dados relacional
- **JWT (JSON Web Tokens)** — autenticação stateless
- **Docker** — containerização
- **C# 12** — linguagem principal

---

## 🚀 Como rodar localmente

### Pré-requisitos
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server (local ou Docker)
- Docker (opcional)

### 1. Clone o repositório
```bash
git clone https://github.com/Darwin00110/API-AccessManager.git
cd API-AccessManager/API-AccessManager
```

### 2. Configure a string de conexão
Edite o arquivo `appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=AccessManagerDb;Trusted_Connection=True;"
}
```

### 3. Execute as migrations e rode
```bash
dotnet restore
dotnet ef database update
dotnet run
```

### Ou com Docker
```bash
docker build -t api-access-manager .
docker run -p 8080:80 api-access-manager
```

---

## 📋 Endpoints

A API está disponível em produção em: `https://api-accessmaneger.onrender.com`

### 🔓 Rotas públicas (sem autenticação)

**Registrar usuário**
```http
POST /Users/Register
Content-Type: application/json

{
  "name": "string",
  "email": "user@example.com",
  "password": "string",
  "telephone": "string",
  "role": "Admin | User"
}
```

**Login**
```http
POST /Users/login
Content-Type: application/json

{
  "email": "user@example.com",
  "password": "string"
}
```
> ✅ O login bem-sucedido retorna o **Bearer Token** necessário para as rotas autenticadas.

---

### 🔒 Rotas autenticadas (requer Bearer Token)

Todas as requisições abaixo precisam do header:
```
Authorization: Bearer SEU_TOKEN_AQUI
```

**Visualizar próprio perfil**
```http
GET /Users/me
```

**Atualizar próprio perfil**
```http
PUT /Users/me

{
  "name": "string",
  "email": "user@example.com",
  "password": "string",
  "telephone": "string"
}
```

**Deletar própria conta**
```http
DELETE /Users/me
```

---

### 👑 Rotas administrativas (requer role `Admin`)

**Listar todos os usuários**
```http
GET /Admin
```

**Atualizar qualquer usuário**
```http
PUT /Admin/{id}
```

**Deletar qualquer usuário**
```http
DELETE /Admin/{id}
```

---

## 🧠 Decisões técnicas

**Por que Clean Architecture e não MVC padrão?**
A separação em camadas permite que a lógica de negócio seja testada isoladamente, sem dependência de framework ou banco. Projetos que crescem tendem a se tornar difíceis de manter quando Controllers acumulam responsabilidade — a Clean Architecture previne isso desde o início.

**Por que JWT stateless?**
Elimina a necessidade de armazenamento de sessão no servidor, tornando a API naturalmente escalável horizontalmente. O token carrega as claims do usuário (incluindo sua role), permitindo autorização sem consulta adicional ao banco.

---

## 📬 Contato

Desenvolvido por **Isaque Santos** como projeto de portfólio backend .NET.

[![LinkedIn](https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/isaque-santos-348109376)
[![GitHub](https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white)](https://github.com/Darwin00110)
