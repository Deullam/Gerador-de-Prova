using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NDD.GeradorProva.Infra;
using NDD.GeradorProva.WinApp.Util;
using NDD.GeradorProva.Domain.Entidades;

namespace NDD.GeradorProva.WinApp.Funcionalidades.QuestaoModule
{
    public partial class AlternativaUserControl : UserControl
    {
        private int _id;
        private Alternativa _entidade;

        public AlternativaUserControl()
        {
            InitializeComponent();
        }

        public List<Alternativa> ObterAlternativas()
        {
            List<Alternativa> list = new List<Alternativa>();
            foreach (Alternativa alternativa in listBoxAlternativas.Items)
            {
                list.Add(alternativa);
            }

            return list;
        }

        public void MostrarAlternativas(IList<Alternativa> alternativas)
        {
            listBoxAlternativas.Items.Clear();

            _id = 1;
            foreach (Alternativa alternativa in alternativas)
            {
                alternativa.Id = _id++;
                listBoxAlternativas.Items.Add(alternativa);
            }
        }

        public void LimparAlternativas()
        {
            listBoxAlternativas.Items.Clear();
            LimparValores();
        }

        private void Salvar()
        {
            try
            {
                AtribuirValores();
                _entidade.Validar();
                _entidade.ValidarUnicidadeNome(ObterAlternativas());

                if (!listBoxAlternativas.Items.Contains(_entidade))
                {
                    listBoxAlternativas.Items.Add(_entidade);
                }
                else
                {
                    var index = listBoxAlternativas.Items.IndexOf(_entidade);
                    listBoxAlternativas.Items.Insert(index, _entidade);
                    listBoxAlternativas.Items.RemoveAt(index + 1);
                }

                LimparValores();
            }
            catch (ValidacaoExcecao ex)
            {
                MessageBox.Show(ex.Message);

                txtDescricao.AlterarValidade(!ex.Campos.Contains("Descricao"));
                chkCorreta.AlterarValidade(!ex.Campos.Contains("Correta"));
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void AtribuirValores()
        {
            if (_entidade == null)
            {
                _entidade = new Alternativa();
                _entidade.Id = _id++;
            }

            _entidade.Descricao = txtDescricao.Text;
            _entidade.Correta = chkCorreta.Checked;
        }

        private void MostrarValores()
        {
            if (_entidade == null)
            {
                return;
            }

            txtDescricao.Text = _entidade.Descricao;
            chkCorreta.Checked = _entidade.Correta;
            btnRemover.Enabled = true;
        }

        private void LimparValores()
        {
            txtDescricao.Clear();
            chkCorreta.Checked = false;
            
            txtDescricao.AlterarValidade(true);
            chkCorreta.AlterarValidade(true);

            btnRemover.Enabled = false;
            _entidade = null;
            listBoxAlternativas.SelectedItem = null;
        }

        private void RemoverEntidade()
        {
            listBoxAlternativas.Items.Remove(_entidade);
            LimparValores();
        }

        private void listBoxAlternativas_SelectedIndexChanged(object sender, EventArgs e)
        {
            _entidade = listBoxAlternativas.SelectedItem as Alternativa;
            MostrarValores();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (_entidade != null)
            {
                RemoverEntidade();
            }
            else
            {
                MessageBox.Show("Selecione uma alternativa para remover.");
            }
        }

    }
}
