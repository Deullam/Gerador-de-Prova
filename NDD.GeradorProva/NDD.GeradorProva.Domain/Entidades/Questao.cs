using NDD.GeradorProva.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDD.GeradorProva.Domain.Entidades
{
    public class Questao : Entidade
    {
        public String Enunciado { get; set; }
        public String Sintese { get; set; }
        public Disciplina Disciplina { get; set; }
        public Materia Materia { get; set; }
        public Bimestre Bimestre { get; set; }
        public List<Alternativa> Alternativas { get; set; }

        public Questao()
        {
        }

        public override void Validar()
        {
            List<string> camposInvalidos = new List<string>();
            string mensagem = "";

            if (String.IsNullOrEmpty(Enunciado))
            {
                mensagem += "O enunciado da questão deve ser informado.\n";
                camposInvalidos.Add("Enunciado");
            }
            else if (Enunciado.Length < 5)
            {
                mensagem += "O enunciado da questão deve ter pelo menos 5 caracteres.\n";
                camposInvalidos.Add("Enunciado");
            }
            else if (Enunciado.Length > 500)
            {
                mensagem += "O enunciado da questão deve ter no máximo 500 caracteres.\n";
                camposInvalidos.Add("Enunciado");
            }


            if (!String.IsNullOrEmpty(Sintese))
            {
                if (Sintese.Length < 5)
                {
                    mensagem += "A síntese da questão deve ter pelo menos 5 caracteres.\n";
                    camposInvalidos.Add("Sintese");
                }
                else if (Sintese.Length > 100)
                {
                    mensagem += "A síntese da questão deve ter no máximo 100 caracteres.\n";
                    camposInvalidos.Add("Sintese");
                }
            }

                if (Disciplina == null)
            {
                mensagem += "A disciplina deve ser informada.\n";
                camposInvalidos.Add("Disciplina");
            }

            if (Materia == null)
            {
                mensagem += "A matéria deve ser informada.\n";
                camposInvalidos.Add("Materia");
            }

            if (Bimestre.Equals(Bimestre.INVALIDO))
            {
                mensagem += "O bimestre deve ser informado.\n";
                camposInvalidos.Add("Bimestre");
            }

            if (Alternativas == null)
            {
                mensagem += "A questão deve possuir alternativas.";
                camposInvalidos.Add("Alternativas");
            }
            else if (Alternativas.Count < 2 || Alternativas.Count > 5)
            {
                mensagem += "A questão deve possuir de 2 à 5 alternativas.";
                camposInvalidos.Add("Alternativas");
            }
            else if (Alternativas.Count(x => x.Correta) < 1)
            {
                mensagem += "A questão deve possuir uma alternativa correta.";
                camposInvalidos.Add("Alternativas");
            }
            else if (Alternativas.Count(x => x.Correta) > 1)
            {
                mensagem += "A questão deve possuir somente uma alternativa correta.";
                camposInvalidos.Add("Alternativas");
            }

            if (camposInvalidos.Count > 0)
            {
                throw new ValidacaoExcecao(mensagem, camposInvalidos);
            }
        }

        public override string ToString()
        {
            string aux = Enunciado;

            if (aux.Length > 50)
            { 
                 aux = aux.Substring(0, 50);
            }; 
            return Disciplina.Nome + ", "
                + Materia.Nome + ", "
                + BimestreUtil.ObterBimestreNumerico(Bimestre) + "º bimestre"
                + (string.IsNullOrEmpty(Sintese) ? "" : ", " + Sintese);
        }


    }
}
