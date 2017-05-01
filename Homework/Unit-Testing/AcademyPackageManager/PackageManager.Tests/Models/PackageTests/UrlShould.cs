using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Models;
using PackageManager.Models.Contracts;

namespace PackageManager.Tests.Models.PackageTests
{
    [TestFixture]
    public class UrlShould
    {
        [Test]
        public void SetInTheCorrectFormat_WhenTheConstructorIsCalled()
        {
            // Arrange
            var name = "SomePackage";

            var expectedUrl = string.Format("1.0.2-{0}", VersionType.beta);

            var versionMock = new Mock<IVersion>();
            var packageMock = new Mock<IPackage>();

            var dependencies = new List<IPackage> { packageMock.Object };

            versionMock.SetupGet(x => x.Major).Returns(1);
            versionMock.SetupGet(x => x.Minor).Returns(0);
            versionMock.SetupGet(x => x.Patch).Returns(2);
            versionMock.SetupGet(x => x.VersionType).Returns(VersionType.beta);

            // Act
            var package = new Package(name, versionMock.Object, dependencies);

            // Assert
            Assert.AreEqual(expectedUrl, package.Url);
        }
    }
}