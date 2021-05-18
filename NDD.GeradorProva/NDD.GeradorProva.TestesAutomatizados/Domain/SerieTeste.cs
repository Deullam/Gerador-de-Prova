using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.Infra;

namespace NDD.GeradorProva.Teste.Domain
{
    [TestClass()]
    public class SerieTeste
    {
        Serie serie;

        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "Número não pode ser Vazio")]
        public void SerieValidacaoNumeroMenor1()
        {
            Serie serie = new Serie();
            serie.Numero = 0;
            serie.Validar();
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "Número não pode ser maior que nove")]
        public void SerieValidacaoNumeroMaior9()
        {
            Serie serie = new Serie();
            serie.Numero = 10;
            serie.Validar();
            Assert.Fail();
        }

        [TestMethod()]
        public void SerieValidacaoSucesso()
        {
            serie = new Serie();
            serie.Numero = 1;
            serie.Validar();
            serie.Numero = 2;
            serie.Validar();
            serie.Numero = 3;
            serie.Validar();
            serie.Numero = 4;
            serie.Validar();
            serie.Numero = 5;
            serie.Validar();
            serie.Numero = 6;
            serie.Validar();
            serie.Numero = 7;
            serie.Validar();
            serie.Numero = 8;
            serie.Validar();
            serie.Numero = 9;
            serie.Validar();
        }


    }
}