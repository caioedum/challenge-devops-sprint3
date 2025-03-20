# 🌟 Web API | Azure Service App - Parrot Tech 🌟

## 📌 Sobre o Projeto

Este projeto consiste em uma API RESTful desenvolvida em .NET 8, conectada ao banco de dados SQL Server e implantada no Azure Service App. A API é responsável por gerenciar dados e realizar CRUD via Swagger nas tabelas de Usuários, Imagens e Previsões.

---

## 📖 Descrição do Projeto

Esta API foi projetada para fornecer uma solução escalável e eficiente, utilizando as melhores práticas de desenvolvimento. Ela implementa:

- **Arquitetura em Camadas** 🏗️
- **Entity Framework Core** para operações com banco de dados 💾
- **Manipulação de Erros e Logs** 🛠️

A API está implantada no **Azure App Service**, garantindo alta disponibilidade e integração contínua com o ambiente de nuvem 🌐.

## 🛠️ Tecnologias Utilizadas

- 🎯 .NET 8 - Framework principal da aplicação

- 🛢️ SQL Server - Banco de dados relacional

- ☁️ Azure Service App - Hospedagem da API na nuvem

- 🔗 Entity Framework Core - ORM para interação com o banco de dados

- 📡 Swagger - Documentação interativa da API
  
---

## 🚀 Como Executar o Projeto

### Pré-requisitos

1. ✅ Instale o [.NET SDK 8](https://dotnet.microsoft.com/download/dotnet/8.0).
2. ✅ Azure CLI (caso deseje implantar manualmente no Azure)

### Passos

1. Clone o repositório:

Acesse a documentação pelo Swagger após rodar a aplicação: 

https://localhost:7185/index.html

## 📌 Endpoints da API

🔹 Exemplos de Endpoints

- GET /api/ImagemUsuario - Retorna todos os registros

- POST /api/ImagemUsuario - Adiciona um novo registro
  
- GET /api/ImagemUsuario - Retorna por Id

- PUT /api/ImagemUsuario/{id} - Atualiza um registro

- DELETE /api/ImagemUsuario/{id} - Remove um registro

## 👥 Integrantes do Grupo

- **Caio Eduardo Nascimento Martins - RM554025**
- **Julia Mariano Barsotti Ferreira - RM552713**
- **Leonardo Gaspar Saheb - RM553383**

## 📝 Licença

🚀 Desenvolvido para o curso de Análise e Desenvolvimento de Sistemas - FIAP.
