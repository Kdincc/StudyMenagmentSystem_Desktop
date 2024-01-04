using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8.Data.Entity.Generated;

namespace Task8.Tests
{
    [TestClass]
    public class ReportBuilderTests
    {
        [TestMethod]
        public void BuildGroupReport_IsCorrectReport()
        {
            Group testGroup = new()
            {
                Name = "test",
                Course = new() { Name = "test course" },
                Students = new List<Student>() { new Student { StudentId = 1, FirstName = "testName", LastName = "lastName" } }
            };
            GroupReport expected = new(testGroup.Course.Name, testGroup.Name, testGroup.Students.ToList());

            GroupReport actual = ReportBuilder.BuildGroupReport(testGroup);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BuildGroupReport_Throws_ArgumentNullException()
        {
            Group group = null;

            Assert.ThrowsException<ArgumentNullException>(() => ReportBuilder.BuildGroupReport(group));
        }
    }
}
