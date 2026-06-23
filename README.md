# 🔐 LoginSystem

Sistema de autenticação desenvolvido em **ASP.NET Core MVC** utilizando **C#**, **SQL Server** e arquitetura em camadas. O projeto foi criado com foco em aprendizado das boas práticas de desenvolvimento, 
incluindo autenticação, gerenciamento de sessões, acesso ao banco de dados e organização de código.

---

## 📖 Sobre o projeto

O LoginSystem é uma aplicação web que permite o cadastro e autenticação de usuários utilizando um banco de dados SQL Server.

O objetivo principal do projeto é estudar conceitos fundamentais do desenvolvimento de aplicações ASP.NET Core MVC, aplicando uma arquitetura limpa e escalável semelhante à utilizada em projetos profissionais.

---

## 🚀 Funcionalidades

- ✅ Cadastro de usuários
- ✅ Login de usuários
- ✅ Logout
- ✅ Gerenciamento de sessão
- ✅ Criptografia de senha com BCrypt
- ✅ Validação de formulários
- ✅ Arquitetura em camadas
- ✅ Integração com SQL Server
- ✅ Injeção de Dependência (Dependency Injection)

---

## 🛠️ Tecnologias utilizadas
  
- ASP.NET Core MVC
- C#
- .NET 10
- SQL Server
- Microsoft.Data.SqlClient
- BCrypt.Net
- HTML5
- CSS3
- Bootstrap 5
- Razor Views

---

## 📂 Estrutura do projeto

```
LoginSystem
│
├── Controllers
│   ├── HomeController.cs
│   ├── LoginController.cs
│   └── UserController.cs
│
├── Data
│   └── Database.cs
│
├── Interfaces
│
├── Models
│   └── User.cs
│
├── Repositories
│   └── UserRepository.cs
│
├── Services
│   ├── LoginService.cs
│   ├── PasswordService.cs
│   ├── SessionService.cs
│   └── UserService.cs
│
├── ViewModels
│   ├── LoginViewModel.cs
│   └── RegisterViewModel.cs
│
├── Views
│
├── wwwroot
│
├── appsettings.json
└── Program.cs
```

---

## 🗄️ Banco de Dados

### Criar banco

```sql
CREATE DATABASE LoginSystem;
```

### Criar tabela Users

```sql
USE LoginSystem;

CREATE TABLE Users
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(150) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    CreatedAt DATETIME NOT NULL
);
```

---

## ⚙️ Configuração

No arquivo `appsettings.Development.json` configure a conexão:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.\\SQLEXPRESS;Database=LoginSystem;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

Caso utilize outra instância do SQL Server, altere apenas o valor de `Server`.

---

## ▶️ Como executar

### 1. Clone o repositório

```bash
git clone https://github.com/seu-usuario/LoginSystem.git
```

### 2. Abra no Visual Studio

Abra o arquivo:

```
LoginSystem.sln
```

### 3. Configure o banco de dados

- Criar o banco
- Criar a tabela `Users`
- Configurar a Connection String

### 4. Executar

Pressione

```
F5
```

ou

```
Ctrl + F5
```

---

## 📚 Conceitos estudados

- ASP.NET Core MVC
- Model-View-Controller
- Injeção de Dependência
- Repository Pattern
- Service Layer
- Session
- Criptografia de senhas
- SQL Server
- Validação de dados
- ViewModels
- Organização em camadas

---

## 📌 Próximas funcionalidades

- [ ] Dashboard administrativo
- [ ] CRUD completo de usuários
- [ ] Perfil do usuário
- [ ] Recuperação de senha
- [ ] Upload de foto de perfil
- [ ] Controle de permissões (Admin / Usuário)
- [ ] Autenticação com Cookies
- [ ] Entity Framework Core
- [ ] Paginação
- [ ] Pesquisa de usuários
- [ ] Responsividade aprimorada
- [ ] Tema escuro

---

## 🎯 Objetivo

Este projeto faz parte dos meus estudos em desenvolvimento Back-end utilizando ASP.NET Core MVC e SQL Server, buscando aplicar boas práticas de arquitetura, organização de código e desenvolvimento de aplicações web.

---

## 👨‍💻 Autor

**Abner Gabriel Affonso**

GitHub:
https://github.com/SEU-USUARIO

LinkedIn:
https://www.linkedin.com/in/SEU-LINKEDIN

---

## 📄 Licença

Este projeto foi desenvolvido para fins de estudo e aprendizado.
