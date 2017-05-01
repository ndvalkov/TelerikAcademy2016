using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;

namespace PackageManager.Tests.Models.PackageTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void SetDependenciesCorrectly_WhenOptionalParamaterDependenciesIsNotPassed()
        {
            // Arrange
            var name = "SomePackage";

            var versionMock = new Mock<IVersion>();

            // Act
            var package = new Package(name, versionMock.Object);

            // Assert
            Assert.NotNull(package.Dependencies);
            Assert.IsInstanceOf<ICollection<IPackage>>(package.Dependencies);
        }

        [Test]
        public void SetDependenciesCorrectly_WhenOptionalParamaterDependenciesIsPassed()
        {
            // Arrange
            var name = "SomePackage";

            var versionMock = new Mock<IVersion>();
            var packageMock = new Mock<IPackage>();

            var dependencies = new List<IPackage> {packageMock.Object};

            // Act
            var package = new Package(name, versionMock.Object, dependencies);

            // Assert
            Assert.AreSame(dependencies, package.Dependencies);
        }
    }
}