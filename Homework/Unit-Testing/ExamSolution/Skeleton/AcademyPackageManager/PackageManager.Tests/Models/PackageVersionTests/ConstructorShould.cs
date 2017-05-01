using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Models;

namespace PackageManager.Tests.Models.PackageVersionTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void AssignMajorCorrectly_WhenPassedValidParameters()
        {
            // Arrange
            var major = 1;
            var minor = 2;
            var patch = 1;
            var versionType = VersionType.alpha;

            var packageVersion = new PackageVersion(major, minor, patch, versionType);

            // Act

            // Assert
            Assert.AreEqual(major, packageVersion.Major);
        }

        [Test]
        public void AssignMinorCorrectly_WhenPassedValidParameters()
        {
            // Arrange
            var major = 1;
            var minor = 2;
            var patch = 1;
            var versionType = VersionType.alpha;

            var packageVersion = new PackageVersion(major, minor, patch, versionType);

            // Act

            // Assert
            Assert.AreEqual(minor, packageVersion.Minor);
        }

        [Test]
        public void AssignPatchCorrectly_WhenPassedValidParameters()
        {
            // Arrange
            var major = 1;
            var minor = 2;
            var patch = 1;
            var versionType = VersionType.alpha;

            var packageVersion = new PackageVersion(major, minor, patch, versionType);

            // Act

            // Assert
            Assert.AreEqual(patch, packageVersion.Patch);
        }

        [Test]
        public void AssignVersionTypeCorrectly_WhenPassedValidParameters()
        {
            // Arrange
            var major = 1;
            var minor = 2;
            var patch = 1;
            var versionType = VersionType.alpha;

            var packageVersion = new PackageVersion(major, minor, patch, versionType);

            // Act

            // Assert
            Assert.AreEqual(versionType, packageVersion.VersionType);
        }
    }
}