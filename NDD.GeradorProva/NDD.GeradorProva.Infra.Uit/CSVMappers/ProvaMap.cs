using CsvHelper.Configuration;
using NDD.GeradorProva.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDD.GeradorProva.Infra.Util.CSVMappers
{
    public class ProvaMap : ClassMap<Teste>
    {
        public ProvaMap()
        {
            Map(x => x.Titulo).Name("Titulo").Index(1);
            Map(x => x.QuantidadeQuestoes).Name("QuantidadeQuestoes").Index(2);
            Map(x => x.Materia.Nome).Name("Materia").Index(3);
            Map(x => x.DataGeracao).Name("DataGeracao").Index(4);
        }
    }
}
