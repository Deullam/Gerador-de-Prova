using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDD.GeradorProva.Infra.Data.Nucleo
{
    public static class ConexaoBDFactory
    {

        public static DbConnection CriarConexao(TipoBancoDeDados tipo)
        {
            ConnectionStringSettings config = ObterStringDeConexao(tipo);

            DbProviderFactory factory = DbProviderFactories.GetFactory(config.ProviderName);

            return factory.CreateConnection();
        }

        public static ConnectionStringSettings ObterStringDeConexao(TipoBancoDeDados tipo)
        {
            string nome = TipoBancoDeDadosUtil.ObterNomeDaPropriedade(tipo);
            foreach (ConnectionStringSettings css in ConfigurationManager.ConnectionStrings)
            {
                if (css.Name.Equals(nome))
                    return css;
            }

            return null;
        }

    }
}
