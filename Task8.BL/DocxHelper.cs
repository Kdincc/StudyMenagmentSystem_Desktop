using NPOI.XWPF.UserModel;
using System.Collections.Generic;
using Task8.BL.Interfaces;
using Task8.Data.Entity.Generated;

namespace Task8.BL
{
    public class DocxHelper : IDocumentHelper<XWPFDocument>
    {
        public void BuildHeader(XWPFDocument document, string text, int fontSize, DocumentFont font, bool isBold = false)
        {
            var paragraph = document.CreateParagraph();
            paragraph.Alignment = ParagraphAlignment.CENTER;

            var run = paragraph.CreateRun();
            run.SetText(text);
            ConfigureRun(run, font, fontSize, isBold);
        }

        public void BuildStudentList(XWPFDocument document, int fontSize, DocumentFont font, ICollection<Student> students, bool isBold = false)
        {
            foreach (Student student in students)
            {
                XWPFParagraph paragraph = document.CreateParagraph();

                paragraph.Alignment = ParagraphAlignment.BOTH;

                var run = paragraph.CreateRun();
                ConfigureRun(run, font, fontSize);
                run.SetText($"{student.FirstName} {student.LastName}");

                paragraph.SetNumID("2");
            }
        }

        private static void ConfigureRun(XWPFRun run, DocumentFont font, int fontSize, bool isBold = false)
        {
            run.IsBold = isBold;
            run.FontSize = fontSize;
            run.FontFamily = font.ToString();
            run.FontSize = fontSize;
        }
    }
}
