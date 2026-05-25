namespace Comum.Financeiro;

public sealed class MoedasDiferentesException : InvalidOperationException
{
    public MoedasDiferentesException(Moeda moedaOrigem, Moeda moedaDestino)
        : base($"Nao e possivel operar valores em moedas diferentes: {moedaOrigem.Codigo} e {moedaDestino.Codigo}.")
    {
        MoedaOrigem = moedaOrigem;
        MoedaDestino = moedaDestino;
    }

    public Moeda MoedaOrigem { get; }

    public Moeda MoedaDestino { get; }
}