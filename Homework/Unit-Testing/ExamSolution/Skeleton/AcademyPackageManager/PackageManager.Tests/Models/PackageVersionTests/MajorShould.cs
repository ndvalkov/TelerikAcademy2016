using System;
using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Models;

namespace PackageManager.Tests.Models.PackageVersionTests
{
    [TestFixture]
    public class MajorShould
    {
        [Test]
        public void GetCorrectResult_WhenValidMajorIsPassedToTheConstructor()
        {
            // Arrange
            var expectedMajor = 1;
            var minor = 2;
            var patch = 1;
            var versionType = VersionType.alpha;

            var packageVersion = new PackageVersion(expectedMajor, minor, patch, versionType);

            // Act
            var result = packageVersion.Major;

            // Assert
            Assert.AreEqual(expectedMajor, result);
        }

        [Test]
        public void NotThrowException_WhenValidMajorIsPassedToTheConstructor()
        {
            // Arrange
            var major = 1;
            var minor = 2;
            var patch = 1;
            var versionType = VersionType.alpha;

            // Act and Assert
            Assert.DoesNotThrow(() => new PackageVersion(major, minor, patch, versionType));
        }

        [Test]
        public void ThrowArgumentException_WhenInvalidMajorIsPassedToTheConstructor()
        {
            // Arrange
            var invalidMajor = -1;
            var minor = 2;
            var patch = 1;
            var versionType = VersionType.alpha;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(invalidMajor, minor, patch, versionType));
        }
    }
}