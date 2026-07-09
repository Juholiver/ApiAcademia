# ApiAcademia2

API simples em ASP.NET Core 10 que fornece dados de exercícios de academia a partir de um arquivo JSON local.

## Visão geral

- Projeto: `ApiAcademia2`
- Tipo: ASP.NET Core Web API
- Framework: .NET 10 (`net10.0`)
- Dados: `Data/exercicios.json`
- Endpoint principal: `GET /api/exercicios`

## Funcionamento

O projeto carrega um arquivo JSON com exercícios em `Data/exercicios.json` e expõe uma rota para recuperar a lista completa.

`ExerciciosService` busca o arquivo de dados com prioridade em:
- `ContentRootPath/Data/exercicios.json`
- `AppContext.BaseDirectory/Data/exercicios.json`
- `Directory.GetCurrentDirectory()/Data/exercicios.json`

## Executar o projeto

1. Abra a pasta `ApiAcademia2` no VS Code ou no terminal.
2. Execute:

```powershell
dotnet run --project ApiAcademia2.csproj
```

3. Acesse a API em:

```text
http://localhost:5000/api/exercicios
```

> Dependendo da configuração do ASP.NET Core, a porta pode variar se estiver usando o `launchSettings.json` no Visual Studio.

## Endpoint

### GET /api/exercicios

Retorna a lista completa de exercícios armazenados no JSON.

Resposta de exemplo:

```json
[
  {
    "id": 1,
    "nome": "Supino Reto com Barra",
    "grupoMuscular": "Peito",
    "musculosSecundarios": ["Tríceps", "Deltoide anterior"],
    "equipamento": "Barra",
    "tipo": "Composto",
    "nivel": "Intermediário",
    "seriesRecomendadas": "3 a 4",
    "repeticoes": "8 a 12",
    "observacao": "Desça a barra até a linha do peito mantendo os punhos alinhados e os pés firmes no chão.",
    "gif": "https://..."
  }
]
```

## Modelo de dados

A classe `Exercicio` contém estas propriedades:

- `Id` (int)
- `Nome` (string)
- `GrupoMuscular` (string)
- `MusculosSecundarios` (List<string>)
- `Equipamento` (string)
- `Tipo` (string)
- `Nivel` (string)
- `SeriesRecomendadas` (string)
- `Repeticoes` (string)
- `Observacao` (string)
- `Gif` (string)

## Estrutura do projeto

- `Program.cs` — configura o app, registra CORS, controllers e serviço singleton.
- `Controllers/ExerciciosController.cs` — expõe o endpoint `GET /api/exercicios`.
- `Services/ExerciciosService.cs` — lê o arquivo JSON e desserializa os exercícios.
- `Models/Exercicio.cs` — define o modelo de dados.
- `Data/exercicios.json` — dados de exercícios usados pela API.

## Observações

- O CORS está configurado para permitir `http://localhost:5173`, ideal para um front-end em Vite.
- Se necessário, ajuste a origem CORS ou adicione novos endpoints.
