using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.Domain.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace NDD.GeradorProva.Infra.Data.RepositorioSQL
{
    public class MateriaRepositorioSQL : RepositorioSQL<Materia>, IMateriaRepositorio
    {
        #region Scripts
        private readonly string _inserir =
                          @"INSERT INTO materia
                               (nome, id_serie,id_disciplina)
                            VALUES 
                                ({0}nome,{0}id_serie,{0}id_disciplina)";

        private readonly string _carregarTodos =
                            @"SELECT 
                                m.*,
                                d.nome AS disciplina_nome,
                                s.numero AS serie_numero
                              FROM materia AS m 
                              INNER JOIN disciplina AS d ON (m.id_disciplina = d.id)
                              INNER JOIN serie AS s ON (m.id_serie = s.id)
                              ORDER BY m.nome ASC";

        private readonly string _carregarTodosFiltragem =
                            @"SELECT 
                                m.*,
                                d.nome AS disciplina_nome,
                                s.numero AS serie_numero
                              FROM materia AS m 
                              INNER JOIN disciplina AS d ON (m.id_disciplina = d.id)
                              INNER JOIN serie AS s ON (m.id_serie = s.id)
                              {0} ORDER BY m.nome ASC";

        private readonly string _atualizar =
                           @"UPDATE materia
                           SET nome = {0}nome ,
                           id_serie = {0}id_serie,
                           id_disciplina = {0}id_disciplina
                            
                            WHERE id = {0}id";

        private readonly string _excluir = @"DELETE FROM materia WHERE id = {0}id";

        private readonly string _carregarPorId =
                          @"SELECT 
                                m.*,
                                d.nome AS disciplina_nome,
                                s.numero AS serie_numero
                            FROM materia AS m 
                            INNER JOIN disciplina AS d ON (m.id_disciplina = d.id)
                            INNER JOIN serie AS s ON (m.id_serie = s.id)
                            WHERE m.id = {0}id";

        //Utilizado para verificar se existe duplicidade de nome
        private readonly string _carregarPorNomeENaoId =
                         @"SELECT 
                            *
                           FROM materia
                           WHERE nome = {0}nome
                           AND id != {0}id";

        private readonly string _carregarPorNome =
                          @"SELECT 
                              *
                            FROM materia
                            WHERE nome = {0}nome";

        private readonly string _carregarPorDisciplina =
                          @"SELECT 
                              m.*,
                                d.nome AS disciplina_nome,
                                s.numero AS serie_numero
                            FROM materia AS m 
                            INNER JOIN disciplina AS d ON (m.id_disciplina = d.id)
                            INNER JOIN serie AS s ON (m.id_serie = s.id)
                            WHERE m.id_disciplina = {0}id_disciplina";

        private readonly string _carregarPorSerie =
                          @"SELECT 
                              *
                            FROM materia
                            WHERE id_serie = {0}id_serie";

        #endregion Scripts


        public MateriaRepositorioSQL(TipoBancoDeDados tipo) : base(tipo)
        {
        }
        public  Materia Adicionar(Materia entidade)
        {
            entidade.Id = base.ExecutarAtualizacao(_inserir, EntidadeParaTupla(entidade, false));
            return entidade;
        }

        public  Materia Atualizar(Materia entidade)
        {
            base.ExecutarAtualizacao(_atualizar, EntidadeParaTupla(entidade, true), false);
            return entidade;
        }

        public  List<Materia> BuscarTodos()
        {
            return base.ConsultarLista(_carregarTodos, TuplaParaEntidadeComJoin);
        }

        public  Materia ConsultarPorId(int id)
        {
            return base.ConsultarEntidade(_carregarPorId, TuplaParaEntidadeComJoin, new Dictionary<String, Object>() { { "id", id } });
        }

        public List<Materia> ConsultarPorNome(string nome)
        {
            return base.ConsultarLista(_carregarPorNome, TuplaParaEntidade, new Dictionary<String, Object>() { { "nome", nome } });
        }

        public List<Materia> ConsultarPorNomeEId(string nome, int id)
        {
            return base.ConsultarLista(_carregarPorNomeENaoId, TuplaParaEntidade, new Dictionary<String, Object>() { { "nome", nome }, { "id", id } });
        }

        public  int Excluir(int id)
        {
            return base.Excluir(_excluir, id);
        }

        public List<Materia> ConsultarPorDisciplina(int idDisciplina)
        {
            return base.ConsultarLista(_carregarPorDisciplina, TuplaParaEntidadeComJoin, new Dictionary<String, Object>() { { "id_disciplina", idDisciplina } });
        }

        public List<Materia> ConsultarPorSerie(int idSerie)
        {
            return base.ConsultarLista(_carregarPorSerie, TuplaParaEntidade, new Dictionary<String, Object>() { { "id_serie", idSerie } });
        }

        public Dictionary<String, Object> EntidadeParaTupla(Materia materia, bool temId)
        {
            Dictionary<String, Object> parametros = new Dictionary<string, object>();
            parametros.Add("nome", materia.Nome);
            parametros.Add("id_serie", materia.Serie.Id);
            parametros.Add("id_disciplina", materia.Disciplina.Id);


            if (temId)
            {
                parametros.Add("id", materia.Id);
            }

            return parametros;
        }

        public List<Materia> ConsultarComFiltragem(object[] filtros)
        {
            Dictionary<String, Object> parametros = new Dictionary<string, object>();

            StringBuilder strBuilder = new StringBuilder();

            for (int i = 0; i < filtros.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        if (!string.IsNullOrEmpty((string)filtros[i]))
                        {
                            strBuilder.Append((strBuilder.Length == 0 ? "WHERE " : " AND ") + "UPPER(m.nome) LIKE UPPER({0}nome)");
                            parametros.Add("nome", filtros[i] + "%");
                        }
                        break;

                    case 1:
                       
                        if (filtros[i] != null)
                        {
                            strBuilder.Append((strBuilder.Length == 0 ? "WHERE " : " AND ") + "m.id_disciplina = {0}id_disciplina");
                            parametros.Add("id_disciplina", ((Disciplina) filtros[i]).Id);
                        }
                        break;

                    case 2:
                        if (filtros[i] != null)
                        {
                            strBuilder.Append((strBuilder.Length == 0 ? "WHERE " : " AND ") + "m.id_serie = {0}id_serie");
                            parametros.Add("id_serie", ((Serie) filtros[i]).Id);
                        }
                        break;
                }
            }

            return ConsultarLista(string.Format(_carregarTodosFiltragem, strBuilder.ToString()), TuplaParaEntidadeComJoin, parametros);
        }

        private static Func<IDataReader, Materia> TuplaParaEntidade = reader =>
          new Materia()
          {     
              Id = Convert.ToInt32(reader["id"]),
              Nome = Convert.ToString(reader["nome"]),
              Serie = new Serie() { Id = Convert.ToInt32(reader["id_serie"]) },
              Disciplina =  new Disciplina() { Id = Convert.ToInt32(reader["id_disciplina"])}

          };

        private static Func<IDataReader, Materia> TuplaParaEntidadeComJoin = reader =>
          new Materia()
          {
              Id = Convert.ToInt32(reader["id"]),
              Nome = Convert.ToString(reader["nome"]),
              Serie = new Serie()
              {
                  Id = Convert.ToInt32(reader["id_serie"]),
                  Numero = Convert.ToInt32(reader["serie_numero"])
              },
              Disciplina = new Disciplina()
              {
                  Id = Convert.ToInt32(reader["id_disciplina"]),
                  Nome = Convert.ToString(reader["disciplina_nome"])
              }

          };
    }
}
