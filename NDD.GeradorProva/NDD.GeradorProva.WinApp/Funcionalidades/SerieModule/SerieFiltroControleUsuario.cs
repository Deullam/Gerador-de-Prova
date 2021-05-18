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

namespace NDD.GeradorProva.WinApp.Funcionalidades.SerieModule
{
    public partial class SerieFiltroControleUsuario : FiltroBasicoControleUsuario<Serie>
    {
        public SerieFiltroControleUsuario() : base(SerieGerenciadorFormulario.Instancia.ObterServico(), SerieGerenciadorFormulario.Instancia.ObterLista())
        {
            InitializeComponent();
        }


        public override void AtualizarDados()
        {
            try
            {
                ValidarFiltros();
                base.AtualizarDados();
                nudNumero.AlterarValidade(true);
            }
            catch (ValidacaoExcecao e)
            {
                nudNumero.AlterarValidade(!e.Campos.Contains("Numero"));

                MessageBox.Show(e.Message);
            }

        }

        public override void LimparFiltros()
        {
            nudNumero.Text = "";
            nudNumero.AlterarValidade(true);
        }

        public override object[] ObterFiltros()
        {
            return new object[]
                {
                    (string.IsNullOrEmpty(nudNumero.Text) ? 0 : nudNumero.Value)
                };
        }

        public override void ValidarFiltros()
        {
            List<string> camposInvalidos = new List<string>();
            string mensagem = "";

            if (!string.IsNullOrEmpty(nudNumero.Text) &&
                   (nudNumero.Value < 1 || nudNumero.Value > 9))
            {
                mensagem += "O número deve estar entre 1 e 9.\n";
                camposInvalidos.Add("Numero");
            }

            if (camposInvalidos.Count > 0)
            {
                throw new ValidacaoExcecao(mensagem, camposInvalidos);
            }
        }
    }
}
