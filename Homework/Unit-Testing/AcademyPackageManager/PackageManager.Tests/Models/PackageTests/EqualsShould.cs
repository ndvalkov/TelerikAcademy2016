using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Models;
using PackageManager.Models.Contracts;

namespace PackageManager.Tests.Models.PackageTests
{
    [TestFixture]
    public class EqualsShould
    {
        [Test]
        public void ShouldReturnCorrectResult_WhenPassedObjectObjIsValidAndHasSameNameAndVersion()
        {
            // Arrange
            var expectedResult = true;

            var nameOfFirst = "SameNameOfPackage";
            var nameOfSecond = "SameNameOfPackage";

            var versionMock = new Mock<IVersion>();
            var otherVersionMock = new Mock<IVersion>();
            var packageMock = new Mock<IPackage>();

            var dependencies = new List<IPackage> { packageMock.Object };

            versionMock.SetupGet(x => x.Major).Returns(1);
            versionMock.SetupGet(x => x.Minor).Returns(0);
            versionMock.SetupGet(x => x.Patch).Returns(2);
            versionMock.SetupGet(x => x.VersionType).Returns(VersionType.beta);

            otherVersionMock.SetupGet(x => x.Major).Returns(1);
            otherVersionMock.SetupGet(x => x.Minor).Returns(0);
            otherVersionMock.SetupGet(x => x.Patch).Returns(2);
            otherVersionMock.SetupGet(x => x.VersionType).Returns(VersionType.beta);

            var thisPackage = new Package(nameOfFirst, versionMock.Object, dependencies);
            var otherPackage = new Package(nameOfSecond, otherVersionMock.Object, dependencies);

            // Act
            var result = thisPackage.Equals(otherPackage);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ThrowArgumentNullException_WhenPassedParameterObjIsNull()
        {
            // Arrange
            var nameOfPackage = "SomeNameOfPackage";

            var versionMock = new Mock<IVersion>();
            var packageMock = new Mock<IPackage>();

            var dependencies = new List<IPackage> { packageMock.Object };

            var package = new Package(nameOfPackage, versionMock.Object, dependencies);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => package.Equals(null));
        }

        [Test]
        public void ThrowArgumentException_WhenPassedParameterObjIsNotOfTypeIPackage()
        {
            // Arrange
            var someInvalidObject = new object();

            var nameOfPackage = "SomeNameOfPackage";

            var versionMock = new Mock<IVersion>();
            var packageMock = new Mock<IPackage>();

            var dependencies = new List<IPackage> { packageMock.Object };

            var package = new Package(nameOfPackage, versionMock.Object, dependencies);

            // Act and Assert
            Assert.Throws<ArgumentException>(() => package.Equals(someInvalidObject));
        }

        [Test]
        public void NotThrowException_WhenPassedParameterObjIsOfTypeIPackage()
        {
            // Arrange
            var nameOfPackage = "SomeNameOfPackage";

            var versionMock = new Mock<IVersion>();
            var packageMock = new Mock<IPackage>();

            var dependencies = new List<IPackage> { packageMock.Object };

            var package = new Package(nameOfPackage, versionMock.Object, dependencies);

            // Act and Assert
            Assert.DoesNotThrow(() => package.Equals(packageMock.Object));
        }

        [Test]
        public void ShouldReturnCorrectResult_WhenPassedObjectObjIsValidAndHasSameNameAndDifferentVersion()
        {
            // Arrange
            var expectedResult = false;

            var nameOfFirst = "SameNameOfPackage";
            var nameOfSecond = "SameNameOfPackage";

            var versionMock = new Mock<IVersion>();
            var otherVersionMock = new Mock<IVersion>();
            var packageMock = new Mock<IPackage>();

            var dependencies = new List<IPackage> { packageMock.Object };

            versionMock.SetupGet(x => x.Major).Returns(1);
            versionMock.SetupGet(x => x.Minor).Returns(1); // different
            versionMock.SetupGet(x => x.Patch).Returns(2);
            versionMock.SetupGet(x => x.VersionType).Returns(VersionType.beta);

            otherVersionMock.SetupGet(x => x.Major).Returns(1);
            otherVersionMock.SetupGet(x => x.Minor).Returns(0);
            otherVersionMock.SetupGet(x => x.Patch).Returns(2);
            otherVersionMock.SetupGet(x => x.VersionType).Returns(VersionType.beta);

            var thisPackage = new Package(nameOfFirst, versionMock.Object, dependencies);
            var otherPackage = new Package(nameOfSecond, otherVersionMock.Object, dependencies);

            // Act
            var result = thisPackage.Equals(otherPackage);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ShouldReturnCorrectResult_WhenPassedObjectObjIsValidAndHasDifferentName()
        {
            // Arrange
            var expectedResult = false;

            var nameOfFirst = "SameNameOfPackage";
            var nameOfSecond = "OtherDifferentNameOfPackage";

            var versionMock = new Mock<IVersion>();
            var otherVersionMock = new Mock<IVersion>();
            var packageMock = new Mock<IPackage>();

            var dependencies = new List<IPackage> { packageMock.Object };

            versionMock.SetupGet(x => x.Major).Returns(1);
            versionMock.SetupGet(x => x.Minor).Returns(0);
            versionMock.SetupGet(x => x.Patch).Returns(2);
            versionMock.SetupGet(x => x.VersionType).Returns(VersionType.beta);

            otherVersionMock.SetupGet(x => x.Major).Returns(1);
            otherVersionMock.SetupGet(x => x.Minor).Returns(0);
            otherVersionMock.SetupGet(x => x.Patch).Returns(2);
            otherVersionMock.SetupGet(x => x.VersionType).Returns(VersionType.beta);

            var thisPackage = new Package(nameOfFirst, versionMock.Object, dependencies);
            var otherPackage = new Package(nameOfSecond, otherVersionMock.Object, dependencies);

            // Act
            var result = thisPackage.Equals(otherPackage);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}