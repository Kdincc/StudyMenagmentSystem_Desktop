using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8.BL.Interfaces;
using Task8.BL.Models;
using Task8.Data.Entity.Generated;

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
    }
}
