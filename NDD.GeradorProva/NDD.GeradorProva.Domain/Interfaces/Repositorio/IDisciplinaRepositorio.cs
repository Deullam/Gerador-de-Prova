using NDD.GeradorProva.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace NDD.GeradorProva.Domain.Interfaces.Repositorio
{
    public interface IDisciplinaRepositorio : IRepositorio<Disciplina>
    {
        List<Disciplina> ConsultarPorNome(String nome);

        List<Disciplina> ConsultarPorNomeEId(String nome, int id);

    }

}
