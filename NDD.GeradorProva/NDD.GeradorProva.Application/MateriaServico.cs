using NDD.GeradorProva.Infra;
using NDD.GeradorProva.Infra.Data.Nucleo;
using System;
using System.Collections.Generic;
using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.Domain.Interfaces.Repositorio;

namespace NDD.GeradorProva.Application
{
    public class MateriaServico : Servico<Materia>
    {

        private TesteServico _testeServico;
        private QuestaoServico _questaoServico;

        public MateriaServico(QuestaoServico questaoServico, TesteServico testeServico) : base(RepositorioIoC.Materia)
        {
            _testeServico = testeServico;
            _questaoServico = questaoServico;
        }

        public MateriaServico(IRepositorio<Materia> repositorio) : base(repositorio)
        {
        }

        public List<Materia> CarregarPorNome(String nome)
        {
            try
            {
                IMateriaRepositorio materiaRepositorio = base.Repositorio as IMateriaRepositorio;
                return materiaRepositorio.ConsultarPorNome(nome);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void ValidarExistenciaNome(String nome, int id)
        {
            try
            {
                IMateriaRepositorio materiaRepositorio = base.Repositorio as IMateriaRepositorio;
                IList<Materia> materias = materiaRepositorio.ConsultarPorNomeEId(nome, id);
                if (materias.Count > 0)
                {
                    throw new ValidacaoExcecao("Este nome já foi informado", new List<String>() { "Nome" });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Materia> CarregarPorDisciplina(int idDisciplina)
        {
            try
            {
                IMateriaRepositorio materiaRepositorio = base.Repositorio as IMateriaRepositorio;
                return materiaRepositorio.ConsultarPorDisciplina(idDisciplina);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Materia> CarregarPorSerie(int idSerie)
        {
            try
            {
                IMateriaRepositorio materiaRepositorio = base.Repositorio as IMateriaRepositorio;
                return materiaRepositorio.ConsultarPorSerie(idSerie);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override int Excluir(Materia entidade)
        {
            if (_questaoServico.CarregarPorMateria(entidade.Id).Count > 0)
            {
                throw new ValidacaoExcecao("Esta matéria não pode ser excluída pois está vínculada a uma questão.");
            }

            if (_testeServico.CarregarPorMateria(entidade.Id).Count > 0)
            {
                throw new ValidacaoExcecao("Esta matéria não pode ser excluída pois está vínculada a um teste.");
            }

            return base.Excluir(entidade);
        }

    }
}

