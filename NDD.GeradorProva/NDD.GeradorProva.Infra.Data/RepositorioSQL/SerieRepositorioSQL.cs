using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.Domain.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace NDD.GeradorProva.Infra.Data.RepositorioSQL
{
	public class SerieRepositorioSQL : RepositorioSQL<Serie>, ISerieRepositorio
	{
		#region Scripts
		private readonly string _inserir =
						  @"INSERT INTO serie
                               (numero)
                            VALUES 
                                ({0}numero)";

		private readonly string _carregarTodos = @"SELECT * FROM serie ORDER BY numero ASC";

        private readonly string _carregarTodosFiltragem = @"SELECT * FROM serie {0} ORDER BY numero ASC";


        private readonly string _atualizar =
						   @"UPDATE serie
                           SET numero = {0}numero 
                            WHERE id = {0}id";

		private readonly string _excluir = @"DELETE FROM serie WHERE id = {0}id";

		private readonly string _carregarPorId =
						  @"SELECT 
                            *
                           FROM serie
                           WHERE id = {0}id";

		private readonly string _carregarPorNumeroEId =
						 @"SELECT 
                            *
                           FROM serie
                           WHERE numero = {0}numero
                           AND id != {0}id";

		private readonly string _carregarPorNumero =
						  @"SELECT 
                              *
                            FROM serie
                            WHERE numero = {0}numero";
		#endregion Scripts

		public SerieRepositorioSQL(TipoBancoDeDados tipo) : base(tipo)
		{
		}

		public  Serie Adicionar(Serie entidade)
		{
			entidade.Id = base.ExecutarAtualizacao(_inserir, EntidadeParaTupla(entidade, false));
			return entidade;
		}

		public  Serie Atualizar(Serie entidade)
		{
            base.ExecutarAtualizacao(_atualizar, EntidadeParaTupla(entidade, true), false);
            return entidade;
        }

		public  List<Serie> BuscarTodos()
		{
            return base.ConsultarLista(_carregarTodos, TuplaParaEntidade);
        }

		public  Serie ConsultarPorId(int id)
		{
            return base.ConsultarEntidade(_carregarPorId, TuplaParaEntidade, new Dictionary<String, Object>() { { "id", id } });
        }

        public  int Excluir(int id)
        {
            return base.Excluir(_excluir, id);
        }

        public List<Serie> ConsultarPorNumeroEId(int numero, int id)
		{
            return base.ConsultarLista(_carregarPorNumeroEId, TuplaParaEntidade, new Dictionary<String, Object>() { { "numero", numero }, { "id", id } });
        }
	
		public List<Serie> ConsultarPorNumero(int numero)
		{
            return base.ConsultarLista(_carregarPorNumero, TuplaParaEntidade, new Dictionary<String, Object>() { { "numero", numero } });
        }	

		public Dictionary<String, Object> EntidadeParaTupla(Serie serie, bool temId)
		{
			Dictionary<String, Object> parametros = new Dictionary<string, object>();
			parametros.Add("numero", serie.Numero);

			if (temId)
			{
				parametros.Add("id", serie.Id);
			}

			return parametros;
		}

        public List<Serie> ConsultarComFiltragem(object[] filtros)
        {
            Dictionary<String, Object> parametros = new Dictionary<string, object>();

            StringBuilder strBuilder = new StringBuilder();

            Console.WriteLine(filtros[0].GetType().Name);

            if (filtros[0] is decimal && (decimal) filtros[0] > 0 && (decimal)filtros[0] < 10)
            {
                strBuilder.Append((strBuilder.Length == 0 ? "WHERE " : " AND ") + "numero = {0}numero");
                parametros.Add("numero", filtros[0]);
            }

            return ConsultarLista(string.Format(_carregarTodosFiltragem, strBuilder.ToString()), TuplaParaEntidade, parametros);
        }

        private static Func<IDataReader, Serie> TuplaParaEntidade = reader =>
		  new Serie()
		  {
			  Id = Convert.ToInt32(reader["id"]),
			  Numero = Convert.ToInt32(reader["numero"])
		  };
	}
}
