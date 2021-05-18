using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.Infra;
using System;

namespace NDD.GeradorProva.Domain.Tests
{
    [TestClass()]
    public class TesteTestes
    {
        [TestMethod()]
        public void TesteValidacaoTesteOk()
        {
            Entidades.Teste teste = new Entidades.Teste()
            {
                Titulo = "Medindo a Febre",
                QuantidadeQuestoes = 30,
                DataGeracao = DateTime.Now,
                Materia = new Materia(),
                Disciplina = new Disciplina()
            };
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "O campo titulo esta vazio.")]
        public void TesteValidaocaoTituloVazio()
        {
            Entidades.Teste teste = new Entidades.Teste()
            {
                Titulo = "",
                QuantidadeQuestoes = 5,
                DataGeracao = DateTime.Now,
                Materia = new Materia(),
                Disciplina = new Disciplina()
            };
            teste.Validar();
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "O campo titulo esta nulo")]
        public void TesteVAlidacaoTituloNull()
        {
            Entidades.Teste teste = new Entidades.Teste()
            {
                Titulo = null,
                QuantidadeQuestoes = 5,
                DataGeracao = DateTime.Now,
                Materia = new Materia(),
                Disciplina = new Disciplina()
            };
            teste.Validar();
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "O campo titulo contem menos de cinco caracteres.")]
        public void TesteValidacaoTituloMenorQueCinco()
        {
            Entidades.Teste teste = new Entidades.Teste()
            {
                Titulo = "AAAA",
                QuantidadeQuestoes = 5,
                DataGeracao = DateTime.Now,
                Materia = new Materia(),
                Disciplina = new Disciplina()
            };
            teste.Validar();
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "O campo titulo contem mais de 50 caracteres.")]
        public void TesteValidacaoTituloMaiorQueCinquenta()
        {
            Entidades.Teste teste = new Entidades.Teste()
            {
                Titulo = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAa",
                QuantidadeQuestoes = 5,
                DataGeracao = DateTime.Now,
                Materia = new Materia(),
                Disciplina = new Disciplina()
            };
            teste.Validar();
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "O campo QuantidadeQuestoes está menor que 1.")]
        public void TesteValidacaoNumeroQuestoesMenorQueUm()
        {
            Entidades.Teste teste = new Entidades.Teste()
            {
                Titulo = "Teste de Matemática",
                QuantidadeQuestoes = 0,
                DataGeracao = DateTime.Now,
                Materia = new Materia(),
                Disciplina = new Disciplina()
            };
            teste.Validar();
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "O campo QuantidadeQUestoes está maior que 30.")]
        public void TesteValidacaoNumeroQuestoesMaiorQueTrinta()
        {
            Entidades.Teste teste = new Entidades.Teste()
            {
                Titulo = "Teste de Português",
                QuantidadeQuestoes = 35,
                DataGeracao = DateTime.Now,
                Materia = new Materia(),
                Disciplina = new Disciplina()
            };
            teste.Validar();
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "O campo disciplina está nulo.")]
        public void TesteValidacaoDisciplinaNula()
        {
            Entidades.Teste teste = new Entidades.Teste()
            {
                Titulo = "Teste de História",
                QuantidadeQuestoes = 25,
                DataGeracao = DateTime.Now,
                Materia = new Materia(),
                Disciplina = null
            };
            teste.Validar();
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "O campo materia está nulo.")]
        public void TesteValidacaoMateriaNula()
        {
            Entidades.Teste teste = new Entidades.Teste()
            {
                Titulo = "Teste de Geografia",
                QuantidadeQuestoes = 12,
                DataGeracao = DateTime.Now,
                Materia = null,
                Disciplina = new Disciplina()
            };
            teste.Validar();
            Assert.Fail();
        }
    }
}