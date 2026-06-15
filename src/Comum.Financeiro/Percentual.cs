namespace Comum.Financeiro;

public sealed record Percentual
{
    public decimal Valor { get; }

    private Percentual(decimal valor)
    {
        if (valor < 0)
        {
            throw new ValorFinanceiroInvalidoException("O percentual não pode ser negativo");
        }
        Valor = valor;
    }

    public static Percentual De(decimal valor)
    {
        return new Percentual(valor);
    }

    public decimal ComFatorDeDesconto()
    {
        return 1 - (Valor / 100m);
    }

    public decimal ComFatorDeAcrescimo()
    {
        return 1 + (Valor / 100m);
    }

    public override string ToString()
    {
        return $"{Valor}%";
    }
}