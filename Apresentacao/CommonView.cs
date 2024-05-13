using DesafioDioEstacionamento.Lib.UI;
using DesafioDioEstacionamento.Model;

namespace DesafioDioEstacionamento.View;

public static class CommonView
{
  public static decimal? ConfigurarPrecoInicial()
  {
    ConsoleWriter.WriteLine("# Configurando preco inicial");
    ConsoleWriter.WriteLine();

    ConsoleWriter.Write("Informe o preco inicial: ");
    var precoInicialStr = Console.ReadLine();

    if (string.IsNullOrEmpty(precoInicialStr))
    {
      ConsoleWriter.WriteLine("O preço inicial não pode ser vazio.", ConsoleColor.Red);
      ConsoleWriter.WriteLine();
      return null;
    }

    decimal precoInicial;

    if (!decimal.TryParse(precoInicialStr, out precoInicial))
    {
      ConsoleWriter.WriteLine("Preço inicial inválido", ConsoleColor.Red);
      ConsoleWriter.WriteLine();
      return null;
    }

    return precoInicial;
  }

  public static DadosVeiculo? ConfigurarTipoVeiculo(TipoVeiculo tipoVeiculo)
  {
    ConsoleWriter.Write("Informe o novo preço por hora: ");
    var precoPorHoraStr = Console.ReadLine();

    if (string.IsNullOrEmpty(precoPorHoraStr))
    {
      ConsoleWriter.WriteLine("O Preço por Hora não pode ser vazio", ConsoleColor.Red);
      return null;
    }

    decimal precoPorHora;

    if (!decimal.TryParse(precoPorHoraStr, out precoPorHora))
    {
      ConsoleWriter.WriteLine("Preço por Hora inválido", ConsoleColor.Red);
      return null;
    }

    return new DadosVeiculo(tipoVeiculo, "", precoPorHora);

  }

  public static void ListarDadosVeiculos(List<DadosVeiculo> dadosVeiculos)
  {
    ConsoleWriter.WriteLine("Veículos que podem ser estacionados:", ConsoleColor.Cyan);
    dadosVeiculos.ForEach(veiculo => ConsoleWriter.WriteLine($"Tipo: {(int)veiculo.Tipo} - Nome: {veiculo.Nome}, Preço por Hora: {veiculo.PrecoPorHora}", ConsoleColor.Cyan));
    ConsoleWriter.WriteLine();

  }

  public static DadosVeiculo? ConfigurarTiposVeiculo(List<DadosVeiculo> dadosVeiculos)
  {
    ConsoleWriter.WriteLine("Configurando dados dos tipos de veículo");
    ConsoleWriter.WriteLine();

    CommonView.ListarDadosVeiculos(dadosVeiculos);

    ConsoleWriter.Write("Informe o Tipo de veículo para atualizar: ");
    var tipo = Console.ReadLine();

    if (string.IsNullOrEmpty(tipo))
    {
      ConsoleWriter.WriteLine("O Tipo de veículo não pode ser vazio", ConsoleColor.Red);
      return null;
    }

    TipoVeiculo tipoVeiculo;

    try
    {
      tipoVeiculo = (TipoVeiculo)Enum.Parse(typeof(TipoVeiculo), tipo);
      return CommonView.ConfigurarTipoVeiculo(tipoVeiculo);
    }
    catch (Exception ex)
    {
      if (ex is ArgumentException || ex is OverflowException)
      {
        ConsoleWriter.WriteLine("Tipo de veículo inválido.", ConsoleColor.Red);
        return null;
      }

      throw;
    }

  }
}
