using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.Infra;

namespace NDD.GeradorProva.Teste.Domain
{
    [TestClass()]
    public class DisciplinaTeste
    {
        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao),"Nome não pode ser Maior que 25 caracteres")]
        public void DisciplinaValidacaoComprimentoNomeMenor4()
        {
            Disciplina disciplina = new Disciplina();
            disciplina.Nome = "AAAAAAAKSJDHAJKSDHJAKHDKJAHDHAKDHJAKDHKJAHDADADADADASFASDAFASDFASDF";
            disciplina.Validar();

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "Nome não pode ser Menor que 4 caracteres")]
        public void DisciplinaValidacaoComprimentoNomeMaior25()
        {
            Disciplina disciplina = new Disciplina();
            disciplina.Nome = "AAA";
            disciplina.Validar();

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "Nome não pode ser Nulo")]
        public void DisciplinaValidacaoNomeNulo()
        {
            Disciplina disciplina = new Disciplina();
            disciplina.Nome = null;
            disciplina.Validar();

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "Nome não pode ser Vazio")]
        public void DisciplinaValidacaoNomeVazio()
        {
            Disciplina disciplina = new Disciplina();
            disciplina.Nome = "";
            disciplina.Validar();

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "Nome não pode ter Caracteres Especiais")]
        public void DisciplinaValidacaoNomeComCaracteresEspeciais()
        {
            Disciplina disciplina = new Disciplina();
            disciplina.Nome = "$#$";
            disciplina.Validar();

            Assert.Fail();
        }


        [TestMethod()]
        public void DisciplinaValidacaoSucesso()
        {
            Disciplina disciplina = new Disciplina();
            disciplina.Nome = "Português";
            disciplina.Validar();
        }
        
    }
}