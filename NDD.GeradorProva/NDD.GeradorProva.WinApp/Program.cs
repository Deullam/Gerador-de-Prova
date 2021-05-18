using NDD.GeradorProva.Infra;
using System;

namespace NDD.GeradorProva.WinApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ConfiguracaoSingleton.Instancia.Tipo = TipoBancoDeDados.SQL_SERVER;
            ConfiguracaoSingleton.Instancia.ModoZueiro = true;

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new Principal());
        }
    }
}
