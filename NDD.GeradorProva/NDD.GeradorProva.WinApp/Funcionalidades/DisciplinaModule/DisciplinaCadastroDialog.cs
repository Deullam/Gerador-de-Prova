using NDD.GeradorProva.Application;
using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.Infra;
using NDD.GeradorProva.WinApp.Nucleo.CadastroDialog;
using NDD.GeradorProva.WinApp.Util;
using System;
using System.Windows.Forms;

namespace NDD.GeradorProva.WinApp.Funcionalidades.DisciplinaModule
{
    public partial class DisciplinaCadastroDialog : CadastroBasicoDialog<Disciplina>
    {

        private DisciplinaServico _servico;
        
        public DisciplinaCadastroDialog() : base()
        {
            InitializeComponent();
            _servico = DisciplinaGerenciadorFormulario.Instancia.ObterServico() as DisciplinaServico;
        }

        protected override void Salvar()
        {
            try
            {
                AtribuirValores();
                _entidade.Validar();
                _servico.ValidarExistenciaNome(_entidade.Nome, _entidade.Id);
            }
            catch (ValidacaoExcecao ex)
            {
                DialogResult = DialogResult.None;

                MessageBox.Show(ex.Message);

                txtDisciplina.AlterarValidade(!ex.Campos.Contains("Nome"));
            }
            catch (Exception exc)
            {
                DialogResult = DialogResult.None;

                MessageBox.Show(exc.Message);
            }
        }

        protected override void AtribuirValores()
        {
            if(_entidade == null)
            {
                _entidade = new Disciplina();
            }
            _entidade.Nome = txtDisciplina.Text;
        }

        protected override void MostrarValores()
        {
            txtDisciplina.Text = _entidade.Nome;
        }

        protected override void LimparValores()
        {
            txtDisciplina.Clear();
            txtDisciplina.AlterarValidade(true);
        }
        
    }
}
