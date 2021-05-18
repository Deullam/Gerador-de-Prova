using System;
using System.Drawing.Imaging;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using NDD.GeradorProva.Domain.Entidades;
using System.Collections.Generic;

namespace NDD.GeradorProva.Infra.Util
{
    public class PDFWriterUtilQuestao
    {

        public void Write(List<Questao> questao, string title, string path)
        {   
            try
            {
                Document document = CreateDocument();

                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));

                document.Open();

                AddParagraph(document, GetTitleParagraph(title + " - " + DateTime.Now.ToShortDateString()));

                PopularQuestoes(questao, document);

                document.Close();

                System.Diagnostics.Process.Start(path);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private void PopularQuestoes(List<Questao> questoes, Document document)
        {
            char[] letras = { 'a', 'b', 'c', 'd', 'e' };

            int j = 0;
            foreach (Questao entity in questoes)
            {
                AddParagraph(document, GetItemParagraphLeft((j + 1) + ")" + entity.Enunciado.ToString() + "\n"));

                int i = 0;
                foreach (var item in questoes[j].Alternativas)
                {
                    if (item.Correta == true)
                    {
                        AddParagraph(document, GetItemParagraphLeft("*(" + letras[i] + ") " + item.Descricao.ToString() + "\n"));
                    }
                    else
                    {
                        AddParagraph(document, GetItemParagraphLeft(" (" + letras[i] + ") " + item.Descricao.ToString() + "\n"));
                     
                    }
                    i++;
                }

                j++;

                AddParagraph(document, GetItemParagraphLeft("\n"));
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

        private Paragraph GetItemParagraphLeft(string text)
        {
            Paragraph paragraph = new Paragraph("", new Font(Font.NORMAL, 14));
            paragraph.Alignment = Element.ALIGN_JUSTIFIED;
            paragraph.Font = new Font(Font.NORMAL, 12, (int)System.Drawing.FontStyle.Regular);

            paragraph.Add(text);

            return paragraph;
        }
        private Paragraph GetItemParagraphRight(string text)
        {
            Paragraph paragraph = new Paragraph("", new Font(Font.NORMAL, 14));
            paragraph.Alignment = Element.ALIGN_RIGHT;
            paragraph.Font = new Font(Font.NORMAL, 12, (int)System.Drawing.FontStyle.Regular);

            paragraph.Add(text);

            return paragraph;
        }

        private Paragraph GetTitleParagraph(string text)
        {
            Paragraph paragraph = new Paragraph("", new Font(Font.NORMAL, 14));
            paragraph.Alignment = Element.ALIGN_CENTER;
            paragraph.Font = new Font(Font.NORMAL, 18, (int)System.Drawing.FontStyle.Regular);

            paragraph.Add(text);

            return paragraph;
        }
    }
}
