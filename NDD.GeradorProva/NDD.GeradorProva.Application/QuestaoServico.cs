using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.Domain.Interfaces.Repositorio;
using NDD.GeradorProva.Infra;
using NDD.GeradorProva.Infra.Data.Nucleo;
using NDD.GeradorProva.Infra.Util;
using System;
using System.Collections.Generic;

namespace NDD.GeradorProva.Application
{
    public class QuestaoServico : Servico<Questao>
    {

        public QuestaoServico() : base(RepositorioIoC.Questao)
        {
        }

        public QuestaoServico(IRepositorio<Questao> repositorio) : base(repositorio)
        {
        }

        public List<Questao> CarregarPorSintese(String sintese)
        {
            try
            {
                IQuestaoRepositorio questaoRepositorio = base.Repositorio as IQuestaoRepositorio;
                return questaoRepositorio.ConsultarPorSintese(sintese);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void ValidarExistenciaSintese(String sintese, int id)
        {
            try
            {
                IQuestaoRepositorio questaoRepositorio = base.Repositorio as IQuestaoRepositorio;
                IList<Questao> questao = questaoRepositorio.ConsultarPorSinteseEId(sintese, id);
                if (questao.Count > 0)
                {
                    throw new ValidacaoExcecao("Esta síntese já foi informada", new List<String>() { "Sintese" });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Questao> CarregarPorEnunciado(String enunciado)
        {
            try
            {
                IQuestaoRepositorio questaoRepositorio = base.Repositorio as IQuestaoRepositorio;
                return questaoRepositorio.ConsultarPorEnunciado(enunciado);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void ValidarExistenciaEnunciado(String enunciado, int id)
        {
            try
            {
                IQuestaoRepositorio questaoRepositorio = base.Repositorio as IQuestaoRepositorio;
                List<Questao> questao = questaoRepositorio.ConsultarPorEnunciadoEId(enunciado, id);
                if (questao.Count > 0)
                {
                    throw new ValidacaoExcecao("Este enunciado já foi informado", new List<String>() { "Enunciado" });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Questao> CarregarPorDisciplina(int idDisciplina)
        {
            try
            {
                IQuestaoRepositorio questaoRepositorio = base.Repositorio as IQuestaoRepositorio;
                return questaoRepositorio.ConsultarPorDisciplina(idDisciplina);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Questao> CarregarPorMateria(int idMateria)
        {
            try
            {
                IQuestaoRepositorio questaoRepositorio = base.Repositorio as IQuestaoRepositorio;
                return questaoRepositorio.ConsultarPorMateria(idMateria);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override int Excluir(Questao entidade)
        {
            if (RepositorioIoC.TesteQuestao.ConsultarPorQuestao(entidade.Id).Count > 0)
            {
                throw new ValidacaoExcecao("Esta questão não pode ser excluída pois está vínculada a um teste.");
            }

            return base.Excluir(entidade);
        }

        public override void GerarPDF(List<Questao> entidades, string path)
        {
            PDFWriterUtilQuestao pdf = new PDFWriterUtilQuestao();
            pdf.Write(entidades, "Listagem de Questões", path);

        }

        public override void GerarCSV(List<Questao> entidades, string path)
        {
            CSVUtil.WriteQuestoesCSV(entidades, path); 
        }
    }
}
