using System.Text.RegularExpressions;

namespace Restaurante.Domain.Validacoes;

public static partial class ValidarCpf
{
    [GeneratedRegex(@"^\d{3}\.?\d{3}\.?\d{3}\-?\d{2}$")]
    private static partial Regex CpfRegex();

    public static bool CpfValido(string cpf)
    {
        return !string.IsNullOrWhiteSpace(cpf) && CpfRegex().IsMatch(cpf);
    }
}

public static partial class ValidarCnpj
{
    [GeneratedRegex(@"^[A-Z0-9]{2}\.?[A-Z0-9]{3}\.?[A-Z0-9]{3}\/?[A-Z0-9]{4}\-?\d{2}$", RegexOptions.IgnoreCase)]
    private static partial Regex CnpjRegex();

    public static bool CnpjValido(string cnpj)
    {
        return !string.IsNullOrWhiteSpace(cnpj) && CnpjRegex().IsMatch(cnpj);
    }
}

public static partial class ValidarEmail
{
    [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase)]
    private static partial Regex EmailRegex();

    public static bool EmailValido(string email)
    {
        return !string.IsNullOrWhiteSpace(email) && EmailRegex().IsMatch(email);
    }
}