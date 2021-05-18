using NDD.GeradorProva.Application;
using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.Infra;
using NDD.GeradorProva.WinApp.Funcionalidades.MateriaModule;
using NDD.GeradorProva.WinApp.Funcionalidades.QuestaoModule;
using NDD.GeradorProva.WinApp.Nucleo.CadastroDialog;
using NDD.GeradorProva.WinApp.Util;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NDD.GeradorProva.WinApp.Funcionalidades.TesteModule
{
    public partial class TesteCadastroDialog : CadastroBasicoDialog<Teste>
    {

        private TesteServico _servico;
        private MateriaServico _servicoMateria;
        private QuestaoServico _servicoQuestao;

        public TesteCadastroDialog(TesteServico servico, IList<Disciplina> disciplinas, IList<Materia> materias) : base()
        {
            InitializeComponent();
            cmbMateria.Enabled = false;
            _servico = servico;
            _servicoMateria = MateriaGerenciadorFormulario.Instancia.ObterServico() as MateriaServico;
            _servicoQuestao = QuestaoGerenciadorFormulario.Instancia.ObterServico() as QuestaoServico;

            foreach (var item in disciplinas)
            {
                cmbDisciplina.Items.Add(item);
            }

        }
        protected override void Salvar()
        {
            try
            {
                AtribuirValores();
                _entidade.Validar();
                _entidade.GerarQuestoesAleatorias(_servicoQuestao.CarregarPorMateria(_entidade.Materia.Id));

                _servico.ValidarExistenciaTitulo(_entidade.Titulo, _entidade.Id);
            }
            catch (ValidacaoExcecao ex)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(ex.Message);

                txtTitulo.AlterarValidade(!ex.Campos.Contains("Titulo"));
                cmbDisciplina.AlterarValidade(!ex.Campos.Contains("Disciplina"));
                cmbMateria.AlterarValidade(!ex.Campos.Contains("Materia"));
                numQtdQuestoes.AlterarValidade(!ex.Campos.Contains("QuantidadeQuestoes"));
               
            }
            catch (Exception exc)
            {
                DialogResult = DialogResult.None;

                MessageBox.Show(exc.Message);
            }
        }
        protected override void AtribuirValores()
        {
            if (_entidade == null)
            {
                _entidade = new Teste();
            }
            _entidade.Titulo = txtTitulo.Text;
            _entidade.QuantidadeQuestoes = Convert.ToInt16(numQtdQuestoes.Value);
            _entidade.DataGeracao = DateTime.Now;
            _entidade.Disciplina = cmbDisciplina.SelectedItem as Disciplina;
            _entidade.Materia = cmbMateria.SelectedItem as Materia;
        }

        protected override void MostrarValores()
        {

        }

        private IList<Materia> BuscarMateriaPorDisciplina(Disciplina disciplina)
        {
            return _servicoMateria.CarregarPorDisciplina(disciplina.Id);
        }

        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMateria.Enabled = true;

            IList<Materia> materias = new List<Materia>();
            Disciplina disciplina = new Disciplina();
            disciplina = cmbDisciplina.SelectedItem as Disciplina;
            materias = BuscarMateriaPorDisciplina(disciplina);
            cmbMateria.Items.Clear();
            foreach (var item in materias)
            {
                cmbMateria.Items.Add(item);
            }


        }

        protected override void LimparValores()
        {
            txtTitulo.Clear();
            txtTitulo.AlterarValidade(true);
            cmbDisciplina.SelectedIndex = -1;
            cmbDisciplina.AlterarValidade(true);
            cmbMateria.SelectedIndex = -1;
            cmbMateria.AlterarValidade(true);
            numQtdQuestoes.Value = 10;
            numQtdQuestoes.AlterarValidade(true);


        }
    }
}
