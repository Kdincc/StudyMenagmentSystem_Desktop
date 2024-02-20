using Task8.BL.Interfaces;
using Task8.Data.Entity.Generated;
using Task8.Tests.Properties;

namespace Task8.Tests
{
    [TestClass]
    public class CsvServiceTests
    {
        private readonly ICsvService _csvService = new CsvService();
        private readonly List<Student> _testList = new()
        {
            new Student { FirstName = "Patsy", LastName = "Stone" },
            new Student { FirstName = "Minnie", LastName = "Paul" },
            new Student { FirstName = "Patsy", LastName = "Stone" },
            new Student { FirstName = "Minnie", LastName = "Paul" },
            new Student { FirstName = "Nadya", LastName = "Call" }
        };

        [TestMethod]
        public void GetStudentsFrom_CorrectReading()
        {
            string recordsPath = FilesPath.CsvCorrectRecords;
            List<Student> expected = _testList;

            List<Student> actual = _csvService.GetStudentsFrom(recordsPath).Records.ToList();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetStudentsFrom_IncorrectRecords()
        {
            string recordPath = FilesPath.CsvIncorrectRecords;

            bool actual = _csvService.GetStudentsFrom(recordPath).Error is not null;

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void WriteStudentsTo_CorrectWriting()
        {
            string pathToWrite = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.csv");
            List<Student> expected = _testList;

            _csvService.WriteStudentsTo(expected, pathToWrite);
            List<Student> actual = _csvService.GetStudentsFrom(pathToWrite).Records.ToList();

            CollectionAssert.AreEqual(expected, actual);

            File.Delete(pathToWrite);
        }
    }
}