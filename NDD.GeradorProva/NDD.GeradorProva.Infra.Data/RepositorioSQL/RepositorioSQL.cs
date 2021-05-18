using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.Infra.Data.Nucleo;
using NDD.GeradorProva.Infra.Data.Util;
using System;
using System.Collections.Generic;
using System.Data;

namespace NDD.GeradorProva.Infra.Data.RepositorioSQL
{
    public abstract class RepositorioSQL<T> where T : Entidade
    {
        protected IDbConnection Conexao { get; }
        protected IDbCommand Comando { get; }
        protected IDataReader Leitor { get; set; }
        protected TipoBancoDeDados Tipo { get; set; }
    
        public RepositorioSQL(TipoBancoDeDados tipo)
        {
            this.Tipo = tipo;
            Conexao = ConexaoBDFactory.CriarConexao(tipo);
            Comando = Conexao.CreateCommand();
        }


        protected int ExecutarAtualizacao(string sql, Dictionary<string, object> parametros = null, bool carregarId = true)
        {
            int id = 0;
            using (Conexao)
            {
                using (Comando)
                {
                    Conexao.ConnectionString = ConexaoBDFactory.ObterStringDeConexao(Tipo).ConnectionString;

                    Comando.Parameters.Clear();
                    Comando.Connection = Conexao;
                    Comando.CommandText = sql.FormatarSQL(Tipo, carregarId);

                    Conexao.Open();

                    Comando.AdicionarParametros(parametros);

                    if (carregarId)
                    {
                        id = Convert.ToInt32(Comando.ExecuteScalar());
                    }
                    else
                    {
                        Comando.ExecuteNonQuery();
                    }
                }
            }

            return id;
        }

        public List<T> ConsultarLista(string sql, Func<IDataReader, T> TuplaParaEntidade, Dictionary<string, object> parametros = null)
        {
            var list = new List<T>();

            using (Conexao)
            {
                using (Comando)
                {
                    Conexao.ConnectionString = ConexaoBDFactory.ObterStringDeConexao(Tipo).ConnectionString;

                    Comando.Parameters.Clear();
                    Comando.Connection = Conexao;
                    Comando.CommandText = sql.FormatarSQL(Tipo);

                    Conexao.Open();

                    Comando.AdicionarParametros(parametros);

                    Leitor = Comando.ExecuteReader();

                    while (Leitor.Read())
                    {
                        list.Add(TuplaParaEntidade(Leitor));
                    }
                }
            }

            return list;
        }
        public T ConsultarEntidade(string sql, Func<IDataReader, T> TuplaParaEntidade, Dictionary<string, object> parametros = null)
        {
            using (Conexao)
            {
                using (Comando)
                {
                    Conexao.ConnectionString = ConexaoBDFactory.ObterStringDeConexao(Tipo).ConnectionString;

                    Comando.Parameters.Clear();
                    Comando.Connection = Conexao;
                    Comando.CommandText = sql.FormatarSQL(Tipo);

                    Conexao.Open();

                    Comando.AdicionarParametros(parametros);

                    Leitor = Comando.ExecuteReader();

                    if (Leitor.Read())
                    {
                        return TuplaParaEntidade(Leitor);
                    }
                }
            }

            return null;
        }

        public int Excluir(string sql, int id, string parameterName = "Id")
        {
            var items = 0;

            using (Conexao)
            {
                Conexao.ConnectionString = ConexaoBDFactory.ObterStringDeConexao(Tipo).ConnectionString;

                Comando.Parameters.Clear();
                Comando.Connection = Conexao;
                Comando.CommandText = sql.FormatarSQL(Tipo);

                Conexao.Open();

                var parametro = Comando.CreateParameter();
                parametro.Value = id;
                parametro.ParameterName = parameterName;
                Comando.Parameters.Add(parametro);

                items = Comando.ExecuteNonQuery();
            }


            return items;
        }

    }

}
