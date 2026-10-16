using Restaurante.Domain.Enums;

namespace Restaurante.Domain.Validacoes
{
    public static class StatusMesaValidacao
    {
        public static void Validar(int statusId)
        {
            if(!Enum.IsDefined(typeof(StatusMesaEnum), statusId))
            {
                throw new ArgumentException(
                    "Informe uma opção válida: 1 para ocupada | 2 para desocupada");
            }
        }
    }
}
