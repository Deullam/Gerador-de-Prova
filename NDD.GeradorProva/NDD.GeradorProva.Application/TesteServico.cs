using NDD.GeradorProva.Infra;
using NDD.GeradorProva.Infra.Data.Nucleo;
using System;
using System.Collections.Generic;
using NDD.GeradorProva.Infra.Util;
using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.Domain.Interfaces.Repositorio;

namespace NDD.GeradorProva.Application
{
    public class TesteServico : Servico<Teste>
    {
        public TesteServico() : base(RepositorioIoC.Teste)
        {
        }

        public TesteServico(IRepositorio<Teste> repositorio) : base(repositorio)
        {
        }

        public List<Teste> CarregarPorTitulo(String titulo)
        {
            try
            {
                ITesteRepositorio testeRepositorio = base.Repositorio as ITesteRepositorio;
                return testeRepositorio.ConsultarPorTitulo(titulo);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void ValidarExistenciaTitulo(String titulo, int id)
        {
            try
            {
                ITesteRepositorio testeRepositorio = base.Repositorio as ITesteRepositorio;
                IList<Teste> testes = testeRepositorio.ConsultarPorTituloEId(titulo, id);
                if (testes.Count > 0)
                {
                    throw new ValidacaoExcecao("Este titulo já foi informado", new List<String>() { "Titulo" });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Teste> CarregarPorMateria(int idMateria)
        {
            try
            {
                ITesteRepositorio testeRepositorio = base.Repositorio as ITesteRepositorio;
                return testeRepositorio.ConsultarPorMateria(idMateria);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Teste> CarregarPorDisciplina(int idDisciplina)
        {
            try
            {
                ITesteRepositorio testeRepositorio = base.Repositorio as ITesteRepositorio;
                return testeRepositorio.ConsultarPorDisciplina(idDisciplina);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        public void GerarPDFTeste(Teste teste, string path)
        {
            PDFWriterUtilTeste pdf = new PDFWriterUtilTeste();
            pdf.WriteTeste(teste, path);
        }

        public void GerarCSVTeste(Teste teste, string path)
        {
            CSVUtil.WriteTesteCSV(teste, path);

        }

        public void GerarXMLTeste(Teste teste, string path)
        {
            XMLUtil.WriteTesteXML(teste, path);
        }
    }
}

