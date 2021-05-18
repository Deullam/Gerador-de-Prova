using System;
using System.Collections.Generic;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using NDD.GeradorProva.Domain.Entidades;

namespace NDD.GeradorProva.Infra.Util
{
    public class PDFWriterUtil<T> where T : Entidade
    {

        public void Write(List<T> entities, string title, string path)
        {
            try {
                Document document = CreateDocument();
            
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));

                document.Open();
                
                AddParagraph(document, GetTitleParagraph(title + " - " + DateTime.Now.ToShortDateString()));

                foreach (T entity in entities)
                {
                    AddParagraph(document, GetItemParagraph(entity.ToString()));
                }
            
                document.Close();
                
                System.Diagnostics.Process.Start(path);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private Document CreateDocument()
        {
            Document document = new Document(PageSize.A4);
            document.SetMargins(40, 40, 40, 80);
            document.AddCreationDate();

            return document;
        }

        private void AddParagraph(Document document, Paragraph paragraph)
        {
            document.Add(paragraph);
        }

        private Paragraph GetItemParagraph(string text)
        {
            Paragraph paragraph = new Paragraph("", new Font(Font.NORMAL, 14));
            paragraph.Alignment = Element.ALIGN_JUSTIFIED;
            paragraph.Font = new Font(Font.NORMAL, 12, (int) System.Drawing.FontStyle.Regular);

            paragraph.Add(text);

            return paragraph;
        }
        
        private Paragraph GetTitleParagraph(string text)
        {
            Paragraph paragraph = new Paragraph("", new Font(Font.NORMAL, 14));
            paragraph.Alignment = Element.ALIGN_CENTER;
            paragraph.Font = new Font(Font.NORMAL, 18, (int) System.Drawing.FontStyle.Regular);

            paragraph.Add(text);

            return paragraph;
        }
    }
}
