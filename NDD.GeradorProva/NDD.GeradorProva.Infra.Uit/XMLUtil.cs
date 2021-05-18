using NDD.GeradorProva.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDD.GeradorProva.Infra.Util
{
    public static class XMLUtil
    {
        public static void WriteXML<T>(this List<T> entidade, string path)
        {
            using (System.IO.FileStream file = System.IO.File.Create(path))
            {
                System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<T>));
                writer.Serialize(file, entidade);
                System.Diagnostics.Process.Start(path);
            }

        }

        public static void WriteTesteXML(this Teste entidade, string path)
        {
            using (System.IO.FileStream file = System.IO.File.Create(path))
            {
                System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(Teste));
                writer.Serialize(file, entidade);
                System.Diagnostics.Process.Start(path);
            }

        }


    }
}
