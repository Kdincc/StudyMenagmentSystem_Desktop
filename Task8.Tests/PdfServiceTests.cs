using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8.BL.Interfaces;
using Task8.Data.Entity.Generated;

namespace Task8.Tests
{
    [TestClass]
    public class PdfServiceTests
    {
        private readonly IPdfService pdfService = new PdfService();
        private readonly Group _testGroup = new();
        private readonly List<Student> _testList = new()
        {
            new Student { FirstName = "Patsy", LastName = "Stone" },
            new Student { FirstName = "Minnie", LastName = "Paul" },
            new Student { FirstName = "Patsy", LastName = "Stone" },
            new Student { FirstName = "Minnie", LastName = "Paul" }
        };

        public PdfServiceTests()
        {
            _testGroup.Students = _testList;
            _testGroup.Name = "Test";
        }

        [TestMethod]
        public void BuidGroupReport_IsCreated()
        {
            string courseName = "TestCourse";
            string pathToSave = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{_testGroup.Name}.pdf");

            pdfService.BuidGroupReport(pathToSave, courseName, _testGroup);

            bool actual = File.Exists(pathToSave);

            Assert.IsTrue(actual);

            File.Delete(pathToSave);
        }

        [TestMethod]
        public void BuildGroupReport_IsCorrectContent()
        {

        }
    }
}
