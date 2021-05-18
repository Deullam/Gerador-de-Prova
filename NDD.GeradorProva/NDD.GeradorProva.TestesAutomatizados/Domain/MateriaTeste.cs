using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.Infra;

namespace NDD.GeradorProva.Teste.Domain
{
    [TestClass()]
    public class MateriaTeste
    {
        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "O campo nome esta vazio")]
        public void MateriaValidacaoNomeVazio()
        {
            Materia materia = new Materia()
            {
                Nome = "",
                Serie = new Serie(),
                Disciplina = new Disciplina()
            };
            materia.Validar();
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "O campo nome esta nulo")]
        public void MateriaValidacaoNomeNulo()
        {
            Materia materia = new Materia()
            {
                Nome = null,
                Serie = new Serie(),
                Disciplina = new Disciplina()
            };
            materia.Validar();
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "O nome tem menos que 5 caracteres")]
        public void MateriaValidacaoComprimentoNomeMenor5()
        {
            Materia materia = new Materia()
            {
                Nome = "abcd",
                Serie = new Serie(),
                Disciplina = new Disciplina()
            };
            materia.Validar();
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "O nome tem mais que 50 caracteres")]
        public void MateriaValidacaoComprimentoNomeMaior50()
        {
            Materia materia = new Materia()
            {
                Nome = "abcdfghijklmnopqrstuvxwzabcdfghijklmnopqrstuvxwzabc",
                Serie = new Serie(),
                Disciplina = new Disciplina()
            };
            materia.Validar();
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "O nome tem caracteres especiais")]
        public void MateriaValidacaoNomePossuiCaracteresEspeciais()
        {
            Materia materia = new Materia()
            {
                Nome = "@!#$%",
                Serie = new Serie(),
                Disciplina = new Disciplina()
            };
            materia.Validar();
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "O nome tem números")]
        public void MateriaValidacaoNomePossuiNumeros()
        {
            Materia materia = new Materia()
            {
                Nome = "Materia12",
                Serie = new Serie(),
                Disciplina = new Disciplina()
            };
            materia.Validar();
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "O nome tem espaços em sequencia")]
        public void MateriaValidacaoNomePossuiEspacosEmSequencia()
        {
            Materia materia = new Materia()
            {
                Nome = "Camila  ",
                Serie = new Serie(),
                Disciplina = new Disciplina()
            };
            materia.Validar();
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "A disciplina nula")]
        public void MateriaValidacaoDisciplinaNula()
        {
            Materia materia = new Materia()
            {
                Nome = "Camila",
                Serie = new Serie(),
                Disciplina = null
            };
            materia.Validar();
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "A serie nula")]
        public void MateriaValidacaoSerieNula()
        {
            Materia materia = new Materia()
            {
                Nome = "Camila",
                Serie = null,
                Disciplina = new Disciplina()
            };
            materia.Validar();
            Assert.Fail();
        }

        [TestMethod()]
        public void MateriaValidacaoSucesso1()
        {
            Materia materia = new Materia()
            {
                Nome = "abcde",
                Serie = new Serie(),
                Disciplina = new Disciplina()
            };
            materia.Validar();
        }

        [TestMethod()]
        public void MateriaValidacaoSucesso2()
        {
            Materia materia = new Materia()
            {
                Nome = "Abçdfghijklmnópqrstùvxwzáb dfghijklmnÔPqrstõvxwz",
                Serie = new Serie(),
                Disciplina = new Disciplina()
            };
            materia.Validar();
        }

    }
}