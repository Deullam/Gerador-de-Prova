using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDD.GeradorProva.Infra.Singleton
{
    public abstract class SingletonBasico<E>
    {
        private static E instancia;

        public static E Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = (E) Activator.CreateInstance(typeof(E), true);
                }

                return instancia;
            }
        }
    }
}
