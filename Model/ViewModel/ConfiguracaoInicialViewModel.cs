namespace DesafioDioEstacionamento.ViewModel;

using DesafioDioEstacionamento.Lib.ViewModel;
using DesafioDioEstacionamento.Model;

public class ConfiguracaoInicialViewModel : ViewModelBase
{
  private GerenteVeiculosViewModel gerenteVeiculosViewModel;
  private EstacionamentoViewModel estacionamentoViewModel;

  public ConfiguracaoInicialViewModel(GerenteVeiculosViewModel gerenteVeiculosViewModel, EstacionamentoViewModel estacionamentoViewModel)
  {
    this.gerenteVeiculosViewModel = gerenteVeiculosViewModel;
    this.estacionamentoViewModel = estacionamentoViewModel;
  }

  public bool IsDadosVeiculosInicializados
  {
    get => this.gerenteVeiculosViewModel.GetVeiculosNaoInicializados().Count == 0;
  }

  public List<DadosVeiculo> GetDadosVeiculos()
  {
    return this.gerenteVeiculosViewModel.GetVeiculos();
  }

  public void AtualizarVeiculo(TipoVeiculo tipo, decimal precoPorHora)
  {
    this.gerenteVeiculosViewModel.AtualizarVeiculo(tipo, precoPorHora);
  }

  public void AtualizarPrecoInicial(decimal preco)
  {
    this.estacionamentoViewModel.AtualizarPrecoInicial(preco);
  }
}
