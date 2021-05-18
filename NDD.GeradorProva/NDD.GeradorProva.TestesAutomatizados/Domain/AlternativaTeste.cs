using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.Infra;
using System.Collections.Generic;

namespace Domain.Teste
{
    [TestClass()]
    public class AlternativaTeste
    {

        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "Descrição não pode ser nula")]
        public void AlternativaValidacaoDescricaoNula()
        {
            Alternativa alternativa = new Alternativa();
            alternativa.Descricao = null;
            alternativa.Validar();

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "Descrição não pode ser vazia")]
        public void AlternativaValidacaoDescricaoVazia()
        {
            Alternativa alternativa = new Alternativa();
            alternativa.Descricao = "";
            alternativa.Validar();

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "Descrição não pode ser menor que 1 caracter")]
        public void AlternativaValidacaoComprimentoDescricaoMenor1()
        {
            Alternativa descricao = new Alternativa();
            descricao.Descricao = "";
            descricao.Validar();

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "Descrição não pode ser maior que 50 caracteres")]
        public void AlternativaValidacaoComprimentoDescricaoMaior50()
        {
            Alternativa alternativa = new Alternativa();
            alternativa.Descricao = "asdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasd";
            alternativa.Validar();

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "Descrição não pode ser duplicada em uma mesma questão")]
        public void AlternativaValidacaoDescricaoDuplicada()
        {
            Alternativa alternativa = new Alternativa();
            alternativa.Descricao = "teste";
            alternativa.Id = 1;
            alternativa.ValidarUnicidadeNome(new List<Alternativa>() { new Alternativa() { Descricao = "teste" } });

            Assert.Fail();
        }
        
        [TestMethod()]
        public void AlternativaValidacaoSucessoDescricaoDuplicada()
        {
            Alternativa alternativa = new Alternativa();
            alternativa.Descricao = "teste1";
            alternativa.Id = 1;
            alternativa.ValidarUnicidadeNome(new List<Alternativa>() { new Alternativa() { Descricao = "teste" } });
        }

        [TestMethod()]
        public void AlternaticaValidacaoSucesso1()
        {
            Alternativa alternativa = new Alternativa();
            alternativa.Descricao = "1";
            alternativa.Correta = true;
            alternativa.Validar();
        }

        [TestMethod()]
        public void AlternaticaValidacaoSucesso2()
        {
            Alternativa alternativa = new Alternativa();
            alternativa.Descricao = "asdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdas";
            alternativa.Correta = false;
            alternativa.Validar();
        }

    }
}