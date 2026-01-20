## Fluxograma da Estrutura do Programa (Estacionamento)

Este ficheiro mostra um fluxograma (Mermaid) da estrutura principal do programa implementado nos ficheiros `main.c`, `funcoes.c` e `structs.h`.

Para visualizar o diagrama no VS Code, utilize a pré-visualização de Markdown com uma extensão que suporte Mermaid (por exemplo, "Markdown Preview Mermaid Support").

```mermaid
graph TD
    Start([Start]) --> Main[main()]
    Main --> Mostrar[mostrarMenu()]
    Mostrar --> Input{opcao}
    Input -->|1| MenuV[menuVeiculos()]
    Input -->|2| MenuR[menuReservas()]
    Input -->|3| MenuP[menuPesquisas()]
    Input -->|4| MenuO[menuOutros()]
    Input -->|0| Exit([Sair])

    subgraph Veiculos [Menu Veículos]
      MenuV --> V1[inserirNovoCarro()]
      MenuV --> V2[listarMatriculas()]
      MenuV --> V3[alterarDadosCarro()]
      MenuV --> V4[removerCarro()]
    end

    subgraph Reservas [Menu Reservas]
      MenuR --> R1[reservarLugar()]
      MenuR --> R2[listarOcupacao()]
      MenuR --> R3[alterarReservasParque()]
      MenuR --> R4[desocuparLugar()]
    end

    subgraph Pesquisas [Menu Pesquisas]
      MenuP --> P1[pesquisarPorMatricula()]
      MenuP --> P2[pesquisarPorNIF()]
      MenuP --> P3[pesquisarPorNumMec()]
    end

    subgraph Outros [Menu Outros]
      MenuO --> O1[adicionarVeiculoProprietario()]
      MenuO --> O2[contarLugaresLivresPorData()]
      MenuO --> O3[historicoReservasPorMatricula()]
    end

    %% Utilitários e ficheiros
    Utils[Utilitários]
    Utils --> parse[parse_line_to_carro(), get_today_str(), is_valid_date_str(), date parsing]
    Utils --> limpar[limparReservasAntigas()]
    Utils --> clear[clearScreen()]

    Files[Ficheiros de Dados]
    Files --> carros["carros.txt (FICHEIRO)"]
    Files --> reservas["reservas.txt (FICHEIRO_RESERVAS)"]

    %% Ligações adicionais
    V1 --> Files
    R1 --> Files
    limpar --> Files
    parse --> Files

    Exit --> End([Fim])
```

Breve descrição:

- `main.c` controla o ciclo principal: mostra o menu e processa a opção escolhida;
- `funcoes.c` implementa os menus (`menuVeiculos`, `menuReservas`, `menuPesquisas`, `menuOutros`) e as operações chamadas por esses menus (inserir, listar, alterar, remover, reservar, etc.);
- `structs.h` define `Carro` e macros com os nomes dos ficheiros (`carros.txt`, `reservas.txt`) usados para persistência;
- Funções utilitárias (parsing, validação de datas, limpeza de reservas antigas) manipulam estes ficheiros.

Como ver o fluxograma:

- No VS Code abra `fluxograma.md` e ative a pré-visualização Markdown.
- Se o VS Code não renderizar Mermaid por defeito, instale a extensão "Markdown Preview Mermaid Support" ou use um visualizador online para renderizar o bloco Mermaid.

Ficheiro criado: `fluxograma.md`
