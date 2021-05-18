using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NDD.GeradorProva.Application;
using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.Domain.Interfaces.Repositorio;
using NDD.GeradorProva.Infra;
using NDD.GeradorProva.Infra.Data.Nucleo;
using System.Collections.Generic;
using System.Linq;

namespace NDD.GeradorProva.Teste.Application
{
    [TestClass()]
    public class MateriaServicoTeste
    {
        [TestMethod()]
        [ExpectedException(typeof(ValidacaoExcecao), "O nome está duplicado")]
        public void MateriaServicoValidacaoInsercaoNomeDuplicado()
        {
            Mock<IMateriaRepositorio> mock = new Mock<IMateriaRepositorio>();
            mock.Setup(m => m.ConsultarPorNomeEId("abcde", 0)).Returns(new List<Materia>(){ new Materia() { Id = 1, Nome = "abcde" } });

            RepositorioTesteIoC.Materia = mock.Object;

            MateriaServico servico = new MateriaServico(RepositorioTesteIoC.Materia);

            servico.ValidarExistenciaNome("abcde", 0);

        }

        [TestMethod()]
        public void MateriaServicoValidacaoBuscarPorNome()
        {
            Mock<IMateriaRepositorio> mock = new Mock<IMateriaRepositorio>();
            mock.Setup(m => m.ConsultarPorNome("abcde")).Returns(new List<Materia>() { new Materia() { Id = 1, Nome = "abcde" } });

            RepositorioTesteIoC.Materia = mock.Object;

            MateriaServico servico = new MateriaServico(RepositorioTesteIoC.Materia);

            
            IList<Materia> resultadoEncontrado = servico.CarregarPorNome("abcde");
            IList<Materia> resultadoEsperado = new List<Materia>() { new Materia() { Id = 1, Nome = "abcde" } };
            Assert.IsTrue(Enumerable.SequenceEqual(resultadoEsperado.OrderBy(t => t), resultadoEncontrado.OrderBy(t => t))); 

        }

        [TestMethod()]
        public void MateriaServicoBuscarPorDisciplina()
        {
            Mock<IMateriaRepositorio> mock = new Mock<IMateriaRepositorio>();
            mock.Setup(m => m.ConsultarPorDisciplina(1)).Returns(new List<Materia>() { new Materia() { Disciplina = new Disciplina() { Id = 1 } } });
            RepositorioTesteIoC.Materia = mock.Object;

            MateriaServico servico = new MateriaServico(RepositorioTesteIoC.Materia);
            IList<Materia> resultadoEncontrado = servico.CarregarPorDisciplina(1);
            IList<Materia> resultadoEsperado = new List<Materia>() { new Materia() { Disciplina = new Disciplina() { Id = 1 } } };

            Assert.IsTrue(Enumerable.SequenceEqual(resultadoEsperado.OrderBy(t => t), resultadoEncontrado.OrderBy(t => t)));

        }

        [TestMethod()]
        public void MateriaServicoConsultarPorSerie()
        {
            Mock<IMateriaRepositorio> mock = new Mock<IMateriaRepositorio>();
            mock.Setup(m => m.ConsultarPorSerie(1)).Returns(new List<Materia>() { new Materia() { Serie = new Serie() { Id = 1 } } });
            RepositorioTesteIoC.Materia = mock.Object;

            MateriaServico servico = new MateriaServico(RepositorioTesteIoC.Materia);
            IList<Materia> resultadoEncontrado = servico.CarregarPorSerie(1);
            IList<Materia> resultadoEsperado = new List<Materia>() { new Materia() { Serie = new Serie() { Id = 1 } } };

            Assert.IsTrue(Enumerable.SequenceEqual(resultadoEsperado.OrderBy(t => t), resultadoEncontrado.OrderBy(t => t)));
        }

        [TestMethod()]
        public void MateriaServicoConsultarPorDisciplinaDiferente()
        {
            Mock<IMateriaRepositorio> mock = new Mock<IMateriaRepositorio>();
            mock.Setup(m => m.ConsultarPorDisciplina(2)).Returns(new List<Materia>() { new Materia() { Disciplina = new Disciplina() { Id = 2 } } });
            RepositorioTesteIoC.Materia = mock.Object;

            MateriaServico servico = new MateriaServico(RepositorioTesteIoC.Materia);
            IList<Materia> resultadoEncontrado = servico.CarregarPorDisciplina(3);
            IList<Materia> resultadoEsperado = new List<Materia>() { new Materia() { Disciplina = new Disciplina() { Id = 2 } } };

            Assert.IsFalse(resultadoEncontrado != null && resultadoEsperado.Contains(resultadoEncontrado[0]));
        }

        [TestMethod()]
        public void MateriaServicoConsultarPorSerieDiferente()
        {
            Mock<IMateriaRepositorio> mock = new Mock<IMateriaRepositorio>();
            mock.Setup(m => m.ConsultarPorSerie(2)).Returns(new List<Materia>() { new Materia() { Serie = new Serie() { Id = 2 } } });
            RepositorioTesteIoC.Materia = mock.Object;

            MateriaServico servico = new MateriaServico(RepositorioTesteIoC.Materia);
            IList<Materia> resultadoEncontrado = servico.CarregarPorSerie(3);
            IList<Materia> resultadoEsperado = new List<Materia>() { new Materia() { Serie = new Serie() { Id = 2 } } };

            Assert.IsFalse(resultadoEncontrado != null && resultadoEsperado.Contains(resultadoEncontrado[0]));
        }

    }
    //Materia materia = new Materia()
    //{
    //    Nome = "abcdwe",
    //    Bimestre = Bimestre.PRIMEIRO,
    //    Serie = new Serie(),
    //    Disciplina = new Disciplina()
    //};
}