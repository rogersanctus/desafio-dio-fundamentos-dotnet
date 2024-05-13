namespace DesafioDioEstacionamento.ViewModel;

using System.Collections.ObjectModel;
using DesafioDioEstacionamento.Lib.ViewModel;
using DesafioDioEstacionamento.Model;

public class EstacionamentoViewModel : ViewModelBase
{
  private Estacionamento estacionamento;

  public EstacionamentoViewModel(GerenteDadosVeiculo gerenteVeiculos)
  {
    this.estacionamento = new Estacionamento(gerenteVeiculos);
  }

  public void AtualizarPrecoInicial(decimal preco)
  {
    this.estacionamento.SetPrecoInicial(preco);
    this.NotificarView("AtualizarPrecoInicial:Sucesso");
  }

  public void CadastrarVeiculo(Veiculo veiculo)
  {
    try
    {
      estacionamento.AdicionarVeiculo(veiculo);
      this.NotificarView("AdicionarVeiculo:Sucesso");
    }
    catch (InvalidOperationException ex)
    {
      this.NotificarView("AdicionarVeiculo:Erro", ex.Message);
    }
  }

  public void RemoverVeiculo(string placa, int tempoMinutos = 0)
  {
    try
    {
      var custo = estacionamento.RemoverVeiculo(placa, tempoMinutos);
      this.NotificarView("RemoverVeiculo:Sucesso", $"{custo}");
    }
    catch (InvalidOperationException ex)
    {
      this.NotificarView("RemoverVeiculo:Erro", ex.Message);
    }
  }

  public ReadOnlyCollection<Veiculo> GetListVeiculos()
  {
    return this.estacionamento.ListarVeiculos().AsReadOnly();
  }

  internal void AtualizarPrecoicial(decimal precoInicial)
  {
    this.estacionamento.SetPrecoInicial(precoInicial);
    this.NotificarView("AtualizarPrecoInicial:Sucesso");
  }
}
