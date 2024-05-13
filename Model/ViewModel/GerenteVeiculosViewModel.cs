namespace DesafioDioEstacionamento.ViewModel;

using DesafioDioEstacionamento.Lib.ViewModel;
using System.Collections.ObjectModel;
using DesafioDioEstacionamento.Model;

public class GerenteVeiculosViewModel : ViewModelBase
{
  private GerenteDadosVeiculo gerenteVeiculos;

  public GerenteVeiculosViewModel(GerenteDadosVeiculo gerenteVeiculos)
  {
    this.gerenteVeiculos = gerenteVeiculos;
  }

  public ReadOnlyCollection<DadosVeiculo> GetVeiculosNaoInicializados()
  {
    return this.gerenteVeiculos.GetVeiculosNaoInicializados().AsReadOnly();
  }

  public void AtualizarVeiculo(TipoVeiculo tipo, decimal precoPorHora)
  {
    try
    {
      this.gerenteVeiculos.AtualizarVeiculo(tipo, precoPorHora);
      this.NotificarView("AtualizarVeiculo:Sucesso");
    }
    catch (InvalidOperationException ex)
    {
      this.NotificarView("AtualizarVeiculo:Erro", ex.Message);
    }
  }

}
