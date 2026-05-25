namespace Comum.Financeiro;

public sealed record Moeda
{
    public Moeda(string codigo, string simbolo, string nome)
    {
        if (string.IsNullOrWhiteSpace(codigo))
        {
            throw new ValorFinanceiroInvalidoException("O codigo da moeda e obrigatorio.");
        }

        if (string.IsNullOrWhiteSpace(simbolo))
        {
            throw new ValorFinanceiroInvalidoException("O simbolo da moeda e obrigatorio.");
        }

        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new ValorFinanceiroInvalidoException("O nome da moeda e obrigatorio.");
        }

        Codigo = codigo.Trim().ToUpperInvariant();
        Simbolo = simbolo.Trim();
        Nome = nome.Trim();
    }

    public string Codigo { get; }

    public string Simbolo { get; }

    public string Nome { get; }

    public static Moeda RealBrasileiro { get; } = new("BRL", "R$", "Real brasileiro");

    public static Moeda DolarAmericano { get; } = new("USD", "US$", "Dolar americano");

    public static Moeda Euro { get; } = new("EUR", "€", "Euro");

    public override string ToString()
    {
        return Codigo;
    }
}