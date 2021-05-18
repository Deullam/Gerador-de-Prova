using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDD.GeradorProva.Infra
{
    public enum TipoBancoDeDados
    {

        SQL_SERVER,
        MY_SQL
    }

    public static class TipoBancoDeDadosUtil
    {
        public static string ObterNomeDaPropriedade(TipoBancoDeDados tipo)
        {
            switch (tipo)
            {
                case TipoBancoDeDados.SQL_SERVER:
                    return "NDD.db.SQLServer";
                case TipoBancoDeDados.MY_SQL:
                    return "NDD.db.MySQL";
            }

            return null;
        }

        public static string ObterApelido(TipoBancoDeDados tipo)
        {
            switch (tipo)
            {
                case TipoBancoDeDados.SQL_SERVER:
                    return "@";
                case TipoBancoDeDados.MY_SQL:
                    return "?";
            }

            return null;
        }
    }

}
