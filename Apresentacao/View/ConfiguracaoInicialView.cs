namespace DesafioDioEstacionamento.View;

using DesafioDioEstacionamento.Lib.UI;
using DesafioDioEstacionamento.Lib.View;
using DesafioDioEstacionamento.Lib.ViewModel;
using DesafioDioEstacionamento.Model;
using DesafioDioEstacionamento.ViewModel;

public class ConfiguracaoInicialView : ViewBase
{
  private ConfiguracaoInicialViewModel _viewModel
  {
    get
    {
      return (ConfiguracaoInicialViewModel)this.ViewModel;
    }
  }

  public ConfiguracaoInicialView(ViewModelBase viewModel) : base(viewModel)
  {
  }

  public override void Notificar(string evento, string? argumento = null)
  {
  }

  public void ConfigurarEstacionamento()
  {
    ConsoleWriter.WriteLine("Configurando o estacionamento");
    ConsoleWriter.WriteLine("---");
    ConsoleWriter.WriteLine();

    decimal? precoInicial = CommonView.ConfigurarPrecoInicial();

    if (precoInicial != null)
    {
      _viewModel.AtualizarPrecoInicial((decimal)precoInicial!);
    }

    List<DadosVeiculo> dadosVeiculos = _viewModel.GetDadosVeiculos();

    ConsoleWriter.WriteLine("# Configurando dados dos tipos de veículo");
    ConsoleWriter.WriteLine();

    CommonView.ListarDadosVeiculos(dadosVeiculos);

    for (int i = 0; i < dadosVeiculos.Count; i++)
    {
      TipoVeiculo tipoVeiculo = (TipoVeiculo)i;

      ConsoleWriter.WriteLine($"## Configurando dados de: {dadosVeiculos[i].Nome}");

      DadosVeiculo? newDadoVeiculo = CommonView.ConfigurarTipoVeiculo(tipoVeiculo);

      if (newDadoVeiculo != null)
      {
        _viewModel.AtualizarVeiculo(newDadoVeiculo.Tipo, newDadoVeiculo.PrecoPorHora);
      }
    }
  }
}
