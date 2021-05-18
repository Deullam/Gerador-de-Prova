using NDD.GeradorProva.Domain.Entidades;
using System.Collections.Generic;

namespace NDD.GeradorProva.Domain.Interfaces.Repositorio
{
    public interface IRepositorio<T> where T : Entidade
    {

        T Adicionar(T entidade);
        T Atualizar(T entidade);
        int Excluir(int id);
        List<T> BuscarTodos();
        T ConsultarPorId(int id);
        List<T> ConsultarComFiltragem(object[] filtros);

    }

}
