using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NDD.GeradorProva.Infra.Uit
{
    public class RegexUtil
    {

        public static bool PerteceAoPadrao(string valor, string padrao)
        {
            Regex regex = new Regex(padrao);
            return regex.IsMatch(valor);
        }

    }
}
