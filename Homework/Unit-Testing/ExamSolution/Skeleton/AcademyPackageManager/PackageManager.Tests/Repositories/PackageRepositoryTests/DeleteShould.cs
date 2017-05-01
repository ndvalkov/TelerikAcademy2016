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
    public class DeleteShould
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
            Assert.Throws<ArgumentNullException>(() => packageRepsitory.Delete(null));
        }

        [Test]
        public void NotThrowException_WhenPassedPackageIsValid()
        {
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();
            var packageToDeleteMock = new Mock<IPackage>();

            packageMock.SetupGet(x => x.Name).Returns("SomeName");
            packageToDeleteMock.SetupGet(x => x.Name).Returns("OtherName");

            var packages = new List<IPackage> { packageMock.Object };

            var packageRepsitory = new PackageRepository(loggerMock.Object, packages);

            packageMock.Setup(x => x.Equals(It.IsAny<IPackage>())).Returns(true);

            // Act and Assert
            Assert.DoesNotThrow(() => packageRepsitory.Delete(packageToDeleteMock.Object));
        }

        [Test]
        public void LogRespectiveMessageAndThrowArgumentNullException_WhenThePackageIsNotFound()
        {
            var someName = "SomeName";
            var targetLogMessage = string.Format("{0}: The package does not exist!", someName);

            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();
            var packageToDeleteMock = new Mock<IPackage>();

            packageMock.SetupGet(x => x.Name).Returns(someName);
            packageToDeleteMock.SetupGet(x => x.Name).Returns(someName);

            var packages = new List<IPackage> { packageMock.Object };

            var packageRepsitory = new PackageRepository(loggerMock.Object, packages);

            packageMock.Setup(x => x.Equals(It.IsAny<IPackage>())).Returns(false);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => packageRepsitory.Delete(packageToDeleteMock.Object));
            loggerMock.Verify(x => x.Log(targetLogMessage), Times.Once);
        }
    }
}