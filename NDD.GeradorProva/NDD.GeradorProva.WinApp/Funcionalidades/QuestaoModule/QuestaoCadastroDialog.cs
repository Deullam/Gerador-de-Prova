using NDD.GeradorProva.Application;
using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.Infra;
using NDD.GeradorProva.WinApp.Funcionalidades.MateriaModule;
using NDD.GeradorProva.WinApp.Nucleo.CadastroDialog;
using NDD.GeradorProva.WinApp.Util;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NDD.GeradorProva.WinApp.Funcionalidades.QuestaoModule
{
    public partial class QuestaoCadastroDialog : CadastroBasicoDialog<Questao>
    {

        private QuestaoServico _servico;
        private MateriaServico _servicoMateria;
        private AlternativaUserControl _alternativaUserControl;

        public QuestaoCadastroDialog(IList<Disciplina> disciplinas)
        {
            InitializeComponent();
            _servico = QuestaoGerenciadorFormulario.Instancia.ObterServico() as QuestaoServico;
            _servicoMateria = MateriaGerenciadorFormulario.Instancia.ObterServico() as MateriaServico;

            CriarAlternativaUserControl();
            PopularCombos(disciplinas);
        }
        
        private void CriarAlternativaUserControl()
        {
            _alternativaUserControl = new AlternativaUserControl();
            _alternativaUserControl.Dock = DockStyle.Fill;
            this.tabPage2.Controls.Add(_alternativaUserControl);
        } 

        private void PopularCombos(IList<Disciplina> disciplinas)
        {
            foreach (var item in disciplinas)
            {
                cmbDisciplina.Items.Add(item);
            }

            foreach (var item in BimestreUtil.ObterListaBimestre())
            {
                cmbBimestre.Items.Add(item);
            }
        }

        protected override void Salvar()
        {
            try
            {
                ValidarValores();
                AtribuirValores();
                _entidade.Validar();

                if (!String.IsNullOrEmpty(_entidade.Sintese))
                {
                    _servico.ValidarExistenciaSintese(_entidade.Sintese, _entidade.Id);
                }
                
                _servico.ValidarExistenciaEnunciado(_entidade.Enunciado, _entidade.Id);
            }
            catch (ValidacaoExcecao ex)
            {
                DialogResult = DialogResult.None;

                MessageBox.Show(ex.Message);

                txtSintese.AlterarValidade(!ex.Campos.Contains("Sintese"));
                txtEnunciado.AlterarValidade(!ex.Campos.Contains("Enunciado"));
                cmbDisciplina.AlterarValidade(!ex.Campos.Contains("Disciplina"));
                cmbMateria.AlterarValidade(!ex.Campos.Contains("Materia"));
                cmbBimestre.AlterarValidade(!ex.Campos.Contains("Bimestre"));
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
                _entidade = new Questao();
            }

            _entidade.Sintese = txtSintese.Text;
            _entidade.Enunciado = txtEnunciado.Text;
            _entidade.Disciplina = cmbDisciplina.SelectedItem as Disciplina;
            _entidade.Materia = cmbMateria.SelectedItem as Materia;
            _entidade.Bimestre = BimestreUtil.ObterBimestre(cmbBimestre.SelectedIndex);
            _entidade.Alternativas = _alternativaUserControl.ObterAlternativas();
        }

        protected override void MostrarValores()
        {
            txtSintese.Text = _entidade.Sintese;
            txtEnunciado.Text = _entidade.Enunciado;
            cmbDisciplina.SelectedItem = _entidade.Disciplina;
            cmbMateria.SelectedItem = _entidade.Materia;
            cmbBimestre.SelectedItem = BimestreUtil.ObterBimestreNumerico(_entidade.Bimestre);
            _alternativaUserControl.MostrarAlternativas(_entidade.Alternativas);
        }

        protected override void LimparValores()
        {
            txtSintese.Clear();
            txtEnunciado.Clear();
            cmbDisciplina.SelectedIndex = -1;
            cmbMateria.SelectedIndex = -1;
            cmbBimestre.SelectedIndex = -1;
            cmbMateria.Enabled = false;
            _alternativaUserControl.LimparAlternativas();

            txtSintese.AlterarValidade(true);
            txtEnunciado.AlterarValidade(true);
            cmbDisciplina.AlterarValidade(true);
            cmbMateria.AlterarValidade(true);
            cmbBimestre.AlterarValidade(true);
        }

        private IList<Materia> BuscarMateriaPorDisciplina(Disciplina disciplina)
        {
            return _servicoMateria.CarregarPorDisciplina(disciplina.Id);
        }

        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMateria.Enabled = true;
            
            Disciplina disciplina = cmbDisciplina.SelectedItem as Disciplina;
            IList<Materia> materias = BuscarMateriaPorDisciplina(disciplina);

            cmbMateria.Items.Clear();

            foreach (var item in materias)
            {
                cmbMateria.Items.Add(item);
            }
        }
    }
}
