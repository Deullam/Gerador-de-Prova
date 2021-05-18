using System;
using System.Collections.Generic;
using NDD.GeradorProva.Infra.Data.Nucleo;
using NDD.GeradorProva.Infra;
using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.Domain.Interfaces.Repositorio;

namespace NDD.GeradorProva.Application
{
    public class SerieServico : Servico<Serie>
    {
        private MateriaServico _materiaServico;

        public SerieServico(MateriaServico materiaServico) : base(RepositorioIoC.Serie)
        {
            this._materiaServico = materiaServico;
        }

        public SerieServico(IRepositorio<Serie> repositorio, MateriaServico materiaServico) : base(repositorio)
        {
            this._materiaServico = materiaServico;
        }

        public List<Serie> CarregarPorNumero(int numero)
        {
            try
            {
                ISerieRepositorio serieRepositorio = base.Repositorio as ISerieRepositorio;
                return serieRepositorio.ConsultarPorNumero(numero);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void ValidarExistenciaNumero(int numero, int id)
        {
            try
            {
                ISerieRepositorio serieRepositorio = base.Repositorio as ISerieRepositorio;
                IList<Serie> series = serieRepositorio.ConsultarPorNumeroEId(numero, id);
                if (series.Count > 0)
                {
                    throw new ValidacaoExcecao("Esta série já foi cadastrada.", new List<String>() { "Numero" });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override int Excluir(Serie entidade)
        {
            if (_materiaServico.CarregarPorSerie(entidade.Id).Count > 0)
            {
                throw new ValidacaoExcecao("Esta série não pode ser excluída pois está vínculada a uma matéria.");
            }

            return base.Excluir(entidade);
        }

    }
}
