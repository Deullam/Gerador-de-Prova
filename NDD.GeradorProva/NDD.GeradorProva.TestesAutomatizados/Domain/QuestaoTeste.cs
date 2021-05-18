using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.Infra;
using System.Collections.Generic;

namespace Domain.Teste
{
    [TestClass()]
    public class QuestaoTeste
    {
        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "Enunciado não pode ser nula")]
        public void QuestaoValidacaoEnunciadoNulo()
        {
            Questao questao = new Questao();
            questao.Enunciado = null;
            questao.Disciplina = new Disciplina();
            questao.Materia = new Materia();
            questao.Bimestre = Bimestre.QUARTO;
            questao.Alternativas = new List<Alternativa>()
            {
                new Alternativa() { Descricao = "1", Correta = false},
                new Alternativa() { Descricao = "1", Correta = true}
            };
            questao.Validar();

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "Enunciado não pode ser vazio")]
        public void QuestaoValidacaoEnunciadoVazio()
        {
            Questao questao = new Questao();
            questao.Enunciado = "";
            questao.Disciplina = new Disciplina();
            questao.Materia = new Materia();
            questao.Bimestre = Bimestre.TERCEIRO;
            questao.Alternativas = new List<Alternativa>()
            {
                new Alternativa() { Descricao = "1", Correta = false},
                new Alternativa() { Descricao = "1", Correta = true}
            };
            questao.Validar();

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "Enunciado não pode ser menor que 5 caracteres")]
        public void QuestaoValidacaoComprimentoEnunciadoMenor5()
        {
            Questao questao = new Questao();
            questao.Enunciado = "qwer";
            questao.Disciplina = new Disciplina();
            questao.Materia = new Materia();
            questao.Bimestre = Bimestre.SEGUNDO;
            questao.Alternativas = new List<Alternativa>()
            {
                new Alternativa() { Descricao = "1", Correta = false},
                new Alternativa() { Descricao = "1", Correta = true}
            };
            questao.Validar();

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "Enunciado não pode ser maior que 500 caracteres")]
        public void QuestaoValidacaoComprimentoEnunciadoMaior500()
        {
            Questao questao = new Questao();
            questao.Enunciado = @"asdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdas
                                        asdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdas
                                        asdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdas
                                        asdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdas
                                        asdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdas
                                        asdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdas
                                        asdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdas
                                        asdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdas
                                        asdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdas
                                        asdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasd";
            questao.Disciplina = new Disciplina();
            questao.Materia = new Materia();
            questao.Bimestre = Bimestre.PRIMEIRO;
            questao.Alternativas = new List<Alternativa>()
            {
                new Alternativa() { Descricao = "1", Correta = false},
                new Alternativa() { Descricao = "1", Correta = true}
            };
            questao.Validar();

            Assert.Fail();
        }


        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "Sintese não pode ser menor que 5 caracteres")]
        public void QuestaoValidacaoComprimentoSinteseMenor5()
        {
            Questao questao = new Questao();
            questao.Enunciado = "qwert";
            questao.Sintese = "asdd";
            questao.Disciplina = new Disciplina();
            questao.Materia = new Materia();
            questao.Bimestre = Bimestre.SEGUNDO;
            questao.Alternativas = new List<Alternativa>()
            {
                new Alternativa() { Descricao = "1", Correta = false},
                new Alternativa() { Descricao = "1", Correta = true}
            };
            questao.Validar();

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "Sintese não pode ser maior que 500 caracteres")]
        public void QuestaoValidacaoComprimentoSinteseMaior100()
        {
            Questao questao = new Questao();
            questao.Enunciado = "asdas";
            questao.Sintese = "asdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdas";
            questao.Disciplina = new Disciplina();
            questao.Materia = new Materia();
            questao.Bimestre = Bimestre.PRIMEIRO;
            questao.Alternativas = new List<Alternativa>()
            {
                new Alternativa() { Descricao = "1", Correta = false},
                new Alternativa() { Descricao = "1", Correta = true}
            };
            questao.Validar();

            Assert.Fail();
        }





        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "Disciplina não pode ser nula")]
        public void QuestaoValidacaoDisciplinaNula()
        {
            Questao questao = new Questao();
            questao.Enunciado = @"asdasdasd";
            questao.Disciplina = null;
            questao.Materia = new Materia();
            questao.Bimestre = Bimestre.PRIMEIRO;
            questao.Alternativas = new List<Alternativa>()
            {
                new Alternativa() { Descricao = "1", Correta = false},
                new Alternativa() { Descricao = "1", Correta = true}
            };
            questao.Validar();

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "Materia não pode ser nula")]
        public void QuestaoValidacaoMateriaNula()
        {
            Questao questao = new Questao();
            questao.Enunciado = @"asdasdasd";
            questao.Disciplina = new Disciplina();
            questao.Materia = null;
            questao.Bimestre = Bimestre.PRIMEIRO;
            questao.Alternativas = new List<Alternativa>()
            {
                new Alternativa() { Descricao = "1", Correta = false},
                new Alternativa() { Descricao = "1", Correta = true}
            };
            questao.Validar();

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "Bimestre não pode ser nulo")]
        public void QuestaoValidacaoBimestreNulo()
        {
            Questao questao = new Questao();
            questao.Enunciado = @"asdasdasd";
            questao.Disciplina = new Disciplina();
            questao.Materia = new Materia();
            questao.Bimestre = Bimestre.INVALIDO;
            questao.Alternativas = new List<Alternativa>()
            {
                new Alternativa() { Descricao = "1", Correta = false},
                new Alternativa() { Descricao = "1", Correta = true}
            };
            questao.Validar();

            Assert.Fail();
        }
        
        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "Alternativas não podem ser nulas")]
        public void QuestaoValidacaoAlternativasNulas()
        {
            Questao questao = new Questao();
            questao.Enunciado = @"asdasdasd";
            questao.Disciplina = new Disciplina();
            questao.Materia = new Materia();
            questao.Bimestre = Bimestre.PRIMEIRO;
            questao.Alternativas = null;
            questao.Validar();

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "A quantidade de alternativas deve ser maior que 1")]
        public void QuestaoValidacaoQuantidadeAlternativasMaiorQue1()
        {
            Questao questao = new Questao();
            questao.Enunciado = @"asdasdasd";
            questao.Disciplina = new Disciplina();
            questao.Materia = new Materia();
            questao.Bimestre = Bimestre.PRIMEIRO;
            questao.Alternativas = new List<Alternativa>()
            {
                new Alternativa() { Descricao = "1", Correta = true}
            };
            questao.Validar();

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "Quantidade de alternativas deve ser menor que 6")]
        public void QuestaoValidacaoQuantidadeAlternativasMaiorQue5()
        {
            Questao questao = new Questao();
            questao.Enunciado = @"asdasdasd";
            questao.Disciplina = new Disciplina();
            questao.Materia = new Materia();
            questao.Bimestre = Bimestre.PRIMEIRO;
            questao.Alternativas = new List<Alternativa>()
            {
                new Alternativa() { Descricao = "1", Correta = false},
                new Alternativa() { Descricao = "1", Correta = false},
                new Alternativa() { Descricao = "1", Correta = false},
                new Alternativa() { Descricao = "1", Correta = false},
                new Alternativa() { Descricao = "1", Correta = false},
                new Alternativa() { Descricao = "1", Correta = true}
            };
            questao.Validar();

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "Deve existir uma alternativa correta")]
        public void QuestaoValidacaoNenhumaAlternativaCorreta()
        {
            Questao questao = new Questao();
            questao.Enunciado = @"asdasdasd";
            questao.Disciplina = new Disciplina();
            questao.Materia = new Materia();
            questao.Bimestre = Bimestre.PRIMEIRO;
            questao.Alternativas = new List<Alternativa>()
            {
                new Alternativa() { Descricao = "1", Correta = false},
                new Alternativa() { Descricao = "1", Correta = false}
            };
            questao.Validar();

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "Deve existir somente uma alternativa correta")]
        public void QuestaoValidacaoMaisQueUmaAlternativaCorreta()
        {
            Questao questao = new Questao();
            questao.Enunciado = @"asdasdasd";
            questao.Disciplina = new Disciplina();
            questao.Materia = new Materia();
            questao.Bimestre = Bimestre.PRIMEIRO;
            questao.Alternativas = new List<Alternativa>()
            {
                new Alternativa() { Descricao = "1", Correta = true},
                new Alternativa() { Descricao = "1", Correta = true}
            };
            questao.Validar();

            Assert.Fail();
        }

        [TestMethod()]
        public void QuestaoValidacaoSucesso1()
        {
            Questao questao = new Questao();
            questao.Enunciado = @"asdas";
            questao.Disciplina = new Disciplina();
            questao.Materia = new Materia();
            questao.Bimestre = Bimestre.PRIMEIRO;
            questao.Alternativas = new List<Alternativa>()
            {
                new Alternativa() { Descricao = "1", Correta = false},
                new Alternativa() { Descricao = "1", Correta = true}
            };
            questao.Validar();
        }


        [TestMethod()]
        public void QuestaoValidacaoSucesso2()
        {
            Questao questao = new Questao();
            questao.Enunciado = @"asdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasassdfsdfsdfsdfsdfsdfsdfdasdasdasdasdasdasdasdasdasddasdasdasdasdasdasdasasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasasdasdasdasdasdasdajjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjj";
            questao.Sintese = "dasdasdas";
            questao.Disciplina = new Disciplina();
            questao.Materia = new Materia();
            questao.Bimestre = Bimestre.PRIMEIRO;
            questao.Alternativas = new List<Alternativa>()
            {
                new Alternativa() { Descricao = "1", Correta = false},
                new Alternativa() { Descricao = "1", Correta = true}
            };
            questao.Validar();
        }

    }
}