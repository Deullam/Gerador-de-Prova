using CsvHelper.Configuration;
using NDD.GeradorProva.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDD.GeradorProva.Infra.Util.CSVMappers
{
    public class QuestaoMap : ClassMap<Questao>
    {
        public QuestaoMap()
        {
            Map(x => x.Enunciado).Name("Enunciado");
        }
    }

}
