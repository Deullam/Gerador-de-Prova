using NDD.GeradorProva.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDD.GeradorProva.Domain.Entidades
{
    public class Serie : Entidade
    {

        public int Numero { get; set; }

        public override void Validar()
        {
            if (Numero < 1 || Numero > 9)
            {
                throw new ValidacaoExcecao("O número da série deve estar entre 1 e 9.", new List<String>() { "Numero" });
            }
        }

        public override string ToString()
        {
            return Numero.ToString() + "ª - " + SerieUtil.ObterDescricao(Numero) + " série";
        }
    }

    static class SerieUtil
    {
        public static string ObterDescricao(int numero)
        {
            switch (numero)
            {
                case 1:
                    return "Primeira";
                case 2:
                    return "Segunda";
                case 3:
                    return "Terceira";
                case 4:
                    return "Quarta";
                case 5:
                    return "Quinta";
                case 6:
                    return "Sexta";
                case 7:
                    return "Sétima";
                case 8:
                    return "Oitava";
                case 9:
                    return "Nona";
                default:
                    return "";
            }
        }
    }
    
}
