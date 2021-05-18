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
    public class Disciplina : Entidade
    {
        public String Nome { get; set;}

        public override void Validar()
        {
            if (String.IsNullOrEmpty(Nome))
            {
                throw new ValidacaoExcecao("O nome da disciplina deve ser informado.",new List<String>() {"Nome"}); 
            }
            else if(Nome.Length < 4)
            {
                throw new ValidacaoExcecao("O nome da disciplina deve ter pelo menos 4 caracteres.", new List<String>() { "Nome" });
            }
            else if (Nome.Length > 25)
            {
                throw new ValidacaoExcecao("O nome da disciplina deve ter no máximo 25 caracteres.", new List<String>() { "Nome" });
            }
            else if (!RegexUtil.PerteceAoPadrao(Nome, @"^[A-Za-z ZéúíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËYÜÏÖÄçÇ]+$"))
            {
                throw new ValidacaoExcecao("O nome da disciplina deve conter apenas letras e espaços.", new List<String>() { "Nome" });
            }
        }

        public override string ToString()
        {
            return Nome;
        }

    }
}
