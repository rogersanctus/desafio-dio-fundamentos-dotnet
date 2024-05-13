namespace DesafioDioEstacionamento.Model;

public enum TipoVeiculo
{
  Carro = 0,
  Motocicleta
};

public class DadosVeiculo
{
  public bool Inicializado { get; set; } = false;
  public TipoVeiculo Tipo { get; set; }
  public string Nome { get; set; }
  public decimal PrecoPorHora { get; set; }

  public DadosVeiculo(TipoVeiculo tipo, string nome, decimal precoPorHora)
  {
    this.Tipo = tipo;
    this.Nome = nome;
    this.PrecoPorHora = precoPorHora;
  }
}

public class GerenteDadosVeiculo
{
  private List<DadosVeiculo> tiposVeiculo;
  public bool Inicializado
  {
    get
    {
      return this.tiposVeiculo.All(inicializado => inicializado.Inicializado);
    }
  }

  public GerenteDadosVeiculo()
  {
    this.tiposVeiculo = new List<DadosVeiculo>();
    this.tiposVeiculo.Insert((int)TipoVeiculo.Carro, new DadosVeiculo(TipoVeiculo.Carro, "Carro", 0.00M));
    this.tiposVeiculo.Insert((int)TipoVeiculo.Motocicleta, new DadosVeiculo(TipoVeiculo.Motocicleta, "Moto", 0.00M));
  }

  public void AtualizarVeiculo(TipoVeiculo tipo, decimal precoPorHora)
  {
    int index = (int)tipo;

    var dados = this.tiposVeiculo.ElementAtOrDefault(index);

    if (dados == null)
    {
      throw new InvalidOperationException("Tipo de veículo inválido");
    }

    // this.tiposVeiculo[index] = newDados;
    dados.PrecoPorHora = precoPorHora;
    dados.Inicializado = true;
  }

  public DadosVeiculo? GetVeiculo(TipoVeiculo tipo)
  {
    int index = (int)tipo;

    DadosVeiculo? dados = this.tiposVeiculo[index];

    return dados;
  }

  public List<DadosVeiculo> GetVeiculosNaoInicializados()
  {
    return this.tiposVeiculo.FindAll((dadosVeiculo) => !dadosVeiculo.Inicializado);
  }

  public List<DadosVeiculo> GetVeiculos()
  {
    return this.tiposVeiculo;
  }
}

public class Veiculo
{
  public TipoVeiculo Tipo { get; set; }
  public string Placa { get; set; }

  public Veiculo(TipoVeiculo tipo, string placa)
  {
    this.Tipo = tipo;
    this.Placa = placa;
  }
}
