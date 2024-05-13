using System.Globalization;
using DesafioDioEstacionamento.Lib.UI;
using DesafioDioEstacionamento.Model;
using DesafioDioEstacionamento.View;
using DesafioDioEstacionamento.ViewModel;


var gerenteVeiculos = new GerenteDadosVeiculo();
var estacionamentoViewModel = new EstacionamentoViewModel(gerenteVeiculos);
var gerenteVeiculosViewModel = new GerenteVeiculosViewModel(gerenteVeiculos);
var configuracaoInicialViewModel = new ConfiguracaoInicialViewModel(gerenteVeiculosViewModel, estacionamentoViewModel);

var configuracaoInicialView = new ConfiguracaoInicialView(configuracaoInicialViewModel);
var estacionamentoView = new EstacionamentoView(estacionamentoViewModel);
var gerenteVeiculosView = new GerenteVeiculosView(gerenteVeiculosViewModel);

bool sair = false;

var decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

Console.Clear();

Console.WriteLine("Controle de Estacionamento");
Console.WriteLine("==========================");

Console.WriteLine();
ConsoleWriter.WriteLine($"Importante: O separador decimal para valores de preço é o caractere: '{decimalSeparator}'", ConsoleColor.Cyan);
Console.WriteLine();

configuracaoInicialView.ConfigurarEstacionamento();


while (!sair)
{
  Console.WriteLine("Menu Principal");
  Console.WriteLine("---");

  Console.WriteLine("1 - Configurar preco inicial");
  Console.WriteLine("2 - Configurar veículo");
  Console.WriteLine("3 - Cadastrar veículo");
  Console.WriteLine("4 - Remover veículo");
  Console.WriteLine("5 - Listar veículos");
  Console.WriteLine("0 - Sair");
  Console.WriteLine();

  var input = Console.ReadLine();

  switch (input)
  {
    case "0":
      sair = true;
      break;
    case "1":
      estacionamentoView.ConfigurarPrecoInicial();
      break;
    case "2":
      gerenteVeiculosView.ConfigurarTipoVeiculo();
      break;
    case "3":
      estacionamentoView.CadastrarVeiculo();
      break;
    case "4":
      estacionamentoView.RemoverVeiculo();
      break;
    case "5":
      estacionamentoView.ListarVeiculos();
      break;
    default:
      ConsoleWriter.WriteLine("Opção Inválida", ConsoleColor.Red);
      break;
  }
}
