using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.Domain.Interfaces.Repositorio;
using NDD.GeradorProva.Infra.Util;
using System;
using System.Collections.Generic;

namespace NDD.GeradorProva.Application
{
    public abstract class Servico<T> where T : Entidade
    {

        protected IRepositorio<T> Repositorio { get; set; }

        public Servico(IRepositorio<T> repositorio)
        {
            this.Repositorio = repositorio;
        }


        public virtual T Adicionar(T entidade)
        {
            try
            {
                entidade.Validar();

                entidade = Repositorio.Adicionar(entidade);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return entidade;
        }



        public virtual T Atualizar(T entidade)
        {
            try
            {
                entidade.Validar();

                entidade = Repositorio.Atualizar(entidade);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return entidade;
        }


        public virtual T ConsultarPorId(int id)
        {
            try
            {
                return Repositorio.ConsultarPorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public virtual List<T> BuscarTodos()
        {
            try
            {
                return Repositorio.BuscarTodos();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public virtual int Excluir(T entidade)
        {
            try
            {
                return Repositorio.Excluir(entidade.Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public virtual List<T> Filtrar(object[] filtros)
        {
            try
            {
                return Repositorio.ConsultarComFiltragem(filtros);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public virtual void GerarPDF(List<T> entidades, string path)
        {
            PDFWriterUtil<T> pdf = new PDFWriterUtil<T>();
            pdf.Write(entidades,"Listagem de " + typeof(T).Name ,path);
        }

        public virtual void GerarXML(List<T> entidades, string path)
        {
            XMLUtil.WriteXML(entidades, path);
        }

        public virtual void GerarCSV(List<T> entidades, string path)
        {
            CSVUtil.WriteCSV(entidades,path);

        }

    }

}
