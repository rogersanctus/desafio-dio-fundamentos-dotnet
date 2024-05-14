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

  Console.WriteLine("# Configurações");
  Console.WriteLine("1 - Configurar Preco inicial");
  Console.WriteLine("2 - Configurar Tipo de Veículo");
  Console.WriteLine("3 - Exibir Preço Inicial Configurado");
  Console.WriteLine("4 - Listar Dados dos Tipos de Veículos");
  Console.WriteLine();
  Console.WriteLine("# Estacionamento");
  Console.WriteLine("5 - Cadastrar Veículo");
  Console.WriteLine("6 - Remover Veículo");
  Console.WriteLine("7 - Listar Veículos");
  Console.WriteLine("8 - Exibir Saldo de Caixa");
  Console.WriteLine();
  Console.WriteLine("0 - Sair");
  Console.WriteLine();

  var input = Console.ReadLine();
  Console.WriteLine();

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
      estacionamentoView.ExibirPrecoInicial();
      break;
    case "4":
      gerenteVeiculosView.ListarDadosVeiculos();
      break;
    case "5":
      estacionamentoView.CadastrarVeiculo();
      break;
    case "6":
      estacionamentoView.RemoverVeiculo();
      break;
    case "7":
      estacionamentoView.ListarVeiculos();
      break;
    case "8":
      estacionamentoView.ExibirSaldoDeCaixa();
      break;
    default:
      ConsoleWriter.WriteLine("Opção Inválida", ConsoleColor.Red);
      break;
  }
}
