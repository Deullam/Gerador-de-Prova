using NDD.GeradorProva.Infra.Data.Nucleo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDD.GeradorProva.Infra.Data.Util
{

    public static class SQLMetodosExtensao
    {

        public static void AdicionarParametros(this IDbCommand command, Dictionary<string, object> parameters)
        {
            if (parameters == null)
                return;

            foreach (KeyValuePair<string, object> entry in parameters)
            {
                var parameter = command.CreateParameter();
                parameter.ParameterName = entry.Key;
                parameter.Value = entry.Value;

                command.Parameters.Add(parameter);
            }
        }

        public static string FormatarSQL(this string query, TipoBancoDeDados type, bool loadId = false)
        {
            query = query.DefinirApelido(type);
            query = (loadId ? query.AcrescentarConsultaId(type) : query);

            return query;
        }

        private static string DefinirApelido(this string query, TipoBancoDeDados type)
        {
            return string.Format(query, TipoBancoDeDadosUtil.ObterApelido(type));
        }

        private static string AcrescentarConsultaId(this string query, TipoBancoDeDados type)
        {
            switch (type)
            {
                case TipoBancoDeDados.MY_SQL:
                    return query + ";SELECT @@IDENTITY";
                case TipoBancoDeDados.SQL_SERVER:
                    return query + ";SELECT SCOPE_IDENTITY()";
            }

            return query;
        }

    }

}
