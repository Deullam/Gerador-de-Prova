using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NDD.GeradorProva.Application;
using NDD.GeradorProva.Domain.Entidades;

namespace NDD.GeradorProva.WinApp.Nucleo.ControleUsuario
{
    public partial class FiltroBasicoControleUsuario<T> : UserControl where T : Entidade
    {

        protected Servico<T> _servico;
        protected ListaBasicaControleUsuario<T> _listaBasica;

        protected FiltroBasicoControleUsuario()
        {
            InitializeComponent();
        }

        public FiltroBasicoControleUsuario(Servico<T> servico, ListaBasicaControleUsuario<T> listaBasica)
        {
            InitializeComponent();
            _servico = servico;
            _listaBasica = listaBasica;
        }

        public virtual object[] ObterFiltros()
        {
            return new object[] { };
        }

        public virtual void LimparFiltros()
        {

        }

        public virtual void ValidarFiltros()
        {

        }

        public virtual void AtualizarDados()
        {
            List<T> lista = _servico.Filtrar(ObterFiltros());
            _listaBasica.PopularListagem(lista);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            AtualizarDados();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparFiltros();
            AtualizarDados();
        }
    }
}
