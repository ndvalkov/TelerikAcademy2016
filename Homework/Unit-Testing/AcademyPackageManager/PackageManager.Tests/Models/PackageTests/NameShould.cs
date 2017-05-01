using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using PackageManager.Repositories.Contracts;

namespace PackageManager.Tests.Models.PackageTests
{
    [TestFixture]
    public class NameShould
    {
        [Test]
        public void SetCorrectly_WhenValidNameIsPassedToTheConstructor()
        {
            // Arrange
            var expecteName = "SomePackage";

            var versionMock = new Mock<IVersion>();
            var packageMock = new Mock<IPackage>();

            var dependencies = new List<IPackage> { packageMock.Object };

            // Act
            var package = new Package(expecteName, versionMock.Object, dependencies);

            // Assert
            Assert.AreEqual(expecteName, package.Name);
        }

        [Test]
        public void ThrowArgumentNullException_WhenInvalidNameIsPassedToTheConstructor()
        {
            // Arrange
            string invalidName = null;

            var versionMock = new Mock<IVersion>();
            var packageMock = new Mock<IPackage>();

            var dependencies = new List<IPackage> { packageMock.Object };

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new Package(invalidName, versionMock.Object, dependencies));
        }
    }
}