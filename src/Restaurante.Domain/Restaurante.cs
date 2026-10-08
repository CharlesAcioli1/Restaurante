using Restaurante.Domain.Validacoes;
namespace Restaurante.Domain;

public sealed partial class Restaurante
{
    //PROPRIEDADES
    public int Id { get; set; }
    public string Nome { get; set; } = default!;
    public string Cnpj { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Endereco { get; set; } = default!;
    public string Telefone { get; set; } = default!;
    public bool Ativo { get; set; } = true;

    //CONSTRUTOR
    public Restaurante() { }

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
            throw new InvalidOperationException("Este restaurante está inativo, não é possível fazer alterações.");
    }

    public void AtualizarNome(string novoNome)
    {
        ValidarAtualizacao();

        if (string.IsNullOrWhiteSpace(novoNome))
            throw new ArgumentException("Este espaço não pode ser vazio!");
        Nome = novoNome;
    }

    public void AtualizarEmail(string novoEmail)
    {
        ValidarAtualizacao();

        if (!ValidarEmail.EmailValido(novoEmail))
            throw new ArgumentException("Este espaço não pode ser vazio!");
        Email = novoEmail;
    }

    public void AtualizarCnpj(string novoCnpj)
    {
        ValidarAtualizacao();
        if (!ValidarCnpj.CnpjValido(novoCnpj))
            throw new ArgumentException("Formato inválido!");
        Cnpj = novoCnpj;
    }

    public void AtualizarTelefone(string novoTelefone)
    {
        ValidarAtualizacao();
        if (string.IsNullOrWhiteSpace(novoTelefone))
            throw new ArgumentException("Este espaço não pode ser vazio!");
        Telefone = novoTelefone;
    }

    public void Desativar() => Ativo = false;
    public void Aivar() => Ativo = true;
}