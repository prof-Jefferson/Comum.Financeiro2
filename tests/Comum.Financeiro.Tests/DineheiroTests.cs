using Comum.Financeiro;

public class DinheiroTests
{
    [Fact]
    public void DeveSomarDoisValoresemBrl()
    {
        var primeiroValor = Dinheiro.EmReais(10m);
        var segundoValor = Dinheiro.EmReais(5.50m);

        var resultado = primeiroValor.Somar(segundoValor);

        Assert.Equal(15.50m, resultado.Valor);
        Assert.Equal(Moeda.RealBrasileiro, resultado.Moeda);
    }
}