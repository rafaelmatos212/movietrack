# MovieTrack — Guia para Agentes

Projeto fullstack para gerenciar interações com filmes.

- **Backend:** .NET 8, Clean Architecture, PostgreSQL, EF Core — pasta [`back/`](back/)
- **Frontend:** Next.js 15 (App Router), React 19, TypeScript strict — pasta [`front/`](front/)

## Comando obrigatório

Antes de concluir qualquer tarefa, rode na raiz:

```bash
npm run verify
```

Exit code 0 = pronto. Exit code diferente de zero = corrigir e rodar de novo.

## Estrutura do backend

```
MovieTrack.Domain       → entidades, value objects, exceções (sem dependências externas)
MovieTrack.Application  → serviços, DTOs, mappers
MovieTrack.Infra        → EF Core, repositórios, migrations
MovieTrack.Api          → controllers, Program.cs
MovieTrack.Tests        → testes xUnit
```

### Fronteiras

- `Domain` não referencia `Application`, `Infra` ou `Api`
- `Application` não referencia `Infra` ou `Api`
- `Api` não acessa EF Core ou DbContext diretamente
- Regras de negócio e invariantes do domínio devem permanecer no Domain,
  preferencialmente em entidades, value objects e domain services quando necessário.
- Application services/use cases são responsáveis por orquestrar o fluxo da aplicação,
  não por concentrar regras de negócio do domínio.

## Desenvolvimento local

```bash
npm run db:up          # PostgreSQL via Docker
npm run db:migrate     # aplicar migrations
npm run dev:back       # API em http://localhost:5264
npm run dev:front      # Next.js em http://localhost:3000
```

### Connection string (obrigatório para rodar a API)

A connection string não fica no repositório. Configure via User Secrets:

```bash
dotnet user-secrets set "ConnectionStrings:DefaultConnection" \
  "Host=localhost;Port=5432;Database=movietrack_db;Username=user;Password=SUA_SENHA" \
  --project back/MovieTrack.Api
```

Use as credenciais do [`docker-compose.yml`](docker-compose.yml).

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

Antes de implementar uma alteração:

1. Leia o AGENTS.md e as regras aplicáveis.
2. Inspecione o código existente relacionado à tarefa.
3. Identifique as camadas afetadas.
4. Respeite as fronteiras arquiteturais existentes.
5. Reutilize abstrações existentes quando apropriado.
6. Não crie abstrações, padrões ou dependências desnecessárias.
7. Não altere contratos existentes sem avaliar os impactos.
8. Implemente a menor alteração necessária para atender ao requisito.
9. Execute os testes e verificações obrigatórias.
10. Não considere a tarefa concluída enquanto `npm run verify` não passar.