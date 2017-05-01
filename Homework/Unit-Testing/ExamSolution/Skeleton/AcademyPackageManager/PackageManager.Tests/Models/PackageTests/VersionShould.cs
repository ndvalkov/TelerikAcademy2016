using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using PackageManager.Models;
using PackageManager.Models.Contracts;

namespace PackageManager.Tests.Models.PackageTests
{
    [TestFixture]
    public class VersionShould
    {
        [Test]
        public void SetCorrectly_WhenValidVersionIsPassedToTheConstructor()
        {
            // Arrange
            var name = "SomePackage";

            var versionMock = new Mock<IVersion>();
            var packageMock = new Mock<IPackage>();

            var dependencies = new List<IPackage> { packageMock.Object };

            // Act
            var package = new Package(name, versionMock.Object, dependencies);

            // Assert
            Assert.AreSame(versionMock.Object, package.Version);
        }

        [Test]
        public void ThrowArgumentNullException_WhenInvalidNameIsPassedToTheConstructor()
        {
            // Arrange
            string name = "SomePackage";

            IVersion invalidVersion = null;
            var packageMock = new Mock<IPackage>();

            var dependencies = new List<IPackage> { packageMock.Object };

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new Package(name, invalidVersion, dependencies));
        }

        [Test]
        public void AssignCorrectly_WhenValidVersionIsSet()
        {
            // Arrange
            var name = "SomePackage";

            var versionMock = new Mock<IVersion>();
            var packageMock = new Mock<IPackage>();

            var expectedVersionMock = new Mock<IVersion>();

            var dependencies = new List<IPackage> { packageMock.Object };

            // Act
            var package = new Package(name, versionMock.Object, dependencies);

            package.Version = expectedVersionMock.Object;

            // Assert
            Assert.AreSame(expectedVersionMock.Object, package.Version);
        }

        /*[Test]
        public void ThrowArgumentNullException_WhenInvalidVersionIsSet()
        {
            // Arrange
            string name = "SomePackage";

            var versionMock = new Mock<IVersion>();
            IVersion invalidVersion = null;
            var packageMock = new Mock<IPackage>();

            var dependencies = new List<IPackage> { packageMock.Object };

            var package = new Package(name, versionMock.Object, dependencies);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => package.Version = invalidVersion);
        }*/
    }
}