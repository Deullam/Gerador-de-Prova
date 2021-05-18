using CsvHelper.Configuration;
using NDD.GeradorProva.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDD.GeradorProva.Infra.Util.CSVMappers
{
    public class AlternativaMap : ClassMap<Alternativa>
    {
        public AlternativaMap()
        {
            Map(x => x.Descricao).Name("Titulo");

        }
    }
}
