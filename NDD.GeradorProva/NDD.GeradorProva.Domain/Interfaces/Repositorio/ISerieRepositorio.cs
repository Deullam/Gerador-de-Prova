using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.Domain.Interfaces.Repositorio;
using System.Collections.Generic;

namespace NDD.GeradorProva.Domain.Interfaces.Repositorio
{
	public interface ISerieRepositorio : IRepositorio<Serie>
    {
		List<Serie> ConsultarPorNumero(int numero);

		List<Serie> ConsultarPorNumeroEId(int numero, int id);
	}
}
