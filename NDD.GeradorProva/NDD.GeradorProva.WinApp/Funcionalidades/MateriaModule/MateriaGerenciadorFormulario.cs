using NDD.GeradorProva.WinApp.Nucleo;
using System.Collections.Generic;
using NDD.GeradorProva.Application;
using NDD.GeradorProva.WinApp.Nucleo.CadastroDialog;
using NDD.GeradorProva.WinApp.Funcionalidades.SerieModule;
using NDD.GeradorProva.WinApp.Funcionalidades.DisciplinaModule;
using NDD.GeradorProva.WinApp.Funcionalidades.TesteModule;
using NDD.GeradorProva.WinApp.Funcionalidades.QuestaoModule;
using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.WinApp.Nucleo.ControleUsuario;
using System;

namespace NDD.GeradorProva.WinApp.Funcionalidades.MateriaModule
{
    public class MateriaGerenciadorFormulario : GerenciadorFormulario<Materia, MateriaGerenciadorFormulario>
    {
        
        private MateriaGerenciadorFormulario()
        {

        }
        
        public override CadastroBasicoDialog<Materia> ObterDialogoCadastro()
        {
            IList<Serie> series = SerieGerenciadorFormulario.Instancia.ObterServico().BuscarTodos();
            IList<Disciplina> disciplinas = DisciplinaGerenciadorFormulario.Instancia.ObterServico().BuscarTodos();
            return new MateriaCadastroDialog(disciplinas, series);
        }

        public override EstadoBotao ObterEstadoBotao()
        {
            return new EstadoBotao()
            {
                Adicionar = true,
                Atualizar = true,
                Excluir = true,
                ExportarPDF = false
            };
        }

        public override FiltroBasicoControleUsuario<Materia> ObterFiltro()
        {
            if (_filtroBasico == null)
            {
                _filtroBasico = new MateriaFiltroControleUsuario();
            }
            return _filtroBasico;
        }

        public override Servico<Materia> ObterServico()
        {
            if (_servico == null)
                _servico = new MateriaServico(QuestaoGerenciadorFormulario.Instancia.ObterServico() as QuestaoServico,
                                        TesteGerenciadorFormulario.Instancia.ObterServico() as TesteServico);
            return _servico;
        }

        public override string ObterTitulo()
        {
            return "Cadastro de Matéria";
        }

        public override TituloBotao ObterTituloBotao()
        {
            return new TituloBotao()
            {
                Adicionar = "Adicionar Matéria",
                Atualizar = "Atualizar Matéria",
                Excluir = "Excluir Matéria",
                ExportarPDF = ""
            };
        }

        public override VisibilidadeBotao ObterVisibilidadeBotao()
        {
            return new VisibilidadeBotao()
            {
                Adicionar = true,
                Atualizar = true,
                Excluir = true,
                ExportarPDF = false
            };
        }

    }
}

