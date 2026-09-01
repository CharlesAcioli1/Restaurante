namespace Restaurante.Domain;

public sealed class Cardapio
{
    public int Id { get; set; }
    public string Nome { get; set; } = default!;
    public int RestauranteId { get; set; }

    public Restaurante? Restaurante { get; set; }

    /*
     * ===========
     * MEMORIZAÇÃO
     * ===========
     * string.Empty garante que o campo inicialize como um
     * texto vazio "" em vez de null, evitando erros graves
     * do tipo NullReferenceException quando a API tentar
     * ler o nome
     * 
     * default! --> Se não tiver algo o código quebra
    Pesquisar a diferença implícita
     */

    //
}