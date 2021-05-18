using NDD.GeradorProva.Infra;
using NDD.GeradorProva.Infra.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDD.GeradorProva.Infra
{
    public class ConfiguracaoSingleton : SingletonBasico<ConfiguracaoSingleton>
    {
        public TipoBancoDeDados Tipo { get; set; }

        public bool ModoZueiro { get; set; }

        private ConfiguracaoSingleton()
        {
        }

    }
}