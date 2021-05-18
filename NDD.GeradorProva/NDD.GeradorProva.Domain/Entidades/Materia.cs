using NDD.GeradorProva.Infra;
using NDD.GeradorProva.Infra.Uit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NDD.GeradorProva.Domain.Entidades
{
    public class Materia : Entidade
    {
        public String Nome { get; set; }
        public Serie Serie { get; set; }
        public Disciplina Disciplina { get; set; }

        public override void Validar()
        {
            List<string> camposInvalidos = new List<string>();
            string mensagem = "";

            if (String.IsNullOrEmpty(Nome))
            {
                mensagem += "O nome da matéria deve ser informado.\n";
                camposInvalidos.Add("Nome"); 
            }
            else if(Nome.Length < 5)
            {
                mensagem += "O nome da matéria deve ter pelo menos 5 caracteres.\n";
                camposInvalidos.Add("Nome");
            }
            else if (Nome.Length > 50)
            {
                mensagem += "O nome da matéria deve ter no máximo 50 caracteres.\n";
                camposInvalidos.Add("Nome");
            }
            else if (!RegexUtil.PerteceAoPadrao(Nome, @"^[A-Za-z \.\-\: ZéúíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËYÜÏÖÄçÇ]+$"))
            {
                mensagem += "O nome da matéria deve conter apenas letras e espaços.\n";
                camposInvalidos.Add("Nome");
            }
            else if (RegexUtil.PerteceAoPadrao(Nome, @"\s{2,}"))
            {
                mensagem += "O nome da matéria deve conter apenas um espaço em sequência.\n";
                camposInvalidos.Add("Nome");
            }

            if (Disciplina == null)
            {
                mensagem += "A disciplina deve ser informada.\n";
                camposInvalidos.Add("Disciplina");
            }

            if (Serie == null)
            {
                mensagem += "A série deve ser informada.\n";
                camposInvalidos.Add("Serie");
            }

            if (camposInvalidos.Count > 0)
            {
                throw new ValidacaoExcecao(mensagem, camposInvalidos);
            }
        }

        public override string ToString()
        {
            return Nome + ", " + Disciplina.Nome + ", " + Serie.ToString();

        }
    }
}
