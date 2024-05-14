namespace DesafioDioEstacionamento.View;

using DesafioDioEstacionamento.Lib.View;
using DesafioDioEstacionamento.ViewModel;
using DesafioDioEstacionamento.Model;
using DesafioDioEstacionamento.Lib.UI;

public class GerenteVeiculosView : ViewBase
{
  /// TODO: Implementar a exibição dos dados de veículos que podem ser estacionados

  public GerenteVeiculosView(GerenteVeiculosViewModel viewModel) : base(viewModel)
  {
  }

  public override void Notificar(string evento, string? argumento = null)
  {
    switch (evento)
    {
      case "AtualizarVeiculo:Sucesso":
        ConsoleWriter.WriteLine("Dados do Veículo atualizados com sucesso", ConsoleColor.Green);
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
    var viewModel = (GerenteVeiculosViewModel)ViewModel;
    List<DadosVeiculo> dadosVeiculos = viewModel.GetVeiculos();
    var newDadoVeiculo = CommonView.ConfigurarTiposVeiculo(dadosVeiculos);

    if (newDadoVeiculo != null)
    {
      viewModel.AtualizarVeiculo(newDadoVeiculo.Tipo, newDadoVeiculo.PrecoPorHora);
    }
  }
}
