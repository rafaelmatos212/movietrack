# MovieTrack — Guia para Agentes

Projeto fullstack para gerenciar interações com filmes.

- **Backend:** .NET 10, Clean Architecture, PostgreSQL, EF Core — pasta [`back/`](back/)
- **Frontend:** Next.js 15 (App Router), React 19, TypeScript strict — pasta [`front/`](front/)

## Comando obrigatório

Antes de concluir qualquer tarefa, rode na raiz:

​```bash
npm run verify
​```

Exit code 0 = pronto. Exit code diferente de zero = corrigir e rodar de novo.

## Estrutura do backend

​```
MovieTrack.Domain       → entidades, value objects, exceções (sem dependências externas)
MovieTrack.Application  → serviços, interfaces, DTOs, mappers
MovieTrack.Infra        → EF Core, repositórios, migrations
MovieTrack.Api          → controllers, Program.cs
MovieTrack.Tests        → testes xUnit
​```

### Fronteiras

- `Domain` não referencia `Application`, `Infra` ou `Api`
- `Application` não referencia `Infra` ou `Api`
- `Api` não acessa EF Core ou DbContext diretamente
- Regras de negócio e invariantes do domínio devem permanecer no Domain,
  preferencialmente em entidades, value objects e domain services quando necessário.
- Application services/use cases são responsáveis por orquestrar o fluxo da aplicação,
  não por concentrar regras de negócio do domínio.

### Convenções de fluxo   <!-- NOVO -->

- Interfaces de serviços de aplicação ficam em `MovieTrack.Application/Interfaces`
- Entidades nunca saem de Domain/Application; controllers só lidam com Request/Response
- Fluxo: Request -> DTO -> Entidade -> DTO de saída -> Response
- Erros de autenticação são sempre genéricos (evita enumeration attack)

## Desenvolvimento local

​```bash
npm run db:up          # PostgreSQL via Docker
npm run db:migrate     # aplicar migrations
npm run dev:back       # API em http://localhost:5264
npm run dev:front      # Next.js em http://localhost:3000
​```

### Variáveis do Docker (`.env` na raiz, gitignored)   <!-- NOVO -->

O `docker-compose.yml` lê `POSTGRES_USER`, `POSTGRES_PASSWORD` e `POSTGRES_DB`
de um arquivo `.env` na raiz. Esse arquivo não vai para o Git.

### Segredos da API (obrigatório para rodar)   <!-- ALTERADO -->

Nada disso fica no repositório. Configure via User Secrets:

​```bash
dotnet user-secrets set "ConnectionStrings:DefaultConnection" \
  "Host=localhost;Port=5432;Database=SEU_DB;Username=SEU_USER;Password=SUA_SENHA" \
  --project back/MovieTrack.Api

dotnet user-secrets set "Jwt:Key" "CHAVE_ALEATORIA_COM_32+_BYTES" \
  --project back/MovieTrack.Api
​```

Use os mesmos valores do seu `.env`. Em produção, use variáveis de ambiente
(`ConnectionStrings__DefaultConnection`, `Jwt__Key`).

## Scripts do harness

| Comando | O que faz |
|---------|-----------|
| `npm run verify` | Verificação completa (back + front) |
| `npm run verify:back` | format check + build + testes |
| `npm run verify:front` | format check + lint + typecheck |
| `npm run fix` | Corrige formatação automaticamente |

## Definição de pronto

- [ ] `npm run verify` passa
- [ ] Sem `NotImplementedException` em código entregue
- [ ] Sem credenciais ou secrets commitados
- [ ] Testes cobrem regras de negócio alteradas

## Comportamento do agente

(manter como está)