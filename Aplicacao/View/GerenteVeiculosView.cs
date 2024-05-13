namespace DesafioDioEstacionamento.View;
using DesafioDioEstacionamento.ViewModel;
using DesafioDioEstacionamento.Model;

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
        Console.WriteLine("Dados do Veículo atualizados com sucesso");
        break;

      case "AtualizarVeiculo:Erro":
        Console.WriteLine("Erro ao atualizar dados do veículo");
        if (argumento != null)
        {
          Console.WriteLine(argumento);
        }
        break;
    }

    Console.WriteLine();
  }

  public void ConfigurarTipoVeiculo()
  {
    Console.WriteLine("Configurando tipo de veículo");

    var viewModel = (GerenteVeiculosViewModel)ViewModel;
    var veiculosNaoInicializados = viewModel.GetVeiculosNaoInicializados().ToList();

    if (veiculosNaoInicializados.Count > 0)
    {
      Console.WriteLine("No momento, estes são os veículos que precisam ser inicializados:");
      veiculosNaoInicializados.ForEach(veiculo => Console.WriteLine($"Tipo: {(int)veiculo.Tipo} - Nome: {veiculo.Nome}, Preço por Hora: {veiculo.PrecoPorHora}"));
      Console.WriteLine();
    }

    Console.Write("Informe o Tipo de veículo para atualizar: ");
    var tipo = Console.ReadLine();

    if (string.IsNullOrEmpty(tipo))
    {
      Console.WriteLine("O Tipo de veículo não pode ser vazio");
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
        Console.WriteLine("Tipo de veículo inválido.");
        return;
      }

      throw;
    }

    Console.Write("Informe o novo preço por hora: ");
    var precoPorHoraStr = Console.ReadLine();

    if (string.IsNullOrEmpty(precoPorHoraStr))
    {
      Console.WriteLine("O Preço por Hora não pode ser vazio");
      return;
    }

    decimal precoPorHora;

    if (!decimal.TryParse(precoPorHoraStr, out precoPorHora))
    {
      Console.WriteLine("Preço por Hora inválido");
      return;
    }

    viewModel.AtualizarVeiculo(tipoVeiculo, precoPorHora);
  }
}
