using NDD.GeradorProva.WinApp.Nucleo;
using NDD.GeradorProva.Application;
using NDD.GeradorProva.WinApp.Nucleo.CadastroDialog;
using NDD.GeradorProva.WinApp.Funcionalidades.MateriaModule;
using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.WinApp.Nucleo.ControleUsuario;
using System;

namespace NDD.GeradorProva.WinApp.Funcionalidades.SerieModule
{
    public class SerieGerenciadorFormulario : GerenciadorFormulario<Serie, SerieGerenciadorFormulario>
    {
        
        private SerieGerenciadorFormulario()
        {

        }
        
        public override CadastroBasicoDialog<Serie> ObterDialogoCadastro()
        {
            return new SerieCadastroDialog();
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

        public override FiltroBasicoControleUsuario<Serie> ObterFiltro()
        {
            if (_filtroBasico == null)
            {
                _filtroBasico = new SerieFiltroControleUsuario();
            }
            return _filtroBasico;
        }

        public override Servico<Serie> ObterServico()
        {
            if (_servico == null)
                _servico = new SerieServico(MateriaGerenciadorFormulario.Instancia.ObterServico() as MateriaServico);
            return _servico;
        }

        public override string ObterTitulo()
        {
            return "Cadastro de série";
        }

        public override TituloBotao ObterTituloBotao()
        {
            return new TituloBotao()
            {
                Adicionar = "Adicionar série",
                Atualizar = "Atualizar série",
                Excluir = "Excluir série",
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
