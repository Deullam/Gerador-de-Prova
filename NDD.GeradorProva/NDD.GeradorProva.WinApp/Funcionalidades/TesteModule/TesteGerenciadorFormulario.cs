using NDD.GeradorProva.WinApp.Nucleo;
using System;
using System.Collections.Generic;
using NDD.GeradorProva.Application;
using NDD.GeradorProva.WinApp.Nucleo.CadastroDialog;
using NDD.GeradorProva.WinApp.Funcionalidades.MateriaModule;
using NDD.GeradorProva.WinApp.Funcionalidades.DisciplinaModule;
using System.Windows.Forms;
using NDD.GeradorProva.Domain.Entidades;
using NDD.GeradorProva.WinApp.Nucleo.ControleUsuario;

namespace NDD.GeradorProva.WinApp.Funcionalidades.TesteModule
{
    public class TesteGerenciadorFormulario : GerenciadorFormulario<Teste, TesteGerenciadorFormulario>
    {
      

        private TesteGerenciadorFormulario()
        {
        }
        
        public override CadastroBasicoDialog<Teste> ObterDialogoCadastro()
        {
            IList<Materia> materias = MateriaGerenciadorFormulario.Instancia.ObterServico().BuscarTodos();
            IList<Disciplina> disciplinas = DisciplinaGerenciadorFormulario.Instancia.ObterServico().BuscarTodos();
            return new TesteCadastroDialog(ObterServico() as TesteServico, disciplinas, materias);
        }

        public override EstadoBotao ObterEstadoBotao()
        {
            return new EstadoBotao()
            {
                Adicionar = true,
                Atualizar = false,
                Excluir = true,
                ExportarPDF = false
            };
        }
        
        public override Servico<Teste> ObterServico()
        {
            if (_servico == null)
                _servico = new TesteServico();
            return _servico;
        }

        public override string ObterTitulo()
        {
            return "Cadastro de teste";
        }

        public override TituloBotao ObterTituloBotao()
        {
            return new TituloBotao()
            {
                Adicionar = "Adicionar teste",
                Atualizar = "",
                Excluir = "Excluir teste",
                ExportarPDF = "Exportar teste para PDF"
            };
        }

        public override VisibilidadeBotao ObterVisibilidadeBotao()
        {
            return new VisibilidadeBotao()
            {
                Adicionar = true,
                Atualizar = false,
                Excluir = true,
                ExportarPDF = false
            };
        }
        public override void Atualizar()
        {
            throw new NotImplementedException();
        }

        public override void ExportarPDF()
        {
            TesteServico _servicoTeste = TesteGerenciadorFormulario.Instancia.ObterServico() as TesteServico;
            CadastroBasicoDialog<Teste> dialog = ObterDialogoCadastro();
            Teste entidade = ObterLista().ObterItemSelecionado();

            if (entidade == null)
            {
                MessageBox.Show("Selecione uma Prova para gerar");
                return;
            }

            SaveFileDialog dialogFile = new SaveFileDialog();
            dialogFile.Filter = "PDF(*.pdf)|*.pdf";
            dialogFile.Title = "Salvar prova";
            dialogFile.ShowDialog();

            if (!string.IsNullOrEmpty(dialogFile.FileName))
            {
                Teste teste = _servicoTeste.ConsultarPorId(entidade.Id);

                try
                {
                    _servicoTeste.GerarPDFTeste(teste, dialogFile.FileName);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Arquivo aberto por outro processo ou sem permissão de acesso ao diretório.");
                }

            }
        }


        public override void ExportarXML()
        {
            TesteServico _servicoTeste = TesteGerenciadorFormulario.Instancia.ObterServico() as TesteServico;
            CadastroBasicoDialog<Teste> dialog = ObterDialogoCadastro();
            Teste entidade = ObterLista().ObterItemSelecionado();

            if (entidade == null)
            {
                MessageBox.Show("Selecione uma Prova para gerar");
                return;
            }

            SaveFileDialog dialogFile = new SaveFileDialog();
            dialogFile.Filter = "XML(*.xml)|*.xml";
            dialogFile.Title = "Salvar prova";
            dialogFile.ShowDialog();

            if (!string.IsNullOrEmpty(dialogFile.FileName))
            {
                Teste teste = _servicoTeste.ConsultarPorId(entidade.Id);

                try
                {
                    _servicoTeste.GerarXMLTeste(teste, dialogFile.FileName);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Arquivo aberto por outro processo ou sem permissão de acesso ao diretório.");
                }

            }
        }

        public override void ExportarCSV()
        {
            TesteServico _servicoTeste = TesteGerenciadorFormulario.Instancia.ObterServico() as TesteServico;
            CadastroBasicoDialog<Teste> dialog = ObterDialogoCadastro();
            Teste entidade = ObterLista().ObterItemSelecionado();

            if (entidade == null)
            {
                MessageBox.Show("Selecione uma Prova para gerar");
                return;
            }

            SaveFileDialog dialogFile = new SaveFileDialog();
            dialogFile.Filter = "CSV(*.csv)|*.csv";
            dialogFile.Title = "Salvar Prova";
            dialogFile.ShowDialog();

            if (!string.IsNullOrEmpty(dialogFile.FileName))
            {
                Teste teste = _servicoTeste.ConsultarPorId(entidade.Id);

                try
                {
                    _servicoTeste.GerarCSVTeste(teste, dialogFile.FileName);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Arquivo aberto por outro processo ou sem permissão de acesso ao diretório.");
                }

            }
        }
        public override FiltroBasicoControleUsuario<Teste> ObterFiltro()
        {
            if (_filtroBasico == null)
            {
                _filtroBasico = new TesteFiltroControleUsuario();
            }
            return _filtroBasico;
        }
    }
}
