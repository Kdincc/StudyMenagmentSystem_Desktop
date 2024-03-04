using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Collections.Generic;
using Task8.BL.Interfaces;
using Task8.Data.Entity.Generated;

namespace Task8.BL
{
    public class PdfHelper : IDocumentHelper<Document>
    {
        public void BuildHeader(Document document, string text, int fontSize, DocumentFont font, bool isBold = false)
        {
            var paragraph = new Paragraph();

            if (isBold)
            {
                paragraph.SetBold();
            }

            paragraph.SetHorizontalAlignment(HorizontalAlignment.CENTER);
            paragraph.SetTextAlignment(TextAlignment.CENTER);
            paragraph.SetFontSize(fontSize);
            paragraph.SetFontFamily(font.ToString());
            paragraph.Add(text);

            document.Add(paragraph);
        }

        public void BuildStudentList(Document document, int fontSize, DocumentFont font, ICollection<Student> students, bool isBold = false)
        {
            int studentCounter = 1;
            List list = new();

            list.SetFontSize(fontSize);
            list.SetFontFamily(font.ToString());

            foreach (var student in students)
            {
                list.Add($"{studentCounter}. {student.FirstName} {student.LastName}");
                studentCounter++;
            }

            document.Add(list);
        }
    }
}
