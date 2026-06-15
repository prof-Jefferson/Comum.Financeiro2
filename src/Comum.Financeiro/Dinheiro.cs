using System.Globalization;

namespace Comum.Financeiro;

public sealed record Dinheiro : IComparable<Dinheiro>
{
    public Dinheiro(decimal valor, Moeda moeda)
    {
        Moeda = moeda ?? throw new ValorFinanceiroInvalidoException("A moeda e obrigatoria.");
        Valor = valor;
    }

    public decimal Valor { get; }

    public Moeda Moeda { get; }

    public static Dinheiro EmReais(decimal valor)
    {
        return new Dinheiro(valor, Moeda.RealBrasileiro);
    }

    public Dinheiro Somar(Dinheiro outro)
    {
        ValidarMesmaMoeda(outro);

        return new Dinheiro(Valor + outro.Valor, Moeda);
    }

    public Dinheiro Subtrair(Dinheiro outro)
    {
        ValidarMesmaMoeda(outro);

        return new Dinheiro(Valor - outro.Valor, Moeda);
    }

    public Dinheiro Multiplicar(decimal quantidade)
    {
        return new Dinheiro(PoliticaArredondamento.Arredondar(Valor * quantidade), Moeda);
    }

    public Dinheiro AplicarDesconto(Percentual percentual)
    {
        if (percentual.Valor > 100m)
        {            
            throw new ValorFinanceiroInvalidoException("O Percentual de desconto não pode ultruapassar 100%");
        }

        var valorComDesconto = Valor * percentual.ComFatorDeDesconto();

        if (valorComDesconto < 0)
        {
            throw new ValorFinanceiroInvalidoException("O resultado do desconto não po de ser negativo");
        }

        return new Dinheiro(PoliticaArredondamento.Arredondar(valorComDesconto), Moeda);        
    }

    public Dinheiro AplicarAcrecscimo(Percentual percentual)
    {
        ArgumentNullException.ThrowIfNull(percentual);

        var valorComAcrescimo = Valor * percentual.ComFatorDeAcrescimo();

        return new Dinheiro(PoliticaArredondamento.Arredondar(valorComAcrescimo), Moeda);
    }

    public bool EhZero()
    {
        return Valor == 0;
    }

    public bool EhPositivo()
    {
        return Valor > 0;
    }

    public bool EhNegativo()
    {
        return Valor < 0;
    }

    public string Formatar()
    {
        var cultura = ObterCulturaDaMoeda();

        return Valor.ToString("C", cultura);
    }

    public int CompareTo(Dinheiro? other)
    {
        if (other is null)
        {
            return 1;
        }

        ValidarMesmaMoeda(other);

        return Valor.CompareTo(other.Valor);
    }

    private void ValidarMesmaMoeda(Dinheiro outro)
    {
        ArgumentNullException.ThrowIfNull(outro);

        if (Moeda != outro.Moeda)
        {
            throw new MoedasDiferentesException(Moeda, outro.Moeda);
        }
    }

    private CultureInfo ObterCulturaDaMoeda()
    {
        return Moeda.Codigo switch
        {
            "BRL" => new CultureInfo("pt-BR"),
            "USD" => new CultureInfo("en-US"),
            "EUR" => new CultureInfo("pt-PT"),
            _ => CultureInfo.CurrentCulture
        };
    }

    public override string ToString()
    {
        return Formatar();
    }
}