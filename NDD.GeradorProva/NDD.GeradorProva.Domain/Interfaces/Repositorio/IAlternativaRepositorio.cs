using NDD.GeradorProva.Domain.Entidades;
using System.Collections.Generic;

namespace NDD.GeradorProva.Domain.Interfaces.Repositorio
{
    public interface IAlternativaRepositorio : IRepositorio<Alternativa>
    {
        List<Alternativa> ConsultarPorQuestao(int idQuestao);
        void ExcluirPorQuestao(int idQuestao);
    }
}
