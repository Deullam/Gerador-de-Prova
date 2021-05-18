using NDD.GeradorProva.Domain.Entidades;
using System;
using System.Windows.Forms;

namespace NDD.GeradorProva.WinApp.Nucleo.CadastroDialog
{
    public partial class CadastroBasicoDialog<E> : Form where E : Entidade
    { 

        protected E _entidade;

        public CadastroBasicoDialog()
        {
            InitializeComponent();
        }

        public E Entidade
        {
            get
            {
                return _entidade;
            }
            set
            {
                _entidade = value;

                LimparValores();

                if (_entidade != null)
                    MostrarValores();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        protected virtual void Salvar() { }

        protected virtual void AtribuirValores() { }

        protected virtual void MostrarValores() { }

        protected virtual void LimparValores() { }

        protected virtual void ValidarValores() { }
        
    }
}
