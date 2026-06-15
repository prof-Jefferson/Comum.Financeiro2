using System.Reflection.PortableExecutable;
using Comum.Financeiro;

namespace Comum.Financeiro.Testes;

public class PercentualTests
{
    [Fact]
    public void DeveCriarPercentual()
    {
        var percentual = Percentual.De(10m);

        Assert.Equal(10m, percentual.Valor);
    }

    [Fact]
    public void DeveImpedirPercentualNegativo()
    {
        Assert.Throws<ValorFinanceiroInvalidoException>(()=> Percentual.De(-1m));
    }

    [Fact]
    public void DeveConverterParaFatorDeDesconto()
    {
        var percentual = Percentual.De(10m);

        var fator = percentual.ComFatorDeDesconto();

        Assert.Equal(0.90m, fator);
    }

    [Fact]
    public void DeveConverterParaFatorDeAcrescimo()
    {
        var percentual = Percentual.De(10m);

        var fator = percentual.ComFatorDeAcrescimo();

        Assert.Equal(1.10m, fator);
    }
}