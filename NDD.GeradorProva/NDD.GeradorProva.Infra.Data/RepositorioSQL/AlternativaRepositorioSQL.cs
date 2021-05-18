using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.Domain.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Data;

namespace NDD.GeradorProva.Infra.Data.RepositorioSQL
{
    public class AlternativaRepositorioSQL : RepositorioSQL<Alternativa>, IAlternativaRepositorio
    {
        #region Scripts
        private readonly string _inserir =
                          @"INSERT INTO alternativa
                               (descricao, correta, id_questao)
                            VALUES 
                                ({0}descricao,{0}correta,{0}id_questao)";

        private readonly string _carregarTodos = @"SELECT * FROM alternativa ORDER BY descricao ASC";

        private readonly string _atualizar =
                           @"UPDATE alternativa
                           SET descricao = {0}descricao ,
                           correta = {0}correta,
                           id_questao = {0}id_questao   
                            
                            WHERE id = {0}id";

        private readonly string _excluir = @"DELETE FROM alternativa WHERE id = {0}id";

        private readonly string _excluirPorQuestao = @"DELETE FROM alternativa WHERE id_questao = {0}id_questao";

        private readonly string _carregarPorId =
                          @"SELECT 
                            *
                           FROM alternativa
                           WHERE id = {0}id";


        private readonly string _carregarPorQuestao =
                          @"SELECT 
                             *
                            FROM alternativa
                            WHERE id_questao = {0}id_questao";


        #endregion Scripts

        public AlternativaRepositorioSQL(TipoBancoDeDados tipo) : base(tipo)
        {

        }

        public Alternativa Adicionar(Alternativa entidade)
        {
            entidade.Id = base.ExecutarAtualizacao(_inserir, EntidadeParaTupla(entidade, false));
            return entidade;
        }

        public Alternativa Atualizar(Alternativa entidade)
        {
            base.ExecutarAtualizacao(_atualizar, EntidadeParaTupla(entidade, true), false);
            return entidade;
        }

        public List<Alternativa> BuscarTodos()
        {
            return base.ConsultarLista(_carregarTodos, TuplaParaEntidade);
        }

        public Alternativa ConsultarPorId(int id)
        {
            return base.ConsultarEntidade(_carregarPorId, TuplaParaEntidade, new Dictionary<String, Object>() { { "id", id } });
        }

        public int Excluir(int id)
        {
            return base.Excluir(_excluir, id);
        }

        public List<Alternativa> ConsultarPorQuestao(int idQuestao)
        {
            return base.ConsultarLista(_carregarPorQuestao, TuplaParaEntidade, new Dictionary<String, Object>() { { "id_questao", idQuestao } });
        }

        private static Func<IDataReader, Alternativa> TuplaParaEntidade = reader =>
         new Alternativa()
         {
             Id = Convert.ToInt32(reader["id"]),
             Descricao = Convert.ToString(reader["descricao"]),
             Correta = Convert.ToBoolean(reader["correta"]),
             Questao = new Questao() { Id = Convert.ToInt32(reader["id_questao"]) }
         };

        public Dictionary<String, Object> EntidadeParaTupla(Alternativa alternativa, bool temId)
        {
            Dictionary<String, Object> parametros = new Dictionary<string, object>();
            parametros.Add("descricao", alternativa.Descricao);
            parametros.Add("correta", alternativa.Correta);
            parametros.Add("id_questao", alternativa.Questao.Id);

            if (temId)
            {
                parametros.Add("id", alternativa.Id);
            }

            return parametros;
        }

        public void ExcluirPorQuestao(int idQuestao)
        {
            base.Excluir(_excluirPorQuestao, idQuestao, "id_questao");
        }

        public List<Alternativa> ConsultarComFiltragem(object[] filtros)
        {
            throw new NotImplementedException();
        }
    }
}
