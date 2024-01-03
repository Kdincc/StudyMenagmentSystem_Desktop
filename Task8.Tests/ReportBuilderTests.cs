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
            Group testGroup = new Group()
            {
                Name = "test",
                Course = new Course() { Name = "test course" },
                Students = new List<Student>() { new Student { FirstName = "testName", LastName = "lastName" } }
            };
            GroupReport expected = new(testGroup.Name, testGroup.Course.Name, testGroup.Students.ToList());

            GroupReport actual = ReportBuilder.BuildGroupReport(testGroup);

            Assert.AreEqual(expected, actual);
        }
    }
}
