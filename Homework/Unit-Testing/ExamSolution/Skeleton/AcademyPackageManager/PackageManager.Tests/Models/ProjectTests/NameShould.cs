using System;
using Moq;
using NUnit.Framework;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using PackageManager.Repositories.Contracts;

namespace PackageManager.Tests.Models.ProjectTests
{
    [TestFixture]
    public class NameShould
    {
        [Test]
        public void SetCorrectly_WhenValidNameIsPassedToTheConstructor()
        {
            // Arrange
            var expectedName = "SomeProject";
            var location = "somelocation";
            var packagesMock = new Mock<IRepository<IPackage>>();

            // Act
            var project = new Project(expectedName, location, packagesMock.Object);

            // Assert
            Assert.AreEqual(expectedName, project.Name);
        }

        [Test]
        public void ThrowArgumentNullException_WhenInvalidNameIsPassedToTheConstructor()
        {
            // Arrange
            string invalidName = null;
            var location = "somelocation";
            var packagesMock = new Mock<IRepository<IPackage>>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new Project(invalidName, location, packagesMock.Object));
        }
    }
}