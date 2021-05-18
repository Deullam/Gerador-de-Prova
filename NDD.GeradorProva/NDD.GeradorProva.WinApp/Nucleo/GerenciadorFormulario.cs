using NDD.GeradorProva.Application;
using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.Infra.Singleton;
using NDD.GeradorProva.WinApp.Nucleo.CadastroDialog;
using NDD.GeradorProva.WinApp.Nucleo.ControleUsuario;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NDD.GeradorProva.WinApp.Nucleo
{
    public abstract class GerenciadorFormulario<T, S> : SingletonBasico<S> where T : Entidade
    {

        protected ListaBasicaControleUsuario<T> _control;
        protected FiltroBasicoControleUsuario<T> _filtroBasico;
        protected Servico<T> _servico;

        protected GerenciadorFormulario()
        {

        }

        public virtual void Adicionar()
        {
            CadastroBasicoDialog<T> dialog = ObterDialogoCadastro();
            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                ObterServico().Adicionar(dialog.Entidade);
                ObterFiltro().AtualizarDados();
            }

        }
        public virtual void Atualizar()
        {
            CadastroBasicoDialog<T> dialog = ObterDialogoCadastro();
            T entidade = ObterLista().ObterItemSelecionado();
            if (entidade == null)
            {
                MessageBox.Show("Selecione um registro para alterar");
                return;
            }

            dialog.Entidade = entidade;

            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                ObterServico().Atualizar(dialog.Entidade);
                ObterFiltro().AtualizarDados();
            }
        }

        public virtual void Excluir()
        {
            T entidade = ObterLista().ObterItemSelecionado();
            if (entidade == null)
            {
                MessageBox.Show("Selecione um registro para excluir");
                return;
            }

            DialogResult result = MessageBox.Show("Você deseja excluir este registro?",
                "Confirmação de exclusão", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    ObterServico().Excluir(entidade);
                    ObterFiltro().AtualizarDados();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public virtual ListaBasicaControleUsuario<T> ObterLista()
        {
            if (_control == null)
            {
                _control = new ListaBasicaControleUsuario<T>();
                ObterFiltro().AtualizarDados();
            }

            return _control;
        }


        public virtual void ExportarPDF()
        {
            _servico = ObterServico();
            //CadastroBasicoDialog<T> dialog = ObterDialogoCadastro();

            SaveFileDialog dialogFile = new SaveFileDialog();
            dialogFile.Filter = "PDF(*.pdf)|*.pdf";
            dialogFile.Title = "Salvar em PDF";
            dialogFile.ShowDialog();

            if (!string.IsNullOrEmpty(dialogFile.FileName))
            {
                List<T> Entidades = _servico.BuscarTodos();

                try
                {
                    _servico.GerarPDF(Entidades, dialogFile.FileName);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Arquivo aberto por outro processo ou sem permissão de acesso ao diretório.");
                }

            }

        }
        public virtual void ExportarXML()
        {
            _servico = ObterServico();

            SaveFileDialog dialogFile = new SaveFileDialog();
            dialogFile.Filter = "XML(*.xml)|*.xml";
            dialogFile.Title = "Salvar em XML";
            dialogFile.ShowDialog();

            if (!string.IsNullOrEmpty(dialogFile.FileName))
            {
                List<T> entidades = _servico.BuscarTodos();
                try
                {
                    _servico.GerarXML(entidades,dialogFile.FileName);
                }
                catch (Exception)
                {

                    MessageBox.Show("Arquivo aberto por outro processo ou sem permissão de acesso ao diretório.");

                }
            }

        }
        public virtual void ExportarCSV()
        {
            _servico = ObterServico();

            SaveFileDialog dialogFile = new SaveFileDialog();
            dialogFile.Filter = "CSV(*.csv)|*.csv";
            dialogFile.Title = "Salvar em CSV";
            dialogFile.ShowDialog();

            if (!string.IsNullOrEmpty(dialogFile.FileName))
            {
                List<T> entidades = _servico.BuscarTodos();

                try
                {
                    _servico.GerarCSV(entidades, dialogFile.FileName);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message +"Arquivo aberto por outro processo ou sem permissão de acesso ao diretório.");

                }
            }
        }



        public abstract string ObterTitulo();
        public abstract Servico<T> ObterServico();
        public abstract FiltroBasicoControleUsuario<T> ObterFiltro();
        public abstract CadastroBasicoDialog<T> ObterDialogoCadastro();
        public abstract EstadoBotao ObterEstadoBotao();
        public abstract VisibilidadeBotao ObterVisibilidadeBotao();
        public abstract TituloBotao ObterTituloBotao();

    }
}
