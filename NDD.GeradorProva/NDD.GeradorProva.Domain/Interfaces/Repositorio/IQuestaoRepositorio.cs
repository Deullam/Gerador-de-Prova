using NDD.GeradorProva.Domain.Entidades;
using System.Collections.Generic;

namespace NDD.GeradorProva.Domain.Interfaces.Repositorio
{
    public interface IQuestaoRepositorio : IRepositorio<Questao>
    {
        List<Questao> ConsultarPorEnunciado(string enunciado);

        List<Questao> ConsultarPorEnunciadoEId(string enunciado, int id);

        List<Questao> ConsultarPorSintese(string sintese);

        List<Questao> ConsultarPorSinteseEId(string sintese, int id);

        List<Questao> ConsultarPorDisciplina(int idDisciplina);

        List<Questao> ConsultarPorMateria(int idMateria);
       
    }
}
