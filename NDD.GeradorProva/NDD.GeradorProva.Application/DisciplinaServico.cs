using System;
using System.Collections.Generic;
using NDD.GeradorProva.Infra.Data.Nucleo;
using NDD.GeradorProva.Infra;
using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.Domain.Interfaces.Repositorio;

namespace NDD.GeradorProva.Application
{
    public class DisciplinaServico : Servico<Disciplina>
    {
        private MateriaServico _materiaServico;
        private QuestaoServico _questaoServico;
        private TesteServico _testeServico;

        public DisciplinaServico(MateriaServico materiaServico, QuestaoServico questaoServico, TesteServico testeServico) : base(RepositorioIoC.Disciplina)
        {
            _materiaServico = materiaServico;
            _questaoServico = questaoServico;
            _testeServico = testeServico;
        }

        public DisciplinaServico(IRepositorio<Disciplina> repositorio, MateriaServico materiaServico) : base(repositorio)
        {
            this._materiaServico = materiaServico;
        }

        public List<Disciplina> CarregarPorNome(String nome)
        {
            try
            {
                IDisciplinaRepositorio disciplinaRepositorio = base.Repositorio as IDisciplinaRepositorio;
                return disciplinaRepositorio.ConsultarPorNome(nome);
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
                IDisciplinaRepositorio disciplinaRepositorio = base.Repositorio as IDisciplinaRepositorio;
                IList<Disciplina> disciplinas = disciplinaRepositorio.ConsultarPorNomeEId(nome, id);
                if(disciplinas.Count > 0)
                {
                    throw new ValidacaoExcecao("Este nome já foi informado", new List<String>() {"Nome"});
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override int Excluir(Disciplina entidade)
        {
            if (_materiaServico.CarregarPorDisciplina(entidade.Id).Count > 0)
            {
                throw new ValidacaoExcecao("Esta disciplina não pode ser excluída pois está vínculada a uma matéria.");
            }

            if (_questaoServico.CarregarPorDisciplina(entidade.Id).Count > 0)
            {
                throw new ValidacaoExcecao("Esta disciplina não pode ser excluída pois está vínculada a uma questão.");
            }

            if (_testeServico.CarregarPorDisciplina(entidade.Id).Count > 0)
            {
                throw new ValidacaoExcecao("Esta disciplina não pode ser excluída pois está vínculada a um teste.");
            }

            return base.Excluir(entidade);
        }

    }
}
