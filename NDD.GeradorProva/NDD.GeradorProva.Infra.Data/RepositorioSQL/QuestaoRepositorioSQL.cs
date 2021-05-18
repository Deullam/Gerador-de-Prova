using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.Domain.Interfaces.Repositorio;
using NDD.GeradorProva.Infra.Data.Nucleo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace NDD.GeradorProva.Infra.Data.RepositorioSQL
{
    public class QuestaoRepositorioSQL : RepositorioSQL<Questao> , IQuestaoRepositorio
    {
        #region Scripts
        private readonly string _inserir =
                          @"INSERT INTO questao
                               (sintese, enunciado, id_disciplina, id_materia, bimestre)
                            VALUES 
                                ({0}sintese,{0}enunciado,{0}id_disciplina,{0}id_materia,{0}bimestre)";

        private readonly string _carregarTodos = @"SELECT 
                            q.*,
                            m.nome AS materia_nome,
                            m.id_serie,
                            d.nome AS disciplina_nome,
                            s.numero AS serie_numero
                           FROM questao AS q
                            INNER JOIN materia AS m ON (q.id_materia = m.id)
                            INNER JOIN disciplina AS d ON (q.id_disciplina = d.id)
                            INNER JOIN serie AS s ON (m.id_serie = s.id)
                            ORDER BY m.nome ASC";

        private readonly string _carregarTodosFiltragem =
                            @"SELECT 
                                q.*,
                                m.nome AS materia_nome,
                                m.id_serie,
                                d.nome AS disciplina_nome,
                                s.numero AS serie_numero
                           FROM questao AS q
                            INNER JOIN materia AS m ON (q.id_materia = m.id)
                            INNER JOIN disciplina AS d ON (q.id_disciplina = d.id)
                            INNER JOIN serie AS s ON (m.id_serie = s.id)
                            {0} ORDER BY m.nome ASC";

        private readonly string _atualizar =
                           @"UPDATE questao
                           SET sintese = {0}sintese ,
                           enunciado = {0}enunciado,
                           id_disciplina = {0}id_disciplina,
                           id_materia = {0}id_materia,
                           bimestre = {0}bimestre
                            
                            WHERE id = {0}id";

        private readonly string _excluir = @"DELETE FROM questao WHERE id = {0}id";

        private readonly string _carregarPorId =
                          @"SELECT 
                            q.*,
                            m.nome AS materia_nome,
                            m.id_serie,
                            d.nome AS disciplina_nome,
                            s.numero AS serie_numero
                           FROM questao AS q
                            INNER JOIN materia AS m ON (q.id_materia = m.id)
                            INNER JOIN disciplina AS d ON (q.id_disciplina = d.id)
                            INNER JOIN serie AS s ON (m.id_serie = s.id)
                           WHERE q.id = {0}id";

        //Utilizado para verificar se existe duplicidade de nome
        private readonly string _carregarPorEnunciadoENaoId =
                         @"SELECT 
                            *
                           FROM questao
                           WHERE enunciado = {0}enunciado
                           AND id != {0}id";

        private readonly string _carregarPorSinteseENaoId =
                         @"SELECT 
                            *
                           FROM questao
                           WHERE sintese = {0}sintese
                           AND id != {0}id";

        private readonly string _carregarPorEnunciado =
                          @"SELECT 
                              *
                            FROM questao
                            WHERE nome = {0}enunciado";

        private readonly string _carregarPorSintese =
                         @"SELECT 
                              *
                            FROM questao
                            WHERE sintese = {0}sintese";

        private readonly string _carregarPorDisciplina =
                          @"SELECT 
                              *
                            FROM questao
                            WHERE id_disciplina = {0}id_disciplina";

        private readonly string _carregarPorMateria =
                          @"SELECT 
                              *
                            FROM questao
                            WHERE id_materia = {0}id_materia";

        #endregion Scripts

        public QuestaoRepositorioSQL(TipoBancoDeDados tipo) : base(tipo)
        {
        }

        public Questao Adicionar(Questao entidade)
        {
            entidade.Id = base.ExecutarAtualizacao(_inserir, EntidadeParaTupla(entidade, false));
            foreach (Alternativa alternativa in entidade.Alternativas)
            {
                alternativa.Questao = entidade;
                RepositorioIoC.Alternativa.Adicionar(alternativa);
            }

            return entidade;
        }

        public Questao Atualizar(Questao entidade)
        {
            base.ExecutarAtualizacao(_atualizar, EntidadeParaTupla(entidade, true), false);
            ((IAlternativaRepositorio)RepositorioIoC.Alternativa).ExcluirPorQuestao(entidade.Id);
            foreach (Alternativa alternativa in entidade.Alternativas)
            {
                alternativa.Questao = entidade;
                RepositorioIoC.Alternativa.Adicionar(alternativa);
            }
            return entidade;
        }

        public List<Questao> BuscarTodos()
        {
            return base.ConsultarLista(_carregarTodos, TuplaParaEntidadeComJoin);
        }

        public Questao ConsultarPorId(int id)
        {
            return base.ConsultarEntidade(_carregarPorId, TuplaParaEntidadeComJoin, new Dictionary<String, Object>() { { "id", id } });
        }

        public int Excluir(int id)
        {
            return base.Excluir(_excluir, id);
        }

        public List<Questao> ConsultarPorEnunciado (string enunciado)
        {
            return base.ConsultarLista(_carregarPorEnunciado, TuplaParaEntidade, new Dictionary<String, Object>() { { "enunciado", enunciado } });
        }

        public List<Questao> ConsultarPorEnunciadoEId(string enunciado, int id)
        {
            return base.ConsultarLista(_carregarPorEnunciadoENaoId, TuplaParaEntidade, new Dictionary<String, Object>() { { "enunciado", enunciado }, { "id", id } });
        }

        public List<Questao> ConsultarPorSintese(string sintese)
        {
            return base.ConsultarLista(_carregarPorSintese, TuplaParaEntidade, new Dictionary<String, Object>() { { "sintese", sintese } });
        }

        public List<Questao> ConsultarPorSinteseEId(string sintese, int id)
        {
            return base.ConsultarLista(_carregarPorSinteseENaoId, TuplaParaEntidade, new Dictionary<String, Object>() { { "sintese", sintese }, { "id", id } });
        }

        public Dictionary<String, Object> EntidadeParaTupla(Questao questao, bool temId)
        {
            Dictionary<String, Object> parametros = new Dictionary<string, object>();
            parametros.Add("sintese", questao.Sintese);
            parametros.Add("enunciado", questao.Enunciado);
            parametros.Add("id_disciplina", questao.Disciplina.Id);
            parametros.Add("id_materia", questao.Materia.Id);
            parametros.Add("bimestre", questao.Bimestre);


            if (temId)
            {
                parametros.Add("id", questao.Id);
            }

            return parametros;
        }

        public List<Questao> ConsultarPorDisciplina(int idDisciplina)
        {
            return base.ConsultarLista(_carregarPorDisciplina, TuplaParaEntidade, new Dictionary<String, Object>() { { "id_disciplina", idDisciplina} });
        }

        public List<Questao> ConsultarPorMateria(int idMateria)
        {
            return base.ConsultarLista(_carregarPorMateria, TuplaParaEntidade, new Dictionary<String, Object>() { { "id_materia", idMateria } });
        }

        public List<Questao> ConsultarComFiltragem(object[] filtros)
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
                            strBuilder.Append((strBuilder.Length == 0 ? "WHERE " : " AND ") + "UPPER(q.enunciado) LIKE UPPER({0}enunciado)");
                            parametros.Add("enunciado", "%" + filtros[i] + "%");
                        }
                        break;

                    case 1:

                        if (filtros[i] != null)
                        {
                            strBuilder.Append((strBuilder.Length == 0 ? "WHERE " : " AND ") + "q.id_disciplina = {0}id_disciplina");
                            parametros.Add("id_disciplina", ((Disciplina)filtros[i]).Id);
                        }
                        break;

                    case 2:
                        if (filtros[i] != null)
                        {
                            strBuilder.Append((strBuilder.Length == 0 ? "WHERE " : " AND ") + "q.id_materia = {0}id_materia");
                            parametros.Add("id_materia", ((Materia)filtros[i]).Id);
                        }
                        break;

                    case 3:
                        if (filtros[i] != null && !filtros[i].Equals(Bimestre.INVALIDO))
                        {
                            strBuilder.Append((strBuilder.Length == 0 ? "WHERE " : " AND ") + "bimestre = {0}bimestre");
                            parametros.Add("bimestre", filtros[i]);
                        }
                        break;
                }
            }
            return ConsultarLista(string.Format(_carregarTodosFiltragem, strBuilder.ToString()), TuplaParaEntidadeComJoin, parametros);
        }

        private static Func<IDataReader, Questao> TuplaParaEntidade = reader =>
          new Questao()
          {
              Id = Convert.ToInt32(reader["id"]),
              Sintese = Convert.ToString(reader["sintese"]),
              Enunciado = Convert.ToString(reader["enunciado"]),
              Disciplina = new Disciplina() { Id = Convert.ToInt32(reader["id_disciplina"])},
              Materia = new Materia() { Id = Convert.ToInt32(reader["id_materia"]) },
              Bimestre = BimestreUtil.ObterBimestre(Convert.ToInt32(reader["bimestre"])),
              Alternativas = ((IAlternativaRepositorio) RepositorioIoC.Alternativa).ConsultarPorQuestao(Convert.ToInt32(reader["id"]))
          };

        private static Func<IDataReader, Questao> TuplaParaEntidadeComJoin = reader =>
          new Questao()
          {
              Id = Convert.ToInt32(reader["id"]),
              Sintese = Convert.ToString(reader["sintese"]),
              Enunciado = Convert.ToString(reader["enunciado"]),
              Disciplina = new Disciplina()
              {
                  Id = Convert.ToInt32(reader["id_disciplina"]),
                  Nome = Convert.ToString(reader["disciplina_nome"])
              },
              Materia = new Materia()
              {
                  Id = Convert.ToInt32(reader["id_materia"]),
                  Nome = Convert.ToString(reader["materia_nome"]),
                  Disciplina = new Disciplina()
                  {
                      Id = Convert.ToInt32(reader["id_disciplina"]),
                      Nome = Convert.ToString(reader["disciplina_nome"])
                  },
                  Serie = new Serie()
                  {
                      Id = Convert.ToInt32(reader["id_serie"]),
                      Numero = Convert.ToInt32(reader["serie_numero"])
                  }
              },
              Bimestre = BimestreUtil.ObterBimestre(Convert.ToInt32(reader["bimestre"])),
              Alternativas = ((IAlternativaRepositorio)RepositorioIoC.Alternativa).ConsultarPorQuestao(Convert.ToInt32(reader["id"]))


          };
    }
}
