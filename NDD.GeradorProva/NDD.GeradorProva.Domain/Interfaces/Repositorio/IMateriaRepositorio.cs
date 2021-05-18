using NDD.GeradorProva.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace NDD.GeradorProva.Domain.Interfaces.Repositorio
{
    public interface IMateriaRepositorio : IRepositorio<Materia>
    {
        List<Materia> ConsultarPorNome(String nome);

        List<Materia> ConsultarPorNomeEId(String nome, int id);

        List<Materia> ConsultarPorDisciplina(int idDisciplina);

        List<Materia> ConsultarPorSerie(int idSerie);
    }
}
