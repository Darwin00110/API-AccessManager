# 🚀 ASP.NET Core REST API - Clean Architecture

API RESTful desenvolvida com foco em boas práticas de backend, escalabilidade e padrões profissionais utilizados em sistemas reais de produção.

---

## 📌 Sobre o projeto

Este projeto simula uma API backend completa utilizando **ASP.NET Core**, aplicando conceitos modernos de arquitetura e segurança. O objetivo foi construir uma base sólida, organizada e escalável, semelhante a sistemas utilizados em ambientes corporativos.

---

## ⚙️ Funcionalidades

- 🔐 Autenticação com JWT
- 👥 Controle de acesso por Roles (Admin / User)
- 🧾 CRUD completo de entidades
- 📦 DTOs para abstração de dados
- ⚠️ Tratamento global de exceções
- 🧩 Injeção de dependência
- 🏗️ Arquitetura em camadas (Clean Architecture)

---

## 🧠 Arquitetura e boas práticas

O projeto foi estruturado com separação clara de responsabilidades:

- Domain (regras de negócio)
- Application (casos de uso)
- Infrastructure (persistência e serviços externos)
- API (camada de entrada)

---

## 🛠️ Tecnologias utilizadas

- ASP.NET Core Web API
- Entity Framework Core
- JWT Authentication
- C#
- SQL Server (ou outro banco configurado)
- Dependency Injection nativo do .NET

---

## 🎯 Objetivo

Este projeto foi desenvolvido com foco em demonstrar habilidades práticas em backend, arquitetura limpa, segurança de APIs e organização de código em nível profissional.

---

## 📈 Destaques

✔ Código organizado como ambiente real de empresa  
✔ API segura com autenticação e autorização  
✔ Estrutura preparada para escalabilidade  
✔ Foco em boas práticas de desenvolvimento backend  

---

## 🚀 Como executar o projeto

1. Clone o repositório
2. Configure a string de conexão no `appsettings.json`
3. Execute as migrations (se aplicável)
4. Rode o projeto com:

```bash
git clone https://github.com/Darwin00110/API-AccessManeger.git
cd API-AccessManeger/API-AccessManeger
dotnet restoure
dotnet ef database update
dotnet run
```

```Rotas
--------Rotas Padrão (SEM AUTH)-----------
POST https://api-accessmaneger.onrender.com/Users/Register
{
  "name": "string",
  "email": "user@example.com",
  "password": "string",
  "telephone": "string",
  "role": "string"
}
OBS: Role so aceita Admin ou User

POST https://api-accessmaneger.onrender.com/Users/login
{
  "email": "user@example.com",
  "password": "string"
}
-------------------------------------------------

---------------- Rotas com AUTH -------------------
OBS: [Todos as requisições presentes aqui é necessario inserir o token de autenticação]
[que é fornecido apos efetuar um login bem sucedido]

GET https://api-accessmaneger.onrender.com/Users/me
----
curl -X GET https://api-accessmaneger.onrender.com/Users/me \
  -H "Authorization: Bearer SEU_TOKEN_AQUI"
=================================================


PUT https://api-accessmaneger.onrender.com/Users/me
----
curl -X PUT https://api-accessmaneger.onrender.com/Users/me \
  -H "Authorization: Bearer SEU_TOKEN_AQUI"
=================================================
{
  "name": "string",
  "email": "user@example.com",
  "password": "string",
  "role": "string",
  "telephone": "string"
}
=====================================================

DELETE https://api-accessmaneger.onrender.com/Users/me
----
curl -X DELETE https://api-accessmaneger.onrender.com/Users/me \
  -H "Authorization: Bearer SEU_TOKEN_AQUI"
=================================================



--------------------------------------------------------------

------------------------Rotas ADM-------------------------------
GET https://api-accessmaneger.onrender.com/Admin
----
curl -X GET https://api-accessmaneger.onrender.com/Admin \
  -H "Authorization: Bearer SEU_TOKEN_AQUI"
=================================================


PUT https://api-accessmaneger.onrender.com/Admin/{id}
----
curl -X PUT https://api-accessmaneger.onrender.com/Admin/{id} \
  -H "Authorization: Bearer SEU_TOKEN_AQUI"
=================================================
{
  "name": "string",
  "email": "user@example.com",
  "password": "string",
  "role": "string",
  "telephone": "string"
}


DELETE https://api-accessmaneger.onrender.com/Admin/{id}
----
curl -X DELETE https://api-accessmaneger.onrender.com/Admin/{id} \
  -H "Authorization: Bearer SEU_TOKEN_AQUI"
=================================================

--------------------------------------------------------------

```


👨‍💻 Autor

Desenvolvido como parte do portfólio backend com foco em oportunidades na área de desenvolvimento .NET.nn