using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NDD.GeradorProva.WinApp.Nucleo.ControleUsuario;
using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.Infra;
using NDD.GeradorProva.WinApp.Util;
using NDD.GeradorProva.Infra.Uit;

namespace NDD.GeradorProva.WinApp.Funcionalidades.DisciplinaModule
{
    public partial class DisciplinaFiltroControleUsuario  : FiltroBasicoControleUsuario<Disciplina>
    {
        public DisciplinaFiltroControleUsuario() : base(DisciplinaGerenciadorFormulario.Instancia.ObterServico(), DisciplinaGerenciadorFormulario.Instancia.ObterLista())
        {
            InitializeComponent();
        }


        public override void AtualizarDados()
        {
            try
            {
                ValidarFiltros();
                base.AtualizarDados();
                txtNome.AlterarValidade(true);
            }
            catch (ValidacaoExcecao e)
            {
                txtNome.AlterarValidade(!e.Campos.Contains("Nome"));

                MessageBox.Show(e.Message);
            }

        }

        public override void LimparFiltros()
        {
            txtNome.Clear();
            txtNome.AlterarValidade(true);
        }

        public override object[] ObterFiltros()
        {
            return new object[]
                {                   
                    txtNome.Text                    
                };
        }

        public override void ValidarFiltros()
        {
            List<string> camposInvalidos = new List<string>();
            string mensagem = "";

            if (!string.IsNullOrEmpty(txtNome.Text) &&
                    !RegexUtil.PerteceAoPadrao(txtNome.Text, @"^[A-Za-z0-9 ZéúíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËYÜÏÖÄçÇ]+$"))
            {
                mensagem += "O nome deve conter apenas letras, números e espaços.\n";
                camposInvalidos.Add("Nome");
            }

            if (camposInvalidos.Count > 0)
            {
                throw new ValidacaoExcecao(mensagem, camposInvalidos);
            }
        }
    }
}
