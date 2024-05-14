namespace DesafioDioEstacionamento.View;

using DesafioDioEstacionamento.Lib.UI;
using DesafioDioEstacionamento.Lib.View;
using DesafioDioEstacionamento.Model;
using DesafioDioEstacionamento.ViewModel;

public class EstacionamentoView : ViewBase
{
  public EstacionamentoView(EstacionamentoViewModel viewModel) : base(viewModel)
  {
  }

  public EstacionamentoViewModel _viewModel
  {
    get
    {
      return (EstacionamentoViewModel)this.ViewModel;
    }
  }

  override public void Notificar(string evento, string? argumento)
  {
    ConsoleWriter.WriteLine();

    switch (evento)
    {
      case "AdicionarVeiculo:Sucesso":
        ConsoleWriter.WriteLine("Veículo adicionado com sucesso", ConsoleColor.Green);
        break;
      case "AdicionarVeiculo:Erro":
        ConsoleWriter.WriteLine("Erro ao adicionar veículo.", ConsoleColor.Red);

        if (argumento != null)
        {
          ConsoleWriter.WriteLine(argumento, ConsoleColor.Red);
        }
        break;
      case "RemoverVeiculo:Sucesso":
        if (decimal.TryParse(argumento, out decimal custo))
        {

          ConsoleWriter.WriteLine("Veículo removido com sucesso", ConsoleColor.Green);
          ConsoleWriter.WriteLine($"Total a pagar pelo estacionamento: {custo:N}", ConsoleColor.Green);
        }
        else
        {
          ConsoleWriter.WriteLine("Formato de custo inválido.", ConsoleColor.Red);
        }
        break;
      case "RemoverVeiculo:Erro":
        ConsoleWriter.WriteLine("Erro ao remover veículo.", ConsoleColor.Red);

        if (argumento != null)
        {
          ConsoleWriter.WriteLine(argumento, ConsoleColor.Red);
        }
        break;
      case "AtualizarPrecoInicial:Sucesso":
        ConsoleWriter.WriteLine("Preço atualizado com sucesso", ConsoleColor.Green);
        break;
    }

    ConsoleWriter.WriteLine();
  }

  public void ConfigurarPrecoInicial()
  {
    decimal? precoInicial = CommonView.ConfigurarPrecoInicial();

    if (precoInicial != null)
    {
      // viewModel.SetPrecoInicial(precoInicial);
      var viewModel = (EstacionamentoViewModel)this.ViewModel;
      viewModel.AtualizarPrecoInicial((decimal)precoInicial);
    }
  }

  public void ExibirPrecoInicial()
  {
    ConsoleWriter.WriteLine("Exibindo Preço Inicial");
    ConsoleWriter.WriteLine("---");
    var precoInicial = _viewModel.GetPrecoInicial();
    ConsoleWriter.WriteLine($"R$: {precoInicial:N}", ConsoleColor.Cyan);
    ConsoleWriter.WriteLine();
  }

  public void CadastrarVeiculo()
  {
    ConsoleWriter.WriteLine("Cadastrando veículo");

    Console.Write("Informe o tipo de veículo: ");
    var tipoVeiculo = Console.ReadLine();

    Console.Write("Informe a placa do veículo: ");
    var placa = Console.ReadLine();

    if (string.IsNullOrEmpty(tipoVeiculo) || string.IsNullOrEmpty(placa))
    {
      ConsoleWriter.WriteLine("Tipo de veículo e placa devem ser informados", ConsoleColor.Red);
      return;
    }

    EstacionamentoViewModel viewModel = (EstacionamentoViewModel)this.ViewModel;

    try
    {
      TipoVeiculo tipo = Enum.Parse<TipoVeiculo>(tipoVeiculo);
      Veiculo veiculo = new Veiculo(tipo, placa);
      viewModel.CadastrarVeiculo(veiculo);
    }
    catch (Exception ex)
    {
      if (ex is ArgumentException || ex is ArgumentNullException)
      {
        ConsoleWriter.WriteLine("Tipo de veículo inválido", ConsoleColor.Red);
      }

      throw;
    }

  }

  public void RemoverVeiculo()
  {
    ConsoleWriter.WriteLine("Removendo veículo");

    Console.Write("Informe o tempo em minutos em que o veículo ficou estacionado: ");
    var tempoEstacionamentoMinutos = Console.ReadLine();

    try
    {
      int tempoEstacionamento = Convert.ToInt32(tempoEstacionamentoMinutos);

      Console.Write("Informe a placa do veículo: ");
      var placa = Console.ReadLine();

      if (string.IsNullOrEmpty(placa))
      {
        ConsoleWriter.WriteLine("Favor informar a placa do veículo", ConsoleColor.Yellow);
        return;
      }

      EstacionamentoViewModel viewModel = (EstacionamentoViewModel)this.ViewModel;
      viewModel.RemoverVeiculo(placa, tempoEstacionamento);
    }
    catch (FormatException)
    {
      ConsoleWriter.WriteLine("Formato do tempo de estacionamento inválido. O valor precisa ser um número inteiro.", ConsoleColor.Red);
    }
  }

  public void ListarVeiculos()
  {
    ConsoleWriter.WriteLine("Listando veículos");
    ConsoleWriter.WriteLine("---");

    var viewModel = (EstacionamentoViewModel)this.ViewModel;

    var veiculos = viewModel.GetListaVeiculos();

    if (veiculos.Count > 0)
    {
      foreach (var veiculo in veiculos)
      {
        ConsoleWriter.WriteLine($"Tipo: {veiculo.Tipo}  - Placa: {veiculo.Placa}");
      }
    }
    else
    {
      ConsoleWriter.WriteLine("Nenhum veículo no estacionamento", ConsoleColor.Cyan);
    }

    ConsoleWriter.WriteLine();
  }
}
