using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Task8.BL.Interfaces;
using Task8.Data.Entity.Generated;

namespace Task8.BL.Services
{
    public class DocxService : IDocxService
    {
        public void BuidGroupReport(string savePath, string courseName, Group group)
        {
            const int listFontSize = 14;
            const int titleFontSize = 16;
            XWPFDocument doc = new();

            BuildHeader(doc, courseName, titleFontSize, true);

            BuildHeader(doc, group.Name, titleFontSize);

            BuildStudentsList(doc, group.Students, listFontSize);

            using (FileStream fs = new(savePath, FileMode.Create, FileAccess.Write))
            {
                doc.Write(fs);
            }
        }

        private static void ConfigureRun(XWPFRun run, DocumentFonts font, int fontSize, bool isBold = false)
        {
            run.IsBold = isBold;
            run.FontSize = fontSize;
            run.FontFamily = font.ToString();
            run.FontSize = fontSize;
        }

        private static void BuildHeader(XWPFDocument document, string headerText, int fontSize, bool isBold = false)
        {
            var paragraph = document.CreateParagraph();
            paragraph.Alignment = ParagraphAlignment.CENTER;

            var run = paragraph.CreateRun();
            run.SetText(headerText);
            ConfigureRun(run, DocumentFonts.TimesNewRoman, fontSize, isBold);
        }

        private static void BuildStudentsList(XWPFDocument document, ICollection<Student> students, int fontSize)
        {
            foreach (Student student in students)
            {
                XWPFParagraph paragraph = document.CreateParagraph();

                paragraph.Alignment = ParagraphAlignment.BOTH;

                var run = paragraph.CreateRun();
                ConfigureRun(run, DocumentFonts.TimesNewRoman, fontSize);
                run.SetText($"{student.FirstName} {student.LastName}");

                paragraph.SetNumID("2");
            }
        }
    }
}
