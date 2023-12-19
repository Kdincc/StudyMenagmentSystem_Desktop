using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Font;
using iText.Layout.Properties;
using System.Collections.Generic;
using System.IO;
using Task8.BL.Interfaces;
using Task8.Data.Entity.Generated;

namespace Task8.BL
{
    public class PDFService : IPDFService
    {
        public void BuidGroupReport(string savePath, string courseName, Group group)
        {
            using (PdfWriter writer = new(savePath))
            {
                using (PdfDocument pdf = new(writer))
                {
                    int fontSize = 14;

                    Document document = new(pdf);

                    var fontProvider = new FontProvider();
                    fontProvider.AddSystemFonts();

                    document.SetFont(PdfFontFactory.CreateFont());
                    document.SetFontProvider(fontProvider);

                    BuildHeader(document, fontSize, courseName, true);

                    BuildHeader(document, fontSize, group.Name);

                    BuildStudentsList(document, fontSize, group.Students);
                }
            }
        }

        private void BuildHeader(Document document, int fontSize, string text, bool isBold = false) 
        {
            var paragraph = new Paragraph();

            if (isBold)
            {
                paragraph.SetBold();
            }

            paragraph.SetHorizontalAlignment(HorizontalAlignment.CENTER);
            paragraph.SetTextAlignment(TextAlignment.CENTER);
            paragraph.SetFontSize(fontSize);
            paragraph.SetFontFamily(DocumentFonts.TimesNewRoman.ToString());
            paragraph.Add(text);

            document.Add(paragraph);
        }

        private void BuildStudentsList(Document document, int fontSize, ICollection<Student> students) 
        {
            int studentCounter = 1;
            List list = new();

            list.SetListSymbol("");
            list.SetFontSize(fontSize);
            list.SetFontFamily(DocumentFonts.TimesNewRoman.ToString());

            foreach (var student in students) 
            {
                list.Add($"{studentCounter}. {student.FirstName} {student.LastName}");
                studentCounter++;
            }

            document.Add(list);
        }
    }
}
