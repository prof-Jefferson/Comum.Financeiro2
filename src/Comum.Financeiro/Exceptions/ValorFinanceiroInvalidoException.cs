namespace Comum.Financeiro;

public sealed class ValorFinanceiroInvalidoException : ArgumentException
{
    public ValorFinanceiroInvalidoException(string mensagem)
        : base(mensagem)
    {
    }
}