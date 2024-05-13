namespace DesafioDioEstacionamento.View;

using DesafioDioEstacionamento.Lib.View;
using DesafioDioEstacionamento.ViewModel;
using DesafioDioEstacionamento.Model;
using DesafioDioEstacionamento.Infra.Utils;

public class GerenteVeiculosView : ViewBase
{
  /// TODO: Implementar a exibição dos dados de veículos que podem ser estacionados

  // private bool 
  public GerenteVeiculosView(GerenteVeiculosViewModel viewModel) : base(viewModel)
  {
  }

  public override void Notificar(string evento, string? argumento = null)
  {
    switch (evento)
    {
      case "AtualizarVeiculo:Sucesso":
        ConsoleWriter.WriteLine("Dados do Veículo atualizados com sucesso");
        break;

      case "AtualizarVeiculo:Erro":
        ConsoleWriter.WriteLine("Erro ao atualizar dados do veículo", ConsoleColor.Red);
        if (argumento != null)
        {
          ConsoleWriter.WriteLine(argumento, ConsoleColor.Red);
        }
        break;
    }

    ConsoleWriter.WriteLine();
  }

  public void ConfigurarTipoVeiculo()
  {
    ConsoleWriter.WriteLine("Configurando tipo de veículo");

    var viewModel = (GerenteVeiculosViewModel)ViewModel;
    var veiculosNaoInicializados = viewModel.GetVeiculosNaoInicializados().ToList();

    if (veiculosNaoInicializados.Count > 0)
    {
      ConsoleWriter.WriteLine("No momento, estes são os veículos que precisam ser inicializados:", ConsoleColor.Cyan);
      veiculosNaoInicializados.ForEach(veiculo => ConsoleWriter.WriteLine($"Tipo: {(int)veiculo.Tipo} - Nome: {veiculo.Nome}, Preço por Hora: {veiculo.PrecoPorHora}", ConsoleColor.Cyan));
      ConsoleWriter.WriteLine();
    }

    ConsoleWriter.Write("Informe o Tipo de veículo para atualizar: ");
    var tipo = Console.ReadLine();

    if (string.IsNullOrEmpty(tipo))
    {
      ConsoleWriter.WriteLine("O Tipo de veículo não pode ser vazio", ConsoleColor.Red);
      return;
    }

    TipoVeiculo tipoVeiculo;

    try
    {
      tipoVeiculo = (TipoVeiculo)Enum.Parse(typeof(TipoVeiculo), tipo);
    }
    catch (Exception ex)
    {
      if (ex is ArgumentException || ex is OverflowException)
      {
        ConsoleWriter.WriteLine("Tipo de veículo inválido.", ConsoleColor.Red);
        return;
      }

      throw;
    }

    ConsoleWriter.Write("Informe o novo preço por hora: ");
    var precoPorHoraStr = Console.ReadLine();

    if (string.IsNullOrEmpty(precoPorHoraStr))
    {
      ConsoleWriter.WriteLine("O Preço por Hora não pode ser vazio", ConsoleColor.Red);
      return;
    }

    decimal precoPorHora;

    if (!decimal.TryParse(precoPorHoraStr, out precoPorHora))
    {
      ConsoleWriter.WriteLine("Preço por Hora inválido", ConsoleColor.Red);
      return;
    }

    viewModel.AtualizarVeiculo(tipoVeiculo, precoPorHora);
  }
}
