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
                    "Informe uma opção válida: 1 para desocupada | 2 para ocupada");
            }
        }

        //public static void ValidarCriacao(int statusId)
        //{
        //    if (statusId != (int)StatusMesaEnum.Desocupada)
        //    {
        //        throw new ArgumentException(
        //            "Mesa apenas pode ser criada com status desocupada!");
        //    }
        //}
    }
}
