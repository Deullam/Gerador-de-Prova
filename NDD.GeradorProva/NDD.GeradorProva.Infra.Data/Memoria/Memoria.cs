using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.Domain.Interfaces.Repositorio;
using System.Collections.Generic;
using System;

namespace NDD.GeradorProva.Infra.Data.Memoria
{
    public abstract class Memoria<T> : IRepositorio<T> where T : Entidade
    {

        protected List<T> _lista;
        protected int _id;

        public Memoria()
        {
            _lista = new List<T>();
            _id = 1;
        }

        public T Adicionar(T entidade)
        {
            entidade.Id = _id++;
            _lista.Add(entidade);

            return entidade;
        }

        public T Atualizar(T entidade)
        {
            var index = _lista.FindIndex(x => x.Id == entidade.Id);
            _lista.RemoveAt(index);
            _lista.Insert(index, entidade);

            return entidade;
        }

        public int Excluir(int id)
        {
            _lista.RemoveAll(x => x.Id == id);

            return id;
        }

        public List<T> BuscarTodos()
        {
            return _lista;
        }

        public T ConsultarPorId(int id)
        {
            return _lista.Find(x => x.Id == id);
        }

        public List<T> ConsultarComFiltragem(object[] filtros)
        {
            throw new NotImplementedException();
        }
    }
}
