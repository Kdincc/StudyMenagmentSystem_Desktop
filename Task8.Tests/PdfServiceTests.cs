using iText.Layout;
using Moq;
using Task8.BL.Interfaces;
using Task8.Data.Entity.Generated;

namespace Task8.Tests
{
    [TestClass]
    public class PdfServiceTests
    {
        private readonly IPdfService pdfService = new PdfService(new Mock<IDocumentHelper<Document>>().Object);
        private readonly GroupReport _testGroupReport;

        public PdfServiceTests()
        {
            List<Student> testList = new()
            {
                new Student { FirstName = "Patsy", LastName = "Stone" },
                new Student { FirstName = "Minnie", LastName = "Paul" },
                new Student { FirstName = "Patsy", LastName = "Stone" },
                new Student { FirstName = "Minnie", LastName = "Paul" }
            };
            _testGroupReport = new("Test", "TestGroup", testList);
        }

        [TestMethod]
        public void BuidGroupReport_IsCreated()
        {
            string pathToSave = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{_testGroupReport.GroupNameHeader}.pdf");

            pdfService.WriteGroupReport(pathToSave, _testGroupReport);
            bool actual = File.Exists(pathToSave);

            Assert.IsTrue(actual);

            File.Delete(pathToSave);
        }
    }
}
