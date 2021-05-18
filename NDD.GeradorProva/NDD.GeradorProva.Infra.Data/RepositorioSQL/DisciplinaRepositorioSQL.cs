using System;
using System.Collections.Generic;
using System.Data;
using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.Domain.Interfaces.Repositorio;
using System.Text;

namespace NDD.GeradorProva.Infra.Data.RepositorioSQL
{
    public class DisciplinaRepositorioSQL : RepositorioSQL<Disciplina>, IDisciplinaRepositorio
    {
        #region Scripts
        private readonly string _inserir =
                          @"INSERT INTO disciplina
                               (nome)
                            VALUES 
                                ({0}nome)";

        private readonly string _carregarTodos = @"SELECT * FROM disciplina ORDER BY nome ASC";

        private readonly string _carregarTodosFiltragem = @"SELECT * FROM disciplina {0} ORDER BY nome ASC";

        private readonly string _atualizar =
                           @"UPDATE disciplina
                           SET nome = {0}nome 
                            WHERE id = {0}id";

        private readonly string _excluir = @"DELETE FROM disciplina WHERE id = {0}id";

        private readonly string _carregarPorId =
                          @"SELECT 
                            *
                           FROM disciplina
                           WHERE id = {0}id";

        private readonly string _carregarPorNomeEId =
                         @"SELECT 
                            *
                           FROM disciplina
                           WHERE nome = {0}nome
                           AND id != {0}id";

        private readonly string _carregarPorNome =
                          @"SELECT 
                              *
                            FROM disciplina
                            WHERE nome = {0}nome";
        #endregion Scripts


        public DisciplinaRepositorioSQL(TipoBancoDeDados tipo) : base(tipo)
        {
        }

        public  Disciplina Adicionar(Disciplina entidade)
        {
            entidade.Id = base.ExecutarAtualizacao(_inserir, EntidadeParaTupla(entidade, false));
            return entidade;
        }

        public  Disciplina Atualizar(Disciplina entidade)
        {
            base.ExecutarAtualizacao(_atualizar, EntidadeParaTupla(entidade, true), false);
            return entidade;
        }

        public  List<Disciplina> BuscarTodos()
        {
            return base.ConsultarLista(_carregarTodos, TuplaParaEntidade);
        }

        public  Disciplina ConsultarPorId(int id)
        {
            return base.ConsultarEntidade(_carregarPorId, TuplaParaEntidade, new Dictionary<String, Object>() { { "id", id } });
        }

        public  int Excluir(int id)
        {
            return base.Excluir(_excluir, id);
        }

        public List<Disciplina> ConsultarPorNome(String nome)
        {
            return base.ConsultarLista(_carregarPorNome, TuplaParaEntidade, new Dictionary<String, Object>() { { "nome", nome } });
        }

        public List<Disciplina> ConsultarPorNomeEId(String nome, int id)
        {
            return base.ConsultarLista(_carregarPorNomeEId, TuplaParaEntidade, new Dictionary<String, Object>() { { "nome", nome }, { "id", id } });
        }

        public Dictionary<String, Object> EntidadeParaTupla(Disciplina disciplina, bool temId)
        {
            Dictionary<String, Object> parametros = new Dictionary<string, object>();
            parametros.Add("nome", disciplina.Nome);

            if (temId)
            {
                parametros.Add("id", disciplina.Id);
            }

            return parametros;
        }

        public List<Disciplina> ConsultarComFiltragem(object[] filtros)
        {
            Dictionary<String, Object> parametros = new Dictionary<string, object>();

            StringBuilder strBuilder = new StringBuilder();
            
            if (!string.IsNullOrEmpty((string) filtros[0]))
            {
                strBuilder.Append((strBuilder.Length == 0 ? "WHERE " : " AND ") + "UPPER(nome) LIKE UPPER({0}nome)");
                parametros.Add("nome", filtros[0] + "%");
            }

            return ConsultarLista(string.Format(_carregarTodosFiltragem, strBuilder.ToString()), TuplaParaEntidade, parametros);
        }


        private static Func<IDataReader, Disciplina> TuplaParaEntidade = reader =>
          new Disciplina()
          {
              Id = Convert.ToInt32(reader["id"]),
              Nome = Convert.ToString(reader["nome"])
          };
    }
}
