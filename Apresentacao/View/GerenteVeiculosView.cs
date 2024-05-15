namespace DesafioDioEstacionamento.View;

using DesafioDioEstacionamento.Lib.View;
using DesafioDioEstacionamento.ViewModel;
using DesafioDioEstacionamento.Model;
using DesafioDioEstacionamento.Lib.UI;

public class GerenteVeiculosView : ViewBase
{
  public GerenteVeiculosView(GerenteVeiculosViewModel viewModel) : base(viewModel)
  {
  }

  private GerenteVeiculosViewModel _viewModel
  {
    get => (GerenteVeiculosViewModel)this.ViewModel;
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
    List<DadosVeiculo> dadosVeiculos = _viewModel.GetVeiculos();
    var newDadoVeiculo = CommonView.ConfigurarTiposVeiculo(dadosVeiculos);

    if (newDadoVeiculo.HasValue)
    {
      var (Tipo, PrecoPorHora) = newDadoVeiculo.Value;
      _viewModel.AtualizarVeiculo(Tipo, PrecoPorHora);
    }
  }

  public void ListarDadosVeiculos()
  {
    ConsoleWriter.WriteLine("Listando dados dos tipos de veículos");
    ConsoleWriter.WriteLine("---");

    List<DadosVeiculo> dadosVeiculos = _viewModel.GetVeiculos();
    dadosVeiculos.ForEach(CommonView.ExibirDadosVeiculo);

    ConsoleWriter.WriteLine();
  }

}
