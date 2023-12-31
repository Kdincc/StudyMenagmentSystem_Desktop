using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Font;
using iText.Layout.Properties;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Task8.BL.Interfaces;
using Task8.Data.Entity.Generated;

namespace Task8.BL
{
    public class PdfService : IPdfService
    {
        public void WriteGroupReport(string savePath, GroupReport report)
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

                    BuildHeader(document, fontSize, report.CourseNameHeader, true);

                    BuildHeader(document, fontSize, report.GroupNameHeader);

                    BuildStudentsList(document, fontSize, report.Students.ToList());
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
