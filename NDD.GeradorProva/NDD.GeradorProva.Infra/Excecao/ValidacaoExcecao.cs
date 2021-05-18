using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDD.GeradorProva.Infra
{
    public class ValidacaoExcecao : ApplicationException
    {

        private IList<String> _campos;

        public IList<String> Campos
        {
            get => _campos;
        }

        public ValidacaoExcecao(string message) : base(message)
        {
            _campos = new List<string>();


        }
        public ValidacaoExcecao(string message, IList<String> fields) : base("O registro possui as seguintes inconsistências: \n" + message)
        {
            this._campos = fields;
        }

    }
}
