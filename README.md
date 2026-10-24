# Catálogo de Produtos API

Nome recomendado para o repositório: `catalogo-produtos-api`.

API de exemplo para consultas de produtos, sem banco de dados. Os dados são fictícios, determinísticos e mantidos em memória; reiniciar a aplicação restaura os mesmos registros.

## Consultar produtos

Execute a API com `dotnet run --project Api/Api.csproj` e consulte:

- `GET /api/products` — lista os produtos.
- `GET /api/products?name=mon` — busca nome sem diferenciar maiúsculas/minúsculas.
- `GET /api/products?category=Eletronicos&minPrice=1000&maxPrice=2000` — combina categoria e faixa de preço.

Filtros de preço negativos e `minPrice` superior a `maxPrice` retornam `400 Bad Request`. Uma consulta sem resultados retorna `200 OK` com uma lista vazia.

Execute os testes com `dotnet test CatalogoProdutos.slnx`.

## Fluxo de branches no GitHub

O workflow `.github/workflows/ci.yml` compila e testa a solução em pull requests para `dev` e `main`. Para PRs destinados a `main`, o check falha se a branch de origem não for exatamente `dev`.

O arquivo de workflow não ativa, por si só, proteção de branches. No GitHub, crie um ruleset para `main` (Settings → Rules → Rulesets) e configure:

1. Exigir pull request antes do merge; desabilitar bypasses se a regra deve valer também para administradores.
2. Exigir o status check `CI / build-and-test`.
3. Bloquear force push e exclusão da branch.
4. Não permitir push direto à `main`; a validação exige que o PR venha da branch `dev` do próprio repositório. Mantenha `dev` como branch de integração.
5. Opcionalmente, exigir aprovação de revisores conforme o tamanho da equipe.

Se também quiser que `dev` só receba mudanças via PR, aplique regras equivalentes nela e exija o check `CI / build-and-test`. Nesse fluxo, branches de trabalho entram em `dev`, e somente `dev` é promovida para `main`.

As regras do GitHub devem ser habilitadas no repositório; confirme que o nome do check exigido corresponde ao exibido na primeira execução do workflow.
