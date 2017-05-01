using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using PackageManager.Repositories;
using PackageManager.Info.Contracts;
using PackageManager.Models.Contracts;

namespace PackageManager.Tests.Repositories.PackageRepositoryTests
{
    public class UpdateShould
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedPackageIsNull()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            // var packageMock = new Mock<IPackage>();

            // var packages = new List<IPackage> { packageMock.Object };

            var packageRepsitory = new PackageRepository(loggerMock.Object);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => packageRepsitory.Update(null));
        }

        [Test]
        public void NotThrowException_WhenPassedPackageIsValid()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();
            var packageToUpdateMock = new Mock<IPackage>();
            var versionMock = new Mock<IVersion>();
            var versionToUpdateMock = new Mock<IVersion>();

            packageMock.SetupGet(x => x.Name).Returns("SameName");
            packageToUpdateMock.SetupGet(x => x.Name).Returns("SameName");

            packageMock.SetupGet(x => x.Version).Returns(versionMock.Object);
            packageToUpdateMock.SetupGet(x => x.Version).Returns(versionToUpdateMock.Object);

            var packages = new List<IPackage> { packageMock.Object };

            var packageRepsitory = new PackageRepository(loggerMock.Object, packages);

            // Act and Assert
            Assert.DoesNotThrow(() => packageRepsitory.Update(packageToUpdateMock.Object));
        }

        [Test]
        public void LogSpecificMessageAndThrowException_WhenPackageIsNotFound()
        {
            // Arrange
            var targetLogMessage = string.Format("{0}: The package does not exist!", "DifferentName");

            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();
            var packageToUpdateMock = new Mock<IPackage>();
            var versionMock = new Mock<IVersion>();
            var versionToUpdateMock = new Mock<IVersion>();

            packageMock.SetupGet(x => x.Name).Returns("SameName");
            packageToUpdateMock.SetupGet(x => x.Name).Returns("DifferentName"); // not found

            packageMock.SetupGet(x => x.Version).Returns(versionMock.Object);
            packageToUpdateMock.SetupGet(x => x.Version).Returns(versionToUpdateMock.Object);

            var packages = new List<IPackage> { packageMock.Object };

            var packageRepsitory = new PackageRepository(loggerMock.Object, packages);

            // Act And Assert
            Assert.Throws<ArgumentNullException>(() => packageRepsitory.Update(packageToUpdateMock.Object));
            loggerMock.Verify(x => x.Log(targetLogMessage), Times.Once);
        }

        [Test]
        public void ShouldSetPackageVersionAndReturnTrue_WhenSuccessfullyUpdated()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();
            var packageToUpdateMock = new Mock<IPackage>();
            var versionMock = new Mock<IVersion>();
            var versionToUpdateMock = new Mock<IVersion>();

            packageMock.SetupGet(x => x.Name).Returns("SameName");
            packageToUpdateMock.SetupGet(x => x.Name).Returns("SameName");

            packageMock.SetupGet(x => x.Version).Returns(versionMock.Object);
            packageToUpdateMock.SetupGet(x => x.Version).Returns(versionToUpdateMock.Object);

            var packages = new List<IPackage> { packageMock.Object };

            var packageRepsitory = new PackageRepository(loggerMock.Object, packages);

            packageToUpdateMock.Setup(x => x.CompareTo(packageMock.Object)).Returns(1);

            // Act
            var result = packageRepsitory.Update(packageToUpdateMock.Object);
            
            // Assert
            packageMock.VerifySet(x=>x.Version = packageToUpdateMock.Object.Version);
            Assert.AreEqual(result, true);
        }
    }
}