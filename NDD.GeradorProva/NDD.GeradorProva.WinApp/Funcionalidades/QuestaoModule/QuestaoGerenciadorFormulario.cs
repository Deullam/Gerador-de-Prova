using NDD.GeradorProva.Domain;
using NDD.GeradorProva.WinApp.Nucleo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NDD.GeradorProva.Application;
using NDD.GeradorProva.WinApp.Nucleo.CadastroDialog;
using NDD.GeradorProva.WinApp.Nucleo.ControleUsuario;
using NDD.GeradorProva.WinApp.Funcionalidades.MateriaModule;
using NDD.GeradorProva.WinApp.Funcionalidades.DisciplinaModule;
using NDD.GeradorProva.Domain.Entidades;
using System.Windows.Forms;

namespace NDD.GeradorProva.WinApp.Funcionalidades.QuestaoModule
{
    public class QuestaoGerenciadorFormulario : GerenciadorFormulario<Questao, QuestaoGerenciadorFormulario>
    {
        
        private QuestaoGerenciadorFormulario()
        {

        }
        
        public override CadastroBasicoDialog<Questao> ObterDialogoCadastro()
        {
            return new QuestaoCadastroDialog(DisciplinaGerenciadorFormulario.Instancia.ObterServico().BuscarTodos());
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

        public override FiltroBasicoControleUsuario<Questao> ObterFiltro()
        {
            if (_filtroBasico == null)
            {
                _filtroBasico = new QuestaoFiltroControleUsuario();
            }
            return _filtroBasico;
        }

        public override Servico<Questao> ObterServico()
        {
            if (_servico == null)
                _servico = new QuestaoServico();

            return _servico;
        }

        public override string ObterTitulo()
        {
            return "Cadastro de questão";
        }

        public override TituloBotao ObterTituloBotao()
        {
            return new TituloBotao()
            {
                Adicionar = "Adicionar questão",
                Atualizar = "Atualizar questão",
                Excluir = "Excluir questão",
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

        public override void ExportarPDF()
        {
            CadastroBasicoDialog<Questao> dialog = ObterDialogoCadastro();
            SaveFileDialog dialogFile = new SaveFileDialog();
            dialogFile.Filter = "PDF(*.pdf)|*.pdf";
            dialogFile.Title = "Salvar Questões";
            dialogFile.ShowDialog();

            if (!string.IsNullOrEmpty(dialogFile.FileName))
            {
                List<Questao> Entidades = _servico.BuscarTodos();

                try
                {
                    _servico.GerarPDF(Entidades, dialogFile.FileName);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Arquivo aberto por outro processo ou sem permissão de acesso ao diretório.");
                }

            }

        }
    }
}
