namespace Restaurante.Domain.Compartilhar
{
    public class Resultado
    {
        public object? Dados { get; set; }
        public bool Sucesso { get; set; }
        public string? Erro { get; set; }

        public bool PossuiDados { get => Sucesso && Dados is not null; }

        private Resultado(bool sucesso, object? dados = null, string? erro = null)
        {
            Sucesso = sucesso;
            Dados = dados;
            Erro = erro;
        }

        public static Resultado Success(object? dados)
        {
            return new Resultado(true, dados);
        }

        public static Resultado Falha(string erro)
        {
            return new Resultado(false, erro: erro);
        }
    }
}
