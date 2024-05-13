namespace DesafioDioEstacionamento.View;

using DesafioDioEstacionamento.Infra.Utils;
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
    ConsoleWriter.WriteLine();

    switch (evento)
    {
      case "AdicionarVeiculo:Sucesso":
        ConsoleWriter.WriteLine("veículo adicionado com sucesso");
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

          ConsoleWriter.WriteLine("veículo removido com sucesso");
          ConsoleWriter.WriteLine($"Total a pagar pelo estacionamento: {custo:N}");
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
        ConsoleWriter.WriteLine("Preço atualizado com sucesso");
        break;
    }

    ConsoleWriter.WriteLine();
  }

  public void ConfigurarPrecoInicial()
  {
    ConsoleWriter.WriteLine("Configurando preco inicial");
    var precoInicialStr = Console.ReadLine();

    if (string.IsNullOrEmpty(precoInicialStr))
    {
      ConsoleWriter.WriteLine("O preço inicial não pode ser vazio.", ConsoleColor.Red);
      ConsoleWriter.WriteLine();
      return;
    }

    decimal precoInicial;

    if (!decimal.TryParse(precoInicialStr, out precoInicial))
    {
      ConsoleWriter.WriteLine("Preço inicial inválido", ConsoleColor.Red);
      ConsoleWriter.WriteLine();
      return;
    }

    // viewModel.SetPrecoInicial(precoInicial);
    var viewModel = (EstacionamentoViewModel)this.ViewModel;
    viewModel.AtualizarPrecoicial(precoInicial);
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
    var viewModel = (EstacionamentoViewModel)this.ViewModel;

    var veiculos = viewModel.GetListVeiculos();

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
