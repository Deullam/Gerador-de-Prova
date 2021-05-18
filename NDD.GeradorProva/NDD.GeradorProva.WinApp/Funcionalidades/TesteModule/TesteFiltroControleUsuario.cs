using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.WinApp.Nucleo.ControleUsuario;
using NDD.GeradorProva.Infra;
using NDD.GeradorProva.WinApp.Util;
using NDD.GeradorProva.Infra.Uit;
using NDD.GeradorProva.WinApp.Funcionalidades.DisciplinaModule;
using NDD.GeradorProva.WinApp.Funcionalidades.MateriaModule;
using NDD.GeradorProva.Application;

namespace NDD.GeradorProva.WinApp.Funcionalidades.TesteModule
{
    public partial class TesteFiltroControleUsuario : FiltroBasicoControleUsuario<Teste>
    {
        public TesteFiltroControleUsuario() : base(TesteGerenciadorFormulario.Instancia.ObterServico(), TesteGerenciadorFormulario.Instancia.ObterLista())
        {
            InitializeComponent();
        }

        public override void AtualizarDados()
        {
            try
            {
                ValidarFiltros();
                base.AtualizarDados();

                txtTitulo.AlterarValidade(true);
                cmbDisciplina.AlterarValidade(true);
                cmbMateria.AlterarValidade(true);
                dtpDataGeracao.AlterarValidade(true);
            }
            catch (ValidacaoExcecao e)
            {
                txtTitulo.AlterarValidade(!e.Campos.Contains("Titulo"));
                cmbDisciplina.AlterarValidade(!e.Campos.Contains("Disciplina"));
                cmbMateria.AlterarValidade(!e.Campos.Contains("Materia"));
                dtpDataGeracao.AlterarValidade(!e.Campos.Contains("DataGeracao"));

                MessageBox.Show(e.Message);
            }

        }

        public override void LimparFiltros()
        {
            txtTitulo.Clear();
            cmbDisciplina.SelectedIndex = -1;
            cmbMateria.SelectedIndex = -1;
            dtpDataGeracao.Value = DateTime.Now.Date;
            cmbMateria.Items.Clear();
            cmbMateria.Enabled = false;
            txtTitulo.AlterarValidade(true);
            cmbDisciplina.AlterarValidade(true);
            cmbMateria.AlterarValidade(true);
            dtpDataGeracao.AlterarValidade(true);

            dtpDataGeracao.CustomFormat = " ";
            PopularComboBox();
        }

        public override object[] ObterFiltros()
        {
            return new object[]
                {
                    txtTitulo.Text,
                    cmbDisciplina.SelectedItem,
                    cmbMateria.SelectedItem,
                    (string.IsNullOrWhiteSpace(dtpDataGeracao.CustomFormat) ? (DateTime?) null : dtpDataGeracao.Value)
                };
        }

        public override void ValidarFiltros()
        {
            List<string> camposInvalidos = new List<string>();
            string mensagem = "";

            if (!string.IsNullOrEmpty(txtTitulo.Text) &&
                    !RegexUtil.PerteceAoPadrao(txtTitulo.Text, @"^[A-Za-z0-9 ZéúíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËYÜÏÖÄçÇ]+$"))
            {
                mensagem += "O título deve conter apenas letras, números e espaços.\n";
                camposInvalidos.Add("Titulo");
            }

            if (dtpDataGeracao.Value.CompareTo(DateTime.Now) > 0)
            {
                mensagem += "A data de geração não pode ser superior a atual.\n";
                camposInvalidos.Add("DataGeracao");
            }

            if (camposInvalidos.Count > 0)
            {
                throw new ValidacaoExcecao(mensagem, camposInvalidos);
            }
        }

        private void PopularComboBox()
        {
            cmbDisciplina.Items.Clear();
            cmbDisciplina.Items.AddRange(DisciplinaGerenciadorFormulario.Instancia.ObterServico().BuscarTodos().ToArray());
            cmbMateria.Items.Clear();
        }

        private IList<Materia> BuscarMateriaPorDisciplina(Disciplina disciplina)
        {
            return ((MateriaServico)MateriaGerenciadorFormulario.Instancia.ObterServico()).CarregarPorDisciplina(disciplina.Id);
        }

        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMateria.Enabled = true;

            Disciplina disciplina = cmbDisciplina.SelectedItem as Disciplina;
            if (disciplina == null)
            {
                return;
            }
            IList<Materia> materias = BuscarMateriaPorDisciplina(disciplina);

            cmbMateria.Items.Clear();

            cmbMateria.Items.AddRange(materias.ToArray());
        }

        private void dtpDataGeracao_ValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(dtpDataGeracao.CustomFormat))
            {
                dtpDataGeracao.CustomFormat = "dd/MM/yyyy";
            }
        }
    }
}
