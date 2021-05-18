using NDD.GeradorProva.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDD.GeradorProva.Domain.Entidades
{
    public class Alternativa : Entidade
    {
        public String Descricao { get; set; }
        public bool Correta { get; set; }
        public Questao Questao { get; set; }

        public Alternativa()
        {
        }

        public override void Validar()
        {
            if (String.IsNullOrEmpty(Descricao))
            {
                throw new ValidacaoExcecao("A descrição da alternativa deve ser informada.\n", new List<string>() { "Descricao" });
            }
            else if (Descricao.Length < 1)
            {
                throw new ValidacaoExcecao("A descrição da alternativa deve ter pelo menos 1 caracteres.\n", new List<string>() { "Descricao" });
            }
            else if (Descricao.Length > 50)
            {
                throw new ValidacaoExcecao("A descrição da alternativa deve ter no máximo 50 caracteres.\n", new List<string>() { "Descricao" });
            }
        }

        public void ValidarUnicidadeNome(IList<Alternativa> alternativas)
        {
            if (alternativas.FirstOrDefault(x => x.Descricao.Equals(Descricao) && x.Id != Id) != null)
            {
                throw new ValidacaoExcecao("Esta descrição de alternativa já foi informada.\n", new List<string>() { "Descricao" });
            }
        }

        public override string ToString()
        {
            return (Correta ? "(X) " : "    ") + Descricao;
        }

    }
}
