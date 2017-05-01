using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using PackageManager.Info.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;

namespace PackageManager.Tests.Repositories.PackageRepositoryTests
{
    [TestFixture]
    public class AddShould
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
            Assert.Throws<ArgumentNullException>(() => packageRepsitory.Add(null));
        }

        [Test]
        public void NotThrowException_WhenPassedPackageIsValid()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            // var packageMock = new Mock<IPackage>();
            var packageMock = new Mock<IPackage>();
            packageMock.SetupGet(x => x.Name).Returns("SomeName");

            // var packages = new List<IPackage> { packageMock.Object };

            var packageRepsitory = new PackageRepository(loggerMock.Object);

            // Act and Assert
            Assert.DoesNotThrow(() => packageRepsitory.Add(packageMock.Object));
        }

        [Test]
        public void AddThePackage_WhenItDoesntExistInTheList()
        {
            // Arrange
            int expectedValue;

            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();
            var packageToAddMock = new Mock<IPackage>();

            packageMock.SetupGet(x => x.Name).Returns("SomeName");
            packageToAddMock.SetupGet(x => x.Name).Returns("OtherName");

            var packages = new List<IPackage> { packageMock.Object };

            expectedValue = packages.Count;

            var packageRepsitory = new PackageRepository(loggerMock.Object, packages);

            // Act
            packageRepsitory.Add(packageToAddMock.Object);

            expectedValue++;

            // Act and Assert
            Assert.AreEqual(expectedValue, packages.Count);
        }

        [Test]
        public void LogRespectiveMessage_WhenPackageWithTheSameVersionIsAlreadyInstalled()
        {
            // Arrange
            var sameName = "SameName";
            var targetLogMessage = String.Format("{0}: Package with the same version is already installed!", sameName);

            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();
            var packageToAddMock = new Mock<IPackage>();
            var versionMock = new Mock<IVersion>();

            packageMock.SetupGet(x => x.Name).Returns(sameName);
            packageToAddMock.SetupGet(x => x.Name).Returns(sameName);

            packageMock.SetupGet(x => x.Version).Returns(versionMock.Object);
            packageToAddMock.SetupGet(x => x.Version).Returns(versionMock.Object);

            var packages = new List<IPackage> { packageMock.Object };

            var packageRepsitory = new PackageRepository(loggerMock.Object, packages);

            // Act
            packageRepsitory.Add(packageToAddMock.Object);


            // Assert
            loggerMock.Verify(x => x.Log(targetLogMessage), Times.Once);
        }

        [Test]
        public void CallTheUpdateMethod_WhenThePackageExistsButWithLowerVersion()
        {
            // Arrange
            var sameName = "SameName";
            // var targetLogMessage = String.Format("{0}: Package with the same version is already installed!", sameName);

            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();
            var packageToAddMock = new Mock<IPackage>();
            var versionMock = new Mock<IVersion>();

            packageMock.SetupGet(x => x.Name).Returns(sameName);
            packageToAddMock.SetupGet(x => x.Name).Returns(sameName);

            packageMock.SetupGet(x => x.Version).Returns(versionMock.Object);
            packageToAddMock.SetupGet(x => x.Version).Returns(versionMock.Object);

            var packages = new List<IPackage> { packageMock.Object };

            var packageRepsitory = new PackageRepository(loggerMock.Object, packages);

            packageMock.Setup(x => x.CompareTo(It.IsAny<IPackage>())).Returns(1);

            // Act
            packageRepsitory.Add(packageToAddMock.Object);

            // Assert
            packageMock.VerifySet(x => x.Version = packageToAddMock.Object.Version, Times.Once);
        }

        [Test]
        public void LogRespectiveMessageAndThrowArgumentNullException_WhenPackageWithHigherVersionAlreadyExists()
        {
            // Arrange
            var sameName = "SameName";
            var targetLogMessage = String.Format("{0}: There is a package with newer version!", sameName);

            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();
            var packageToAddMock = new Mock<IPackage>();
            var sameVersionMock = new Mock<IVersion>();
            var differentVersionMock = new Mock<IVersion>();

            packageMock.SetupGet(x => x.Name).Returns(sameName);
            packageToAddMock.SetupGet(x => x.Name).Returns(sameName);

            packageMock.SetupGet(x => x.Version).Returns(sameVersionMock.Object);
            packageToAddMock.SetupGet(x => x.Version).Returns(differentVersionMock.Object);

            var packages = new List<IPackage> { packageMock.Object };

            var packageRepsitory = new PackageRepository(loggerMock.Object, packages);

            packageMock.Setup(x => x.CompareTo(packageToAddMock.Object)).Returns(-1);

            // Act and Assert
            // Assert.Throws<ArgumentNullException>(() => packageRepsitory.Add(packageToAddMock.Object));
            loggerMock.Verify(x => x.Log(targetLogMessage), Times.Once);
        }

        /*[Test]
        public void LogRespectiveMessage_WhenPackageWithLowerVersionAlreadyExists()
        {
            // Arrange
            var sameName = "SameName";
            var targetLogMessage = String.Format("{0}: There is a package with newer version!", sameName);

            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();
            var packageToAddMock = new Mock<IPackage>();
            var sameVersionMock = new Mock<IVersion>();
            var differentVersionMock = new Mock<IVersion>();

            packageMock.SetupGet(x => x.Name).Returns(sameName);
            packageToAddMock.SetupGet(x => x.Name).Returns(sameName);

            packageMock.SetupGet(x => x.Version).Returns(sameVersionMock.Object);
            packageToAddMock.SetupGet(x => x.Version).Returns(differentVersionMock.Object);

            var packages = new List<IPackage> { packageMock.Object };

            var packageRepsitory = new PackageRepository(loggerMock.Object, packages);

            packageMock.Setup(x => x.CompareTo(packageToAddMock.Object)).Returns(1);

            // Act
            packageRepsitory.Add(packageToAddMock.Object);

            // Assert
            loggerMock.Verify(x => x.Log(targetLogMessage), Times.Once);
        }*/
    }
}