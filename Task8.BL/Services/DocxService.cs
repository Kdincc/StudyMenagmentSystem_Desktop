using NPOI.XWPF.UserModel;
using System;
using System.IO;
using System.Linq;
using Task8.BL.Interfaces;

namespace Task8.BL.Services
{
    public class DocxService : IDocxService
    {
        private readonly IDocumentHelper<XWPFDocument> _helper;

        public DocxService(IDocumentHelper<XWPFDocument> helper)
        {
            _helper = helper;
        }

        public void WriteGroupReport(string savePath, GroupReport report)
        {
            ArgumentNullException.ThrowIfNull(savePath, nameof(savePath));
            ArgumentNullException.ThrowIfNull(report, nameof(report));

            int listFontSize = 14;
            int titleFontSize = 16;
            using XWPFDocument doc = new();

            _helper.BuildHeader(doc, report.CourseNameHeader, titleFontSize, DocumentFont.TimesNewRoman, true);

            _helper.BuildHeader(doc, report.GroupNameHeader, titleFontSize, DocumentFont.TimesNewRoman);

            _helper.BuildStudentList(doc, listFontSize, DocumentFont.TimesNewRoman, report.Students.ToList());

            using (FileStream fs = new(savePath, FileMode.Create, FileAccess.Write))
            {
                doc.Write(fs);
            }
        }
    }
}
