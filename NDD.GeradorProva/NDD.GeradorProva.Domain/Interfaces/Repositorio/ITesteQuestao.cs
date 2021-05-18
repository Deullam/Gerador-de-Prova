using NDD.GeradorProva.Domain.Entidades;
using System.Collections.Generic;

namespace NDD.GeradorProva.Domain.Interfaces.Repositorio
{
    public interface ITesteQuestao
    {
        void Adicionar(Teste teste, Questao questao);
        List<Questao> ConsultarPorQuestao(int id);
        List<Questao> ConsultarPorTeste(int id);

    }
}
