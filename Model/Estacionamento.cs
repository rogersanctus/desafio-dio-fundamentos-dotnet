﻿namespace DesafioDioEstacionamento.Model;

using System.Collections.Generic;

public class Estacionamento
{
  /// TODO: Implementar saldo do estacionamento, acumulando os custos para cada remoção de veículo
  private GerenteDadosVeiculo gerenteVeiculos;
  private List<Veiculo> veiculos = new List<Veiculo>();
  private decimal? precoInicial = null;

  private bool Inicializado
  {
    get
    {
      return this.precoInicial != null && this.gerenteVeiculos.Inicializado;
    }
  }

  public Estacionamento(GerenteDadosVeiculo gerenteVeiculos)
  {
    this.gerenteVeiculos = gerenteVeiculos;
  }

  public void SetPrecoInicial(decimal preco)
  {
    this.precoInicial = preco;
  }

  public void AdicionarVeiculo(Veiculo veiculo)
  {
    if (!this.Inicializado)
    {
      throw new InvalidOperationException("Estacionamento não inicializado");
    }

    this.GetVeiculoPorTipoEValida(veiculo.Tipo);

    veiculos.Add(veiculo);
  }

  public decimal RemoverVeiculo(string placa, int tempoMinutos = 0)
  {
    if (!this.Inicializado)
    {
      throw new InvalidOperationException("Estacionamento não inicializado");
    }

    var veiculo = this.veiculos.Find(v => v.Placa == placa);

    if (veiculo == null)
    {
      throw new InvalidOperationException("Veículo não encontrado");
    }

    var dadosVeiculo = this.GetVeiculoPorTipoEValida(veiculo.Tipo);

    var horas = tempoMinutos / 60f;
    var precoInicial = this.precoInicial ?? 0;
    decimal custo = precoInicial + dadosVeiculo.PrecoPorHora * Convert.ToDecimal(horas);

    veiculos.Remove(veiculo);

    return custo;
  }

  public List<Veiculo> ListarVeiculos()
  {
    return this.veiculos;
  }

  private DadosVeiculo GetVeiculoPorTipoEValida(TipoVeiculo tipo)
  {
    var dadosVeiculo = this.gerenteVeiculos.GetVeiculo(tipo);

    if (dadosVeiculo == null)
    {
      throw new InvalidOperationException("Tipo de Veículo não cadastrado");
    }

    return dadosVeiculo;
  }
}
