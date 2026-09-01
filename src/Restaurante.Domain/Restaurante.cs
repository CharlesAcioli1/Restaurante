namespace Restaurante.Domain;

public sealed class Restaurante
{
    //PROPRIEDADES
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Cnpj { get; private set; }
    public string? Email { get; private set; }
    public string? Endereco { get; set; }
    public string? Telefone { get; private set; }
    public bool Ativo { get; private set; } = true;

    //CONSTRUTOR
    public Restaurante(string nome, string cnpj, string email, string endereco, string telefone)
    {
        if (string.IsNullOrWhiteSpace(nome) ||
            string.IsNullOrWhiteSpace(cnpj) ||
            string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(endereco) ||
            string.IsNullOrWhiteSpace(telefone))
            throw new ArgumentException("Essa informação é obrigatória!");

        Nome = nome;
        Cnpj = cnpj;
        Email = email;
        Endereco = endereco;
        Telefone = telefone;
    }

    //MÉTODOS/FUNÇÕES
    private void ValidarAtualizacao()
    {
        if (!Ativo)
            throw new InvalidOperationException("Este espaço está vazio ou você está alterando algum dado inativo.");
    }

    public void AtualizarEmail(string novoEmail)
    {
        ValidarAtualizacao();
        if (string.IsNullOrWhiteSpace(novoEmail))
            throw new ArgumentException("Este espaço não pode ser vazio!");
        Email = novoEmail;
    }

    public void AtualizarTelefone(string novoTelefone)
    {
        ValidarAtualizacao();
        if (string.IsNullOrWhiteSpace(novoTelefone))
            throw new ArgumentException("Este espaço não pode ser vazio!");
        Telefone = novoTelefone;
    }

    private Restaurante() { }
}