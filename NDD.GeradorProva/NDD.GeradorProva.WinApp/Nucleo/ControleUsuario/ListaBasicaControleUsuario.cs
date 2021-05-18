using System.Collections.Generic;
using System.Windows.Forms;
using NDD.GeradorProva.Domain.Entidades;

namespace NDD.GeradorProva.WinApp.Nucleo.ControleUsuario
{
    public partial class ListaBasicaControleUsuario<E> : UserControl where E : Entidade
    {
        public ListaBasicaControleUsuario()
        {
            InitializeComponent();
        }

        public void PopularListagem(IList<E> entidades)
        {
            listBoxEntidades.Items.Clear();

            foreach (E c in entidades)
            {
                listBoxEntidades.Items.Add(c);
            }

        }

        public E ObterItemSelecionado()
        {
            return listBoxEntidades.SelectedItem as E;
        }

    }
}
