using NDD.GeradorProva.Application;
using NDD.GeradorProva.Domain;
using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.Infra;
using NDD.GeradorProva.Infra.Uit;
using NDD.GeradorProva.WinApp.Nucleo.CadastroDialog;
using NDD.GeradorProva.WinApp.Util;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NDD.GeradorProva.WinApp.Funcionalidades.SerieModule
{
    public partial class SerieCadastroDialog : CadastroBasicoDialog<Serie>
    {
        private SerieServico _servico;

        public SerieCadastroDialog() : base()
        {
            InitializeComponent();
            _servico = SerieGerenciadorFormulario.Instancia.ObterServico() as SerieServico;
        }


        protected override void Salvar()
        {
            try
            {
                ValidarValores();
                AtribuirValores();
                _entidade.Validar();
                _servico.ValidarExistenciaNumero(_entidade.Numero, _entidade.Id);
            }
            catch (ValidacaoExcecao ex)
            {
                DialogResult = DialogResult.None;

                MessageBox.Show(ex.Message);

                nudSerie.AlterarValidade(!ex.Campos.Contains("Numero"));
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
                _entidade = new Serie();
            }
            _entidade.Numero = (int)nudSerie.Value;
        }

        protected override void MostrarValores()
        {
            nudSerie.Value = _entidade.Numero;
        }

        protected override void LimparValores()
        {
            nudSerie.Value = 1;
            nudSerie.AlterarValidade(true);
        }

        protected override void ValidarValores()
        {
            if (!NumeroUtil.EhInt(nudSerie.Text))
                throw new ValidacaoExcecao("O número deve ser numérico.",new List<String>() {"Numero"});
        
        }

        private void nudSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
