# MovieTrack

Projeto fullstack para gerenciar interações com filmes.

- **Backend:** .NET 8 + PostgreSQL (Clean Architecture)
- **Frontend:** Next.js 15 + React 19

## Estrutura

- `back/` — API .NET
- `front/` — Frontend Next.js
- `docker-compose.yml` — PostgreSQL
- `AGENTS.md` — guia para agentes de IA

## Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (ou SDK 10 com runtime 8)
- Node.js 20+
- Docker Desktop (para PostgreSQL)

## Setup

```bash
# 1. Dependências
npm install
npm --prefix front ci

# 2. Banco de dados
npm run db:up
npm run db:migrate

# 3. Connection string (User Secrets — não commitar)
dotnet user-secrets set "ConnectionStrings:DefaultConnection" \
  "Host=localhost;Port=5432;Database=movietrack_db;Username=user;Password=Pass123$" \
  --project back/MovieTrack.Api
```

## Desenvolvimento

```bash
npm run dev:back    # API — http://localhost:5264/swagger
npm run dev:front   # Next.js — http://localhost:3000
```

## Harness (verificação)

```bash
npm run verify      # verificação completa (back + front)
npm run fix         # corrige formatação
```

O CI no GitHub Actions roda `npm run verify` em todo push/PR.

## Autor

Rafael Matos
