using CsvHelper;
using CsvHelper.Configuration;
using Moq;
using System.Globalization;
using Task8.BL.Interfaces;
using Task8.BL.Models;
using Task8.Data.Entity.Generated;
using Task8.Tests.Properties;

namespace Task8.Tests
{
    [TestClass]
    public class CourseEditTests
    {

        private readonly Mock<IPdfService> pdfMock = new();
        private readonly Mock<IDocxService> docxMock = new();
        private readonly Mock<IRepositoryService> repositoryMock = new();
        private readonly Mock<ICsvService> svMock = new();
        private readonly ICourseEditModel model;

        public CourseEditTests()
        {
            model = new CourseEditModel(repositoryMock.Object, docxMock.Object, pdfMock.Object, svMock.Object);
        }

        [TestMethod]
        public void CreateGroup_IsAddedToRepository()
        {
            string newGroupName = "Test";

            model.CreateGroup(newGroupName);

            repositoryMock.Verify(x => x.Add(It.IsAny<Group>()), Times.Once);
        }

        [TestMethod]
        public void CreateGroup_EmptyNameGroup_NotAddToRepository()
        {
            string newGroupName = "";

            model.CreateGroup(newGroupName);

            repositoryMock.Verify(x => x.Add(It.IsAny<Group>()), Times.Never);
        }

        [TestMethod]
        public void RemoveGroup_IsRemovedFromRepository()
        {
            var group = new Group() { Name = "Test" };

            model.CreateGroup(group.Name);

            model.RemoveGroup(group);

            repositoryMock.Verify(x => x.Remove(group), Times.Once);
        }

        [TestMethod]
        public void RemoveGroup_GroupWithStudents_IsNotRemovedGroupFromRepository()
        {
            var group = new Group() { Students = new List<Student>() { new Student() }, Name = "Test" };

            model.CreateGroup(group.Name);

            model.RemoveGroup(group);

            repositoryMock.Verify(x => x.Remove(group), Times.Never);
        }

        [TestMethod]
        public void RemoveGroup_NullArgument_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => model.RemoveGroup(null));
        }

        [TestMethod]
        public void BuildDocxReport_IsWrited()
        {
            string testPath = "test";
            Group group = new() { Name = "", Students = new List<Student>(), Course = new Course() };

            model.BuildDocxReport(testPath, group);

            docxMock.Verify(x => x.WriteGroupReport(testPath, It.IsAny<GroupReport>()));
        }

        [TestMethod]
        public void BuildPDFReport_IsWrited()
        {
            string testPath = "test";
            Group group = new() { Name = "", Students = new List<Student>(), Course = new Course() };

            model.BuildPDFReport(testPath, group);

            pdfMock.Verify(x => x.WriteGroupReport(testPath, It.IsAny<GroupReport>()));
        }

        [TestMethod]
        public void ImportStudents_IsStudentsChanged()
        {
            string path = FilesPath.CsvCorrectRecords;
            Group group = new();
            List<Student> expectedStudents = new()
            {
                new Student { FirstName = "Patsy", LastName = "Stone" },
                new Student { FirstName = "Minnie", LastName = "Paul" },
                new Student { FirstName = "Patsy", LastName = "Stone" },
                new Student { FirstName = "Minnie", LastName = "Paul" },
                new Student { FirstName = "Nadya", LastName = "Call" }
            };

            svMock.Setup(x => x.GetStudentsFrom(path)).Returns(new CsvReadingResults<Student>(expectedStudents));

            model.ImportStudents(group, path);

            CollectionAssert.AreEqual(expectedStudents, group.Students.ToList());
        }

        [TestMethod]
        public void ImportStudents_IncorrectCsvResults_StudentsNotChanged()
        {
            string path = FilesPath.CsvIncorrectRecords;
            Group group = new();
            List <Student> expectedStudents = new()
            {
                new Student { FirstName = "Patsy", LastName = "Stone" },
                new Student { FirstName = "Minnie", LastName = "Paul" },
                new Student { FirstName = "Patsy", LastName = "Stone" },
                new Student { FirstName = "Minnie", LastName = "Paul" },
                new Student { FirstName = "Nadya", LastName = "Call" }
            };
            group.Students = expectedStudents;
            CsvContext csvContext = new(new CsvConfiguration(CultureInfo.InvariantCulture));
            HeaderValidationException exception = new(csvContext, Array.Empty<InvalidHeader>());

            svMock.Setup(x => x.GetStudentsFrom(path)).Returns(new CsvReadingResults<Student>(new List<Student>(), exception));

            model.ImportStudents(group, path);

            CollectionAssert.AreEqual(expectedStudents, group.Students.ToList());
        }

        [TestMethod]
        public void ExportStudents_IsCsvServiceExportStudents()
        {
            model.ExportStudents(new Group(), "");

            svMock.Verify(x => x.WriteStudentsTo(It.IsAny<ICollection<Student>>(), It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void ChangeGroupName_IsNameChangedCorrectly()
        {
            string expected = "ChangedName";
            Group group = new() { GroupId = 1, Name = "Test"};
            Course course = new() { Groups = new List<Group>() { group } };

            model.CurrentCourse = course;
            model.ChangeGroupName(group, expected);

            string actual = group.Name;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ChangeGroupTeacher_IstTeacherChangedCorrectly()
        {
            Teacher expected = new();
            Group group = new() { Teacher = new Teacher() };
            Course course = new() { Groups = new List<Group>() { group } };

            model.CurrentCourse = course;
            model.ChangeGroupTeacher(group, expected);
            Teacher actual = group.Teacher;

            Assert.AreEqual(expected, actual);
        }
    }
}
