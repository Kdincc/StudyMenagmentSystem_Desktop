using Moq;
using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8.BL.Interfaces;
using Task8.BL.Services;
using Task8.Data.Entity.Generated;

namespace Task8.Tests
{
    [TestClass]
    public class DocxServiceTests
    {
        private readonly IDocxService docxService = new DocxService(new Mock<IDocumentHelper<XWPFDocument>>().Object);
        private readonly GroupReport _testGroupReport;

        public DocxServiceTests()
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

            docxService.WriteGroupReport(pathToSave, _testGroupReport);
            bool actual = File.Exists(pathToSave);

            Assert.IsTrue(actual);

            File.Delete(pathToSave);
        }
    }
}
