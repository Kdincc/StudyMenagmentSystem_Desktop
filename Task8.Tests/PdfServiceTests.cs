using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8.BL.Interfaces;
using Task8.Data.Entity.Generated;
using Task8.Tests.Properties;

namespace Task8.Tests
{
    [TestClass]
    public class PdfServiceTests
    {
        private readonly IPdfService pdfService = new PdfService();
        private readonly GroupReport _testGroupReport;
        private readonly List<Student> _testList = new()
        {
            new Student { FirstName = "Patsy", LastName = "Stone" },
            new Student { FirstName = "Minnie", LastName = "Paul" },
            new Student { FirstName = "Patsy", LastName = "Stone" },
            new Student { FirstName = "Minnie", LastName = "Paul" }
        };

        public PdfServiceTests()
        {
            _testGroupReport = new("Test", "TestGroup", _testList);
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

        [TestMethod]
        public void BuildGroupReport_IsCorrectContent()
        {
            string text = File.ReadAllText(FilesPath.TestPdfReport);

            Assert.AreEqual(text, "");
        }
    }
}
