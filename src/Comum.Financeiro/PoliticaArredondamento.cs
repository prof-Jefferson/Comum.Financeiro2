namespace Comum.Financeiro;

public static class PoliticaArredondamento
{
    public static decimal Arredondar(decimal valor)
    {
        return Math.Round(valor, 2, MidpointRounding.AwayFromZero);
    }
}