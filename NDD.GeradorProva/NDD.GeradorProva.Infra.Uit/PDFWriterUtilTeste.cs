using System;
using System.Drawing.Imaging;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using NDD.GeradorProva.Domain.Entidades;

namespace NDD.GeradorProva.Infra.Util
{
    public class PDFWriterUtilTeste
    {

        public void WriteTeste(Teste teste, string path)
        {   
            try
            {   
                Document document = CreateDocument();

                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));

                document.Open();

                Cabecalho(teste, document);

                PopularQuestoes(teste, document);

                GerarGabarito(teste, document);

                document.Close();

                System.Diagnostics.Process.Start(path);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private void PopularQuestoes(Teste teste, Document document)
        {
            char[] letras = { 'a', 'b', 'c', 'd', 'e' };

            int j = 0;
            foreach (Questao entity in teste.Questoes)
            {
                AddParagraph(document, GetItemParagraphLeft((j + 1) + ")" + entity.Enunciado.ToString() + "\n"));

                int i = 0;
                foreach (var item in teste.Questoes[j].Alternativas)
                {
                    AddParagraph(document, GetItemParagraphLeft("(" + letras[i] + ") " + item.Descricao.ToString() + "\n"));
                    i++;
                }

                j++;

                AddParagraph(document, GetItemParagraphLeft("\n"));
            }
        }

        private void GerarGabarito(Teste teste, Document document)
        {
            int j;
            document.NewPage();

            AddParagraph(document, GetTitleParagraph("Gabarito " + " - " + teste.Titulo + "\n\n"));

            j = 0;
            char[] letrass = { 'a', 'b', 'c', 'd', 'e' };

            foreach (Questao entity in teste.Questoes)
            {
                int i = 0;
                foreach (var item in teste.Questoes[j].Alternativas)
                {
                    if (item.Correta == true)
                    {
                        AddParagraph(document, GetItemParagraphLeft(((j + 1) + "-(" + letrass[i] + ") " + item.Descricao.ToString() + "\n")));
                        break;
                    }
                    i++;
                }

                j++;

                AddParagraph(document, GetItemParagraphLeft("\n"));
            }

        }

        private void Cabecalho(Teste teste, Document document)
        {
            if (ConfiguracaoSingleton.Instancia.ModoZueiro)
            {
                System.Drawing.Bitmap bmp = (System.Drawing.Bitmap)Properties.Resources.logo_top;
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, ImageFormat.Png);
                byte[] bmpBytes = ms.ToArray();


                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(bmpBytes);
                logo.ScaleAbsolute(130f, 130f);
                logo.SetAbsolutePosition(430, 680);
                document.Add(logo);

                AddParagraph(document, GetItemParagraphLeft("Nome:________________________________________________\n"));
                AddParagraph(document, GetItemParagraphLeft("Data: ____/_____/_______   Nota:_____"));
                AddParagraph(document, GetItemParagraphLeft(teste.Materia.Serie.Numero.ToString() + "ª Série"));
                AddParagraph(document, GetItemParagraphLeft("Disciplina: " + teste.Disciplina.Nome.ToString()));
                AddParagraph(document, GetItemParagraphLeft("Matéria: " + teste.Materia.Nome.ToString() + "\n\n\n"));
            }
            else
            {
                AddParagraph(document, GetItemParagraphLeft("Nome:______________________________________________________  Nota:_____\n"));
                AddParagraph(document, GetItemParagraphLeft("Data: ____/_____/_______"));
                AddParagraph(document, GetItemParagraphLeft(teste.Materia.Serie.Numero.ToString() + "ª Série"));
                AddParagraph(document, GetItemParagraphLeft("Disciplina: " + teste.Disciplina.Nome.ToString()));
                AddParagraph(document, GetItemParagraphLeft("Matéria: " + teste.Materia.Nome.ToString() + "\n\n"));
            }

            AddParagraph(document, GetTitleParagraph(teste.Titulo + "\n\n"));
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
