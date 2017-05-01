using Moq;
using NUnit.Framework;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;
using PackageManager.Repositories.Contracts;

namespace PackageManager.Tests.Models.ProjectTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void SetPackageRepositoryCorrectly_WhenOptionalParamaterPackagesIsNotPassed()
        {
            // Arrange
            var name = "SomeProject";
            var location = "somelocation";

            // Act
            var project = new Project(name, location);

            // Assert
            Assert.NotNull(project.PackageRepository);
            Assert.IsInstanceOf<PackageRepository>(project.PackageRepository);
        }

        [Test]
        public void SetPackageRepositoryCorrectly_WhenOptionalParamaterPackagesIsPassed()
        {
            // Arrange
            var name = "SomeProject";
            var location = "somelocation";
            var packagesMock = new Mock<IRepository<IPackage>>();

            // Act
            var project = new Project(name, location, packagesMock.Object);

            // Assert
            Assert.AreSame(packagesMock.Object, project.PackageRepository);
        }
    }
}