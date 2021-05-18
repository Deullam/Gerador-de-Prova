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
using NDD.GeradorProva.WinApp.Funcionalidades.DisciplinaModule;
using NDD.GeradorProva.WinApp.Funcionalidades.SerieModule;

namespace NDD.GeradorProva.WinApp.Funcionalidades.MateriaModule
{
    public partial class MateriaFiltroControleUsuario : FiltroBasicoControleUsuario<Materia>
    {
        public MateriaFiltroControleUsuario() : base(MateriaGerenciadorFormulario.Instancia.ObterServico(), MateriaGerenciadorFormulario.Instancia.ObterLista())
        {
            InitializeComponent();
            PopularComboBox();
        }

        public override void AtualizarDados()
        {
            try
            {
                ValidarFiltros();
                base.AtualizarDados();
                txtNome.AlterarValidade(true);
                cmbDisciplina.AlterarValidade(true);
                cmbSerie.AlterarValidade(true);
            }
            catch (ValidacaoExcecao e)
            {
                txtNome.AlterarValidade(!e.Campos.Contains("Nome"));
                cmbDisciplina.AlterarValidade(!e.Campos.Contains("Disciplina"));
                cmbSerie.AlterarValidade(!e.Campos.Contains("Serie"));

                MessageBox.Show(e.Message);
            }

        }

        public override void LimparFiltros()
        {
            txtNome.Clear();
            cmbDisciplina.SelectedIndex = -1;
            cmbSerie.SelectedIndex = -1;
            txtNome.AlterarValidade(true);
            cmbDisciplina.AlterarValidade(true);
            cmbSerie.AlterarValidade(true);


        }

        public override object[] ObterFiltros()
        {
            return new object[]
                {
                    txtNome.Text,
                    cmbDisciplina.SelectedItem,
                    cmbSerie.SelectedItem

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

        private void PopularComboBox()
        {
            cmbDisciplina.Items.AddRange(DisciplinaGerenciadorFormulario.Instancia.ObterServico().BuscarTodos().ToArray());
            cmbSerie.Items.AddRange(SerieGerenciadorFormulario.Instancia.ObterServico().BuscarTodos().ToArray());
        }
    }
}

