using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDD.GeradorProva.Domain.Entidades
{
    public enum Bimestre
    {

        PRIMEIRO,
        SEGUNDO,
        TERCEIRO,
        QUARTO,

        INVALIDO

    }

    public static class BimestreUtil
    {
        public static int[] ObterListaBimestre()
        {
            return new int[] { 1, 2, 3, 4 };
        }

        public static Bimestre ObterBimestre(int bimestre)
        {
            switch (bimestre)
            {
                case 0:
                    return Bimestre.PRIMEIRO;
                case 1:
                    return Bimestre.SEGUNDO;
                case 2:
                    return Bimestre.TERCEIRO;
                case 3:
                    return Bimestre.QUARTO;
                default:
                    return Bimestre.INVALIDO;
            }
        }


        public static int ObterBimestreNumerico(Bimestre bimestre)
        {
            switch (bimestre)
            {
                case Bimestre.PRIMEIRO:
                    return 1;
                case Bimestre.SEGUNDO:
                    return 2;
                case Bimestre.TERCEIRO:
                    return 3;
                case Bimestre.QUARTO:
                    return 4;
                default:
                    return -1;
            }
        }
    }

}
