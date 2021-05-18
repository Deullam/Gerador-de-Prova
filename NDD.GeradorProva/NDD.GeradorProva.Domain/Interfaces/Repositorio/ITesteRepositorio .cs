using NDD.GeradorProva.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace NDD.GeradorProva.Domain.Interfaces.Repositorio
{
    public interface ITesteRepositorio : IRepositorio<Teste>
    {
        List<Teste> ConsultarPorTitulo(String titulo);

        List<Teste> ConsultarPorTituloEId(String titulo, int id);

        List<Teste> ConsultarPorDisciplina(int idDisciplina);

        List<Teste> ConsultarPorMateria(int idMateria);

        

    }
}
