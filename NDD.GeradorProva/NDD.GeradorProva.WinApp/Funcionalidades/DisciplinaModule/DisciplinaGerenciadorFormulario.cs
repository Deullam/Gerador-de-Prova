using System;
using NDD.GeradorProva.Application;
using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.WinApp.Funcionalidades.MateriaModule;
using NDD.GeradorProva.WinApp.Funcionalidades.QuestaoModule;
using NDD.GeradorProva.WinApp.Funcionalidades.TesteModule;
using NDD.GeradorProva.WinApp.Nucleo;
using NDD.GeradorProva.WinApp.Nucleo.CadastroDialog;
using NDD.GeradorProva.WinApp.Nucleo.ControleUsuario;

namespace NDD.GeradorProva.WinApp.Funcionalidades.DisciplinaModule
{
    public class DisciplinaGerenciadorFormulario : GerenciadorFormulario<Disciplina, DisciplinaGerenciadorFormulario>
    {

        private DisciplinaGerenciadorFormulario()
        {

        }
        
        public override CadastroBasicoDialog<Disciplina> ObterDialogoCadastro()
        {
            return new DisciplinaCadastroDialog();
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

        public override FiltroBasicoControleUsuario<Disciplina> ObterFiltro()
        {
            if (_filtroBasico == null)
            {
                _filtroBasico =  new DisciplinaFiltroControleUsuario();
            }
            return _filtroBasico;
        }

        public override Servico<Disciplina> ObterServico()
        {
            if (_servico == null)
                _servico = new DisciplinaServico(MateriaGerenciadorFormulario.Instancia.ObterServico() as MateriaServico,
                                        QuestaoGerenciadorFormulario.Instancia.ObterServico() as QuestaoServico,
                                        TesteGerenciadorFormulario.Instancia.ObterServico() as TesteServico);
            return _servico;
        }

        public override string ObterTitulo()
        {
            return "Cadastro de disciplina";
        }

        public override TituloBotao ObterTituloBotao()
        {
            return new TituloBotao()
            {
                Adicionar = "Adicionar disciplina",
                Atualizar = "Atualizar disciplina",
                Excluir = "Excluir disciplina",
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
