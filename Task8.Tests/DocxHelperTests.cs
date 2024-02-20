using NPOI.XWPF.UserModel;
using Task8.Data.Entity.Generated;

namespace Task8.Tests
{
    [TestClass]
    public class DocxHelperTests
    {
        private readonly DocxHelper _helper = new();

        [TestMethod]
        public void BuildHeader_IsBuildedCorrectly()
        {
            XWPFDocument docx = new();
            DocumentFont font = DocumentFont.TimesNewRoman;
            string expectdFontName = font.ToString();
            string expectedText = "Test";
            int expectedFontSize = 14;
            string actualText;
            int actualFontSize;
            string actualFontName;

            _helper.BuildHeader(docx, expectedText, expectedFontSize, font);
            var run = docx.Paragraphs.First().Runs.First();
            actualText = run.Text;
            actualFontSize = (int)run.FontSize;
            actualFontName = run.FontName;

            Assert.AreEqual(expectedText, actualText);
            Assert.AreEqual(expectedFontSize, actualFontSize);
            Assert.AreEqual(expectdFontName, actualFontName);
        }

        [TestMethod]
        public void BuildStudentList_IsBuildedCorrectly()
        {
            XWPFDocument docx = new();
            ICollection<Student> students = new List<Student>()
            {
                new Student { FirstName = "John", LastName = "Doe" },
                new Student { FirstName = "Jane", LastName = "Smith" }
            };

            _helper.BuildStudentList(docx, 14, DocumentFont.TimesNewRoman, students);
            var paragraphs = docx.Paragraphs;

            int index = 0;
            foreach (var student in students)
            {
                string expectedText = $"{student.FirstName} {student.LastName}";
                string actualText = paragraphs[index].Text;
                Assert.AreEqual(expectedText, actualText);
                index++;
            }
        }
    }
}
