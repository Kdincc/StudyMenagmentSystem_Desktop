using Moq;
using Task8.BL.Interfaces;
using Task8.BL.Models;
using Task8.Data.Entity.Generated;

namespace Task8.Tests
{
    [TestClass]
    public class TeachersModelTests
    {
        private readonly Mock<Repository> _repositoryService = new();
        private readonly TeachersModel _teachersModel;

        public TeachersModelTests()
        {
            _teachersModel = new(_repositoryService.Object);
        }

        [TestMethod]
        public void CreateTeacher_IsAddedToRepository()
        {
            _teachersModel.CreateTeacher("Test", "Test");

            _repositoryService.Verify(a => a.Add(It.IsAny<Teacher>()), Times.Once);
        }

        [TestMethod]
        public void ChangeTeacherName_IsChanged()
        {
            string actual;
            string expected = "Changed";
            Teacher teacher = new() { Name = "Test" };

            _repositoryService.SetupGet(t => t.Teachers).Returns(new List<Teacher>() { teacher });

            _teachersModel.ChangeTeacherName(teacher, expected);
            actual = teacher.Name;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ChangeTeacherSurname_IsChanged()
        {
            string actual;
            string expected = "Changed";
            Teacher teacher = new() { Surname = "Test" };

            _repositoryService.SetupGet(t => t.Teachers).Returns(new List<Teacher>() { teacher });

            _teachersModel.ChangeTeacherSurname(teacher, expected);
            actual = teacher.Surname;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveTeacher_IsRewmovedFromRepository()
        {
            Teacher teacher = new();

            _teachersModel.RemoveTeacher(teacher);

            _repositoryService.Verify(r => r.Remove(teacher), Times.Once);
        }
    }
}
