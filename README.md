DIO - Trilha .NET - Fundamentos
===

Informações sobre o desafio original em: [trilha-net-fundamentos-desafio](https://github.com/digitalinnovationone/trilha-net-fundamentos-desafio)

## Como foi resolvido?


Nesse projeto além de ser usada a framework .NET 6.0 e a linguagem C# e todos os conhecimentos adquiridos, procurei usar conceitos de MVVM (Model View ViewModel) para implementar toda a aplicação. De forma a obter uma boa separação de atribuições entre as entidades, sem com isso,
aumentar demais a complexidade. A estrutura do projeto é bem básica, embora mais complexa do que o pedido. Mas por que esse tipo de implementação? Bom, como o projeto busca ser também um portfólio, preferi englobar um pouco de minha bagagem.

## O que há de adicional/diferente em termos de funcionalidade?
- Possibilidade de estacionar Carros e Motos
- Configurar inicialmente e posteriormente os parâmetros como preço por hora de cada veículo e o preço inicial cobrado por estacionamento.
- Listar e exibir todos os parâmetros
- Acumular e exibir o saldo de caixa
- O tempo de estacionamento perguntado durante a remoção de um veículo é dado em minutos ao invés de horas

## Como executar o projeto?

De dentro da **raiz** do projeto, rode o seguinte comando no seu **terminal**:

```bash
dotnet run --project Aplicacao
```

> É preciso ter o .NET 6.0 SDK instalado.
