namespace DesafioDioEstacionamento.View;

using DesafioDioEstacionamento.Model;
using DesafioDioEstacionamento.ViewModel;

public class EstacionamentoView : ViewBase
{

  /// TODO: Implementar exibição do preço Inicial

  public EstacionamentoView(EstacionamentoViewModel viewModel) : base(viewModel)
  {
  }

  override public void Notificar(string evento, string? argumento)
  {
    Console.WriteLine();

    switch (evento)
    {
      case "AdicionarVeiculo:Sucesso":
        Console.WriteLine("veículo adicionado com sucesso");
        break;
      case "AdicionarVeiculo:Erro":
        Console.WriteLine("Erro ao adicionar veículo.");

        if (argumento != null)
        {
          Console.WriteLine(argumento);
        }
        break;
      case "RemoverVeiculo:Sucesso":
        if (decimal.TryParse(argumento, out decimal custo))
        {

          Console.WriteLine("veículo removido com sucesso");
          Console.WriteLine($"Total a pagar pelo estacionamento: {custo}");
        }
        else
        {
          Console.WriteLine("Formato de custo inválido.");
        }
        break;
      case "RemoverVeiculo:Erro":
        Console.WriteLine("Erro ao remover veículo.");

        if (argumento != null)
        {
          Console.WriteLine(argumento);
        }
        break;
      case "AtualizarPrecoInicial:Sucesso":
        Console.WriteLine("Preço atualizado com sucesso");
        break;
    }

    Console.WriteLine();
  }

  public void ConfigurarPrecoInicial()
  {
    Console.WriteLine("Configurando preco inicial");
    var precoInicialStr = Console.ReadLine();

    if (string.IsNullOrEmpty(precoInicialStr))
    {
      Console.WriteLine("O preço inicial não pode ser vazio.");
      Console.WriteLine();
      return;
    }

    decimal precoInicial;

    if (!decimal.TryParse(precoInicialStr, out precoInicial))
    {
      Console.WriteLine("Preço inicial inválido");
      Console.WriteLine();
      return;
    }

    // viewModel.SetPrecoInicial(precoInicial);
    var viewModel = (EstacionamentoViewModel)this.ViewModel;
    viewModel.AtualizarPrecoicial(precoInicial);
  }

  public void CadastrarVeiculo()
  {
    Console.WriteLine("Cadastrando veículo");

    Console.Write("Informe o tipo de veículo: ");
    var tipoVeiculo = Console.ReadLine();

    Console.Write("Informe a placa do veículo: ");
    var placa = Console.ReadLine();

    if (string.IsNullOrEmpty(tipoVeiculo) || string.IsNullOrEmpty(placa))
    {
      Console.WriteLine("Tipo de veículo e placa devem ser informados");
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
        Console.WriteLine("Tipo de veículo inválido");
      }

      throw;
    }

  }

  public void RemoverVeiculo()
  {
    Console.WriteLine("Removendo veículo");

    Console.Write("Informe o tempo em minutos em que o veículo ficou estacionado: ");
    var tempoEstacionamentoMinutos = Console.ReadLine();

    try
    {
      int tempoEstacionamento = Convert.ToInt32(tempoEstacionamentoMinutos);

      Console.Write("Informe a placa do veículo: ");
      var placa = Console.ReadLine();

      if (string.IsNullOrEmpty(placa))
      {
        Console.WriteLine("Favor informar a placa do veículo");
        return;
      }

      EstacionamentoViewModel viewModel = (EstacionamentoViewModel)this.ViewModel;
      viewModel.RemoverVeiculo(placa, tempoEstacionamento);
    }
    catch (FormatException)
    {
      Console.WriteLine("Formato do tempo de estacionamento inválido. O valor precisa ser um número inteiro.");
    }
  }

  public void ListarVeiculos()
  {
    Console.WriteLine("Listando veículos");
    var viewModel = (EstacionamentoViewModel)this.ViewModel;

    var veiculos = viewModel.GetListVeiculos();

    if (veiculos.Count > 0)
    {
      foreach (var veiculo in veiculos)
      {
        Console.WriteLine($"Tipo: {veiculo.Tipo}  - Placa: {veiculo.Placa}");
      }
    }
    else
    {
      Console.WriteLine("Nenhum veículo no estacionamento");
    }

    Console.WriteLine();
  }
}
