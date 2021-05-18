using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.Domain.Interfaces.Repositorio;

namespace NDD.GeradorProva.Infra.Data.Nucleo
{
    public static class RepositorioTesteIoC
    {
        public static IRepositorio<Disciplina> Disciplina { get; set; }
        public static IRepositorio<Serie> Serie { get; set; }
        public static IRepositorio<Materia> Materia { get; set; }
  
    }
}
