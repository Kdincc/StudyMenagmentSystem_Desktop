using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8.BL.Interfaces;
using Task8.Data.Data;
using Task8.Data.Entity.Generated;

namespace Task8.Tests
{
    [TestClass]
    public class RepositoryServiceTests
    {
        private readonly Mock<Task6Context> moqContext = new();
        private readonly IRepositoryService _repositoryService;

        public RepositoryServiceTests()
        {
            Mock<DbSet<Group>> mockGroupDbSet = new();
            moqContext.Setup(x => x.Groups).Returns(mockGroupDbSet.Object);

            Mock<DbSet<Student>> mockStudentDbSet = new();
            moqContext.Setup(x => x.Students).Returns(mockStudentDbSet.Object);

            Mock<DbSet<Teacher>> mockTeacherDbSet = new();
            moqContext.Setup(x => x.Teachers).Returns(mockTeacherDbSet.Object);

            _repositoryService = new RepositoryService(moqContext.Object);
        }

        [TestMethod]
        public void Add_Group_AddsToDbContext()
        {
            Group groupToAdd = new();
            
            _repositoryService.Add(groupToAdd);

            moqContext.Verify(x => x.Groups.Add(It.IsAny<Group>()), Times.Once);
        }

        [TestMethod]
        public void Remove_Group_RemovesInDbContext()
        {
            Group groupToRemove = new();

            _repositoryService.Remove(groupToRemove);

            moqContext.Verify(x => x.Groups.Remove(It.IsAny<Group>()), Times.Once);
        }

        [TestMethod]
        public void Add_Student_AddsToDbContext()
        {
            Student studentToAdd = new();

            _repositoryService.Add(studentToAdd);

            moqContext.Verify(x => x.Students.Add(It.IsAny<Student>()), Times.Once);
        }

        [TestMethod]
        public void Remove_Student_RemovesInDbContext()
        {
            Student studentToRemove = new();

            _repositoryService.Remove(studentToRemove);

            moqContext.Verify(x => x.Students.Remove(It.IsAny<Student>()), Times.Once);
        }

        [TestMethod]
        public void Add_Teacher_AddsToDbContext()
        {
            Teacher teacherToAdd = new();

            _repositoryService.Add(teacherToAdd);

            moqContext.Verify(x => x.Teachers.Add(It.IsAny<Teacher>()), Times.Once);
        }

        [TestMethod]
        public void Remove_Teacher_RemovesInDbContext()
        {
            Teacher teacherToRemove = new();

            _repositoryService.Remove(teacherToRemove);

            moqContext.Verify(x => x.Teachers.Remove(It.IsAny<Teacher>()), Times.Once);
        }

        [TestMethod]
        public void SaveChanges_SaveChanesInDbContext()
        {
            _repositoryService.SaveChanges();

            moqContext.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
