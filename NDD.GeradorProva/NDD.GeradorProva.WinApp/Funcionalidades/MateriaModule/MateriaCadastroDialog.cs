using NDD.GeradorProva.Application;
using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.Infra;
using NDD.GeradorProva.WinApp.Nucleo.CadastroDialog;
using NDD.GeradorProva.WinApp.Util;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NDD.GeradorProva.WinApp.Funcionalidades.MateriaModule
{
    public partial class MateriaCadastroDialog : CadastroBasicoDialog<Materia>
    {

        private MateriaServico _servico;

        public MateriaCadastroDialog(IList<Disciplina> disciplinas, IList<Serie> series) : base()
        {
            InitializeComponent();
            _servico = MateriaGerenciadorFormulario.Instancia.ObterServico() as MateriaServico;
            PopularComboBox(disciplinas, series);

        }

        private void PopularComboBox(IList<Disciplina> disciplinas, IList<Serie> series)
        {
            foreach (var item in disciplinas)
            {
                cmbDisciplina.Items.Add(item);
            }

            foreach (var item in series)
            {
                cmbSerie.Items.Add(item);
            }
        }

        protected override void Salvar()
        {
            try
            {
                AtribuirValores();
                _entidade.Validar();
                ((MateriaServico)_servico).ValidarExistenciaNome(_entidade.Nome, _entidade.Id);
            }
            catch (ValidacaoExcecao ex)
            {
                DialogResult = DialogResult.None;

                MessageBox.Show(ex.Message);

                txtMateria.AlterarValidade(!ex.Campos.Contains("Nome"));
                cmbDisciplina.AlterarValidade(!ex.Campos.Contains("Disciplina"));
                cmbSerie.AlterarValidade(!ex.Campos.Contains("Serie"));
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
                _entidade = new Materia();
            }
            _entidade.Nome = txtMateria.Text;
            _entidade.Disciplina = cmbDisciplina.SelectedItem as Disciplina;
            _entidade.Serie = cmbSerie.SelectedItem as Serie;
        }

        protected override void MostrarValores()
        {
            txtMateria.Text = _entidade.Nome;
            cmbDisciplina.SelectedItem = _entidade.Disciplina;
            cmbSerie.SelectedItem = _entidade.Serie;
        }

        protected override void LimparValores()
        {
            txtMateria.Clear();
            txtMateria.AlterarValidade(true);
            cmbDisciplina.SelectedIndex = -1;
            cmbDisciplina.AlterarValidade(true);
            cmbSerie.SelectedIndex = -1;
            cmbSerie.AlterarValidade(true);


        }

        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }


}

