using Comum.Financeiro;

public class DinheiroTests
{
    [Fact]
    public void DeveCriarDinheiroEmReais()
    {
        var dinheiro = Dinheiro.EmReais(10.50m);

        // Teste de integridade
        Assert.Equal(10.50m, dinheiro.Valor);
        Assert.Equal(Moeda.RealBrasileiro, dinheiro.Moeda);
    }

    [Fact]
    public void DeveSomarDoisValoresEmBrl()
    {
        var primeiroValor = Dinheiro.EmReais(10m);
        var segundoValor = Dinheiro.EmReais(5.50m);

        var resultado = primeiroValor.Somar(segundoValor);

        Assert.Equal(15.50m, resultado.Valor);
        Assert.Equal(Moeda.RealBrasileiro, resultado.Moeda);
    }

    [Fact]
    public void DeveSubtrairDoisValoresEmBrl()
    {
        var primeiroValor = Dinheiro.EmReais(10m);
        var segundoValor = Dinheiro.EmReais(5.50m);

        var resultado = primeiroValor.Subtrair(segundoValor);

        Assert.Equal(4.50m, resultado.Valor);
        Assert.Equal(Moeda.RealBrasileiro, resultado.Moeda);
    }

    [Fact]
    public void DeveImpedirSomaEntreBrlEUsd()
    {
        var valorEmReais = Dinheiro.EmReais(10m);
        var valorEmDolares = new Dinheiro(10m, Moeda.DolarAmericano);

        Assert.Throws<MoedasDiferentesException>(()=>valorEmReais.Somar(valorEmDolares));        
    }

    [Fact]
    public void DeveImpedirSubtracaoEntreBrlEUsd()
    {
        var valorEmReais = Dinheiro.EmReais(10m);
        var valorEmDolares = new Dinheiro(10m, Moeda.DolarAmericano);

        Assert.Throws<MoedasDiferentesException>(()=>valorEmReais.Subtrair(valorEmDolares));  
    }

    [Fact]
    public void DeveMultiplarDinheiroPorQuantidade()
    {
        var dinheiro = Dinheiro.EmReais(12.5m);
        var resultado = dinheiro.Multiplicar(3m);

        Assert.Equal(37.5m, resultado.Valor);
        Assert.Equal(Moeda.RealBrasileiro, resultado.Moeda);
    }

    [Fact]
    public void DeveVerificarValorEhZero()
    {
        var dinheiro = Dinheiro.EmReais(0m);
        
        Assert.True(dinheiro.EhZero());
        Assert.False(dinheiro.EhPositivo());
        Assert.False(dinheiro.EhNegativo());
    }

    [Fact]
    public void DeveVerificarValorEhPositivo()
    {
        var dinheiro = Dinheiro.EmReais(1m);
        
        Assert.False(dinheiro.EhZero());
        Assert.True(dinheiro.EhPositivo());
        Assert.False(dinheiro.EhNegativo());
    }

    [Fact]
    public void DeveVerificarValorEhNegativo()
    {
        var dinheiro = Dinheiro.EmReais(-1m);
        
        Assert.False(dinheiro.EhZero());
        Assert.False(dinheiro.EhPositivo());
        Assert.True(dinheiro.EhNegativo());   
    }

    [Fact]
    public void DeveFormatarValorEmReais()
    {
        var dinheiro = Dinheiro.EmReais(10.5m);
        var valorFormatado = dinheiro.Formatar();

        Assert.Contains("R$", valorFormatado);
        Assert.Contains("10,50", valorFormatado);
    }
}