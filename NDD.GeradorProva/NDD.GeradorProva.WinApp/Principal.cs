using NDD.GeradorProva.WinApp.Funcionalidades.DisciplinaModule;
using NDD.GeradorProva.WinApp.Funcionalidades.MateriaModule;
using NDD.GeradorProva.WinApp.Funcionalidades.QuestaoModule;
using NDD.GeradorProva.WinApp.Funcionalidades.SerieModule;
using NDD.GeradorProva.WinApp.Funcionalidades.TesteModule;
using NDD.GeradorProva.WinApp.Nucleo;
using System;
using System.Windows.Forms;

namespace NDD.GeradorProva.WinApp
{
    public partial class Principal : Form
    {
        private dynamic _manager;
        public Principal()
        {
            InitializeComponent();
        }

        private void disciplinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getCadastre(DisciplinaGerenciadorFormulario.Instancia);
        }

        private void getCadastre(dynamic manager)
        {
            exportarToolStripMenuItem.Visible = true;
            _manager = manager;

            labelTitle.Text = _manager.ObterTitulo();

            dynamic listagem = _manager.ObterLista();
            dynamic filtro = _manager.ObterFiltro();

            filtro.LimparFiltros();
            filtro.AtualizarDados();

            TituloBotao buttonsTitle = _manager.ObterTituloBotao();
            VisibilidadeBotao buttonsVisibility = _manager.ObterVisibilidadeBotao();
            EstadoBotao buttonsStatus = _manager.ObterEstadoBotao();

            AdjustDisplayedButton(btnIncluir, buttonsTitle.Adicionar, buttonsStatus.Adicionar, buttonsVisibility.Adicionar);
            AdjustDisplayedButton(btnAlterar, buttonsTitle.Atualizar, buttonsStatus.Atualizar, buttonsVisibility.Atualizar);
            AdjustDisplayedButton(btnExcluir, buttonsTitle.Excluir, buttonsStatus.Excluir, buttonsVisibility.Excluir);
            AdjustDisplayedButton(btnExportarPDF, buttonsTitle.ExportarPDF, buttonsStatus.ExportarPDF, buttonsVisibility.ExportarPDF);

            filtro.Dock = DockStyle.Top;
            listagem.Dock = DockStyle.Fill;

            pnlPrincipal.Controls.Clear();

            pnlPrincipal.Controls.Add(listagem);
            pnlPrincipal.Controls.Add(filtro);
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }
        private void AdjustDisplayedButton(ToolStripButton button, string title, bool enabled, bool visible)
        {
            button.Text = title;
            button.Enabled = enabled;
            button.Visible = visible;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            this._manager.Adicionar();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            this._manager.Atualizar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            this._manager.Excluir();
        }

        private void menuItemSerie_Click(object sender, EventArgs e)
        {
            getCadastre(SerieGerenciadorFormulario.Instancia);
        }

        private void matériaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getCadastre(MateriaGerenciadorFormulario.Instancia);
        }

        private void questaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getCadastre(QuestaoGerenciadorFormulario.Instancia);
        }

        private void testeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getCadastre(TesteGerenciadorFormulario.Instancia);
        }

        //não é mais chamado
        private void toolStripButtonExportarPDF_Click(object sender, EventArgs e)
        {
            this._manager.ExportarParaPDF();
        }

        private void exportarPDFMenuItem_Click(object sender, EventArgs e)
        {
            _manager.ExportarPDF();

        }

        private void exportarXMLMenuItem_Click(object sender, EventArgs e)
        {
            _manager.ExportarXML();

        }

        private void exportarCSVMenuItem_Click(object sender, EventArgs e)
        {
            _manager.ExportarCSV();

        }
    }
}
