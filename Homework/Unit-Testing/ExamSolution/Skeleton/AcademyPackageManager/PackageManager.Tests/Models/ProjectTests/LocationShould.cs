using System;
using Moq;
using NUnit.Framework;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using PackageManager.Repositories.Contracts;

namespace PackageManager.Tests.Models.ProjectTests
{
    [TestFixture]
    public class LocationShould
    {
        [Test]
        public void SetCorrectly_WhenValidLocationIsPassedToTheConstructor()
        {
            // Arrange
            var name = "SomeProject";
            var expectedLocation = "somelocation";
            var packagesMock = new Mock<IRepository<IPackage>>();

            // Act
            var project = new Project(name, expectedLocation, packagesMock.Object);

            // Assert
            Assert.AreEqual(expectedLocation, project.Location);
        }

        [Test]
        public void ThrowArgumentNullException_WhenInvalidLocationIsPassedToTheConstructor()
        {
            // Arrange
            var name = "SomeProject";
            string invalidLocation = null;
            var packagesMock = new Mock<IRepository<IPackage>>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new Project(name, invalidLocation, packagesMock.Object));
        }
    }
}