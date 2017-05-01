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
    public class CompareToShould
    {
        [Test]
        public void ShouldReturnCorrectResult_WhenPassedObjectOtherIsValidAndHasSameNameAndVersionParameters()
        {
            // Arrange
            var expectedResult = 0;

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
            var result = thisPackage.CompareTo(otherPackage);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ShouldReturnCorrectResult_WhenPassedObjectOtherIsValidAndHasSameNameAndHigherVersion()
        {
            // Arrange
            var expectedResult = 1;

            var nameOfFirst = "SameNameOfPackage";
            var nameOfSecond = "SameNameOfPackage";

            var versionMock = new Mock<IVersion>();
            var otherVersionMock = new Mock<IVersion>();
            var packageMock = new Mock<IPackage>();

            var dependencies = new List<IPackage> { packageMock.Object };

            versionMock.SetupGet(x => x.Major).Returns(1);
            versionMock.SetupGet(x => x.Minor).Returns(1); // higher
            versionMock.SetupGet(x => x.Patch).Returns(2);
            versionMock.SetupGet(x => x.VersionType).Returns(VersionType.beta);

            otherVersionMock.SetupGet(x => x.Major).Returns(1);
            otherVersionMock.SetupGet(x => x.Minor).Returns(0);
            otherVersionMock.SetupGet(x => x.Patch).Returns(2);
            otherVersionMock.SetupGet(x => x.VersionType).Returns(VersionType.beta);

            var thisPackage = new Package(nameOfFirst, versionMock.Object, dependencies);
            var otherPackage = new Package(nameOfSecond, otherVersionMock.Object, dependencies);

            // Act
            var result = thisPackage.CompareTo(otherPackage);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ShouldReturnCorrectResult_WhenPassedObjectOtherIsValidAndHasSameNameAndLowerVersion()
        {
            // Arrange
            var expectedResult = -1;

            var nameOfFirst = "SameNameOfPackage";
            var nameOfSecond = "SameNameOfPackage";

            var versionMock = new Mock<IVersion>();
            var otherVersionMock = new Mock<IVersion>();
            var packageMock = new Mock<IPackage>();

            var dependencies = new List<IPackage> { packageMock.Object };

            versionMock.SetupGet(x => x.Major).Returns(1);
            versionMock.SetupGet(x => x.Minor).Returns(0);
            versionMock.SetupGet(x => x.Patch).Returns(1); // lower
            versionMock.SetupGet(x => x.VersionType).Returns(VersionType.beta);

            otherVersionMock.SetupGet(x => x.Major).Returns(1);
            otherVersionMock.SetupGet(x => x.Minor).Returns(0);
            otherVersionMock.SetupGet(x => x.Patch).Returns(2);
            otherVersionMock.SetupGet(x => x.VersionType).Returns(VersionType.beta);

            var thisPackage = new Package(nameOfFirst, versionMock.Object, dependencies);
            var otherPackage = new Package(nameOfSecond, otherVersionMock.Object, dependencies);

            // Act
            var result = thisPackage.CompareTo(otherPackage);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ThrowArgumentNullException_WhenPassedParameterOtherIsNull()
        {
            // Arrange
            var nameOfPackage = "SomeNameOfPackage";

            var versionMock = new Mock<IVersion>();
            var packageMock = new Mock<IPackage>();

            var dependencies = new List<IPackage> { packageMock.Object };

            var package = new Package(nameOfPackage, versionMock.Object, dependencies);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => package.CompareTo(null));
        }

        [Test]
        public void ThrowArgumentException_WhenPassedParameterOtherHasDifferentName()
        {
            // Arrange
            var expectedResult = 0;

            var nameOfFirst = "SameNameOfPackage";
            var nameOfSecond = "DifferentNameOfOtherPackage";

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

            // Act and Assert
            Assert.Throws<ArgumentException>(() => thisPackage.CompareTo(otherPackage));
        }


    }
}