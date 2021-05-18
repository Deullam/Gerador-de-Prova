using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.Domain.Interfaces.Repositorio;
using System.Collections.Generic;

namespace NDD.GeradorProva.Infra.Data.Memoria
{
    public class DisciplinaMemoria : Memoria<Disciplina>, IDisciplinaRepositorio
    {
        public List<Disciplina> ConsultarPorNome(string nome)
        {
            return _lista.FindAll(x => x.Nome == nome);
        }

        public List<Disciplina> ConsultarPorNomeEId(string nome, int id)
        {
            return _lista.FindAll(x => x.Nome == nome && x.Id != id);
        }
    }
}
