using System.Drawing;
using System.Windows.Forms;

namespace NDD.GeradorProva.WinApp.Util
{
    public static class ValidacaoComponenteMetodoExtensao
    {
        public static void AlterarValidade<T>(this T componente, bool valido) where T : Control
        {
            componente.BackColor = valido ? SystemColors.Window : Color.Red;
            componente.ForeColor = valido ? SystemColors.WindowText : Color.White;
        }

    }
}
