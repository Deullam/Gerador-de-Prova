using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.Domain.Interfaces.Repositorio;
using NDD.GeradorProva.Infra.Data.Nucleo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace NDD.GeradorProva.Infra.Data.RepositorioSQL
{
    public class TesteRepositorioSQL : RepositorioSQL<Teste>, ITesteRepositorio
    {
        #region Scripts
        private readonly string _inserir =
                          @"INSERT INTO teste
                               (id_disciplina ,id_materia,titulo,numero_questoes,data_geracao)
                            VALUES 
                                ({0}id_disciplina ,{0}id_materia,{0}titulo,{0}numero_questoes,{0}data_geracao)";




        private readonly string _carregarTodos = @"SELECT 
                                                        t.*,
                                                        d.nome AS disciplina_nome,
                                                        m.nome AS materia_nome,
                                                        s.numero as serie_numero
                                                    FROM teste AS t
                                                    JOIN disciplina AS d ON (t.id_disciplina = d.id)
                                                    JOIN materia AS m ON (t.id_materia = m.id)
                                                    JOIN serie AS s on (m.id_serie = s.id)
                                                    ORDER BY t.titulo ASC";

        private readonly string _carregarTodosFiltragem =
                                @"SELECT 
                                    t.*,
                                    d.nome AS disciplina_nome,
                                    m.nome AS materia_nome,
                                    s.numero as serie_numero
                                FROM teste AS t
                                JOIN disciplina AS d ON (t.id_disciplina = d.id)
                                JOIN materia AS m ON (t.id_materia = m.id)
                                JOIN serie AS s on (m.id_serie = s.id)
                                {0} ORDER BY t.titulo ASC";

        private readonly string _atualizar =
                           @"UPDATE teste
                           SET titulo = {0}titulo,id_disciplina = {0}id_disciplina,
                           id_materia = {0}id_materia,numero_questoes = {0}numero_questoes,
                           data_geracao = {0}data_geracao
                           WHERE id = {0}id";

        private readonly string _excluir = @"DELETE FROM teste WHERE id = {0}id";

        private readonly string _carregarPorId =
                          @"SELECT 
                                t.*,
                                d.nome AS disciplina_nome,
                                m.nome AS materia_nome,
                                s.numero as serie_numero
                            FROM teste AS t
                            JOIN disciplina AS d ON (t.id_disciplina = d.id)
                            JOIN materia AS m ON (t.id_materia = m.id)
                            JOIN serie AS s on (m.id_serie = s.id)
                           WHERE t.id = {0}id";

        //Utilizado para verificar se existe duplicidade de titulo
        private readonly string _carregarPorTituloENaoId =
                         @"SELECT 
                            *
                           FROM teste
                           WHERE titulo = {0}titulo
                           AND id != {0}id";

        private readonly string _carregarPorTitulo =
                          @"SELECT 
                              *
                            FROM teste
                            WHERE titulo = {0}titulo";

        private readonly string _carregarPorDisciplina =
                          @"SELECT 
                              *
                            FROM teste
                            WHERE id_disciplina = {0}id_disciplina";

        private readonly string _carregarPorMateria =
                          @"SELECT 
                              *
                            FROM teste
                            WHERE id_materia = {0}id_materia";

        private readonly string _carregarMateriaPorDisciplina=
                          @"SELECT 
                              *
                            FROM materia
                            WHERE id_disciplina = {0}id_disciplina";

       
        #endregion Scripts


        public TesteRepositorioSQL(TipoBancoDeDados tipo) : base(tipo)
        {
        }
        public Teste Adicionar(Teste entidade)
        {
            entidade.Id = base.ExecutarAtualizacao(_inserir, EntidadeParaTupla(entidade, false));
            foreach (Questao questao in entidade.Questoes)
            {
                RepositorioIoC.TesteQuestao.Adicionar(entidade, questao);
            }
            return entidade;
        }

        public Teste Atualizar(Teste entidade)
        {
            base.ExecutarAtualizacao(_atualizar, EntidadeParaTupla(entidade, true), false);
            return entidade;
        }

        

        public List<Teste> BuscarTodos()
        {
            return base.ConsultarLista(_carregarTodos, TuplaParaEntidadeComJoin);
        }

        public Teste ConsultarPorId(int id)
        {
            return base.ConsultarEntidade(_carregarPorId, TuplaParaEntidadeComJoin, new Dictionary<String, Object>() { { "id", id } });
        }

        public List<Teste> ConsultarPorTitulo(string titulo)
        {
            return base.ConsultarLista(_carregarPorTitulo, TuplaParaEntidade, new Dictionary<String, Object>() { { "titulo", titulo } });
        }

        public List<Teste> ConsultarPorTituloEId(string titulo, int id)
        {
            return base.ConsultarLista(_carregarPorTituloENaoId, TuplaParaEntidade, new Dictionary<String, Object>() { { "titulo", titulo }, { "id", id } });
        }

        public int Excluir(int id)
        {
            return base.Excluir(_excluir, id);
        }

        public List<Teste> ConsultarPorDisciplina(int idDisciplina)
        {
            return base.ConsultarLista(_carregarPorDisciplina, TuplaParaEntidade, new Dictionary<String, Object>() { { "id_disciplina", idDisciplina } });
        }

        public Dictionary<String, Object> EntidadeParaTupla(Teste teste, bool temId)
        {
            Dictionary<String, Object> parametros = new Dictionary<string, object>();
            parametros.Add("titulo", teste.Titulo);
            parametros.Add("data_geracao", teste.DataGeracao);
            parametros.Add("numero_questoes", teste.QuantidadeQuestoes);
            parametros.Add("id_materia", teste.Materia.Id);
            parametros.Add("id_disciplina", teste.Disciplina.Id);
            
            if (temId)
            {
                parametros.Add("id", teste.Id);
            }

            return parametros;
        }

        public List<Teste> ConsultarPorMateria(int idMateria)
        {
            return base.ConsultarLista(_carregarPorMateria, TuplaParaEntidade, new Dictionary<String, Object>() { { "id_materia", idMateria } });
        }


        public List<Teste> ConsultarComFiltragem(object[] filtros)
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
                            strBuilder.Append((strBuilder.Length == 0 ? "WHERE " : " AND ") + "UPPER(t.titulo) LIKE UPPER({0}titulo)");
                            parametros.Add("titulo", "%" + filtros[i] + "%");
                        }
                        break;

                    case 1:

                        if (filtros[i] != null)
                        {
                            strBuilder.Append((strBuilder.Length == 0 ? "WHERE " : " AND ") + "t.id_disciplina = {0}id_disciplina");
                            parametros.Add("id_disciplina", ((Disciplina)filtros[i]).Id);
                        }
                        break;

                    case 2:
                        if (filtros[i] != null)
                        {
                            strBuilder.Append((strBuilder.Length == 0 ? "WHERE " : " AND ") + "t.id_materia = {0}id_materia");
                            parametros.Add("id_materia", ((Materia)filtros[i]).Id);
                        }
                        break;

                    case 3:
                        if (filtros[i] != null)
                        {
                            strBuilder.Append((strBuilder.Length == 0 ? "WHERE " : " AND ") + "cast(t.data_geracao AS DATE) = {0}data_geracao");
                            parametros.Add("data_geracao", filtros[i]);
                        }
                        break;
                }
            }
            return ConsultarLista(string.Format(_carregarTodosFiltragem, strBuilder.ToString()), TuplaParaEntidadeComJoin, parametros);
        }

        private static Func<IDataReader, Teste> TuplaParaEntidade = reader =>
          new Teste()
          {
              Id = Convert.ToInt32(reader["id"]),
              Titulo = Convert.ToString(reader["titulo"]),
              DataGeracao =Convert.ToDateTime(reader["data_geracao"]),
              QuantidadeQuestoes = Convert.ToInt16(reader["numero_questoes"]),
              Materia = new Materia() { Id = Convert.ToInt32(reader["id_materia"]) },
              Disciplina = new Disciplina() { Id = Convert.ToInt32(reader["id_disciplina"]) },
              Questoes = RepositorioIoC.TesteQuestao.ConsultarPorTeste(Convert.ToInt32(reader["id"]))

          };


        private static Func<IDataReader, Teste> TuplaParaEntidadeComJoin = reader =>
          new Teste()
          {
              Id = Convert.ToInt32(reader["id"]),
              Titulo = Convert.ToString(reader["titulo"]),
              DataGeracao = Convert.ToDateTime(reader["data_geracao"]),
              QuantidadeQuestoes = Convert.ToInt16(reader["numero_questoes"]),
              Materia = new Materia() {
                  Id = Convert.ToInt32(reader["id_materia"]),
                  Nome = Convert.ToString(reader["materia_nome"]),
                  Serie = new Serie() {
                        Numero = Convert.ToInt16(reader["serie_numero"])
                    }, 
                    
              },
              Disciplina = new Disciplina() {
                  Id = Convert.ToInt32(reader["id_disciplina"]),
                  Nome = Convert.ToString(reader["disciplina_nome"])
              },
              Questoes = RepositorioIoC.TesteQuestao.ConsultarPorTeste(Convert.ToInt32(reader["id"]))

          };
    }
}
