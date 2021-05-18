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

namespace NDD.GeradorProva.WinApp.Funcionalidades.QuestaoModule
{
    public partial class QuestaoFiltroControleUsuario : FiltroBasicoControleUsuario<Questao>
    {
        public QuestaoFiltroControleUsuario() : base(QuestaoGerenciadorFormulario.Instancia.ObterServico(), QuestaoGerenciadorFormulario.Instancia.ObterLista())
        {
            InitializeComponent();
        }


        public override void AtualizarDados()
        {
            try
            {
                ValidarFiltros();
                base.AtualizarDados();
                txtEnunciado.AlterarValidade(true);
                cmbDisciplina.AlterarValidade(true);
                cmbMateria.AlterarValidade(true);
                cmbBimestre.AlterarValidade(true);
            }
            catch (ValidacaoExcecao e)
            {
                txtEnunciado.AlterarValidade(!e.Campos.Contains("Enunciado"));
                cmbDisciplina.AlterarValidade(!e.Campos.Contains("Disciplina"));
                cmbMateria.AlterarValidade(!e.Campos.Contains("Materia"));
                cmbBimestre.AlterarValidade(!e.Campos.Contains("Bimestre"));

                MessageBox.Show(e.Message);
            }

        }

        public override void LimparFiltros()
        {
            txtEnunciado.Clear();
            cmbDisciplina.SelectedIndex = -1;
            cmbMateria.SelectedIndex = -1;
            cmbBimestre.SelectedIndex = -1;
            cmbMateria.Items.Clear();
            cmbMateria.Enabled = false;
            txtEnunciado.AlterarValidade(true);
            cmbDisciplina.AlterarValidade(true);
            cmbMateria.AlterarValidade(true);
            cmbBimestre.AlterarValidade(true);

            PopularComboBox();

        }

        public override object[] ObterFiltros()
        {
            return new object[]
                {
                    txtEnunciado.Text,
                    cmbDisciplina.SelectedItem,
                    cmbMateria.SelectedItem,
                    BimestreUtil.ObterBimestre(cmbBimestre.SelectedIndex)

                };
        }

        public override void ValidarFiltros()
        {
            List<string> camposInvalidos = new List<string>();
            string mensagem = "";

            if (!string.IsNullOrEmpty(txtEnunciado.Text) &&
                    !RegexUtil.PerteceAoPadrao(txtEnunciado.Text, @"^[A-Za-z0-9 ZéúíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËYÜÏÖÄçÇ]+$"))
            {
                mensagem += "O enunciado deve conter apenas letras, números e espaços.\n";
                camposInvalidos.Add("Enunciado");
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

            foreach (int item in BimestreUtil.ObterListaBimestre()) {  
                cmbBimestre.Items.Add(item);
            }
        }

        private IList<Materia> BuscarMateriaPorDisciplina(Disciplina disciplina)
        {
            return ((MateriaServico) MateriaGerenciadorFormulario.Instancia.ObterServico()).CarregarPorDisciplina(disciplina.Id);
        }

        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMateria.Enabled = true;

            Disciplina disciplina = cmbDisciplina.SelectedItem as Disciplina;
            if(disciplina == null)
            {
                return;
            }
            IList<Materia> materias = BuscarMateriaPorDisciplina(disciplina);

            cmbMateria.Items.Clear();

            cmbMateria.Items.AddRange(materias.ToArray());
        }
    }
}
