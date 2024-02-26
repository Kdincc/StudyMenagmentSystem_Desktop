using Moq;
using Task8.BL.Interfaces;
using Task8.BL.Models;
using Task8.Data.Entity.Generated;

namespace Task8.Tests
{
    [TestClass]
    public class GroupEditTests
    {
        private readonly Mock<Repository> _repositoryMock = new();
        private readonly GroupEditModel _groupEditModel;

        public GroupEditTests()
        {
            _groupEditModel = new(_repositoryMock.Object);
        }

        [TestMethod]
        public void CreateStudent_IsAddedToRepository()
        {
            _groupEditModel.CreateStudent("Test", "Test");

            _repositoryMock.Verify(a => a.Add(It.IsAny<Student>()), Times.Once);
        }

        [TestMethod]
        [DataRow("Test", "", false)]
        [DataRow("", "Test", false)]
        public void CreateStudent_NullArguments_ReturnFalse(string name, string surname, bool expected)
        {
            bool actual;

            actual = _groupEditModel.CreateStudent(name, surname);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveStudent_IsRemovedFromRepository()
        {
            _groupEditModel.RemoveStudent(new Student());

            _repositoryMock.Verify(r => r.Remove(It.IsAny<Student>()));
        }

        [TestMethod]
        public void ChangeStudnetName_IsNameChanged()
        {
            string actualName;
            string expectedName = "Changed";
            Student student = new Student() { FirstName = "Test" };
            Group group = new() { Students = new List<Student>() { student } };

            _groupEditModel.Group = group;
            _groupEditModel.ChangeStudentName(student, expectedName);
            actualName = student.FirstName;

            Assert.AreEqual(expectedName, actualName);
        }

        [TestMethod]
        public void ChangeStudentLastName_IsChanged()
        {
            string actualLastName;
            string expectedLastName = "Changed";
            Student student = new Student() { FirstName = "Test" };
            Group group = new() { Students = new List<Student>() { student } };

            _groupEditModel.Group = group;
            _groupEditModel.ChangeStudentLastName(student, expectedLastName);
            actualLastName = student.LastName;

            Assert.AreEqual(expectedLastName, actualLastName);
        }
    }
}
