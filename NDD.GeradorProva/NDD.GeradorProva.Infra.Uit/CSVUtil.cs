using CsvHelper;
using CsvHelper.Configuration;
using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.Infra.Util.CSVMappers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDD.GeradorProva.Infra.Util
{
    public static class CSVUtil
    {
        public static void WriteCSV<T>(this List<T> entidades, string path)
        {
            using (var writer = new StreamWriter(path, false, Encoding.UTF8))
            {
                using (var csvWriter = new CsvWriter(writer))
                {
                    var records = entidades;
                    csvWriter.Configuration.Delimiter = ";";
                    //csvWriter.Configuration.AutoMap(typeof(List<T>));
                    csvWriter.WriteRecords(records);
                }
                System.Diagnostics.Process.Start(path);

            }

        }

        public static void WriteTesteCSV(this Teste entidades, string path)
        {

            using (var writer = new StreamWriter(path, false, Encoding.UTF8))
            using (var csvWriter = new CsvWriter(writer))
            {
                csvWriter.Configuration.CultureInfo = CultureInfo.GetCultureInfo("pt-BR");

                csvWriter.Configuration.Delimiter = ";";
                csvWriter.Configuration.HasHeaderRecord = true;

                csvWriter.Configuration.RegisterClassMap<ProvaMap>();
                csvWriter.Configuration.RegisterClassMap<QuestaoMap>();
                csvWriter.Configuration.RegisterClassMap<AlternativaMap>();

                csvWriter.WriteRecord(entidades);
                csvWriter.NextRecord();
                foreach (Questao questao in entidades.Questoes)
                {
                    csvWriter.WriteRecord(questao);
                    csvWriter.NextRecord();
                    foreach (Alternativa alternativa in questao.Alternativas)
                    {
                        csvWriter.WriteRecord(alternativa);
                        csvWriter.NextRecord();
                    }
                }
                csvWriter.NextRecord();
                System.Diagnostics.Process.Start(path);
            }

        }

        public static void WriteQuestoesCSV(this List<Questao> entidades, string path)
        {
            using (var writer = new StreamWriter(path, false, Encoding.UTF8))
            using (var csvWriter = new CsvWriter(writer))
            {
                csvWriter.Configuration.CultureInfo = CultureInfo.GetCultureInfo("pt-BR");

                csvWriter.Configuration.Delimiter = ";";
                csvWriter.Configuration.HasHeaderRecord = true;

                csvWriter.Configuration.RegisterClassMap<QuestaoMap>();
                csvWriter.Configuration.RegisterClassMap<AlternativaMap>();

                foreach (Questao questao in entidades)
                {
                    csvWriter.WriteRecord(questao);
                    csvWriter.NextRecord();
                    foreach (Alternativa alternativa in questao.Alternativas)
                    {
                        csvWriter.WriteRecord(alternativa);
                        csvWriter.NextRecord();
                    }
                }
                csvWriter.NextRecord();
                System.Diagnostics.Process.Start(path);
            }


        }

    }
}

