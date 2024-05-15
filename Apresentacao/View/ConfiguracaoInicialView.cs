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
    get => (ConfiguracaoInicialViewModel)this.ViewModel;
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

      var newDadoVeiculo = CommonView.ConfigurarTipoVeiculo(tipoVeiculo);

      if (newDadoVeiculo.HasValue)
      {
        var (Tipo, PrecoPorHora) = newDadoVeiculo.Value;
        _viewModel.AtualizarVeiculo(Tipo, PrecoPorHora);
      }
    }

    if (!_viewModel.IsDadosVeiculosInicializados)
    {
      ConsoleWriter.WriteLine("Um ou outro veículo não foi inicializado. Para conseguir operar o estacionamento, é necessário configurar todos os veículos.", ConsoleColor.Yellow);
      ConsoleWriter.Write("Mas não se preocupe, na próxima tela, você pode configurar os veículos remanescentes na opção: ", ConsoleColor.Yellow);
      ConsoleWriter.WriteLine("Configurar Tipo de Veículo.", ConsoleColor.Blue);
      ConsoleWriter.Write("Você pode verificar os dados dos tipos de veiculos na opção: ", ConsoleColor.Yellow);
      ConsoleWriter.WriteLine("Listar Dados dos Tipos de Veiculos.", ConsoleColor.Blue);
      ConsoleWriter.WriteLine();
    }
  }
}
