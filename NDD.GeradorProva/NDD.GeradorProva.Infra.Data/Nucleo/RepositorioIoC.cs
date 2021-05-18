using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.Domain.Interfaces.Repositorio;
using NDD.GeradorProva.Infra.Data.RepositorioSQL;

namespace NDD.GeradorProva.Infra.Data.Nucleo
{
    public static class RepositorioIoC
    {
        public static IRepositorio<Disciplina> Disciplina { get; internal set; }
        public static IRepositorio<Serie> Serie { get; internal set; }
        public static IRepositorio<Materia> Materia { get; internal set; }
        public static IRepositorio<Questao> Questao { get; internal set; }
        public static IRepositorio<Alternativa> Alternativa { get; internal set; }
        public static ITesteQuestao TesteQuestao { get; internal set; }

        public static IRepositorio<Teste> Teste { get; internal set; }


        static RepositorioIoC()
        {
            Disciplina = new DisciplinaRepositorioSQL(ConfiguracaoSingleton.Instancia.Tipo);
            Serie = new SerieRepositorioSQL(ConfiguracaoSingleton.Instancia.Tipo);
            Materia = new MateriaRepositorioSQL(ConfiguracaoSingleton.Instancia.Tipo);
            Questao = new QuestaoRepositorioSQL(ConfiguracaoSingleton.Instancia.Tipo);
            Alternativa = new AlternativaRepositorioSQL(ConfiguracaoSingleton.Instancia.Tipo);
            Teste = new TesteRepositorioSQL(ConfiguracaoSingleton.Instancia.Tipo);
            TesteQuestao = new TesteQuestaoRepositorioSQL(ConfiguracaoSingleton.Instancia.Tipo);

        }

  
    }
}
