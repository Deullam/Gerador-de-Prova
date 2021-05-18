using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.Domain.Interfaces.Repositorio;
using NDD.GeradorProva.Infra.Data.Nucleo;
using NDD.GeradorProva.Infra.Data.Util;
using System;
using System.Collections.Generic;

namespace NDD.GeradorProva.Infra.Data.RepositorioSQL
{
    public class TesteQuestaoRepositorioSQL : RepositorioSQL<Entidade>, ITesteQuestao
    {
        #region Scripts
        private readonly string _inserir =
                          @"INSERT INTO teste_questao
                               (id_teste ,id_questao)
                            VALUES 
                                ({0}id_teste ,{0}id_questao)";


        private readonly string _carregarPorTeste =
                          @"SELECT 
                              *
                            FROM teste_questao
                            WHERE id_teste = {0}id_teste";

        private readonly string _carregarPorQuestao =
                          @"SELECT 
                              *
                            FROM teste_questao
                            WHERE id_questao = {0}id_questao";


        #endregion Scripts
        public TesteQuestaoRepositorioSQL(TipoBancoDeDados tipo) : base(tipo)
        {
        }

        public void Adicionar(Teste teste, Questao questao)
        {
            base.ExecutarAtualizacao(_inserir, EntidadeParaTupla(teste, questao));
        }

        public List<Questao> ConsultarPorQuestao(int id)
        {
            var list = new List<Questao>();

            using (Conexao)
            {
                using (Comando)
                {
                    Conexao.ConnectionString = ConexaoBDFactory.ObterStringDeConexao(Tipo).ConnectionString;

                    Comando.Parameters.Clear();
                    Comando.Connection = Conexao;
                    Comando.CommandText = _carregarPorQuestao.FormatarSQL(Tipo);

                    Conexao.Open();

                    Comando.AdicionarParametros(new Dictionary<string, object>() { { "id_questao" , id } });

                    Leitor = Comando.ExecuteReader();

                    while (Leitor.Read())
                    {
                        list.Add(RepositorioIoC.Questao.ConsultarPorId(Convert.ToInt32(Leitor["id_questao"])));
                    }
                }
            }
            return list;
        }

        public List<Questao> ConsultarPorTeste(int id)
        {
            var list = new List<Questao>();

            using (Conexao)
            {
                using (Comando)
                {
                    Conexao.ConnectionString = ConexaoBDFactory.ObterStringDeConexao(Tipo).ConnectionString;

                    Comando.Parameters.Clear();
                    Comando.Connection = Conexao;
                    Comando.CommandText = _carregarPorTeste.FormatarSQL(Tipo);

                    Conexao.Open();

                    Comando.AdicionarParametros(new Dictionary<string, object>() { { "id_teste", id } });

                    Leitor = Comando.ExecuteReader();

                    while (Leitor.Read())
                    {
                        list.Add(RepositorioIoC.Questao.ConsultarPorId(Convert.ToInt32(Leitor["id_questao"])));
                    }
                }
            }
            return list;
        }

        public Dictionary<String, Object> EntidadeParaTupla(Teste teste, Questao questao)
        {
            Dictionary<String, Object> parametros = new Dictionary<string, object>();
            parametros.Add("id_teste", teste.Id);
            parametros.Add("id_questao", questao.Id);
            return parametros;
        }
    }
}
